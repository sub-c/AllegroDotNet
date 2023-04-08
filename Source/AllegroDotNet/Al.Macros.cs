using SubC.AllegroDotNet.Enums;

namespace SubC.AllegroDotNet;

public static partial class Al
{
  public static double BpmToSecs(double bpm)
  {
    return 60.0 / bpm;
  }

  public static double BpsToSecs(double bps)
  {
    return 1.0 / bps;
  }

  public static bool EventTypeIsUser(EventType eventType)
  {
    return (int)eventType >= 512;
  }

  public static EventType GetEventType(char a, char b, char c, char d)
  {
    return (EventType)(((a) << 24) | ((b) << 16) | ((c) << 8) | (d));
  }
}
