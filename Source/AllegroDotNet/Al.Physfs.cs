using SubC.AllegroDotNet.Native;

namespace SubC.AllegroDotNet
{
  public static partial class Al
  {
    public static void SetPhysfsFileInterface()
    {
      NativeFunctions.AlSetPhysfsFileInterface();
    }

    /// <summary>
    /// Gets the compiled version of the PhysFS addon.
    /// </summary>
    /// <returns>The compiled version of the PhysFS addon, in the same format as <see cref="Al.GetAllegroVersion"/></returns>
    public static uint GetAllegroPhysfsVersion()
    {
      return NativeFunctions.AlGetAllegroPhysfsVersion();
    }
  }
}
