using SubC.AllegroDotNet.Models;

namespace SubC.AllegroDotNet.Extensions;

/// <summary>
/// This class provides extension methods for the <see cref="AllegroSampleID"/> class
/// that can be used as shortcuts or object-oriented methods for Allegro.
/// </summary>
public static class AllegroSampleIDExtensions
{
  public static void StopSample(this ref AllegroSampleID? sampleID)
      => Al.StopSample(ref sampleID);
}
