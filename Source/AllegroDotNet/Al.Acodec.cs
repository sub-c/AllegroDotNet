using SubC.AllegroDotNet.Native;

namespace SubC.AllegroDotNet;

/// <summary>
/// This static class contains the Allegro 5 library methods.
/// </summary>
public static partial class Al
{
    public static bool InitACodecAddon()
    {
        return Interop.ACodec.AlInitACodecAddon() != 0;
    }

    public static bool IsACodecAddonInitialized()
    {
        return Interop.ACodec.AlIsACodecAddonInitialized() != 0;
    }

    public static uint GetAllegroACodecVersion()
    {
        return Interop.ACodec.AlGetAllegroACodecVersion();
    }
}
