namespace SubC.AllegroDotNet.Enums;

public enum EventType : int
{
    JoystickAxis = 1,
    JoystickButtonDown = 2,
    JoystickButtonUp = 3,
    JoystickConfiguration = 4,

    KeyDown = 10,
    KeyChar = 11,
    KeyUp = 12,

    MouseAxes = 20,
    MouseButtonDown = 21,
    MouseButtonUp = 22,
    MouseEnterDisplay = 23,
    MouseLeaveDisplay = 24,
    MouseWarped = 25,

    Timer = 30,

    DisplayExpose = 40,
    DisplayResize = 41,
    DisplayClose = 42,
    DisplayLost = 43,
    DisplayFound = 44,
    DisplaySwitchIn = 45,
    DisplaySwitchOut = 46,
    DisplayOrientation = 47,
    DisplayHaltDrawing = 48,
    DisplayResumeDrawing = 49,

    TouchBegin = 50,
    TouchEnd = 51,
    TouchMove = 52,
    TouchCancel = 53,

    DisplayConnected = 60,
    DisplayDisconnected = 61,

    // Video streaming addon
    VideoFrameShow = 550,
    VideoFinished = 551,

    // Native dialog addon
    NativeDialogClose = 600,
    MenuClick = 601
}
