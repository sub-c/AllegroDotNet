namespace SubC.AllegroDotNet.Enums
{
    /// <summary>
    /// Used when locking a bitmap for reading or writing.
    /// </summary>
    public enum LockFlags : int
    {
        /// <summary>
        /// The locked region can be written to and read from. Use this flag if a partial number of pixels need to be
        /// written to, even if reading is not needed.
        /// </summary>
        ReadWrite = 0,

        /// <summary>
        /// The locked region will not be written to. This can be faster if the bitmap is a video texture, as it can
        /// be discarded after the lock instead of uploaded back to the card.
        /// </summary>
        ReadOnly = 1,

        /// <summary>
        /// The locked region will not be read from. This can be faster if the bitmap is a video texture, as no data
        /// need to be read from the video card. You are required to fill in all pixels before unlocking the bitmap
        /// again, so be careful when using this flag.
        /// </summary>
        WriteOnly = 2
    }
}
