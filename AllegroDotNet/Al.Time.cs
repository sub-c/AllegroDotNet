using SubC.AllegroDotNet.Models;
using SubC.AllegroDotNet.Native.Libraries;

namespace SubC.AllegroDotNet
{
    /// <summary>
    /// Allegro game library methods.
    /// </summary>
    public static partial class Al
    {
        /// <summary>
        /// Return the number of seconds since the Allegro library was initialised. The return value is undefined
        /// if Allegro is uninitialised. The resolution depends on the used driver, but typically can be in the
        /// order of microseconds.
        /// </summary>
        /// <returns>The number of seconds since the Allegro library was initialised.</returns>
        public static double GetTime() =>
            AllegroLibrary.AlGetTime();

        /// <summary>
        /// Set timeout value of some number of seconds after the function call.
        /// <para>
        /// For compatibility with all platforms, <c>seconds</c> must be 2,147,483.647 seconds or less.
        /// </para>
        /// </summary>
        /// <param name="timeout">The timeout to initialize.</param>
        /// <param name="seconds">The seconds for the timeout after the function call.</param>
        public static void InitTimeout(ref AllegroTimeout timeout, double seconds) =>
            AllegroLibrary.AlInitTimeout(ref timeout.NativeTimeout, seconds);

        /// <summary>
        /// Waits for the specified number of seconds. This tells the system to pause the current thread for the given
        /// amount of time. With some operating systems, the accuracy can be in the order of 10ms. That is, even
        /// <para>
        /// <c>Rest(0.000001)</c>
        /// </para>
        /// <para>
        /// might pause for something like 10ms. Also see the section on Timer routines for easier ways to time your
        /// program without using up all CPU.
        /// </para>
        /// </summary>
        /// <param name="seconds">The amount of seconds to rest.</param>
        public static void Rest(double seconds) =>
            AllegroLibrary.AlRest(seconds);
    }
}
