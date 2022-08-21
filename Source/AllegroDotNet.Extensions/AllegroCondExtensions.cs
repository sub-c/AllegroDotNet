using SubC.AllegroDotNet.Models;

namespace SubC.AllegroDotNet.Extensions
{
  public static class AllegroCondExtensions
  {
    public static void DestroyCond(this AllegroCond? cond)
      => Al.DestroyCond(cond);

    public static void WaitCond(this AllegroCond? cond, AllegroMutex? mutex)
      => Al.WaitCond(cond, mutex);

    public static int WaitCondUntil(this AllegroCond? cond, AllegroMutex? mutex, AllegroTimeout timeout)
      => Al.WaitCondUntil(cond, mutex, timeout);

    public static void BroadcastCond(this AllegroCond? cond)
      => Al.BroadcastCond(cond);

    public static void SignalCond(this AllegroCond? cond)
      => Al.SignalCond(cond);
  }
}
