using static SubC.AllegroDotNet.Native.NativeDelegates;

namespace SubC.AllegroDotNet.Native;

internal partial class Context
{
  internal sealed class ImageAddon
  {
    public al_init_image_addon AlInitImageAddon { get; }
    public al_is_image_addon_initialized AlIsImageAddonInitialized { get; }
    public al_shutdown_image_addon AlShutdownImageAddon { get; }
    public al_get_allegro_image_version AlGetAllegroImageVersion { get; }

    public ImageAddon()
    {
      AlInitImageAddon = Interop.LoadFunction<al_init_image_addon>();
      AlIsImageAddonInitialized = Interop.LoadFunction<al_is_image_addon_initialized>();
      AlShutdownImageAddon = Interop.LoadFunction<al_shutdown_image_addon>();
      AlGetAllegroImageVersion = Interop.LoadFunction<al_get_allegro_image_version>();
    }
  }
}