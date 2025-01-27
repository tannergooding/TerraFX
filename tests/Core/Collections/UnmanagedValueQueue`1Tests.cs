// Copyright © Tanner Gooding and Contributors. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System;
using NUnit.Framework;
using TerraFX.Collections;

// Not a correct fix for mutable structs

namespace TerraFX.UnitTests.Collections;

/// <summary>Provides a set of tests covering the <see cref="UnmanagedValueQueue{T}" /> struct.</summary>
internal static class UnmanagedValueQueueTests
{
    /// <summary>Provides validation of the <see cref="UnmanagedValueQueue{T}.UnmanagedValueQueue()" /> constructor.</summary>
    [Test]
    public static void CtorTest()
    {
        using var valueQueue = new UnmanagedValueQueue<int>();

        Assert.That(() => valueQueue,
            Has.Property("Capacity").EqualTo((nuint)0)
               .And.Count.EqualTo((nuint)0)
        );
    }

    /// <summary>Provides validation of the <see cref="UnmanagedValueQueue{T}.UnmanagedValueQueue(nuint, nuint)" /> constructor.</summary>
    [Test]
    public static void CtorNUIntNUIntTest()
    {
        using (var valueQueue = new UnmanagedValueQueue<int>(5))
        {
            Assert.That(() => valueQueue,
                Has.Property("Capacity").EqualTo((nuint)5)
                   .And.Count.EqualTo((nuint)0)
            );
        }

        using (var valueQueue = new UnmanagedValueQueue<int>(5, 2))
        {
            Assert.That(() => valueQueue,
                Has.Property("Capacity").EqualTo((nuint)5)
                   .And.Count.EqualTo((nuint)0)
            );
        }

        Assert.That(() => new UnmanagedValueQueue<int>(5, 3),
            Throws.InstanceOf<ArgumentOutOfRangeException>()
                    .And.Property("ActualValue").EqualTo((nuint)3)
                    .And.Property("ParamName").EqualTo("alignment")
        );

        using (var valueQueue = new UnmanagedValueQueue<int>(0, 2))
        {
            Assert.That(() => valueQueue,
                Has.Property("Capacity").EqualTo((nuint)0)
                   .And.Count.EqualTo((nuint)0)
            );
        }

        Assert.That(() => new UnmanagedValueQueue<int>(0, 3),
            Throws.InstanceOf<ArgumentOutOfRangeException>()
                    .And.Property("ActualValue").EqualTo((nuint)3)
                    .And.Property("ParamName").EqualTo("alignment")
        );
    }

    /// <summary>Provides validation of the <see cref="UnmanagedValueQueue{T}.UnmanagedValueQueue(UnmanagedReadOnlySpan{T}, nuint)" /> constructor.</summary>
    [Test]
    public static void CtorUnmanagedReadOnlySpanNUIntTest()
    {
        using var array = new UnmanagedArray<int>(3);

        array[0] = 1;
        array[1] = 2;
        array[2] = 3;

        using (var valueQueue = new UnmanagedValueQueue<int>(array.AsUnmanagedSpan()))
        {
            Assert.That(() => valueQueue,
                Has.Property("Capacity").EqualTo((nuint)3)
                   .And.Count.EqualTo((nuint)3)
            );
        }

        using (var valueQueue = new UnmanagedValueQueue<int>(array.AsUnmanagedSpan(), 2))
        {
            Assert.That(() => valueQueue,
                Has.Property("Capacity").EqualTo((nuint)3)
                   .And.Count.EqualTo((nuint)3)
            );
        }

        Assert.That(() => new UnmanagedValueQueue<int>(array.AsUnmanagedSpan(), 3),
            Throws.InstanceOf<ArgumentOutOfRangeException>()
                    .And.Property("ActualValue").EqualTo((nuint)3)
                    .And.Property("ParamName").EqualTo("alignment")
        );

        using (var valueQueue = new UnmanagedValueQueue<int>(UnmanagedArray.Empty<int>().AsUnmanagedSpan()))
        {
            Assert.That(() => valueQueue,
                Has.Property("Capacity").EqualTo((nuint)0)
                   .And.Count.EqualTo((nuint)0)
            );
        }

        using (var valueQueue = new UnmanagedValueQueue<int>(UnmanagedArray.Empty<int>().AsUnmanagedSpan(), 2))
        {
            Assert.That(() => valueQueue,
                Has.Property("Capacity").EqualTo((nuint)0)
                   .And.Count.EqualTo((nuint)0)
            );
        }

        Assert.That(() => new UnmanagedValueQueue<int>(UnmanagedArray.Empty<int>().AsUnmanagedSpan(), 3),
            Throws.InstanceOf<ArgumentOutOfRangeException>()
                    .And.Property("ActualValue").EqualTo((nuint)3)
                    .And.Property("ParamName").EqualTo("alignment")
        );

        using (var valueQueue = new UnmanagedValueQueue<int>(new UnmanagedArray<int>().AsUnmanagedSpan()))
        {
            Assert.That(() => valueQueue,
                Has.Property("Capacity").EqualTo((nuint)0)
                   .And.Count.EqualTo((nuint)0)
            );
        }

        using (var valueQueue = new UnmanagedValueQueue<int>(new UnmanagedArray<int>().AsUnmanagedSpan(), 2))
        {
            Assert.That(() => valueQueue,
                Has.Property("Capacity").EqualTo((nuint)0)
                   .And.Count.EqualTo((nuint)0)
            );
        }

        Assert.That(() => new UnmanagedValueQueue<int>(new UnmanagedArray<int>().AsUnmanagedSpan(), 3),
            Throws.InstanceOf<ArgumentOutOfRangeException>()
                    .And.Property("ActualValue").EqualTo((nuint)3)
                    .And.Property("ParamName").EqualTo("alignment")
        );
    }

    /// <summary>Provides validation of the <see cref="UnmanagedValueQueue{T}.UnmanagedValueQueue(UnmanagedArray{T}, bool)" /> constructor.</summary>
    [Test]
    public static void CtorUnmanagedArrayBooleanTest()
    {
        var array = new UnmanagedArray<int>(3);

        array[0] = 1;
        array[1] = 2;
        array[2] = 3;

        using (var valueQueue = new UnmanagedValueQueue<int>(array, takeOwnership: false))
        {
            Assert.That(() => valueQueue,
                Has.Property("Capacity").EqualTo((nuint)3)
                   .And.Count.EqualTo((nuint)3)
            );
        }

        using (var valueQueue = new UnmanagedValueQueue<int>(array, takeOwnership: true))
        {
            Assert.That(() => valueQueue,
                Has.Property("Capacity").EqualTo((nuint)3)
                   .And.Count.EqualTo((nuint)3)
            );
        }

        using (var valueQueue = new UnmanagedValueQueue<int>([], takeOwnership: false))
        {
            Assert.That(() => valueQueue,
                Has.Property("Capacity").EqualTo((nuint)0)
                   .And.Count.EqualTo((nuint)0)
            );
        }

        using (var valueQueue = new UnmanagedValueQueue<int>([], takeOwnership: true))
        {
            Assert.That(() => valueQueue,
                Has.Property("Capacity").EqualTo((nuint)0)
                   .And.Count.EqualTo((nuint)0)
            );
        }

        using (var valueQueue = new UnmanagedValueQueue<int>(new UnmanagedArray<int>(), takeOwnership: false))
        {
            Assert.That(() => valueQueue,
                Has.Property("Capacity").EqualTo((nuint)0)
                   .And.Count.EqualTo((nuint)0)
            );
        }

        using (var valueQueue = new UnmanagedValueQueue<int>(new UnmanagedArray<int>(), takeOwnership: true))
        {
            Assert.That(() => valueQueue,
                Has.Property("Capacity").EqualTo((nuint)0)
                   .And.Count.EqualTo((nuint)0)
            );
        }

        Assert.That(() => new UnmanagedValueQueue<int>(array: default, takeOwnership: false),
            Throws.ArgumentNullException
                  .And.Property("ParamName").EqualTo("array")
        );

        Assert.That(() => new UnmanagedValueQueue<int>(array: default, takeOwnership: true),
            Throws.ArgumentNullException
                    .And.Property("ParamName").EqualTo("array")
        );
    }

    /// <summary>Provides validation of the <see cref="UnmanagedValueQueue.Clear{T}(ref UnmanagedValueQueue{T})" /> method.</summary>
    [Test]
    public static void ClearTest()
    {
        var array = new UnmanagedArray<int>(3);

        array[0] = 1;
        array[1] = 2;
        array[2] = 3;

        var valueQueue = new UnmanagedValueQueue<int>(array, takeOwnership: false);
        {
            valueQueue.Clear();

            Assert.That(() => valueQueue,
                Has.Property("Capacity").EqualTo((nuint)3)
                   .And.Count.EqualTo((nuint)0)
            );
        }
        valueQueue.Dispose();

        valueQueue = new UnmanagedValueQueue<int>(array, takeOwnership: false);
        {
            _ = valueQueue.Dequeue();

            valueQueue.Enqueue(4);
            valueQueue.Clear();

            Assert.That(() => valueQueue,
                Has.Property("Capacity").EqualTo((nuint)3)
                   .And.Count.EqualTo((nuint)0)
            );
        }
        valueQueue.Dispose();

        valueQueue = new UnmanagedValueQueue<int>(array, takeOwnership: true);
        {
            _ = valueQueue.Dequeue();

            valueQueue.Enqueue(4);
            valueQueue.Enqueue(5);

            valueQueue.Clear();

            Assert.That(() => valueQueue,
                Has.Property("Capacity").EqualTo((nuint)6)
                   .And.Count.EqualTo((nuint)0)
            );
        }
        valueQueue.Dispose();

        valueQueue = new UnmanagedValueQueue<int>();
        {
            valueQueue.Clear();

            Assert.That(() => valueQueue,
                Has.Property("Capacity").EqualTo((nuint)0)
                   .And.Count.EqualTo((nuint)0)
            );
        }
        valueQueue.Dispose();
    }

    /// <summary>Provides validation of the <see cref="UnmanagedValueQueue.Contains{T}(ref readonly UnmanagedValueQueue{T}, T)" /> method.</summary>
    [Test]
    public static void ContainsTest()
    {
        var array = new UnmanagedArray<int>(3);

        array[0] = 1;
        array[1] = 2;
        array[2] = 3;

        var valueQueue = new UnmanagedValueQueue<int>(array, takeOwnership: true);
        {
            Assert.That(() => valueQueue.Contains(1),
                Is.True
            );

            Assert.That(() => valueQueue.Contains(4),
                Is.False
            );

            _ = valueQueue.Dequeue();
            valueQueue.Enqueue(4);

            Assert.That(() => valueQueue.Contains(1),
                Is.False
            );

            Assert.That(() => valueQueue.Contains(4),
                Is.True
            );

            _ = valueQueue.Dequeue();
            valueQueue.Enqueue(5);
            valueQueue.Enqueue(6);

            Assert.That(() => valueQueue.Contains(2),
                Is.False
            );

            Assert.That(() => valueQueue.Contains(5),
                Is.True
            );

            Assert.That(() => valueQueue.Contains(6),
                Is.True
            );
        }
        valueQueue.Dispose();

        valueQueue = new UnmanagedValueQueue<int>();
        {
            Assert.That(() => valueQueue.Contains(0),
                Is.False
            );
        }
        valueQueue.Dispose();
    }

    /// <summary>Provides validation of the <see cref="UnmanagedValueQueue.CopyTo{T}(ref readonly UnmanagedValueQueue{T}, UnmanagedSpan{T})" /> method.</summary>
    [Test]
    public static void CopyToUnmanagedSpanTest()
    {
        var array = new UnmanagedArray<int>(3);

        array[0] = 1;
        array[1] = 2;
        array[2] = 3;

        var valueQueue = new UnmanagedValueQueue<int>(array, takeOwnership: true);
        {
            using (var destination = new UnmanagedArray<int>(3))
            {
                valueQueue.CopyTo(destination);

                Assert.That(() => destination[0],
                    Is.EqualTo(1)
                );

                Assert.That(() => destination[1],
                    Is.EqualTo(2)
                );

                Assert.That(() => destination[2],
                    Is.EqualTo(3)
                );

                _ = valueQueue.Dequeue();
                valueQueue.Enqueue(4);

                valueQueue.CopyTo(destination);

                Assert.That(() => destination[0],
                    Is.EqualTo(2)
                );

                Assert.That(() => destination[1],
                    Is.EqualTo(3)
                );

                Assert.That(() => destination[2],
                    Is.EqualTo(4)
                );
            }

            using (var destination = new UnmanagedArray<int>(6))
            {
                valueQueue.CopyTo(destination);

                Assert.That(() => destination[0],
                    Is.EqualTo(2)
                );

                Assert.That(() => destination[1],
                    Is.EqualTo(3)
                );

                Assert.That(() => destination[2],
                    Is.EqualTo(4)
                );

                Assert.That(() => destination[3],
                    Is.EqualTo(0)
                );

                Assert.That(() => destination[4],
                    Is.EqualTo(0)
                );

                Assert.That(() => destination[5],
                    Is.EqualTo(0)
                );

                _ = valueQueue.Dequeue();
                valueQueue.Enqueue(5);
                valueQueue.Enqueue(6);

                valueQueue.CopyTo(destination);

                Assert.That(() => destination[0],
                    Is.EqualTo(3)
                );

                Assert.That(() => destination[1],
                    Is.EqualTo(4)
                );

                Assert.That(() => destination[2],
                    Is.EqualTo(5)
                );

                Assert.That(() => destination[3],
                    Is.EqualTo(6)
                );

                Assert.That(() => destination[4],
                    Is.EqualTo(0)
                );

                Assert.That(() => destination[5],
                    Is.EqualTo(0)
                );
            }

            Assert.That(() => valueQueue.CopyTo(UnmanagedArray.Empty<int>()),
                Throws.InstanceOf<ArgumentOutOfRangeException>()
                      .And.Property("ActualValue").EqualTo((nuint)4)
                      .And.Property("ParamName").EqualTo("count")
            );
        }
        valueQueue.Dispose();

        valueQueue = new UnmanagedValueQueue<int>();
        {
            Assert.That(() => valueQueue.CopyTo(UnmanagedArray.Empty<int>()),
                Throws.Nothing
            );
        }
        valueQueue.Dispose();
    }

    /// <summary>Provides validation of the <see cref="UnmanagedValueQueue.Dequeue{T}(ref UnmanagedValueQueue{T})" /> method.</summary>
    [Test]
    public static void DequeueTest()
    {
        var array = new UnmanagedArray<int>(3);

        array[0] = 1;
        array[1] = 2;
        array[2] = 3;

        var valueQueue = new UnmanagedValueQueue<int>(array, takeOwnership: false);
        {
            Assert.That(() => valueQueue.Dequeue(),
                Is.EqualTo(1)
            );

            Assert.That(() => valueQueue.Dequeue(),
                Is.EqualTo(2)
            );

            Assert.That(() => valueQueue.Dequeue(),
                Is.EqualTo(3)
            );

            Assert.That(() => valueQueue.Dequeue(),
                Throws.InvalidOperationException
            );
        }
        valueQueue.Dispose();

        valueQueue = new UnmanagedValueQueue<int>(array, takeOwnership: true);
        {
            _ = valueQueue.Dequeue();
            valueQueue.Enqueue(4);

            Assert.That(() => valueQueue.Dequeue(),
                Is.EqualTo(2)
            );

            _ = valueQueue.Dequeue();
            valueQueue.Enqueue(5);
            valueQueue.Enqueue(6);

            Assert.That(() => valueQueue.Dequeue(),
                Is.EqualTo(4)
            );

            Assert.That(() => valueQueue.Dequeue(),
                Is.EqualTo(5)
            );

            Assert.That(() => valueQueue.Dequeue(),
                Is.EqualTo(6)
            );

            Assert.That(() => valueQueue,
                Has.Property("Capacity").EqualTo((nuint)3)
                   .And.Count.EqualTo((nuint)0)
            );
        }
        valueQueue.Dispose();

        valueQueue = new UnmanagedValueQueue<int>();
        {
            Assert.That(() => valueQueue.Dequeue(),
                Throws.InvalidOperationException
            );
        }
        valueQueue.Dispose();
    }

    /// <summary>Provides validation of the <see cref="UnmanagedValueQueue.Enqueue{T}(ref UnmanagedValueQueue{T}, T)" /> method.</summary>
    [Test]
    public static void EnqueueTest()
    {
        var array = new UnmanagedArray<int>(3);

        array[0] = 1;
        array[1] = 2;
        array[2] = 3;

        var valueQueue = new UnmanagedValueQueue<int>(array, takeOwnership: false);
        {
            valueQueue.Enqueue(4);

            Assert.That(() => valueQueue,
                Has.Property("Capacity").EqualTo((nuint)6)
                   .And.Count.EqualTo((nuint)4)
            );

            Assert.That(() => valueQueue,
                Has.Property("Capacity").EqualTo((nuint)6)
                   .And.Count.EqualTo((nuint)4)
            );

            valueQueue.Enqueue(5);

            Assert.That(() => valueQueue,
                Has.Property("Capacity").EqualTo((nuint)6)
                   .And.Count.EqualTo((nuint)5)
            );
        }
        valueQueue.Dispose();

        valueQueue = new UnmanagedValueQueue<int>(array, takeOwnership: true);
        {
            _ = valueQueue.Dequeue();
            valueQueue.Enqueue(5);

            Assert.That(() => valueQueue,
                Has.Property("Capacity").EqualTo((nuint)3)
                   .And.Count.EqualTo((nuint)3)
            );
        }
        valueQueue.Dispose();

        valueQueue = new UnmanagedValueQueue<int>();
        {
            valueQueue.Enqueue(6);

            Assert.That(() => valueQueue,
                Has.Property("Capacity").EqualTo((nuint)1)
                   .And.Count.EqualTo((nuint)1)
            );
        }
        valueQueue.Dispose();
    }

    /// <summary>Provides validation of the <see cref="UnmanagedValueQueue.EnsureCapacity{T}(ref UnmanagedValueQueue{T}, nuint)" /> method.</summary>
    [Test]
    public static void EnsureCapacityTest()
    {
        var array = new UnmanagedArray<int>(3);

        array[0] = 1;
        array[1] = 2;
        array[2] = 3;

        var valueQueue = new UnmanagedValueQueue<int>(array);
        {
            valueQueue.EnsureCapacity(0);

            Assert.That(() => valueQueue,
                Has.Property("Capacity").EqualTo((nuint)3)
                   .And.Count.EqualTo((nuint)3)
            );

            valueQueue.EnsureCapacity(3);

            Assert.That(() => valueQueue,
                Has.Property("Capacity").EqualTo((nuint)3)
                   .And.Count.EqualTo((nuint)3)
            );

            valueQueue.EnsureCapacity(4);

            Assert.That(() => valueQueue,
                Has.Property("Capacity").EqualTo((nuint)6)
                   .And.Count.EqualTo((nuint)3)
            );

            valueQueue.EnsureCapacity(16);

            Assert.That(() => valueQueue,
                Has.Property("Capacity").EqualTo((nuint)16)
                   .And.Count.EqualTo((nuint)3)
            );
        }
        valueQueue.Dispose();
    }

    /// <summary>Provides validation of the <see cref="ValueQueue.Peek{T}(ref readonly ValueQueue{T})" /> method.</summary>
    [Test]
    public static void PeekTest()
    {
        var array = new UnmanagedArray<int>(3);

        array[0] = 1;
        array[1] = 2;
        array[2] = 3;

        var valueQueue = new UnmanagedValueQueue<int>(array, takeOwnership: true);
        {
            Assert.That(() => valueQueue.Peek(),
                Is.EqualTo(1)
            );

            valueQueue.Enqueue(4);

            Assert.That(() => valueQueue.Peek(),
                Is.EqualTo(1)
            );

            _ = valueQueue.Dequeue();
            valueQueue.Enqueue(5);

            Assert.That(() => valueQueue.Peek(),
                Is.EqualTo(2)
            );

            _ = valueQueue.Dequeue();
            valueQueue.Enqueue(6);
            valueQueue.Enqueue(7);

            Assert.That(() => valueQueue.Peek(),
                Is.EqualTo(3)
            );

            Assert.That(() => valueQueue,
                Has.Property("Capacity").EqualTo((nuint)6)
                   .And.Count.EqualTo((nuint)5)
            );
        }
        valueQueue.Dispose();

        valueQueue = new UnmanagedValueQueue<int>();
        {
            Assert.That(() => valueQueue.Peek(),
                Throws.InvalidOperationException
            );
        }
        valueQueue.Dispose();
    }

    /// <summary>Provides validation of the <see cref="UnmanagedValueQueue.Peek{T}(ref readonly UnmanagedValueQueue{T}, nuint)" /> method.</summary>
    [Test]
    public static void PeekNUIntTest()
    {
        var array = new UnmanagedArray<int>(3);

        array[0] = 1;
        array[1] = 2;
        array[2] = 3;

        var valueQueue = new UnmanagedValueQueue<int>(array, takeOwnership: true);
        {
            Assert.That(() => valueQueue.Peek(0),
                Is.EqualTo(1)
            );

            valueQueue.Enqueue(4);

            Assert.That(() => valueQueue.Peek(0),
                Is.EqualTo(1)
            );

            Assert.That(() => valueQueue.Peek(3),
                Is.EqualTo(4)
            );

            _ = valueQueue.Dequeue();
            valueQueue.Enqueue(5);

            Assert.That(() => valueQueue.Peek(0),
                Is.EqualTo(2)
            );

            Assert.That(() => valueQueue.Peek(1),
                Is.EqualTo(3)
            );

            _ = valueQueue.Dequeue();
            valueQueue.Enqueue(6);
            valueQueue.Enqueue(7);

            Assert.That(() => valueQueue.Peek(0),
                Is.EqualTo(3)
            );

            Assert.That(() => valueQueue.Peek(2),
                Is.EqualTo(5)
            );

            Assert.That(() => valueQueue,
                Has.Property("Capacity").EqualTo((nuint)6)
                   .And.Count.EqualTo((nuint)5)
            );
        }
        valueQueue.Dispose();

        valueQueue = new UnmanagedValueQueue<int>();
        {
            Assert.That(() => valueQueue.Peek(0),
                Throws.InstanceOf<ArgumentOutOfRangeException>()
                      .And.Property("ActualValue").EqualTo((nuint)0)
                      .And.Property("ParamName").EqualTo("index")
            );
        }
        valueQueue.Dispose();
    }

    /// <summary>Provides validation of the <see cref="ValueQueue.Remove{T}(ref ValueQueue{T}, T)" /> method.</summary>
    [Test]
    public static void RemoveTest()
    {
        var array = new UnmanagedArray<int>(4);

        array[0] = 1;
        array[1] = 2;
        array[2] = 3;
        array[3] = 4;

        var valueQueue = new UnmanagedValueQueue<int>(array, takeOwnership: true);
        {
            Assert.That(() => valueQueue.Remove(1),
                Is.True
            );

            Assert.That(() => valueQueue,
                Is.EquivalentTo([2, 3, 4])
            );

            valueQueue.Enqueue(1);

            Assert.That(() => valueQueue,
                Is.EquivalentTo([2, 3, 4, 1])
            );

            Assert.That(() => valueQueue.Remove(2),
                Is.True
            );

            Assert.That(() => valueQueue,
                Is.EquivalentTo([3, 4, 1])
            );

            valueQueue.Enqueue(2);

            Assert.That(() => valueQueue,
                Is.EquivalentTo([3, 4, 1, 2])
            );

            Assert.That(() => valueQueue.Remove(1),
                Is.True
            );

            Assert.That(() => valueQueue,
                Is.EquivalentTo([3, 4, 2])
            );
        }
        valueQueue.Dispose();

        valueQueue = new UnmanagedValueQueue<int>();
        {
            Assert.That(() => valueQueue.Remove(0),
                Is.False
            );
        }
        valueQueue.Dispose();
    }

    /// <summary>Provides validation of the <see cref="UnmanagedValueQueue.TrimExcess{T}(ref UnmanagedValueQueue{T}, float)" /> method.</summary>
    [Test]
    public static void TrimExcessTest()
    {
        var array = new UnmanagedArray<int>(3);

        array[0] = 1;
        array[1] = 2;
        array[2] = 3;

        var valueQueue = new UnmanagedValueQueue<int>(array, takeOwnership: false);
        {
            valueQueue.TrimExcess();

            Assert.That(() => valueQueue,
                Has.Property("Capacity").EqualTo((nuint)3)
                   .And.Count.EqualTo((nuint)3)
            );
        }
        valueQueue.Dispose();

        valueQueue = new UnmanagedValueQueue<int>(array, takeOwnership: false);
        {
            _ = valueQueue.Dequeue();

            valueQueue.Enqueue(4);
            valueQueue.TrimExcess();

            Assert.That(() => valueQueue,
                Has.Property("Capacity").EqualTo((nuint)3)
                   .And.Count.EqualTo((nuint)3)
            );
        }
        valueQueue.Dispose();

        valueQueue = new UnmanagedValueQueue<int>(array, takeOwnership: true);
        {
            valueQueue.Enqueue(4);
            valueQueue.Enqueue(5);

            valueQueue.TrimExcess();

            Assert.That(() => valueQueue,
                Has.Property("Capacity").EqualTo((nuint)5)
                   .And.Count.EqualTo((nuint)5)
            );

            valueQueue.EnsureCapacity(15);
            valueQueue.TrimExcess(0.3f);

            Assert.That(() => valueQueue,
                Has.Property("Capacity").EqualTo((nuint)15)
                   .And.Count.EqualTo((nuint)5)
            );
        }
        valueQueue.Dispose();

        valueQueue = new UnmanagedValueQueue<int>();
        {
            valueQueue.TrimExcess();

            Assert.That(() => valueQueue,
                Has.Property("Capacity").EqualTo((nuint)0)
                   .And.Count.EqualTo((nuint)0)
            );
        }
        valueQueue.Dispose();
    }

    /// <summary>Provides validation of the <see cref="ValueQueue.TryDequeue{T}(ref ValueQueue{T}, out T)" /> method.</summary>
    [Test]
    public static void TryDequeueTest()
    {
        var array = new UnmanagedArray<int>(3);

        array[0] = 1;
        array[1] = 2;
        array[2] = 3;

        var valueQueue = new UnmanagedValueQueue<int>(array, takeOwnership: true);
        {
            var result = valueQueue.TryDequeue(out var value);

            Assert.That(() => result,
                Is.True
            );

            Assert.That(() => value,
                Is.EqualTo(1)
            );

            valueQueue.Enqueue(4);
            result = valueQueue.TryDequeue(out value);

            Assert.That(() => result,
                Is.True
            );

            Assert.That(() => value,
                Is.EqualTo(2)
            );

            Assert.That(() => valueQueue,
                Has.Property("Capacity").EqualTo((nuint)3)
                   .And.Count.EqualTo((nuint)2)
            );
        }
        valueQueue.Dispose();

        valueQueue = new UnmanagedValueQueue<int>();
        {
            Assert.That(() => valueQueue.TryDequeue(out _),
                Is.False
            );
        }
        valueQueue.Dispose();
    }

    /// <summary>Provides validation of the <see cref="ValueQueue.TryPeek{T}(ref readonly ValueQueue{T}, out T)" /> method.</summary>
    [Test]
    public static void TryPeekTest()
    {
        var array = new UnmanagedArray<int>(3);

        array[0] = 1;
        array[1] = 2;
        array[2] = 3;

        var valueQueue = new UnmanagedValueQueue<int>(array, takeOwnership: true);
        {
            var result = valueQueue.TryPeek(out var value);

            Assert.That(() => result,
                Is.True
            );

            Assert.That(() => value,
                Is.EqualTo(1)
            );

            valueQueue.Enqueue(4);
            result = valueQueue.TryPeek(out value);

            Assert.That(() => result,
                Is.True
            );

            Assert.That(() => value,
                Is.EqualTo(1)
            );

            Assert.That(() => valueQueue,
                Has.Property("Capacity").EqualTo((nuint)6)
                   .And.Count.EqualTo((nuint)4)
            );
        }
        valueQueue.Dispose();

        valueQueue = new UnmanagedValueQueue<int>();
        {
            Assert.That(() => valueQueue.TryPeek(out _),
                Is.False
            );
        }
        valueQueue.Dispose();
    }

    /// <summary>Provides validation of the <see cref="UnmanagedValueQueue.TryPeek{T}(ref readonly UnmanagedValueQueue{T}, nuint, out T)" /> method.</summary>
    [Test]
    public static void TryPeekNUIntTest()
    {
        var array = new UnmanagedArray<int>(3);

        array[0] = 1;
        array[1] = 2;
        array[2] = 3;

        var valueQueue = new UnmanagedValueQueue<int>(array, takeOwnership: true);
        {
            var result = valueQueue.TryPeek(0, out var value);

            Assert.That(() => result,
                Is.True
            );

            Assert.That(() => value,
                Is.EqualTo(1)
            );

            valueQueue.Enqueue(4);
            result = valueQueue.TryPeek(0, out value);

            Assert.That(() => result,
                Is.True
            );

            Assert.That(() => value,
                Is.EqualTo(1)
            );

            result = valueQueue.TryPeek(3, out value);

            Assert.That(() => result,
                Is.True
            );

            Assert.That(() => value,
                Is.EqualTo(4)
            );

            Assert.That(() => valueQueue,
                Has.Property("Capacity").EqualTo((nuint)6)
                   .And.Count.EqualTo((nuint)4)
            );
        }
        valueQueue.Dispose();

        valueQueue = new UnmanagedValueQueue<int>();
        {
            Assert.That(() => valueQueue.TryPeek(0, out _),
                Is.False
            );
        }
        valueQueue.Dispose();
    }
}
