using SubC.AllegroDotNet.Models;

namespace SubC.AllegroDotNet.Extensions;

/// <summary>
/// This class provides extension methods for the <see cref="AllegroCond"/> class
/// that can be used as shortcuts or object-oriented methods for Allegro.
/// </summary>
public static class AllegroCondExtensions
{
    public static void DestroyCond(this AllegroCond? cond)
       => Al.DestroyCond(cond);

    public static void WaitCond(this AllegroCond? cond, AllegroMutex? mutex)
      => Al.WaitCond(cond, mutex);

    public static int WaitCondUntil(this AllegroCond? cond, AllegroMutex? mutex, ref AllegroTimeout timeout)
      => Al.WaitCondUntil(cond, mutex, ref timeout);

    public static void BroadcastCond(this AllegroCond? cond)
      => Al.BroadcastCond(cond);

    public static void SignalCond(this AllegroCond? cond)
      => Al.SignalCond(cond);
}
