using SubC.AllegroDotNet.Enums;
using SubC.AllegroDotNet.Models;
using SubC.AllegroDotNet.Native;

namespace SubC.AllegroDotNet;

/// <summary>
/// This static class contains the Allegro 5 library methods.
/// </summary>
public static partial class Al
{
  /// <summary>
  /// Allocates and initializes a timer. If successful, a pointer to a new timer object is returned, otherwise
  /// <c>null</c> is returned. speed_secs is in seconds per “tick”, and must be positive. The new timer is initially
  /// stopped and needs to be started with <see cref="StartTimer"/> before <see cref="EventType.Timer"/> events
  /// are sent.
  /// <para>
  /// Usage note: typical granularity is on the order of microseconds, but with some drivers might only be milliseconds.
  /// </para>
  /// </summary>
  /// <param name="speedSeconds">The time in seconds for a tick.</param>
  /// <returns>An <see cref="AllegroTimer"/> instance on success, otherwise <c>null</c>.</returns>
  public static AllegroTimer? CreateTimer(double speedSeconds)
  {
    var pointer = Interop.Context.Core.AlCreateTimer(speedSeconds);
    return NativePointer.Create<AllegroTimer>(pointer);
  }

  /// <summary>
  /// Start the timer specified. From then, the timer’s counter will increment at a constant rate, and it will begin
  /// generating events. Starting a timer that is already started does nothing. Starting a timer that was stopped will
  /// reset the timer’s counter, effectively restarting the timer from the beginning.
  /// </summary>
  /// <param name="timer">An <see cref="AllegroTimer"/> instance.</param>
  public static void StartTimer(AllegroTimer? timer)
  {
    Interop.Context.Core.AlStartTimer(NativePointer.Get(timer));
  }

  /// <summary>
  /// Resume the timer specified. From then, the timer’s counter will increment at a constant rate, and it will begin
  /// generating events. Resuming a timer that is already started does nothing. Resuming a stopped timer will not reset
  /// the timer’s counter (unlike <see cref="StartTimer"/>).
  /// </summary>
  /// <param name="timer">An <see cref="AllegroTimer"/> instance.</param>
  public static void ResumeTimer(AllegroTimer? timer)
  {
    Interop.Context.Core.AlResumeTimer(NativePointer.Get(timer));
  }

  /// <summary>
  /// Stop the timer specified. The timer’s counter will stop incrementing and it will stop generating events.
  /// Stopping a timer that is already stopped does nothing.
  /// </summary>
  /// <param name="timer">An <see cref="AllegroTimer"/> instance.</param>
  public static void StopTimer(AllegroTimer? timer)
  {
    Interop.Context.Core.AlStopTimer(NativePointer.Get(timer));
  }

  /// <summary>
  /// Return true if the timer specified is currently started.
  /// </summary>
  /// <param name="timer">An <see cref="AllegroTimer"/> instance.</param>
  /// <returns>True if the timer specified is currently started, otherwise false.</returns>
  public static bool GetTimerStarted(AllegroTimer? timer)
  {
    return Interop.Context.Core.AlGetTimerStarted(NativePointer.Get(timer)) == 1;
  }

  /// <summary>
  /// Uninstall the timer specified. If the timer is started, it will automatically be stopped before uninstallation.
  /// It will also automatically unregister the timer with any event queues. Does nothing if passed the <c>null</c>
  /// pointer.
  /// </summary>
  /// <param name="timer">An <see cref="AllegroTimer"/> instance.</param>
  public static void DestroyTimer(AllegroTimer? timer)
  {
    Interop.Context.Core.AlDestroyTimer(NativePointer.Get(timer));
  }

  /// <summary>
  /// Return the timer’s counter value. The timer can be started or stopped.
  /// </summary>
  /// <param name="timer">An <see cref="AllegroTimer"/> instance.</param>
  /// <returns>The timers counter value.</returns>
  public static long GetTimerCount(AllegroTimer? timer)
  {
    return Interop.Context.Core.AlGetTimerCount(NativePointer.Get(timer));
  }

  /// <summary>
  /// Set the timer’s counter value. The timer can be started or stopped. The count value may be positive or negative,
  /// but will always be incremented by +1 at each tick.
  /// </summary>
  /// <param name="timer">An <see cref="AllegroTimer"/> instance.</param>
  /// <param name="newCount">The new counter value.</param>
  public static void SetTimerCount(AllegroTimer? timer, long newCount)
  {
    Interop.Context.Core.AlSetTimerCount(NativePointer.Get(timer), newCount);
  }

  /// <summary>
  /// Add <c>difference</c> to the timer’s counter value atomically, so no ticks are lost.
  /// </summary>
  /// <param name="timer">An <see cref="AllegroTimer"/> instance.</param>
  /// <param name="difference">The ticks to add.</param>
  public static void AddTimerCount(AllegroTimer? timer, long difference)
  {
    Interop.Context.Core.AlAddTimerCount(NativePointer.Get(timer), difference);
  }

  /// <summary>
  /// Return the timer’s speed, in seconds.
  /// </summary>
  /// <param name="timer">An <see cref="AllegroTimer"/> instance.</param>
  /// <returns>The timer's speed in seconds.</returns>
  public static double GetTimerSpeed(AllegroTimer? timer)
  {
    return Interop.Context.Core.AlGetTimerSpeed(NativePointer.Get(timer));
  }

  /// <summary>
  /// Set the timer’s speed, i.e. the rate at which its counter will be incremented when it is started.
  /// This can be done when the timer is started or stopped. If the timer is currently running, it is made to
  /// look as though the speed change occurred precisely at the last tick. <paramref name="newSpeedSeconds"/>
  /// has exactly the same meaning as with <see cref="CreateTimer"/>.
  /// </summary>
  /// <param name="timer">An <see cref="AllegroTimer"/> instance.</param>
  /// <param name="newSpeedSeconds">The timer speed in seconds.</param>
  public static void SetTimerSpeed(AllegroTimer? timer, double newSpeedSeconds)
  {
    Interop.Context.Core.AlSetTimerSpeed(NativePointer.Get(timer), newSpeedSeconds);
  }

  /// <summary>
  /// Retrieve the associated event source. Timers will generate events of type <see cref="EventType.Timer"/>.
  /// </summary>
  /// <param name="timer">An <see cref="AllegroTimer"/> instance.</param>
  /// <returns>The event source instance on success, otherwise <c>null</c>.</returns>
  public static AllegroEventSource? GetTimerEventSource(AllegroTimer? timer)
  {
    var pointer = Interop.Context.Core.AlGetTimerEventSource(NativePointer.Get(timer));
    return NativePointer.Create<AllegroEventSource>(pointer);
  }
}