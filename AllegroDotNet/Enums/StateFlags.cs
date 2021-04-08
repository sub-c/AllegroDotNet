namespace AllegroDotNet.Enums
{
    /// <summary>
    /// Defines what part of the state of the current thread is stored in a given ALLEGRO_STATE object.
    /// </summary>
    public enum StateFlags : int
    {
        /// <summary>
        /// new_display_format, new_display_refresh_rate, new_display_flags
        /// </summary>
        NewDisplayParameters = 0x0001,

        /// <summary>
        /// new_bitmap_format, new_bitmap_flags
        /// </summary>
        NewBitmapParameters = 0x0002,

        /// <summary>
        /// current_display
        /// </summary>
        Display = 0x0004,

        /// <summary>
        /// target_bitmap
        /// </summary>
        TargetBitmap = 0x0008,

        /// <summary>
        /// blender
        /// </summary>
        Blender = 0x0010,

        /// <summary>
        /// new_file_interface
        /// </summary>
        NewFileInterface = 0x0020,

        /// <summary>
        /// current_transformation
        /// </summary>
        Transform = 0x0040,

        /// <summary>
        /// current_projection_transformation
        /// </summary>
        ProjectionTransform = 0x0100,

        /// <summary>
        /// new_bitmap_format, new_bitmap_flags, target_bitmap
        /// </summary>
        Bitmap = TargetBitmap + NewBitmapParameters,

        /// <summary>
        /// everything
        /// </summary>
        All = 0xffff
    }
}
