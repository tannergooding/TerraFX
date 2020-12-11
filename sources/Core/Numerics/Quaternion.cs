// Copyright © Tanner Gooding and Contributors. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System;
using System.Globalization;
using System.Resources;
using System.Text;
using TerraFX.Utilities;

namespace TerraFX.Numerics
{
    /// <summary>Defines a quaternion.</summary>
    public readonly struct Quaternion : IEquatable<Quaternion>, IFormattable
    {
        /// <summary>Defines a <see cref="Quaternion" /> that represents the Identity mapping.</summary>
        public static readonly Quaternion Identity = new Quaternion(0.0f, 0.0f, 0.0f, 1.0f);

        private readonly float _x;
        private readonly float _y;
        private readonly float _z;
        private readonly float _w;

        /// <summary>Initializes a new instance of the <see cref="Quaternion" /> struct.</summary>
        /// <param name="x">The value of the x-component.</param>
        /// <param name="y">The value of the y-component.</param>
        /// <param name="z">The value of the z-component.</param>
        /// <param name="w">The value of the w-component.</param>
        public Quaternion(float x, float y, float z, float w)
        {
            _x = x;
            _y = y;
            _z = z;
            _w = w;
        }

        /// <summary>Gets the value of the x-component.</summary>
        public float X => _x;

        /// <summary>Gets the value of the y-component.</summary>
        public float Y => _y;

        /// <summary>Gets the value of the z-component.</summary>
        public float Z => _z;

        /// <summary>Gets the value of the w-component.</summary>
        public float W => _w;

        /// <summary>Compares two <see cref="Quaternion" /> instances to determine equality.</summary>
        /// <param name="left">The <see cref="Quaternion" /> to compare with <paramref name="right" />.</param>
        /// <param name="right">The <see cref="Quaternion" /> to compare with <paramref name="left" />.</param>
        /// <returns><c>true</c> if <paramref name="left" /> and <paramref name="right" /> are equal; otherwise, <c>false</c>.</returns>
        public static bool operator ==(Quaternion left, Quaternion right)
        {
            return (left.X == right.X)
                && (left.Y == right.Y)
                && (left.Z == right.Z)
                && (left.W == right.W);
        }

        /// <summary>Compares two <see cref="Quaternion" /> instances to determine inequality.</summary>
        /// <param name="left">The <see cref="Quaternion" /> to compare with <paramref name="right" />.</param>
        /// <param name="right">The <see cref="Quaternion" /> to compare with <paramref name="left" />.</param>
        /// <returns><c>true</c> if <paramref name="left" /> and <paramref name="right" /> are not equal; otherwise, <c>false</c>.</returns>
        public static bool operator !=(Quaternion left, Quaternion right)
        {
            return (left.X != right.X)
                || (left.Y != right.Y)
                || (left.Z != right.Z)
                || (left.W != right.W);
        }

        /// <summary>Returns the value of the <see cref="Quaternion" /> operand (the sign of the operand is unchanged).</summary>
        /// <param name="value">The operand to return</param>
        /// <returns>The value of the operand, <paramref name="value" />.</returns>
        public static Quaternion operator +(Quaternion value) => value;

        /// <summary>Negates the value of the specified <see cref="Quaternion" /> operand.</summary>
        /// <param name="value">The value to negate.</param>
        /// <returns>The result of <paramref name="value" /> multiplied by negative one (-1).</returns>
        public static Quaternion operator -(Quaternion value) => value * -1;

        /// <summary>Adds two specified <see cref="Quaternion" /> values.</summary>
        /// <param name="left">The first value to add.</param>
        /// <param name="right">The second value to add.</param>
        /// <returns>The result of adding <paramref name="left" /> and <paramref name="right" />.</returns>
        public static Quaternion operator +(Quaternion left, Quaternion right) => new Quaternion(left.X + right.X, left.Y + right.Y, left.Z + right.Z, left.W + right.W);

        /// <summary>Subtracts two specified <see cref="Quaternion" /> values.</summary>
        /// <param name="left">The minuend.</param>
        /// <param name="right">The subtrahend.</param>
        /// <returns>The result of subtracting <paramref name="right" /> from <paramref name="left" />.</returns>
        public static Quaternion operator -(Quaternion left, Quaternion right) => new Quaternion(left.X - right.X, left.Y - right.Y, left.Z - right.Z, left.W - right.W);

        /// <summary>Multiplies two specified <see cref="Quaternion" /> values.</summary>
        /// <param name="left">The first value to multiply.</param>
        /// <param name="right">The second value to multiply.</param>
        /// <returns>The result of multiplying <paramref name="left" /> by <paramref name="right" />.</returns>
        public static Quaternion operator *(Quaternion left, Quaternion right) => new Quaternion(left.X * right.X, left.Y * right.Y, left.Z * right.Z, left.W * right.W);

        /// <summary>Divides two specified <see cref="Quaternion" /> values component by component.</summary>
        /// <param name="left">The dividend.</param>
        /// <param name="right">The divisor.</param>
        /// <returns>The result of dividing <paramref name="left" /> by <paramref name="right" />.</returns>
        public static Quaternion operator /(Quaternion left, Quaternion right) => new Quaternion(left.X / right.X, left.Y / right.Y, left.Z / right.Z, left.W / right.W);

        /// <summary>Multiplies each component of a <see cref="Quaternion" /> value by a given <see cref="float" /> value.</summary>
        /// <param name="left">The vector to multiply.</param>
        /// <param name="right">The value to multiply each component by.</param>
        /// <returns>The result of multiplying each component of <paramref name="left" /> by <paramref name="right" />.</returns>
        public static Quaternion operator *(Quaternion left, float right) => new Quaternion(left.X * right, left.Y * right, left.Z * right, left.W * right);

        /// <summary>Divides each component of a <see cref="Quaternion" /> value by a given <see cref="float" /> value.</summary>
        /// <param name="left">The dividend.</param>
        /// <param name="right">The divisor to divide each component by.</param>
        /// <returns>The result of multiplying each component of <paramref name="left" /> by <paramref name="right" />.</returns>
        public static Quaternion operator /(Quaternion left, float right) => new Quaternion(left.X / right, left.Y / right, left.Z / right, left.W / right);

        // -- equality and similarity --

        /// <inheritdoc />
        public override bool Equals(object? obj) => (obj is Quaternion other) && Equals(other);

        /// <inheritdoc />
        public bool Equals(Quaternion other) => this == other;

        /// <summary>Tests if two <see cref="Quaternion" /> instances have sufficiently similar values to see them as equivalent.
        /// Use this to compare values that might be affected by differences in rounding the least significant bits.</summary>
        /// <param name="q">The other Quaternion to compare.</param>
        /// <param name="errorTolerance">The threshold below which they are sufficiently similar.</param>
        /// <returns>True if similar, false otherwise.</returns>
        public bool IsSimilarTo(Quaternion q, float errorTolerance = FloatUtilities.ErrorTolerance)
        {
            var diffNorm2 = NormSquared(this - q);
            return diffNorm2 < errorTolerance;
        }

        // -- state reporting (GetHashCode, ToString) --

        /// <inheritdoc />
        public override int GetHashCode()
        {
            var hashCode = new HashCode();
            {
                hashCode.Add(X);
                hashCode.Add(Y);
                hashCode.Add(Z);
                hashCode.Add(W);
            }
            return hashCode.ToHashCode();
        }

        /// <inheritdoc />
        public override string ToString() => ToString(format: null, formatProvider: null);


        /// <inheritdoc />
        public string ToString(string? format, IFormatProvider? formatProvider)
        {
            var separator = NumberFormatInfo.GetInstance(formatProvider).NumberGroupSeparator;

            return new StringBuilder(9 + (separator.Length * 3))
                .Append('<')
                .Append(X.ToString(format, formatProvider))
                .Append(separator)
                .Append(' ')
                .Append(Y.ToString(format, formatProvider))
                .Append(separator)
                .Append(' ')
                .Append(Z.ToString(format, formatProvider))
                .Append(separator)
                .Append(' ')
                .Append(W.ToString(format, formatProvider))
                .Append('>')
                .ToString();
        }

        // -- new instance with some member changed (With*) --

        /// <summary>Creates a new <see cref="Quaternion" /> instance with <see cref="X" /> set to the specified value.</summary>
        /// <param name="value">The new value of the x-component.</param>
        /// <returns>A new <see cref="Quaternion" /> instance with <see cref="X" /> set to <paramref name="value" />.</returns>
        public Quaternion WithX(float value) => new Quaternion(value, Y, Z, W);

        /// <summary>Creates a new <see cref="Quaternion" /> instance with <see cref="Y" /> set to the specified value.</summary>
        /// <param name="value">The new value of the y-component.</param>
        /// <returns>A new <see cref="Quaternion" /> instance with <see cref="Y" /> set to <paramref name="value" />.</returns>
        public Quaternion WithY(float value) => new Quaternion(X, value, Z, W);

        /// <summary>Creates a new <see cref="Quaternion" /> instance with <see cref="Z" /> set to the specified value.</summary>
        /// <param name="value">The new value of the z-component.</param>
        /// <returns>A new <see cref="Quaternion" /> instance with <see cref="Z" /> set to <paramref name="value" />.</returns>
        public Quaternion WithZ(float value) => new Quaternion(X, Y, value, W);

        /// <summary>Creates a new <see cref="Quaternion" /> instance with <see cref="W" /> set to the specified value.</summary>
        /// <param name="value">The new value of the w-component.</param>
        /// <returns>A new <see cref="Quaternion" /> instance with <see cref="W" /> set to <paramref name="value" />.</returns>
        public Quaternion WithW(float value) => new Quaternion(X, Y, Z, value);

        // -- conversion to other formats (ToMatrix) --

        /// <summary>The  <see cref="Matrix3x3" /> that corresponds to this <see cref="Quaternion" />.
        /// If this Quaternion is normalized, then the Matrix3x3 is a rotation only matrix,
        /// otherwise the Matrix3x3 is a rotation + scaling matrix.</summary>
        /// <param name="q">The Quaternion for this operation.</param>
        /// <returns>The resulting <see cref="Matrix3x3" />.</returns>
        public static Matrix3x3 ToMatrix3x3(Quaternion q)
        {
            var w2 = q.W * q.W;
            var x2 = q.X * q.X;
            var y2 = q.Y * q.Y;
            var z2 = q.Z * q.Z;
            var wz = 2 * q.W * q.Z;
            var xz = 2 * q.X * q.Z;
            var xy = 2 * q.X * q.Y;
            var wx = 2 * q.W * q.X;
            var wy = 2 * q.W * q.Y;
            var yz = 2 * q.Y * q.Z;
            var x = new Vector3(w2 + x2 - y2 - z2, wz + xy, xz - wy);
            var y = new Vector3(xy - wz, w2 - x2 + y2 - z2, wx + yz);
            var z = new Vector3(wy + xz, yz - wx, w2 - x2 - y2 + z2);
            var m = new Matrix3x3(x, y, z);
            return m;
        }

        // -- math --

        /// <summary>
        /// Creates a new <see cref="Quaternion" /> by concatenating 'this' with the given one.
        /// The result will have the combined effect of the rotations and scalings in both source Quaternions.
        /// </summary>
        /// <param name="q">The left Quaternion for this operation.</param>
        /// <param name="r">The right Quaternion to concatenate.</param>
        /// <returns>The combined Quaternion.</returns>
        public static Quaternion Concatenate(Quaternion q, Quaternion r)
        {
            var a = new Vector3(q.X, q.Y, q.Z);
            var b = new Vector3(r.X, r.Y, r.Z);
            var c = a * r.W;
            c += b * q.W;
            c += Vector3.Cross(b, a);
            var resultQ = Normalize(new Quaternion(c.X, c.Y, c.Z, (q.W * r.W) - Vector3.Dot(a, b)));
            return resultQ;
        }

        /// <summary>The Conjugate of a <see cref="Quaternion" />.</summary>
        /// <param name="q">The Quaternion for this operation.</param>
        /// <returns>The resulting Conjugate.</returns>
        public static Quaternion Conjugate(Quaternion q) => new Quaternion(-q.X, -q.Y, -q.Z, q.W);

        /// <summary>The dot product of this <see cref="Quaternion" /> with the given other one.</summary>
        /// <param name="q">The left Quaternion for this operation.</param>
        /// <param name="r">The right Quaternion for this operation.</param>
        /// <returns>The resulting dot product <see cref="Quaternion" />.</returns>
        public static Quaternion Dot(Quaternion q, Quaternion r) => new Quaternion(q.X * r.X, q.Y * r.Y, q.Z * r.Z, q.W * r.W);

        /// <summary>The inverse of this <see cref="Quaternion" /> with the given other one.</summary>
        /// <param name="q">The Quaternion for this operation.</param>
        /// <returns>The resulting inverse <see cref="Quaternion" />.</returns>
        public static Quaternion Invert(Quaternion q)
        {
            var l2 = NormSquared(q);
            return new Quaternion(-q.X / l2, -q.Y / l2, -q.Z / l2, q.W / l2);
        }

        /// <summary>The squared norm of this <see cref="Quaternion" />.</summary>
        /// <param name="q">The Quaternion for this operation.</param>
        /// <returns>The resulting squared norm.</returns>
        public static float NormSquared(Quaternion q)
        {
            var d = Dot(q, q);
            var norm2 = d.X + d.Y + d.Z + d.W;
            return norm2;
        }

        /// <summary>The norm of this <see cref="Quaternion" /> with the given other one.</summary>
        /// <param name="q">The Quaternion for this operation.</param>
        /// <returns>The resulting norm.</returns>
        public static float Norm(Quaternion q) => MathF.Sqrt(NormSquared(q));

        /// <summary>The unit length version of this <see cref="Quaternion" /> with the given other one.</summary>
        /// <param name="q">The Quaternion for this operation.</param>
        /// <param name="errorTolerance">The threshold below which standard normalzation is replaced by returning Identity instead.</param>
        /// <returns>The resulting unit length <see cref="Quaternion" />.</returns>
        public static Quaternion Normalize(Quaternion q, float errorTolerance = FloatUtilities.ErrorTolerance)
        {
            var norm = Norm(q);
            return norm > errorTolerance ? q / norm : Quaternion.Identity;
        }

        /// <summary>A rounded version of this <see cref="Quaternion" />.</summary>
        /// <param name="q">The Quaternion for this operation.</param>
        /// <param name="numDigits">The number of fractional digits to round to. By default 4.</param>
        /// <returns>The resulting rounded <see cref="Quaternion" />.</returns>
        public static Quaternion Round(Quaternion q, int numDigits = 4) => new Quaternion(MathF.Round(q.X, numDigits), MathF.Round(q.Y, numDigits), MathF.Round(q.Z, numDigits), MathF.Round(q.W, numDigits));

        /// <summary>The given <see cref="Vector3" /> rotated by this <see cref="Quaternion" />.</summary>
        /// <param name="q">The Quaternion for this operation.</param>
        /// <param name="v">The vertor to rotate.</param>
        /// <returns>The resulting rotated <see cref="Vector3" />.</returns>
        public static Vector3 Rotate(Quaternion q, Vector3 v) => v * ToMatrix3x3(q);

        /// <summary>The given <see cref="Vector3" /> rotated by the inverse of this <see cref="Quaternion" />.</summary>
        /// <param name="q">The Quaternion for this operation.</param>
        /// <param name="v">The vertor to rotate.</param>
        /// <returns>The resulting rotated <see cref="Vector3" />.</returns>
        public static Vector3 RotateBack(Quaternion q, Vector3 v) => v * ToMatrix3x3(Invert(q));

        /// <summary>A new  <see cref="Quaternion" /> that embodies rotation about the given axis by the given angle in radians.</summary>
        /// <param name="axis">The rotation axis. It will be normalized before use.</param>
        /// <param name="radians">The rotation angle in radians.</param>
        /// <returns></returns>
        public static Quaternion RotationAroundAxis(Vector3 axis, float radians)
        {
            var unitAxis = Vector3.Normalize(axis);
            var scale = MathF.Sin(radians / 2.0f);
            var q = new Quaternion(
                scale * unitAxis.X,
                scale * unitAxis.Y,
                scale * unitAxis.Z,
                MathF.Cos(radians / 2));
            return q;
        }
    }
}
