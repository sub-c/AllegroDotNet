using SubC.AllegroDotNet.Models;

namespace SubC.AllegroDotNet.Extensions;

/// <summary>
/// This class provides extension methods for the <see cref="AllegroTimer"/> class
/// that can be used as shortcuts or object-oriented methods for Allegro.
/// </summary>
public static class AllegroTimerExtensions
{
    public static void StartTimer(this AllegroTimer? timer)
    => Al.StartTimer(timer);

    public static void ResumeTimer(this AllegroTimer? timer)
      => Al.ResumeTimer(timer);

    public static void StopTimer(this AllegroTimer? timer)
      => Al.StopTimer(timer);

    public static bool GetTimerStarted(this AllegroTimer? timer)
      => Al.GetTimerStarted(timer);

    public static void DestroyTimer(this AllegroTimer? timer)
      => Al.DestroyTimer(timer);

    public static long GetTimerCount(this AllegroTimer? timer)
      => Al.GetTimerCount(timer);

    public static void SetTimerCount(this AllegroTimer? timer, long newCount)
      => Al.SetTimerCount(timer, newCount);

    public static void AddTimerCount(this AllegroTimer? timer, long diff)
      => Al.AddTimerCount(timer, diff);

    public static double GetTimerSpeed(this AllegroTimer? timer)
      => Al.GetTimerSpeed(timer);

    public static void SetTimerSpeed(this AllegroTimer? timer, double newSpeedSecs)
      => Al.SetTimerSpeed(timer, newSpeedSecs);

    public static AllegroEventSource? GetTimerEventSource(this AllegroTimer? timer)
      => Al.GetTimerEventSource(timer);
}
