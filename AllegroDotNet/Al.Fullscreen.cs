using System;
using System.Runtime.InteropServices;
using SubC.AllegroDotNet.Models;
using SubC.AllegroDotNet.Native;
using SubC.AllegroDotNet.Native.Libraries;

namespace SubC.AllegroDotNet
{
    /// <summary>
    /// Allegro game library methods.
    /// </summary>
    public static partial class Al
    {
        /// <summary>
        /// Retrieves a fullscreen mode. Display parameters should not be changed between a call of
        /// <see cref="GetNumDisplayModes"/> and <see cref="GetDisplayMode(int, AllegroDisplayMode)"/>. index must
        /// be between 0 and the number returned from <see cref="GetNumDisplayModes()"/>-1. mode must be an allocated
        /// <see cref="AllegroDisplayMode"/> structure. This function will return <c>null</c> on failure, and the mode
        /// parameter that was passed in on success.
        /// </summary>
        /// <param name="index">The index of the display mode.</param>
        /// <param name="mode">The mode.</param>
        /// <returns>Null on failure, the mode parameter passed in on success.</returns>
        public static AllegroDisplayMode GetDisplayMode(int index, AllegroDisplayMode mode)
        {
            var returnedMode = AllegroLibrary.AlGetDisplayMode(index, ref mode.Native);
            return returnedMode == IntPtr.Zero ? null : new AllegroDisplayMode { Native = Marshal.PtrToStructure<NativeDisplayMode>(returnedMode) };
        }

        /// <summary>
        /// Get the number of available fullscreen display modes for the current set of display parameters.
        /// This will use the values set with <see cref="SetNewDisplayRefreshRate(int)"/>, and
        /// <see cref="SetNewDisplayFlags(Enums.DisplayFlags)"/> to find the number of modes that match. Settings the
        /// new display parameters to zero will give a list of all modes for the default driver.
        /// </summary>
        /// <returns>The number of display modes.</returns>
        public static int GetNumDisplayModes() =>
            AllegroLibrary.AlGetNumDisplayModes();
    }
}
