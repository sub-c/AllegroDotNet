using SubC.AllegroDotNet.Native;

namespace SubC.AllegroDotNet
{
  public static partial class Al
  {
    public static bool InitAcodecAddon()
    {
      return NativeFunctions.AlInitAcodecAddon();
    }

    public static bool IsAcodecAddonInitialized()
    {
      return NativeFunctions.AlIsAcodecAddonInitialized();
    }

    public static uint GetAllegroAcodecVersion()
    {
      return NativeFunctions.AlGetAllegroAcodecVersion();
    }
  }
}
