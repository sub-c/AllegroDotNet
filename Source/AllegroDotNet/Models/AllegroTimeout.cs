using System.Runtime.InteropServices;

namespace SubC.AllegroDotNet.Models
{
  public sealed class AllegroTimeout
  {
    internal NativeAllegroTimeout NativeTimeout;

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct NativeAllegroTimeout
    {
      private long __pad1__;
      private long __pad2__;
    }
  }
}