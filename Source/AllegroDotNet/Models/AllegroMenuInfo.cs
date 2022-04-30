using System;
using System.Runtime.InteropServices;

namespace SubC.AllegroDotNet.Models
{
  public sealed class AllegroMenuInfo
  {
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct NativeAllegroMenuInfo
    {
      public IntPtr caption;
      public ushort id;
      public int flags;
      public IntPtr icon;
    }
  }
}