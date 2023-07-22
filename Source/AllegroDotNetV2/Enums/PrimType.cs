namespace SubC.AllegroDotNet.Enums;

/// <summary>
/// This enumeration specifies a primitive type.
/// </summary>
public enum PrimType : int
{
  /// <summary>
  /// List of lines.
  /// </summary>
  LineList = 0,
  
  /// <summary>
  /// Strip of lines.
  /// </summary>
  LineStrip,
  
  /// <summary>
  /// Loop of lines.
  /// </summary>
  LineLoop,
  
  /// <summary>
  /// List of triangles.
  /// </summary>
  TriangleList,
  
  /// <summary>
  /// Strip of triangles.
  /// </summary>
  TriangleStrip,
  
  /// <summary>
  /// Fan of triangles.
  /// </summary>
  TriangleFan,
  
  /// <summary>
  /// List of points.
  /// </summary>
  PointList
}