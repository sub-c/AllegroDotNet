namespace SubC.AllegroDotNet.Enums;

/// <summary>
/// The display orientation.
/// </summary>
public enum DisplayOrientation : int
{
  /// <summary>
  /// Unknown/failure to detect display orientation.
  /// </summary>
  Unknown = 0,

  /// <summary>
  /// 0-degree of rotation.
  /// </summary>
  Degrees0 = 1,

  /// <summary>
  /// 90-degrees of rotation.
  /// </summary>
  Degrees90 = 2,

  /// <summary>
  /// 180-degrees of rotation.
  /// </summary>
  Degrees180 = 4,

  /// <summary>
  /// 270-degrees of rotation.
  /// </summary>
  Degrees270 = 8,

  /// <summary>
  /// Portrait orientation.
  /// </summary>
  Portrait = 5,

  /// <summary>
  /// Landscape orientation.
  /// </summary>
  Landscape = 10,

  /// <summary>
  /// Both portrait and landscape orientation.
  /// </summary>
  All = 15,

  /// <summary>
  /// Face up orientation.
  /// </summary>
  FaceUp = 16,

  /// <summary>
  /// Face down orientation.
  /// </summary>
  FaceDown = 32
}
