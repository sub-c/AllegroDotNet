namespace AllegroDotNet.Enums
{
    /// <summary>
    /// Sample and stream playback mode.
    /// </summary>
    public enum PlayMode : int
    {
        Unknown = 0,

        /// <summary>
        /// the sample/stream is played from start to finish an then it stops.
        /// </summary>
        Once = 0x100,

        /// <summary>
        /// the sample/stream is played from start to finish (or between the two loop points).
        /// When it reaches the end, it restarts from the beginning.
        /// </summary>
        Loop = 0x101,

        /// <summary>
        /// the sample is played from start to finish (or between the two loop points). When it reaches the end,
        /// it reverses the playback direction and plays until it reaches the beginning when it reverses the direction
        /// back to normal. This is mode is rarely supported for streams.
        /// </summary>
        BiDir = 0x102,
    }
}
