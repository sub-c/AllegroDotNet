using System;

namespace SubC.AllegroDotNet.Enums
{
    /// <summary>
    /// Menu item flags.
    /// </summary>
    [Flags]
    public enum MenuFlags : int
    {
        /// <summary>
        /// Menu item was not found.
        /// </summary>
        NotFound = -1,

        /// <summary>
        /// Menu item is enabled.
        /// </summary>
        Enabled = 0,

        /// <summary>
        /// Menu item is a checkbox.
        /// </summary>
        CheckBox = 1,

        /// <summary>
        /// Menu item is checked.
        /// </summary>
        Checked = 2,

        /// <summary>
        /// Menu item is disabled.
        /// </summary>
        Disabled = 4
    }
}
