namespace SubC.AllegroDotNet.Enums;

/// <summary>
/// This enumeration provides the different types an Allegro event can be.
/// </summary>
public enum EventType : int
{
  /// <summary>
  /// Joystick axis event.
  /// </summary>
  JoystickAxis = 1,
  
  /// <summary>
  /// Joystick button down event.
  /// </summary>
  JoystickButtonDown = 2,
  
  /// <summary>
  /// Joystick button up event.
  /// </summary>
  JoystickButtonUp = 3,
  
  /// <summary>
  /// Joystick configuration changed event (plugged in/out).
  /// </summary>
  JoystickConfiguration = 4,

  /// <summary>
  /// Keyboard key down event.
  /// </summary>
  KeyDown = 10,
  
  /// <summary>
  /// Keyboard character typed event.
  /// </summary>
  KeyChar = 11,
  
  /// <summary>
  /// Keyboard key up event.
  /// </summary>
  KeyUp = 12,

  /// <summary>
  /// Mouse axis changed event.
  /// </summary>
  MouseAxes = 20,
  
  /// <summary>
  /// Mouse button down event.
  /// </summary>
  MouseButtonDown = 21,
  
  /// <summary>
  /// Mouse button up event.
  /// </summary>
  MouseButtonUp = 22,
  
  /// <summary>
  /// Mouse entered display event.
  /// </summary>
  MouseEnterDisplay = 23,
  
  /// <summary>
  /// Mouse left display event.
  /// </summary>
  MouseLeaveDisplay = 24,
  
  /// <summary>
  /// Mouse warp (snap to position) event.
  /// </summary>
  MouseWarped = 25,

  /// <summary>
  /// Timer tick event.
  /// </summary>
  Timer = 30,

  /// <summary>
  /// Display exposed event.
  /// </summary>
  DisplayExpose = 40,
  
  /// <summary>
  /// Display resized event.
  /// </summary>
  DisplayResize = 41,
  
  /// <summary>
  /// Display close (ALT+F4, close button clicked, etc) event.
  /// </summary>
  DisplayClose = 42,
  
  /// <summary>
  /// Display lost focus event.
  /// </summary>
  DisplayLost = 43,
  
  /// <summary>
  /// Display gained focus event.
  /// </summary>
  DisplayFound = 44,
  
  /// <summary>
  /// Display switched to focus event.
  /// </summary>
  DisplaySwitchIn = 45,
  
  /// <summary>
  /// Display switched out of focus event.
  /// </summary>
  DisplaySwitchOut = 46,
  
  /// <summary>
  /// Display orientation changed event.
  /// </summary>
  DisplayOrientation = 47,
  
  /// <summary>
  /// Display told to stop drawing event.
  /// </summary>
  DisplayHaltDrawing = 48,
  
  /// <summary>
  /// Display told to resume drawing event.
  /// </summary>
  DisplayResumeDrawing = 49,

  /// <summary>
  /// Touch event begin event.
  /// </summary>
  TouchBegin = 50,
  
  /// <summary>
  /// Touch event ended event.
  /// </summary>
  TouchEnd = 51,
  
  /// <summary>
  /// Touch moved event.
  /// </summary>
  TouchMove = 52,
  
  /// <summary>
  /// Touch cancel event.
  /// </summary>
  TouchCancel = 53,

  /// <summary>
  /// Display connected event.
  /// </summary>
  DisplayConnected = 60,
  
  /// <summary>
  /// Display disconnected event.
  /// </summary>
  DisplayDisconnected = 61,

  /// <summary>
  /// Native add-on only. Native dialog closed event.
  /// </summary>
  NativeDialogClose = 600,
  
  /// <summary>
  /// Native add-on only. Native menu clicked event.
  /// </summary>
  MenuClick = 601
}