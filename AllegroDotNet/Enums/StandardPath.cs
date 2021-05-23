namespace SubC.AllegroDotNet.Enums
{
    public enum StandardPath : int
    {
        /// <summary>
        /// If you bundle data in a location relative to your executable, then you should use this path to locate that data. On most platforms,
        /// this is the directory that contains the executable file.
        /// <para>
        /// If called from an OS X app bundle, then this will point to the internal resource directory (&lt;bundle.app&gt;/Contents/Resources). To maintain
        /// consistency, if you put your resources into a directory called "data" beneath the executable on some other platform (like Windows), then
        /// you should also create a directory called "data" under the OS X app bundle's resource folder.
        /// </para>
        /// <para>
        /// You should not try to write to this path, as it is very likely read-only.
        ///</para>
        /// If you install your resources in some other system directory (e.g., in /usr/share or C:\ProgramData), then you are responsible for
        /// keeping track of that yourself.
        /// </summary>
        ResourcesPath = 0,

        /// <summary>
        /// Path to the directory for temporary files.
        /// </summary>
        TempPath,

        /// <summary>
        /// This is the user's home directory. You should not normally write files into this directory directly, or create any sub folders in it,
        /// without explicit permission from the user. One practical application of this path would be to use it as the starting place of a file
        /// selector in a GUI. 
        /// </summary>
        UserHomePath,

        /// <summary>
        /// This location is easily accessible by the user, and is the place to store documents and files that the user might want to later open
        /// with an external program or transfer to another place.
        ///
        /// You should not save files here unless the user expects it, usually by explicit permission.
        /// </summary>
        UserDocumentsPath,

        /// <summary>
        /// If your program saves any data that the user doesn't need to access externally, then you should place it here. This is generally the
        /// least intrusive place to store data. This path will usually not be present on the file system, so make sure to create it before writing
        /// to it. 
        /// </summary>
        UserDataPath,

        /// <summary>
        /// If you are saving configuration files (especially if the user may want to edit them outside of your program), then you should place them
        /// here. This path will usually not be present on the file system, so make sure to create it before writing to it. 
        /// </summary>
        UserSettingsPath,

        /// <summary>
        /// The full path to the executable.
        /// </summary>
        ExeNamePath,
        LastPath
    }
}
