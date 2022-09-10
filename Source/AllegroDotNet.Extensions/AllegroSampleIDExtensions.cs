using SubC.AllegroDotNet.Models;

namespace SubC.AllegroDotNet.Extensions
{
  public static class AllegroSampleIDExtensions
  {
    public static void StopSample(this AllegroSampleID? sampleID)
      => Al.StopSample(sampleID);
  }
}
