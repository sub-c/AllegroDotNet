using SubC.AllegroDotNet.Enums;
using SubC.AllegroDotNet.Models;
using SubC.AllegroDotNet.Native;

namespace SubC.AllegroDotNet;

/// <summary>
/// This static class contains the Allegro 5 library methods.
/// </summary>
public static partial class Al
{
  public static uint GetAllegroPrimitivesVersion()
  {
    return Interop.Primitives.AlGetAllegroPrimitivesVersion();
  }

  public static bool InitPrimitivesAddon()
  {
    return Interop.Primitives.AlInitPrimitivesAddon() != 0;
  }

  public static bool IsPrimitivesAddonInitialized()
  {
    return Interop.Primitives.AlIsPrimitivesAddonInitialized() != 0;
  }

  public static void ShutdownPrimitivesAddon()
  {
    Interop.Primitives.AlShutdownPrimitivesAddon();
  }

  public static void DrawLine(float x1, float y1, float x2, float y2, AllegroColor color, float thickness)
  {
    Interop.Primitives.AlDrawLine(x1, y1, x2, y2, color, thickness);
  }

  public static void DrawTriangle(
    float x1,
    float y1,
    float x2,
    float y2,
    float x3,
    float y3,
    AllegroColor color,
    float thickness)
  {
    Interop.Primitives.AlDrawTriangle(x1, y1, x2, y2, x3, y3, color, thickness);
  }

  public static void DrawFilledTriangle(
    float x1,
    float y1,
    float x2,
    float y2,
    float x3,
    float y3,
    AllegroColor color)
  {
    Interop.Primitives.AlDrawFilledTriangle(x1, y1, x2, y2, x3, y3, color);
  }

  public static void DrawRectangle(float x1, float y1, float x2, float y2, AllegroColor color, float thickness)
  {
    Interop.Primitives.AlDrawRectangle(x1, y1, x2, y2, color, thickness);
  }

  public static void DrawFilledRectangle(float x1, float y1, float x2, float y2, AllegroColor color)
  {
    Interop.Primitives.AlDrawFilledRectangle(x1, y1, x2, y2, color);
  }

  public static void DrawRoundedRectangle(
    float x1,
    float y1,
    float x2,
    float y2,
    float rx,
    float ry,
    AllegroColor color,
    float thickness)
  {
    Interop.Primitives.AlDrawRoundedRectangle(x1, y1, x2, y2, rx, ry, color, thickness);
  }

  public static void DrawFilledRoundedRectangle(
    float x1,
    float y1,
    float x2,
    float y2,
    float rx,
    float ry,
    AllegroColor color)
  {
    Interop.Primitives.AlDrawFilledRoundedRectangle(x1, y1, x2, y2, rx, ry, color);
  }

  public static void CalculateArc(
    float[] destination,
    int stride,
    float cx,
    float cy,
    float rx,
    float ry,
    float startTheta,
    float deltaTheta,
    float thickness,
    int pointsCount)
  {
    Interop.Primitives.AlCalculateArc(
      destination,
      stride,
      cx,
      cy,
      rx,
      ry,
      startTheta,
      deltaTheta,
      thickness,
      pointsCount);
  }

  public static void DrawPieslice(
    float cx,
    float cy,
    float r,
    float startTheta,
    float deltaTheta,
    AllegroColor color,
    float thickness)
  {
    Interop.Primitives.AlDrawPieslice(cx, cy, r, startTheta, deltaTheta, color, thickness);
  }

  public static void DrawFilledPieslice(
    float cx,
    float cy,
    float r,
    float startTheta,
    float deltaTheta,
    AllegroColor color)
  {
    Interop.Primitives.AlDrawFilledPieslice(cx, cy, r, startTheta, deltaTheta, color);
  }

  public static void DrawEllipse(float cx, float cy, float rx, float ry, AllegroColor color, float thickness)
  {
    Interop.Primitives.AlDrawEllipse(cx, cy, rx, ry, color, thickness);
  }

  public static void DrawFilledEllipse(float cx, float cy, float rx, float ry, AllegroColor color)
  {
    Interop.Primitives.AlDrawFilledEllipse(cx, cy, rx, ry, color);
  }

  public static void DrawCircle(float cx, float cy, float r, AllegroColor color, float thickness)
  {
    Interop.Primitives.AlDrawCircle(cx, cy, r, color, thickness);
  }

  public static void DrawFilledCircle(float cx, float cy, float r, AllegroColor color)
  {
    Interop.Primitives.AlDrawFilledCircle(cx, cy, r, color);
  }

  public static void DrawArc(
    float cx,
    float cy,
    float r,
    float startTheta,
    float deltaTheta,
    AllegroColor color,
    float thickness)
  {
    Interop.Primitives.AlDrawArc(cx, cy, r, startTheta, deltaTheta, color, thickness);
  }

  public static void DrawEllipticalArc(
    float cx,
    float cy,
    float rx,
    float ry,
    float startTheta,
    float deltaTheta,
    AllegroColor color,
    float thickness)
  {
    Interop.Primitives.AlDrawEllipticalArc(cx, cy, rx, ry, startTheta, deltaTheta, color, thickness);
  }

  public static void CalculateSpline(float[] destination, int stride, float[] points, float thickness, int segmentCount)
  {
    Interop.Primitives.AlCalculateSpline(destination, stride, points, thickness, segmentCount);
  }

  public static void DrawSpline(float[] points, AllegroColor color, float thickness)
  {
    Interop.Primitives.AlDrawSpline(points, color, thickness);
  }

  public static void CalculateRibbon(
    float[] destination,
    int destinationStride,
    float[] points,
    int pointStride,
    float thickness,
    int segmentCount)
  {
    Interop.Primitives.AlCalculateRibbon(
      destination,
      destinationStride,
      points,
      pointStride,
      thickness,
      segmentCount);
  }

  public static void DrawRibbon(float[] points, int pointStride, AllegroColor color, float thickness, int segmentCount)
  {
    Interop.Primitives.AlDrawRibbon(points, pointStride, color, thickness, segmentCount);
  }

  public static int DrawPrim(
    AllegroVertex[] vertexes,
    AllegroBitmap? texture,
    int start,
    int end,
    PrimType type)
  {
    return Interop.Primitives.AlDrawPrim(
      vertexes,
      IntPtr.Zero,
      NativePointer.Get(texture),
      start,
      end,
      (int)type);
  }

  public static int DrawIndexedPrim(
    AllegroVertex[] vertexes,
    AllegroBitmap? texture,
    int[] indices,
    int vertexCount,
    PrimType type)
  {
    return Interop.Primitives.AlDrawIndexedPrim(
      vertexes,
      IntPtr.Zero,
      NativePointer.Get(texture),
      indices,
      vertexCount,
      (int)type);
  }

  public static int DrawVertexBuffer(
    AllegroVertexBuffer? buffer,
    AllegroBitmap? texture,
    int start,
    int end,
    PrimType type)
  {
    return Interop.Primitives.AlDrawVertexBuffer(
      NativePointer.Get(buffer),
      NativePointer.Get(texture),
      start,
      end,
      (int)type);
  }

  public static int DrawIndexedBuffer(
    AllegroVertexBuffer? buffer,
    AllegroBitmap? texture,
    AllegroIndexBuffer? indexBuffer,
    int start,
    int end,
    PrimType type)
  {
    return Interop.Primitives.AlDrawIndexedBuffer(
      NativePointer.Get(buffer),
      NativePointer.Get(texture),
      NativePointer.Get(indexBuffer),
      start,
      end,
      (int)type);
  }

  public static void DrawSoftTriangle(
    ref AllegroVertex v1,
    ref AllegroVertex v2,
    ref AllegroVertex v3,
    UIntPtr state,
    Delegates.DrawPrimitiveSoftTriangleInit initAction,
    Delegates.DrawPrimitiveSoftTriangleFirst firstAction,
    Delegates.DrawPrimitiveStep stepAction,
    Delegates.DrawPrimitiveSoftTriangleDraw drawAction)
  {
    Interop.Primitives.AlDrawSoftTriangle(ref v1, ref v2, ref v3, state, initAction, firstAction, stepAction, drawAction);
  }

  public static void DrawSoftLine(
    ref AllegroVertex v1,
    ref AllegroVertex v2,
    UIntPtr state,
    Delegates.DrawPrimitiveSoftLineFirst firstAction,
    Delegates.DrawPrimitiveStep stepAction,
    Delegates.DrawPrimitiveSoftLineDraw drawAction)
  {
    Interop.Primitives.AlDrawSoftLine(ref v1, ref v2, state, firstAction, stepAction, drawAction);
  }

  public static AllegroVertexDecl? CreateVertexDecl(AllegroVertexElement[] elements, int stride)
  {
    var pointer = Interop.Primitives.AlCreateVertexDecl(elements, stride);
    return NativePointer.Create<AllegroVertexDecl>(pointer);
  }

  public static void DestroyVertexDecl(AllegroVertexDecl? decl)
  {
    Interop.Primitives.AlDestroyVertexDecl(NativePointer.Get(decl));
  }

  public static AllegroVertexBuffer? CreateVertexBuffer(AllegroVertexDecl? decl, IntPtr initialData, int verticesCount, PrimBufferFlags flags)
  {
    var pointer = Interop.Primitives.AlCreateVertexBuffer(NativePointer.Get(decl), initialData, verticesCount, (int)flags);
    return NativePointer.Create<AllegroVertexBuffer>(pointer);
  }

  public static void DestroyVertexBuffer(AllegroVertexBuffer? buffer)
  {
    Interop.Primitives.AlDestroyVertexBuffer(NativePointer.Get(buffer));
  }

  public static IntPtr LockVertexBuffer(AllegroVertexBuffer? buffer, int offset, int length, LockFlag flag)
  {
    return Interop.Primitives.AlLockVertexBuffer(NativePointer.Get(buffer), offset, length, (int)flag);
  }

  public static void UnlockVertexBuffer(AllegroVertexBuffer? buffer)
  {
    Interop.Primitives.AlUnlockVertexBuffer(NativePointer.Get(buffer));
  }

  public static int GetVertexBufferSize(AllegroVertexBuffer? buffer)
  {
    return Interop.Primitives.AlGetVertexBufferSize(NativePointer.Get(buffer));
  }

  public static AllegroIndexBuffer? CreateIndexBuffer(int indexSize, IntPtr initialData, int indicesCount, PrimBufferFlags flags)
  {
    var pointer = Interop.Primitives.AlCreateIndexBuffer(indexSize, initialData, indicesCount, (int)flags);
    return NativePointer.Create<AllegroIndexBuffer>(pointer);
  }

  public static void DestroyIndexBuffer(AllegroIndexBuffer? buffer)
  {
    Interop.Primitives.AlDestroyIndexBuffer(NativePointer.Get(buffer));
  }

  public static IntPtr LockIndexBuffer(AllegroIndexBuffer? buffer, int offset, int length, LockFlag flag)
  {
    return Interop.Primitives.AlLockIndexBuffer(NativePointer.Get(buffer), offset, length, (int)flag);
  }

  public static void UnlockIndexBuffer(AllegroIndexBuffer? buffer)
  {
    Interop.Primitives.AlUnlockIndexBuffer(NativePointer.Get(buffer));
  }

  public static int GetIndexBufferSize(AllegroIndexBuffer? buffer)
  {
    return Interop.Primitives.AlGetIndexBufferSize(NativePointer.Get(buffer));
  }

  public static void DrawPolyline(
    float[] vertices,
    int vertexStride,
    int vertexCount,
    LineJoin joinStyle,
    LineCap capStyle,
    AllegroColor color,
    float thickness,
    float miterLimit)
  {
    Interop.Primitives.AlDrawPolyline(
      vertices,
      vertexStride,
      vertexCount,
      (int)joinStyle,
      (int)capStyle,
      color,
      thickness,
      miterLimit);
  }

  public static void DrawPolygon(
    float[] vertices,
    int vertexCount,
    LineJoin joinStyle,
    AllegroColor color,
    float thickness,
    float miterLimit)
  {
    Interop.Primitives.AlDrawPolygon(vertices, vertexCount, (int)joinStyle, color, thickness, miterLimit);
  }

  public static void DrawFilledPolygon(float[] vertices, int vertexCount, AllegroColor color)
  {
    Interop.Primitives.AlDrawFilledPolygon(vertices, vertexCount, color);
  }

  public static void DrawFilledPolygonWithHoles(float[] vertices, int[] vertexCounts, AllegroColor color)
  {
    Interop.Primitives.AlDrawFilledPolygonWithHoles(vertices, vertexCounts, color);
  }

  public static bool TriangulatePolygon(
    float[] vertices,
    ulong vertexStride,
    int[] vertexCounts,
    Delegates.TriangulatePolygonEmitTriangle emitTriangleAction,
    IntPtr userdata)
  {
    return Interop.Primitives.AlTriangulatePolygon(
      vertices,
      new UIntPtr(vertexStride),
      vertexCounts,
      emitTriangleAction,
      userdata) != 0;
  }
}
