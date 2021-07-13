using System;
using SubC.AllegroDotNet.Models;
using SubC.AllegroDotNet.Native.Libraries;

namespace SubC.AllegroDotNet
{
    public static partial class Al
    {
        /// <summary>
        /// Spawn a new thread which begins executing the given process. The thread is passed its own thread handle
        /// and the argument given.
        /// </summary>
        /// <param name="process">The process to execute in a new thread.</param>
        /// <param name="argument">The argument passed to the new thread.</param>
        /// <returns>A new <see cref="AllegroThread"/> instance on success, otherwise null.</returns>
        public static AllegroThread CreateThread(AlConstants.ThreadProcessDelegate process, IntPtr argument)
        {
            var nativeThread = AllegroLibrary.AlCreateThread(process, argument);
            return nativeThread == IntPtr.Zero ? null : new AllegroThread { NativeIntPtr = nativeThread };
        }

        public static void StartThread(AllegroThread thread) =>
            AllegroLibrary.AlStartThread(thread.NativeIntPtr);

        public static void JoinThread(AllegroThread thread, ref IntPtr returnValue) =>
            AllegroLibrary.AlJoinThread(thread.NativeIntPtr, ref returnValue);

        public static void SetThreadShouldStop(AllegroThread thread) =>
            AllegroLibrary.AlSetThreadShouldStop(thread.NativeIntPtr);

        public static bool GetThreadShouldStop(AllegroThread thread) =>
            AllegroLibrary.AlGetThreadShouldStop(thread.NativeIntPtr);

        public static void DestroyThread(AllegroThread thread) =>
            AllegroLibrary.AlDestroyThread(thread.NativeIntPtr);

        public static void RunDetachedThread(AlConstants.DetachedThreadProcessDelegate process, IntPtr argument) =>
            AllegroLibrary.AlRunDetachedThread(process, argument);

        public static AllegroMutex CreateMutex()
        {
            var nativeMutex = AllegroLibrary.AlCreateMutex();
            return nativeMutex == IntPtr.Zero ? null : new AllegroMutex { NativeIntPtr = nativeMutex };
        }

        public static AllegroMutex CreateMutexRecursive()
        {
            var nativeMutex = AllegroLibrary.AlCreateMutexRecursive();
            return nativeMutex == IntPtr.Zero ? null : new AllegroMutex { NativeIntPtr = nativeMutex };
        }

        public static void LockMutex(AllegroMutex mutex) =>
            AllegroLibrary.AlLockMutex(mutex.NativeIntPtr);

        public static void UnlockMutex(AllegroMutex mutex) =>
            AllegroLibrary.AlUnlockMutex(mutex.NativeIntPtr);

        public static void DestroyMutex(AllegroMutex mutex) =>
            AllegroLibrary.AlDestroyMutex(mutex.NativeIntPtr);

        public static AllegroCond CreateCond()
        {
            var nativeCond = AllegroLibrary.AlCreateCond();
            return nativeCond == IntPtr.Zero ? null : new AllegroCond { NativeIntPtr = nativeCond };
        }

        public static void DestroyCond(AllegroCond condition) =>
            AllegroLibrary.AlDestroyCond(condition.NativeIntPtr);

        public static void WaitCond(AllegroCond condition, AllegroMutex mutex) =>
            AllegroLibrary.AlWaitCond(condition.NativeIntPtr, mutex.NativeIntPtr);

        public static int WaitCondUntil(AllegroCond condition, AllegroMutex mutex, AllegroTimeout timeout) =>
            AllegroLibrary.AlWaitCondUntil(condition.NativeIntPtr, mutex.NativeIntPtr, ref timeout.NativeTimeout);

        public static void BroadcastCond(AllegroCond condition) =>
            AllegroLibrary.AlBroadcastCond(condition.NativeIntPtr);

        public static void SignalCond(AllegroCond condition) =>
            AllegroLibrary.AlSignalCond(condition.NativeIntPtr);

        #region P/Invokes
        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //private static extern IntPtr al_create_thread(AlConstants.ThreadProcessDelegate proc, IntPtr arg);

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //private static extern void al_start_thread(IntPtr thread);

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //private static extern void al_join_thread(IntPtr thread, ref IntPtr ret_value);

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //private static extern void al_set_thread_should_stop(IntPtr thread);

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //private static extern bool al_get_thread_should_stop(IntPtr thread);

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //private static extern void al_destroy_thread(IntPtr thread);

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //private static extern void al_run_detached_thread(AlConstants.DetachedThreadProcessDelegate proc, IntPtr arg);

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //private static extern IntPtr al_create_mutex();

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //private static extern IntPtr al_create_mutex_recursive();

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //private static extern void al_lock_mutex(IntPtr mutex);

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //private static extern void al_unlock_mutex(IntPtr mutex);

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //private static extern void al_destroy_mutex(IntPtr mutex);

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //private static extern IntPtr al_create_cond();

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //private static extern void al_destroy_cond(IntPtr cond);

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //private static extern void al_wait_cond(IntPtr cond, IntPtr mutex);

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //private static extern int al_wait_cond_until(IntPtr cond, IntPtr mutex, ref NativeAllegroTimeout timeout);

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //private static extern void al_broadcast_cond(IntPtr cond);

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //private static extern void al_signal_cond(IntPtr cond);
        #endregion
    }
}
