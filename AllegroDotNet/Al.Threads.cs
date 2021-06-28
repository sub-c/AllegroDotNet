using System;
using System.Runtime.InteropServices;
using SubC.AllegroDotNet.Models;
using SubC.AllegroDotNet.Native;

namespace SubC.AllegroDotNet
{
    public static partial class Al
    {
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate IntPtr ThreadProcessDelegate(IntPtr nativeThread, IntPtr nativeArgument);

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate IntPtr DetachedThreadProcessDelegate(IntPtr nativeArgument);

        /// <summary>
        /// Spawn a new thread which begins executing the given process. The thread is passed its own thread handle
        /// and the argument given.
        /// </summary>
        /// <param name="process">The process to execute in a new thread.</param>
        /// <param name="argument">The argument passed to the new thread.</param>
        /// <returns>A new <see cref="AllegroThread"/> instance on success, otherwise null.</returns>
        public static AllegroThread CreateThread(ThreadProcessDelegate process, IntPtr argument)
        {
            var nativeThread = al_create_thread(process, argument);
            return nativeThread == IntPtr.Zero ? null : new AllegroThread { NativeIntPtr = nativeThread };
        }

        public static void StartThread(AllegroThread thread)
            => al_start_thread(thread.NativeIntPtr);

        public static void JoinThread(AllegroThread thread, ref IntPtr returnValue)
            => al_join_thread(thread.NativeIntPtr, ref returnValue);

        public static void SetThreadShouldStop(AllegroThread thread)
            => al_set_thread_should_stop(thread.NativeIntPtr);

        public static bool GetThreadShouldStop(AllegroThread thread)
            => al_get_thread_should_stop(thread.NativeIntPtr);

        public static void DestroyThread(AllegroThread thread)
            => al_destroy_thread(thread.NativeIntPtr);

        public static void RunDetachedThread(DetachedThreadProcessDelegate process, IntPtr argument)
            => al_run_detached_thread(process, argument);

        public static AllegroMutex CreateMutex()
        {
            var nativeMutex = al_create_mutex();
            return nativeMutex == IntPtr.Zero ? null : new AllegroMutex { NativeIntPtr = nativeMutex };
        }

        public static AllegroMutex CreateMutexRecursive()
        {
            var nativeMutex = al_create_mutex_recursive();
            return nativeMutex == IntPtr.Zero ? null : new AllegroMutex { NativeIntPtr = nativeMutex };
        }

        public static void LockMutex(AllegroMutex mutex)
            => al_lock_mutex(mutex.NativeIntPtr);

        public static void UnlockMutex(AllegroMutex mutex)
            => al_unlock_mutex(mutex.NativeIntPtr);

        public static void DestroyMutex(AllegroMutex mutex)
            => al_destroy_mutex(mutex.NativeIntPtr);

        public static AllegroCond CreateCond()
        {
            var nativeCond = al_create_cond();
            return nativeCond == IntPtr.Zero ? null : new AllegroCond { NativeIntPtr = nativeCond };
        }

        public static void DestroyCond(AllegroCond condition)
            => al_destroy_cond(condition.NativeIntPtr);

        public static void WaitCond(AllegroCond condition, AllegroMutex mutex)
            => al_wait_cond(condition.NativeIntPtr, mutex.NativeIntPtr);

        public static int WaitCondUntil(AllegroCond condition, AllegroMutex mutex, AllegroTimeout timeout)
            => al_wait_cond_until(condition.NativeIntPtr, mutex.NativeIntPtr, ref timeout.NativeTimeout);

        public static void BroadcastCond(AllegroCond condition)
            => al_broadcast_cond(condition.NativeIntPtr);

        public static void SignalCond(AllegroCond condition)
            => al_signal_cond(condition.NativeIntPtr);

        #region P/Invokes
        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern IntPtr al_create_thread(ThreadProcessDelegate proc, IntPtr arg);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern void al_start_thread(IntPtr thread);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern void al_join_thread(IntPtr thread, ref IntPtr ret_value);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern void al_set_thread_should_stop(IntPtr thread);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern bool al_get_thread_should_stop(IntPtr thread);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern void al_destroy_thread(IntPtr thread);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern void al_run_detached_thread(DetachedThreadProcessDelegate proc, IntPtr arg);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern IntPtr al_create_mutex();

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern IntPtr al_create_mutex_recursive();

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern void al_lock_mutex(IntPtr mutex);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern void al_unlock_mutex(IntPtr mutex);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern void al_destroy_mutex(IntPtr mutex);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern IntPtr al_create_cond();

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern void al_destroy_cond(IntPtr cond);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern void al_wait_cond(IntPtr cond, IntPtr mutex);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern int al_wait_cond_until(IntPtr cond, IntPtr mutex, ref NativeAllegroTimeout timeout);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern void al_broadcast_cond(IntPtr cond);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern void al_signal_cond(IntPtr cond);
        #endregion
    }
}
