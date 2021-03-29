namespace AllegroDotNet
{
    /// <summary>
    /// Useful functions from Allegro that natively were implemented as C macros.
    /// </summary>
    public static class Macros
    {
        /// <summary>
        /// Convert beats per minute to seconds.
        /// </summary>
        /// <param name="bpm">Beats per minute.</param>
        /// <returns>Converted seconds.</returns>
        public static double BpmToSecs(double bpm)
            => 60.0 / bpm;

        /// <summary>
        /// Converts beats per second to seconds.
        /// </summary>
        /// <param name="bps">Beats per second.</param>
        /// <returns>Converted seconds.</returns>
        public static double BpsToSecs(double bps)
            => 1.0 / bps;

        /// <summary>
        /// Make an event type identifier, which is a 32-bit integer. Usually, but not necessarily, this will be made
        /// from four 8-bit character codes, for example:
        /// <para>
        /// <c>var myEventType = GetEventType('M','I','N','E');</c>
        /// </para>
        /// <para>
        /// IDs less than 1024 are reserved for Allegro or its addons. Don't use anything lower than:
        /// <c>(0, 0, 4, 0)</c>
        /// </para>
        /// <para>
        /// You should try to make your IDs unique so they don't clash with any 3rd party code you may be using.
        /// Be creative. Numbering from 1024 is not creative.
        /// </para>
        /// </summary>
        /// <param name="a">First identifier.</param>
        /// <param name="b">Second identifier.</param>
        /// <param name="c">Third identifier.</param>
        /// <param name="d">Fourth identifier.</param>
        /// <returns>A identifer, for user events.</returns>
        public static int GetEventType(char a, char b, char c, char d)
            => ((a) << 24) | ((b) << 16) | ((c) << 8) | (d);

        /// <summary>
        /// Convert milliseconds to seconds.
        /// </summary>
        /// <param name="msecs">Amount of milliseconds.</param>
        /// <returns>Converted seconds.</returns>
        public static double MSecsToSecs(double msecs)
            => msecs / 1000.0;

        /// <summary>
        /// Convert microseconds to seconds.
        /// </summary>
        /// <param name="usecs">Amount of microseconds.</param>
        /// <returns>Converted seconds.</returns>
        public static double USecsToSecs(double usecs)
            => usecs / 1000000.0;
    }
}
