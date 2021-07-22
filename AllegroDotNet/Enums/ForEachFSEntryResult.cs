namespace SubC.AllegroDotNet.Enums
{
    /// <summary>
    /// Return values for the callbacks of <see cref="ForEachFSEntryResult"/> and for that function itself.
    /// </summary>
    public enum ForEachFSEntryResult : int
    {
        /// <summary>
        /// An error ocurred.
        /// </summary>
        Error = -1,

        /// <summary>
        /// Continue normally and recurse into directories.
        /// </summary>
        OK = 0,

        /// <summary>
        /// Continue but do NOT recusively descend.
        /// </summary>
        Skip = 1,

        /// <summary>
        /// Stop iterating and return.
        /// </summary>
        Stop = 2
    }
}
