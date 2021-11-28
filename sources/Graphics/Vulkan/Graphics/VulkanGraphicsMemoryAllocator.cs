// Copyright © Tanner Gooding and Contributors. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

// This file includes code based on the Allocator class from https://github.com/GPUOpen-LibrariesAndSDKs/D3D12MemoryAllocator/
// The original code is Copyright © Advanced Micro Devices, Inc. All rights reserved. Licensed under the MIT License (MIT).

using System;
using System.Collections.Generic;
using System.Numerics;
using TerraFX.Interop.Vulkan;
using TerraFX.Threading;
using static TerraFX.Interop.Vulkan.VkImageType;
using static TerraFX.Interop.Vulkan.VkMemoryHeapFlags;
using static TerraFX.Interop.Vulkan.VkMemoryPropertyFlags;
using static TerraFX.Interop.Vulkan.VkPhysicalDeviceType;
using static TerraFX.Interop.Vulkan.VkSampleCountFlags;
using static TerraFX.Interop.Vulkan.VkStructureType;
using static TerraFX.Interop.Vulkan.Vulkan;
using static TerraFX.Threading.VolatileState;
using static TerraFX.Utilities.VulkanUtilities;

namespace TerraFX.Graphics;

/// <inheritdoc />
public sealed unsafe class VulkanGraphicsMemoryAllocator : GraphicsMemoryAllocator
{
    private readonly VulkanGraphicsMemoryHeapCollection[] _heapCollections;
    private VolatileState _state;

    internal VulkanGraphicsMemoryAllocator(VulkanGraphicsDevice device, in GraphicsMemoryAllocatorSettings settings)
        : base(device, in settings)
    {
        var memoryTypeCount = Device.Adapter.VulkanPhysicalDeviceMemoryProperties.memoryTypeCount;
        _heapCollections = new VulkanGraphicsMemoryHeapCollection[memoryTypeCount];

        for (uint memoryTypeIndex = 0; memoryTypeIndex < memoryTypeCount; memoryTypeIndex++)
        {
            _heapCollections[memoryTypeIndex] = new VulkanGraphicsMemoryHeapCollection(Device, this, memoryTypeIndex);
        }

        // TODO: UpdateBudget
        _ = _state.Transition(to: Initialized);
    }

    /// <summary>Finalizes an instance of the <see cref="VulkanGraphicsMemoryAllocator" /> class.</summary>
    ~VulkanGraphicsMemoryAllocator() => Dispose(isDisposing: true);

    /// <inheritdoc />
    public override int Count => _heapCollections.Length;

    /// <inheritdoc cref="GraphicsDeviceObject.Device" />
    public new VulkanGraphicsDevice Device => (VulkanGraphicsDevice)base.Device;

    /// <inheritdoc />
    public override VulkanGraphicsBuffer<TMetadata> CreateBuffer<TMetadata>(GraphicsBufferKind kind, GraphicsResourceCpuAccess cpuAccess, ulong size, GraphicsMemoryRegionAllocationFlags allocationFlags = GraphicsMemoryRegionAllocationFlags.None)
    {
        var vulkanDevice = Device.VulkanDevice;

        var bufferCreateInfo = new VkBufferCreateInfo {
            sType = VK_STRUCTURE_TYPE_BUFFER_CREATE_INFO,
            size = size,
            usage = GetVulkanBufferUsageKind(kind, cpuAccess)
        };

        VkBuffer vulkanBuffer;
        ThrowExternalExceptionIfNotSuccess(vkCreateBuffer(vulkanDevice, &bufferCreateInfo, pAllocator: null, &vulkanBuffer));

        VkMemoryRequirements memoryRequirements;
        vkGetBufferMemoryRequirements(vulkanDevice, vulkanBuffer, &memoryRequirements);

        var index = GetHeapCollectionIndex(cpuAccess, memoryRequirements.memoryTypeBits);
        ref readonly var heapCollection = ref _heapCollections[index];

        var heapRegion = heapCollection.Allocate(memoryRequirements.size, memoryRequirements.alignment, allocationFlags);
        return new VulkanGraphicsBuffer<TMetadata>(Device, kind, in heapRegion, cpuAccess, vulkanBuffer);
    }

    /// <inheritdoc />
    public override VulkanGraphicsTexture<TMetadata> CreateTexture<TMetadata>(GraphicsTextureKind kind, GraphicsResourceCpuAccess cpuAccess, uint width, uint height = 1, ushort depth = 1, GraphicsMemoryRegionAllocationFlags allocationFlags = GraphicsMemoryRegionAllocationFlags.None, TexelFormat texelFormat = default)
    {
        var vulkanDevice = Device.VulkanDevice;

        var imageCreateInfo = new VkImageCreateInfo {
            sType = VK_STRUCTURE_TYPE_IMAGE_CREATE_INFO,
            imageType = kind switch {
                GraphicsTextureKind.OneDimensional => VK_IMAGE_TYPE_1D,
                GraphicsTextureKind.TwoDimensional => VK_IMAGE_TYPE_2D,
                GraphicsTextureKind.ThreeDimensional => VK_IMAGE_TYPE_3D,
                _ => default,
            },
            format = Map(texelFormat),
            extent = new VkExtent3D {
                width = width,
                height = height,
                depth = depth,
            },
            mipLevels = 1,
            arrayLayers = 1,
            samples = VK_SAMPLE_COUNT_1_BIT,
            usage = GetVulkanImageUsageKind(kind, cpuAccess),
        };

        VkImage vulkanImage;
        ThrowExternalExceptionIfNotSuccess(vkCreateImage(vulkanDevice, &imageCreateInfo, pAllocator: null, &vulkanImage));

        VkMemoryRequirements memoryRequirements;
        vkGetImageMemoryRequirements(vulkanDevice, vulkanImage, &memoryRequirements);

        var index = GetHeapCollectionIndex(cpuAccess, memoryRequirements.memoryTypeBits);
        ref readonly var heapCollection = ref _heapCollections[index];

        var heapRegion = heapCollection.Allocate(memoryRequirements.size, memoryRequirements.alignment, allocationFlags);
        return new VulkanGraphicsTexture<TMetadata>(Device, kind, in heapRegion, cpuAccess, width, height, depth, vulkanImage);
    }

    /// <inheritdoc />
    public override void GetBudget(GraphicsMemoryHeapCollection heapCollection, out GraphicsMemoryBudget budget) => GetBudget((VulkanGraphicsMemoryHeapCollection)heapCollection, out budget);

    /// <inheritdoc cref="GetBudget(GraphicsMemoryHeapCollection, out GraphicsMemoryBudget)" />
    public void GetBudget(VulkanGraphicsMemoryHeapCollection heapCollection, out GraphicsMemoryBudget budget) => budget = new GraphicsMemoryBudget {
        EstimatedBudget = ulong.MaxValue,
        EstimatedUsage = 0,
        TotalAllocatedRegionSize = 0,
        TotalHeapSize = 0,
    };

    /// <inheritdoc />
    public override IEnumerator<VulkanGraphicsMemoryHeapCollection> GetEnumerator() => throw new NotImplementedException();

    /// <inheritdoc />
    protected override void Dispose(bool isDisposing)
    {
        var priorState = _state.BeginDispose();

        if (priorState < Disposing)
        {
            foreach (var heapCollection in _heapCollections)
            {
                heapCollection?.Dispose();
            }
        }

        _state.EndDispose();
    }

    private int GetHeapCollectionIndex(GraphicsResourceCpuAccess cpuAccess, uint memoryTypeBits)
    {
        var isIntegratedGpu = Device.Adapter.VulkanPhysicalDeviceProperties.deviceType == VK_PHYSICAL_DEVICE_TYPE_INTEGRATED_GPU;
        var canBeMultiInstance = false;

        VkMemoryPropertyFlags requiredMemoryPropertyFlags = 0;
        VkMemoryPropertyFlags preferredMemoryPropertyFlags = 0;
        VkMemoryPropertyFlags unpreferredMemoryPropertyFlags = 0;

        switch (cpuAccess)
        {
            case GraphicsResourceCpuAccess.GpuOnly:
            {
                preferredMemoryPropertyFlags |= isIntegratedGpu ? default : VK_MEMORY_PROPERTY_DEVICE_LOCAL_BIT;
                canBeMultiInstance = true;
                break;
            }

            case GraphicsResourceCpuAccess.GpuToCpu:
            {
                requiredMemoryPropertyFlags |= VK_MEMORY_PROPERTY_HOST_VISIBLE_BIT;
                preferredMemoryPropertyFlags |= VK_MEMORY_PROPERTY_HOST_CACHED_BIT;
                break;
            }

            case GraphicsResourceCpuAccess.CpuToGpu:
            {
                requiredMemoryPropertyFlags |= VK_MEMORY_PROPERTY_HOST_VISIBLE_BIT;
                preferredMemoryPropertyFlags |= isIntegratedGpu ? default : VK_MEMORY_PROPERTY_DEVICE_LOCAL_BIT;
                break;
            }
        }

        var index = -1;
        var lowestCost = int.MaxValue;

        ref readonly var memoryProperties = ref Device.Adapter.VulkanPhysicalDeviceMemoryProperties;

        for (var i = 0; i < _heapCollections.Length; i++)
        {
            if ((memoryTypeBits & (1 << i)) == 0)
            {
                continue;
            }

            ref var memoryType = ref memoryProperties.memoryTypes[i];
            ref var memoryHeap = ref memoryProperties.memoryHeaps[(int)memoryType.heapIndex];

            var memoryPropertyFlags = memoryType.propertyFlags;

            if ((requiredMemoryPropertyFlags & ~memoryPropertyFlags) != 0)
            {
                continue;
            }

            if (!canBeMultiInstance && memoryHeap.flags.HasFlag(VK_MEMORY_HEAP_MULTI_INSTANCE_BIT))
            {
                continue;
            }

            // The cost is calculated as the number of preferred bits not present
            // added to the the number of unpreferred bits that are present. A value
            // of zero represents an ideal match and allows us to return early.

            var cost = BitOperations.PopCount((uint)(preferredMemoryPropertyFlags & ~memoryPropertyFlags))
                     + BitOperations.PopCount((uint)(unpreferredMemoryPropertyFlags & memoryPropertyFlags));

            if (cost >= lowestCost)
            {
                continue;
            }

            index = i;

            if (cost == 0)
            {
                break;
            }

            lowestCost = cost;
        }

        return index;
    }
}
