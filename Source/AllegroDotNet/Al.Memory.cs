using SubC.AllegroDotNet.Models;
using SubC.AllegroDotNet.Native;
using System.Runtime.InteropServices;

namespace SubC.AllegroDotNet;

/// <summary>
/// This static class contains the Allegro 5 library methods.
/// </summary>
public static partial class Al
{
    public static IntPtr MallocWithContext(ulong n, int line, string file, string func)
    {
        var nativeN = new UIntPtr(n);
        using var nativeFile = new CStringAnsi(file);
        using var nativeFunc = new CStringAnsi(func);
        return Interop.Core.AlMallocWithContext(nativeN, line, nativeFile.Pointer, nativeFunc.Pointer);
    }

    public static void FreeWithContext(IntPtr pointer, int line, string file, string func)
    {
        using var nativeFile = new CStringAnsi(file);
        using var nativeFunc = new CStringAnsi(func);
        Interop.Core.AlFreeWithContext(pointer, line, nativeFile.Pointer, nativeFunc.Pointer);
    }

    public static IntPtr ReallocWithContext(IntPtr pointer, ulong n, int line, string file, string func)
    {
        var nativeN = new UIntPtr(n);
        using var nativeFile = new CStringAnsi(file);
        using var nativeFunc = new CStringAnsi(func);
        return Interop.Core.AlReallocWithContext(pointer, nativeN, line, nativeFile.Pointer, nativeFunc.Pointer);
    }

    public static IntPtr CallocWithContext(ulong count, ulong n, int line, string file, string func)
    {
        var nativeCount = new UIntPtr(count);
        var nativeN = new UIntPtr(n);
        using var nativeFile = new CStringAnsi(file);
        using var nativeFunc = new CStringAnsi(func);
        return Interop.Core.AlCallocWithContext(nativeCount, nativeN, line, nativeFile.Pointer, nativeFunc.Pointer);
    }

    public static void SetMemoryInterface(AllegroMemoryInterface? memoryInterface)
    {
        if (memoryInterface is null)
            Interop.Core.AlSetMemoryInterface(IntPtr.Zero);
        else
        {
            var nativeSize = Marshal.SizeOf<AllegroMemoryInterface>();
            var nativeMemoryInterface = Marshal.AllocHGlobal(nativeSize);
            try
            {
                Marshal.StructureToPtr(memoryInterface, nativeMemoryInterface, false);
                Interop.Core.AlSetMemoryInterface(nativeMemoryInterface);
            }
            finally
            {
                Marshal.FreeHGlobal(nativeMemoryInterface);
            }
        }
    }
}
