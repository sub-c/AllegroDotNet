using System;

namespace SubC.AllegroDotNet.Enums
{
  [Flags]
  public enum MenuItem : int
  {
    Enabled = 0,
    Checkbox = 1,
    Checked = 2,
    Disabled = 4
  }
}