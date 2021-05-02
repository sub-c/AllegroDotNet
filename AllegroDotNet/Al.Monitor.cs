using System.Runtime.InteropServices;
using AllegroDotNet.Models;
using AllegroDotNet.Native;

namespace AllegroDotNet
{
    /// <summary>
    /// Allegro game library methods.
    /// </summary>
    public static partial class Al
    {
        /// <summary>
        /// Gets the video adapter index where new displays will be created by the calling thread, if previously set
        /// with al_set_new_display_adapter. Otherwise returns <see cref="AlConstants.AllegroDefaultDisplayAdapter"/>.
        /// </summary>
        /// <returns>
        /// Index where new displays are created by the calling thread, or
        /// <see cref="AlConstants.AllegroDefaultDisplayAdapter"/>.
        /// </returns>
        public static int GetNewDisplayAdapter()
            => al_get_new_display_adapter();

        /// <summary>
        /// Sets the adapter to use for new displays created by the calling thread. The adapter has a monitor
        /// attached to it. Information about the monitor can be gotten using
        /// al_get_num_video_adapters and al_get_monitor_info.
        /// </summary>
        /// <param name="adapter">
        /// The adapter to use for new displays, or <see cref="AlConstants.AllegroDefaultDisplayAdapter"/> to
        /// return to default behavior.
        /// </param>
        public static void SetNewDisplayAdapter(int adapter)
            => al_set_new_display_adapter(adapter);

        /// <summary>
        /// Get information about a monitor’s position on the desktop. adapter is a number from 0 to
        /// al_get_num_video_adapters()-1.
        /// <para>
        /// On Windows, use al_set_new_display_flags to switch between Direct3D and OpenGL backends, which will
        /// often have different adapters available.
        /// </para>
        /// </summary>
        /// <param name="adapter">The adapter to use for the calling thread.</param>
        /// <param name="info">The monitor info to populate.</param>
        /// <returns>Returns true on success, false on failure.</returns>
        public static bool GetMonitorInfo(int adapter, AllegroMonitorInfo info)
            => al_get_monitor_info(adapter, ref info.Native);

        /// <summary>
        /// Get the dots per inch of a monitor attached to the display adapter.
        /// </summary>
        /// <param name="adapter">The adapter index.</param>
        /// <returns>The DPI of the monitor.</returns>
        public static int GetMonitorDpi(int adapter)
            => al_get_monitor_dpi(adapter);

        /// <summary>
        /// Get the number of video “adapters” attached to the computer. Each video card attached to the computer
        /// counts as one or more adapters. An adapter is thus really a video port that can have a monitor
        /// connected to it.
        /// <para>
        /// On Windows, use al_set_new_display_flags to switch between Direct3D and OpenGL backends, which will
        /// often have different adapters available.
        /// </para>
        /// </summary>
        /// <returns>The number of video adapters.</returns>
        public static int GetNumVideoAdapters()
            => al_get_num_video_adapters();

        /// <summary>
        /// Returns the current refresh rate of a monitor attached to the display adapter.
        /// <para>
        /// Unstable API: This is an experimental feature and currently only works on Windows.
        /// </para>
        /// </summary>
        /// <param name="adapter">The adapter index.</param>
        /// <returns>The refresh rate of the monitor.</returns>
        public static int GetMonitorRefreshRate(int adapter)
            => al_get_monitor_refresh_rate(adapter);

        #region P/Invokes
        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern int al_get_new_display_adapter();

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern void al_set_new_display_adapter(int adapter);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern bool al_get_monitor_info(int adapter, ref NativeMonitorInfo info);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern int al_get_monitor_dpi(int adapter);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern int al_get_num_video_adapters();

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern int al_get_monitor_refresh_rate(int adapter);
        #endregion
    }
}
