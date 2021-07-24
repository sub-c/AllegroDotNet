namespace SubC.AllegroDotNet.Enums
{
    /// <summary>
    /// Speaker configuration (mono, stereo, 2.1, etc).
    /// </summary>
    public enum ChannelConf : int
    {
        /// <summary>
        /// Unknown.
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// Mono.
        /// </summary>
        Conf1 = 0x10,

        /// <summary>
        /// Stereo.
        /// </summary>
        Conf2 = 0x20,

        /// <summary>
        /// 2.1 audio.
        /// </summary>
        Conf3 = 0x30,

        /// <summary>
        /// Four speakers.
        /// </summary>
        Conf4 = 0x40,

        /// <summary>
        /// 5.1 audio.
        /// </summary>
        Conf5_1 = 0x51,

        /// <summary>
        /// 6.1 audio.
        /// </summary>
        Conf6_1 = 0x61,

        /// <summary>
        /// 7.1 audio.
        /// </summary>
        Conf7_1 = 0x71,

        /// <summary>
        /// Maximum amount of channels supported.
        /// </summary>
        MaxChannels = 8
    }
}
