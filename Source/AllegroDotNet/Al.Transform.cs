using SubC.AllegroDotNet.Models;
using SubC.AllegroDotNet.Native;
using System.Runtime.InteropServices;

namespace SubC.AllegroDotNet;

/// <summary>
/// This static class contains the Allegro 5 library methods.
/// </summary>
public static partial class Al
{
  public static void CopyTransform(ref AllegroTransform destination, in AllegroTransform source)
  {
    Interop.Core.AlCopyTransform(ref destination, in source);
  }

  public static void UseTransform(ref AllegroTransform transform)
  {
    Interop.Core.AlUseTransform(ref transform);
  }

  public static AllegroTransform? GetCurrentTransform()
  {
    var pointer = Interop.Core.AlGetCurrentTransform();
    return pointer == IntPtr.Zero
      ? null
      : Marshal.PtrToStructure<AllegroTransform>(pointer);
  }

  public static void UseProjectionTransform(ref AllegroTransform transform)
  {
    Interop.Core.AlUseProjectionTransform(ref transform);
  }

  public static AllegroTransform GetCurrentProjectionTransform()
  {
    var pointer = Interop.Core.AlGetCurrentProjectionTransform();
    return Marshal.PtrToStructure<AllegroTransform>(pointer);
  }

  public static AllegroTransform GetCurrentInverseTransform()
  {
    var pointer = Interop.Core.AlGetCurrentInverseTransform();
    return Marshal.PtrToStructure<AllegroTransform>(pointer);
  }

  public static void InvertTransform(ref AllegroTransform transform)
  {
    Interop.Core.AlInvertTransform(ref transform);
  }

  public static void TransposeTransform(ref AllegroTransform transform)
  {
    Interop.Core.AlTransposeTransform(ref transform);
  }

  public static int CheckInverse(ref AllegroTransform transform, float tolerance)
  {
    return Interop.Core.AlCheckInverse(ref transform, tolerance);
  }

  public static void IdentityTransform(ref AllegroTransform transform)
  {
    Interop.Core.AlIdentityTransform(ref transform);
  }

  public static void BuildTransform(
    ref AllegroTransform transform,
    float x,
    float y,
    float sx,
    float sy,
    float theta)
  {
    Interop.Core.AlBuildTransform(ref transform, x, y, sx, sy, theta);
  }

  public static void BuildCameraTransform(
    ref AllegroTransform transform,
    float positionX,
    float positionY,
    float positionZ,
    float lookX,
    float lookY,
    float lookZ,
    float upX,
    float upY,
    float upZ)
  {
    Interop.Core.AlBuildCameraTransform(
      ref transform,
      positionX,
      positionY,
      positionZ,
      lookX,
      lookY,
      lookZ,
      upX,
      upY,
      upZ);
  }

  public static void TranslateTransform(ref AllegroTransform transform, float x, float y)
  {
    Interop.Core.AlTranslateTransform(ref transform, x, y);
  }

  public static void RotateTransform(ref AllegroTransform transform, float theta)
  {
    Interop.Core.AlRotateTransform(ref transform, theta);
  }

  public static void ScaleTransform(ref AllegroTransform transform, float sX, float sY)
  {
    Interop.Core.AlScaleTransform(ref transform, sX, sY);
  }

  public static void TransformCoordinates(ref AllegroTransform transform, ref float x, ref float y)
  {
    Interop.Core.AlTransformCoordinates(ref transform, ref x, ref y);
  }

  public static void TransformCoordinates3D(ref AllegroTransform transform, ref float x, ref float y, ref float z)
  {
    Interop.Core.AlTransformCoordinates3D(ref transform, ref x, ref y, ref z);
  }

  public static void TransformCoordinates4D(
    ref AllegroTransform transform,
    ref float x,
    ref float y,
    ref float z,
    ref float w)
  {
    Interop.Core.AlTransformCoordinates4D(ref transform, ref x, ref y, ref z, ref w);
  }

  public static void TransformCoordinates3DProjective(
    ref AllegroTransform transform,
    ref float x,
    ref float y,
    ref float z)
  {
    Interop.Core.AlTransformCoordinates3DProjective(ref transform, ref x, ref y, ref z);
  }

  public static void ComposeTransform(ref AllegroTransform transform, in AllegroTransform otherTransform)
  {
    Interop.Core.AlComposeTransform(ref transform, in otherTransform);
  }

  public static void OrthographicTransform(
    ref AllegroTransform transform,
    float left,
    float top,
    float n,
    float right,
    float bottom,
    float f)
  {
    Interop.Core.AlOrthographicTransform(ref transform, left, top, n, right, bottom, f);
  }

  public static void PerspectiveTransform(
    ref AllegroTransform transform,
    float left,
    float top,
    float n,
    float right,
    float bottom,
    float f)
  {
    Interop.Core.AlPerspectiveTransform(ref transform, left, top, n, right, bottom, f);
  }

  public static void TranslateTransform3D(ref AllegroTransform transform, float x, float y, float z)
  {
    Interop.Core.AlTranslateTransform3D(ref transform, x, y, z);
  }

  public static void ScaleTransform3D(ref AllegroTransform transform, float sX, float sY, float sZ)
  {
    Interop.Core.AlScaleTransform3D(ref transform, sX, sY, sZ);
  }

  public static void RotateTransform3D(ref AllegroTransform transform, float x, float y, float z, float angle)
  {
    Interop.Core.AlRotateTransform3D(ref transform, x, y, z, angle);
  }

  public static void HorizontalShearTransform(ref AllegroTransform transform, float theta)
  {
    Interop.Core.AlHorizontalShearTransform(ref transform, theta);
  }

  public static void VerticalShearTransform(ref AllegroTransform transform, float theta)
  {
    Interop.Core.AlVerticalShearTransform(ref transform, theta);
  }
}
