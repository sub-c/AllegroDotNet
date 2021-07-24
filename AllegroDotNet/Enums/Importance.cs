namespace SubC.AllegroDotNet.Enums
{
    /// <summary>
    /// The importance of a flag.
    /// </summary>
    public enum Importance : int
    {
        /// <summary>
        ///  Do not care if flag is set.
        /// </summary>
        DontCare = 0,

        /// <summary>
        /// Require the flag, and fail if it cannot succeed.
        /// </summary>
        Require,

        /// <summary>
        /// Suggest the flag, but do not fail if it cannot succeed.
        /// </summary>
        Suggest
    }
}
