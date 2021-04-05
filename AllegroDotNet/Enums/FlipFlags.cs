namespace AllegroDotNet.Enums
{
    public enum FlipFlags : int
    {
        /// <summary>
        /// Do not flip the bitmap on any axis.
        /// </summary>
        None = 0,

        /// <summary>
        /// Flip the bitmap about the y-axis.
        /// </summary>
        Horizontal = 0x00001,

        /// <summary>
        /// Flip the bitmap about the x-axis.
        /// </summary>
        Vertical = 0x00002
    }
}
