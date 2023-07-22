namespace SubC.AllegroDotNet.Enums;

/// <summary>
/// This enumeration holds values to indicate a desired standard folder path.
/// </summary>
public enum StandardPath : int
{
  /// <summary>
  /// If you bundle data in a location relative to your executable, then you should use this path to locate that data.
  /// On most platforms, this is the directory that contains the executable file. You should not try to write to this
  /// path, as it is very likely read-only.
  /// </summary>
  ResourcesPath = 0,
  
  /// <summary>
  /// Path to the directory for temporary files.
  /// </summary>
  TempPath,
  
  /// <summary>
  /// If your program saves any data that the user does not need to access externally, then you should place it here.
  /// This is generally the least intrusive place to store data. This path will usually not be present on the file
  /// system, so make sure to create it before writing to it. 
  /// </summary>
  UserDataPath,
  
  /// <summary>
  /// This is the user's home directory. You should not normally write files into this directory directly, or create
  /// any sub folders in it, without explicit permission from the user. One practical application of this path would
  /// be to use it as the starting place of a file selector in a GUI. 
  /// </summary>
  UserHomePath,
  
  /// <summary>
  /// If you are saving configuration files (especially if the user may want to edit them outside of your program),
  /// then you should place them here. This path will usually not be present on the file system, so make sure to
  /// create it before writing to it. 
  /// </summary>
  UserSettingsPath,
  
  /// <summary>
  /// This location is easily accessible by the user, and is the place to store documents and files that the user might
  /// want to later open with an external program or transfer to another place. You should not save files here unless
  /// the user expects it, usually by explicit permission.
  /// </summary>
  UserDocumentsPath,
  
  /// <summary>
  /// The full path to the executable.
  /// </summary>
  ExeNamePath
}