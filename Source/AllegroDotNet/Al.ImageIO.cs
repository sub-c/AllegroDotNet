using SubC.AllegroDotNet.Native;

namespace SubC.AllegroDotNet
{
  public static partial class Al
  {
    public static bool InitImageAddon()
    {
      return NativeFunctions.AlInitImageAddon();
    }

    public static bool IsImageAddonInitialized()
    {
      return NativeFunctions.AlIsImageAddonInitialized();
    }

    public static void ShutdownImageAddon()
    {
      NativeFunctions.AlShutdownImageAddon();
    }

    public static uint GetAllegroImageVersion()
    {
      return NativeFunctions.AlGetAllegroImageVersion();
    }
  }
}
