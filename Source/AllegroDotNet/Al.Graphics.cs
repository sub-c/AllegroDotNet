using SubC.AllegroDotNet.Enums;
using SubC.AllegroDotNet.Models;
using SubC.AllegroDotNet.Native;
using System;
using System.Runtime.InteropServices;

namespace SubC.AllegroDotNet
{
  public static partial class Al
  {
    public static AllegroColor MapRgb(byte r, byte g, byte b)
    {
      return NativeFunctions.AlMapRgb(r, g, b);
    }

    public static AllegroColor MapRgbF(float r, float g, float b)
    {
      return NativeFunctions.AlMapRgbF(r, g, b);
    }

    public static AllegroColor MapRgba(byte r, byte g, byte b, byte a)
    {
      return NativeFunctions.AlMapRgba(r, g, b, a);
    }

    public static AllegroColor PremulRgba(byte r, byte g, byte b, byte a)
    {
      return NativeFunctions.AlPremulRgba(r, g, b, a);
    }

    public static AllegroColor MapRgbaF(float r, float g, float b, float a)
    {
      return NativeFunctions.AlMapRgbaF(r, g, b, a);
    }

    public static AllegroColor PremulRgbaF(float r, float g, float b, float a)
    {
      return NativeFunctions.AlPremulRgbaF(r, g, b, a);
    }

    public static void UnmapRgb(ref byte r, ref byte g, ref byte b)
    {
      NativeFunctions.AlUnmapRgb(ref r, ref g, ref b);
    }

    public static void UnmapRgbF(ref float r, ref float g, ref float b)
    {
      NativeFunctions.AlUnmapRgbF(ref r, ref g, ref b);
    }

    public static void UnmapRgba(ref byte r, ref byte g, ref byte b, ref byte a)
    {
      NativeFunctions.AlUnmapRgba(ref r, ref g, ref b, ref a);
    }

    public static void UnmapRgbaF(ref float r, ref float g, ref float b, ref float a)
    {
      NativeFunctions.AlUnmapRgbaF(ref r, ref g, ref b, ref a);
    }

    public static int GetPixelSize(PixelFormat format)
    {
      return NativeFunctions.AlGetPixelSize((int)format);
    }

    public static int GetPixelFormatBits(PixelFormat format)
    {
      return NativeFunctions.AlGetPixelFormatBits((int)format);
    }

    public static int GetPixelBlockSize(PixelFormat format)
    {
      return NativeFunctions.AlGetPixelBlockSize((int)format);
    }

    public static int GetPixelBlockWidth(PixelFormat format)
    {
      return NativeFunctions.AlGetPixelBlockWidth((int)format);
    }

    public static int GetPixelBlockHeight(PixelFormat format)
    {
      return NativeFunctions.AlGetPixelBlockHeight((int)format);
    }

    public static AllegroLockedRegion? LockBitmap(AllegroBitmap? bitmap, PixelFormat format, LockFlag flag)
    {
      var nativeStructPtr = NativeFunctions.AlLockBitmap(NativePointerModel.GetPointer(bitmap), (int)format, (int)flag);
      return nativeStructPtr == IntPtr.Zero
          ? null
          : Marshal.PtrToStructure<AllegroLockedRegion>(nativeStructPtr);
    }

    public static AllegroLockedRegion? LockBitmapRegion(
        AllegroBitmap? bitmap,
        int x,
        int y,
        int width,
        int height,
        PixelFormat format,
        LockFlag flag)
    {
      var nativeStructPtr = NativeFunctions.AlLockBitmapRegion(NativePointerModel.GetPointer(bitmap), x, y, width, height, (int)format, (int)flag);
      return nativeStructPtr == IntPtr.Zero
          ? null
          : Marshal.PtrToStructure<AllegroLockedRegion>(nativeStructPtr);
    }

    public static void UnlockBitmap(AllegroBitmap? bitmap)
    {
      NativeFunctions.AlUnlockBitmap(NativePointerModel.GetPointer(bitmap));
    }

    public static AllegroLockedRegion? LockBitmapBlocked(AllegroBitmap? bitmap, LockFlag flag)
    {
      var nativeStructPtr = NativeFunctions.AlLockBitmapBlocked(NativePointerModel.GetPointer(bitmap), (int)flag);
      return nativeStructPtr == IntPtr.Zero
          ? null
          : Marshal.PtrToStructure<AllegroLockedRegion>(nativeStructPtr);
    }

    public static AllegroLockedRegion? LockBitmapRegionBlocked(AllegroBitmap? bitmap, int xBlock, int yBlock, int widthBlock, int heightBlock, LockFlag flag)
    {
      var nativeStructPtr = NativeFunctions.AlLockBitmapRegionBlocked(NativePointerModel.GetPointer(bitmap), xBlock, yBlock, widthBlock, heightBlock, (int)flag);
      return nativeStructPtr == IntPtr.Zero
          ? null
          : Marshal.PtrToStructure<AllegroLockedRegion>(nativeStructPtr);
    }

    public static AllegroBitmap? CreateBitmap(int width, int height)
    {
      var nativeBitmap = NativeFunctions.AlCreateBitmap(width, height);
      return NativePointerModel.Create<AllegroBitmap>(nativeBitmap);
    }

    public static AllegroBitmap? CreateSubBitmap(AllegroBitmap? parent, int x, int y, int width, int height)
    {
      var nativeSubBitmap = NativeFunctions.AlCreateSubBitmap(NativePointerModel.GetPointer(parent), x, y, width, height);
      return NativePointerModel.Create<AllegroBitmap>(nativeSubBitmap);
    }

    public static AllegroBitmap? CloneBitmap(AllegroBitmap? bitmap)
    {
      var nativeCloneBitmap = NativeFunctions.AlCloneBitmap(NativePointerModel.GetPointer(bitmap));
      return NativePointerModel.Create<AllegroBitmap>(nativeCloneBitmap);
    }

    public static void ConvertBitmap(AllegroBitmap? bitmap)
    {
      NativeFunctions.AlConvertBitmap(NativePointerModel.GetPointer(bitmap));
    }

    public static void ConvertMemoryBitmap()
    {
      NativeFunctions.AlConvertMemoryBitmaps();
    }

    public static void DestroyBitmap(AllegroBitmap? bitmap)
    {
      NativeFunctions.AlDestroyBitmap(NativePointerModel.GetPointer(bitmap));
    }

    public static BitmapFlags GetNewBitmapFlags()
    {
      return (BitmapFlags)NativeFunctions.AlGetNewBitmapFlags();
    }

    public static PixelFormat GetNewBitmapFormat()
    {
      return (PixelFormat)NativeFunctions.AlGetNewBitmapFormat();
    }

    public static void SetNewBitmapFlags(BitmapFlags flags)
    {
      NativeFunctions.AlSetNewBitmapFlags((int)flags);
    }

    public static void AddNewBitmapFlag(BitmapFlags flag)
    {
      NativeFunctions.AlAddNewBitmapFlag((int)flag);
    }

    public static void SetNewBitmapFormat(PixelFormat format)
    {
      NativeFunctions.AlSetNewBitmapFormat((int)format);
    }

    public static BitmapFlags GetBitmapFlags(AllegroBitmap? bitmap)
    {
      return (BitmapFlags)NativeFunctions.AlGetBitmapFlags(NativePointerModel.GetPointer(bitmap));
    }

    public static PixelFormat GetBitmapFormat(AllegroBitmap? bitmap)
    {
      return (PixelFormat)NativeFunctions.AlGetBitmapFormat(NativePointerModel.GetPointer(bitmap));
    }

    public static int GetBitmapHeight(AllegroBitmap? bitmap)
    {
      return NativeFunctions.AlGetBitmapHeight(NativePointerModel.GetPointer(bitmap));
    }

    public static int GetBitmapWidth(AllegroBitmap? bitmap)
    {
      return NativeFunctions.AlGetBitmapWidth(NativePointerModel.GetPointer(bitmap));
    }

    public static AllegroColor GetPixel(AllegroBitmap? bitmap, int x, int y)
    {
      return NativeFunctions.AlGetPixel(NativePointerModel.GetPointer(bitmap), x, y);
    }

    public static bool IsBitmapLocked(AllegroBitmap? bitmap)
    {
      return NativeFunctions.AlIsBitmapLocked(NativePointerModel.GetPointer(bitmap));
    }

    public static bool IsCompatibleBitmap(AllegroBitmap? bitmap)
    {
      return NativeFunctions.AlIsCompatibleBitmap(NativePointerModel.GetPointer(bitmap));
    }

    public static bool IsSubBitmap(AllegroBitmap? bitmap)
    {
      return NativeFunctions.AlIsSubBitmap(NativePointerModel.GetPointer(bitmap));
    }

    public static AllegroBitmap? GetParentBitmap(AllegroBitmap? bitmap)
    {
      var nativeBitmap = NativeFunctions.AlGetParentBitmap(NativePointerModel.GetPointer(bitmap));
      return NativePointerModel.Create<AllegroBitmap>(nativeBitmap);
    }

    public static int GetBitmapX(AllegroBitmap? bitmap)
    {
      return NativeFunctions.AlGetBitmapX(NativePointerModel.GetPointer(bitmap));
    }

    public static int GetBitmapY(AllegroBitmap? bitmap)
    {
      return NativeFunctions.AlGetBitmapY(NativePointerModel.GetPointer(bitmap));
    }

    public static void ReparentBitmap(AllegroBitmap? bitmap, AllegroBitmap? parent, int x, int y, int width, int height)
    {
      NativeFunctions.AlReparentBitmap(NativePointerModel.GetPointer(bitmap), NativePointerModel.GetPointer(parent), x, y, width, height);
    }

    public static void ClearToColor(AllegroColor color)
    {
      NativeFunctions.AlClearToColor(color);
    }

    public static void ClearDepthBuffer(float z)
    {
      NativeFunctions.AlClearDepthBuffer(z);
    }

    public static void DrawBitmap(AllegroBitmap? bitmap, float dx, float dy, FlipFlags flags)
    {
      NativeFunctions.AlDrawBitmap(NativePointerModel.GetPointer(bitmap), dx, dy, (int)flags);
    }

    public static void DrawTintedBitmap(AllegroBitmap? bitmap, AllegroColor tint, float dx, float dy, FlipFlags flags)
    {
      NativeFunctions.AlDrawTintedBitmap(NativePointerModel.GetPointer(bitmap), tint, dx, dy, (int)flags);
    }

    public static void DrawBitmapRegion(AllegroBitmap? bitmap, float sx, float sy, float sw, float sh, float dx, float dy, FlipFlags flags)
    {
      NativeFunctions.AlDrawBitmapRegion(NativePointerModel.GetPointer(bitmap), sx, sy, sw, sh, dx, dy, (int)flags);
    }

    public static void DrawTintedBitmapRegion(AllegroBitmap? bitmap, AllegroColor tint, float sx, float sy, float sw, float sh, float dx, float dy, FlipFlags flags)
    {
      NativeFunctions.AlDrawTintedBitmapRegion(NativePointerModel.GetPointer(bitmap), tint, sx, sy, sw, sh, dx, dy, (int)flags);
    }

    public static void DrawPixel(float x, float y, AllegroColor color)
    {
      NativeFunctions.AlDrawPixel(x, y, color);
    }

    public static void DrawRotatedBitmap(AllegroBitmap? bitmap, float cx, float cy, float dx, float dy, float angle, FlipFlags flags)
    {
      NativeFunctions.AlDrawRotatedBitmap(NativePointerModel.GetPointer(bitmap), cx, cy, dx, dy, angle, (int)flags);
    }

    public static void DrawTintedRotatedBitmap(AllegroBitmap? bitmap, AllegroColor tint, float cx, float cy, float dx, float dy, float angle, FlipFlags flags)
    {
      NativeFunctions.AlDrawTintedRotatedBitmap(NativePointerModel.GetPointer(bitmap), tint, cx, cy, dx, dy, angle, (int)flags);
    }

    public static void DrawScaledRotatedBitmap(AllegroBitmap? bitmap, float cx, float cy, float dx, float dy, float xScale, float yScale, float angle, FlipFlags flags)
    {
      NativeFunctions.AlDrawScaledRotatedBitmap(NativePointerModel.GetPointer(bitmap), cx, cy, dx, dy, xScale, yScale, angle, (int)flags);
    }

    public static void DrawTintedScaledRotatedBitmap(AllegroBitmap? bitmap, AllegroColor tint, float cx, float cy, float dx, float dy, float xScale, float yScale, float angle, FlipFlags flags)
    {
      NativeFunctions.AlDrawTintedScaledRotatedBitmap(NativePointerModel.GetPointer(bitmap), tint, cx, cy, dx, dy, xScale, yScale, angle, (int)flags);
    }

    public static void DrawTintedScaledRotatedBitmapRegion(AllegroBitmap? bitmap, float sx, float sy, float sw, float sh, AllegroColor tint, float cx, float cy, float dx, float dy, float xScale, float yScale, float angle, FlipFlags flags)
    {
      NativeFunctions.AlDrawTintedScaledRotatedBitmapRegion(NativePointerModel.GetPointer(bitmap), sx, sy, sw, sh, tint, cx, cy, dx, dy, xScale, yScale, angle, (int)flags);
    }

    public static void DrawScaledBitmap(AllegroBitmap? bitmap, float sx, float sy, float sw, float sh, float dx, float dy, float dw, float dh, FlipFlags flags)
    {
      NativeFunctions.AlDrawScaledBitmap(NativePointerModel.GetPointer(bitmap), sx, sy, sw, sh, dx, dy, dw, dh, (int)flags);
    }

    public static void DrawTintedScaledBitmap(AllegroBitmap? bitmap, AllegroColor tint, float sx, float sy, float sw, float sh, float dx, float dy, float dw, float dh, FlipFlags flags)
    {
      NativeFunctions.AlDrawTintedScaledBitmap(NativePointerModel.GetPointer(bitmap), tint, sx, sy, sw, sh, dx, dy, dw, dh, (int)flags);
    }

    public static AllegroBitmap? GetTargetBitmap()
    {
      var nativeBitmap = NativeFunctions.AlGetTargetBitmap();
      return NativePointerModel.Create<AllegroBitmap>(nativeBitmap);
    }

    public static void PutPixel(int x, int y, AllegroColor color)
    {
      NativeFunctions.AlPutPixel(x, y, color);
    }

    public static void PutBlendedPixel(int x, int y, AllegroColor color)
    {
      NativeFunctions.AlPutBlendedPixel(x, y, color);
    }

    public static void SetTargetBitmap(AllegroBitmap? bitmap)
    {
      NativeFunctions.AlSetTargetBitmap(NativePointerModel.GetPointer(bitmap));
    }

    public static void SetTargetBackbuffer(AllegroDisplay? display)
    {
      NativeFunctions.AlSetTargetBackbuffer(NativePointerModel.GetPointer(display));
    }

    public static AllegroDisplay? GetCurrentDisplay()
    {
      var nativeDisplay = NativeFunctions.AlGetCurrentDisplay();
      return NativePointerModel.Create<AllegroDisplay>(nativeDisplay);
    }

    public static void GetBlender(ref int op, ref int src, ref int dst)
    {
      NativeFunctions.AlGetBlender(ref op, ref src, ref dst);
    }

    public static void GetSeparateBlender(ref int op, ref int src, ref int dst, ref int alphaOp, ref int alphaSrc, ref int alphaDst)
    {
      NativeFunctions.AlGetSeparateBlender(ref op, ref src, ref dst, ref alphaOp, ref alphaSrc, ref alphaDst);
    }

    public static AllegroColor GetBlendColor()
    {
      return NativeFunctions.AlGetBlendColor();
    }

    public static void SetBlender(int op, int src, int dst)
    {
      NativeFunctions.AlSetBlender(op, src, dst);
    }

    public static void SetSeparateBlender(int op, int src, int dst, int alphaOp, int alphaSrc, int alphaDst)
    {
      NativeFunctions.AlSetSeparateBlender(op, src, dst, alphaOp, alphaSrc, alphaDst);
    }

    public static void SetBlendColor(AllegroColor color)
    {
      NativeFunctions.AlSetBlendColor(color);
    }

    public static void GetClippingRectangle(ref int x, ref int y, ref int width, ref int height)
    {
      NativeFunctions.AlGetClippingRectangle(ref x, ref y, ref width, ref height);
    }

    public static void SetClippingRectangle(int x, int y, int width, int height)
    {
      NativeFunctions.AlSetClippingRectangle(x, y, width, height);
    }

    public static void ResetClippingRectangle()
    {
      NativeFunctions.AlResetClippingRectangle();
    }

    public static void ConvertMaskToAlpha(AllegroBitmap? bitmap, AllegroColor maskColor)
    {
      NativeFunctions.AlConvertMaskToAlpha(NativePointerModel.GetPointer(bitmap), maskColor);
    }

    public static void HoldBitmapDrawing(bool hold)
    {
      NativeFunctions.AlHoldBitmapDrawing(hold);
    }

    public static bool IsBitmapDrawingHeld()
    {
      return NativeFunctions.AlIsBitmapDrawingHeld();
    }

    public static bool RegisterBitmapLoader(string extension, NativeDelegates.RegisterBitmapLoader loader)
    {
      var nativeExtension = Marshal.StringToHGlobalAnsi(extension);
      var result = NativeFunctions.AlRegisterBitmapLoader(nativeExtension, loader);
      Marshal.FreeHGlobal(nativeExtension);
      return result;
    }

    public static bool RegisterBitmapSaver(string extension, NativeDelegates.RegisterBitmapSaver saver)
    {
      var nativeExtension = Marshal.StringToHGlobalAnsi(extension);
      var result = NativeFunctions.AlRegisterBitmapSaver(nativeExtension, saver);
      Marshal.FreeHGlobal(nativeExtension);
      return result;
    }

    public static bool RegisterBitmapLoaderF(string extension, NativeDelegates.RegisterBitmapLoaderF fsLoader)
    {
      var nativeExtension = Marshal.StringToHGlobalAnsi(extension);
      var result = NativeFunctions.AlRegisterBitmapLoaderF(nativeExtension, fsLoader);
      Marshal.FreeHGlobal(nativeExtension);
      return result;
    }

    public static bool RegisterBitmapSaverF(string extension, NativeDelegates.RegisterBitmapSaverF fsSaver)
    {
      var nativeExtension = Marshal.StringToHGlobalAnsi(extension);
      var result = NativeFunctions.AlRegisterBitmapSaverF(nativeExtension, fsSaver);
      Marshal.FreeHGlobal(nativeExtension);
      return result;
    }

    public static AllegroBitmap? LoadBitmap(string filename)
    {
      var nativeFilename = Marshal.StringToHGlobalAnsi(filename);
      var nativeBitmap = NativeFunctions.AlLoadBitmap(nativeFilename);
      Marshal.FreeHGlobal(nativeFilename);
      return NativePointerModel.Create<AllegroBitmap>(nativeBitmap);
    }

    public static AllegroBitmap? LoadBitmapFlags(string filename, LoadBitmapFlags flags)
    {
      var nativeFilename = Marshal.StringToHGlobalAnsi(filename);
      var nativeBitmap = NativeFunctions.AlLoadBitmapFlags(nativeFilename, (int)flags);
      Marshal.FreeHGlobal(nativeFilename);
      return NativePointerModel.Create<AllegroBitmap>(nativeBitmap);
    }

    public static AllegroBitmap? LoadBitmapF(AllegroFile? file, string ident)
    {
      var nativeIdent = Marshal.StringToHGlobalAnsi(ident);
      var nativeBitmap = NativeFunctions.AlLoadBitmapF(NativePointerModel.GetPointer(file), nativeIdent);
      Marshal.FreeHGlobal(nativeIdent);
      return NativePointerModel.Create<AllegroBitmap>(nativeBitmap);
    }

    public static AllegroBitmap? LoadBitmapFlagsF(AllegroFile? file, string ident, LoadBitmapFlags flags)
    {
      var nativeIdent = Marshal.StringToHGlobalAnsi(ident);
      var nativeBitmap = NativeFunctions.AlLoadBitmapFlagsF(NativePointerModel.GetPointer(file), nativeIdent, (int)flags);
      Marshal.FreeHGlobal(nativeIdent);
      return NativePointerModel.Create<AllegroBitmap>(nativeBitmap);
    }

    public static bool SaveBitmap(string filename, AllegroBitmap? bitmap)
    {
      var nativeFilename = Marshal.StringToHGlobalAnsi(filename);
      var result = NativeFunctions.AlSaveBitmap(nativeFilename, NativePointerModel.GetPointer(bitmap));
      Marshal.FreeHGlobal(nativeFilename);
      return result;
    }

    public static bool SaveBitmapF(AllegroFile file, string ident, AllegroBitmap? bitmap)
    {
      var nativeIdent = Marshal.StringToHGlobalAnsi(ident);
      var result = NativeFunctions.AlSaveBitmapF(file.NativePointer, nativeIdent, NativePointerModel.GetPointer(bitmap));
      Marshal.FreeHGlobal(nativeIdent);
      return result;
    }

    public static bool RegisterBitmapIdentifier(string extension, NativeDelegates.RegisterBitmapIdentifier identifier)
    {
      var nativeExtension = Marshal.StringToHGlobalAnsi(extension);
      var result = NativeFunctions.AlRegisterBitmapIdentifier(nativeExtension, identifier);
      Marshal.FreeHGlobal(nativeExtension);
      return result;
    }

    public static string? IdentifyBitmap(string filename)
    {
      var nativeFilename = Marshal.StringToHGlobalAnsi(filename);
      var nativeResult = NativeFunctions.AlIdentifyBitmap(nativeFilename);
      Marshal.FreeHGlobal(nativeFilename);
      return Marshal.PtrToStringAnsi(nativeResult);
    }

    public static string? IdentifyBitmapF(AllegroFile? file)
    {
      var nativeResult = NativeFunctions.AlIdentifyBitmapF(NativePointerModel.GetPointer(file));
      return Marshal.PtrToStringAnsi(nativeResult);
    }

    public static void SetRenderState(RenderState state, int value)
    {
      NativeFunctions.AlSetRenderState((int)state, value);
    }
  }
}