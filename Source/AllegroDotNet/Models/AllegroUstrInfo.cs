using System;
using System.Runtime.InteropServices;

namespace SubC.AllegroDotNet.Models
{
  public sealed class AllegroUstrInfo
  {
    internal NativeAllegroUstrInfo NativeUstrInfo;

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct NativeAllegroUstrInfo
    {
      public int mlen;
      public int slen;
      public UIntPtr data;
    }
  }
}
