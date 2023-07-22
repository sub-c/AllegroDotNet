namespace SubC.AllegroDotNet.Models;

/// <summary>
/// This class is a partially opaque class that holds the state of the keyboard keys.
/// </summary>
public sealed class AllegroKeyboardState : NativeStruct<Native.Structs.AllegroKeyboardState>
{
  /// <summary>
  /// Gets or sets the display which received the keyboard input.
  /// </summary>
  public AllegroDisplay? Display
  {
    get => NativePointer.Create<AllegroDisplay>(Struct.display);
    set => Struct.display = NativePointer.Get(value);
  }
}