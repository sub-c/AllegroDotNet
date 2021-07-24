using System;

namespace SubC.AllegroDotNet.Enums
{
    /// <summary>
    /// Flags specifying how to format a message box.
    /// </summary>
    [Flags]
    public enum MessageBoxFlags : int
    {
        /// <summary>
        /// The message is a warning. This may cause a different icon (or other effects).
        /// </summary>
        Warn = 1 << 0,

        /// <summary>
        /// The message is an error.
        /// </summary>
        Error = 1 << 1,

        /// <summary>
        /// Display a cancel button alongside the “OK” button. Ignored if buttons is not NULL.
        /// </summary>
        OkCancel = 1 << 2,

        /// <summary>
        /// Display Yes/No buttons instead of the “OK” button. Ignored if buttons is not NULL.
        /// </summary>
        YesNo = 1 << 3,

        /// <summary>
        /// The message is a question. 
        /// </summary>
        Question = 1 << 4
    }
}
