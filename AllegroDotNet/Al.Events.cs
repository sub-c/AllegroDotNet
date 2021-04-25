using System;
using System.Runtime.InteropServices;
using AllegroDotNet.Models;
using AllegroDotNet.Native;

namespace AllegroDotNet
{
    /// <summary>
    /// Allegro game library methods.
    /// </summary>
    public static partial class Al
    {
        /// <summary>
        /// Create a new, empty event queue. 
        /// </summary>
        /// <returns>A event queue, or null on error.</returns>
        public static AllegroEventQueue CreateEventQueue()
        {
            var eventQueue = al_create_event_queue();
            return eventQueue == IntPtr.Zero ? null : new AllegroEventQueue { NativeIntPtr = eventQueue };
        }

        /// <summary>
        /// Destroy the event queue specified. All event sources currently registered with the queue will be
        /// automatically unregistered before the queue is destroyed.
        /// </summary>
        /// <param name="eventQueue">The event queue to destroy.</param>
        public static void DestroyEventQueue(AllegroEventQueue eventQueue)
            => al_destroy_event_queue(eventQueue.NativeIntPtr);

        /// <summary>
        /// Register the event source with the event queue specified. An event source may be registered with any
        /// number of event queues simultaneously, or none. Trying to register an event source with the same event
        /// queue more than once does nothing.
        /// </summary>
        /// <param name="eventQueue">The event queue to register the event source with.</param>
        /// <param name="eventSource">The event source.</param>
        public static void RegisterEventSource(AllegroEventQueue eventQueue, AllegroEventSource eventSource)
            => al_register_event_source(eventQueue.NativeIntPtr, eventSource.NativeIntPtr);

        /// <summary>
        /// Unregister an event source with an event queue. If the event source is not actually registered with the
        /// event queue, nothing happens.
        /// <para>
        /// If the queue had any events in it which originated from the event source, they will no longer be in the
        /// queue after this call.
        /// </para>
        /// </summary>
        /// <param name="eventQueue">The event queue to unregister the event source with.</param>
        /// <param name="eventSource">The event source.</param>
        public static void UnregisterEventSource(AllegroEventQueue eventQueue, AllegroEventSource eventSource)
            => al_unregister_event_source(eventQueue.NativeIntPtr, eventSource.NativeIntPtr);

        /// <summary>
        /// Return true if the event source is registered.
        /// </summary>
        /// <param name="eventQueue">The event queue to check if registered in.</param>
        /// <param name="eventSource">The event source to check if registered with.</param>
        /// <returns>Return true if the event source is registered, otherwise false.</returns>
        public static bool IsEventSourceRegistered(AllegroEventQueue eventQueue, AllegroEventSource eventSource)
            => al_is_event_source_registered(eventQueue.NativeIntPtr, eventSource.NativeIntPtr);

        /// <summary>
        /// Pause or resume accepting new events into the event queue (to resume, pass <c>false</c> for pause). Events
        /// already in the queue are unaffected.
        /// <para>
        /// While a queue is paused, any events which would be entered into the queue are simply ignored. This is an
        /// alternative to unregistering then re-registering all event sources from the event queue, if you just
        /// need to prevent events piling up in the queue for a while.
        /// </para>
        /// </summary>
        /// <param name="eventQueue">The event queue to pause.</param>
        /// <param name="pause">True to pause the queue, false to resume.</param>
        public static void PauseEventQueue(AllegroEventQueue eventQueue, bool pause)
            => al_pause_event_queue(eventQueue.NativeIntPtr, pause);

        /// <summary>
        /// Return true if the event queue is paused.
        /// </summary>
        /// <param name="eventQueue">The event queue to check if paused.</param>
        /// <returns>Return true if the event queue is paused, otherwise false.</returns>
        public static bool IsEventQueuePaused(AllegroEventQueue eventQueue)
            => al_is_event_queue_paused(eventQueue.NativeIntPtr);

        /// <summary>
        /// Return true if the event queue specified is currently empty.
        /// </summary>
        /// <param name="eventQueue">The event queue to check if empty.</param>
        /// <returns>Return true if the event queue specified is currently empty, otherwise false.</returns>
        public static bool IsEventQueueEmpty(AllegroEventQueue eventQueue)
            => al_is_event_queue_empty(eventQueue.NativeIntPtr);

        /// <summary>
        /// Take the next event out of the event queue specified, and copy the contents into <c>retEvent</c>, returning
        /// true. The original event will be removed from the queue. If the event queue is empty, return false and
        /// the contents of <c>eventQueue</c> are unspecified.
        /// </summary>
        /// <param name="eventQueue">The event queue to get the next event from.</param>
        /// <param name="retEvent">The event to populate with the next event.</param>
        /// <returns>True if an event was returned, false otherwise.</returns>
        public static bool GetNextEvent(AllegroEventQueue eventQueue, ref AllegroEvent retEvent)
            => al_get_next_event(eventQueue.NativeIntPtr, ref retEvent.NativeEvent);

        /// <summary>
        /// Copy the contents of the next event in the event queue specified into <c>retEvent</c> and return true. The
        /// original event packet will remain at the head of the queue. If the event queue is actually empty,
        /// this function returns false and the contents of <c>retEvent</c> are unspecified.
        /// </summary>
        /// <param name="eventQueue">The event queue to peek the next event from.</param>
        /// <param name="retEvent">The event to populate with the peeked event.</param>
        /// <returns>True if an event was peeked, otherwise false.</returns>
        public static bool PeekNextEvent(AllegroEventQueue eventQueue, ref AllegroEvent retEvent)
            => al_peek_next_event(eventQueue.NativeIntPtr, ref retEvent.NativeEvent);

        /// <summary>
        /// Drop (remove) the next event from the queue. If the queue is empty, nothing happens. Returns true if an
        /// event was dropped.
        /// </summary>
        /// <param name="eventQueue">The event queue to drop the next even from.</param>
        /// <returns>True if an event was dropped, otherwise false.</returns>
        public static bool DropNextEvent(AllegroEventQueue eventQueue)
            => al_drop_next_event(eventQueue.NativeIntPtr);

        /// <summary>
        /// Drops all events, if any, from the queue.
        /// </summary>
        /// <param name="eventQueue">The event queue to drop all events from.</param>
        public static void FlushEventQueue(AllegroEventQueue eventQueue)
            => al_flush_event_queue(eventQueue.NativeIntPtr);

        /// <summary>
        /// Wait until the event queue specified is non-empty. If <c>retEvent</c> is not null, the first event in the
        /// queue will be copied into <c>retEvent</c> and removed from the queue. If <c>retEvent</c> is null the first
        /// event is left at the head of the queue.
        /// </summary>
        /// <param name="eventQueue">The event queue to wait for an event from.</param>
        /// <param name="retEvent">The next event in the event queue.</param>
        public static void WaitForEvent(AllegroEventQueue eventQueue, ref AllegroEvent retEvent)
            => al_wait_for_event(eventQueue.NativeIntPtr, ref retEvent.NativeEvent);

        /// <summary>
        /// Wait until the event queue specified is non-empty. If <c>retEvent</c> is not null, the first event
        /// in the queue will be copied into <c>retEvent</c> and removed from the queue. If <c>retEvent</c> is null
        /// the first event is left at the head of the queue.
        /// <para>
        /// <c>seconds</c> determines approximately how many seconds to wait. If the call times out, false is returned.
        /// Otherwise, if an event ocurred, true is returned.
        /// </para>
        /// <para>
        /// For compatibility with all platforms, <c>seconds</c> must be 2,147,483.647 seconds or less.
        /// </para>
        /// </summary>
        /// <param name="eventQueue">The event queue to wait for an event to occur.</param>
        /// <param name="retEvent">The returned event from the event queue.</param>
        /// <param name="seconds">The approximate seconds to wait for an event.</param>
        /// <returns>True if the call did not time out, otherwise false.</returns>
        public static bool WaitForEventTimed(AllegroEventQueue eventQueue, ref AllegroEvent retEvent, float seconds)
            => al_wait_for_event_timed(eventQueue.NativeIntPtr, ref retEvent.NativeEvent, seconds);

        /// <summary>
        /// Wait until the event queue specified is non-empty. If <c>retEvent</c> is not null, the first event in the
        /// queue will be copied into <c>retEvent</c> and removed from the queue. If <c>retEvent</c> is null the first
        /// event is left at the head of the queue.
        /// <para>
        /// <c>timeout</c> determines how long to wait. If the call times out, false is returned. Otherwise, if an
        /// event ocurred, true is returned.
        /// </para>
        /// <para>
        /// For compatibility with all platforms, <c>timeout</c> must be 2,147,483.647 seconds or less.
        /// </para>
        /// </summary>
        /// <param name="eventQueue">The event queue to wait for an event to occur.</param>
        /// <param name="retEvent">The returned event from the event queue.</param>
        /// <param name="timeout">The approximate timeout to wait for an event.</param>
        /// <returns>True if the call did not time out, otherwise false.</returns>
        public static bool WaitForEventUntil(AllegroEventQueue eventQueue, ref AllegroEvent retEvent, ref AllegroTimeout timeout)
            => al_wait_for_event_until(eventQueue.NativeIntPtr, ref retEvent.NativeEvent, ref timeout.NativeTimeout);

        /// <summary>
        /// Initialise an event source for emitting user events. The space for the event source must already have
        /// been allocated.
        /// <para>
        /// The user event source will never be destroyed automatically. You must destroy it manually with
        /// <see cref="DestroyUserEventSource()"/>.
        /// </para>
        /// </summary>
        /// <param name="eventSource">The user event source to be initialized.</param>
        public static void InitUserEventSource(AllegroEventSource eventSource)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Destroy an event source initialised with <see cref="InitUserEventSource(AllegroEventSource)"/>.
        /// </summary>
        /// <param name="eventSource">The user event source.</param>
        public static void DestroyUserEventSource(AllegroEventSource eventSource)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Emit an event from a user event source. The event source must have been initialised with
        /// <see cref="InitUserEventSource(AllegroEventSource)"/>. Returns false if the event source isn't registered
        /// with any queues, hence the event wouldn't have been delivered into any queues.
        /// <para>
        /// Events are copied in and out of event queues, so after this function returns the memory pointed to by
        /// <c>allegroEvent</c> may be freed or reused. Some fields of the event being passed in may be modified
        /// by the function.
        /// </para>
        /// <para>
        /// Reference counting will be performed if dtor is not NULL. Whenever a copy of the event is made, the
        /// reference count increases. You need to call al_unref_user_event to decrease the reference count once
        /// you are done with a user event that you have received from al_get_next_event, al_peek_next_event,
        /// al_wait_for_event, etc.
        /// </para>
        /// <para>
        /// Once the reference count drops to zero dtor will be called with a copy of the event as an argument.
        /// It should free the resources associated with the event, but not the event itself (since it is just a copy).
        /// </para>
        /// <para>
        /// If <c>dtor</c> is null then reference counting will not be performed. It is safe, but unnecessary, to call
        /// al_unref_user_event on non-reference counted user events.
        /// </para>
        /// <para>
        /// You can use al_emit_user_event to emit both user and non-user events from your user event source.
        /// Note that emitting input events will not update the corresponding input device states. For example,
        /// you may emit an event of type ALLEGRO_EVENT_KEY_DOWN, but it will not update the
        /// ALLEGRO_KEYBOARD_STATE returned by al_get_keyboard_state.
        /// </para>
        /// </summary>
        /// <param name="eventSource">The user event source to emit the event from.</param>
        /// <param name="allegroEvent">The event to emit.</param>
        /// <param name="dtor">The method invoked when this event is emitted if non-null.</param>
        /// <returns>True if at least one event queue is registered to source, otherwise false.</returns>
        public static bool EmitUserEvent(AllegroEventSource eventSource, ref AllegroEvent allegroEvent, IntPtr dtor)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Decrease the reference count of a user-defined event. This must be called on any user event that you
        /// get from al_get_next_event, al_peek_next_event, al_wait_for_event, etc.
        /// which is reference counted. This function does nothing if the event is not reference counted.
        /// </summary>
        /// <param name="userEvent">The user event to decrease the reference count of.</param>
        public static void UnrefUserEvent(IntPtr userEvent)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns the abstract user data associated with the event source. If no data was previously set,
        /// returns null.
        /// </summary>
        /// <param name="eventSource">The user event source to get data from.</param>
        /// <returns>The user event data pointer, or null if no data.</returns>
        public static IntPtr GetEventSourceData(AllegroEventSource eventSource)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Assign the abstract user data to the event source. Allegro does not use the data internally for
        /// anything; it is simply meant as a convenient way to associate your own data or objects with events.
        /// </summary>
        /// <param name="eventSource">The user event source to set data to.</param>
        /// <param name="userData">The user event data pointer.</param>
        public static void SetEventSourceData(AllegroEventSource eventSource, IntPtr userData)
        {
            throw new NotImplementedException();
        }

        #region P/Invokes
        [DllImport(AlConstants.AllegroCoreDllFilename)]
        private static extern IntPtr al_create_event_queue();

        [DllImport(AlConstants.AllegroCoreDllFilename)]
        private static extern void al_destroy_event_queue(IntPtr queue);

        [DllImport(AlConstants.AllegroCoreDllFilename)]
        private static extern void al_register_event_source(IntPtr queue, IntPtr source);

        [DllImport(AlConstants.AllegroCoreDllFilename)]
        private static extern void al_unregister_event_source(IntPtr queue, IntPtr source);

        [DllImport(AlConstants.AllegroCoreDllFilename)]
        private static extern bool al_is_event_source_registered(IntPtr queue, IntPtr source);

        [DllImport(AlConstants.AllegroCoreDllFilename)]
        private static extern void al_pause_event_queue(IntPtr queue, bool pause);

        [DllImport(AlConstants.AllegroCoreDllFilename)]
        private static extern bool al_is_event_queue_paused(IntPtr queue);

        [DllImport(AlConstants.AllegroCoreDllFilename)]
        private static extern bool al_is_event_queue_empty(IntPtr queue);

        [DllImport(AlConstants.AllegroCoreDllFilename)]
        private static extern bool al_get_next_event(IntPtr queue, ref NativeAllegroEvent retEvent);

        [DllImport(AlConstants.AllegroCoreDllFilename)]
        private static extern bool al_peek_next_event(IntPtr queue, ref NativeAllegroEvent retEvent);

        [DllImport(AlConstants.AllegroCoreDllFilename)]
        private static extern bool al_drop_next_event(IntPtr queue);

        [DllImport(AlConstants.AllegroCoreDllFilename)]
        private static extern void al_flush_event_queue(IntPtr queue);

        [DllImport(AlConstants.AllegroCoreDllFilename)]
        private static extern void al_wait_for_event(IntPtr queue, ref NativeAllegroEvent retEvent);

        [DllImport(AlConstants.AllegroCoreDllFilename)]
        private static extern bool al_wait_for_event_timed(IntPtr queue, ref NativeAllegroEvent retEvent, float seconds);

        [DllImport(AlConstants.AllegroCoreDllFilename)]
        private static extern bool al_wait_for_event_until(IntPtr queue, ref NativeAllegroEvent retEvent, ref NativeAllegroTimeout timeout);

        [DllImport(AlConstants.AllegroCoreDllFilename)]
        private static extern void al_init_user_event_source(IntPtr src);

        [DllImport(AlConstants.AllegroCoreDllFilename)]
        private static extern void al_destroy_user_event_source(IntPtr src);

        [DllImport(AlConstants.AllegroCoreDllFilename)]
        private static extern bool al_emit_user_event(IntPtr source, ref NativeAllegroEvent allegroEvent, IntPtr dtor);

        [DllImport(AlConstants.AllegroCoreDllFilename)]
        private static extern void al_unref_user_event(IntPtr source);

        [DllImport(AlConstants.AllegroCoreDllFilename)]
        private static extern IntPtr al_get_event_source_data(IntPtr source);

        [DllImport(AlConstants.AllegroCoreDllFilename)]
        private static extern void al_set_event_source_data(IntPtr source, IntPtr data);
        #endregion
    }
}
