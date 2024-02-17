using SubC.AllegroDotNet.Enums;
using SubC.AllegroDotNet.Models;
using SubC.AllegroDotNet.Native;

namespace SubC.AllegroDotNet;
/// <summary>
/// This static class contains the Allegro 5 library methods.
/// </summary>
public static partial class Al
{
  public static void RestoreState(AllegroState state)
  {
    Interop.Core.AlRestoreState(ref state);
  }

  public static void StoreState(AllegroState state, StateFlags flags)
  {
    Interop.Core.AlStoreState(ref state, (int)flags);
  }

  public static int GetErrno()
  {
    return Interop.Core.AlGetErrno();
  }

  public static void SetErrno(int error)
  {
    Interop.Core.AlSetErrno(error);
  }
}
