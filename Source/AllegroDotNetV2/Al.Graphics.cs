using System.Runtime.InteropServices;
using SubC.AllegroDotNet.Enums;
using SubC.AllegroDotNet.Models;
using SubC.AllegroDotNet.Native;
using SubC.AllegroDotNet.Native.Structs;

namespace SubC.AllegroDotNet;

/// <summary>
/// This static class contains the Allegro 5 library methods.
/// </summary>
public static partial class Al
{
  /// <summary>
  /// Convert r, g, b (ranging from 0-255) into an <see cref="AllegroColor"/>, using 255 as the alpha.
  /// This function can be called before Allegro is initialized.
  /// </summary>
  /// <param name="r">The red component.</param>
  /// <param name="g">The green component.</param>
  /// <param name="b">The blue component.</param>
  /// <returns>The color instance.</returns>
  public static AllegroColor MapRgb(byte r, byte g, byte b)
  {
    return Interop.Context.Core.AlMapRgb(r, g, b);
  }

  /// <summary>
  /// Convert r, g, b (ranging from 0.0-1.0) into an <see cref="AllegroColor"/>, using 1.0 as the alpha.
  /// This function can be called before Allegro is initialized.
  /// </summary>
  /// <param name="r">The red component.</param>
  /// <param name="g">The green component.</param>
  /// <param name="b">The blue component.</param>
  /// <returns>The color instance.</returns>
  public static AllegroColor MapRgbF(float r, float g, float b)
  {
    return Interop.Context.Core.AlMapRgbF(r, g, b);
  }

  /// <summary>
  /// Convert r, g, b (ranging from 0-255) into an <see cref="AllegroColor"/>.
  /// This function can be called before Allegro is initialized.
  /// </summary>
  /// <param name="r">The red component.</param>
  /// <param name="g">The green component.</param>
  /// <param name="b">The blue component.</param>
  /// <param name="a">The alpha component.</param>
  /// <returns>The color instance.</returns>
  public static AllegroColor MapRgba(byte r, byte g, byte b, byte a)
  {
    return Interop.Context.Core.AlMapRgba(r, g, b, a);
  }

  /// <summary>
  /// <para>
  /// This is a shortcut for <c>Al.MapRgba(r * a / 255, g * a / 255, b * a / 255)</c>.
  /// This can be called before Allegro is initialized.
  /// </para>
  /// <para>
  /// By default Allegro uses pre-multiplied alpha for transparent blending of bitmaps and primitives
  /// (see <see cref="LoadBitmapFlags"/> for a discussion of that feature). This means that if you want to tint
  /// a bitmap or primitive to be transparent you need to multiply the color components by the alpha components
  /// when you pass them to this function.
  /// </para>
  /// </summary>
  /// <param name="r">The red component.</param>
  /// <param name="g">The green component.</param>
  /// <param name="b">The blue component.</param>
  /// <param name="a">The alpha component.</param>
  /// <returns>The color instance.</returns>
  public static AllegroColor PremulRgba(byte r, byte g, byte b, byte a)
  {
    return Interop.Context.Core.AlPremulRgba(r, g, b, a);
  }

  /// <summary>
  /// Convert r, g, b, a (ranging from 0.0-1.0) into an <see cref="AllegroColor"/>.
  /// This function can be called before Allegro is initialized.
  /// </summary>
  /// <param name="r">The red component.</param>
  /// <param name="g">The green component.</param>
  /// <param name="b">The blue component.</param>
  /// <param name="a">The alpha component.</param>
  /// <returns>The color instance.</returns>
  public static AllegroColor MapRgbaF(float r, float g, float b, float a)
  {
    return Interop.Context.Core.AlMapRgbaF(r, g, b, a);
  }

  /// <summary>
  /// <para>
  /// This is a shortcut for <c>Al.MapRgbaF(r * a, g * a, b * a, a)</c>.
  /// This can be called before Allegro is initialized.
  /// </para>
  /// <para>
  /// By default Allegro uses pre-multiplied alpha for transparent blending of bitmaps and primitives
  /// (see <see cref="LoadBitmapFlags"/> for a discussion of that feature). This means that if you want to tint
  /// a bitmap or primitive to be transparent you need to multiply the color components by the alpha components
  /// when you pass them to this function.
  /// </para>
  /// </summary>
  /// <param name="r">The red component.</param>
  /// <param name="g">The green component.</param>
  /// <param name="b">The blue component.</param>
  /// <param name="a">The alpha component.</param>
  /// <returns>The color instance.</returns>
  public static AllegroColor PremulRgbaF(float r, float g, float b, float a)
  {
    return Interop.Context.Core.AlPremulRgbaF(r, g, b, a);
  }

  /// <summary>
  /// Retrieves components of an <see cref="AllegroColor"/>, ignoring alpha. Components will range from 0-255.
  /// This function can be called before Allegro is initialized.
  /// </summary>
  /// <param name="color">The color instance.</param>
  /// <param name="r">The red component.</param>
  /// <param name="g">The green component.</param>
  /// <param name="b">The blue component.</param>
  public static void UnmapRgb(AllegroColor color, out byte r, out byte g, out byte b)
  {
    r = g = b = 0;
    Interop.Context.Core.AlUnmapRgb(color, ref r, ref g, ref b);
  }

  /// <summary>
  /// Retrieves components of an <see cref="AllegroColor"/>, ignoring alpha. Components will range from 0.0f-1.0f.
  /// This function can be called before Allegro is initialized.
  /// </summary>
  /// <param name="color">The color instance.</param>
  /// <param name="r">The red component.</param>
  /// <param name="g">The green component.</param>
  /// <param name="b">The blue component.</param>
  public static void UnmapRgbF(AllegroColor color, out float r, out float g, out float b)
  {
    r = g = b = 0;
    Interop.Context.Core.AlUnmapRgbF(color, ref r, ref g, ref b);
  }

  /// <summary>
  /// Retrieves components of an <see cref="AllegroColor"/>. Components will range from 0-255.
  /// This function can be called before Allegro is initialized.
  /// </summary>
  /// <param name="color">The color instance.</param>
  /// <param name="r">The red component.</param>
  /// <param name="g">The green component.</param>
  /// <param name="b">The blue component.</param>
  /// <param name="a">The alpha component.</param>
  public static void UnmapRgba(AllegroColor color, out byte r, out byte g, out byte b, out byte a)
  {
    r = g = b = a = 0;
    Interop.Context.Core.AlUnmapRgba(color, ref r, ref g, ref b, ref a);
  }

  /// <summary>
  /// Retrieves components of an <see cref="AllegroColor"/>. Components will range from 0.0f-1.0f.
  /// This function can be called before Allegro is initialized.
  /// </summary>
  /// <param name="color">The color instance.</param>
  /// <param name="r">The red component.</param>
  /// <param name="g">The green component.</param>
  /// <param name="b">The blue component.</param>
  /// <param name="a">The alpha component.</param>
  public static void UnmapRgbaF(AllegroColor color, out float r, out float g, out float b, out float a)
  {
    r = g = b = a = 0;
    Interop.Context.Core.AlUnmapRgbaF(color, ref r, ref g, ref b, ref a);
  }

  /// <summary>
  /// Return the number of bytes that a pixel of the given format occupies. For blocked pixel formats
  /// (e.g. compressed formats), this returns 0.
  /// </summary>
  /// <param name="format">The pixel format.</param>
  /// <returns>The number of bytes a pixel of the given format occupies.</returns>
  public static int GetPixelSize(PixelFormat format)
  {
    return Interop.Context.Core.AlGetPixelSize((int)format);
  }

  /// <summary>
  /// Return the number of bits that a pixel of the given format occupies. For blocked pixel formats
  /// (e.g. compressed formats), this returns 0.
  /// </summary>
  /// <param name="format">The pixel format.</param>
  /// <returns>The number of bytes a pixel of the given format occupies.</returns>
  public static int GetPixelFormatBits(PixelFormat format)
  {
    return Interop.Context.Core.AlGetPixelFormatBits((int)format);
  }

  /// <summary>
  /// Return the number of bytes that a block of pixels with this format occupies.
  /// </summary>
  /// <param name="format">The pixel format.</param>
  /// <returns>The number of bytes that a block of pixels with this format occupies.</returns>
  public static int GetPixelBlockSize(PixelFormat format)
  {
    return Interop.Context.Core.AlGetPixelBlockSize((int)format);
  }

  /// <summary>
  /// Return the width of the the pixel block for this format.
  /// </summary>
  /// <param name="format">The pixel format.</param>
  /// <returns>The width of the the pixel block for the format.</returns>
  public static int GetPixelBlockWidth(PixelFormat format)
  {
    return Interop.Context.Core.AlGetPixelBlockWidth((int)format);
  }

  /// <summary>
  /// Return the height of the the pixel block for this format.
  /// </summary>
  /// <param name="format">The pixel format.</param>
  /// <returns>The height of the the pixel block for the format.</returns>
  public static int GetPixelBlockHeight(PixelFormat format)
  {
    return Interop.Context.Core.AlGetPixelBlockHeight((int)format);
  }

  /// <summary>
  /// <para>
  /// Lock an entire bitmap for reading or writing. If the bitmap is a display bitmap it will be updated from
  /// system memory after the bitmap is unlocked (unless locked read only). Returns <c>null</c> if the bitmap
  /// cannot be locked, e.g. the bitmap was locked previously and not unlocked. This function also returns
  /// <c>null</c> if the format is a compressed format.
  /// </para>
  /// <para>
  /// <paramref name="format"/> indicates the pixel format that the returned buffer will be in. To lock in the
  /// same format as the bitmap stores its data internally, call with <see cref="GetBitmapFormat"/> as the
  /// format or use <see cref="PixelFormat.Any"/>. Locking in the native format will usually be faster.
  /// If the bitmap format is compressed, using <see cref="PixelFormat.Any"/> will choose an implementation
  /// defined non-compressed format.
  /// </para>
  /// <para>
  /// On some platforms, Allegro automatically backs up the contents of video bitmaps because they may be
  /// occasionally lost (see discussion in <see cref="CreateBitmap"/>’s documentation). If you’re completely
  /// recreating the bitmap contents often (e.g. every frame) then you will get much better performance by
  /// creating the target bitmap with <see cref="BitmapFlags.NoPreserveTexture"/> flag.
  /// </para>
  /// <para>
  /// Note: While a bitmap is locked, you can not use any drawing operations on it (with the sole exception of
  /// <see cref="PutPixel"/> and <see cref="PutBlendedPixel"/>).
  /// </para>
  /// </summary>
  /// <param name="bitmap">The bitmap to lock.</param>
  /// <param name="format">The pixel format of the returned buffer.</param>
  /// <param name="flag">The lock flag.</param>
  /// <returns>The locked region if successful, otherwise <c>null</c>.</returns>
  public static Models.AllegroLockedRegion? LockBitmap(AllegroBitmap? bitmap, PixelFormat format, LockFlag flag)
  {
    var pointer = Interop.Context.Core.AlLockBitmap(NativePointer.Get(bitmap), (int)format, (int)flag);
    return pointer == IntPtr.Zero
      ? null
      : new Models.AllegroLockedRegion { Struct = Marshal.PtrToStructure<Native.Structs.AllegroLockedRegion>(pointer) };
  }

  /// <summary>
  /// <para>
  /// Like <see cref="LockBitmap"/>, but only locks a specific area of the bitmap. If the bitmap is a video bitmap,
  /// only that area of the texture will be updated when it is unlocked. Locking only the region you intend to modify
  /// will be faster than locking the whole bitmap.
  /// </para>
  /// <para>
  /// Note: Using the <see cref="LockFlag.WriteOnly"/> with a blocked pixel format (i.e. formats for which
  /// <see cref="GetPixelBlockWidth"/> or <see cref="GetPixelBlockHeight"/> do not return 1) requires you to have
  /// the region be aligned to the block width for optimal performance. If it is not, then the function will have
  /// to lock the region with the <see cref="LockFlag.ReadWrite"/> instead in order to pad this region with valid data.
  /// </para>
  /// </summary>
  /// <param name="bitmap">The bitmap to lock.</param>
  /// <param name="x">The X position.</param>
  /// <param name="y">The Y position.</param>
  /// <param name="width">The width in pixels.</param>
  /// <param name="height">The height in pixels.</param>
  /// <param name="format">The pixel format.</param>
  /// <param name="flag">The lock option.</param>
  /// <returns></returns>
  public static Models.AllegroLockedRegion? LockBitmapRegion(
    AllegroBitmap? bitmap,
    int x,
    int y,
    int width,
    int height,
    PixelFormat format,
    LockFlag flag)
  {
    var pointer = Interop.Context.Core.AlLockBitmapRegion(
      NativePointer.Get(bitmap),
      x,
      y,
      width,
      height,
      (int)format,
      (int)flag);
    return pointer == IntPtr.Zero
      ? null
      : new Models.AllegroLockedRegion { Struct = Marshal.PtrToStructure<Native.Structs.AllegroLockedRegion>(pointer) };
  }

  /// <summary>
  /// Unlock a previously locked bitmap or bitmap region. If the bitmap is a video bitmap, the texture will be updated
  /// to match the system memory copy (unless it was locked read only).
  /// </summary>
  /// <param name="bitmap">The bitmap to unlock.</param>
  public static void UnlockBitmap(AllegroBitmap? bitmap)
  {
    Interop.Context.Core.AlUnlockBitmap(NativePointer.Get(bitmap));
  }

  /// <summary>
  /// <para>
  /// Like <see cref="LockBitmap"/>, but allows locking bitmaps with a blocked pixel format (i.e. a format for which
  /// <see cref="GetPixelBlockWidth"/> or <see cref="GetPixelBlockHeight"/> do not return 1) in that format.
  /// To that end, this function also does not allow format conversion. For bitmap formats with a block size of 1,
  /// this function is identical to calling <c>Al.LockBitmap(bitmap, Al.GetBitmapFormat(bitmap), flags)</c>.
  /// </para>
  /// <para>
  /// Note: Currently there are no drawing functions that work when the bitmap is locked with a compressed format.
  /// <see cref="GetPixel"/> will also not work.
  /// </para>
  /// </summary>
  /// <param name="bitmap">The bitmap to lock.</param>
  /// <param name="flag">The lock option.</param>
  /// <returns>The locked bitmap region if successful, otherwise <c>null</c>.</returns>
  public static Models.AllegroLockedRegion? LockBitmapBlocked(AllegroBitmap? bitmap, LockFlag flag)
  {
    var pointer = Interop.Context.Core.AlLockBitmapBlocked(NativePointer.Get(bitmap), (int)flag);
    return pointer == IntPtr.Zero
      ? null
      : new Models.AllegroLockedRegion { Struct = Marshal.PtrToStructure<Native.Structs.AllegroLockedRegion>(pointer) };
  }

  /// <summary>
  /// Like <see cref="LockBitmapBlocked"/>, but allows locking a sub-region, for performance.
  /// Unlike <see cref="LockBitmapRegion"/> the region specified in terms of blocks and not pixels.
  /// </summary>
  /// <param name="bitmap"></param>
  /// <param name="x">The X block position.</param>
  /// <param name="y">The Y block position.</param>
  /// <param name="width">The width in blocks.</param>
  /// <param name="height">The height in blocks.</param>
  /// <param name="flag">The lock option.</param>
  /// <returns>A locked bitmap region on success, otherwise <c>null</c>.</returns>
  public static Models.AllegroLockedRegion? LockBitmapRegionBlocked(
    AllegroBitmap? bitmap,
    int x,
    int y,
    int width,
    int height,
    LockFlag flag)
  {
    var pointer = Interop.Context.Core.AlLockBitmapRegionBlocked(
      NativePointer.Get(bitmap),
      x,
      y,
      width,
      height,
      (int)flag);
    return pointer == IntPtr.Zero
      ? null
      : new Models.AllegroLockedRegion { Struct = Marshal.PtrToStructure<Native.Structs.AllegroLockedRegion>(pointer) };
  }

  /// <summary>
  /// <para>
  /// Creates a new bitmap using the bitmap format and flags for the current thread. Blitting between bitmaps of
  /// differing formats, or blitting between memory bitmaps and display bitmaps may be slow.
  /// </para>
  /// <para>
  /// Unless you set the <see cref="BitmapFlags.MemoryBitmap"/> flag, the bitmap is created for the current display.
  /// Blitting to another display may be slow.
  /// </para>
  /// <para>
  /// If a display bitmap is created, there may be limitations on the allowed dimensions. For example a DirectX
  /// or OpenGL backend usually has a maximum allowed texture size - so if bitmap creation fails for very large
  /// dimensions, you may want to re-try with a smaller bitmap. Some platforms also dictate a minimum texture size,
  /// which is relevant if you plan to use this bitmap with the primitives addon. If you try to create a bitmap
  /// smaller than this, this call will not fail but the returned bitmap will be a section of a larger bitmap with
  /// the minimum size. The minimum size that will work on all platforms is 32 by 32. There is an experimental switch
  /// to turns this padding off by editing the system configuration (see
  /// <c>min_bitmap_size</c> key in <see cref="GetSystemConfig"/>).
  /// </para>
  /// <para>
  /// Some platforms do not directly support display bitmaps whose dimensions are not powers of two. Allegro
  /// handles this by creating a larger bitmap that has dimensions that are powers of two and then returning a
  /// section of that bitmap with the dimensions you requested. This can be relevant if you plan to use this bitmap
  /// with the primitives addon but shouldn’t be an issue otherwise.
  /// </para>
  /// <para>
  /// If you create a bitmap without <see cref="BitmapFlags.MemoryBitmap"/> set but there is no current display,
  /// a temporary memory bitmap will be created instead. You can later convert all such bitmap to video bitmap
  /// and assign to a display by calling <see cref="ConvertMemoryBitmaps"/>.
  /// </para>
  /// <para>
  /// On some platforms the contents of video bitmaps may be lost when your application loses focus. Allegro
  /// has an internal mechanism to restore the contents of these video bitmaps, but it is not foolproof
  /// (sometimes bitmap contents can get lost permanently) and has performance implications. If you are using
  /// a bitmap as an intermediate buffer this mechanism may be wasteful. In this case, if you do not want Allegro
  /// to manage the bitmap contents for you, you can disable this mechanism by creating the bitmap with the
  /// <see cref="BitmapFlags.NoPreserveTexture"/> flag. The bitmap contents are lost when you get the
  /// <see cref="EventType.DisplayLost"/> and <see cref="EventType.DisplayHaltDrawing"/> and a should be restored
  /// when you get the <see cref="EventType.DisplayFound"/> and when you call <see cref="AcknowledgeDrawingResume"/>
  /// (after <see cref="EventType.DisplayResumeDrawing"/> event). You can use those events to implement your own
  /// bitmap content restoration mechanism if Allegro’s does not work well enough for you (for example, you can
  /// reload them all from disk).
  /// </para>
  /// <para>
  /// Note: The contents of a newly created bitmap are undefined - you need to clear the bitmap or make sure all
  /// pixels get overwritten before drawing it.
  /// </para>
  /// <para>
  /// When you are done with using the bitmap you must call <see cref="DestroyBitmap"/> on it to free any resources
  /// allocated for it.
  /// </para>
  /// </summary>
  /// <param name="width">The width of the bitmap in pixels.</param>
  /// <param name="height">The height of the bitmap in pixels.</param>
  /// <returns>The created bitmap on success, otherwise <c>null</c>.</returns>
  public static AllegroBitmap? CreateBitmap(int width, int height)
  {
    var pointer = Interop.Context.Core.AlCreateBitmap(width, height);
    return NativePointer.Create<AllegroBitmap>(pointer);
  }

  /// <summary>
  /// <para>
  /// Creates a sub-bitmap of the parent, at the specified coordinates and of the specified size. A sub-bitmap
  /// is a bitmap that shares drawing memory with a pre-existing (parent) bitmap, but possibly with a different
  /// size and clipping settings.
  /// </para>
  /// <para>
  /// The sub-bitmap may originate off or extend past the parent bitmap.
  /// </para>
  /// <para>
  /// See the discussion in <see cref="GetBackbuffer"/> about using sub-bitmaps of the backbuffer.
  /// </para>
  /// <para>
  /// The parent bitmap’s clipping rectangles are ignored.
  /// </para>
  /// <para>
  /// If a sub-bitmap was not or cannot be created then <c>null</c> is returned.
  /// </para>
  /// <para>
  /// When you are done with using the sub-bitmap you must call <see cref="DestroyBitmap"/> on it to free any
  /// resources allocated for it.
  /// </para>
  /// <para>
  /// Note that destroying parents of sub-bitmaps will not destroy the sub-bitmaps; instead the sub-bitmaps become
  /// invalid and should no longer be used for drawing - they still must be destroyed with <see cref="DestroyBitmap"/>
  /// however. It does not matter whether you destroy a sub-bitmap before or after its parent otherwise.
  /// </para>
  /// </summary>
  /// <param name="parent">The parent bitmap.</param>
  /// <param name="x">The X position in pixels.</param>
  /// <param name="y">The Y position in pixels.</param>
  /// <param name="width">The width in pixels.</param>
  /// <param name="height">The height in pixels.</param>
  /// <returns>The sub-bitmap instance on success, otherwise <c>null</c>.</returns>
  public static AllegroBitmap? CreateSubBitmap(AllegroBitmap? parent, int x, int y, int width, int height)
  {
    var pointer = Interop.Context.Core.AlCreateSubBitmap(NativePointer.Get(parent), x, y, width, height);
    return NativePointer.Create<AllegroBitmap>(pointer);
  }

  /// <summary>
  /// Create a new bitmap with al_create_bitmap, and copy the pixel data from the old bitmap across. The newly
  /// created bitmap will be created with the current new bitmap flags, and not the ones that were used to create
  /// the original bitmap. If the new bitmap is a memory bitmap, its projection bitmap is reset to be orthographic.
  /// </summary>
  /// <param name="bitmap">The bitmap to clone.</param>
  /// <returns>The bitmap instance on success, otherwise <c>null</c>.</returns>
  public static AllegroBitmap? CloneBitmap(AllegroBitmap? bitmap)
  {
    var pointer = Interop.Context.Core.AlCloneBitmap(NativePointer.Get(bitmap));
    return NativePointer.Create<AllegroBitmap>(pointer);
  }

  /// <summary>
  /// <para>
  /// Converts the bitmap to the current bitmap flags and format. The bitmap will be as if it was created anew with
  /// <see cref="CreateBitmap"/> but retain its contents. All of this bitmap’s sub-bitmaps are also converted. If
  /// the new bitmap type is memory, then the bitmap’s projection bitmap is reset to be orthographic.
  /// </para>
  /// <para>
  /// If this bitmap is a sub-bitmap, then it, its parent and all the sibling sub-bitmaps are also converted.
  /// </para>
  /// </summary>
  /// <param name="bitmap">The bitmap to convert.</param>
  public static void ConvertBitmap(AllegroBitmap? bitmap)
  {
    Interop.Context.Core.AlConvertBitmap(NativePointer.Get(bitmap));
  }

  /// <summary>
  /// <para>
  /// If you create a bitmap when there is no current display (for example because you have not called
  /// <see cref="CreateDisplay"/> in the current thread) and are using the <see cref="BitmapFlags.ConvertBitmap"/>
  /// bitmap flag (which is set by default) then the bitmap will be created successfully, but as a memory bitmap.
  /// This function converts all such bitmaps to proper video bitmaps belonging to the current display.
  /// </para>
  /// <para>
  /// Note that video bitmaps get automatically converted back to memory bitmaps when the last display is destroyed.
  /// </para>
  /// <para>
  /// This operation will preserve all bitmap flags except <see cref="BitmapFlags.VideoBitmap"/> and
  /// <see cref="BitmapFlags.MemoryBitmap"/>.
  /// </para>
  /// </summary>
  public static void ConvertMemoryBitmaps()
  {
    Interop.Context.Core.AlConvertMemoryBitmaps();
  }

  /// <summary>
  /// <para>
  /// Destroys the given bitmap, freeing all resources used by it. This function does nothing if the bitmap argument
  /// is <c>null</c>.
  /// </para>
  /// <para>
  /// As a convenience, if the calling thread is currently targeting the bitmap then the bitmap will be untargeted
  /// first. The new target bitmap is unspecified. (since: 5.0.10, 5.1.6)
  /// </para>
  /// <para>
  /// Otherwise, it is an error to destroy a bitmap while it (or a sub-bitmap) is the target bitmap of any thread.
  /// </para>
  /// </summary>
  /// <param name="bitmap">The bitmap to destroy.</param>
  public static void DestroyBitmap(AllegroBitmap? bitmap)
  {
    Interop.Context.Core.AlDestroyBitmap(NativePointer.Get(bitmap));
  }

  /// <summary>
  /// Returns the flags used for newly created bitmaps.
  /// </summary>
  /// <returns>The flags used for newly created bitmaps.</returns>
  public static BitmapFlags GetNewBitmapFlags()
  {
    return (BitmapFlags)Interop.Context.Core.AlGetNewBitmapFlags();
  }

  /// <summary>
  /// Returns the format used for newly created bitmaps.
  /// </summary>
  /// <returns>The format used for newly created bitmaps.</returns>
  public static PixelFormat GetNewBitmapFormat()
  {
    return (PixelFormat)Interop.Context.Core.AlGetNewBitmapFormat();
  }

  /// <summary>
  /// Sets the flags to use for newly created bitmaps.
  /// </summary>
  /// <param name="flags">The flags to use for newly created bitmaps.</param>
  public static void SetNewBitmapFlags(BitmapFlags flags)
  {
    Interop.Context.Core.AlSetNewBitmapFlags((int)flags);
  }

  /// <summary>
  /// A convenience function which does the same as
  /// <c>Al.SetNewBitmapFlags(Al.GetNewBitmapFlags() | flags);</c>.
  /// </summary>
  /// <param name="flags">The flags to add to newly created bitmaps.</param>
  public static void AddNewBitmapFlag(BitmapFlags flags)
  {
    Interop.Context.Core.AlAddNewBitmapFlag((int)flags);
  }

  /// <summary>
  /// Sets the pixel format for newly created bitmaps. The default format is <see cref="PixelFormat.Any"/>
  /// and means the display driver will choose the best format.
  /// </summary>
  /// <param name="format">The format to use for newly created bitmaps.</param>
  public static void SetNewBitmapFormat(PixelFormat format)
  {
    Interop.Context.Core.AlSetNewBitmapFormat((int)format);
  }

  /// <summary>
  /// Return the flags used to create the bitmap.
  /// </summary>
  /// <param name="bitmap">The bitmap instance.</param>
  /// <returns>The flags used to create the bitmap.</returns>
  public static BitmapFlags GetBitmapFlags(AllegroBitmap? bitmap)
  {
    return (BitmapFlags)Interop.Context.Core.AlGetBitmapFlags(NativePointer.Get(bitmap));
  }

  /// <summary>
  /// Returns the pixel format of a bitmap.
  /// </summary>
  /// <param name="bitmap">The bitmap instance.</param>
  /// <returns>The pixel format of a bitmap.</returns>
  public static PixelFormat GetBitmapFormat(AllegroBitmap? bitmap)
  {
    return (PixelFormat)Interop.Context.Core.AlGetBitmapFormat(NativePointer.Get(bitmap));
  }

  /// <summary>
  /// Returns the height of a bitmap in pixels.
  /// </summary>
  /// <param name="bitmap">The bitmap instance.</param>
  /// <returns>The height of a bitmap in pixels.</returns>
  public static int GetBitmapHeight(AllegroBitmap? bitmap)
  {
    return Interop.Context.Core.AlGetBitmapHeight(NativePointer.Get(bitmap));
  }

  /// <summary>
  /// Returns the width of a bitmap in pixels.
  /// </summary>
  /// <param name="bitmap">The bitmap instance.</param>
  /// <returns>The width of a bitmap in pixels.</returns>
  public static int GetBitmapWidth(AllegroBitmap? bitmap)
  {
    return Interop.Context.Core.AlGetBitmapWidth(NativePointer.Get(bitmap));
  }

  /// <summary>
  /// Get a pixel’s color value from the specified bitmap. This operation is slow on non-memory bitmaps. Consider
  /// locking the bitmap if you are going to use this function multiple times on the same bitmap.
  /// </summary>
  /// <param name="bitmap">The bitmap instance.</param>
  /// <param name="x">The X position in pixels.</param>
  /// <param name="y">The Y position in pixels.</param>
  /// <returns>The color.</returns>
  public static AllegroColor GetPixel(AllegroBitmap? bitmap, int x, int y)
  {
    return Interop.Context.Core.AlGetPixel(NativePointer.Get(bitmap), x, y);
  }

  /// <summary>
  /// Returns whether or not a bitmap is already locked.
  /// </summary>
  /// <param name="bitmap">The bitmap instance.</param>
  /// <returns>True if the bitmap is already locked, otherwise false.</returns>
  public static bool IsBitmapLocked(AllegroBitmap? bitmap)
  {
    return Interop.Context.Core.AlIsBitmapLocked(NativePointer.Get(bitmap)) != 0;
  }

  /// <summary>
  /// <para>
  /// D3D and OpenGL allow sharing a texture in a way so it can be used for multiple windows. Each
  /// <see cref="AllegroBitmap"/> created with <see cref="CreateBitmap"/> however is usually tied to a single
  /// <see cref="AllegroDisplay"/>. This function can be used to know if the bitmap is compatible with the given
  /// display, even if it is a different display to the one it was created with. It returns true if the bitmap is
  /// compatible (things like a cached texture version can be used) and false otherwise (blitting in the current
  /// display will be slow).
  /// </para>
  /// <para>
  /// The only time this function is useful is if you are using multiple windows and need accelerated blitting of
  /// the same bitmaps to both.
  /// </para>
  /// <para>
  /// Returns true if the bitmap is compatible with the current display, false otherwise. If there is no current
  /// display, false is returned.
  /// </para>
  /// </summary>
  /// <param name="bitmap">The bitmap instance.</param>
  /// <returns>True if the bitmap is compatible with the current display, otherwise false.</returns>
  public static bool IsCompatibleBitmap(AllegroBitmap? bitmap)
  {
    return Interop.Context.Core.AlIsCompatibleBitmap(NativePointer.Get(bitmap)) != 0;
  }

  /// <summary>
  /// Returns true if the specified bitmap is a sub-bitmap, false otherwise.
  /// </summary>
  /// <param name="bitmap">The bitmap instance.</param>
  /// <returns>True if the specified bitmap is a sub-bitmap, false otherwise.</returns>
  public static bool IsSubBitmap(AllegroBitmap? bitmap)
  {
    return Interop.Context.Core.AlIsSubBitmap(NativePointer.Get(bitmap)) != 0;
  }

  /// <summary>
  /// Returns the bitmap this bitmap is a sub-bitmap of. Returns <c>null</c> if this bitmap is not a sub-bitmap. This
  /// function always returns the real bitmap, and never a sub-bitmap. This might NOT match what was passed to
  /// <see cref="CreateSubBitmap"/>.
  /// </summary>
  /// <param name="bitmap">The bitmap instance.</param>
  /// <returns>The parent bitmap instance on success, otherwise <c>null</c>.</returns>
  public static AllegroBitmap? GetParentBitmap(AllegroBitmap? bitmap)
  {
    var pointer = Interop.Context.Core.AlGetParentBitmap(NativePointer.Get(bitmap));
    return NativePointer.Create<AllegroBitmap>(pointer);
  }

  /// <summary>
  /// For a sub-bitmap, return it’s X position within the parent.
  /// </summary>
  /// <param name="bitmap">The sub-bitmap instance.</param>
  /// <returns>X position within the parent bitmap.</returns>
  public static int GetBitmapX(AllegroBitmap? bitmap)
  {
    return Interop.Context.Core.AlGetBitmapX(NativePointer.Get(bitmap));
  }

  /// <summary>
  /// For a sub-bitmap, return it’s Y position within the parent.
  /// </summary>
  /// <param name="bitmap">The sub-bitmap instance.</param>
  /// <returns>Y position within the parent bitmap.</returns>
  public static int GetBitmapY(AllegroBitmap? bitmap)
  {
    return Interop.Context.Core.AlGetBitmapY(NativePointer.Get(bitmap));
  }

  /// <summary>
  /// For a sub-bitmap, changes the parent, position and size. This is the same as destroying the bitmap and
  /// re-creating it with <see cref="CreateSubBitmap"/> - except the bitmap pointer stays the same. This has many
  /// uses, for example an animation player could return a single bitmap which can just be re-parented to different
  /// animation frames without having to re-draw the contents. Or a sprite atlas could re-arrange its sprites without
  /// having to invalidate all existing bitmaps.
  /// </summary>
  /// <param name="bitmap">The sub-bitmap instance.</param>
  /// <param name="parent">The parent bitmap instance.</param>
  /// <param name="x">The X position in pixels.</param>
  /// <param name="y">The Y position in pixels.</param>
  /// <param name="width">The width in pixels.</param>
  /// <param name="height">The height in pixels.</param>
  public static void ReparentBitmap(AllegroBitmap? bitmap, AllegroBitmap? parent, int x, int y, int width, int height)
  {
    Interop.Context.Core.AlReparentBitmap(NativePointer.Get(bitmap), NativePointer.Get(parent), x, y, width, height);
  }

  /// <summary>
  /// Clear the complete target bitmap, but confined by the clipping rectangle.
  /// </summary>
  /// <param name="color">The color to clear to.</param>
  public static void ClearToColor(AllegroColor color)
  {
    Interop.Context.Core.AlClearToColor(color);
  }

  /// <summary>
  /// <para>
  /// Clear the depth buffer (confined by the clipping rectangle) to the given value. A depth buffer is only available
  /// if it was requested with <see cref="SetNewDisplayOption"/> and the requirement could be met by the
  /// <see cref="CreateDisplay"/> call creating the current display. Operations involving the depth buffer are also
  /// affected by <see cref="SetRenderState"/>.
  /// </para>
  /// <para>
  /// For example, if <see cref="RenderState.DepthFunction"/> is set to <see cref="RenderFunction.Less"/> then depth
  /// buffer value of 1 represents infinite distance, and thus is a good value to use when clearing the depth buffer.
  /// </para>
  /// </summary>
  /// <param name="z">The value to clear the depth buffer to.</param>
  public static void ClearDepthBuffer(float z)
  {
    Interop.Context.Core.AlClearDepthBuffer(z);
  }

  /// <summary>
  /// <para>
  /// Draws an unscaled, unrotated bitmap at the given position to the current target bitmap (see
  /// <see cref="SetTargetBitmap"/>).
  /// </para>
  /// <para>
  /// Note: The current target bitmap must be a different bitmap. Drawing a bitmap to itself (or to a sub-bitmap of
  /// itself) or drawing a sub-bitmap to its parent (or another sub-bitmap of its parent) are not currently supported.
  /// To copy part of a bitmap into the same bitmap simply use a temporary bitmap instead.
  /// </para>
  /// <para>
  /// Note: The backbuffer (or a sub-bitmap thereof) can not be transformed, blended or tinted. If you need to draw
  /// the backbuffer draw it to a temporary bitmap first with no active transformation (except translation). Blending
  /// and tinting settings/parameters will be ignored. This does not apply when drawing into a memory bitmap.
  /// </para>
  /// </summary>
  /// <param name="bitmap">The bitmap to draw.</param>
  /// <param name="dx">The destination X position in pixels.</param>
  /// <param name="dy">The destination Y position in pixels.</param>
  /// <param name="flags">The flip flags.</param>
  public static void DrawBitmap(AllegroBitmap? bitmap, float dx, float dy, FlipFlags flags)
  {
    Interop.Context.Core.AlDrawBitmap(NativePointer.Get(bitmap), dx, dy, (int)flags);
  }

  /// <summary>
  /// Like <see cref="DrawBitmap"/> but multiplies all colors in the bitmap with the given color. See
  /// <see cref="DrawBitmap"/> for a note on restrictions on which bitmaps can be drawn where.
  /// </summary>
  /// <param name="bitmap">The bitmap to draw.</param>
  /// <param name="tint">The tint to apply.</param>
  /// <param name="dx">The destination X position in pixels.</param>
  /// <param name="dy">The destination Y position in pixels.</param>
  /// <param name="flags">The flip flags.</param>
  public static void DrawTintedBitmap(AllegroBitmap? bitmap, AllegroColor tint, float dx, float dy, FlipFlags flags)
  {
    Interop.Context.Core.AlDrawTintedBitmap(NativePointer.Get(bitmap), tint, dx, dy, (int)flags);
  }
  
  /// <summary>
  /// Draws a region of the given bitmap to the target bitmap. See <see cref="DrawBitmap"/> for a note on restrictions
  /// on which bitmaps can be drawn where.
  /// </summary>
  /// <param name="bitmap">The bitmap to draw.</param>
  /// <param name="sx">The source X position in pixels.</param>
  /// <param name="sy">The source Y position in pixels.</param>
  /// <param name="sw">The source width position in pixels.</param>
  /// <param name="sh">The source height position in pixels.</param>
  /// <param name="dx">The destination X position in pixels.</param>
  /// <param name="dy">The destination Y position in pixels.</param>
  /// <param name="flags">The flip flags.</param>
  public static void DrawBitmapRegion(
    AllegroBitmap? bitmap,
    float sx,
    float sy,
    float sw,
    float sh,
    float dx,
    float dy,
    FlipFlags flags)
  {
    Interop.Context.Core.AlDrawBitmapRegion(NativePointer.Get(bitmap), sx, sy, sw, sh, dx, dy, (int)flags);
  }

  /// <summary>
  /// Like <see cref="DrawBitmapRegion"/> but multiplies all colors in the bitmap with the given color. See
  /// <see cref="DrawBitmap"/> for a note on restrictions on which bitmaps can be drawn where.
  /// </summary>
  /// <param name="bitmap">The bitmap to draw.</param>
  /// <param name="tint">The color tint.</param>
  /// <param name="sx">The source X position in pixels.</param>
  /// <param name="sy">The source Y position in pixels.</param>
  /// <param name="sw">The source width position in pixels.</param>
  /// <param name="sh">The source height position in pixels.</param>
  /// <param name="dx">The destination X position in pixels.</param>
  /// <param name="dy">The destination Y position in pixels.</param>
  /// <param name="flags">The flip flags.</param>
  public static void DrawTintedBitmapRegion(
    AllegroBitmap? bitmap,
    AllegroColor tint,
    float sx,
    float sy,
    float sw,
    float sh,
    float dx,
    float dy,
    FlipFlags flags)
  {
    Interop.Context.Core.AlDrawTintedBitmapRegion(NativePointer.Get(bitmap), tint, sx, sy, sw, sh, dx, dy, (int)flags);
  }

  /// <summary>
  /// <para>
  /// Draws a single pixel at x, y. This function, unlike <see cref="PutPixel"/>, does blending and, unlike
  /// <see cref="PutBlendedPixel"/>, respects the transformations (that is, the pixel’s position is transformed,
  /// but its size is unaffected - it remains a pixel). This function can be slow if called often; if you need to
  /// draw a lot of pixels consider using <see cref="DrawPrim"/> with <see cref="PrimType.PointList"/> from the
  /// primitives addon.
  /// </para>
  /// <para>
  /// Note: This function may not draw exactly where you expect it to. See the pixel-precise output section on the
  /// primitives addon documentation for details on how to control exactly where the pixel is drawn.
  /// </para>
  /// </summary>
  /// <param name="x">The X position in pixels.</param>
  /// <param name="y">The Y position in pixels.</param>
  /// <param name="color">The color to draw.</param>
  public static void DrawPixel(float x, float y, AllegroColor color)
  {
    Interop.Context.Core.AlDrawPixel(x, y, color);
  }

  /// <summary>
  /// <para>
  /// Draws a rotated version of the given bitmap to the target bitmap. The bitmap is rotated by ‘angle’ radians
  /// clockwise. See <see cref="DrawBitmap"/> for a note on restrictions on which bitmaps can be drawn where.
  /// </para>
  /// <para>
  /// The point at <paramref name="cx"/>/<paramref name="cy"/> relative to the upper left corner of the bitmap will
  /// be drawn at <paramref name="dx"/>/<paramref name="dy"/> and the bitmap is rotated around this point. If
  /// <paramref name="cx"/>,<paramref name="cy"/> is 0,0 the bitmap will rotate around its upper left corner.
  /// </para>
  /// </summary>
  /// <param name="bitmap">The bitmap to draw.</param>
  /// <param name="cx">The X position in pixels of the source bitmap rotation.</param>
  /// <param name="cy">The Y position in pixels of the source bitmap rotation.</param>
  /// <param name="dx">The X position in pixels of the destination of the rotation point.</param>
  /// <param name="dy">The Y position in pixels of the destination of the rotation point.</param>
  /// <param name="angle">The angle to rotate in radians.</param>
  /// <param name="flags">The flip flags.</param>
  public static void DrawRotatedBitmap(
    AllegroBitmap? bitmap,
    float cx,
    float cy,
    float dx,
    float dy,
    float angle,
    FlipFlags flags)
  {
    Interop.Context.Core.AlDrawRotatedBitmap(NativePointer.Get(bitmap), cx, cy, dx, dy, angle, (int)flags);
  }

  /// <summary>
  /// Like <see cref="DrawRotatedBitmap"/> but multiplies all colors in the bitmap with the given color.
  /// See <see cref="DrawBitmap"/> for a note on restrictions on which bitmaps can be drawn where.
  /// </summary>
  /// <param name="bitmap">The bitmap to draw.</param>
  /// <param name="tint">The tint to multiple all colors by.</param>
  /// <param name="cx">The X position in pixels of the source bitmap rotation.</param>
  /// <param name="cy">The Y position in pixels of the source bitmap rotation.</param>
  /// <param name="dx">The X position in pixels of the destination of the rotation point.</param>
  /// <param name="dy">The Y position in pixels of the destination of the rotation point.</param>
  /// <param name="angle">The angle to rotate in radians.</param>
  /// <param name="flags">The flip flags.</param>
  public static void DrawTintedRotatedBitmap(
    AllegroBitmap? bitmap,
    AllegroColor tint,
    float cx,
    float cy,
    float dx,
    float dy,
    float angle,
    FlipFlags flags)
  {
    Interop.Context.Core.AlDrawTintedRotatedBitmap(NativePointer.Get(bitmap), tint, cx, cy, dx, dy, angle, (int)flags);
  }

  /// <summary>
  /// Like <see cref="DrawRotatedBitmap"/> but can also scale the bitmap.
  /// See <see cref="DrawBitmap"/> for a note on restrictions on which bitmaps can be drawn where.
  /// </summary>
  /// <param name="bitmap">The bitmap to draw.</param>
  /// <param name="cx">The X position in pixels of the source bitmap rotation.</param>
  /// <param name="cy">The Y position in pixels of the source bitmap rotation.</param>
  /// <param name="dx">The X position in pixels of the destination of the rotation point.</param>
  /// <param name="dy">The Y position in pixels of the destination of the rotation point.</param>
  /// <param name="xscale">The amount to scale on the X-axis (ex: 2 for twice the size).</param>
  /// <param name="yscale">The amount to scale on the Y-axis (ex: 2 for twice the size).</param>
  /// <param name="angle">The angle to rotate in radians.</param>
  /// <param name="flags">The flip flags.</param>
  public static void DrawScaledRotatedBitmap(
    AllegroBitmap? bitmap,
    float cx,
    float cy,
    float dx,
    float dy,
    float xscale,
    float yscale,
    float angle,
    FlipFlags flags)
  {
    Interop.Context.Core.AlDrawScaledRotatedBitmap(NativePointer.Get(bitmap), cx, cy, dx, dy, xscale, yscale, angle, (int)flags);
  }

  /// <summary>
  /// Like <see cref="DrawScaledRotatedBitmap"/> but multiplies all colors in the bitmap with the given color.
  /// See <see cref="DrawBitmap"/> for a note on restrictions on which bitmaps can be drawn where.
  /// </summary>
  /// <param name="bitmap">The bitmap to draw.</param>
  /// <param name="tint">The tint to multiple all colors by.</param>
  /// <param name="cx">The X position in pixels of the source bitmap rotation.</param>
  /// <param name="cy">The Y position in pixels of the source bitmap rotation.</param>
  /// <param name="dx">The X position in pixels of the destination of the rotation point.</param>
  /// <param name="dy">The Y position in pixels of the destination of the rotation point.</param>
  /// <param name="xscale">The amount to scale on the X-axis (ex: 2 for twice the size).</param>
  /// <param name="yscale">The amount to scale on the Y-axis (ex: 2 for twice the size).</param>
  /// <param name="angle">The angle to rotate in radians.</param>
  /// <param name="flags">The flip flags.</param>
  public static void DrawTintedScaledRotatedBitmap(
    AllegroBitmap? bitmap,
    AllegroColor tint,
    float cx,
    float cy,
    float dx,
    float dy,
    float xscale,
    float yscale,
    float angle,
    FlipFlags flags)
  {
    Interop.Context.Core.AlDrawTintedScaledRotatedBitmap(
      NativePointer.Get(bitmap),
      tint,
      cx,
      cy,
      dx,
      dy,
      xscale,
      yscale,
      angle,
      (int)flags);
  }

  /// <summary>
  /// Like <see cref="DrawTintedScaledRotatedBitmap"/> but you specify an area within the bitmap to be drawn.
  /// See <see cref="DrawBitmap"/> for a note on restrictions on which bitmaps can be drawn where.
  /// </summary>
  /// <param name="bitmap">The bitmap to draw.</param>
  /// <param name="sx">The source X position in pixels.</param>
  /// <param name="sy">The source Y position in pixels.</param>
  /// <param name="sw">The source width position in pixels.</param>
  /// <param name="sh">The source height position in pixels.</param>
  /// <param name="tint">The tint to multiple all colors by.</param>
  /// <param name="cx">The X position in pixels of the source bitmap rotation.</param>
  /// <param name="cy">The Y position in pixels of the source bitmap rotation.</param>
  /// <param name="dx">The X position in pixels of the destination of the rotation point.</param>
  /// <param name="dy">The Y position in pixels of the destination of the rotation point.</param>
  /// <param name="xscale">The amount to scale on the X-axis (ex: 2 for twice the size).</param>
  /// <param name="yscale">The amount to scale on the Y-axis (ex: 2 for twice the size).</param>
  /// <param name="angle">The angle to rotate in radians.</param>
  /// <param name="flags">The flip flags.</param>
  public static void DrawTintedScaledRotatedBitmapRegion(
    AllegroBitmap? bitmap,
    float sx,
    float sy,
    float sw,
    float sh,
    AllegroColor tint,
    float cx,
    float cy,
    float dx,
    float dy,
    float xscale,
    float yscale,
    float angle,
    FlipFlags flags)
  {
    Interop.Context.Core.AlDrawTintedScaledRotatedBitmapRegion(
      NativePointer.Get(bitmap),
      sx,
      sy,
      sw,
      sh,
      tint,
      cx,
      cy,
      dx,
      dy,
      xscale,
      yscale,
      angle,
      (int)flags);
  }

  /// <summary>
  /// Draws a scaled version of the given bitmap to the target bitmap.
  /// See <see cref="DrawBitmap"/> for a note on restrictions on which bitmaps can be drawn where.
  /// </summary>
  /// <param name="bitmap">The bitmap to draw.</param>
  /// <param name="sx">The source X position in pixels.</param>
  /// <param name="sy">The source Y position in pixels.</param>
  /// <param name="sw">The source width position in pixels.</param>
  /// <param name="sh">The source height position in pixels.</param>
  /// <param name="dx">The X position in pixels of the destination of the rotation point.</param>
  /// <param name="dy">The Y position in pixels of the destination of the rotation point.</param>
  /// <param name="dw">The width in pixels of the destination.</param>
  /// <param name="dh">The height in pixels of the destination.</param>
  /// <param name="flags">The flip flags.</param>
  public static void DrawScaledBitmap(
    AllegroBitmap? bitmap,
    float sx,
    float sy,
    float sw,
    float sh,
    float dx,
    float dy,
    float dw,
    float dh,
    FlipFlags flags)
  {
    Interop.Context.Core.AlDrawScaledBitmap(NativePointer.Get(bitmap), sx, sy, sw, sh, dx, dy, dw, dh, (int)flags);
  }

  /// <summary>
  /// Like <see cref="DrawScaledBitmap"/> but multiplies all colors in the bitmap with the given color.
  /// See <see cref="DrawBitmap"/> for a note on restrictions on which bitmaps can be drawn where.
  /// </summary>
  /// <param name="bitmap">The bitmap to draw.</param>
  /// <param name="tint">The tint to multiple all colors by.</param>
  /// <param name="sx">The source X position in pixels.</param>
  /// <param name="sy">The source Y position in pixels.</param>
  /// <param name="sw">The source width position in pixels.</param>
  /// <param name="sh">The source height position in pixels.</param>
  /// <param name="dx">The X position in pixels of the destination of the rotation point.</param>
  /// <param name="dy">The Y position in pixels of the destination of the rotation point.</param>
  /// <param name="dw">The width in pixels of the destination.</param>
  /// <param name="dh">The height in pixels of the destination.</param>
  /// <param name="flags">The flip flags.</param>
  public static void DrawTintedScaledBitmap(
    AllegroBitmap? bitmap,
    AllegroColor tint,
    float sx,
    float sy,
    float sw,
    float sh,
    float dx,
    float dy,
    float dw,
    float dh,
    FlipFlags flags)
  {
    Interop.Context.Core.AlDrawTintedScaledBitmap(
      NativePointer.Get(bitmap),
      tint,
      sx,
      sy,
      sw,
      sh,
      dx,
      dy,
      dw,
      dh,
      (int)flags);
  }

  /// <summary>
  /// Return the target bitmap of the calling thread.
  /// </summary>
  /// <returns>The target bitmap of the calling thread.</returns>
  public static AllegroBitmap? GetTargetBitmap()
  {
    var pointer = Interop.Context.Core.AlGetTargetBitmap();
    return NativePointer.Create<AllegroBitmap>(pointer);
  }

  /// <summary>
  /// Draw a single pixel on the target bitmap. This operation is slow on non-memory bitmaps.
  /// Consider locking the bitmap if you are going to use this function multiple times on the same bitmap.
  /// This function is not affected by the transformations or the color blenders.
  /// </summary>
  /// <param name="x">The X position in pixels.</param>
  /// <param name="y">The Y position in pixels.</param>
  /// <param name="color">The color.</param>
  public static void PutPixel(int x, int y, AllegroColor color)
  {
    Interop.Context.Core.AlPutPixel(x, y, color);
  }

  /// <summary>
  /// Like <see cref="PutPixel"/>, but the pixel color is blended using the current blenders before being drawn.
  /// </summary>
  /// <param name="x">The X position in pixels.</param>
  /// <param name="y">The Y position in pixels.</param>
  /// <param name="color">The color.</param>
  public static void PutBlendedPixel(int x, int y, AllegroColor color)
  {
    Interop.Context.Core.AlPutBlendedPixel(x, y, color);
  }

  /// <summary>
  /// <para>
  /// This function selects the bitmap to which all subsequent drawing operations in the calling thread will draw to.
  /// To return to drawing to a display, set the backbuffer of the display as the target bitmap, using
  /// <see cref="GetBackbuffer"/>. As a convenience, you may also use <see cref="SetTargetBackbuffer"/>.
  /// </para>
  /// <para>
  /// Each allegro bitmap maintains two transformation matrices associated with it for drawing onto the bitmap.
  /// There is a view matrix and a projection matrix. When you call <see cref="SetTargetBitmap"/>, these will be made
  /// current for the bitmap, affecting global OpenGL and DirectX states depending on the driver in use.
  /// </para>
  /// <para>
  /// Each video bitmap is tied to a display. When a video bitmap is set to as the target bitmap, the display that
  /// the bitmap belongs to is automatically made “current” for the calling thread (if it is not current already).
  /// Then drawing other bitmaps which are tied to the same display can be hardware accelerated.
  /// </para>
  /// <para>
  /// A single display cannot be current for multiple threads simultaneously. If you need to release a display, so it
  /// is not current for the calling thread, call <c>Al.SetTargetBitmap(null)</c>;
  /// </para>
  /// <para>
  /// Setting a memory bitmap as the target bitmap will not change which display is current for the calling thread.
  /// </para>
  /// <para>
  /// On some platforms, Allegro automatically backs up the contents of video bitmaps because they may be occasionally
  /// lost (see discussion in <see cref="CreateBitmap"/> documentation). If you’re completely recreating the bitmap
  /// contents often (e.g. every frame) then you will get much better performance by creating the target bitmap with
  /// <see cref="BitmapFlags.NoPreserveTexture"/> flag.
  /// </para>
  /// <para>
  /// OpenGL note: Framebuffer objects (FBOs) allow OpenGL to directly draw to a bitmap, which is very fast.
  /// When using an OpenGL display, if all of the following conditions are met an FBO will be created for use with
  /// the bitmap:
  /// <list type="table">
  /// <item>
  /// The <c>GL_EXT_framebuffer_object</c> OpenGL extension is available.
  /// </item>
  /// <item>
  /// The bitmap is not a memory bitmap.
  /// </item>
  /// <item>
  /// The bitmap is not currently locked.
  /// </item>
  /// </list>
  /// </para>
  /// <para>
  /// In Allegro 5.0.0, you had to be careful as an FBO would be kept around until the bitmap is destroyed or you
  /// explicitly called <see cref="RemoveOpenglFbo"/> on the bitmap, wasting resources. In newer versions, FBOs will
  /// be freed automatically when the bitmap is no longer the target bitmap, unless you have called
  /// <see cref="GetOpenglFbo"/> to retrieve the FBO id.
  /// </para>
  /// <para>
  /// In the following example, no FBO will be created:
  /// <code>
  /// lock = al_lock_bitmap(bitmap);
  /// al_set_target_bitmap(bitmap);
  /// al_put_pixel(x, y, color);
  /// al_unlock_bitmap(bitmap);
  /// </code>
  /// </para>
  /// <para>
  /// In this example an FBO is created however:
  /// <code>
  /// al_set_target_bitmap(bitmap);
  /// al_draw_line(x1, y1, x2, y2, color, 0);
  /// </code>
  /// </para>
  /// </summary>
  /// <param name="bitmap">The bitmap to set as the target.</param>
  public static void SetTargetBitmap(AllegroBitmap? bitmap)
  {
    Interop.Context.Core.AlSetTargetBitmap(NativePointer.Get(bitmap));
  }

  /// <summary>
  /// Same as: <code>Al.SetTargetBitmap(Al.GetBackbuffer(display));</code>
  /// </summary>
  /// <param name="display">The display to set the backbuffer of.</param>
  public static void SetTargetBackbuffer(AllegroDisplay? display)
  {
    Interop.Context.Core.AlSetTargetBackbuffer(NativePointer.Get(display));
  }

  /// <summary>
  /// Return the display that is “current” for the calling thread, or <c>null</c> if there is none.
  /// </summary>
  /// <returns>The display that is "current" for the calling thread on success, otherwise <c>null</c>.</returns>
  public static AllegroDisplay? GetCurrentDisplay()
  {
    var pointer = Interop.Context.Core.AlGetCurrentDisplay();
    return NativePointer.Create<AllegroDisplay>(pointer);
  }

  /// <summary>
  /// Returns the active blender for the current thread.
  /// </summary>
  /// <param name="op">The operation.</param>
  /// <param name="src">The source.</param>
  /// <param name="dst">The destination.</param>
  public static void GetBlender(ref int op, ref int src, ref int dst)
  {
    Interop.Context.Core.AlGetBlender(ref op, ref src, ref dst);
  }

  /// <summary>
  /// Returns the active blender for the current thread.
  /// </summary>
  /// <param name="op">The operation.</param>
  /// <param name="src">The source.</param>
  /// <param name="dst">The destination.</param>
  /// <param name="alphaOp">The alpha operation.</param>
  /// <param name="alphaSrc">The alpha source.</param>
  /// <param name="alphaDst">The alpha destination.</param>
  public static void GetSeparateBlender(
    ref int op,
    ref int src,
    ref int dst,
    ref int alphaOp,
    ref int alphaSrc,
    ref int alphaDst)
  {
    Interop.Context.Core.AlGetSeparateBlender(ref op, ref src, ref dst, ref alphaOp, ref alphaSrc, ref alphaDst);
  }

  /// <summary>
  /// Returns the color currently used for constant color blending (white by default).
  /// </summary>
  /// <returns>The color currently used for constant color blending.</returns>
  public static AllegroColor GetBlendColor()
  {
    return Interop.Context.Core.AlGetBlendColor();
  }

  /// <summary>
  /// <para>
  /// Sets the function to use for blending for the current thread.
  /// </para>
  /// <para>
  /// Blending means, the source and destination colors are combined in drawing operations.
  /// </para>
  /// <para>
  /// Assume the source color (e.g. color of a rectangle to draw, or pixel of a bitmap to draw) is given
  /// as its red/green/blue/alpha components (if the bitmap has no alpha it always is assumed to be fully
  /// opaque, so 255 for 8-bit or 1.0 for floating point): <c>s = s.r, s.g, s.b, s.a</c>. And this color is drawn
  /// to a destination, which already has a color: <c>d = d.r, d.g, d.b, d.a</c>.
  /// </para>
  /// <para>
  /// The conceptional formula used by Allegro to draw any pixel then depends on the op parameter:
  /// <list type="table">
  /// <item>
  /// For example, add:
  /// </item>
  /// <item>
  /// <code>
  /// r = d.r * df.r + s.r * sf.r
  /// g = d.g * df.g + s.g * sf.g
  /// b = d.b * df.b + s.b * sf.b
  /// a = d.a * df.a + s.a * sf.a
  /// </code>
  /// </item>
  /// </list>
  /// </para>
  /// <para>
  /// See the Allegro documentation for further discussion.
  /// </para>
  /// </summary>
  /// <param name="op">The operation.</param>
  /// <param name="src">The source.</param>
  /// <param name="dst">The destination.</param>
  public static void SetBlender(int op, int src, int dst)
  {
    Interop.Context.Core.AlSetBlender(op, src, dst);
  }

  /// <summary>
  /// Like <see cref="SetBlender"/>, but allows specifying a separate blending operation for the alpha channel.
  /// This is useful if your target bitmap also has an alpha channel and the two alpha channels need to be combined
  /// in a different way than the color components.
  /// </summary>
  /// <param name="op">The operation.</param>
  /// <param name="src">The source.</param>
  /// <param name="dst">The destination.</param>
  /// <param name="alphaOp">The alpha operation.</param>
  /// <param name="alphaSrc">The alpha source.</param>
  /// <param name="alphaDst">The alpha destination.</param>
  public static void SetSeparateBlender(int op, int src, int dst, int alphaOp, int alphaSrc, int alphaDst)
  {
    Interop.Context.Core.AlSetSeparateBlender(op, src, dst, alphaOp, alphaSrc, alphaDst);
  }

  /// <summary>
  /// Sets the color to use for blending when using the ALLEGRO_CONST_COLOR or
  /// ALLEGRO_INVERSE_CONST_COLOR blend functions. See <see cref="SetBlender"/> for more information.
  /// </summary>
  /// <param name="color">The color to use for blending.</param>
  public static void SetBlendColor(AllegroColor color)
  {
    Interop.Context.Core.AlSetBlendColor(color);
  }

  /// <summary>
  /// Gets the clipping rectangle of the target bitmap.
  /// </summary>
  /// <param name="x">The X position in pixels.</param>
  /// <param name="y">The Y position in pixels.</param>
  /// <param name="width">The width in pixels.</param>
  /// <param name="height">The height in pixels.</param>
  public static void GetClippingRectangle(ref int x, ref int y, ref int width, ref int height)
  {
    Interop.Context.Core.AlGetClippingRectangle(ref x, ref y, ref width, ref height);
  }

  /// <summary>
  /// Set the region of the target bitmap or display that pixels get clipped to.
  /// The default is to clip pixels to the entire bitmap.
  /// </summary>
  /// <param name="x">The X position in pixels.</param>
  /// <param name="y">The Y position in pixels.</param>
  /// <param name="width">The width in pixels.</param>
  /// <param name="height">The height in pixels.</param>
  public static void SetClippingRectangle(int x, int y, int width, int height)
  {
    Interop.Context.Core.AlSetClippingRectangle(x, y, width, height);
  }

  /// <summary>
  /// Equivalent to calling <c>Al.SetClippingRectangle(0, 0, w, h)</c> where w and h are the width and height of
  /// the target bitmap respectively. Does nothing if there is no target bitmap.
  /// </summary>
  public static void ResetClippingRectangle()
  {
    Interop.Context.Core.AlResetClippingRectangle();
  }

  /// <summary>
  /// Convert the given mask color to an alpha channel in the bitmap. Can be used to convert older 4.2-style
  /// bitmaps with magic pink to alpha-ready bitmaps.
  /// </summary>
  /// <param name="bitmap">The bitmap instance.</param>
  /// <param name="maskColor">The color to turn into an alpha channel.</param>
  public static void ConvertMaskToAlpha(AllegroBitmap? bitmap, AllegroColor maskColor)
  {
    Interop.Context.Core.AlConvertMaskToAlpha(NativePointer.Get(bitmap), maskColor);
  }

  /// <summary>
  /// <para>
  /// Enables or disables deferred bitmap drawing. This allows for efficient drawing of many bitmaps that share
  /// a parent bitmap, such as sub-bitmaps from a tilesheet or simply identical bitmaps. Drawing bitmaps that do
  /// not share a parent is less efficient, so it is advisable to stagger bitmap drawing calls such that the parent
  /// bitmap is the same for large number of those calls. While deferred bitmap drawing is enabled, the only
  /// functions that can be used are the bitmap drawing functions and font drawing functions. Changing the state such
  /// as the blending modes will result in undefined behaviour. One exception to this rule are the non-projection
  /// transformations. It is possible to set a new transformation while the drawing is held.
  /// </para>
  /// <para>
  /// No drawing is guaranteed to take place until you disable the hold. Thus, the idiom of this function’s usage
  /// is to enable the deferred bitmap drawing, draw as many bitmaps as possible, taking care to stagger bitmaps
  /// that share parent bitmaps, and then disable deferred drawing. As mentioned above, this function also works
  /// with bitmap and truetype fonts, so if multiple lines of text need to be drawn, this function can speed
  /// things up.
  /// </para>
  /// </summary>
  /// <param name="hold">True to enable deferred bitmap drawing, otherwise disables it.</param>
  public static void HoldBitmapDrawing(bool hold)
  {
    Interop.Context.Core.AlHoldBitmapDrawing((byte)(hold ? 1 : 0));
  }

  /// <summary>
  /// Returns whether the deferred bitmap drawing mode is turned on or off.
  /// </summary>
  /// <returns>True if deferred bitmap drawing mode is enabled, otherwise false.</returns>
  public static bool IsBitmapDrawingHeld()
  {
    return Interop.Context.Core.AlIsBitmapDrawingHeld() != 0;
  }

  /// <summary>
  /// Register a handler for <see cref="LoadBitmap"/>. The given function will be used to handle the loading of
  /// bitmaps files with the given extension. The extension should include the leading dot (‘.’) character. It will be
  /// matched case-insensitively. The loader argument may be <c>null</c> to unregister an entry. Returns true on
  /// success, false on error. Returns false if unregistering an entry that doesn’t exist.
  /// </summary>
  /// <param name="extension">The file extension of the image file, including the leading dot '.' character.</param>
  /// <param name="loader">The method to call to load the image, or <c>null</c> to unregister a handler.</param>
  /// <returns>True on success, otherwise false.</returns>
  public static bool RegisterBitmapLoader(string extension, Delegates.BitmapLoaderDelegate? loader)
  {
    var nativeExtension = Marshal.StringToHGlobalAnsi(extension);
    var result = Interop.Context.Core.AlRegisterBitmapLoader(nativeExtension, loader);
    Marshal.FreeHGlobal(nativeExtension);
    return result != 0;
  }

  /// <summary>
  /// Register a handler for <see cref="SaveBitmap"/>. The given function will be used to handle the saving of
  /// bitmaps files with the given extension. The extension should include the leading dot (‘.’) character. It will
  /// be matched case-insensitively. The saver argument may be <c>null</c> to unregister an entry. Returns true on
  /// success, false on error. Returns false if unregistering an entry that doesn’t exist.
  /// </summary>
  /// <param name="extension">The file extension of the image file, including the leading dot '.' character.</param>
  /// <param name="saver">The method to call to save the image, or <c>null</c> to unregister a handler.</param>
  /// <returns>True on success, otherwise false.</returns>
  public static bool RegisterBitmapSaver(string extension, Delegates.BitmapSaverDelegate? saver)
  {
    var nativeExtension = Marshal.StringToHGlobalAnsi(extension);
    var result = Interop.Context.Core.AlRegisterBitmapSaver(nativeExtension, saver);
    Marshal.FreeHGlobal(nativeExtension);
    return result != 0;
  }

  /// <summary>
  /// Register a handler for <see cref="LoadBitmapF"/>. The given function will be used to handle the loading of
  /// bitmaps files with the given extension. The extension should include the leading dot (‘.’) character. It will
  /// be matched case-insensitively. The loader argument may be <c>null</c> to unregister an entry. Returns true
  /// on success, false on error. Returns false if unregistering an entry that doesn’t exist.
  /// </summary>
  /// <param name="extension">The file extension of the image file, including the leading dot '.' character.</param>
  /// <param name="loader">The method to call to load the image, or <c>null</c> to unregister a handler.</param>
  /// <returns>True on success, otherwise false.</returns>
  public static bool RegisterBitmapLoaderF(string extension, Delegates.BitmapLoaderFDelegate? loader)
  {
    var nativeExtension = Marshal.StringToHGlobalAnsi(extension);
    var result = Interop.Context.Core.AlRegisterBitmapLoaderF(nativeExtension, loader);
    Marshal.FreeHGlobal(nativeExtension);
    return result != 0;
  }

  /// <summary>
  /// Register a handler for <see cref="SaveBitmapF"/>. The given function will be used to handle the saving of bitmaps
  /// files with the given extension. The extension should include the leading dot (‘.’) character. It will be
  /// matched case-insensitively. The saver argument may be <c>null</c> to unregister an entry. Returns true on
  /// success, false on error. Returns false if unregistering an entry that doesn’t exist.
  /// </summary>
  /// <param name="extension">The file extension of the image file, including the leading dot '.' character.</param>
  /// <param name="saver">The method to call to save the image, or <c>null</c> to unregister a handler.</param>
  /// <returns>True on success, otherwise false.</returns>
  public static bool RegisterBitmapSaverF(string extension, Delegates.BitmapSaverFDelegate saver)
  {
    var nativeExtension = Marshal.StringToHGlobalAnsi(extension);
    var result = Interop.Context.Core.AlRegisterBitmapSaverF(nativeExtension, saver);
    Marshal.FreeHGlobal(nativeExtension);
    return result != 0;
  }

  /// <summary>
  /// <para>
  /// Loads an image file into a new <see cref="AllegroBitmap"/>. The file type is determined by
  /// <see cref="IdentifyBitmap"/>, using the extension as a fallback in case identification is not possible. Returns
  /// <c>null</c> on error. This is the same as <see cref="LoadBitmapFlags"/> with a flags parameter of 0.
  /// </para>
  /// <para>
  /// Note: the core Allegro library does not support any image file formats by default. You must use the
  /// image addon, or register your own format handler.
  /// </para>
  /// </summary>
  /// <param name="filename">The full or partial path to the image file.</param>
  /// <returns>The loaded bitmap instance on success, otherwise <c>null</c>.</returns>
  public static AllegroBitmap? LoadBitmap(string filename)
  {
    var nativeFilename = Marshal.StringToHGlobalAnsi(filename);
    var pointer = Interop.Context.Core.AlLoadBitmap(nativeFilename);
    Marshal.FreeHGlobal(nativeFilename);
    return NativePointer.Create<AllegroBitmap>(pointer);
  }

  /// <summary>
  /// Loads an image file into a new <see cref="AllegroBitmap"/>. The file type is determined by
  /// <see cref="IdentifyBitmap"/>, using the extension as a fallback in case identification is not possible. Returns
  /// <c>null</c> on error.
  /// </summary>
  /// <param name="filename">The full or partial path to the image file.</param>
  /// <param name="flags">The flags to use when loading the image.</param>
  /// <returns>The bitmap instance on success, otherwise <c>null</c>.</returns>
  public static AllegroBitmap? LoadBitmapFlags(string filename, LoadBitmapFlags flags)
  {
    var nativeFilename = Marshal.StringToHGlobalAnsi(filename);
    var pointer = Interop.Context.Core.AlLoadBitmapFlags(nativeFilename, (int)flags);
    Marshal.FreeHGlobal(nativeFilename);
    return NativePointer.Create<AllegroBitmap>(pointer);
  }

  /// <summary>
  /// Loads an image from an <see cref="AllegroFile"/> stream into a new <see cref="AllegroBitmap"/>. The file type
  /// is determined by <see cref="IdentifyBitmapF"/>. If identification is not possible, the passed
  /// <paramref name="identifier"/> parameter, which is a file name extension including the leading dot, is used as
  /// a fallback, if it is not <c>null</c>.
  /// </summary>
  /// <param name="file">The file instance.</param>
  /// <param name="identifier">The file extension of the image, including the leading dot.</param>
  /// <returns>The loaded bitmap instance on success, otherwise <c>null</c>.</returns>
  public static AllegroBitmap? LoadBitmapF(AllegroFile? file, string identifier)
  {
    var nativeIdentifier = Marshal.StringToHGlobalAnsi(identifier);
    var pointer = Interop.Context.Core.AlLoadBitmapF(NativePointer.Get(file), nativeIdentifier);
    Marshal.FreeHGlobal(nativeIdentifier);
    return NativePointer.Create<AllegroBitmap>(pointer);
  }

  /// <summary>
  /// <para>
  /// Loads an image from an <see cref="AllegroFile"/> stream into a new <see cref="AllegroBitmap"/>. The file type
  /// is determined by <see cref="IdentifyBitmapF"/>. If identification is not possible, the passed
  /// <paramref name="identifier"/> parameter, which is a file name extension including the leading dot, is used as
  /// a fallback, if it is not <c>null</c>. The flags parameter is the same as for <see cref="LoadBitmapFlags"/>.
  /// Returns <c>null</c> on error. The file remains open afterwards.
  /// </para>
  /// <para>
  /// Note: the core Allegro library does not support any image file formats by default. You must use the
  /// image addon, or register your own format handler.
  /// </para>
  /// </summary>
  /// <param name="file">The file instance.</param>
  /// <param name="identifier">The file extension of the image, including the leading dot.</param>
  /// <param name="flags">The flags to load the image with.</param>
  /// <returns>The loaded bitmap instance on success, otherwise <c>null</c>.</returns>
  public static AllegroBitmap? LoadBitmapFlagsF(AllegroFile? file, string identifier, LoadBitmapFlags flags)
  {
    var nativeIdentifier = Marshal.StringToHGlobalAnsi(identifier);
    var pointer = Interop.Context.Core.AlLoadBitmapFlagsF(NativePointer.Get(file), nativeIdentifier, (int)flags);
    Marshal.FreeHGlobal(nativeIdentifier);
    return NativePointer.Create<AllegroBitmap>(pointer);
  }

  /// <summary>
  /// <para>
  /// Saves an <see cref="AllegroBitmap"/> to an image file. The file type is determined by the extension. Returns
  /// true on success, false on error.
  /// </para>
  /// <para>
  /// Note: the core Allegro library does not support any image file formats by default. You must use the
  /// image addon, or register your own format handler.
  /// </para>
  /// </summary>
  /// <param name="filename">The full or partial path to the image file to save.</param>
  /// <param name="bitmap">The bitmap instance.</param>
  /// <returns>True on success, false on error.</returns>
  public static bool SaveBitmap(string filename, AllegroBitmap? bitmap)
  {
    var nativeFilename = Marshal.StringToHGlobalAnsi(filename);
    var result = Interop.Context.Core.AlSaveBitmap(nativeFilename, NativePointer.Get(bitmap));
    Marshal.FreeHGlobal(nativeFilename);
    return result != 0;
  }

  /// <summary>
  /// <para>
  /// Saves an <see cref="AllegroBitmap"/> to an <see cref="AllegroFile"/> stream. The file type is determined by
  /// the passed <paramref name="identifier"/> parameter, which is a file name extension including the leading dot.
  /// Returns true on success, false on error. The file remains open afterwards.
  /// </para>
  /// <para>
  /// Note: the core Allegro library does not support any image file formats by default. You must use the
  /// image addon, or register your own format handler.
  /// </para>
  /// </summary>
  /// <param name="file">The file instance.</param>
  /// <param name="identifier">The file extension of the image file, including the leading dot.</param>
  /// <param name="bitmap">The bitmap instance.</param>
  /// <returns>True on success, false on error.</returns>
  public static bool SaveBitmapF(AllegroFile? file, string identifier, AllegroBitmap? bitmap)
  {
    var nativeIdentifier = Marshal.StringToHGlobalAnsi(identifier);
    var result = Interop.Context.Core.AlSaveBitmapF(NativePointer.Get(file), nativeIdentifier, NativePointer.Get(bitmap));
    Marshal.FreeHGlobal(nativeIdentifier);
    return result != 0;
  }

  /// <summary>
  /// Register an identify handler for <see cref="IdentifyBitmap"/>. The given function will be used to detect files
  /// for the given extension. It will be called with a single argument of type <see cref="AllegroFile"/> which is a
  /// file handle opened for reading and located at the first byte of the file. The handler should try to read as few
  /// bytes as possible to safely determine if the given file contents correspond to the type with the extension and
  /// return true in that case, false otherwise. The file handle must not be closed but there is no need to reset
  /// it to the beginning. The extension should include the leading dot (‘.’) character. It will be matched
  /// case-insensitively. The <paramref name="identifier"/> argument may be NULL to unregister an entry. Returns
  /// true on success, false on error. Returns false if unregistering an entry that doesn’t exist.
  /// </summary>
  /// <param name="extension">The extension of the image file, including the leading dot.</param>
  /// <param name="identifier">The method used to detect files of the given file extension.</param>
  /// <returns>True on success, otherwise false.</returns>
  public static bool RegisterBitmapIdentifier(string extension, Delegates.BitmapIdentifierDelegate? identifier)
  {
    var nativeExtension = Marshal.StringToHGlobalAnsi(extension);
    var result = Interop.Context.Core.AlRegisterBitmapIdentifier(nativeExtension, identifier);
    Marshal.FreeHGlobal(nativeExtension);
    return result != 0;
  }

  /// <summary>
  /// This works exactly as <see cref="IdentifyBitmapF"/> but you specify the filename of the file for which to detect
  /// the type and not a file handle. The extension, if any, of the passed filename is not taken into account - only
  /// the file contents.
  /// </summary>
  /// <param name="filename">The full or partial path to the image file.</param>
  /// <returns>The file extension for the type, including the leading dot.</returns>
  public static string? IdentifyBitmap(string filename)
  {
    var nativeFilename = Marshal.StringToHGlobalAnsi(filename);
    var result = Interop.Context.Core.AlIdentifyBitmap(nativeFilename);
    Marshal.FreeHGlobal(nativeFilename);
    return Marshal.PtrToStringAnsi(result);
  }

  /// <summary>
  /// Tries to guess the bitmap file type of the open <see cref="AllegroFile"/> by reading the first few bytes.
  /// By default Allegro cannot recognize any file types, but calling <see cref="InitImageAddon"/> will add detection
  /// of (some of) the types it can read. You can also use <see cref="RegisterBitmapIdentifier"/> to add
  /// identification for custom file types.
  /// <para>
  /// Returns a pointer to a static string with a file extension for the type, including the leading dot. For example
  /// “.png” or “.jpg”. Returns <c>null</c> if the bitmap type cannot be determined.
  /// </para>
  /// </summary>
  /// <param name="file">The file instance.</param>
  /// <returns>The file extension for the type, including the leading dot.</returns>
  public static string? IdentifyBitmapF(AllegroFile? file)
  {
    var result = Interop.Context.Core.AlIdentifyBitmapF(NativePointer.Get(file));
    return Marshal.PtrToStringAnsi(result);
  }

  /// <summary>
  /// Set one of several render attributes; see <see cref="RenderState"/> for details. This function does nothing if
  /// the target bitmap is a memory bitmap.
  /// </summary>
  /// <param name="renderState">The render state.</param>
  /// <param name="value">The value to set.</param>
  public static void SetRenderState(RenderState renderState, int value)
  {
    Interop.Context.Core.AlSetRenderState((int)renderState, value);
  }
}