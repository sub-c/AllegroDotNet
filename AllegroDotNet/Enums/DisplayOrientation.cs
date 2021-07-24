namespace SubC.AllegroDotNet.Enums
{
    /// <summary>
    /// The display orientation/rotation.
    /// </summary>
    public enum DisplayOrientation : int
    {
        /// <summary>
        /// Unknown orientation.
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// Display is not rotated.
        /// </summary>
        Degrees0 = 1,

        /// <summary>
        /// Dispay is rotated 90 degrees.
        /// </summary>
        Degrees90 = 2,

        /// <summary>
        /// Display is rotated 180 degrees.
        /// </summary>
        Degrees180 = 4,

        /// <summary>
        /// Display is rotated 270 degrees.
        /// </summary>
        Degrees270 = 8,

        /// <summary>
        /// Display is in portrait mode.
        /// </summary>
        Portrait = 5,

        /// <summary>
        /// Display is in landscape mode.
        /// </summary>
        Landscape = 10,

        /// <summary>
        /// Display is in all mode.
        /// </summary>
        All = 15,

        /// <summary>
        /// Display is facing up.
        /// </summary>
        FaceUp = 16,

        /// <summary>
        /// Display is facing down.
        /// </summary>
        FaceDown = 32
    }
}
