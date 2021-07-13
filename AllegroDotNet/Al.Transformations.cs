using System;
using System.Runtime.InteropServices;
using SubC.AllegroDotNet.Native;

namespace SubC.AllegroDotNet
{
    /// <summary>
    /// Allegro game library methods.
    /// </summary>
    public static partial class Al
    {
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
