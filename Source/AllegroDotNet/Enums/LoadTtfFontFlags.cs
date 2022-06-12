using System;

namespace SubC.AllegroDotNet.Enums
{
  [Flags]
  public enum LoadTtfFontFlags : int
  {
    None = 0,
    NoKerning = 1,
    Monochrome = 2,
    NoAutohint = 4
  }
}
