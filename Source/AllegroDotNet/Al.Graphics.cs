using SubC.AllegroDotNet.Enums;
using SubC.AllegroDotNet.Models;
using SubC.AllegroDotNet.Native;
using System.Runtime.InteropServices;

namespace SubC.AllegroDotNet;

/// <summary>
/// This static class contains the Allegro 5 library methods.
/// </summary>
public static partial class Al
{
  public static AllegroColor MapRgb(byte r, byte g, byte b)
  {
    return Interop.Core.AlMapRgb(r, g, b);
  }

  public static AllegroColor MapRgbF(float r, float g, float b)
  {
    return Interop.Core.AlMapRgbF(r, g, b);
  }

  public static AllegroColor MapRgba(byte r, byte g, byte b, byte a)
  {
    return Interop.Core.AlMapRgba(r, g, b, a);
  }
  public static AllegroColor PremulRgba(byte r, byte g, byte b, byte a)
  {
    return Interop.Core.AlPremulRgba(r, g, b, a);
  }

  public static AllegroColor MapRgbaF(float r, float g, float b, float a)
  {
    return Interop.Core.AlMapRgbaF(r, g, b, a);
  }

  public static AllegroColor PremulRgbaF(float r, float g, float b, float a)
  {
    return Interop.Core.AlPremulRgbaF(r, g, b, a);
  }

  public static void UnmapRgb(AllegroColor color, ref byte r, ref byte g, ref byte b)
  {
    Interop.Core.AlUnmapRgb(color, ref r, ref g, ref b);
  }

  public static void UnmapRgbF(AllegroColor color, ref float r, ref float g, ref float b, ref float a)
  {
    Interop.Core.AlUnmapRgbF(color, ref r, ref g, ref b);
  }

  public static void UnmapRgba(AllegroColor color, ref byte r, ref byte g, ref byte b, ref byte a)
  {
    Interop.Core.AlUnmapRgba(color, ref r, ref g, ref b, ref a);
  }

  public static void UnmapRgbaF(AllegroColor color, ref float r, ref float g, ref float b, ref float a)
  {
    Interop.Core.AlUnmapRgbaF(color, ref r, ref g, ref b, ref a);
  }

  public static int GetPixelSize(PixelFormat format)
  {
    return Interop.Core.AlGetPixelSize((int)format);
  }

  public static int GetPixelFormatBits(PixelFormat format)
  {
    return Interop.Core.AlGetPixelFormatBits((int)format);
  }

  public static int GetPixelBlockSize(PixelFormat format)
  {
    return Interop.Core.AlGetPixelBlockSize((int)format);
  }

  public static int GetPixelBlockWidth(PixelFormat format)
  {
    return Interop.Core.AlGetPixelBlockWidth((int)format);
  }

  public static int GetPixelBlockHeight(PixelFormat format)
  {
    return Interop.Core.AlGetPixelBlockHeight((int)format);
  }

  public static AllegroLockedRegion? LockBitmap(AllegroBitmap? bitmap, PixelFormat format, LockFlag lockFlag)
  {
    var pointer = Interop.Core.AlLockBitmap(NativePointer.Get(bitmap), (int)format, (int)lockFlag);
    return pointer == IntPtr.Zero
      ? null
      : Marshal.PtrToStructure<AllegroLockedRegion>(pointer);
  }

  public static AllegroLockedRegion? LockBitmapRegion(AllegroBitmap? bitmap, int x, int y, int width, int height, PixelFormat format, LockFlag lockFlag)
  {
    var pointer = Interop.Core.AlLockBitmapRegion(NativePointer.Get(bitmap), x, y, width, height, (int)format, (int)lockFlag);
    return pointer == IntPtr.Zero
      ? null
      : Marshal.PtrToStructure<AllegroLockedRegion>(pointer);
  }

  public static void UnlockBitmap(AllegroBitmap? bitmap)
  {
    Interop.Core.AlUnlockBitmap(NativePointer.Get(bitmap));
  }

  public static AllegroLockedRegion? LockBitmapBlocked(AllegroBitmap? bitmap, LockFlag lockFlag)
  {
    var pointer = Interop.Core.AlLockBitmapBlocked(NativePointer.Get(bitmap), (int)lockFlag);
    return pointer == IntPtr.Zero
      ? null
      : Marshal.PtrToStructure<AllegroLockedRegion>(pointer);
  }

  public static AllegroLockedRegion? LockBitmapRegionBlocked(
    AllegroBitmap? bitmap,
    int xBlock,
    int yBlock,
    int widthBlock,
    int heightBlock,
    LockFlag lockFlag)
  {
    var pointer = Interop.Core.AlLockBitmapRegionBlocked(
      NativePointer.Get(bitmap),
      xBlock,
      yBlock,
      widthBlock,
      heightBlock,
      (int)lockFlag);

    return pointer == IntPtr.Zero
      ? null
      : Marshal.PtrToStructure<AllegroLockedRegion>(pointer);
  }

  public static AllegroBitmap? CreateBitmap(int w, int h)
  {
    var pointer = Interop.Core.AlCreateBitmap(w, h);
    return NativePointer.Create<AllegroBitmap>(pointer);
  }

  public static AllegroBitmap? CreateSubBitmap(AllegroBitmap? bitmap, int x, int y, int w, int h)
  {
    var pointer = Interop.Core.AlCreateSubBitmap(NativePointer.Get(bitmap), x, y, w, h);
    return NativePointer.Create<AllegroBitmap>(pointer);
  }

  public static AllegroBitmap? CloneBitmap(AllegroBitmap? bitmap)
  {
    var pointer = Interop.Core.AlCloneBitmap(NativePointer.Get(bitmap));
    return NativePointer.Create<AllegroBitmap>(pointer);
  }

  public static void ConvertBitmap(AllegroBitmap? bitmap)
  {
    Interop.Core.AlConvertBitmap(NativePointer.Get(bitmap));
  }

  public static void ConvertMemoryBitmaps()
  {
    Interop.Core.AlConvertMemoryBitmaps();
  }

  public static void DestroyBitmap(AllegroBitmap? bitmap)
  {
    Interop.Core.AlDestroyBitmap(NativePointer.Get(bitmap));
  }

  public static BitmapFlags GetNewBitmapFlags()
  {
    return (BitmapFlags)Interop.Core.AlGetNewBitmapFlags();
  }

  public static PixelFormat GetNewBitmapFormat()
  {
    return (PixelFormat)Interop.Core.AlGetNewBitmapFormat();
  }

  public static void SetNewBitmapFlags(BitmapFlags flags)
  {
    Interop.Core.AlSetNewBitmapFlags((int)flags);
  }

  public static void AddNewBitmapFlag(BitmapFlags flag)
  {
    Interop.Core.AlAddNewBitmapFlag((int)flag);
  }

  public static void SetNewBitmapFormat(PixelFormat format)
  {
    Interop.Core.AlSetNewBitmapFormat((int)format);
  }

  public static BitmapFlags GetBitmapFlags(AllegroBitmap? bitmap)
  {
    return (BitmapFlags)Interop.Core.AlGetBitmapFlags(NativePointer.Get(bitmap));
  }

  public static PixelFormat GetBitmapFormat(AllegroBitmap? bitmap)
  {
    return (PixelFormat)Interop.Core.AlGetBitmapFormat(NativePointer.Get(bitmap));
  }

  public static int GetBitmapHeight(AllegroBitmap? bitmap)
  {
    return Interop.Core.AlGetBitmapHeight(NativePointer.Get(bitmap));
  }

  public static int GetBitmapWidth(AllegroBitmap? bitmap)
  {
    return Interop.Core.AlGetBitmapWidth(NativePointer.Get(bitmap));
  }

  public static AllegroColor GetPixel(AllegroBitmap? bitmap, int x, int y)
  {
    return Interop.Core.AlGetPixel(NativePointer.Get(bitmap), x, y);
  }

  public static bool IsBitmapLocked(AllegroBitmap? bitmap)
  {
    return Interop.Core.AlIsBitmapLocked(NativePointer.Get(bitmap)) != 0;
  }

  public static bool IsCompatibleBitmap(AllegroBitmap? bitmap)
  {
    return Interop.Core.AlIsCompatibleBitmap(NativePointer.Get(bitmap)) != 0;
  }

  public static bool IsSubBitmap(AllegroBitmap? bitmap)
  {
    return Interop.Core.AlIsSubBitmap(NativePointer.Get(bitmap)) != 0;
  }

  public static AllegroBitmap? GetParentBitmap(AllegroBitmap? bitmap)
  {
    var pointer = Interop.Core.AlGetParentBitmap(NativePointer.Get(bitmap));
    return NativePointer.Create<AllegroBitmap>(pointer);
  }

  public static int GetBitmapX(AllegroBitmap? bitmap)
  {
    return Interop.Core.AlGetBitmapX(NativePointer.Get(bitmap));
  }

  public static int GetBitmapY(AllegroBitmap? bitmap)
  {
    return Interop.Core.AlGetBitmapY(NativePointer.Get(bitmap));
  }

  public static void ReparentBitmap(AllegroBitmap? bitmap, AllegroBitmap? parent, int x, int y, int w, int h)
  {
    Interop.Core.AlReparentBitmap(NativePointer.Get(bitmap), NativePointer.Get(parent), x, y, w, h);
  }

  public static void ClearToColor(AllegroColor color)
  {
    Interop.Core.AlClearToColor(color);
  }

  public static void ClearDepthBuffer(float z)
  {
    Interop.Core.AlClearDepthBuffer(z);
  }

  public static void DrawBitmap(AllegroBitmap? bitmap, float dx, float dy, FlipFlags flags)
  {
    Interop.Core.AlDrawBitmap(NativePointer.Get(bitmap), dx, dy, (int)flags);
  }

  public static void DrawTintedBitmap(AllegroBitmap? bitmap, AllegroColor tint, float dx, float dy, FlipFlags flags)
  {
    Interop.Core.AlDrawTintedBitmap(NativePointer.Get(bitmap), tint, dx, dy, (int)flags);
  }

  public static void DrawBitmapRegion(AllegroBitmap? bitmap, float sx, float sy, float sw, float sh, float dx, float dy, FlipFlags flags)
  {
    Interop.Core.AlDrawBitmapRegion(NativePointer.Get(bitmap), sx, sy, sw, sh, dx, dy, (int)flags);
  }

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
    Interop.Core.AlDrawTintedBitmapRegion(NativePointer.Get(bitmap), tint, sx, sy, sw, sh, dx, dy, (int)flags);
  }

  public static void DrawPixel(float x, float y, AllegroColor color)
  {
    Interop.Core.AlDrawPixel(x, y, color);
  }

  public static void DrawRotatedBitmap(AllegroBitmap? bitmap, float cx, float cy, float dx, float dy, float angle, FlipFlags flags)
  {
    Interop.Core.AlDrawRotatedBitmap(NativePointer.Get(bitmap), cx, cy, dx, dy, angle, (int)flags);
  }

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
    Interop.Core.AlDrawTintedRotatedBitmap(NativePointer.Get(bitmap), tint, cx, cy, dx, dy, angle, (int)flags);
  }

  public static void DrawScaledRotatedBitmap(
    AllegroBitmap? bitmap,
    float cx,
    float cy,
    float dx,
    float dy,
    float xScale,
    float yScale,
    float angle,
    FlipFlags flags)
  {
    Interop.Core.AlDrawScaledRotatedBitmap(NativePointer.Get(bitmap), cx, cy, dx, dy, xScale, yScale, angle, (int)flags);
  }

  public static void DrawTintedScaledRotatedBitmap(
    AllegroBitmap? bitmap,
    AllegroColor tint,
    float cx,
    float cy,
    float dx,
    float dy,
    float xScale,
    float yScale,
    float angle,
    FlipFlags flags)
  {
    Interop.Core.AlDrawTintedScaledRotatedBitmap(NativePointer.Get(bitmap), tint, cx, cy, dx, dy, xScale, yScale, angle, (int)flags);
  }

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
    float xScale,
    float yScale,
    float angle,
    FlipFlags flags)
  {
    Interop.Core.AlDrawTintedScaledRotatedBitmapRegion(
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
      xScale,
      yScale,
      angle,
      (int)flags);
  }

  public static void DrawScaledBitmap(AllegroBitmap? bitmap, float sx, float sy, float sw, float sh, float dx, float dy, float dw, float dh, FlipFlags flags)
  {
    Interop.Core.AlDrawScaledBitmap(NativePointer.Get(bitmap), sx, sy, sw, sh, dx, dy, dw, dh, (int)flags);
  }

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
    Interop.Core.AlDrawTintedScaledBitmap(NativePointer.Get(bitmap), tint, sx, sy, sw, sh, dx, dy, sw, dh, (int)flags);
  }

  public static AllegroBitmap? GetTargetBitmap()
  {
    var pointer = Interop.Core.AlGetTargetBitmap();
    return NativePointer.Create<AllegroBitmap>(pointer);
  }

  public static void PutPixel(int x, int y, AllegroColor color)
  {
    Interop.Core.AlPutPixel(x, y, color);
  }

  public static void PutBlendedPixel(int x, int y, AllegroColor color)
  {
    Interop.Core.AlPutBlendedPixel(x, y, color);
  }

  public static void SetTargetBitmap(AllegroBitmap? bitmap)
  {
    Interop.Core.AlSetTargetBitmap(NativePointer.Get(bitmap));
  }

  public static void SetTargetBackbuffer(AllegroDisplay? display)
  {
    Interop.Core.AlSetTargetBackbuffer(NativePointer.Get(display));
  }

  public static AllegroDisplay? GetCurrentDisplay()
  {
    var pointer = Interop.Core.AlGetCurrentDisplay();
    return NativePointer.Create<AllegroDisplay>(pointer);
  }

  public static void GetBlender(out BlendOperation operation, out BlendMode source, out BlendMode destination)
  {
    int sourceInt = default;
    int destinationInt = default;
    int operationInt = default;

    Interop.Core.AlGetBlender(ref operationInt, ref sourceInt, ref destinationInt);

    operation = (BlendOperation)operationInt;
    source = (BlendMode)sourceInt;
    destination = (BlendMode)destinationInt;
  }

  public static void GetSeparateBlender(
    out BlendOperation operation,
    out BlendMode source,
    out BlendMode destination,
    out BlendOperation alphaOperation,
    out BlendMode alphaSource,
    out BlendMode alphaDestination)
  {
    int sourceInt = default;
    int destinationInt = default;
    int alphaSourceInt = default;
    int alphaDestinationInt = default;
    int operationInt = default;
    int alphaOperationInt = default;

    Interop.Core.AlGetSeparateBlender(
      ref operationInt,
      ref sourceInt,
      ref destinationInt,
      ref alphaOperationInt,
      ref alphaSourceInt,
      ref alphaDestinationInt);

    operation = (BlendOperation)operationInt;
    source = (BlendMode)sourceInt;
    destination = (BlendMode)destinationInt;
    alphaOperation = (BlendOperation)alphaOperationInt;
    alphaSource = (BlendMode)alphaSourceInt;
    alphaDestination = (BlendMode)alphaDestinationInt;
  }

  public static AllegroColor GetBlendColor()
  {
    return Interop.Core.AlGetBlendColor();
  }

  public static void SetBlender(BlendOperation operation, BlendMode source, BlendMode destination)
  {
    Interop.Core.AlSetBlender((int)operation, (int)source, (int)destination);
  }

  public static void SetSeparateBLender(
    BlendOperation operation,
    BlendMode source,
    BlendMode destination,
    BlendOperation alphaOperation,
    BlendMode alphaSource,
    BlendMode alphaDestination)
  {
    Interop.Core.AlSetSeparateBlender(
      (int)operation,
      (int)source,
      (int)destination,
      (int)alphaOperation,
      (int)alphaSource,
      (int)alphaDestination);
  }

  public static void SetBlendColor(AllegroColor color)
  {
    Interop.Core.AlSetBlendColor(color);
  }

  public static void GetClippingRectangle(out int x, out int y, out int width, out int height)
  {
    int xInt = default, yInt = default, widthInt = default, heightInt = default;

    Interop.Core.AlGetClippingRectangle(ref xInt, ref yInt, ref widthInt, ref heightInt);

    x = xInt;
    y = yInt;
    width = widthInt;
    height = heightInt;
  }

  public static void SetClippingRectangle(int x, int y, int width, int height)
  {
    Interop.Core.AlSetClippingRectangle(x, y, width, height);
  }

  public static void ResetClippingRectangle()
  {
    Interop.Core.AlResetClippingRectangle();
  }

  public static void ConvertMaskToAlpha(AllegroBitmap? bitmap, AllegroColor maskColor)
  {
    Interop.Core.AlConvertMaskToAlpha(NativePointer.Get(bitmap), maskColor);
  }

  public static void HoldBitmapDrawing(bool isHeld)
  {
    Interop.Core.AlHoldBitmapDrawing((byte)(isHeld ? 1 : 0));
  }

  public static bool IsBitmapDrawingHeld()
  {
    return Interop.Core.AlIsBitmapDrawingHeld() != 0;
  }

  public static AllegroBitmap? LoadBitmap(string? filename)
  {
    using var nativeFilename = new CStringAnsi(filename);
    var pointer = Interop.Core.AlLoadBitmap(nativeFilename.Pointer);
    return NativePointer.Create<AllegroBitmap>(pointer);
  }

  public static AllegroBitmap? LoadBitmapFlags(string? filename, LoadBitmapFlags flags)
  {
    using var nativeFilename = new CStringAnsi(filename);
    var pointer = Interop.Core.AlLoadBitmapFlags(nativeFilename.Pointer, (int)flags);
    return NativePointer.Create<AllegroBitmap>(pointer);
  }

  public static AllegroBitmap? LoadBitmapF(AllegroFile? file, string? identifier)
  {
    using var nativeIdentifier = new CStringAnsi(identifier);
    var pointer = Interop.Core.AlLoadBitmapF(NativePointer.Get(file), nativeIdentifier.Pointer);
    return NativePointer.Create<AllegroBitmap>(pointer);
  }

  public static AllegroBitmap? LoadBitmapFlagsF(AllegroFile? file, string? identifier, LoadBitmapFlags flags)
  {
    using var nativeIdentifier = new CStringAnsi(identifier);
    var pointer = Interop.Core.AlLoadBitmapFlagsF(NativePointer.Get(file), nativeIdentifier.Pointer, (int)flags);
    return NativePointer.Create<AllegroBitmap>(pointer);
  }

  public static bool SaveBitmap(string? filename, AllegroBitmap? bitmap)
  {
    using var nativeFilename = new CStringAnsi(filename);
    return Interop.Core.AlSaveBitmap(nativeFilename.Pointer, NativePointer.Get(bitmap)) != 0;
  }

  public static bool SaveBitmapF(AllegroFile? file, string? identifier, AllegroBitmap? bitmap)
  {
    using var nativeIdentifier = new CStringAnsi(identifier);
    return Interop.Core.AlSaveBitmapF(NativePointer.Get(file), nativeIdentifier.Pointer, NativePointer.Get(bitmap)) != 0;
  }

  public static void SetRenderState(AllegroRenderState state, bool value)
  {
    var nativeValue = value ? 1 : 0;
    Interop.Core.AlSetRenderState((int)state, nativeValue);
  }

  public static void SetRenderState(AllegroRenderState state, AllegroRenderFunction function)
  {
    Interop.Core.AlSetRenderState((int)state, (int)function);
  }

  public static void SetRenderState(AllegroRenderState state, AllegroWriteMaskFlags maskFlags)
  {
    Interop.Core.AlSetRenderState((int)state, (int)maskFlags);
  }

  public static void SetRenderState(AllegroRenderState state, int value)
  {
    Interop.Core.AlSetRenderState((int)state, value);
  }
}
