using System.Runtime.InteropServices;
using SubC.AllegroDotNet.Enums;
using SubC.AllegroDotNet.Native;

namespace SubC.AllegroDotNet.Models;

/// <summary>
/// This class represents an event in Allegro.
/// </summary>
public sealed class AllegroEvent : NativeStruct<Native.Structs.AllegroEvent>
{
  /// <summary>
  /// Gets the display specific event data.
  /// </summary>
  public Display Display { get; }
  
  /// <summary>
  /// Gets the joystick specific event data.
  /// </summary>
  public Joystick Joystick { get; }
  
  /// <summary>
  /// Gets the keyboard specific event data.
  /// </summary>
  public Keyboard Keyboard { get; }

  /// <summary>
  /// Gets or sets the source which generated the event.
  /// </summary>
  public IntPtr Source
  {
    get => Struct.any.source;
    set => Struct.any.source = value;
  }
  
  /// <summary>
  /// Gets the timer specific event data.
  /// </summary>
  public Timer Timer { get; }

  /// <summary>
  /// Gets or sets the timestamp when the event was generated.
  /// </summary>
  public double Timestamp
  {
    get => Struct.any.timestamp;
    set => Struct.any.timestamp = value;
  }

  /// <summary>
  /// Gets or sets the type of event.
  /// </summary>
  public EventType Type
  {
    get => (EventType)Struct.any.type;
    set => Struct.any.type = (uint)value;
  }

  /// <summary>
  /// The user event data.
  /// </summary>
  public User User { get; }

  /// <summary>
  /// Initialize a new instance of the <see cref="AllegroEvent"/> class.
  /// </summary>
  public AllegroEvent()
  {
    Display = new Display(this);
    Joystick = new Joystick(this);
    Keyboard = new Keyboard(this);
    Timer = new Timer(this);
    User = new User(this);
  }
}

/// <summary>
/// This class holds the display specific event data.
/// </summary>
public sealed class Display
{
  /// <summary>
  /// The height of the rectangle for the event.
  /// </summary>
  public int Height
  {
    get => _instance.Struct.display.height;
    set => _instance.Struct.display.height = value;
  }

  /// <summary>
  /// The orientation of the event.
  /// </summary>
  public DisplayOrientation Orientation
  {
    get => (DisplayOrientation)_instance.Struct.display.orientation;
    set => _instance.Struct.display.orientation = (int)value;
  }
  
  /// <summary>
  /// The width of the rectangle for the event.
  /// </summary>
  public int Width
  {
    get => _instance.Struct.display.width;
    set => _instance.Struct.display.width = value;
  }
  
  /// <summary>
  /// The X position of the top-left corner of the rectangle for the event.
  /// </summary>
  public int X
  {
    get => _instance.Struct.display.x;
    set => _instance.Struct.display.x = value;
  }

  /// <summary>
  /// The Y position for the top-left corner of the rectangle for the event.
  /// </summary>
  public int Y
  {
    get => _instance.Struct.display.y;
    set => _instance.Struct.display.y = value;
  }
  
  private readonly NativeStruct<Native.Structs.AllegroEvent> _instance;
  
  internal Display(NativeStruct<Native.Structs.AllegroEvent> instance)
  {
    _instance = instance;
  }
}

/// <summary>
/// This class holds the joystick specific event data.
/// </summary>
public sealed class Joystick
{
  /// <summary>
  /// Gets or sets the axis number on the stick, counting from zero.
  /// </summary>
  public int Axis
  {
    get => _instance.Struct.joystick.axis;
    set => _instance.Struct.joystick.axis = value;
  }

  /// <summary>
  /// Gets or sets the button pressed or released, counting from zero.
  /// </summary>
  public int Button
  {
    get => _instance.Struct.joystick.button;
    set => _instance.Struct.joystick.button = value;
  }
  
  /// <summary>
  /// Gets or sets the joystick that generated the event. This is different than the event source.
  /// </summary>
  public IntPtr Id
  {
    get => _instance.Struct.joystick.id;
    set => _instance.Struct.joystick.id = value;
  }

  /// <summary>
  /// Gets or sets the axis position, from -1.0 to +1.0.
  /// </summary>
  public float Pos
  {
    get => _instance.Struct.joystick.pos;
    set => _instance.Struct.joystick.pos = value;
  }

  /// <summary>
  /// Gets or sets the stick number, counting from zero. Axes on a joystick are grouped into “sticks”. 
  /// </summary>
  public int Stick
  {
    get => _instance.Struct.joystick.stick;
    set => _instance.Struct.joystick.stick = value;
  }
  
  private readonly NativeStruct<Native.Structs.AllegroEvent> _instance;
  
  internal Joystick(NativeStruct<Native.Structs.AllegroEvent> instance)
  {
    _instance = instance;
  }
}

/// <summary>
/// This class holds keyboard specific event data.
/// </summary>
public sealed class Keyboard
{
  /// <summary>
  /// Gets or sets the display which had keyboard focus when the event occurred.
  /// </summary>
  public AllegroDisplay? Display
  {
    get => NativePointer.Create<AllegroDisplay>(_instance.Struct.keyboard.display);
    set => _instance.Struct.keyboard.display = NativePointer.Get(value);
  }
  
  /// <summary>
  /// Gets or sets the code corresponding to the physical key which was pressed.
  /// </summary>
  public KeyCode KeyCode
  {
    get => (KeyCode)_instance.Struct.keyboard.keycode;
    set => _instance.Struct.keyboard.keycode = (int)value;
  }

  /// <summary>
  /// Gets or sets the bitfield of the modifier keys which were pressed when the event occurred.
  /// </summary>
  public uint Modifiers
  {
    get => _instance.Struct.keyboard.modifiers;
    set => _instance.Struct.keyboard.modifiers = value;
  }

  /// <summary>
  /// Gets or sets if this is a repeated character.
  /// </summary>
  public bool Repeat
  {
    get => _instance.Struct.keyboard.repeat != 0;
    set => _instance.Struct.keyboard.repeat = (byte)(value ? 1 : 0);
  }

  /// <summary>
  /// <para>
  /// A Unicode code point (character). This may be zero or negative if the event was generated for a non-visible
  /// “character”, such as an arrow or Function key. In that case you can act upon the <see cref="KeyCode"/> field.
  /// </para>
  /// <para>
  /// Some special keys will set the unichar field to their standard ASCII values: Tab=9, Return=13,
  /// Escape=27. In addition if you press the Control key together with A to Z the unichar field will have
  /// the values 1 to 26. For example Ctrl-A will set unichar to 1 and Ctrl-H will set it to 8.
  /// </para>
  /// <para>
  /// As of Allegro 5.0.2 there are some inconsistencies in the treatment of Backspace (8 or 127)
  /// and Delete (127 or 0) keys on different platforms. These can be worked around by checking the
  /// <see cref="KeyCode"/> field.
  /// </para>
  /// </summary>
  public int Unichar
  {
    get => _instance.Struct.keyboard.unichar;
    set => _instance.Struct.keyboard.unichar = value;
  }
  
  private readonly NativeStruct<Native.Structs.AllegroEvent> _instance;

  internal Keyboard(NativeStruct<Native.Structs.AllegroEvent> instance)
  {
    _instance = instance;
  }
}

/// <summary>
/// This class holds the timer specific event data.
/// </summary>
public sealed class Timer
{
  /// <summary>
  /// Gets or sets the timer count value.
  /// </summary>
  public long Count
  {
    get => _instance.Struct.timer.count;
    set => _instance.Struct.timer.count = value;
  }
  
  /// <summary>
  /// Gets or sets the timer that generated the event.
  /// </summary>
  public AllegroTimer? Source
  {
    get => NativePointer.Create<AllegroTimer>(_instance.Struct.any.source);
    set => _instance.Struct.any.source = NativePointer.Get(value);
  }
  
  private readonly NativeStruct<Native.Structs.AllegroEvent> _instance;

  internal Timer(NativeStruct<Native.Structs.AllegroEvent> instance)
  {
    _instance = instance;
  }
}

/// <summary>
/// This class holds the user event specific data.
/// </summary>
public sealed class User
{
  /// <summary>
  /// Gets or sets the user data native data pointer.
  /// </summary>
  public IntPtr Data1
  {
    get => _instance.Struct.user.data1;
    set => _instance.Struct.user.data1 = value;
  }
  
  /// <summary>
  /// Gets or sets the user data native data pointer.
  /// </summary>
  public IntPtr Data2
  {
    get => _instance.Struct.user.data2;
    set => _instance.Struct.user.data2 = value;
  }
  
  /// <summary>
  /// Gets or sets the user data native data pointer.
  /// </summary>
  public IntPtr Data3
  {
    get => _instance.Struct.user.data3;
    set => _instance.Struct.user.data3 = value;
  }
  
  /// <summary>
  /// Gets or sets the user data native data pointer.
  /// </summary>
  public IntPtr Data4
  {
    get => _instance.Struct.user.data4;
    set => _instance.Struct.user.data4 = value;
  }
  
  private readonly NativeStruct<Native.Structs.AllegroEvent> _instance;

  internal User(NativeStruct<Native.Structs.AllegroEvent> instance)
  {
    _instance = instance;
  }
}