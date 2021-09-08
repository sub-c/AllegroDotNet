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

        /// <summary>
        /// When a thread is created, it is initially in a suspended state. Calling
        /// <see cref="StartThread(AllegroThread)"/> will start its actual execution. Starting a thread which has
        /// already been started does nothing.
        /// </summary>
        /// <param name="thread">The thread instance.</param>
        public static void StartThread(AllegroThread thread) =>
            AllegroLibrary.AlStartThread(thread.NativeIntPtr);

        /// <summary>
        /// Wait for the thread to finish executing. This implicitly calls
        /// <see cref="SetThreadShouldStop(AllegroThread)"/> first.
        /// <para>
        /// If returnValue is non-<c>null</c>, the value returned by the thread function will be stored at the
        /// location pointed to by returnValue.
        /// </para>
        /// </summary>
        /// <param name="thread">The thread instance.</param>
        /// <param name="returnValue">If non-<c>null</c>, will store the return value from the thread.</param>
        public static void JoinThread(AllegroThread thread, ref IntPtr returnValue) =>
            AllegroLibrary.AlJoinThread(thread.NativeIntPtr, ref returnValue);

        /// <summary>
        /// Set the flag to indicate thread should stop. Returns immediately.
        /// </summary>
        /// <param name="thread">The thread instance.</param>
        public static void SetThreadShouldStop(AllegroThread thread) =>
            AllegroLibrary.AlSetThreadShouldStop(thread.NativeIntPtr);

        /// <summary>
        /// Check if another thread is waiting for thread to stop. Threads which run in a loop should check this
        /// periodically and act on it when convenient.
        /// </summary>
        /// <param name="thread">The thread instance.</param>
        /// <returns>
        /// True if <see cref="SetThreadShouldStop(AllegroThread)"/> or
        /// <see cref="JoinThread(AllegroThread, ref IntPtr)"/> was called on the thread.
        /// </returns>
        public static bool GetThreadShouldStop(AllegroThread thread) =>
            AllegroLibrary.AlGetThreadShouldStop(thread.NativeIntPtr);

        /// <summary>
        /// Free the resources used by a thread. Implicitly performs
        /// <see cref="JoinThread(AllegroThread, ref IntPtr)"/> on the thread if it hasn’t been done already. Does
        /// nothing if thread is <c>null</c>.
        /// </summary>
        /// <param name="thread"></param>
        public static void DestroyThread(AllegroThread thread)
        {
            var nativeThread = thread == null ? IntPtr.Zero : thread.NativeIntPtr;
            AllegroLibrary.AlDestroyThread(nativeThread);
        }

        /// <summary>
        /// Runs the passed function in its own thread, with arg passed to it as only parameter. This is similar
        /// to calling <see cref="CreateThread(AlConstants.ThreadProcessDelegate, IntPtr)"/>,
        /// <see cref="StartThread(AllegroThread)"/> and (after the thread has finished)
        /// <see cref="DestroyThread(AllegroThread)"/> - but you don’t have the possibility of ever calling
        /// <see cref="JoinThread(AllegroThread, ref IntPtr)"/> on the thread.
        /// </summary>
        /// <param name="process">The process delegate.</param>
        /// <param name="argument">The argument to pass.</param>
        public static void RunDetachedThread(AlConstants.DetachedThreadProcessDelegate process, IntPtr argument) =>
            AllegroLibrary.AlRunDetachedThread(process, argument);

        /// <summary>
        /// Create the mutex object (a mutual exclusion device). The mutex may or may not support “recursive” locking.
        /// </summary>
        /// <returns>Returns the mutex on success or <c>null</c> on error.</returns>
        public static AllegroMutex CreateMutex()
        {
            var nativeMutex = AllegroLibrary.AlCreateMutex();
            return nativeMutex == IntPtr.Zero ? null : new AllegroMutex { NativeIntPtr = nativeMutex };
        }

        /// <summary>
        /// Create the mutex object (a mutual exclusion device), with support for “recursive” locking. That is, the
        /// mutex will count the number of times it has been locked by the same thread. If the caller tries to
        /// acquire a lock on the mutex when it already holds the lock then the count is incremented. The mutex is
        /// only unlocked when the thread releases the lock on the mutex an equal number of times, i.e. the count
        /// drops down to zero.
        /// </summary>
        /// <returns>Returns the mutex on success or <c>null</c> on error.</returns>
        public static AllegroMutex CreateMutexRecursive()
        {
            var nativeMutex = AllegroLibrary.AlCreateMutexRecursive();
            return nativeMutex == IntPtr.Zero ? null : new AllegroMutex { NativeIntPtr = nativeMutex };
        }

        /// <summary>
        /// Acquire the lock on mutex. If the mutex is already locked by another thread, the call will block until
        /// the mutex becomes available and locked.
        /// <para>
        /// If the mutex is already locked by the calling thread, then the behaviour depends on whether the mutex was
        /// created with <see cref="CreateMutex"/> or <see cref="CreateMutexRecursive"/>. In the former case, the
        /// behaviour is undefined; the most likely behaviour is deadlock. In the latter case, the count in the mutex
        /// will be incremented and the call will return immediately.
        /// </para>
        /// </summary>
        /// <param name="mutex">The mutex instance.</param>
        public static void LockMutex(AllegroMutex mutex) =>
            AllegroLibrary.AlLockMutex(mutex.NativeIntPtr);

        /// <summary>
        /// Release the lock on mutex if the calling thread holds the lock on it. If the calling thread doesn’t hold
        /// the lock, or if the mutex is not locked, undefined behaviour results.
        /// </summary>
        /// <param name="mutex"></param>
        public static void UnlockMutex(AllegroMutex mutex) =>
            AllegroLibrary.AlUnlockMutex(mutex.NativeIntPtr);

        /// <summary>
        /// Free the resources used by the mutex. The mutex should be unlocked. Destroying a locked mutex results
        /// in undefined behaviour. Does nothing if mutex is <c>null</c>.
        /// </summary>
        /// <param name="mutex"></param>
        public static void DestroyMutex(AllegroMutex mutex)
        {
            var nativeMutex = mutex == null ? IntPtr.Zero : mutex.NativeIntPtr;
            AllegroLibrary.AlDestroyMutex(nativeMutex);
        }

        /// <summary>
        /// Create a condition variable.
        /// </summary>
        /// <returns>Returns the condition value on success or <c>null</c> on error.</returns>
        public static AllegroCond CreateCond()
        {
            var nativeCond = AllegroLibrary.AlCreateCond();
            return nativeCond == IntPtr.Zero ? null : new AllegroCond { NativeIntPtr = nativeCond };
        }

        /// <summary>
        /// Destroy a condition variable. Destroying a condition variable which has threads block on it results in
        /// undefined behaviour. Does nothing if cond is <c>null</c>.
        /// </summary>
        /// <param name="condition">The condition instance.</param>
        public static void DestroyCond(AllegroCond condition)
        {
            var nativeCondition = condition == null ? IntPtr.Zero : condition.NativeIntPtr;
            AllegroLibrary.AlDestroyCond(nativeCondition);
        }

        /// <summary>
        /// On entering this function, mutex must be locked by the calling thread. The function will atomically release
        /// mutex and block on cond. The function will return when cond is “signalled”, acquiring the lock on the mutex
        /// in the process.
        /// <para>
        /// The mutex should be locked before checking the condition, and should be rechecked
        /// <see cref="WaitCond(AllegroCond, AllegroMutex)"/> returns. 
        /// <see cref="WaitCond(AllegroCond, AllegroMutex)"/> can return for other reasons than the condition becoming
        /// true (e.g. the process was signalled). If multiple threads are blocked on the condition variable, the
        /// condition may no longer be true by the time the second and later threads are unblocked. Remember not to
        /// unlock the mutex prematurely.
        /// </para>
        /// </summary>
        /// <param name="condition">The condition instance.</param>
        /// <param name="mutex">The mutex instance.</param>
        public static void WaitCond(AllegroCond condition, AllegroMutex mutex) =>
            AllegroLibrary.AlWaitCond(condition.NativeIntPtr, mutex.NativeIntPtr);

        /// <summary>
        /// Like <see cref="WaitCond(AllegroCond, AllegroMutex)"/> but the call can return if the absolute time passes
        /// timeout before the condition is signalled.
        /// </summary>
        /// <param name="condition">The condition instance.</param>
        /// <param name="mutex">The mutex instance.</param>
        /// <param name="timeout">The timeout instance.</param>
        /// <returns>Returns zero on success, non-zero if the call timed out.</returns>
        public static int WaitCondUntil(AllegroCond condition, AllegroMutex mutex, AllegroTimeout timeout) =>
            AllegroLibrary.AlWaitCondUntil(condition.NativeIntPtr, mutex.NativeIntPtr, ref timeout.NativeTimeout);

        /// <summary>
        /// Unblock all threads currently waiting on a condition variable. That is, broadcast that some condition which
        /// those threads were waiting for has become true.
        /// <para>
        /// Note: The pthreads spec says to lock the mutex associated with cond before signalling for predictable
        /// scheduling behaviour.
        /// </para>
        /// </summary>
        /// <param name="condition">The condition instance.</param>
        public static void BroadcastCond(AllegroCond condition) =>
            AllegroLibrary.AlBroadcastCond(condition.NativeIntPtr);

        /// <summary>
        /// Unblock at least one thread waiting on a condition variable.
        /// </summary>
        /// <param name="condition">The condition instance.</param>
        public static void SignalCond(AllegroCond condition) =>
            AllegroLibrary.AlSignalCond(condition.NativeIntPtr);
    }
}
