namespace SubC.AllegroDotNet.Enums;

/// <summary>
/// Key modifier flags for the keyboard modifier keys.
/// </summary>
[Flags]
public enum KeyMods : int
{
  /// <summary>
  /// The reset button.
  /// </summary>
  Reset = -1,
  
  /// <summary>
  /// The shift modifier.
  /// </summary>
  Shift = 0x00001,
  
  /// <summary>
  /// The control modifier.
  /// </summary>
  Ctrl = 0x00002,
  
  /// <summary>
  /// The alt modifier.
  /// </summary>
  Alt = 0x00004,
  
  /// <summary>
  /// The left windows modifier.
  /// </summary>
  LWin = 0x00008,
  
  /// <summary>
  /// The right windows modifier.
  /// </summary>
  RWin = 0x00010,
  
  /// <summary>
  /// The menu modifier.
  /// </summary>
  Menu = 0x00020,
  
  /// <summary>
  /// The alt gr modifier.
  /// </summary>
  AltGr = 0x00040,
  
  /// <summary>
  /// The command modifier (OSX).
  /// </summary>
  Command = 0x00080,
  
  /// <summary>
  /// The scroll lock modifier.
  /// </summary>
  ScrollLock  = 0x00100,
  
  /// <summary>
  /// The number lock modifier.
  /// </summary>
  NumLock = 0x00200,
  
  /// <summary>
  /// The capital lock modifier.
  /// </summary>
  CapsLock = 0x00400,
  
  /// <summary>
  /// The in alt seq modifier.
  /// </summary>
  InAltSeq = 0x00800,
  
  /// <summary>
  /// The accent 1 modifier.
  /// </summary>
  Accent1 = 0x01000,
  
  /// <summary>
  /// The accent 2 modifier.
  /// </summary>
  Accent2 = 0x02000,
  
  /// <summary>
  /// The accent 3 modifier.
  /// </summary>
  Accent3 = 0x04000,
  
  /// <summary>
  /// The accent 4 modifier.
  /// </summary>
  Accent4 = 0x08000
}