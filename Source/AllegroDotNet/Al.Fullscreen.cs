using SubC.AllegroDotNet.Models;
using SubC.AllegroDotNet.Native;
using System.Runtime.InteropServices;

namespace SubC.AllegroDotNet;

/// <summary>
/// This static class contains the Allegro 5 library methods.
/// </summary>
public static partial class Al
{
    public static AllegroDisplayMode? GetDisplayMode(int index, ref AllegroDisplayMode mode)
    {
        var pointer = Interop.Core.AlGetDisplayMode(index, ref mode);
        return Marshal.PtrToStructure<AllegroDisplayMode>(pointer);
    }

    public static int GetNumDisplayModes()
    {
        return Interop.Core.AlGetNumDisplayModes();
    }
}
