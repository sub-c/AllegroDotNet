namespace AllegroDotNet.Models.Enums
{
    /// <summary>
    /// Indicates what properties of <see cref="AllegroEvent"/> are filled out, based on the event that occurred.
    /// </summary>
    public enum EventType : int
    {
        /// <summary>
        /// A joystick axis value changed.
        /// </summary>
        JoystickAxis = 1,

        /// <summary>
        /// A joystick button was pressed.
        /// </summary>
        JoystickButtonDown = 2,

        /// <summary>
        /// A joystick button was released.
        /// </summary>
        JoystickButtonUp = 3,

        /// <summary>
        /// A joystick was plugged in or unplugged. See <see cref="Al.ReconfigureJoysticks()"/> for details.
        /// </summary>
        JoystickConfiguration = 4,

        /// <summary>
        /// A keyboard key was pressed.
        /// </summary>
        KeyDown = 10,

        /// <summary>
        /// A character was typed on the keyboard, or a character was auto-repeated.
        /// </summary>
        KeyChar = 11,

        /// <summary>
        /// A keyboard key was released.
        /// </summary>
        KeyUp = 12,

        /// <summary>
        /// One or more mouse axis values changed.
        /// </summary>
        MouseAxes = 20,

        /// <summary>
        /// A mouse button was pressed.
        /// </summary>
        MouseButtonDown = 21,

        /// <summary>
        /// A mouse button was released.
        /// </summary>
        MouseButtonUp = 22,

        /// <summary>
        /// The mouse cursor entered a window opened by the program.
        /// </summary>
        MouseEnterDisplay = 23,

        /// <summary>
        /// The mouse cursor left the boundaries of a window opened by the program.
        /// </summary>
        MouseLeaveDisplay = 24,

        /// <summary>
        /// <see cref="Al.SetMouseXY()"/> was called to move the mouse.
        /// This event is identical to <see cref="MouseAxes"/> otherwise.
        /// </summary>
        MouseWarped = 25,

        /// <summary>
        /// A timer counter incremented.
        /// </summary>
        Timer = 30,

        /// <summary>
        /// The display (or a portion thereof) has become visible.
        /// </summary>
        DisplayExpose = 40,

        /// <summary>
        /// The window has been resized.
        /// </summary>
        DisplayResize = 41,

        /// <summary>
        /// The close button of the window has been pressed.
        /// </summary>
        DisplayClose = 42,

        /// <summary>
        /// When using Direct3D, displays can enter a "lost" state. In that state, drawing calls are ignored, and upon
        /// entering the state, bitmap's pixel data can become undefined. Allegro does its best to preserve the
        /// correct contents of bitmaps (see the <see cref="BitmapOption.NoPreserveTexture"/> flag) and restore them
        /// when the device is "found" (see <see cref="DisplayFound"/>). However, this is not 100% fool proof (see
        /// discussion in <see cref="Al.CreateBitmap()"/>'s documentation).
        /// </summary>
        DisplayLost = 43,

        /// <summary>
        /// Generated when a lost device is restored to operating state. See <see cref="DisplayLost"/>.
        /// </summary>
        DisplayFound = 44,

        /// <summary>
        /// The window is the active once again.
        /// </summary>
        DisplaySwitchIn = 45,

        /// <summary>
        /// The window is no longer active, that is the user might have clicked into another window or "tabbed" away.
        /// In response to this event you might want to call <see cref="Al.ClearKeyboardState()"/> (possibly passing
        /// <see cref="AllegroEvent.DisplaySource"/> as its argument) in order to prevent Allegro's keyboard state
        /// from getting out of sync.
        /// </summary>
        DisplaySwitchOut = 46,

        /// <summary>
        /// Generated when the rotation or orientation of a display changes.
        /// </summary>
        DisplayOrientation = 47,

        /// <summary>
        /// When a display receives this event it should stop doing any drawing and then call
        /// al_acknowledge_drawing_halt immediately.
        /// 
        /// This is currently only relevant for Android and iOS. It will be sent when the application is switched to
        /// background mode, in addition to ALLEGRO_EVENT_DISPLAY_SWITCH_OUT.
        /// The latter may also be sent in situations where the application is not active but still should continue
        /// drawing, for example when a popup is displayed in front of it.
        /// 
        /// Note: This event means that the next time you call a drawing function, your program will crash. So you
        /// must stop drawing and you must immediately reply with al_acknowledge_drawing_halt. Allegro sends this
        /// event because it cannot handle this automatically. Your program might be doing the drawing in a different
        /// thread from the event handling, in which case the drawing thread needs to be signaled to stop drawing
        /// before acknowledging this event.
        /// 
        /// Note: Mobile devices usually never quit an application, so to prevent the battery from draining while
        /// your application is halted it can be a good idea to call al_stop_timer on all your timers, otherwise
        /// they will keep generating events. If you are using audio, you can also stop all audio voices (or pass
        /// NULL to al_set_default_voice if you use the default mixer), otherwise Allegro will keep streaming silence
        /// to the voice even if the stream or mixer are stopped or detached.
        /// 
        /// 
        /// </summary>
        DisplayHaltDrawing = 48,

        /// <summary>
        /// When a display receives this event, it may resume drawing again, and it must call
        /// al_acknowledge_drawing_resume immediately.
        /// 
        /// This is currently only relevant for Android and iOS. The event will be sent when an application returns
        /// from background mode and is allowed to draw to the display again, in addition to
        /// ALLEGRO_EVENT_DISPLAY_SWITCH_IN. The latter event may also be sent in a situation where the
        /// application is already active, for example when a popup in front of it closes.
        /// 
        /// Note: Unlike <see cref="DisplayFound"/> it is not necessary to reload any bitmaps
        /// when you receive this event.
        /// </summary>
        DisplayResumeDrawing = 49,

        /// <summary>
        /// The touch input device registered a new touch.
        /// </summary>
        TouchBegin = 50,

        /// <summary>
        /// A touch ended.
        /// </summary>
        TouchEnd = 51,

        /// <summary>
        /// The position of a touch changed.
        /// </summary>
        TouchMove = 52,

        /// <summary>
        /// A touch was cancelled. This is device specific but could for example mean that a finger moved off the
        /// border of the device or moved so fast that it could not be tracked any longer.
        /// </summary>
        TouchCancel = 53,


        /// <summary>
        /// This event is sent when a physical display is connected to the device Allegro runs on. Currently, on
        /// most platforms, Allegro supports only a single physical display. However, on iOS, a secondary physical
        /// display is supported.
        /// </summary>
        DisplayConnected = 60,

        /// <summary>
        /// This event is sent when a physical display is disconnected from the device Allegro runs on. Currently,
        /// on most platforms, Allegro supports only a single physical display. However, on iOS, a secondary
        /// physical display is supported.
        /// </summary>
        DisplayDisconnected = 61
    }
}
