using System;

namespace SubC.AllegroDotNet.Enums
{
  [Flags]
  public enum LoadBitmapFlags : int
  {
    None = 0,
    KeepBitmapFormat = 0x0002,
    NoPremultipliedAlpha = 0x0200,
    KeepIndex = 0x0800
  }
}