using SubC.AllegroDotNet.Native;
using System.Runtime.InteropServices;

namespace SubC.AllegroDotNet.Models;

[StructLayout(LayoutKind.Sequential)]
public struct AllegroMemoryInterface
{
  public Delegates.MemoryInterfaceCalloc Calloc
  {
    get => mi_calloc;
    set => mi_calloc = value;
  }

  public Delegates.MemoryInterfaceFree Free
  {
    get => mi_free;
    set => mi_free = value;
  }

  public Delegates.MemoryInterfaceMalloc Malloc
  {
    get => mi_malloc;
    set => mi_malloc = value;
  }

  public Delegates.MemoryInterfaceRealloc Realloc
  {
    get => mi_realloc;
    set => mi_realloc = value;
  }

  public Delegates.MemoryInterfaceMalloc mi_malloc;
  public Delegates.MemoryInterfaceFree mi_free;
  public Delegates.MemoryInterfaceRealloc mi_realloc;
  public Delegates.MemoryInterfaceCalloc mi_calloc;
}
