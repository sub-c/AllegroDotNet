using SubC.AllegroDotNet.Models;
using SubC.AllegroDotNet.Native;
using System;
using System.Runtime.InteropServices;

namespace SubC.AllegroDotNet;

public static partial class Al
{
  /// <summary>
  /// Create a new and empty event queue.
  /// </summary>
  /// <returns>A new and empty event queue instance, or null on error.</returns>
  public static AllegroEventQueue? CreateEventQueue()
  {
    var nativePointer = NativeFunctions.AlCreateEventQueue();
    return NativePointerModel.Create<AllegroEventQueue>(nativePointer);
  }

  /// <summary>
  /// Destroy the event queue specified. All event sources currently registered with the queue will be
  /// automatically unregistered before the queue is destroyed.
  /// </summary>
  /// <param name="queue">The event queue instance to destroy.</param>
  public static void DestroyEventQueue(AllegroEventQueue? queue)
  {
    NativeFunctions.AlDestroyEventQueue(NativePointerModel.GetPointer(queue));
  }

  /// <summary>
  /// Register the event source with the event queue specified. An event source may be registered with any
  /// number of event queues simultaneously, or none. Trying to register an event source with the same event
  /// queue more than once does nothing.
  /// </summary>
  /// <param name="queue">The event queue to register the source with.</param>
  /// <param name="source">The event source to register.</param>
  public static void RegisterEventSource(AllegroEventQueue? queue, AllegroEventSource? source)
  {
    NativeFunctions.AlRegisterEventSource(NativePointerModel.GetPointer(queue), NativePointerModel.GetPointer(source));
  }

  /// <summary>
  /// Unregister an event source with an event queue. If the event source is not actually registered with the
  /// event queue, nothing happens. If the queue had any events in it which originated from the event source,
  /// they will no longer be in the queue after this call.
  /// </summary>
  /// <param name="queue">The event queue to unregister the source from.</param>
  /// <param name="source">The event source to unregister.</param>
  public static void UnregisterEventSource(AllegroEventQueue? queue, AllegroEventSource? source)
  {
    NativeFunctions.AlUnregisterEventSource(NativePointerModel.GetPointer(queue), NativePointerModel.GetPointer(source));
  }

  /// <summary>
  /// Determines if a given event source is registered to a given event queue.
  /// </summary>
  /// <param name="queue">The event queue to see if a source is registered with.</param>
  /// <param name="source">The event source to check if registered with a queue.</param>
  /// <returns>True if the event source is registered, otherwise false.</returns>
  public static bool IsEventSourceRegistered(AllegroEventQueue? queue, AllegroEventSource? source)
  {
    return NativeFunctions.AlIsEventSourceRegistered(NativePointerModel.GetPointer(queue), NativePointerModel.GetPointer(source));
  }

  public static void PauseEventQueue(AllegroEventQueue? queue, bool pause)
  {
    NativeFunctions.AlPauseEventQueue(NativePointerModel.GetPointer(queue), pause);
  }

  public static bool IsEventQueuePaused(AllegroEventQueue? queue)
  {
    return NativeFunctions.AlIsEventQueuePaused(NativePointerModel.GetPointer(queue));
  }

  public static bool IsEventQueueEmpty(AllegroEventQueue? queue)
  {
    return NativeFunctions.AlIsEventQueueEmpty(NativePointerModel.GetPointer(queue));
  }

  public static bool GetNextEvent(AllegroEventQueue? queue, AllegroEvent allegroEvent)
  {
    return NativeFunctions.AlGetNextEvent(NativePointerModel.GetPointer(queue), ref allegroEvent.NativeEvent);
  }

  public static bool PeekNextEvent(AllegroEventQueue? queue, AllegroEvent allegroEvent)
  {
    return NativeFunctions.AlPeekNextEvent(NativePointerModel.GetPointer(queue), ref allegroEvent.NativeEvent);
  }

  public static bool DropNextEvent(AllegroEventQueue? queue)
  {
    return NativeFunctions.AlDropNextEvent(NativePointerModel.GetPointer(queue));
  }

  public static void FlushEventQueue(AllegroEventQueue? queue)
  {
    NativeFunctions.AlFlushEventQueue(NativePointerModel.GetPointer(queue));
  }

  public static void WaitForEvent(AllegroEventQueue? queue, AllegroEvent allegroEvent)
  {
    NativeFunctions.AlWaitForEvent(NativePointerModel.GetPointer(queue), ref allegroEvent.NativeEvent);
  }

  public static void WaitForEventTimed(AllegroEventQueue? queue, AllegroEvent allegroEvent, float secs)
  {
    NativeFunctions.AlWaitForEventTimed(NativePointerModel.GetPointer(queue), ref allegroEvent.NativeEvent, secs);
  }

  public static bool WaitForEventUntil(AllegroEventQueue? queue, AllegroEvent allegroEvent, AllegroTimeout timeout)
  {
    return NativeFunctions.AlWaitForEventUntil(NativePointerModel.GetPointer(queue), ref allegroEvent.NativeEvent, ref timeout.NativeTimeout);
  }

  public static void InitUserEventSource(out AllegroEventSource? source)
  {
    var nativeEventSouce = Marshal.AllocHGlobal(Marshal.SizeOf<AllegroEventSource.NativeAllegroEventSource>());
    NativeFunctions.AlInitUserEventSource(nativeEventSouce);
    source = NativePointerModel.Create<AllegroEventSource>(nativeEventSouce);
  }

  public static void DestroyUserEventSource(AllegroEventSource? source)
  {
    NativeFunctions.AlDestroyUserEventSource(NativePointerModel.GetPointer(source));
    Marshal.FreeHGlobal(NativePointerModel.GetPointer(source));
  }

  public static bool EmitUserEvent(
      AllegroEventSource? source,
      AllegroEvent allegroEvent,
      NativeDelegates.UserEventDelegate? userEventDelegate)
  {
    return NativeFunctions.AlEmitUserEvent(NativePointerModel.GetPointer(source), ref allegroEvent.NativeEvent, userEventDelegate);
  }

  public static void UnrefUserEvent(AllegroUserEvent userEvent)
  {
    NativeFunctions.AlUnrefUserEvent(ref userEvent.NativeUserEvent);
  }

  /// <summary>
  /// Returns the abstract user data associated with the event source. If no data was previously set,
  /// returns null.
  /// </summary>
  /// <param name="source">The event source to get user data from.</param>
  /// <returns>The abstract user data associated with the event source, otherwise null.</returns>
  public static IntPtr GetEventSourceData(AllegroEventSource? source)
  {
    return NativeFunctions.AlGetEventSourceData(NativePointerModel.GetPointer(source));
  }

  /// <summary>
  /// Assign the abstract user data to the event source. Allegro does not use the data internally for
  /// anything; it is simply meant as a convenient way to associate your own data or objects with events.
  /// </summary>
  /// <param name="source">The event source to assign user data to.</param>
  /// <param name="data">The user data to assign to the event source.</param>
  public static void SetEventSourceData(AllegroEventSource? source, IntPtr data)
  {
    NativeFunctions.AlSetEventSourceData(NativePointerModel.GetPointer(source), data);
  }
}
