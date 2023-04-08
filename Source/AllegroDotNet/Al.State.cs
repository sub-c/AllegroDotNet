using SubC.AllegroDotNet.Enums;
using SubC.AllegroDotNet.Models;
using SubC.AllegroDotNet.Native;

namespace SubC.AllegroDotNet;

public static partial class Al
{
  /// <summary>
  /// Restores part of the state of the current thread from the given <see cref="AllegroState"/> object.
  /// </summary>
  /// <param name="state">The instance to restore the state of.</param>
  public static void RestoreState(AllegroState state)
  {
    NativeFunctions.AlRestoreState(ref state.State);
  }

  /// <summary>
  /// Stores part of the state of the current thread in the given <see cref="AllegroState"/> object.
  /// </summary>
  /// <param name="state">The instance to store the state to.</param>
  /// <param name="flags">The specific parts of the state to store.</param>
  public static void StoreState(AllegroState state, StateFlags flags)
  {
    NativeFunctions.AlStoreState(ref state.State, (int)flags);
  }

  /// <summary>
  /// Some Allegro functions will set an error number as well as returning an error code. Call this function to
  /// retrieve the last error number set for the calling thread.
  /// </summary>
  /// <returns>The error number for the calling thread.</returns>
  public static int GetErrno()
  {
    return NativeFunctions.AlGetErrno();
  }

  /// <summary>
  /// Sets the error number for the calling thread.
  /// </summary>
  /// <param name="errorNumber">The error number to set.</param>
  public static void SetErrno(int errorNumber)
  {
    NativeFunctions.AlSetErrno(errorNumber);
  }
}
