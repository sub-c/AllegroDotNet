using SubC.AllegroDotNet.Native;

namespace SubC.AllegroDotNet;

/// <summary>
/// This static class contains the Allegro 5 library methods.
/// </summary>
public static partial class Al
{
    public static bool InitImageAddon()
    {
        return Interop.Image.AlInitImageAddon() != 0;
    }

    public static bool IsImageAddonInitialized()
    {
        return Interop.Image.AlIsImageAddonInitialized() != 0;
    }

    public static void ShutdownImageAddon()
    {
        Interop.Image.AlShutdownImageAddon();
    }

    public static uint GetAllegroImageVersion()
    {
        return Interop.Image.AlGetAllegroImageVersion();
    }
}

