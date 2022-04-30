using SubC.AllegroDotNet.Models;
using SubC.AllegroDotNet.Native;

namespace SubC.AllegroDotNet
{
  public static partial class Al
  {
    public static AllegroTimer? CreateTimer(double speedSecs)
    {
      var nativeTimer = NativeFunctions.ALCreateTimer(speedSecs);
      return NativePointerModel.Create<AllegroTimer>(nativeTimer);
    }

    public static void StartTimer(AllegroTimer? timer)
    {
      NativeFunctions.AlStartTimer(NativePointerModel.GetPointer(timer));
    }

    public static void ResumeTimer(AllegroTimer? timer)
    {
      NativeFunctions.AlResumeTimer(NativePointerModel.GetPointer(timer));
    }

    public static void StopTimer(AllegroTimer? timer)
    {
      NativeFunctions.AlStopTimer(NativePointerModel.GetPointer(timer));
    }

    public static bool GetTimerStarted(AllegroTimer? timer)
    {
      return NativeFunctions.AlGetTimerStarted(NativePointerModel.GetPointer(timer));
    }

    public static void DestroyTimer(AllegroTimer? timer)
    {
      NativeFunctions.AlDestroyTimer(NativePointerModel.GetPointer(timer));
    }

    public static ulong GetTimerCount(AllegroTimer? timer)
    {
      return NativeFunctions.AlGetTimerCount(NativePointerModel.GetPointer(timer));
    }

    public static void SetTimerCount(AllegroTimer? timer, ulong newCount)
    {
      NativeFunctions.AlSetTimerCount(NativePointerModel.GetPointer(timer), newCount);
    }

    public static void AddTimerCount(AllegroTimer? timer, ulong diff)
    {
      NativeFunctions.AlAddTimerCount(NativePointerModel.GetPointer(timer), diff);
    }

    public static double GetTimerSpeed(AllegroTimer? timer)
    {
      return NativeFunctions.AlGetTimerSpeed(NativePointerModel.GetPointer(timer));
    }

    public static void SetTimerSpeed(AllegroTimer? timer, double newSpeedSecs)
    {
      NativeFunctions.AlSetTimerSpeed(NativePointerModel.GetPointer(timer), newSpeedSecs);
    }

    public static AllegroEventSource? GetTimerEventSource(AllegroTimer? timer)
    {
      var sourcePtr = NativeFunctions.AlGetTimerEventSource(NativePointerModel.GetPointer(timer));
      return NativePointerModel.Create<AllegroEventSource>(sourcePtr);
    }
  }
}