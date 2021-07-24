using System;

namespace SubC.AllegroDotNet.Enums
{
    [Flags]
    public enum MenuFlags : int
    {
        NotFound = -1,
        Enabled = 0,
        CheckBox = 1,
        Checked = 2,
        Disabled = 4
    }
}
