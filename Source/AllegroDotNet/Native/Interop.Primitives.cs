using SubC.AllegroDotNet.Models;
using System.Runtime.InteropServices;

namespace SubC.AllegroDotNet.Native;

internal static partial class Interop
{
  public static PrimitivesContext Primitives => _primitivesContext ??= new();

  private static PrimitivesContext? _primitivesContext;

  public sealed class PrimitivesContext
  {
    #region Primitives Routines

    public al_get_allegro_primitives_version AlGetAllegroPrimitivesVersion { get; }
    public al_init_primitives_addon AlInitPrimitivesAddon { get; }
    public al_is_primitives_addon_initialized AlIsPrimitivesAddonInitialized { get; }
    public al_shutdown_primitives_addon AlShutdownPrimitivesAddon { get; }
    public al_draw_line AlDrawLine { get; }
    public al_draw_triangle AlDrawTriangle { get; }
    public al_draw_filled_triangle AlDrawFilledTriangle { get; }
    public al_draw_rectangle AlDrawRectangle { get; }
    public al_draw_filled_rectangle AlDrawFilledRectangle { get; }
    public al_draw_rounded_rectangle AlDrawRoundedRectangle { get; }
    public al_draw_filled_rounded_rectangle AlDrawFilledRoundedRectangle { get; }
    public al_calculate_arc AlCalculateArc { get; }
    public al_draw_pieslice AlDrawPieslice { get; }
    public al_draw_filled_pieslice AlDrawFilledPieslice { get; }
    public al_draw_ellipse AlDrawEllipse { get; }
    public al_draw_filled_ellipse AlDrawFilledEllipse { get; }
    public al_draw_circle AlDrawCircle { get; }
    public al_draw_filled_circle AlDrawFilledCircle { get; }
    public al_draw_arc AlDrawArc { get; }
    public al_draw_elliptical_arc AlDrawEllipticalArc { get; }
    public al_calculate_spline AlCalculateSpline { get; }
    public al_draw_spline AlDrawSpline { get; }
    public al_calculate_ribbon AlCalculateRibbon { get; }
    public al_draw_ribbon AlDrawRibbon { get; }
    public al_draw_prim AlDrawPrim { get; }
    public al_draw_indexed_prim AlDrawIndexedPrim { get; }
    public al_draw_vertex_buffer AlDrawVertexBuffer { get; }
    public al_draw_indexed_buffer AlDrawIndexedBuffer { get; }
    public al_draw_soft_triangle AlDrawSoftTriangle { get; }
    public al_draw_soft_line AlDrawSoftLine { get; }
    public al_create_vertex_decl AlCreateVertexDecl { get; }
    public al_destroy_vertex_decl AlDestroyVertexDecl { get; }
    public al_create_vertex_buffer AlCreateVertexBuffer { get; }
    public al_destroy_vertex_buffer AlDestroyVertexBuffer { get; }
    public al_lock_vertex_buffer AlLockVertexBuffer { get; }
    public al_unlock_vertex_buffer AlUnlockVertexBuffer { get; }
    public al_get_vertex_buffer_size AlGetVertexBufferSize { get; }
    public al_create_index_buffer AlCreateIndexBuffer { get; }
    public al_destroy_index_buffer AlDestroyIndexBuffer { get; }
    public al_lock_index_buffer AlLockIndexBuffer { get; }
    public al_unlock_index_buffer AlUnlockIndexBuffer { get; }
    public al_get_index_buffer_size AlGetIndexBufferSize { get; }
    public al_draw_polyline AlDrawPolyline { get; }
    public al_draw_polygon AlDrawPolygon { get; }
    public al_draw_filled_polygon AlDrawFilledPolygon { get; }
    public al_draw_filled_polygon_with_holes AlDrawFilledPolygonWithHoles { get; }
    public al_triangulate_polygon AlTriangulatePolygon { get; }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate uint al_get_allegro_primitives_version();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte al_init_primitives_addon();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte al_is_primitives_addon_initialized();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_shutdown_primitives_addon();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_draw_line(float x1, float y1, float x2, float y2, AllegroColor color, float thickness);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_draw_triangle(float x1, float y1, float x2, float y2, float x3, float y3, AllegroColor color, float thickness);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_draw_filled_triangle(float x1, float y1, float x2, float y2, float x3, float y3, AllegroColor color);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_draw_rectangle(float x1, float y1, float x2, float y2, AllegroColor color, float thickness);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_draw_filled_rectangle(float x1, float y1, float x2, float y2, AllegroColor color);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_draw_rounded_rectangle(float x1, float y1, float x2, float y2, float rx, float ry, AllegroColor color, float thickness);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_draw_filled_rounded_rectangle(float x1, float y1, float x2, float y2, float rx, float ry, AllegroColor color);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_calculate_arc(
      float[] dest,
      int stride,
      float cx,
      float cy,
      float rx,
      float ry,
      float start_theta,
      float delta_theta,
      float thickness,
      int num_points);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_draw_pieslice(float cx, float cy, float r, float start_theta, float delta_theta, AllegroColor color, float thickness);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_draw_filled_pieslice(float cx, float cy, float r, float start_theta, float delta_theta, AllegroColor color);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_draw_ellipse(float cx, float cy, float rx, float ry, AllegroColor color, float thickness);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_draw_filled_ellipse(float cx, float cy, float rx, float ry, AllegroColor color);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_draw_circle(float cx, float cy, float r, AllegroColor color, float thickness);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_draw_filled_circle(float cx, float cy, float r, AllegroColor color);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_draw_arc(float cx, float cy, float r, float start_theta, float delta_theta, AllegroColor color, float thickness);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_draw_elliptical_arc(
      float cx,
      float cy,
      float rx,
      float ry,
      float start_theta,
      float delta_theta,
      AllegroColor color,
      float thickness);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_calculate_spline(float[] dest, int stride, float[] points, float thickness, int num_segments);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_draw_spline(float[] points, AllegroColor color, float thickness);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_calculate_ribbon(float[] dest, int dest_stride, float[] points, int points_stride, float thickness, int num_segments);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_draw_ribbon(float[] points, int points_stride, AllegroColor color, float thickness, int num_segments);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_draw_prim(AllegroVertex[] vtxs, IntPtr decl, IntPtr texture, int start, int end, int type);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_draw_indexed_prim(AllegroVertex[] vtxs, IntPtr decl, IntPtr texture, int[] indices, int num_vtx, int type);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_draw_vertex_buffer(IntPtr vertex_buffer, IntPtr texture, int start, int end, int type);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_draw_indexed_buffer(IntPtr vertex_buffer, IntPtr texture, IntPtr index_buffer, int start, int end, int type);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_draw_soft_triangle(
      ref AllegroVertex v1,
      ref AllegroVertex v2,
      ref AllegroVertex v3,
      UIntPtr state,
      Delegates.DrawPrimitiveSoftTriangleInit init,
      Delegates.DrawPrimitiveSoftTriangleFirst first,
      Delegates.DrawPrimitiveStep step,
      Delegates.DrawPrimitiveSoftTriangleDraw draw);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_draw_soft_line(
      ref AllegroVertex v1,
      ref AllegroVertex v2,
      UIntPtr state,
      Delegates.DrawPrimitiveSoftLineFirst first,
      Delegates.DrawPrimitiveStep step,
      Delegates.DrawPrimitiveSoftLineDraw draw);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_create_vertex_decl(AllegroVertexElement[] elements, int stride);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_destroy_vertex_decl(IntPtr decl);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_create_vertex_buffer(IntPtr decl, IntPtr initial_data, int num_vertices, int flags);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_destroy_vertex_buffer(IntPtr buffer);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_lock_vertex_buffer(IntPtr buffer, int offset, int length, int flags);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_unlock_vertex_buffer(IntPtr buffer);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_vertex_buffer_size(IntPtr buffer);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_create_index_buffer(int index_size, IntPtr initial_data, int num_indices, int flags);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_destroy_index_buffer(IntPtr buffer);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_lock_index_buffer(IntPtr buffer, int offset, int length, int flags);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_unlock_index_buffer(IntPtr buffer);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_index_buffer_size(IntPtr buffer);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_draw_polyline(
      float[] vertices,
      int vertex_stride,
      int vertex_count,
      int join_style,
      int cap_style,
      AllegroColor color,
      float thickness,
      float miter_limit);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_draw_polygon(float[] vertices, int vertex_count, int join_style, AllegroColor color, float thickness, float miter_limit);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_draw_filled_polygon(float[] vertices, int vertex_count, AllegroColor color);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_draw_filled_polygon_with_holes(in float[] vertices, in int[] vertex_counts, AllegroColor color);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte al_triangulate_polygon(
      in float[] vertices, 
      UIntPtr vertex_stride, 
      in int[] vertex_counts,
      Delegates.TriangulatePolygonEmitTriangle emit_triangle,
      IntPtr userdata);

    #endregion

    public PrimitivesContext()
    {
      AlGetAllegroPrimitivesVersion = LoadFunction<al_get_allegro_primitives_version>();
      AlInitPrimitivesAddon = LoadFunction<al_init_primitives_addon>();
      AlIsPrimitivesAddonInitialized = LoadFunction<al_is_primitives_addon_initialized>();
      AlShutdownPrimitivesAddon = LoadFunction<al_shutdown_primitives_addon>();
      AlDrawLine = LoadFunction<al_draw_line>();
      AlDrawTriangle = LoadFunction<al_draw_triangle>();
      AlDrawFilledTriangle = LoadFunction<al_draw_filled_triangle>();
      AlDrawRectangle = LoadFunction<al_draw_rectangle>();
      AlDrawFilledRectangle = LoadFunction<al_draw_filled_rectangle>();
      AlDrawRoundedRectangle = LoadFunction<al_draw_rounded_rectangle>();
      AlDrawFilledRoundedRectangle = LoadFunction<al_draw_filled_rounded_rectangle>();
      AlCalculateArc = LoadFunction<al_calculate_arc>();
      AlDrawPieslice = LoadFunction<al_draw_pieslice>();
      AlDrawFilledPieslice = LoadFunction<al_draw_filled_pieslice>();
      AlDrawEllipse = LoadFunction<al_draw_ellipse>();
      AlDrawFilledEllipse = LoadFunction<al_draw_filled_ellipse>();
      AlDrawCircle = LoadFunction<al_draw_circle>();
      AlDrawFilledCircle = LoadFunction<al_draw_filled_circle>();
      AlDrawArc = LoadFunction<al_draw_arc>();
      AlDrawEllipticalArc = LoadFunction<al_draw_elliptical_arc>();
      AlCalculateSpline = LoadFunction<al_calculate_spline>();
      AlDrawSpline = LoadFunction<al_draw_spline>();
      AlCalculateRibbon = LoadFunction<al_calculate_ribbon>();
      AlDrawRibbon = LoadFunction<al_draw_ribbon>();
      AlDrawPrim = LoadFunction<al_draw_prim>();
      AlDrawIndexedPrim = LoadFunction<al_draw_indexed_prim>();
      AlDrawVertexBuffer = LoadFunction<al_draw_vertex_buffer>();
      AlDrawIndexedBuffer = LoadFunction<al_draw_indexed_buffer>();
      AlDrawSoftTriangle = LoadFunction<al_draw_soft_triangle>();
      AlDrawSoftLine = LoadFunction<al_draw_soft_line>();
      AlCreateVertexDecl = LoadFunction<al_create_vertex_decl>();
      AlDestroyVertexDecl = LoadFunction<al_destroy_vertex_decl>();
      AlCreateVertexBuffer = LoadFunction<al_create_vertex_buffer>();
      AlDestroyVertexBuffer = LoadFunction<al_destroy_vertex_buffer>();
      AlLockVertexBuffer = LoadFunction<al_lock_vertex_buffer>();
      AlUnlockVertexBuffer = LoadFunction<al_unlock_vertex_buffer>();
      AlGetVertexBufferSize = LoadFunction<al_get_vertex_buffer_size>();
      AlCreateIndexBuffer = LoadFunction<al_create_index_buffer>();
      AlDestroyIndexBuffer = LoadFunction<al_destroy_index_buffer>();
      AlLockIndexBuffer = LoadFunction<al_lock_index_buffer>();
      AlUnlockIndexBuffer = LoadFunction<al_unlock_index_buffer>();
      AlGetIndexBufferSize = LoadFunction<al_get_index_buffer_size>();
      AlDrawPolyline = LoadFunction<al_draw_polyline>();
      AlDrawPolygon = LoadFunction<al_draw_polygon>();
      AlDrawFilledPolygon = LoadFunction<al_draw_filled_polygon>();
      AlDrawFilledPolygonWithHoles = LoadFunction<al_draw_filled_polygon_with_holes>();
      AlTriangulatePolygon = LoadFunction<al_triangulate_polygon>();
    }
  }
}
