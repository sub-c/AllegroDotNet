using SubC.AllegroDotNet.Models;

namespace SubC.AllegroDotNet.Extensions;

/// <summary>
/// This class provides extension methods for the <see cref="AllegroThread"/> class
/// that can be used as shortcuts or object-oriented methods for Allegro.
/// </summary>
public static class AllegroThreadExtensions
{
  public static void StartThread(this AllegroThread? thread)
  => Al.StartThread(thread);

  public static void JoinThread(this AllegroThread? thread, ref IntPtr returnValue)
    => Al.JoinThread(thread, ref returnValue);

  public static void SetThreadShouldStop(this AllegroThread? thread)
    => Al.SetThreadShouldStop(thread);

  public static bool GetThreadShouldStop(this AllegroThread? thread)
    => Al.GetThreadShouldStop(thread);

  public static void DestroyThread(this AllegroThread? thread)
    => Al.DestroyThread(thread);
}
