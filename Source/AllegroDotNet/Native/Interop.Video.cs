using System.Runtime.InteropServices;

namespace SubC.AllegroDotNet.Native;

internal static partial class Interop
{
  public static VideoContext Video => _videoContext ??= new();

  private static VideoContext? _videoContext;

  public sealed class VideoContext
  {
    #region Video Streaming Routines

    public al_init_video_addon AlInitVideoAddon { get; }
    public al_is_video_addon_initialized AlIsVideoAddonInitialized { get; }
    public al_shutdown_video_addon AlShutdownVideoAddon { get; }
    public al_get_allegro_video_version AlGetAllegroVideoVersion { get; }
    public al_open_video AlOpenVideo { get; }
    public al_identify_video AlIdentifyVideo { get; }
    public al_identify_video_f AlIdentifyVideoF { get; }
    public al_close_video AlCloseVideo { get; }
    public al_start_video AlStartVideo { get; }
    public al_start_video_with_voice AlStartVideoWithVoice { get; }
    public al_get_video_event_source AlGetVideoEventSource { get; }
    public al_set_video_playing AlSetVideoPlaying { get; }
    public al_is_video_playing AlIsVideoPlaying { get; }
    public al_get_video_audio_rate AlGetVideoAudioRate { get; }
    public al_get_video_fps AlGetVideoFps { get; }
    public al_get_video_scaled_width AlGetVideoScaledWidth { get; }
    public al_get_video_scaled_height AlGetVideoScaledHeight { get; }
    public al_get_video_frame AlGetVideoFrame { get; }
    public al_get_video_position AlGetVideoPosition { get; }
    public al_seek_video AlSeekVideo { get; }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte al_init_video_addon();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte al_is_video_addon_initialized();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_shutdown_video_addon();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate uint al_get_allegro_video_version();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_open_video(IntPtr filename);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_identify_video(IntPtr filename);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_identify_video_f(IntPtr fp);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_close_video(IntPtr video);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_start_video(IntPtr video, IntPtr mixer);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_start_video_with_voice(IntPtr video, IntPtr voice);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_video_event_source(IntPtr video);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_set_video_playing(IntPtr video, byte play);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte al_is_video_playing(IntPtr video);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate double al_get_video_audio_rate(IntPtr video);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate double al_get_video_fps(IntPtr video);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate float al_get_video_scaled_width(IntPtr video);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate float al_get_video_scaled_height(IntPtr video);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_video_frame(IntPtr video);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate double al_get_video_position(IntPtr video, int which);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte al_seek_video(IntPtr video, double pos_in_seconds);

    #endregion

    public VideoContext()
    {
      AlInitVideoAddon = LoadFunction<al_init_video_addon>();
      AlIsVideoAddonInitialized = LoadFunction<al_is_video_addon_initialized>();
      AlShutdownVideoAddon = LoadFunction<al_shutdown_video_addon>();
      AlGetAllegroVideoVersion = LoadFunction<al_get_allegro_video_version>();
      AlOpenVideo = LoadFunction<al_open_video>();
      AlIdentifyVideo = LoadFunction<al_identify_video>();
      AlIdentifyVideoF = LoadFunction<al_identify_video_f>();
      AlCloseVideo = LoadFunction<al_close_video>();
      AlStartVideo = LoadFunction<al_start_video>();
      AlStartVideoWithVoice = LoadFunction<al_start_video_with_voice>();
      AlGetVideoEventSource = LoadFunction<al_get_video_event_source>();
      AlSetVideoPlaying = LoadFunction<al_set_video_playing>();
      AlIsVideoPlaying = LoadFunction<al_is_video_playing>();
      AlGetVideoAudioRate = LoadFunction<al_get_video_audio_rate>();
      AlGetVideoFps = LoadFunction<al_get_video_fps>();
      AlGetVideoScaledWidth = LoadFunction<al_get_video_scaled_width>();
      AlGetVideoScaledHeight = LoadFunction<al_get_video_scaled_height>();
      AlGetVideoFrame = LoadFunction<al_get_video_frame>();
      AlGetVideoPosition = LoadFunction<al_get_video_position>();
      AlSeekVideo = LoadFunction<al_seek_video>();
    }
  }
}
