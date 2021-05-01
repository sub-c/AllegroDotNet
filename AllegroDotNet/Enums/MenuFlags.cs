using System;

namespace AllegroDotNet.Enums
{
    [Flags]
    public enum MenuFlags : int
    {
        Enabled = 0,
        CheckBox = 1,
        Checked = 2,
        Disabled = 4
    }
}
