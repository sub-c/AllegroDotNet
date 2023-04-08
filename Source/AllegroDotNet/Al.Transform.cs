using SubC.AllegroDotNet.Models;
using SubC.AllegroDotNet.Native;
using System;
using System.Runtime.InteropServices;

namespace SubC.AllegroDotNet;

public static partial class Al
{
  public static void CopyTransform(AllegroTransform destination, AllegroTransform source)
  {
    NativeFunctions.AlCopyTransform(ref destination.Transform, ref source.Transform);
  }

  public static void UseTransform(AllegroTransform transform)
  {
    NativeFunctions.AlUseTransform(ref transform.Transform);
  }

  public static AllegroTransform? GetCurrentTransform()
  {
    var nativeTransform = NativeFunctions.AlGetCurrentTransform();
    return nativeTransform == IntPtr.Zero
        ? null
        : new AllegroTransform
        {
          Transform = Marshal.PtrToStructure<AllegroTransform.NativeAllegroTransform>(nativeTransform)
        };
  }

  public static void UseProjectionTransform(AllegroTransform transform)
  {
    NativeFunctions.AlUseProjectionTransform(ref transform.Transform);
  }

  public static AllegroTransform? GetCurrentProjectionTransform()
  {
    var nativeTransform = NativeFunctions.AlGetCurrentProjectionTransform();
    return nativeTransform == IntPtr.Zero
        ? null
        : new AllegroTransform
        {
          Transform = Marshal.PtrToStructure<AllegroTransform.NativeAllegroTransform>(nativeTransform)
        };
  }

  public static AllegroTransform? GetCurrentInverseTransform()
  {
    var nativeTransform = NativeFunctions.AlGetCurrentInverseTransform();
    return nativeTransform == IntPtr.Zero
        ? null
        : new AllegroTransform
        {
          Transform = Marshal.PtrToStructure<AllegroTransform.NativeAllegroTransform>(nativeTransform)
        };
  }

  public static void InvertTransform(AllegroTransform transform)
  {
    NativeFunctions.AlInvertTransform(ref transform.Transform);
  }

  public static void TransposeTransform(AllegroTransform transform)
  {
    NativeFunctions.AlTransposeTransform(ref transform.Transform);
  }

  public static int CheckInverse(AllegroTransform transform, float tolerance)
  {
    return NativeFunctions.AlCheckInverse(ref transform.Transform, tolerance);
  }

  public static void IdentityTransform(AllegroTransform transform)
  {
    NativeFunctions.AlIdentityTransform(ref transform.Transform);
  }

  public static void BuildTransform(AllegroTransform transform, float x, float y, float sx, float sy, float theta)
  {
    NativeFunctions.AlBuildTransform(ref transform.Transform, x, y, sx, sy, theta);
  }

  public static void BuildCameraTransform(
      AllegroTransform transform,
      float posX,
      float posY,
      float posZ,
      float lookX,
      float lookY,
      float lookZ,
      float upX,
      float upY,
      float upZ)
  {
    NativeFunctions.AlBuildCameraTransform(ref transform.Transform, posX, posY, posZ, lookX, lookY, lookZ, upX, upY, upZ);
  }

  public static void TranslateTransform(AllegroTransform transform, float x, float y)
  {
    NativeFunctions.AlTranslateTransform(ref transform.Transform, x, y);
  }

  public static void RotateTransform(AllegroTransform transform, float theta)
  {
    NativeFunctions.AlRotateTransform(ref transform.Transform, theta);
  }

  public static void ScaleTransform(AllegroTransform transform, float sx, float sy)
  {
    NativeFunctions.AlScaleTransform(ref transform.Transform, sx, sy);
  }

  public static void TransformCoordinates(AllegroTransform transform, ref float x, ref float y)
  {
    NativeFunctions.AlTransformCoordinates(ref transform.Transform, ref x, ref y);
  }

  public static void TransformCoordinates3D(AllegroTransform transform, ref float x, ref float y, ref float z)
  {
    NativeFunctions.AlTransformCoordinates3D(ref transform.Transform, ref x, ref y, ref z);
  }

  public static void TransformCoordinates4D(AllegroTransform transform, ref float x, ref float y, ref float z, ref float w)
  {
    NativeFunctions.AlTransformCoordinates4D(ref transform.Transform, ref x, ref y, ref z, ref w);
  }

  public static void TransformCoordinates3DProjective(AllegroTransform transform, ref float x, ref float y, ref float z)
  {
    NativeFunctions.AlTransformCoordinates3DProjective(ref transform.Transform, ref x, ref y, ref z);
  }

  public static void ComposeTransform(AllegroTransform transform, AllegroTransform otherTransform)
  {
    NativeFunctions.AlComposeTransform(ref transform.Transform, ref otherTransform.Transform);
  }

  public static void OrthographicTransform(
      AllegroTransform transform,
      float left,
      float top,
      float n,
      float right,
      float bottom,
      float f)
  {
    NativeFunctions.AlOrthographicTransform(ref transform.Transform, left, top, n, right, bottom, f);
  }

  public static void PerspectiveTransform(
      AllegroTransform transform,
      float left,
      float top,
      float n,
      float right,
      float bottom,
      float f)
  {
    NativeFunctions.AlPerspectiveTransform(ref transform.Transform, left, top, n, right, bottom, f);
  }

  public static void TranslateTransform3D(AllegroTransform transform, float x, float y, float z)
  {
    NativeFunctions.AlTranslateTransform3D(ref transform.Transform, x, y, z);
  }

  public static void ScaleTransform3D(AllegroTransform transform, float sx, float sy, float sz)
  {
    NativeFunctions.AlScaleTransform3D(ref transform.Transform, sx, sy, sz);
  }

  public static void RotateTransform3D(AllegroTransform transform, float x, float y, float z, float angle)
  {
    NativeFunctions.AlRotateTransform3D(ref transform.Transform, x, y, z, angle);
  }

  public static void HorizontalShearTransform(AllegroTransform transform, float theta)
  {
    NativeFunctions.AlHorizontalShearTransform(ref transform.Transform, theta);
  }

  public static void VerticalShearTransform(AllegroTransform transform, float theta)
  {
    NativeFunctions.AlVerticalShearTransform(ref transform.Transform, theta);
  }
}
