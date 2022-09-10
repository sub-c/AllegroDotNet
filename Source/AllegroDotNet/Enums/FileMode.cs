using System;

namespace SubC.AllegroDotNet.Enums
{
  [Flags]
  public enum FileMode
  {
    ReadAccess = 1,
    WriteAccess = 1 << 1,
    UsingBinary = 1 << 2,
    Expandable = 1 << 3,
    EnableSeekToEndOfSlice = 1 << 4,
    DisableSeekToEndOfSlice = 1 << 5
  }
}
