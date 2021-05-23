namespace SubC.AllegroDotNet.Enums
{
    /// <summary>
    /// Speaker configuration (mono, stereo, 2.1, etc).
    /// </summary>
    public enum ChannelConf : int
    {
        Unknown = 0,
        Conf1 = 0x10,
        Conf2 = 0x20,
        Conf3 = 0x30,
        Conf4 = 0x40,
        Conf5_1 = 0x51,
        Conf6_1 = 0x61,
        Conf7_1 = 0x71,
        MaxChannels = 8
    }
}
