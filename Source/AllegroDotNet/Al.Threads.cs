using SubC.AllegroDotNet.Models;
using SubC.AllegroDotNet.Native;
using System;

namespace SubC.AllegroDotNet
{
  public static partial class Al
  {
    public static AllegroThread? CreateThread(NativeDelegates.ThreadProcess process, IntPtr arg)
    {
      var nativeThread = NativeFunctions.AlCreateThread(process, arg);
      return NativePointerModel.Create<AllegroThread>(nativeThread);
    }

    public static void StartThread(AllegroThread? thread)
    {
      NativeFunctions.AlStartThread(NativePointerModel.GetPointer(thread));
    }

    public static void JoinThread(AllegroThread? thread, ref IntPtr returnValue)
    {
      NativeFunctions.AlJoinThread(NativePointerModel.GetPointer(thread), ref returnValue);
    }

    public static void SetThreadShouldStop(AllegroThread? thread)
    {
      NativeFunctions.AlSetThreadShouldStop(NativePointerModel.GetPointer(thread));
    }

    public static bool GetThreadShouldStop(AllegroThread? thread)
    {
      return NativeFunctions.AlGetThreadShouldStop(NativePointerModel.GetPointer(thread));
    }

    public static void DestroyThread(AllegroThread? thread)
    {
      NativeFunctions.AlDestroyThread(NativePointerModel.GetPointer(thread));
    }

    public static void RunDetachedThread(NativeDelegates.DetachedThreadProcess process, IntPtr arg)
    {
      NativeFunctions.AlRunDetachedThread(process, arg);
    }

    public static AllegroMutex? CreateMutex()
    {
      var nativeMutex = NativeFunctions.AlCreateMutex();
      return NativePointerModel.Create<AllegroMutex>(nativeMutex);
    }

    public static AllegroMutex? CreateMutexRecursive()
    {
      var nativeMutex = NativeFunctions.AlCreateMutexRecursive();
      return NativePointerModel.Create<AllegroMutex>(nativeMutex);
    }

    public static void LockMutex(AllegroMutex? mutex)
    {
      NativeFunctions.AlLockMutex(NativePointerModel.GetPointer(mutex));
    }

    public static void UnlockMutex(AllegroMutex? mutex)
    {
      NativeFunctions.AlUnlockMutex(NativePointerModel.GetPointer(mutex));
    }

    public static void DestroyMutex(AllegroMutex? mutex)
    {
      NativeFunctions.AlDestroyMutex(NativePointerModel.GetPointer(mutex));
    }

    public static AllegroCond? CreateCond()
    {
      var nativeCond = NativeFunctions.AlCreateCond();
      return NativePointerModel.Create<AllegroCond>(nativeCond);
    }

    public static void DestroyCond(AllegroCond? condition)
    {
      NativeFunctions.AlDestroyCond(NativePointerModel.GetPointer(condition));
    }

    public static void WaitCond(AllegroCond? condition, AllegroMutex? mutex)
    {
      NativeFunctions.AlWaitCond(NativePointerModel.GetPointer(condition), NativePointerModel.GetPointer(mutex));
    }

    public static int WaitCondUntil(AllegroCond? condition, AllegroMutex? mutex, AllegroTimeout timeout)
    {
      return NativeFunctions.AlWaitCondUntil(NativePointerModel.GetPointer(condition), NativePointerModel.GetPointer(mutex), ref timeout.NativeTimeout);
    }

    public static void BroadcastCond(AllegroCond? condition)
    {
      NativeFunctions.AlBroadcastCond(NativePointerModel.GetPointer(condition));
    }

    public static void SignalCond(AllegroCond? condition)
    {
      NativeFunctions.AlSignalCond(NativePointerModel.GetPointer(condition));
    }
  }
}