// Copyright © Tanner Gooding and Contributors. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System;

namespace TerraFX.Graphics;

/// <summary>Represents a graphics context, which can be used for executing commands.</summary>
public abstract class GraphicsContext : GraphicsDeviceObject
{
    /// <summary>Initializes a new instance of the <see cref="GraphicsContext" /> class.</summary>
    /// <param name="device">The device for which the context is being created.</param>
    /// <exception cref="ArgumentNullException"><paramref name="device" /> is <c>null</c>.</exception>
    protected GraphicsContext(GraphicsDevice device)
        : base(device)
    {
    }

    /// <summary>Gets the fence used by the context for synchronization.</summary>
    /// <exception cref="ObjectDisposedException">The context has been disposed.</exception>
    public abstract GraphicsFence Fence { get; }

    /// <summary>Copies the contents of a buffer view to a separate buffer view.</summary>
    /// <param name="destination">The destination buffer view.</param>
    /// <param name="source">The source buffer view.</param>
    /// <exception cref="ArgumentNullException"><paramref name="destination" /> is <c>null</c>.</exception>
    /// <exception cref="ArgumentNullException"><paramref name="source" /> is <c>null</c>.</exception>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="destination" /> is shorter than <paramref name="source" />.</exception>
    /// <exception cref="ObjectDisposedException">The context has been disposed.</exception>
    public abstract void Copy(GraphicsBufferView destination, GraphicsBufferView source);

    /// <summary>Copies the contents of a buffer view to a texture view.</summary>
    /// <param name="destination">The destination dimensional texture view.</param>
    /// <param name="source">The source buffer view.</param>
    /// <exception cref="ArgumentNullException"><paramref name="destination" /> is <c>null</c>.</exception>
    /// <exception cref="ArgumentNullException"><paramref name="source" /> is <c>null</c>.</exception>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="destination" /> is shorter than <paramref name="source" />.</exception>
    /// <exception cref="ObjectDisposedException">The context has been disposed.</exception>
    public abstract void Copy(GraphicsTextureView destination, GraphicsBufferView source);

    /// <summary>Flushes the graphics context.</summary>
    public abstract void Flush();

    /// <summary>Resets the graphics context.</summary>
    public abstract void Reset();
}
