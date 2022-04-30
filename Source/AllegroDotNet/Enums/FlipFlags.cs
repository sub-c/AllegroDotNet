using System;

namespace SubC.AllegroDotNet.Enums
{
  [Flags]
  public enum FlipFlags : int
  {
    None = 0,
    Horizontal = 0x00001,
    Vertical = 0x00002
  }
}