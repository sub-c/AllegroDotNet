using System.Runtime.InteropServices;

namespace SubC.AllegroDotNet.Models
{
    /// <summary>
    /// This class contains delegates used as function pointers for Allegro.
    /// </summary>
    public static class Delegates
    {
        /// <summary>
        /// A delegate to be used as an assert handler by Allegro.
        /// </summary>
        /// <param name="expr">The expression causing the assert to fail.</param>
        /// <param name="file">The file causing the assert to fail.</param>
        /// <param name="line">The line causing the assert to fail.</param>
        /// <param name="func">The function name causing the assert to fail.</param>
        public delegate void AssertHandler(
            [MarshalAs(UnmanagedType.LPStr)] string expr,
            [MarshalAs(UnmanagedType.LPStr)] string file,
            int line,
            [MarshalAs(UnmanagedType.LPStr)] string func);

        /// <summary>
        /// A delegate to be used by <see cref="Al.InstallSystem(int)"/>.
        /// </summary>
        /// <param name="atExitHandler">The method to be called at program exit.</param>
        /// <returns>The error code to return.</returns>
        public delegate int AtExit(AtExitHandler atExitHandler);

        /// <summary>
        /// A delegate to be used by <see cref="AtExit"/>.
        /// </summary>
        public delegate void AtExitHandler();

        /// <summary>
        /// A delegate to be used by <see cref="Al.RegisterTraceHandler(TraceHandler)"/> for tracing.
        /// </summary>
        /// <param name="trace">The trace string.</param>
        public delegate void TraceHandler([MarshalAs(UnmanagedType.LPStr)] string trace);
    }
}
