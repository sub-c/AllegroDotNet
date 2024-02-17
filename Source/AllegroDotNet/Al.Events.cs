using SubC.AllegroDotNet.Models;
using SubC.AllegroDotNet.Native;
using System.Runtime.InteropServices;

namespace SubC.AllegroDotNet;

/// <summary>
/// This static class contains the Allegro 5 library methods.
/// </summary>
public static partial class Al
{
  public static AllegroEventQueue? CreateEventQueue()
  {
    var pointer = Interop.Core.AlCreateEventQueue();
    return NativePointer.Create<AllegroEventQueue>(pointer);
  }

  public static void DestroyEventQueue(AllegroEventQueue? queue)
  {
    Interop.Core.AlDestroyEventQueue(NativePointer.Get(queue));
  }

  public static void RegisterEventSource(AllegroEventQueue? queue, AllegroEventSource? source)
  {
    Interop.Core.AlRegisterEventSource(NativePointer.Get(queue), NativePointer.Get(source));
  }

  public static void UnregisterEventSource(AllegroEventQueue? queue, AllegroEventSource? source)
  {
    Interop.Core.AlUnregisterEventSource(NativePointer.Get(queue), NativePointer.Get(source));
  }

  public static bool IsEventSourceRegistered(AllegroEventQueue? queue, AllegroEventSource? source)
  {
    return Interop.Core.AlIsEventSourceRegistered(NativePointer.Get(queue), NativePointer.Get(source)) != 0;
  }

  public static void PauseEventQueue(AllegroEventQueue? queue, bool pause)
  {
    Interop.Core.AlPauseEventQueue(NativePointer.Get(queue), (byte)(pause ? 1 : 0));
  }

  public static bool IsEventQueuePaused(AllegroEventQueue? queue)
  {
    return Interop.Core.AlIsEventQueuePaused(NativePointer.Get(queue)) != 0;
  }

  public static bool IsEventQueueEmpty(AllegroEventQueue? queue)
  {
    return Interop.Core.AlIsEventQueueEmpty(NativePointer.Get(queue)) != 0;
  }

  public static bool GetNextEvent(AllegroEventQueue? queue, ref AllegroEvent retEvent)
  {
    return Interop.Core.AlGetNextEvent(NativePointer.Get(queue), ref retEvent) != 0;
  }

  public static bool PeekNextEvent(AllegroEventQueue? queue, ref AllegroEvent retEvent)
  {
    return Interop.Core.AlPeekNextEvent(NativePointer.Get(queue), ref retEvent) != 0;
  }

  public static bool DropNextEvent(AllegroEventQueue? queue)
  {
    return Interop.Core.AlDropNextEvent(NativePointer.Get(queue)) != 0;
  }

  public static void FlushEventQueue(AllegroEventQueue? queue)
  {
    Interop.Core.AlFlushEventQueue(NativePointer.Get(queue));
  }

  public static void WaitForEvent(AllegroEventQueue? queue, ref AllegroEvent retEvent)
  {
    Interop.Core.AlWaitForEvent(NativePointer.Get(queue), ref retEvent);
  }

  public static bool WaitForEventTimed(AllegroEventQueue? queue, ref AllegroEvent retEvent, float seconds)
  {
    return Interop.Core.AlWaitForEventTimed(NativePointer.Get(queue), ref retEvent, seconds) != 0;
  }

  public static bool WaitForEventUntil(AllegroEventQueue? queue, ref AllegroEvent retEvent, AllegroTimeout? timeout)
  {
    return Interop.Core.AlWaitForEventUntil(NativePointer.Get(queue), ref retEvent, NativePointer.Get(timeout)) != 0;
  }

  public static void InitUserEventSource(out AllegroEventSource? source)
  {
    var nativeEventSourceSize = Marshal.SizeOf<int>() * 32;
    var pointer = Marshal.AllocHGlobal(nativeEventSourceSize);
    source = pointer == IntPtr.Zero
      ? null
      : NativePointer.Create<AllegroEventSource>(pointer);

    if (source is not null)
      Interop.Core.AlInitUserEventSource(NativePointer.Get(source));
  }

  public static void DestroyUserEventSource(AllegroEventSource? source)
  {
    Interop.Core.AlDestroyUserEventSource(NativePointer.Get(source));

    if (source is not null)
      Marshal.FreeHGlobal(source.Pointer);
  }

  public static bool EmitUserEvent(AllegroEventSource? source, AllegroEvent @event, Delegates.UserEventDeconstructor? dtor)
  {
    return Interop.Core.AlEmitUserEvent(NativePointer.Get(source), ref @event, dtor) != 0;
  }

  public static void UnrefUserEvent(ref AllegroUserEvent @event)
  {
    Interop.Core.AlUnrefUserEvent(ref @event);
  }

  public static IntPtr GetEventSourceData(AllegroEventSource? source)
  {
    return Interop.Core.AlGetEventSourceData(NativePointer.Get(source));
  }

  public static void SetEventSourceData(AllegroEventSource? source, IntPtr data)
  {
    Interop.Core.AlSetEventSourceData(NativePointer.Get(source), data);
  }
}
