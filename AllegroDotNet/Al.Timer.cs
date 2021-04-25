using System;
using System.Runtime.InteropServices;
using AllegroDotNet.Models;
using AllegroDotNet.Enums;

namespace AllegroDotNet
{
    /// <summary>
    /// Allegro game library methods.
    /// </summary>
    public static partial class Al
    {
        /// <summary>
        /// Allocates and initializes a timer. If successful, a pointer to a new timer object is returned, otherwise
        /// null is returned. <c>speedSecs</c> is in seconds per "tick", and must be positive. The new timer is
        /// initially stopped.
        /// </summary>
        /// <param name="speedSecs">The amount of seconds per tick.</param>
        /// <returns>A new <see cref="AllegroTimer"/> instance, or null if it fails.</returns>
        public static AllegroTimer CreateTimer(double speedSecs)
        {
            var nativeTimer = al_create_timer(speedSecs);
            return nativeTimer == IntPtr.Zero ? null : new AllegroTimer { NativeIntPtr = nativeTimer };
        }

        /// <summary>
        /// Start the timer specified. From then, the timer's counter will increment at a constant rate, and it will
        /// begin generating events. Starting a timer that is already started does nothing. Starting a timer that was
        /// stopped will reset the timer's counter, effectively restarting the timer from the beginning.
        /// </summary>
        /// <param name="timer">The timer to start.</param>
        public static void StartTimer(AllegroTimer timer)
            => al_start_timer(timer.NativeIntPtr);

        /// <summary>
        /// Resume the timer specified. From then, the timer's counter will increment at a constant rate, and it will
        /// begin generating events. Resuming a timer that is already started does nothing. Resuming a stopped timer
        /// will not reset the timer's counter (unlike <see cref="StartTimer(AllegroTimer)"/>).
        /// </summary>
        /// <param name="timer">The timer to resume.</param>
        public static void ResumeTimer(AllegroTimer timer)
            => al_resume_timer(timer.NativeIntPtr);

        /// <summary>
        /// Stop the timer specified. The timer's counter will stop incrementing and it will stop generating events.
        /// Stopping a timer that is already stopped does nothing.
        /// </summary>
        /// <param name="timer">The timer to stop.</param>
        public static void StopTimer(AllegroTimer timer)
            => al_stop_timer(timer.NativeIntPtr);

        /// <summary>
        /// Return true if the timer specified is currently started.
        /// </summary>
        /// <param name="timer">The timer to check if started.</param>
        /// <returns>True if the timer specified is currently started, otherwise false.</returns>
        public static bool GetTimerStarted(AllegroTimer timer)
            => al_get_timer_started(timer.NativeIntPtr);

        /// <summary>
        /// Uninstall the timer specified. If the timer is started, it will automatically be stopped
        /// before uninstallation. It will also automatically unregister the timer with any event queues.
        /// <para>
        /// Does nothing if passed a <c>null</c> pointer.
        /// </para>
        /// </summary>
        /// <param name="timer">The timer to destroy.</param>
        public static void DestroyTimer(AllegroTimer timer)
            => al_destroy_timer(timer.NativeIntPtr);

        /// <summary>
        /// Return the timer's counter value. The timer can be started or stopped.
        /// </summary>
        /// <param name="timer">The timer to get the counter value of.</param>
        /// <returns>The current count of the timer.</returns>
        public static long GetTimerCount(AllegroTimer timer)
            => al_get_timer_count(timer.NativeIntPtr);

        /// <summary>
        /// Set the timer's counter value. The timer can be started or stopped. The count value may be positive
        /// or negative, but will always be incremented by +1 at each tick.
        /// </summary>
        /// <param name="timer">The timer to set.</param>
        /// <param name="newCount">The new count for the timer.</param>
        public static void SetTimerCount(AllegroTimer timer, long newCount)
            => al_set_timer_count(timer.NativeIntPtr, newCount);

        /// <summary>
        /// Add diff to the timer's counter value. This is similar to:
        /// <para>
        /// <c>SetTimerCount(timer, GetTimerCount(timer) + diff)</c>
        /// </para>
        /// <para>
        /// except that the addition is performed atomically, so no ticks will be lost.
        /// </para>
        /// </summary>
        /// <param name="timer">The timer to add counts to.</param>
        /// <param name="diff">The amount of counts to add.</param>
        public static void AddTimerCount(AllegroTimer timer, long diff)
            => al_add_timer_count(timer.NativeIntPtr, diff);

        /// <summary>
        /// Return the timer's speed, in seconds (The same value passed to
        /// <see cref="CreateTimer(double)"/> or <see cref="SetTimerSpeed(AllegroTimer, double)"/>).
        /// </summary>
        /// <param name="timer">The timer to get the speed of.</param>
        /// <returns>The speed in seconds of the timer.</returns>
        public static double GetTimerSpeed(AllegroTimer timer)
            => al_get_timer_speed(timer.NativeIntPtr);

        /// <summary>
        /// Set the timer's speed, i.e. the rate at which its counter will be incremented when it is started.
        /// This can be done when the timer is started or stopped. If the timer is currently running, it is made
        /// to look as though the speed change occurred precisely at the last tick.
        /// </summary>
        /// <param name="timer">The timer to set the speed of.</param>
        /// <param name="newSpeedSecs">The new speed in seconds.</param>
        public static void SetTimerSpeed(AllegroTimer timer, double newSpeedSecs)
            => al_set_timer_speed(timer.NativeIntPtr, newSpeedSecs);

        /// <summary>
        /// Retrieve the associated event source. Timers will generate events of type <see cref="EventType.Timer"/>.
        /// </summary>
        /// <param name="timer">The timer to get the event source of.</param>
        /// <returns>The timer's event source.</returns>
        public static AllegroEventSource GetTimerEventSource(AllegroTimer timer)
        {
            var nativeEventSource = al_get_timer_event_source(timer.NativeIntPtr);
            return nativeEventSource == IntPtr.Zero ? null : new AllegroEventSource { NativeIntPtr = nativeEventSource };
        }

        #region P/Invokes
        [DllImport(AlConstants.AllegroCoreDllFilename)]
        private static extern IntPtr al_create_timer(double speedSecs);

        [DllImport(AlConstants.AllegroCoreDllFilename)]
        private static extern void al_start_timer(IntPtr timer);

        [DllImport(AlConstants.AllegroCoreDllFilename)]
        private static extern void al_resume_timer(IntPtr timer);

        [DllImport(AlConstants.AllegroCoreDllFilename)]
        private static extern void al_stop_timer(IntPtr timer);

        [DllImport(AlConstants.AllegroCoreDllFilename)]
        private static extern bool al_get_timer_started(IntPtr timer);

        [DllImport(AlConstants.AllegroCoreDllFilename)]
        private static extern void al_destroy_timer(IntPtr timer);

        [DllImport(AlConstants.AllegroCoreDllFilename)]
        private static extern long al_get_timer_count(IntPtr timer);

        [DllImport(AlConstants.AllegroCoreDllFilename)]
        private static extern void al_set_timer_count(IntPtr timer, long newCount);

        [DllImport(AlConstants.AllegroCoreDllFilename)]
        private static extern void al_add_timer_count(IntPtr timer, long diff);

        [DllImport(AlConstants.AllegroCoreDllFilename)]
        private static extern double al_get_timer_speed(IntPtr timer);

        [DllImport(AlConstants.AllegroCoreDllFilename)]
        private static extern void al_set_timer_speed(IntPtr timer, double newSpeedSecs);

        [DllImport(AlConstants.AllegroCoreDllFilename)]
        private static extern IntPtr al_get_timer_event_source(IntPtr timer);
        #endregion
    }
}
