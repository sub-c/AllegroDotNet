using System;

namespace SubC.AllegroDotNet.Enums
{
    [Flags]
    public enum FileChooserMode : int
    {
        /// <summary>
        /// No special options.
        /// </summary>
        None = 0,

        /// <summary>
        /// If supported by the native dialog, it will not allow entering new names, but just allow existing files
        /// to be selected. Else it is ignored. 
        /// </summary>
        FileMustExist = 1,

        /// <summary>
        /// If the native dialog system has a different dialog for saving (for example one which allows creating new
        /// directories), it is used. Else it is ignored. 
        /// </summary>
        Save = 2,

        /// <summary>
        /// If there is support for a separate dialog to select a folder instead of a file, it will be used.
        /// </summary>
        Folder = 4,

        /// <summary>
        /// If a different dialog is available for selecting pictures, it is used. Else it is ignored.
        /// </summary>
        Pictures = 8,

        /// <summary>
        /// If the platform supports it, also hidden files will be shown.
        /// </summary>
        ShowHidden = 16,

        /// <summary>
        /// If supported, allow selecting multiple files.
        /// </summary>
        Multiple = 32
    }
}
