using SubC.AllegroDotNet.Enums;
using SubC.AllegroDotNet.Models;

namespace SubC.AllegroDotNet.Extensions;

/// <summary>
/// This class provides extension methods for the <see cref="AllegroSample"/> class
/// that can be used as shortcuts or object-oriented methods for Allegro.
/// </summary>
public static class AllegroSampleExtensions
{
  public static bool PlaySample(this AllegroSample? sample, float gain, float pan, float speed, PlayMode playmode, ref AllegroSampleID? retID)
  => Al.PlaySample(sample, gain, pan, speed, playmode, ref retID);

  public static bool SaveSample(this AllegroSample? sample, string filename)
    => Al.SaveSample(filename, sample);

  public static bool SaveSampleF(this AllegroSample? sample, AllegroFile? file, string identifier)
    => Al.SaveSampleF(file, identifier, sample);

  public static void DestroySample(this AllegroSample? sample)
    => Al.DestroySample(sample);

  public static ChannelConfig GetSampleChannels(this AllegroSample? sample)
    => Al.GetSampleChannels(sample);

  public static AudioDepth GetSampleDepth(this AllegroSample? sample)
    => Al.GetSampleDepth(sample);

  public static uint GetSampleFrequency(this AllegroSample? sample)
    => Al.GetSampleFrequency(sample);

  public static uint GetSampleLength(this AllegroSample? sample)
    => Al.GetSampleLength(sample);

  public static IntPtr GetSampleData(this AllegroSample? sample)
    => Al.GetSampleData(sample);

  public static AllegroSampleInstance? CreateSampleInstance(this AllegroSample? sample)
    => Al.CreateSampleInstance(sample);
}
