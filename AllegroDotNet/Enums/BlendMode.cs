namespace SubC.AllegroDotNet.Enums
{
    /// <summary>
    /// The factors used when drawing in blending modes.
    /// </summary>
    public enum BlendMode : int
    {
        /// <summary>
        /// f = 0, 0, 0, 0
        /// </summary>
        Zero = 0,

        /// <summary>
        /// f = 1, 1, 1, 1
        /// </summary>
        One = 1,

        /// <summary>
        /// f = s.a, s.a, s.a, s.a
        /// </summary>
        Alpha = 2,

        /// <summary>
        /// f = 1 - s.a, 1 - s.a, 1 - s.a, 1 - s.a
        /// </summary>
        InverseAlpha = 3,

        /// <summary>
        /// f = s.r, s.g, s.b, s.a
        /// </summary>
        SourceColor = 4,

        /// <summary>
        /// f = d.r, d.g, d.b, d.a
        /// </summary>
        DestinationColor = 5,

        /// <summary>
        /// f = 1 - s.r, 1 - s.g, 1 - s.b, 1 - s.a
        /// </summary>
        InverseSourceColor = 6,

        /// <summary>
        /// f = 1 - d.r, 1 - d.g, 1 - d.b, 1 - d.a
        /// </summary>
        InverseDestinationColor = 7,

        /// <summary>
        /// f = cc.r, cc.g, cc.b, cc.a
        /// </summary>
        ConstantColor = 8,

        /// <summary>
        /// f = 1 - cc.r, 1 - cc.g, 1 - cc.b, 1 - cc.a
        /// </summary>
        InverseConstantColor = 9,

        /// <summary>
        /// The total number of blend modes.
        /// </summary>
        NumBlendModes
    }
}
