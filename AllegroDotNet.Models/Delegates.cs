using System.Runtime.InteropServices;

namespace AllegroDotNet.Models
{
    public static class Delegates
    {
        public delegate void AssertHandler(
            [MarshalAs(UnmanagedType.LPStr)]string expr,
            [MarshalAs(UnmanagedType.LPStr)] string file,
            int line,
            [MarshalAs(UnmanagedType.LPStr)] string func);
        public delegate int AtExit(AtExitHandler atExitHandler);
        public delegate void AtExitHandler();
        public delegate void TraceHandler([MarshalAs(UnmanagedType.LPStr)] string trace);
    }
}
