namespace SubC.AllegroDotNet.Enums
{
    /// <summary>
    /// Mixer quality flags.
    /// </summary>
    public enum MixerQuality : int
    {
        /// <summary>
        /// point sampling
        /// </summary>
        Point = 0x110,

        /// <summary>
        /// linear interpolation
        /// </summary>
        Linear = 0x111,

        /// <summary>
        /// cubic interpolation
        /// </summary>
        Cubic = 0x112
    }
}
