using System;

namespace SubC.AllegroDotNet.Enums
{
  [Flags]
  public enum TextLogFlags : int
  {
    NoClose = 1 << 0,
    Monospace = 1 << 1
  }
}