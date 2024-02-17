using SubC.AllegroDotNet.Enums;
using SubC.AllegroDotNet.Models;
using SubC.AllegroDotNet.Native;

namespace SubC.AllegroDotNet;

/// <summary>
/// This static class contains the Allegro 5 library methods.
/// </summary>
public static partial class Al
{
  public static bool InitVideoAddon()
  {
    return Interop.Video.AlInitVideoAddon() != 0;
  }

  public static bool IsVideoAddonInitialized()
  {
    return Interop.Video.AlIsVideoAddonInitialized() != 0;
  }

  public static void ShutdownVideoAddon()
  {
    Interop.Video.AlShutdownVideoAddon();
  }

  public static uint GetAllegroVideoVersion()
  {
    return Interop.Video.AlGetAllegroVideoVersion();
  }

  public static AllegroVideo? OpenVideo(string? filename)
  {
    using var nativeFilename = new CStringAnsi(filename);
    var pointer = Interop.Video.AlOpenVideo(nativeFilename.Pointer);
    return NativePointer.Create<AllegroVideo>(pointer);
  }

  public static string? IdentifyVideo(string? filename)
  {
    using var nativeFilename = new CStringAnsi(filename);
    var pointer = Interop.Video.AlIdentifyVideo(nativeFilename.Pointer);
    return CStringAnsi.ToCSharpString(pointer);
  }

  public static string? IdentifyVideoF(AllegroFile? file)
  {
    var pointer = Interop.Video.AlIdentifyVideoF(NativePointer.Get(file));
    return CStringAnsi.ToCSharpString(pointer);
  }

  public static void CloseVideo(AllegroVideo? video)
  {
    Interop.Video.AlCloseVideo(NativePointer.Get(video));
  }

  public static void StartVideo(AllegroVideo? video, AllegroMixer? mixer)
  {
    Interop.Video.AlStartVideo(NativePointer.Get(video), NativePointer.Get(mixer));
  }

  public static void StartVideoWithVoice(AllegroVideo? video, AllegroVoice? voice)
  {
    Interop.Video.AlStartVideoWithVoice(NativePointer.Get(video), NativePointer.Get(voice));
  }

  public static AllegroEventSource? GetVideoEventSource(AllegroVideo? video)
  {
    var pointer = Interop.Video.AlGetVideoEventSource(NativePointer.Get(video));
    return NativePointer.Create<AllegroEventSource>(pointer);
  }

  public static void SetVideoPlaying(AllegroVideo? video, bool play)
  {
    Interop.Video.AlSetVideoPlaying(NativePointer.Get(video), (byte)(play ? 1 : 0));
  }

  public static bool IsVideoPlaying(AllegroVideo? video)
  {
    return Interop.Video.AlIsVideoPlaying(NativePointer.Get(video)) != 0;
  }

  public static double GetVideoAudioRate(AllegroVideo? video)
  {
    return Interop.Video.AlGetVideoAudioRate(NativePointer.Get(video));
  }

  public static double GetVideoFps(AllegroVideo? video)
  {
    return Interop.Video.AlGetVideoFps(NativePointer.Get(video));
  }

  public static float GetVideoScaledWidth(AllegroVideo? video)
  {
    return Interop.Video.AlGetVideoScaledWidth(NativePointer.Get(video));
  }

  public static float GetVideoScaledHeight(AllegroVideo? video)
  {
    return Interop.Video.AlGetVideoScaledHeight(NativePointer.Get(video));
  }

  public static AllegroBitmap? GetVideoFrame(AllegroVideo? video)
  {
    var pointer = Interop.Video.AlGetVideoFrame(NativePointer.Get(video));
    return NativePointer.Create<AllegroBitmap>(pointer);
  }

  public static double GetVideoPosition(AllegroVideo? video, VideoPositionType position)
  {
    return Interop.Video.AlGetVideoPosition(NativePointer.Get(video), (int)position);
  }

  public static bool SeekVideo(AllegroVideo? video, double positionInSeconds)
  {
    return Interop.Video.AlSeekVideo(NativePointer.Get(video), positionInSeconds) != 0;
  }
}
