using SubC.AllegroDotNet.Native;
using SubC.AllegroDotNet.Native.Structs;

namespace SubC.AllegroDotNet;

/// <summary>
/// This static class contains the Allegro 5 library methods.
/// </summary>
public static partial class Al
{
  /// <summary>
  /// Return the number of seconds since the Allegro library was initialised. The return value is undefined if Allegro
  /// is uninitialised. The resolution depends on the used driver, but typically can be in the order of microseconds.
  /// </summary>
  /// <returns>The number of seconds since the Allegro library was initialized.</returns>
  public static double GetTime()
  {
    return Interop.Context.Core.AlGetTime();
  }

  /// <summary>
  /// Set timeout value of some number of seconds after the function call. For compatibility with all platforms,
  /// seconds must be 2,147,483.647 seconds or less.
  /// </summary>
  /// <param name="timeout">The timeout to initialize.</param>
  /// <param name="seconds">The seconds to set the timeout for.</param>
  public static void InitTimeout(ref AllegroTimeout timeout, double seconds)
  {
    Interop.Context.Core.AlInitTimeout(ref timeout, seconds);
  }

  /// <summary>
  /// Waits for the specified number of seconds. This tells the system to pause the current thread for the given
  /// amount of time. With some operating systems, the accuracy can be in the order of 10ms. see the section on
  /// Timer routines for easier ways to time your program without using up all CPU.
  /// </summary>
  /// <param name="seconds">The amount of seconds to wait.</param>
  public static void Rest(double seconds)
  {
    Interop.Context.Core.AlRest(seconds);
  }
}