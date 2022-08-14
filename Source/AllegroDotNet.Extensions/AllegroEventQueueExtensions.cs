using SubC.AllegroDotNet.Models;

namespace SubC.AllegroDotNet.Extensions
{
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

    public static bool GetNextEvent(this AllegroEventQueue? queue, AllegroEvent allegroEvent)
      => Al.GetNextEvent(queue, allegroEvent);

    public static bool PeekNextEvent(this AllegroEventQueue? queue, AllegroEvent allegroEvent)
      => Al.PeekNextEvent(queue, allegroEvent);

    public static bool DropNextEvent(this AllegroEventQueue? queue)
      => Al.DropNextEvent(queue);

    public static void FlushEventQueue(this AllegroEventQueue? queue)
      => Al.FlushEventQueue(queue);

    public static void WaitForEvent(this AllegroEventQueue? queue, AllegroEvent allegroEvent)
      => Al.WaitForEvent(queue, allegroEvent);

    public static void WaitForEventTimed(this AllegroEventQueue? queue, AllegroEvent allegroEvent, float secs)
      => Al.WaitForEventTimed(queue, allegroEvent, secs);

    public static bool WaitForEventUntil(this AllegroEventQueue? queue, AllegroEvent allegroEvent, AllegroTimeout timeout)
      => Al.WaitForEventUntil(queue, allegroEvent, timeout);
  }
}
