using SubC.AllegroDotNet.Enums;
using SubC.AllegroDotNet.Models;

namespace SubC.AllegroDotNet.Extensions;

/// <summary>
/// This class provides extension methods for the <see cref="AllegroSampleInstance"/> class
/// that can be used as shortcuts or object-oriented methods for Allegro.
/// </summary>
public static class AllegroSampleInstanceExtensions
{
    public static void DestroySampleInstance(this AllegroSampleInstance? instance)
        => Al.DestroySampleInstance(instance);

    public static bool PlaySampleInstance(this AllegroSampleInstance? instance)
      => Al.PlaySampleInstance(instance);

    public static bool StopSampleInstance(this AllegroSampleInstance? instance)
      => Al.StopSampleInstance(instance);

    public static ChannelConfig GetSampleInstanceChannels(this AllegroSampleInstance? instance)
      => Al.GetSampleInstanceChannels(instance);

    public static AudioDepth GetSampleInstanceDepth(this AllegroSampleInstance? instance)
      => Al.GetSampleInstanceDepth(instance);

    public static uint GetSampleInstanceFrequency(this AllegroSampleInstance? instance)
      => Al.GetSampleInstanceFrequency(instance);

    public static uint GetSampleInstanceLength(this AllegroSampleInstance? instance)
      => Al.GetSampleInstanceLength(instance);

    public static bool SetSampleInstanceLength(this AllegroSampleInstance? instance, uint length)
      => Al.SetSampleInstanceLength(instance, length);

    public static uint GetSampleInstancePosition(this AllegroSampleInstance? instance)
      => Al.GetSampleInstancePosition(instance);

    public static bool SetSampleInstancePosition(this AllegroSampleInstance? instance, uint position)
      => Al.SetSampleInstancePosition(instance, position);

    public static float GetSampleInstanceSpeed(this AllegroSampleInstance? instance)
      => Al.GetSampleInstanceSpeed(instance);

    public static bool SetSampleInstanceSpeed(this AllegroSampleInstance? instance, float speed)
      => Al.SetSampleInstanceSpeed(instance, speed);

    public static float GetSampleInstanceGain(this AllegroSampleInstance? instance)
      => Al.GetSampleInstanceGain(instance);

    public static bool SetSampleInstanceGain(this AllegroSampleInstance? instance, float gain)
      => Al.SetSampleInstanceGain(instance, gain);

    public static float GetSampleInstancePan(this AllegroSampleInstance? instance)
      => Al.GetSampleInstancePan(instance);

    public static bool SetSampleInstancePan(this AllegroSampleInstance? instance, float pan)
      => Al.SetSampleInstancePan(instance, pan);

    public static float GetSampleInstanceTime(this AllegroSampleInstance? instance)
      => Al.GetSampleInstanceTime(instance);

    public static PlayMode GetSampleInstancePlaymode(this AllegroSampleInstance? instance)
      => Al.GetSampleInstancePlaymode(instance);

    public static bool SetSampleInstancePlaymode(this AllegroSampleInstance? instance, PlayMode playmode)
      => Al.SetSampleInstancePlaymode(instance, playmode);

    public static bool GetSampleInstancePlaying(this AllegroSampleInstance? instance)
      => Al.GetSampleInstancePlaying(instance);

    public static bool SetSampleInstancePlaying(this AllegroSampleInstance? instance, bool playing)
      => Al.SetSampleInstancePlaying(instance, playing);

    public static bool GetSampleInstanceAttached(this AllegroSampleInstance? instance)
      => Al.GetSampleInstanceAttached(instance);

    public static bool DetachSampleInstance(this AllegroSampleInstance? instance)
      => Al.DetachSampleInstance(instance);

    public static AllegroSample? GetSample(this AllegroSampleInstance? instance)
      => Al.GetSample(instance);

    public static bool SetSample(this AllegroSampleInstance? instance, AllegroSample? sample)
      => Al.SetSample(instance, sample);

    public static bool AttachSampleInstanceToVoice(this AllegroSampleInstance? instance, AllegroVoice? voice)
      => Al.AttachSampleInstanceToVoice(instance, voice);

    public static bool AttachSampleInstanceToMixer(this AllegroSampleInstance? instance, AllegroMixer? mixer)
      => Al.AttachSampleInstanceToMixer(instance, mixer);
}
