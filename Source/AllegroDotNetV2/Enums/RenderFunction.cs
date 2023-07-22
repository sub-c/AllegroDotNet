namespace SubC.AllegroDotNet.Enums;

/// <summary>
/// Render functions.
/// </summary>
public enum RenderFunction : int
{
  /// <summary>
  /// Never.
  /// </summary>
  Never = 0,
  
  /// <summary>
  /// Always.
  /// </summary>
  Always,
  
  /// <summary>
  /// Less than.
  /// </summary>
  Less,
  
  /// <summary>
  /// If equal.
  /// </summary>
  Equal,
  
  /// <summary>
  /// If less than or equal.
  /// </summary>
  LessEqual,
  
  /// <summary>
  /// Greater than.
  /// </summary>
  Greater,
  
  /// <summary>
  /// Not equal.
  /// </summary>
  NotEqual,
  
  /// <summary>
  /// Greater than or equal.
  /// </summary>
  GreaterEqual
}