namespace SubC.AllegroDotNet.Enums
{
    /// <summary>
    /// The conceptional formula used by Allegro to draw any pixel in blending modes.
    /// </summary>
    public enum BlendOperation : int
    {
        /// <summary>
        /// _ = d.r * df.r + s.r * sf.r
        /// </summary>
        Add = 0,

        /// <summary>
        /// _ = d.r * df.r - s.r * sf.r
        /// </summary>
        SourceMinusDestination = 1,

        /// <summary>
        /// _ = s.r * sf.r - d.r * df.r
        /// </summary>
        DestinationMinusSource = 2,

        /// <summary>
        /// Total number of blend operations.
        /// </summary>
        NumBlendOperations
    }
}
