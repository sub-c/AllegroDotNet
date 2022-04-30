using SubC.AllegroDotNet.Native;
using System.Runtime.InteropServices;

namespace SubC.AllegroDotNet.Models
{
  public sealed class AllegroMemoryInterface
  {
    internal NativeMemoryInterface MemoryInterface;

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct NativeMemoryInterface
    {
      public NativeDelegates.MemoryInterfaceMalloc mi_malloc;
      public NativeDelegates.MemoryInterfaceFree mi_free;
      public NativeDelegates.MemoryInterfaceRealloc mi_realloc;
      public NativeDelegates.MemoryInterfaceCalloc mi_calloc;
    }
  }
}