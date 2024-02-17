namespace SubC.AllegroDotNet.Enums;

/// <summary>
/// Sets the importance of applying a display option.
/// </summary>
public enum DisplayImportance : int
{
  /// <summary>
  /// If you added a display option with one of the above two settings before, it will be removed again. Else this
  /// does nothing.
  /// </summary>
  DontCare,

  /// <summary>
  /// The display will not be created if the setting can not be met.
  /// </summary>
  Require,

  /// <summary>
  /// If the setting is not available, the display will be created anyway with a setting as close as possible to the
  /// requested one. You can query the actual value used in that case by calling <see cref="Al.GetDisplayOption"/>
  /// after the display has been created.
  /// </summary>
  Suggest
}
