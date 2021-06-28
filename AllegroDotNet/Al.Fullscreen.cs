using System;
using System.Runtime.InteropServices;
using SubC.AllegroDotNet.Models;
using SubC.AllegroDotNet.Native;

namespace SubC.AllegroDotNet
{
    /// <summary>
    /// Allegro game library methods.
    /// </summary>
    public static partial class Al
    {
        /// <summary>
        /// Retrieves a fullscreen mode. Display parameters should not be changed between a call of
        /// al_get_num_display_modes and al_get_display_mode. index must be between 0 and the number
        /// returned from al_get_num_display_modes-1. mode must be an allocated ALLEGRO_DISPLAY_MODE
        /// structure. This function will return NULL on failure, and the mode parameter that was passed
        /// in on success.
        /// </summary>
        /// <param name="index">The index of the display mode.</param>
        /// <param name="mode">The mode.</param>
        /// <returns>Null on failure, the mode parameter passed in on success.</returns>
        public static AllegroDisplayMode GetDisplayMode(int index, AllegroDisplayMode mode)
        {
            var returnedMode = al_get_display_mode(index, ref mode.Native);
            return returnedMode == IntPtr.Zero ? null : new AllegroDisplayMode { Native = Marshal.PtrToStructure<NativeDisplayMode>(returnedMode) };
        }

        /// <summary>
        /// Get the number of available fullscreen display modes for the current set of display parameters.
        /// This will use the values set with al_set_new_display_refresh_rate, and al_set_new_display_flags
        /// to find the number of modes that match. Settings the new display parameters to zero will give a
        /// list of all modes for the default driver.
        /// </summary>
        /// <returns>The number of display modes.</returns>
        public static int GetNumDisplayModes()
            => al_get_num_display_modes();

        #region P/Invokes
        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern IntPtr al_get_display_mode(int index, ref NativeDisplayMode mode);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern int al_get_num_display_modes();
        #endregion
    }
}
