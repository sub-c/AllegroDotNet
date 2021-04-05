namespace AllegroDotNet.Enums
{
    /// <summary>
    /// The factors used when drawing in blending modes.
    /// </summary>
    public enum BlendMode : int
    {
        Zero = 0,
        One = 1,
        Alpha = 2,
        InverseAlpha = 3,
        SourceColor = 4,
        DestinationColor = 5,
        InverseSourceColor = 6,
        InverseDestinationColor = 7,
        ConstantColor = 8,
        InverseConstantColor = 9,
        NumBlendModes
    }
}
