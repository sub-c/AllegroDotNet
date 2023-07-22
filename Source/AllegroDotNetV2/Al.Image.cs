using SubC.AllegroDotNet.Native;

namespace SubC.AllegroDotNet;

/// <summary>
/// This static class contains the Allegro 5 library methods.
/// </summary>
public static partial class Al
{
  /// <summary>
  /// <para>
  /// Initializes the image addon. This registers bitmap format handlers for
  /// <see cref="LoadBitmap"/>, <see cref="LoadBitmapF"/>, <see cref="SaveBitmap"/>, <see cref="SaveBitmapF"/>.
  /// </para>
  /// <para>
  /// The following types are built into the Allegro image addon and guaranteed to be available: BMP, DDS, PCX, TGA.
  /// Every platform also supports JPEG and PNG via external dependencies.
  /// </para>
  /// <para>
  /// Other formats may be available depending on the operating system and installed libraries, but are not
  /// guaranteed and should not be assumed to be universally available.
  /// </para>
  /// <para>
  /// The DDS format is only supported to load from, and only if the DDS file contains textures compressed in the DXT1,
  /// DXT3 and DXT5 formats. Note that when loading a DDS file, the created bitmap will always be a video bitmap and
  /// will have the pixel format matching the format in the file.
  /// </para>
  /// </summary>
  /// <returns>True on success, otherwise false.</returns>
  public static bool InitImageAddon()
  {
    return Interop.Context.Image.AlInitImageAddon() == 1;
  }

  /// <summary>
  /// Returns true if the image addon is initialized, otherwise returns false.
  /// </summary>
  /// <returns>True if the image addon is initialized, otherwise returns false.</returns>
  public static bool IsImageAddonInitialized()
  {
    return Interop.Context.Image.AlIsImageAddonInitialized() == 1;
  }

  /// <summary>
  /// Shut down the image addon. This is done automatically at program exit, but can be called any time the user
  /// wishes as well.
  /// </summary>
  public static void ShutdownImageAddon()
  {
    Interop.Context.Image.AlShutdownImageAddon();
  }

  /// <summary>
  /// Returns the (compiled) version of the addon, in the same format as <see cref="GetAllegroVersion"/>.
  /// </summary>
  /// <returns>The compiled version of the addon.</returns>
  public static uint GetAllegroImageVersion()
  {
    return Interop.Context.Image.AlGetAllegroImageVersion();
  }
}