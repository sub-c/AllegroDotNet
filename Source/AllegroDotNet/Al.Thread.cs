using SubC.AllegroDotNet.Models;
using SubC.AllegroDotNet.Native;

namespace SubC.AllegroDotNet;

/// <summary>
/// This static class contains the Allegro 5 library methods.
/// </summary>
public static partial class Al
{
    public static AllegroThread? CreateThread(Delegates.ThreadExecutionDelegate proc, IntPtr arg)
    {
        var pointer = Interop.Core.AlCreateThread(proc, arg);
        return NativePointer.Create<AllegroThread>(pointer);
    }

    public static void StartThread(AllegroThread? thread)
    {
        Interop.Core.AlStartThread(NativePointer.Get(thread));
    }

    public static void JoinThread(AllegroThread? thread, ref IntPtr returnedPointer)
    {
        Interop.Core.AlJoinThread(NativePointer.Get(thread), ref returnedPointer);
    }

    public static void SetThreadShouldStop(AllegroThread? thread)
    {
        Interop.Core.AlSetThreadShouldStop(NativePointer.Get(thread));
    }

    public static bool GetThreadShouldStop(AllegroThread? thread)
    {
        return Interop.Core.AlGetThreadShouldStop(NativePointer.Get(thread)) != 0;
    }

    public static void DestroyThread(AllegroThread? thread)
    {
        Interop.Core.AlDestroyThread(NativePointer.Get(thread));
    }

    public static void RunDetachedThread(Delegates.ThreadDetachedExecutionDelegate proc, IntPtr arg)
    {
        Interop.Core.AlRunDetachedThread(proc, arg);
    }

    public static AllegroMutex? CreateMutex()
    {
        var pointer = Interop.Core.AlCreateMutex();
        return NativePointer.Create<AllegroMutex>(pointer);
    }

    public static AllegroMutex? CreateMutexRecursive()
    {
        var pointer = Interop.Core.AlCreateMutexRecursive();
        return NativePointer.Create<AllegroMutex>(pointer);
    }

    public static void LockMutex(AllegroMutex? mutex)
    {
        Interop.Core.AlLockMutex(NativePointer.Get(mutex));
    }

    public static void UnlockMutex(AllegroMutex? mutex)
    {
        Interop.Core.AlUnlockMutex(NativePointer.Get(mutex));
    }

    public static void DestroyMutex(AllegroMutex? mutex)
    {
        Interop.Core.AlDestroyMutex(NativePointer.Get(mutex));
    }

    public static AllegroCond? CreateCond()
    {
        var pointer = Interop.Core.AlCreateCond();
        return NativePointer.Create<AllegroCond>(pointer);
    }

    public static void DestroyCond(AllegroCond? cond)
    {
        Interop.Core.AlDestroyCond(NativePointer.Get(cond));
    }

    public static void WaitCond(AllegroCond? cond, AllegroMutex? mutex)
    {
        Interop.Core.AlWaitCond(NativePointer.Get(cond), NativePointer.Get(mutex));
    }

    public static int WaitCondUntil(AllegroCond? cond, AllegroMutex? mutex, ref AllegroTimeout timeout)
    {
        return Interop.Core.AlWaitCondUntil(NativePointer.Get(cond), NativePointer.Get(mutex), ref timeout);
    }

    public static void BroadcastCond(AllegroCond? cond)
    {
        Interop.Core.AlBroadcastCond(NativePointer.Get(cond));
    }

    public static void SignalCond(AllegroCond? cond)
    {
        Interop.Core.AlSignalCond(NativePointer.Get(cond));
    }
}
