using SubC.AllegroDotNet.Models;

namespace SubC.AllegroDotNet.Extensions
{
  public static class AllegroMutexExtensions
  {
    public static void LockMutex(this AllegroMutex? mutex)
      => Al.LockMutex(mutex);

    public static void UnlockMutex(this AllegroMutex? mutex)
      => Al.UnlockMutex(mutex);

    public static void DestroyMutex(this AllegroMutex? mutex)
      => Al.DestroyMutex(mutex);
  }
}
