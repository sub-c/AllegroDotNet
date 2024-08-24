using System.Diagnostics;

namespace SubC.AllegroDotNet.Models;

/// <summary>
/// This abstract class wraps a native <see cref="IntPtr"/> with the child class' type.
/// </summary>
[DebuggerDisplay("Pointer = {Pointer}")]
public abstract class NativePointer : IEquatable<NativePointer?>
{
    internal IntPtr Pointer;

    /// <summary>
    /// Determines if a <see cref="IntPtr"/> matches the native pointer of a <see cref="NativePointer"/>.
    /// </summary>
    /// <param name="ptr">The native pointer.</param>
    /// <param name="pointer">The <see cref="NativePointer"/> instance.</param>
    /// <returns></returns>
    public static bool operator ==(IntPtr ptr, NativePointer? pointer)
    {
        return ptr == pointer?.Pointer;
    }

    /// <summary>
    /// Determines if the native pointers of two <see cref="NativePointer"/> match.
    /// </summary>
    /// <param name="pointer1">The <see cref="NativePointer"/> instance</param>
    /// <param name="pointer2">The <see cref="NativePointer"/> instance</param>
    /// <returns></returns>
    public static bool operator ==(NativePointer? pointer1, NativePointer? pointer2)
    {
        return pointer1?.Pointer == pointer2?.Pointer;
    }

    /// <summary>
    /// Determines if a <see cref="IntPtr"/> does not match the native pointer of a <see cref="NativePointer"/>.
    /// </summary>
    /// <param name="ptr">The native pointer.</param>
    /// <param name="pointer">The <see cref="NativePointer"/> instance</param>
    /// <returns></returns>
    public static bool operator !=(IntPtr ptr, NativePointer? pointer)
    {
        return ptr != pointer?.Pointer;
    }

    /// <summary>
    /// Determines if the native pointers of two <see cref="NativePointer"/> match.
    /// </summary>
    /// <param name="pointer1">The <see cref="NativePointer"/> instance</param>
    /// <param name="pointer2">The <see cref="NativePointer"/> instance</param>
    /// <returns></returns>
    public static bool operator !=(NativePointer? pointer1, NativePointer? pointer2)
    {
        return pointer1?.Pointer != pointer2?.Pointer;
    }

    internal static T? Create<T>(IntPtr pointer)
      where T : NativePointer, new()
    {
        return pointer == IntPtr.Zero
          ? null
          : new T() { Pointer = pointer };
    }

    internal static IntPtr Get(NativePointer? instance)
    {
        return instance?.Pointer ?? IntPtr.Zero;
    }

    /// <summary>
    /// Determines if the native pointer of another <see cref="NativePointer"/> is equal.
    /// </summary>
    /// <param name="other">The other native pointer instance.</param>
    /// <returns>True if the native pointer instance equals this native pointer, otherwise false.</returns>
    public bool Equals(NativePointer? other)
    {
        if (ReferenceEquals(null, other))
            return false;

        if (ReferenceEquals(this, other))
            return true;

        return Pointer.Equals(other.Pointer);
    }

    /// <inheritdoc />
    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj))
            return false;

        if (ReferenceEquals(this, obj))
            return true;

        if (obj.GetType() != GetType())
            return false;

        return Equals((NativePointer)obj);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        return Pointer.GetHashCode();
    }
}
