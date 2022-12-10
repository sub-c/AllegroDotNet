using SubC.AllegroDotNet.Models;
using System;

namespace SubC.AllegroDotNet.Extensions
{
  public static class AllegroThreadExtensions
  {
    public static void StartThread(this AllegroThread? thread)
      => Al.StartThread(thread);

    public static void JoinThread(this AllegroThread? thread, out IntPtr returnValue)
      => Al.JoinThread(thread, out returnValue);

    public static void SetThreadShouldStop(this AllegroThread? thread)
      => Al.SetThreadShouldStop(thread);

    public static bool GetThreadShouldStop(this AllegroThread? thread)
      => Al.GetThreadShouldStop(thread);

    public static void DestroyThread(this AllegroThread? thread)
      => Al.DestroyThread(thread);
  }
}
