using SubC.AllegroDotNet.Enums;
using SubC.AllegroDotNet.Models;

namespace SubC.AllegroDotNet.Extensions;

/// <summary>
/// This class provides extension methods for the <see cref="AllegroBitmap"/> class
/// that can be used as shortcuts or object-oriented methods for Allegro.
/// </summary>
public static class AllegroBitmapExtensions
{
    public static AllegroLockedRegion? LockBitmap(this AllegroBitmap? bitmap, PixelFormat format, LockFlag flag)
        => Al.LockBitmap(bitmap, format, flag);

    public static AllegroLockedRegion? LockBitmapRegion(this AllegroBitmap? bitmap, int x, int y, int width, int height, PixelFormat format, LockFlag flag)
      => Al.LockBitmapRegion(bitmap, x, y, width, height, format, flag);

    public static void UnlockBitmap(this AllegroBitmap? bitmap)
      => Al.UnlockBitmap(bitmap);

    public static AllegroLockedRegion? LockBitmapBlocked(this AllegroBitmap? bitmap, LockFlag flag)
      => Al.LockBitmapBlocked(bitmap, flag);

    public static AllegroLockedRegion? LockBitmapRegionBlocked(this AllegroBitmap? bitmap, int xBlock, int yBlock, int widthBlock, int heightBlock, LockFlag flag)
      => Al.LockBitmapRegionBlocked(bitmap, xBlock, yBlock, widthBlock, heightBlock, flag);

    public static AllegroBitmap? CreateSubBitmap(this AllegroBitmap? parent, int x, int y, int width, int height)
      => Al.CreateSubBitmap(parent, x, y, width, height);

    public static AllegroBitmap? CloneBitmap(this AllegroBitmap? bitmap)
      => Al.CloneBitmap(bitmap);

    public static void ConvertBitmap(this AllegroBitmap? bitmap)
      => Al.ConvertBitmap(bitmap);

    public static void DestroyBitmap(this AllegroBitmap? bitmap)
      => Al.DestroyBitmap(bitmap);

    public static BitmapFlags GetBitmapFlags(this AllegroBitmap? bitmap)
      => Al.GetBitmapFlags(bitmap);

    public static PixelFormat GetBitmapFormat(this AllegroBitmap? bitmap)
      => Al.GetBitmapFormat(bitmap);

    public static int GetBitmapHeight(this AllegroBitmap? bitmap)
      => Al.GetBitmapHeight(bitmap);

    public static int GetBitmapWidth(this AllegroBitmap? bitmap)
      => Al.GetBitmapWidth(bitmap);

    public static AllegroColor GetPixel(this AllegroBitmap? bitmap, int x, int y)
      => Al.GetPixel(bitmap, x, y);

    public static bool IsBitmapLocked(this AllegroBitmap? bitmap)
      => Al.IsBitmapLocked(bitmap);

    public static bool IsCompatibleBitmap(this AllegroBitmap? bitmap)
      => Al.IsCompatibleBitmap(bitmap);

    public static bool IsSubBitmap(this AllegroBitmap? bitmap)
      => Al.IsSubBitmap(bitmap);

    public static AllegroBitmap? GetParentBitmap(this AllegroBitmap? bitmap)
      => Al.GetParentBitmap(bitmap);

    public static int GetBitmapX(this AllegroBitmap? bitmap)
      => Al.GetBitmapX(bitmap);

    public static int GetBitmapY(this AllegroBitmap? bitmap)
      => Al.GetBitmapY(bitmap);

    public static void ReparentBitmap(this AllegroBitmap? bitmap, AllegroBitmap? parent, int x, int y, int width, int height)
      => Al.ReparentBitmap(bitmap, parent, x, y, width, height);

    public static void DrawBitmap(this AllegroBitmap? bitmap, float dx, float dy, FlipFlags flags)
      => Al.DrawBitmap(bitmap, dx, dy, flags);

    public static void DrawTintedBitmap(this AllegroBitmap? bitmap, AllegroColor tint, float dx, float dy, FlipFlags flags)
      => Al.DrawTintedBitmap(bitmap, tint, dx, dy, flags);

    public static void DrawBitmapRegion(this AllegroBitmap? bitmap, float sx, float sy, float sw, float sh, float dx, float dy, FlipFlags flags)
      => Al.DrawBitmapRegion(bitmap, sx, sy, sw, sh, dx, dy, flags);

    public static void DrawTintedBitmapRegion(this AllegroBitmap? bitmap, AllegroColor tint, float sx, float sy, float sw, float sh, float dx, float dy, FlipFlags flags)
      => Al.DrawTintedBitmapRegion(bitmap, tint, sx, sy, sw, sh, dx, dy, flags);

    public static void DrawRotatedBitmap(this AllegroBitmap? bitmap, float cx, float cy, float dx, float dy, float angle, FlipFlags flags)
      => Al.DrawRotatedBitmap(bitmap, cx, cy, dx, dy, angle, flags);

    public static void DrawTintedRotatedBitmap(this AllegroBitmap? bitmap, AllegroColor tint, float cx, float cy, float dx, float dy, float angle, FlipFlags flags)
      => Al.DrawTintedRotatedBitmap(bitmap, tint, cx, cy, dx, dy, angle, flags);

    public static void DrawScaledRotatedBitmap(this AllegroBitmap? bitmap, float cx, float cy, float dx, float dy, float xScale, float yScale, float angle, FlipFlags flags)
      => Al.DrawScaledRotatedBitmap(bitmap, cx, cy, dx, dy, xScale, yScale, angle, flags);

    public static void DrawTintedScaledRotatedBitmap(this AllegroBitmap? bitmap, AllegroColor tint, float cx, float cy, float dx, float dy, float xScale, float yScale, float angle, FlipFlags flags)
      => Al.DrawTintedScaledRotatedBitmap(bitmap, tint, cx, cy, dx, dy, xScale, yScale, angle, flags);

    public static void DrawTintedScaledRotatedBitmapRegion(this AllegroBitmap? bitmap, float sx, float sy, float sw, float sh, AllegroColor tint, float cx, float cy, float dx, float dy, float xScale, float yScale, float angle, FlipFlags flags)
      => Al.DrawTintedScaledRotatedBitmapRegion(bitmap, sx, sy, sw, sh, tint, cx, cy, dx, dy, xScale, yScale, angle, flags);

    public static void DrawScaledBitmap(this AllegroBitmap? bitmap, float sx, float sy, float sw, float sh, float dx, float dy, float dw, float dh, FlipFlags flags)
      => Al.DrawScaledBitmap(bitmap, sx, sy, sw, sh, dx, dy, dw, dh, flags);

    public static void DrawTintedScaledBitmap(this AllegroBitmap? bitmap, AllegroColor tint, float sx, float sy, float sw, float sh, float dx, float dy, float dw, float dh, FlipFlags flags)
      => Al.DrawTintedScaledBitmap(bitmap, tint, sx, sy, sw, sh, dx, dy, dw, dh, flags);

    public static void SetTargetBitmap(this AllegroBitmap? bitmap)
      => Al.SetTargetBitmap(bitmap);

    public static void ConvertMaskToAlpha(this AllegroBitmap? bitmap, AllegroColor maskColor)
      => Al.ConvertMaskToAlpha(bitmap, maskColor);

    public static AllegroFont? GrabFontFromBitmap(this AllegroBitmap? bitmap, int rangesCount, int[] ranges)
      => Al.GrabFontFromBitmap(bitmap, rangesCount, ranges);
}
