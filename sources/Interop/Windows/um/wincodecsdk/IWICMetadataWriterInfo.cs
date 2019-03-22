// Copyright © Tanner Gooding and Contributors. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

// Ported from um\wincodecsdk.h in the Windows SDK for Windows 10.0.15063.0
// Original source is Copyright © Microsoft. All rights reserved.

using System;
using System.Runtime.InteropServices;
using System.Security;
using TerraFX.Utilities;
using static TerraFX.Utilities.InteropUtilities;

namespace TerraFX.Interop
{
    [Guid("B22E3FBA-3925-4323-B5C1-9EBFC430F236")]
    [Unmanaged]
    public unsafe struct IWICMetadataWriterInfo
    {
        #region Fields
        public readonly Vtbl* lpVtbl;
        #endregion

        #region IUnknown Delegates
        [SuppressUnmanagedCodeSecurity]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall, BestFitMapping = false, CharSet = CharSet.Unicode, SetLastError = false, ThrowOnUnmappableChar = false)]
        [return: ComAliasName("HRESULT")]
        public /* static */ delegate int _QueryInterface(
            [In] IWICMetadataWriterInfo* This,
            [In, ComAliasName("REFIID")] Guid* riid,
            [Out] void** ppvObject
        );

        [SuppressUnmanagedCodeSecurity]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall, BestFitMapping = false, CharSet = CharSet.Unicode, SetLastError = false, ThrowOnUnmappableChar = false)]
        [return: ComAliasName("ULONG")]
        public /* static */ delegate uint _AddRef(
            [In] IWICMetadataWriterInfo* This
        );

        [SuppressUnmanagedCodeSecurity]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall, BestFitMapping = false, CharSet = CharSet.Unicode, SetLastError = false, ThrowOnUnmappableChar = false)]
        [return: ComAliasName("ULONG")]
        public /* static */ delegate uint _Release(
            [In] IWICMetadataWriterInfo* This
        );
        #endregion

        #region IWICComponentInfo Delegates
        [SuppressUnmanagedCodeSecurity]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall, BestFitMapping = false, CharSet = CharSet.Unicode, SetLastError = false, ThrowOnUnmappableChar = false)]
        [return: ComAliasName("HRESULT")]
        public /* static */ delegate int _GetComponentType(
            [In] IWICMetadataWriterInfo* This,
            [Out] WICComponentType* pType
        );

        [SuppressUnmanagedCodeSecurity]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall, BestFitMapping = false, CharSet = CharSet.Unicode, SetLastError = false, ThrowOnUnmappableChar = false)]
        [return: ComAliasName("HRESULT")]
        public /* static */ delegate int _GetCLSID(
            [In] IWICMetadataWriterInfo* This,
            [Out, ComAliasName("CLSID")] Guid* pclsid
        );

        [SuppressUnmanagedCodeSecurity]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall, BestFitMapping = false, CharSet = CharSet.Unicode, SetLastError = false, ThrowOnUnmappableChar = false)]
        [return: ComAliasName("HRESULT")]
        public /* static */ delegate int _GetSigningStatus(
            [In] IWICMetadataWriterInfo* This,
            [Out, ComAliasName("DWORD")] uint* pStatus
        );

        [SuppressUnmanagedCodeSecurity]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall, BestFitMapping = false, CharSet = CharSet.Unicode, SetLastError = false, ThrowOnUnmappableChar = false)]
        [return: ComAliasName("HRESULT")]
        public /* static */ delegate int _GetAuthor(
            [In] IWICMetadataWriterInfo* This,
            [In, ComAliasName("UINT")] uint cchAuthor,
            [In, Out, Optional, ComAliasName("WCHAR[]")] char* wzAuthor,
            [Out, ComAliasName("UINT")] uint* pcchActual
        );

        [SuppressUnmanagedCodeSecurity]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall, BestFitMapping = false, CharSet = CharSet.Unicode, SetLastError = false, ThrowOnUnmappableChar = false)]
        [return: ComAliasName("HRESULT")]
        public /* static */ delegate int _GetVendorGUID(
            [In] IWICMetadataWriterInfo* This,
            [Out, ComAliasName("GUID")] Guid* pguidVendor
        );

        [SuppressUnmanagedCodeSecurity]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall, BestFitMapping = false, CharSet = CharSet.Unicode, SetLastError = false, ThrowOnUnmappableChar = false)]
        [return: ComAliasName("HRESULT")]
        public /* static */ delegate int _GetVersion(
            [In] IWICMetadataWriterInfo* This,
            [In, ComAliasName("UINT")] uint cchVersion,
            [In, Out, Optional, ComAliasName("WCHAR[]")] char* wzVersion,
            [Out, ComAliasName("UINT")] uint* pcchActual
        );

        [SuppressUnmanagedCodeSecurity]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall, BestFitMapping = false, CharSet = CharSet.Unicode, SetLastError = false, ThrowOnUnmappableChar = false)]
        [return: ComAliasName("HRESULT")]
        public /* static */ delegate int _GetSpecVersion(
            [In] IWICMetadataWriterInfo* This,
            [In, ComAliasName("UINT")] uint cchSpecVersion,
            [In, Out, Optional, ComAliasName("WCHAR[]")] char* wzSpecVersion,
            [Out, ComAliasName("UINT")] uint* pcchActual
        );

        [SuppressUnmanagedCodeSecurity]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall, BestFitMapping = false, CharSet = CharSet.Unicode, SetLastError = false, ThrowOnUnmappableChar = false)]
        [return: ComAliasName("HRESULT")]
        public /* static */ delegate int _GetFriendlyName(
            [In] IWICMetadataWriterInfo* This,
            [In, ComAliasName("UINT")] uint cchFriendlyName,
            [In, Out, Optional, ComAliasName("WCHAR[]")] char* wzFriendlyName,
            [Out, ComAliasName("UINT")] uint* pcchActual
        );
        #endregion

        #region IWICMetadataHandlerInfo Delegates
        [SuppressUnmanagedCodeSecurity]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall, BestFitMapping = false, CharSet = CharSet.Unicode, SetLastError = false, ThrowOnUnmappableChar = false)]
        [return: ComAliasName("HRESULT")]
        public /* static */ delegate int _GetMetadataFormat(
            [In] IWICMetadataWriterInfo* This,
            [Out, ComAliasName("GUID")] Guid* pguidMetadataFormat
        );

        [SuppressUnmanagedCodeSecurity]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall, BestFitMapping = false, CharSet = CharSet.Unicode, SetLastError = false, ThrowOnUnmappableChar = false)]
        [return: ComAliasName("HRESULT")]
        public /* static */ delegate int _GetContainerFormats(
            [In] IWICMetadataWriterInfo* This,
            [In, ComAliasName("UINT")] uint cContainerFormats,
            [In, Out, Optional, ComAliasName("GUID[]")] Guid* pguidContainerFormats,
            [Out, ComAliasName("UINT")] uint* pcchActual
        );

        [SuppressUnmanagedCodeSecurity]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall, BestFitMapping = false, CharSet = CharSet.Unicode, SetLastError = false, ThrowOnUnmappableChar = false)]
        [return: ComAliasName("HRESULT")]
        public /* static */ delegate int _GetDeviceManufacturer(
            [In] IWICMetadataWriterInfo* This,
            [In, ComAliasName("UINT")] uint cchDeviceManufacturer,
            [In, Out, Optional, ComAliasName("WCHAR[]")] char* wzDeviceManufacturer,
            [Out, ComAliasName("UINT")] uint* pcchActual
        );

        [SuppressUnmanagedCodeSecurity]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall, BestFitMapping = false, CharSet = CharSet.Unicode, SetLastError = false, ThrowOnUnmappableChar = false)]
        [return: ComAliasName("HRESULT")]
        public /* static */ delegate int _GetDeviceModels(
            [In] IWICMetadataWriterInfo* This,
            [In, ComAliasName("UINT")] uint cchDeviceModels,
            [In, Out, Optional, ComAliasName("WCHAR[]")] char* wzDeviceModels,
            [Out, ComAliasName("UINT")] uint* pcchActual
        );

        [SuppressUnmanagedCodeSecurity]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall, BestFitMapping = false, CharSet = CharSet.Unicode, SetLastError = false, ThrowOnUnmappableChar = false)]
        [return: ComAliasName("HRESULT")]
        public /* static */ delegate int _DoesRequireFullStream(
            [In] IWICMetadataWriterInfo* This,
            [Out, ComAliasName("BOOL")] int* pfRequiresFullStream
        );

        [SuppressUnmanagedCodeSecurity]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall, BestFitMapping = false, CharSet = CharSet.Unicode, SetLastError = false, ThrowOnUnmappableChar = false)]
        [return: ComAliasName("HRESULT")]
        public /* static */ delegate int _DoesSupportPadding(
            [In] IWICMetadataWriterInfo* This,
            [Out, ComAliasName("BOOL")] int* pfSupportsPadding
        );

        [SuppressUnmanagedCodeSecurity]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall, BestFitMapping = false, CharSet = CharSet.Unicode, SetLastError = false, ThrowOnUnmappableChar = false)]
        [return: ComAliasName("HRESULT")]
        public /* static */ delegate int _DoesRequireFixedSize(
            [In] IWICMetadataWriterInfo* This,
            [Out, ComAliasName("BOOL")] int* pfFixedSize
        );
        #endregion

        #region Delegates
        [SuppressUnmanagedCodeSecurity]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall, BestFitMapping = false, CharSet = CharSet.Unicode, SetLastError = false, ThrowOnUnmappableChar = false)]
        [return: ComAliasName("HRESULT")]
        public /* static */ delegate int _GetHeader(
            [In] IWICMetadataWriterInfo* This,
            [In, ComAliasName("REFGUID")] Guid* guidContainerFormat,
            [In, ComAliasName("UINT")] uint cbSize,
            [Out] WICMetadataHeader* pHeader = null,
            [Out, ComAliasName("UINT")] uint* pcbActual = null
        );

        [SuppressUnmanagedCodeSecurity]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall, BestFitMapping = false, CharSet = CharSet.Unicode, SetLastError = false, ThrowOnUnmappableChar = false)]
        [return: ComAliasName("HRESULT")]
        public /* static */ delegate int _CreateInstance(
            [In] IWICMetadataWriterInfo* This,
            [Out] IWICMetadataWriter** ppIWriter = null
        );
        #endregion

        #region IUnknown Methods
        [return: ComAliasName("HRESULT")]
        public int QueryInterface(
            [In, ComAliasName("REFIID")] Guid* riid,
            [Out] void** ppvObject
        )
        {
            fixed (IWICMetadataWriterInfo* This = &this)
            {
                return MarshalFunction<_QueryInterface>(lpVtbl->QueryInterface)(
                    This,
                    riid,
                    ppvObject
                );
            }
        }

        [return: ComAliasName("ULONG")]
        public uint AddRef()
        {
            fixed (IWICMetadataWriterInfo* This = &this)
            {
                return MarshalFunction<_AddRef>(lpVtbl->AddRef)(
                    This
                );
            }
        }

        [return: ComAliasName("ULONG")]
        public uint Release()
        {
            fixed (IWICMetadataWriterInfo* This = &this)
            {
                return MarshalFunction<_Release>(lpVtbl->Release)(
                    This
                );
            }
        }
        #endregion

        #region IWICComponentInfo Methods
        [return: ComAliasName("HRESULT")]
        public int GetComponentType(
            [Out] WICComponentType* pType
        )
        {
            fixed (IWICMetadataWriterInfo* This = &this)
            {
                return MarshalFunction<_GetComponentType>(lpVtbl->GetComponentType)(
                    This,
                    pType
                );
            }
        }

        [return: ComAliasName("HRESULT")]
        public int GetCLSID(
            [Out, ComAliasName("CLSID")] Guid* pclsid
        )
        {
            fixed (IWICMetadataWriterInfo* This = &this)
            {
                return MarshalFunction<_GetCLSID>(lpVtbl->GetCLSID)(
                    This,
                    pclsid
                );
            }
        }

        [return: ComAliasName("HRESULT")]
        public int GetSigningStatus(
            [Out, ComAliasName("DWORD")] uint* pStatus
        )
        {
            fixed (IWICMetadataWriterInfo* This = &this)
            {
                return MarshalFunction<_GetSigningStatus>(lpVtbl->GetSigningStatus)(
                    This,
                    pStatus
                );
            }
        }

        [return: ComAliasName("HRESULT")]
        public int GetAuthor(
            [In, ComAliasName("UINT")] uint cchAuthor,
            [In, Out, Optional, ComAliasName("WCHAR[]")] char* wzAuthor,
            [Out, ComAliasName("UINT")] uint* pcchActual
        )
        {
            fixed (IWICMetadataWriterInfo* This = &this)
            {
                return MarshalFunction<_GetAuthor>(lpVtbl->GetAuthor)(
                    This,
                    cchAuthor,
                    wzAuthor,
                    pcchActual
                );
            }
        }

        [return: ComAliasName("HRESULT")]
        public int GetVendorGUID(
            [Out, ComAliasName("GUID")] Guid* pguidVendor
        )
        {
            fixed (IWICMetadataWriterInfo* This = &this)
            {
                return MarshalFunction<_GetVendorGUID>(lpVtbl->GetVendorGUID)(
                    This,
                    pguidVendor
                );
            }
        }

        [return: ComAliasName("HRESULT")]
        public int GetVersion(
            [In, ComAliasName("UINT")] uint cchVersion,
            [In, Out, Optional, ComAliasName("WCHAR[]")] char* wzVersion,
            [Out, ComAliasName("UINT")] uint* pcchActual
        )
        {
            fixed (IWICMetadataWriterInfo* This = &this)
            {
                return MarshalFunction<_GetVersion>(lpVtbl->GetVersion)(
                    This,
                    cchVersion,
                    wzVersion,
                    pcchActual
                );
            }
        }

        [return: ComAliasName("HRESULT")]
        public int GetSpecVersion(
            [In, ComAliasName("UINT")] uint cchSpecVersion,
            [In, Out, Optional, ComAliasName("WCHAR[]")] char* wzSpecVersion,
            [Out, ComAliasName("UINT")] uint* pcchActual
        )
        {
            fixed (IWICMetadataWriterInfo* This = &this)
            {
                return MarshalFunction<_GetSpecVersion>(lpVtbl->GetSpecVersion)(
                    This,
                    cchSpecVersion,
                    wzSpecVersion,
                    pcchActual
                );
            }
        }

        [return: ComAliasName("HRESULT")]
        public int GetFriendlyName(
            [In, ComAliasName("UINT")] uint cchFriendlyName,
            [In, Out, Optional, ComAliasName("WCHAR[]")] char* wzFriendlyName,
            [Out, ComAliasName("UINT")] uint* pcchActual
        )
        {
            fixed (IWICMetadataWriterInfo* This = &this)
            {
                return MarshalFunction<_GetFriendlyName>(lpVtbl->GetFriendlyName)(
                    This,
                    cchFriendlyName,
                    wzFriendlyName,
                    pcchActual
                );
            }
        }
        #endregion

        #region IWICMetadataHandlerInfo Methods
        [return: ComAliasName("HRESULT")]
        public int GetMetadataFormat(
            [Out, ComAliasName("GUID")] Guid* pguidMetadataFormat
        )
        {
            fixed (IWICMetadataWriterInfo* This = &this)
            {
                return MarshalFunction<_GetMetadataFormat>(lpVtbl->GetMetadataFormat)(
                    This,
                    pguidMetadataFormat
                );
            }
        }

        [return: ComAliasName("HRESULT")]
        public int GetContainerFormats(
            [In, ComAliasName("UINT")] uint cContainerFormats,
            [In, Out, Optional, ComAliasName("GUID[]")] Guid* pguidContainerFormats,
            [Out, ComAliasName("UINT")] uint* pcchActual
        )
        {
            fixed (IWICMetadataWriterInfo* This = &this)
            {
                return MarshalFunction<_GetContainerFormats>(lpVtbl->GetContainerFormats)(
                    This,
                    cContainerFormats,
                    pguidContainerFormats,
                    pcchActual
                );
            }
        }

        [return: ComAliasName("HRESULT")]
        public int GetDeviceManufacturer(
            [In, ComAliasName("UINT")] uint cchDeviceManufacturer,
            [In, Out, Optional, ComAliasName("WCHAR[]")] char* wzDeviceManufacturer,
            [Out, ComAliasName("UINT")] uint* pcchActual
        )
        {
            fixed (IWICMetadataWriterInfo* This = &this)
            {
                return MarshalFunction<_GetDeviceManufacturer>(lpVtbl->GetDeviceManufacturer)(
                    This,
                    cchDeviceManufacturer,
                    wzDeviceManufacturer,
                    pcchActual
                );
            }
        }

        [return: ComAliasName("HRESULT")]
        public int GetDeviceModels(
            [In, ComAliasName("UINT")] uint cchDeviceModels,
            [In, Out, Optional, ComAliasName("WCHAR[]")] char* wzDeviceModels,
            [Out, ComAliasName("UINT")] uint* pcchActual
        )
        {
            fixed (IWICMetadataWriterInfo* This = &this)
            {
                return MarshalFunction<_GetDeviceModels>(lpVtbl->GetDeviceModels)(
                    This,
                    cchDeviceModels,
                    wzDeviceModels,
                    pcchActual
                );
            }
        }

        [return: ComAliasName("HRESULT")]
        public int DoesRequireFullStream(
            [Out, ComAliasName("BOOL")] int* pfRequiresFullStream
        )
        {
            fixed (IWICMetadataWriterInfo* This = &this)
            {
                return MarshalFunction<_DoesRequireFullStream>(lpVtbl->DoesRequireFullStream)(
                    This,
                    pfRequiresFullStream
                );
            }
        }

        [return: ComAliasName("HRESULT")]
        public int DoesSupportPadding(
            [Out, ComAliasName("BOOL")] int* pfSupportsPadding
        )
        {
            fixed (IWICMetadataWriterInfo* This = &this)
            {
                return MarshalFunction<_DoesSupportPadding>(lpVtbl->DoesSupportPadding)(
                    This,
                    pfSupportsPadding
                );
            }
        }

        [return: ComAliasName("HRESULT")]
        public int DoesRequireFixedSize(
            [Out, ComAliasName("BOOL")] int* pfFixedSize
        )
        {
            fixed (IWICMetadataWriterInfo* This = &this)
            {
                return MarshalFunction<_DoesRequireFixedSize>(lpVtbl->DoesRequireFixedSize)(
                    This,
                    pfFixedSize
                );
            }
        }
        #endregion

        #region Methods
        [return: ComAliasName("HRESULT")]
        public int GetHeader(
            [In, ComAliasName("REFGUID")] Guid* guidContainerFormat,
            [In, ComAliasName("UINT")] uint cbSize,
            [Out] WICMetadataHeader* pHeader = null,
            [Out, ComAliasName("UINT")] uint* pcbActual = null
        )
        {
            fixed (IWICMetadataWriterInfo* This = &this)
            {
                return MarshalFunction<_GetHeader>(lpVtbl->GetHeader)(
                    This,
                    guidContainerFormat,
                    cbSize,
                    pHeader,
                    pcbActual
                );
            }
        }

        [return: ComAliasName("HRESULT")]
        public int CreateInstance(
            [Out] IWICMetadataWriter** ppIWriter = null
        )
        {
            fixed (IWICMetadataWriterInfo* This = &this)
            {
                return MarshalFunction<_CreateInstance>(lpVtbl->CreateInstance)(
                    This,
                    ppIWriter
                );
            }
        }
        #endregion

        #region Structs
        [Unmanaged]
        public struct Vtbl
        {
            #region IUnknown Fields
            public IntPtr QueryInterface;

            public IntPtr AddRef;

            public IntPtr Release;
            #endregion

            #region IWICComponentInfo Fields
            public IntPtr GetComponentType;

            public IntPtr GetCLSID;

            public IntPtr GetSigningStatus;

            public IntPtr GetAuthor;

            public IntPtr GetVendorGUID;

            public IntPtr GetVersion;

            public IntPtr GetSpecVersion;

            public IntPtr GetFriendlyName;
            #endregion

            #region IWICMetadataHandlerInfo Fields
            public IntPtr GetMetadataFormat;

            public IntPtr GetContainerFormats;

            public IntPtr GetDeviceManufacturer;

            public IntPtr GetDeviceModels;

            public IntPtr DoesRequireFullStream;

            public IntPtr DoesSupportPadding;

            public IntPtr DoesRequireFixedSize;
            #endregion

            #region Fields
            public IntPtr GetHeader;

            public IntPtr CreateInstance;
            #endregion
        }
        #endregion
    }
}
