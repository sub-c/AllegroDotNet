using SubC.AllegroDotNet.Models;
using SubC.AllegroDotNet.Native;

namespace SubC.AllegroDotNet;

/// <summary>
/// This static class contains the Allegro 5 library methods.
/// </summary>
public static partial class Al
{
    public static double USecsToSecs(double x)
    {
        return (x / 1000000.0);
    }

    public static double MSecsToSecs(double x)
    {
        return (x / 1000.0);
    }

    public static double BpsToSecs(double x)
    {
        return (1.0 / x);
    }

    public static double BpmToSecs(double x)
    {
        return (60.0 / x);
    }

    public static AllegroTimer? CreateTimer(double speedSeconds)
    {
        var pointer = Interop.Core.AlCreateTimer(speedSeconds);
        return NativePointer.Create<AllegroTimer>(pointer);
    }

    public static void StartTimer(AllegroTimer? timer)
    {
        Interop.Core.AlStartTimer(NativePointer.Get(timer));
    }

    public static void ResumeTimer(AllegroTimer? timer)
    {
        Interop.Core.AlResumeTimer(NativePointer.Get(timer));
    }

    public static void StopTimer(AllegroTimer? timer)
    {
        Interop.Core.AlStopTimer(NativePointer.Get(timer));
    }

    public static bool GetTimerStarted(AllegroTimer? timer)
    {
        return Interop.Core.AlGetTimerStarted(NativePointer.Get(timer)) != 0;
    }

    public static void DestroyTimer(AllegroTimer? timer)
    {
        Interop.Core.AlDestroyTimer(NativePointer.Get(timer));
    }

    public static long GetTimerCount(AllegroTimer? timer)
    {
        return Interop.Core.AlGetTimerCount(NativePointer.Get(timer));
    }

    public static void SetTimerCount(AllegroTimer? timer, long newCount)
    {
        Interop.Core.AlSetTimerCount(NativePointer.Get(timer), newCount);
    }

    public static void AddTimerCount(AllegroTimer? timer, long diffCount)
    {
        Interop.Core.AlAddTimerCount(NativePointer.Get(timer), diffCount);
    }

    public static double GetTimerSpeed(AllegroTimer? timer)
    {
        return Interop.Core.AlGetTimerSpeed(NativePointer.Get(timer));
    }

    public static void SetTimerSpeed(AllegroTimer? timer, double newSpeedSeconds)
    {
        Interop.Core.AlSetTimerSpeed(NativePointer.Get(timer), newSpeedSeconds);
    }

    public static AllegroEventSource? GetTimerEventSource(AllegroTimer? timer)
    {
        var pointer = Interop.Core.AlGetTimerEventSource(NativePointer.Get(timer));
        return NativePointer.Create<AllegroEventSource>(pointer);
    }
}
