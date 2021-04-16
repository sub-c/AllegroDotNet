namespace AllegroDotNet.Enums
{
    /// <summary>
    /// Specifies what file seeks are relative to.
    /// </summary>
    public enum Seek : int
    {
        /// <summary>
        /// Seek relative to beginning of file
        /// </summary>
        Set = 0,

        /// <summary>
        /// Seek relative to current file position
        /// </summary>
        Cur,

        /// <summary>
        /// Seek relative to end of file
        /// </summary>
        End
    }
}
