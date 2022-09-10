namespace SubC.AllegroDotNet.Enums
{
  /// <summary>
  /// Specifies the relatively of a seek.
  /// </summary>
  public enum Seek : int
  {
    /// <summary>
    /// Seek relative to beginning of file.
    /// </summary>
    Set = 0,

    /// <summary>
    /// Seek relative to current file position.
    /// </summary>
    Current,

    /// <summary>
    /// Seek relative to end of file.
    /// </summary>
    End
  }
}
