namespace SubC.AllegroDotNet.Native;

/// <summary>
/// This interface defines where and how to load the Allegro 5 library.
/// </summary>
public interface IInteropProvider
{
  /// <summary>
  /// Gets the collection of filename(s) to pass to the <see cref="LoadLibrary(string)"/>
  /// method when loading the Allegro 5 library.
  /// </summary>
  IEnumerable<string> NativeLibraryFilenames { get; }

  /// <summary>
  /// This method is invoked with a filename from <see cref="NativeLibraryFilenames"/>.
  /// It is expected that this method loads that library and return a pointer to it.
  /// </summary>
  /// <param name="filename">The filename of a Allegro 5 library (ex: `allegro-5.2.dll`).</param>
  /// <returns>A pointer to the loaded library, or <see cref="IntPtr.Zero"/> if it could not be loaded.</returns>
  IntPtr LoadLibrary(string filename);

  /// <summary>
  /// This method is invoked with a library pointer returned from <see cref="LoadLibrary(string)"/>
  /// and the name of a function from the Allegro 5 library to load. It is expected that a pointer
  /// to that Allegro 5 function is returned.
  /// </summary>
  /// <param name="nativeLibrary">A pointer to a loaded Allegro 5 library.</param>
  /// <param name="functionName">The name of a Allegro 5 function (ex: `al_install_system`).</param>
  /// <returns>A pointer to the Allegro 5 function, or <see cref="IntPtr.Zero"/> if it could not be found.</returns>
  IntPtr LoadFunction(IntPtr nativeLibrary, string functionName);
}
