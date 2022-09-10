using SubC.AllegroDotNet.Enums;
using SubC.AllegroDotNet.Models;
using System;

namespace SubC.AllegroDotNet.Extensions
{
  public static class AllegroAudioStreamExtensions
  {
    public static void DestroyAudioStream(this AllegroAudioStream? stream)
      => Al.DestroyAudioStream(stream);

    public static AllegroEventSource? GetAudioStreamEventSource(this AllegroAudioStream? stream)
      => Al.GetAudioStreamEventSource(stream);

    public static void DrainAudioStream(this AllegroAudioStream? stream)
      => Al.DrainAudioStream(stream);

    public static bool RewindAudioStream(this AllegroAudioStream? stream)
      => Al.RewindAudioStream(stream);

    public static uint GetAudioStreamFrequency(this AllegroAudioStream? stream)
      => Al.GetAudioStreamFrequency(stream);

    public static ChannelConfig GetAudioStreamChannels(this AllegroAudioStream? stream)
      => Al.GetAudioStreamChannels(stream);

    public static AudioDepth GetAudioStreamDepth(this AllegroAudioStream? stream)
      => Al.GetAudioStreamDepth(stream);

    public static uint GetAudioStreamLength(this AllegroAudioStream? stream)
      => Al.GetAudioStreamLength(stream);

    public static float GetAudioStreamSpeed(this AllegroAudioStream? stream)
      => Al.GetAudioStreamSpeed(stream);

    public static bool SetAudioStreamSpeed(this AllegroAudioStream? stream, float speed)
      => Al.SetAudioStreamSpeed(stream, speed);

    public static float GetAudioStreamGain(this AllegroAudioStream? stream)
      => Al.GetAudioStreamGain(stream);

    public static bool SetAudioStreamGain(this AllegroAudioStream? stream, float gain)
      => Al.SetAudioStreamGain(stream, gain);

    public static float GetAudioStreamPan(this AllegroAudioStream? stream)
      => Al.GetAudioStreamPan(stream);

    public static bool SetAudioStreamPan(this AllegroAudioStream? stream, float pan)
      => Al.SetAudioStreamPan(stream, pan);

    public static bool GetAudioStreamPlaying(this AllegroAudioStream? stream)
      => Al.GetAudioStreamPlaying(stream);

    public static bool SetAudioStreamPlaying(this AllegroAudioStream? stream, bool playing)
      => Al.SetAudioStreamPlaying(stream, playing);

    public static Playmode GetAudioStreamPlaymode(this AllegroAudioStream? stream)
      => Al.GetAudioStreamPlaymode(stream);

    public static bool SetAudioStreamPlaymode(this AllegroAudioStream? stream, Playmode mode)
      => Al.SetAudioStreamPlaymode(stream, mode);

    public static bool GetAudioStreamAttached(this AllegroAudioStream? stream)
      => Al.GetAudioStreamAttached(stream);

    public static bool DetachAudioStream(this AllegroAudioStream? stream)
      => Al.DetachAudioStream(stream);

    public static ulong GetAudioStreamPlayedSamples(this AllegroAudioStream? stream)
      => Al.GetAudioStreamPlayedSamples(stream);

    public static IntPtr GetAudioStreamFragment(this AllegroAudioStream? stream)
      => Al.GetAudioStreamFragment(stream);

    public static bool SetAudioStreamFragment(this AllegroAudioStream? stream, IntPtr fragment)
      => Al.SetAudioStreamFragment(stream, fragment);

    public static uint GetAudioStreamFragments(this AllegroAudioStream? stream)
      => Al.GetAudioStreamFragments(stream);

    public static uint GetAvailableAudioStreamFragments(this AllegroAudioStream? stream)
      => Al.GetAvailableAudioStreamFragments(stream);

    public static bool SeekAudioStreamSecs(this AllegroAudioStream? stream, double time)
      => Al.SeekAudioStreamSecs(stream, time);

    public static double GetAudioStreamPositionSecs(this AllegroAudioStream? stream)
      => Al.GetAudioStreamPositionSecs(stream);

    public static double GetAudioStreamLengthSecs(this AllegroAudioStream? stream)
      => Al.GetAudioStreamLengthSecs(stream);

    public static bool SetAudioStreamLoopSecs(this AllegroAudioStream? stream, double start, double end)
      => Al.SetAudioStreamLoopSecs(stream, start, end);

    public static bool AttachAudioStreamToVoice(this AllegroAudioStream? stream, AllegroVoice? voice)
      => Al.AttachAudioStreamToVoice(stream, voice);

    public static bool AttachAudioStreamToMixer(this AllegroAudioStream? stream, AllegroMixer? mixer)
      => Al.AttachAudioStreamToMixer(stream, mixer);
  }
}
