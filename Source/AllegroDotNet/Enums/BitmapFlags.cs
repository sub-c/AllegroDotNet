using System;

namespace SubC.AllegroDotNet.Enums
{
  [Flags]
  public enum BitmapFlags : int
  {
    MemoryBitmap = 0x0001,
    ForceLocking = 0x0004,
    NoPreserveTexture = 0x0008,
    MinLinear = 0x0040,
    MagLinear = 0x0080,
    Mipmap = 0x0100,
    VideoBitmap = 0x0400,
    ConvertBitmap = 0x1000
  }
}