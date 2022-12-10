using SubC.AllegroDotNet.Enums;
using SubC.AllegroDotNet.Models;
using SubC.AllegroDotNet.Native;
using System;
using System.Linq;

namespace SubC.AllegroDotNet
{
  public static partial class Al
  {
    public static uint GetAllegroPrimitivesVersion()
    {
      return NativeFunctions.AlGetAllegroPrimitivesVersion();
    }

    public static bool InitPrimitivesAddon()
    {
      return NativeFunctions.AlInitPrimitivesAddon();
    }

    public static bool IsPrimitivesAddonInitialized()
    {
      return NativeFunctions.AlIsPrimitivesAddonInitialized();
    }

    public static void ShutdownPrimitivesAddon()
    {
      NativeFunctions.AlShutdownPrimitivesAddon();
    }

    public static void DrawLine(float x1, float y1, float x2, float y2, AllegroColor color, float thickness)
    {
      NativeFunctions.AlDrawLine(x1, y1, x2, y2, color, thickness);
    }

    public static void DrawTriangle(float x1, float y1, float x2, float y2, float x3, float y3, AllegroColor color, float thickness)
    {
      NativeFunctions.AlDrawTriangle(x1, y1, x2, y2, x3, y3, color, thickness);
    }

    public static void DrawFilledTriangle(float x1, float y1, float x2, float y2, float x3, float y3, AllegroColor color)
    {
      NativeFunctions.AlDrawFilledTriangle(x1, y1, x2, y2, x3, y3, color);
    }

    public static void DrawRectangle(float x1, float y1, float x2, float y2, AllegroColor color, float thickness)
    {
      NativeFunctions.AlDrawRectangle(x1, y1, x2, y2, color, thickness);
    }

    public static void DrawFilledRectangle(float x1, float y1, float x2, float y2, AllegroColor color)
    {
      NativeFunctions.AlDrawFilledRectangle(x1, y1, x2, y2, color);
    }

    public static void DrawRoundedRectangle(float x1, float y1, float x2, float y2, float rx, float ry, AllegroColor color, float thickness)
    {
      NativeFunctions.AlDrawRoundedRectangle(x1, y1, x2, y2, rx, ry, color, thickness);
    }

    public static void DrawFilledRoundedRectangle(float x1, float y1, float x2, float y2, float rx, float ry, AllegroColor color)
    {
      NativeFunctions.AlDrawFilledRoundedRectangle(x1, y1, x2, y2, rx, ry, color);
    }

    public static void CalculateArc(ref float[] buffer, int stride, float cx, float cy, float rx, float ry, float startTheta, float deltaTheta, float thickness, int numPoints)
    {
      NativeFunctions.AlCalculateArc(ref buffer, stride, cx, cy, rx, ry, startTheta, deltaTheta, thickness, numPoints);
    }

    public static void DrawPieSlice(float cx, float cy, float r, float startTheta, float deltaTheta, AllegroColor color, float thickness)
    {
      NativeFunctions.AlDrawPieslice(cx, cy, r, startTheta, deltaTheta, color, thickness);
    }

    public static void DrawFilledPieSlice(float cx, float cy, float r, float startTheta, float deltaTheta, AllegroColor color)
    {
      NativeFunctions.AlDrawFilledPieslice(cx, cy, r, startTheta, deltaTheta, color);
    }

    public static void DrawEllipse(float cx, float cy, float rx, float ry, AllegroColor color, float thickness)
    {
      NativeFunctions.AlDrawEllipse(cx, cy, rx, ry, color, thickness);
    }

    public static void DrawFilledEllipse(float cx, float cy, float rx, float ry, AllegroColor color)
    {
      NativeFunctions.AlDrawFilledEllipse(cx, cy, rx, ry, color);
    }

    public static void DrawCircle(float cx, float cy, float r, AllegroColor color, float thickness)
    {
      NativeFunctions.AlDrawCircle(cx, cy, r, color, thickness);
    }

    public static void DrawFilledCircle(float cx, float cy, float r, AllegroColor color)
    {
      NativeFunctions.AlDrawFilledCircle(cx, cy, r, color);
    }

    public static void DrawArc(float cx, float cy, float r, float startTheta, float deltaTheta, AllegroColor color, float thickness)
    {
      NativeFunctions.AlDrawArc(cx, cy, r, startTheta, deltaTheta, color, thickness);
    }

    public static void DrawEllipticalArc(float cx, float cy, float rx, float ry, float startTheta, float deltaTheta, AllegroColor color, float thickness)
    {
      NativeFunctions.AlDrawEllipticalArc(cx, cy, rx, ry, startTheta, deltaTheta, color, thickness);
    }

    public static void CalculateSpline(ref float[] buffer, int stride, float[] points, float thickness, int numSegments)
    {
      NativeFunctions.AlCalculateSpline(ref buffer, stride, points, thickness, numSegments);
    }

    public static void DrawSpline(float[] points, AllegroColor color, float thickness)
    {
      NativeFunctions.AlDrawSpline(points, color, thickness);
    }

    public static void CalculateRibbon(ref float[] buffer, int destStride, ref float[] points, int pointsStride, float thickness, int numSegments)
    {
      NativeFunctions.AlCalculateRibbon(ref buffer, destStride, ref points, pointsStride, thickness, numSegments);
    }

    public static void DrawRibbon(ref float[] points, int pointsStride, AllegroColor color, float thickness, int numSegments)
    {
      NativeFunctions.AlDrawRibbon(ref points, pointsStride, color, thickness, numSegments);
    }

    public static void DrawPrim(ref AllegroVertex[] vertexes, AllegroVertexDecl? declaration, AllegroBitmap? texture, int start, int end, PrimitiveType type)
    {
      if (declaration is not null)
        throw new NotImplementedException("Vertex declarations are not implemented, pass null instead.");

      NativeFunctions.AlDrawPrim(ref vertexes, IntPtr.Zero, NativePointerModel.GetPointer(texture), start, end, (int)type);
    }

    public static int DrawIndexedPrim(ref AllegroVertex[] vertexes, AllegroVertexDecl? declaration, AllegroBitmap? texture, ref int[] indices, int vertexCount, PrimitiveType type)
    {
      if (declaration is not null)
        throw new NotImplementedException("Vertex declarations are not implemented, pass null instead.");

      return NativeFunctions.AlDrawIndexedPrim(ref vertexes, IntPtr.Zero, NativePointerModel.GetPointer(texture), ref indices, vertexCount, (int)type);
    }

    public static int DrawVertexBuffer(AllegroVertexBuffer? vertexBuffer, AllegroBitmap? texture, int start, int end, PrimitiveType type)
    {
      return NativeFunctions.AlDrawVertexBuffer(NativePointerModel.GetPointer(vertexBuffer), NativePointerModel.GetPointer(texture), start, end, (int)type);
    }

    public static int DrawIndexedBuffer(AllegroVertexBuffer? vertexBuffer, AllegroBitmap? texture, AllegroIndexBuffer? indexBuffer, int start, int end, PrimitiveType type)
    {
      return NativeFunctions.AlDrawIndexedBuffer(
        NativePointerModel.GetPointer(vertexBuffer),
        NativePointerModel.GetPointer(texture),
        NativePointerModel.GetPointer(indexBuffer),
        start,
        end,
        (int)type);
    }

    public static void DrawSoftTriangle()
    {
      throw new NotImplementedException();
    }

    public static void DrawSoftLine()
    {
      throw new NotImplementedException();
    }

    public static AllegroVertexDecl? CreateVertexDecl(AllegroVertexElement[] elements, int stride)
    {
      var nativeAllegroVertexElements = elements.Select(x => x.NativeVertexElement).ToArray();
      var result = NativeFunctions.AlCreateVertexDecl(nativeAllegroVertexElements, stride);
      return NativePointerModel.Create<AllegroVertexDecl>(result);
    }

    public static void DestroyVertexDecl(AllegroVertexDecl? decl)
    {
      NativeFunctions.AlDestroyVertexDecl(NativePointerModel.GetPointer(decl));
    }

    public static AllegroVertexBuffer? CreateVertexBuffer(AllegroVertexDecl? decl, IntPtr initialData, int numVertices, int flags)
    {
      var nativePointer = NativeFunctions.AlCreateVertexBuffer(NativePointerModel.GetPointer(decl), initialData, numVertices, flags);
      return NativePointerModel.Create<AllegroVertexBuffer>(nativePointer);
    }

    public static void DestroyVertexBuffer(AllegroVertexBuffer? buffer)
    {
      NativeFunctions.AlDestroyVertexBuffer(NativePointerModel.GetPointer(buffer));
    }

    public static void LockVertexBuffer(AllegroVertexBuffer? buffer, int offset, int length, int flags)
    {
      NativeFunctions.AlLockVertexBuffer(NativePointerModel.GetPointer(buffer), offset, length, flags);
    }

    public static void UnlockVertexBuffer(AllegroVertexBuffer? buffer)
    {
      NativeFunctions.AlUnlockVertexBuffer(NativePointerModel.GetPointer(buffer));
    }

    public static int GetVertexBufferSize(AllegroVertexBuffer? buffer)
    {
      return NativeFunctions.AlGetVertexBufferSize(NativePointerModel.GetPointer(buffer));
    }

    public static AllegroIndexBuffer? CreateIndexBuffer(int indexSize, IntPtr initialData, int numIndices, int flags)
    {
      var nativePointer = NativeFunctions.AlCreateIndexBuffer(indexSize, initialData, numIndices, flags);
      return NativePointerModel.Create<AllegroIndexBuffer>(nativePointer);
    }

    public static void DestroyIndexBuffer(AllegroIndexBuffer? buffer)
    {
      NativeFunctions.AlDestroyIndexBuffer(NativePointerModel.GetPointer(buffer));
    }

    public static IntPtr LockIndexBuffer(AllegroIndexBuffer? buffer, int offset, int length, int flags)
    {
      return NativeFunctions.AlLockIndexBuffer(NativePointerModel.GetPointer(buffer), offset, length, flags);
    }

    public static void UnlockIndexBuffer(AllegroIndexBuffer? buffer)
    {
      NativeFunctions.AlUnlockIndexBuffer(NativePointerModel.GetPointer(buffer));
    }

    public static int GetIndexBufferSize(AllegroIndexBuffer? buffer)
    {
      return NativeFunctions.AlGetIndexBufferSize(NativePointerModel.GetPointer(buffer));
    }

    public static void DrawPolyline(IntPtr vertices, int vertexStride, int vertexCount, int joinStyle, int capStyle, AllegroColor color, float thickness, float miterLimit)
    {
      NativeFunctions.AlDrawPolyline(vertices, vertexStride, vertexCount, joinStyle, capStyle, color, thickness, miterLimit);
    }

    public static void DrawPolygon(IntPtr vertices, int vertexCount, int joinStyle, AllegroColor color, float thickness, float miterLimit)
    {
      NativeFunctions.AlDrawPolygon(vertices, vertexCount, joinStyle, color, thickness, miterLimit);
    }

    public static void DrawFilledPolygon(IntPtr vertices, int vertexCount, AllegroColor color)
    {
      NativeFunctions.AlDrawFilledPolygon(vertices, vertexCount, color);
    }

    public static void DrawFilledPolygonWithHoles(IntPtr vertices, IntPtr vertexCounts, AllegroColor color)
    {
      NativeFunctions.AlDrawFilledPolygonWithHoles(vertices, vertexCounts, color);
    }

    public static bool TriangulatePolygon(IntPtr vertices, long vertexStride, IntPtr vertexCounts, NativeDelegates.EmitTriangle emitTriangle, IntPtr userdata)
    {
      return NativeFunctions.AlTriangulatePolygon(vertices, vertexStride, vertexCounts, emitTriangle, userdata);
    }
  }
}
