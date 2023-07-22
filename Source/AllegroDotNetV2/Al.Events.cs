using System.Runtime.InteropServices;
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
  /// Create a new, empty event queue, returning a pointer to the newly created object if successful.
  /// Returns <c>null</c> on error.
  /// </summary>
  /// <returns>An event queue instance on success, otherwise <c>null</c>.</returns>
  public static AllegroEventQueue? CreateEventQueue()
  {
    var pointer = Interop.Context.Core.AlCreateEventQueue();
    return NativePointer.Create<AllegroEventQueue>(pointer);
  }

  /// <summary>
  /// Destroy the event queue specified. All event sources currently registered with the queue will be automatically
  /// unregistered before the queue is destroyed.
  /// </summary>
  /// <param name="queue">The event queue instance.</param>
  public static void DestroyEventQueue(AllegroEventQueue? queue)
  {
    Interop.Context.Core.AlDestroyEventQueue(NativePointer.Get(queue));
  }

  /// <summary>
  /// Register the event source with the event queue specified. An event source may be registered with any number of
  /// event queues simultaneously, or none. Trying to register an event source with the same event queue more than
  /// once does nothing.
  /// </summary>
  /// <param name="queue">The event queue instance.</param>
  /// <param name="source">The event source instance.</param>
  public static void RegisterEventSource(AllegroEventQueue? queue, AllegroEventSource? source)
  {
    Interop.Context.Core.AlRegisterEventSource(NativePointer.Get(queue), NativePointer.Get(source));
  }

  /// <summary>
  /// <para>
  /// Unregister an event source with an event queue. If the event source is not actually registered with the event
  /// queue, nothing happens.
  /// </para>
  /// <para>
  /// If the queue had any events in it which originated from the event source, they will no longer be in the queue
  /// after this call.
  /// </para>
  /// </summary>
  /// <param name="queue">The event queue instance.</param>
  /// <param name="source">The event source instance.</param>
  public static void UnregisterEventSource(AllegroEventQueue? queue, AllegroEventSource? source)
  {
    Interop.Context.Core.AlUnregisterEventSource(NativePointer.Get(queue), NativePointer.Get(source));
  }

  /// <summary>
  /// Return true if the event source is registered.
  /// </summary>
  /// <param name="queue">The event queue instance.</param>
  /// <param name="source">The event source instance.</param>
  /// <returns>True if the source is registered in the queue, otherwise false.</returns>
  public static bool IsEventSourceRegistered(AllegroEventQueue? queue, AllegroEventSource? source)
  {
    return Interop.Context.Core.AlIsEventSourceRegistered(NativePointer.Get(queue), NativePointer.Get(source)) != 0;
  }

  /// <summary>
  /// <para>
  /// Pause or resume accepting new events into the event queue (to resume, pass false for pause).
  /// Events already in the queue are unaffected.
  /// </para>
  /// <para>
  /// While a queue is paused, any events which would be entered into the queue are simply ignored.
  /// This is an alternative to unregistering then re-registering all event sources from the event queue,
  /// if you just need to prevent events piling up in the queue for a while.
  /// </para>
  /// </summary>
  /// <param name="queue">The event queue instance.</param>
  /// <param name="pause">True to pause, otherwise false.</param>
  public static void PauseEventQueue(AllegroEventQueue? queue, bool pause)
  {
    Interop.Context.Core.AlPauseEventQueue(NativePointer.Get(queue), (byte)(pause ? 1 : 0));
  }

  /// <summary>
  /// Return true if the event queue is paused.
  /// </summary>
  /// <param name="queue">The event queue instance.</param>
  /// <returns>True if the event queue is paused.</returns>
  public static bool IsEventQueuePaused(AllegroEventQueue? queue)
  {
    return Interop.Context.Core.AlIsEventQueuePaused(NativePointer.Get(queue)) != 0;
  }

  /// <summary>
  /// Returns true if the event queue specified is currently empty.
  /// </summary>
  /// <param name="queue">The event queue instance.</param>
  /// <returns>True if the event queue is empty, otherwise false.</returns>
  public static bool IsEventQueueEmpty(AllegroEventQueue? queue)
  {
    return Interop.Context.Core.AlIsEventQueueEmpty(NativePointer.Get(queue)) != 0;
  }

  /// <summary>
  /// Take the next event out of the event queue specified, and copy the contents into
  /// <paramref name="allegroEvent"/>, returning true.
  /// The original event will be removed from the queue.
  /// If the event queue is empty, return false and the contents of <paramref name="allegroEvent"/> are unspecified.
  /// </summary>
  /// <param name="queue">The event queue instance.</param>
  /// <param name="allegroEvent">The event to copy from the event queue to.</param>
  /// <returns>True if the next event was copied from the queue, otherwise false.</returns>
  public static bool GetNextEvent(AllegroEventQueue? queue, AllegroEvent allegroEvent)
  {
    return Interop.Context.Core.AlGetNextEvent(NativePointer.Get(queue), ref allegroEvent.Struct) != 0;
  }

  /// <summary>
  /// Copy the contents of the next event in the event queue specified into <paramref name="allegroEvent"/>
  /// and return true. The original event packet will remain at the head of the queue. If the event queue is
  /// actually empty, this function returns false and the contents of <paramref name="allegroEvent"/> are unspecified.
  /// </summary>
  /// <param name="queue">The event queue instance.</param>
  /// <param name="allegroEvent">The event to copy from the event queue to.</param>
  /// <returns>True if an event was present to peek at, otherwise false.</returns>
  public static bool PeekNextEvent(AllegroEventQueue? queue, AllegroEvent allegroEvent)
  {
    return Interop.Context.Core.AlPeekNextEvent(NativePointer.Get(queue), ref allegroEvent.Struct) != 0;
  }

  /// <summary>
  /// Drop (remove) the next event from the queue. If the queue is empty, nothing happens.
  /// Returns true if an event was dropped.
  /// </summary>
  /// <param name="queue">The event queue instance.</param>
  /// <returns>True if an event was present and dropped, otherwise false.</returns>
  public static bool DropNextEvent(AllegroEventQueue? queue)
  {
    return Interop.Context.Core.AlDropNextEvent(NativePointer.Get(queue)) != 0;
  }

  /// <summary>
  /// Drops all events, if any, from the event queue.
  /// </summary>
  /// <param name="queue">The event queue instance.</param>
  public static void FlushEventQueue(AllegroEventQueue? queue)
  {
    Interop.Context.Core.AlFlushEventQueue(NativePointer.Get(queue));
  }

  /// <summary>
  /// Wait until the event queue specified is non-empty. The first event in the queue will be copied into
  /// <paramref name="allegroEvent"/> and removed from the queue.
  /// </summary>
  /// <param name="queue">The event queue instance.</param>
  /// <param name="allegroEvent">The event to copy from the event queue to.</param>
  public static void WaitForEvent(AllegroEventQueue? queue, AllegroEvent allegroEvent)
  {
    Interop.Context.Core.AlWaitForEvent(NativePointer.Get(queue), ref allegroEvent.Struct);
  }

  /// <summary>
  /// <para>
  /// Wait until the event queue specified is non-empty. If <paramref name="allegroEvent"/> is not <c>null</c>,
  /// the first event in the queue will be copied into <paramref name="allegroEvent"/> and removed from the
  /// queue. If <paramref name="allegroEvent"/> is <c>null</c> the first event is left at the head of the queue.
  /// </para>
  /// <para>
  /// <paramref name="seconds"/> determines approximately how many seconds to wait. If the call times out,
  /// false is returned. Otherwise, if an event occurred, true is returned.
  /// </para>
  /// <para>
  /// For compatibility with all platforms, <paramref name="seconds"/> must be 2,147,483.647 seconds or less.
  /// </para>
  /// </summary>
  /// <param name="queue">The event queue instance.</param>
  /// <param name="allegroEvent">The event to copy from the event queue to.</param>
  /// <param name="seconds">The seconds to wait for an event.</param>
  /// <returns>False if the wait time was exceeded with no event, otherwise true.</returns>
  public static bool WaitForEventTimed(AllegroEventQueue? queue, AllegroEvent allegroEvent, float seconds)
  {
    return Interop.Context.Core.AlWaitForEventTimed(
      NativePointer.Get(queue),
      ref allegroEvent.Struct,
      seconds) != 0;
  }

  /// <summary>
  /// <para>
  /// Wait until the event queue specified is non-empty. If <paramref name="allegroEvent"/> is not <c>null</c>,
  /// the first event in the queue will be copied into <paramref name="allegroEvent"/> and removed from the
  /// queue. If <paramref name="allegroEvent"/> is <c>null</c> the first event is left at the head of the queue.
  /// </para>
  /// <para>
  /// <paramref name="timeout"/> determines approximately how many seconds to wait. If the call times out,
  /// false is returned. Otherwise, if an event occurred, true is returned.
  /// </para>
  /// <para>
  /// For compatibility with all platforms, <paramref name="timeout"/> must be 2,147,483.647 seconds or less.
  /// </para>
  /// </summary>
  /// <param name="queue">The event queue instance.</param>
  /// <param name="allegroEvent">The event to copy from the event queue to.</param>
  /// <param name="timeout">The timeout instance.</param>
  /// <returns>False if the timeout was exceeded without an event, otherwise true.</returns>
  public static bool WaitForEventUntil(AllegroEventQueue? queue, AllegroEvent allegroEvent, AllegroTimeout? timeout)
  {
    return Interop.Context.Core.AlWaitForEventUntil(
      NativePointer.Get(queue),
      ref allegroEvent.Struct,
      NativePointer.Get(timeout)) != 0;
  }

  /// <summary>
  /// Initialise an event source for emitting user events. This method differs from the native Allegro library
  /// in that the event source is not allocated by the caller, and instead it is allocated by this method. To free
  /// this memory, call <see cref="DestroyUserEventSource"/>.
  /// </summary>
  /// <param name="source">The created user event source instance.</param>
  public static void InitUserEventSource(out AllegroEventSource? source)
  {
    var pointer = Marshal.AllocHGlobal(Marshal.SizeOf<Native.Structs.NativeAllegroEventSource>());
    Interop.Context.Core.AlInitUserEventSource(pointer);
    source = NativePointer.Create<AllegroEventSource>(pointer);
  }

  /// <summary>
  /// Destroy an event source initialized by <see cref="InitUserEventSource"/>, and freeing the memory used by the
  /// user event source.
  /// </summary>
  /// <param name="source">The user event source instance.</param>
  public static void DestroyUserEventSource(AllegroEventSource? source)
  {
    Interop.Context.Core.AlDestroyUserEventSource(NativePointer.Get(source));
    Marshal.FreeHGlobal(NativePointer.Get(source));
  }

  /// <summary>
  /// <para>
  /// Emit an event from a user event source. The event source must have been initialised with
  /// <see cref="InitUserEventSource"/>. Returns false if the event source isn’t registered with any queues, hence
  /// the event would not have been delivered into any queues.
  /// </para>
  /// <para>
  /// Events are copied in and out of event queues, so after this function returns the memory pointed to by
  /// <paramref name="allegroEvent"/> may be freed or reused. Some fields of the event being passed in may be modified
  /// by the function.
  /// </para>
  /// <para>
  /// Reference counting will be performed if <paramref name="eventDeconstructor"/> is not <c>null</c>.
  /// Whenever a copy of the event is made, the reference count increases. You need to call <see cref="UnrefUserEvent"/>
  /// to decrease the reference count once you are done with a user event that you have received from
  /// <see cref="GetNextEvent"/>, <see cref="PeekNextEvent"/>, <see cref="WaitForEvent"/>, etc.
  /// </para>
  /// <para>
  /// Once the reference count drops to zero <paramref name="eventDeconstructor"/> will be called with a copy of the
  /// event as an argument. It should free the resources associated with the event, but not the event itself
  /// (since it is just a copy).
  /// </para>
  /// <para>
  /// If <paramref name="eventDeconstructor"/> is <c>null</c> then reference counting will not be performed.
  /// It is safe, but unnecessary, to call <see cref="UnrefUserEvent"/> on non-reference counted user events.
  /// </para>
  /// <para>
  /// You can use <see cref="EmitUserEvent"/> to emit both user and non-user events from your user event source.
  /// Note that emitting input events will not update the corresponding input device states. For example, you may emit
  /// an event of type <see cref="EventType.KeyDown"/>, but it will not update the
  /// <see cref="AllegroKeyboardState"/> returned by <see cref="GetKeyboardState"/>.
  /// </para>
  /// </summary>
  /// <param name="source">The event source instance.</param>
  /// <param name="allegroEvent">The event instance to emit.</param>
  /// <param name="eventDeconstructor">The deconstructor to call once the event's reference count hits 0.</param>
  /// <returns>True if the event was emitted to one or more listener, otherwise false.</returns>
  public static bool EmitUserEvent(
    AllegroEventSource? source,
    AllegroEvent allegroEvent,
    Delegates.UserEventDeconstructor? eventDeconstructor)
  {
    return Interop.Context.Core.AlEmitUserEvent(NativePointer.Get(source), ref allegroEvent.Struct, eventDeconstructor) != 0;
  }

  /// <summary>
  /// Decrease the reference count of a user-defined event. This must be called on any user event that you get from
  /// <see cref="GetNextEvent"/>, <see cref="PeekNextEvent"/>, <see cref="WaitForEvent"/>, etc. which is reference
  /// counted. This function does nothing if the event is not reference counted.
  /// </summary>
  /// <param name="allegroEvent">The event instance to decrease the reference count of.</param>
  public static void UnrefUserEvent(AllegroEvent allegroEvent)
  {
    Interop.Context.Core.AlUnrefUserEvent(ref allegroEvent.Struct);
  }

  /// <summary>
  /// Returns the abstract user data associated with the event source. If no data was previously set, returns
  /// <see cref="IntPtr.Zero"/>.
  /// </summary>
  /// <param name="source">The event source to get abstract user data from.</param>
  /// <returns>The abstract user data if previously set, otherwise <see cref="IntPtr.Zero"/>.</returns>
  public static IntPtr GetEventSourceData(AllegroEventSource? source)
  {
    return Interop.Context.Core.AlGetEventSourceData(NativePointer.Get(source));
  }

  /// <summary>
  /// Assign the abstract user data to the event source. Allegro does not use the data internally for anything;
  /// it is simply meant as a convenient way to associate your own data or objects with events.
  /// </summary>
  /// <param name="source">The event source to set abstract user data to.</param>
  /// <param name="data">The abstract user data.</param>
  public static void SetEventSourceData(AllegroEventSource? source, IntPtr data)
  {
    Interop.Context.Core.AlSetEventSourceData(NativePointer.Get(source), data);
  }
}