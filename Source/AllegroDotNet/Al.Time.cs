using SubC.AllegroDotNet.Native;

namespace SubC.AllegroDotNet;

/// <summary>
/// This static class contains the Allegro 5 library methods.
/// </summary>
public static partial class Al
{
    /// <summary>
    /// Gets the number of seconds elapsed since the Allegro library was initialized.
    /// The result is undefined if Allegro has not been initialized yet.
    /// The resolution depends on the used driver, but typically can be in the order of microseconds.
    /// </summary>
    /// <returns>Number of seconds elapsed since the Allegro library was initialized.</returns>
    public static double GetTime()
    {
        return Interop.Core.AlGetTime();
    }

    /// <summary>
    /// Waits for the specified number of seconds. This tells the system to pause the current thread
    /// for the given amount of time. With some operating systems, the accuracy can be in the order 
    /// of 10ms.
    /// </summary>
    /// <param name="seconds">The number of seconds to wait to elapse.</param>
    public static void Rest(double seconds)
    {
        Interop.Core.AlRest(seconds);
    }
}
