namespace AllegroDotNet.Models
{
    public static class Delegates
    {
        public delegate void AssertHandler(string expr, string file, int line, string func);
        public delegate int AtExit(AtExitHandler atExitHandler);
        public delegate void AtExitHandler();
        public delegate void TraceHandler(string trace);
    }
}
