namespace SubC.AllegroDotNet.Enums
{
    /// <summary>
    /// The conceptional formula used by Allegro to draw any pixel in blending modes.
    /// </summary>
    public enum BlendOperation : int
    {
        Add = 0,
        SourceMinusDestination = 1,
        DestinationMinusSource = 2,
        NumBlendOperations
    }
}
