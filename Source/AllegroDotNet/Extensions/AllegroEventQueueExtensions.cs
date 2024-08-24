using SubC.AllegroDotNet.Models;

namespace SubC.AllegroDotNet.Extensions;

/// <summary>
/// This class provides extension methods for the <see cref="AllegroEventQueue"/> class
/// that can be used as shortcuts or object-oriented methods for Allegro.
/// </summary>
public static class AllegroEventQueueExtensions
{
    public static void DestroyEventQueue(this AllegroEventQueue? queue)
        => Al.DestroyEventQueue(queue);

    public static void RegisterEventSource(this AllegroEventQueue? queue, AllegroEventSource? source)
      => Al.RegisterEventSource(queue, source);

    public static void UnregisterEventSource(this AllegroEventQueue? queue, AllegroEventSource? source)
      => Al.UnregisterEventSource(queue, source);

    public static bool IsEventSourceRegistered(this AllegroEventQueue? queue, AllegroEventSource? source)
      => Al.IsEventSourceRegistered(queue, source);

    public static void PauseEventQueue(this AllegroEventQueue? queue, bool pause)
      => Al.PauseEventQueue(queue, pause);

    public static bool IsEventQueuePaused(this AllegroEventQueue? queue)
      => Al.IsEventQueuePaused(queue);

    public static bool IsEventQueueEmpty(this AllegroEventQueue? queue)
      => Al.IsEventQueueEmpty(queue);

    public static bool GetNextEvent(this AllegroEventQueue? queue, ref AllegroEvent allegroEvent)
      => Al.GetNextEvent(queue, ref allegroEvent);

    public static bool PeekNextEvent(this AllegroEventQueue? queue, ref AllegroEvent allegroEvent)
      => Al.PeekNextEvent(queue, ref allegroEvent);

    public static bool DropNextEvent(this AllegroEventQueue? queue)
      => Al.DropNextEvent(queue);

    public static void FlushEventQueue(this AllegroEventQueue? queue)
      => Al.FlushEventQueue(queue);

    public static void WaitForEvent(this AllegroEventQueue? queue, ref AllegroEvent allegroEvent)
      => Al.WaitForEvent(queue, ref allegroEvent);

    public static void WaitForEventTimed(this AllegroEventQueue? queue, ref AllegroEvent allegroEvent, float secs)
      => Al.WaitForEventTimed(queue, ref allegroEvent, secs);

    public static bool WaitForEventUntil(this AllegroEventQueue? queue, ref AllegroEvent allegroEvent, AllegroTimeout timeout)
      => Al.WaitForEventUntil(queue, ref allegroEvent, timeout);
}
