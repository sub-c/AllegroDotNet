using SubC.AllegroDotNet.Models;
using SubC.AllegroDotNet.Native.Libraries;

namespace SubC.AllegroDotNet
{
    /// <summary>
    /// Allegro game library methods.
    /// </summary>
    public static partial class Al
    {
        /// <summary>
        /// Sets the projection transformation to be used for the drawing operations on the target bitmap (each bitmap
        /// maintains its own projection transformation). Every drawing operation after this call will be transformed
        /// using this transformation.
        /// <para>
        /// This function does nothing if there is no target bitmap. This function also does nothing if the bitmap is a
        /// memory bitmap (i.e. memory bitmaps always use an orthographic transform like the snippet above). Note that
        /// the projection transform will be reset to default if a video bitmap is converted to a memory bitmap.
        /// Additionally, if the bitmap in question is the backbuffer, it’s projection transformation will be reset to
        /// default if it is resized. Lastly, when you draw a memory bitmap to a video bitmap with a custom projection
        /// transform, this transformation will be ignored (i.e. it’ll be as if the projection transform of the target
        /// bitmap was temporarily reset to default).
        /// </para>
        /// <para>
        /// The parameter is passed by reference as an optimization to avoid the overhead of stack copying. The
        /// reference will not be stored in the Allegro library so it is safe to pass references to local variables.
        /// </para>
        /// </summary>
        /// <param name="trans">The transformation instance.</param>
        public static void UseProjectionTransform(AllegroTransform trans) =>
            AllegroLibrary.AlUseProjectionTransform(ref trans.Native);

        #region P/Invokes
        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //private static extern void al_copy_transform(ref NativeTransform dest, ref NativeTransform src);

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //private static extern void al_use_transform(ref NativeTransform trans);

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //private static extern IntPtr al_get_current_transform();

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //private static extern void al_use_projection_transform(ref NativeTransform trans);

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //private static extern IntPtr al_get_current_projection_transform();

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //private static extern IntPtr al_get_current_inverse_transform();

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //private static extern void al_invert_transform(ref NativeTransform trans);

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //private static extern void al_transpose_transform(ref NativeTransform trans);

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //private static extern int al_check_inverse(ref NativeTransform trans, float tol);

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //private static extern void al_identity_transform(ref NativeTransform trans);

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //private static extern void al_build_transform(ref NativeTransform trans, float x, float y, float sx, float sy, float theta);

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //private static extern void al_build_camera_transform(ref NativeTransform trans, float position_x, float position_y, float position_z, float look_x, float look_y, float look_z, float up_x, float up_y, float up_z);

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //private static extern void al_translate_transform(ref NativeTransform trans, float x, float y);

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //private static extern void al_rotate_transform(ref NativeTransform trans, float theta);

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //private static extern void al_scale_transform(ref NativeTransform trans, float sx, float sy);

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //private static extern void al_transform_coordinates(ref NativeTransform trans, ref float x, ref float y);

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //private static extern void al_transform_coordinates_3d(ref NativeTransform trans, ref float x, ref float y, ref float z);

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //private static extern void al_transform_coordinates_4d(ref NativeTransform trans, ref float x, ref float y, ref float z, ref float w);

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //private static extern void al_transform_coordinates_3d_projective(ref NativeTransform trans, ref float x, ref float y, ref float z);

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //private static extern void al_compose_transform(ref NativeTransform trans, ref NativeTransform other);

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //private static extern void al_orthographic_transform(ref NativeTransform trans, float left, float top, float n, float right, float bottom, float f);

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //private static extern void al_perspective_transform(ref NativeTransform trans, float left, float top, float n, float right, float bottom, float f);

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //private static extern void al_translate_transform_3d(ref NativeTransform trans, float x, float y, float z);

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //private static extern void al_scale_transform_3d(ref NativeTransform trans, float sx, float sy, float sz);

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //private static extern void al_rotate_transform_3d(ref NativeTransform trans, float x, float y, float z, float angle);

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //private static extern void al_horizontal_shear_transform(ref NativeTransform trans, float theta);

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //private static extern void al_vertical_shear_transform(ref NativeTransform trans, float theta);
        #endregion
    }
}
