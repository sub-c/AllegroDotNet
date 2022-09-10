using SubC.AllegroDotNet;
using SubC.AllegroDotNet.Enums;
using SubC.AllegroDotNet.Extensions;
using SubC.AllegroDotNet.Models;
using System;
using System.Runtime.InteropServices;

internal static class Program
{
  private const ushort FileExitID = 1;

  public static IntPtr MyBitmapLoader(IntPtr filename, int flags)
  {
    return IntPtr.Zero;
  }

  public static IntPtr MyThreadProcess(IntPtr nativeThread, IntPtr arg)
  {
    return IntPtr.Zero;
  }

  public static void Main(string[] args)
  {
    Console.WriteLine($"InstallSystem: {Al.InstallSystem(Al.ALLEGRO_VERSION_INT, null)}");
    Console.WriteLine($"InstallKeyboard: {Al.InstallKeyboard()}");
    Console.WriteLine($"InstallJoystick: {Al.InstallJoystick()}");
    Console.WriteLine($"InstallMouse: {Al.InstallMouse()}");
    Console.WriteLine($"IsSystemInstalled: {Al.IsSystemInstalled()}");
    Console.WriteLine($"GetAllegroVersion: {Al.GetAllegroVersion()}");
    Console.WriteLine($"GetTime: {Al.GetTime()}");
    Console.WriteLine($"CPU Count: {Al.GetCpuCount()}");
    Console.WriteLine($"RAM Size: {Al.GetRamSize()}");

    Console.WriteLine($"IsNativeDialog: {Al.IsNativeDialogAddonInitialized()}");
    Console.WriteLine($"InitNativeDialog: {Al.InitNativeDialogAddon()}");
    Console.WriteLine($"InitImageAddon: {Al.InitImageAddon()}");
    Console.WriteLine($"InitFont: {Al.InitFontAddon()}");
    Console.WriteLine($"InitTtf: {Al.InitTtfAddon()}");

    Console.WriteLine($"InstallAudio: {Al.InstallAudio()}");
    Console.WriteLine($"ReserveSamples: {Al.ReserveSamples(16)}");
    Console.WriteLine($"InitACodec: {Al.InitAcodecAddon()}");

    var sample = Al.LoadSample("E:/intro_music.ogg");
    AllegroSampleInstance? sampleInstance = default;
    AllegroVoice? voice = default;
    AllegroMixer? mixer = default;
    if (sample != null)
    {
      //Al.PlaySample(sample, 1, 0, 1, Playmode.Once, null);
      voice = Al.CreateVoice(44100, AudioDepth.Int16, ChannelConfig.Channels2) ?? throw new Exception("no voice");
      mixer = Al.CreateMixer(44100, AudioDepth.Float32, ChannelConfig.Channels2) ?? throw new Exception("no mixer");
      Al.AttachMixerToVoice(mixer, voice);

      sampleInstance = Al.CreateSampleInstance(sample);
      Al.AttachSampleInstanceToMixer(sampleInstance, mixer);

      Al.SetSampleInstancePlaymode(sampleInstance, Playmode.Once);
      Al.SetSampleInstanceGain(sampleInstance, 0.5f);
      Al.PlaySampleInstance(sampleInstance);
    }

    var fileInterface = new AllegroFileInterface();
    //  public delegate IntPtr FileInterfaceFOpen(IntPtr path, IntPtr mode);
    fileInterface.FOpen = (x, y) =>
    {
      var thePath = Marshal.PtrToStringAnsi(x);
      var theMode = Marshal.PtrToStringAnsi(y);
      return IntPtr.Zero;
    };
    var fOpenedInterface = Al.FOpenInterface(fileInterface, "E:/intro_music.ogg", FileMode.ReadAccess | FileMode.UsingBinary);

    Console.WriteLine($"Num Video Adapters: {Al.GetNumVideoAdapters()}");
    for (var index = 0; index < Al.GetNumVideoAdapters(); ++index)
    {
      Al.GetMonitorInfo(index, out var info);
      Console.WriteLine($"Adapter#{index}: {info.X1},{info.Y1} {info.X2},{info.Y2}");
    }
    Console.WriteLine($"Display Modes: {Al.GetNumDisplayModes()}");
    var displayMode = new AllegroDisplayMode();
    displayMode = Al.GetDisplayMode(0, displayMode);

    var numJoysticks = Al.GetNumJoysticks();
    Console.WriteLine($"Joysticks detected: {numJoysticks}");
    if (numJoysticks > 0)
    {
      var joystick = Al.GetJoystick(0) ?? throw new Exception("joy null");
      Console.WriteLine($"Joystick name: {Al.GetJoystickName(joystick)}");
      AllegroJoystickState joystickState = new();
      Al.GetJoystickState(joystick, joystickState);
    }

    var config = Al.CreateConfig() ?? throw new Exception();
    Al.SetConfigValue(config, "Options", "FullScreen", "false");
    Al.SaveConfigFile("duck.cfg", config);
    Al.DestroyConfig(config);

    var exePath = Al.GetStandardPath(StandardPath.ExeNamePath) ?? throw new Exception();
    var exeFilename = Al.GetPathFilename(exePath);
    var exeCstr = Al.PathCstr(exePath, Al.ALLEGRO_NATIVE_PATH_SEP);
    var exeUstr = Al.PathUstr(exePath, Al.ALLEGRO_NATIVE_PATH_SEP);

    var utfIn = Al.UstrNew("hello world");
    var utfOut = Al.Cstr(utfIn);
    Console.WriteLine($"UTF output: {utfOut}");

    var state = new AllegroState();
    Al.StoreState(state, StateFlags.All);
    Al.RestoreState(state);

    var timeout = new AllegroTimeout();
    Al.InitTimeout(timeout, 2);

    var display = Al.CreateDisplay(1280, 720) ?? throw new Exception("disp null");
    var displayEventSource = Al.GetDisplayEventSource(display) ?? throw new Exception("disp source null");

    var windowHandle = Al.GetWinWindowHandle(display);

    var builtinFont = Al.CreateBuiltinFont();

    var menu = Al.CreateMenu();
    var fileMenu = Al.CreateMenu();
    Al.AppendMenuItem(fileMenu, "New", 2, MenuItem.Enabled, null, null);
    Al.AppendMenuItem(fileMenu, "Open", 3, MenuItem.Enabled, null, null);
    Al.AppendMenuItem(fileMenu, "Save", 4, MenuItem.Enabled, null, null);
    Al.AppendMenuItem(fileMenu, "Exit", FileExitID, MenuItem.Enabled, null, null);
    Al.AppendMenuItem(menu, "File", 2, MenuItem.Enabled, null, fileMenu);
    Al.SetDisplayMenu(display, menu);

    //var fileDialog = Al.CreateNativeFileDialog("D:/", "My title", "*.*", FileChooser.FileMustExist) ?? throw new NullReferenceException(); ;
    //Al.ShowNativeFileDialog(display, fileDialog);

    var mouseCursorBitmap = Al.CreateBitmap(64, 64) ?? throw new Exception();
    //Al.SetTargetBitmap(mouseCursorBitmap);
    mouseCursorBitmap.SetTargetBitmap();
    Al.ClearToColor(Al.MapRgb(50, 50, 200));
    var mouseCursor = Al.CreateMouseCursor(mouseCursorBitmap, 0, 0) ?? throw new Exception();
    Al.SetMouseCursor(display, mouseCursor);

    var timer = Al.CreateTimer(Al.BpsToSecs(60)) ?? throw new Exception("timer null");
    //var timerEventSource = Al.GetTimerEventSource(timer) ?? throw new Exception("timer source null");
    var timerEventSource = timer.GetTimerEventSource() ?? throw new Exception("timer source null");

    var eventQueue = Al.CreateEventQueue() ?? throw new Exception("eq null");
    //Al.RegisterEventSource(eventQueue, displayEventSource);
    eventQueue.RegisterEventSource(display.GetDisplayEventSource());
    Al.RegisterEventSource(eventQueue, timerEventSource);
    Al.RegisterEventSource(eventQueue, Al.GetKeyboardEventSource() ?? throw new Exception("key source null"));
    Al.RegisterEventSource(eventQueue, Al.GetDefaultMenuEventSource());
    Al.StartTimer(timer);

    Al.InitUserEventSource(out var userEventSource);
    Al.RegisterEventSource(eventQueue, userEventSource);

    Al.SetNewBitmapFlags(BitmapFlags.ConvertBitmap | BitmapFlags.NoPreserveTexture);
    var bitmap = Al.CreateBitmap(320, 240) ?? throw new Exception("!");
    var redColor = Al.MapRgb(128, 32, 64);
    var lockedRegion = Al.LockBitmap(bitmap, PixelFormat.AnyNoAlpha, LockFlag.ReadOnly);
    Al.UnlockBitmap(bitmap);

    Console.WriteLine($"Is display event source registered: {Al.IsEventSourceRegistered(eventQueue, displayEventSource)}");
    Console.WriteLine($"Clipboard has text: {Al.ClipboardHasText(display)}");
    Console.WriteLine($"Clipboard text: {Al.GetClipboardText(display)}");
    Console.WriteLine($"Is drawing held: {Al.IsBitmapDrawingHeld()}");
    Console.WriteLine($"Register bitmap loader: {Al.RegisterBitmapLoader(".x", MyBitmapLoader)}");
    Console.WriteLine($"Identify non-existant bitmap: {Al.IdentifyBitmap("xxx.png")}");

    var thread = Al.CreateThread(MyThreadProcess, IntPtr.Zero) ?? throw new Exception("nul thread");
    var mutex = Al.CreateMutex() ?? throw new Exception("nul mut");
    var cond = Al.CreateCond() ?? throw new Exception("nul cond");
    Al.StartThread(thread);

    var transform = Al.GetCurrentTransform();

    var aEvent = new AllegroEvent();
    var aUserEvent = new AllegroEvent();
    var myUserEventType = Al.GetEventType('M', 'I', 'N', 'E');
    var isRunning = true;
    while (isRunning)
    {
      Al.WaitForEvent(eventQueue, aEvent);

      if (aEvent.Type == EventType.DisplayClose)
      {
        isRunning = false;
      }

      if (aEvent.Type == EventType.MenuClick)
      {
        var a = new IntPtr(FileExitID);
        var b = a.ToInt64();
        if (aEvent.UserData1 == new IntPtr(FileExitID))
        {
          isRunning = false;
        }
      }

      if (aEvent.Type == EventType.DisplayResize)
      {
      }

      if (aEvent.Type == EventType.KeyDown)
      {
        if (aEvent.KeyCode == KeyCode.KeyEscape)
        {
          isRunning = false;
        }
        if (aEvent.KeyCode == KeyCode.KeyQ)
        {
          aUserEvent.Type = myUserEventType;
          Al.EmitUserEvent(userEventSource, aUserEvent, null);
        }
        Console.WriteLine($"KeyCode: {aEvent.KeyCode}");
      }

      if (aEvent.Type == myUserEventType)
      {
        var a = 5;
      }

      if (aEvent.Type == EventType.Timer && Al.IsEventQueueEmpty(eventQueue))
      {
        Al.SetTargetBitmap(bitmap);
        Al.ClearToColor(redColor);
        Al.DrawText(builtinFont, Al.MapRgb(255, 255, 255), 32, 32, FontAlignFlags.Left, "THE builtin FONT!");
        Al.SetTargetBackbuffer(display);
        Al.DrawBitmap(bitmap, 8, 8, FlipFlags.None);
        Al.FlipDisplay();
      }
    }

    Al.SetThreadShouldStop(thread);
    Al.JoinThread(thread, out var returnIntPtr);
    Al.DestroyCond(cond);
    Al.DestroyMutex(mutex);
    Al.DestroyThread(thread);

    Al.UnregisterEventSource(eventQueue, userEventSource);
    Al.UnregisterEventSource(eventQueue, Al.GetKeyboardEventSource() ?? throw new Exception("wha?"));
    Al.UnregisterEventSource(eventQueue, timerEventSource);
    Al.UnregisterEventSource(eventQueue, displayEventSource);
    Al.DestroyEventQueue(eventQueue);

    Al.DestroyUserEventSource(userEventSource);
    Al.StopTimer(timer);
    Al.DestroyTimer(timer);
    Al.DestroyMouseCursor(mouseCursor);
    Al.DestroyBitmap(mouseCursorBitmap);
    Al.DestroyDisplay(display);

    if (sample != null && sampleInstance != null)
    {
      Al.SetSample(sampleInstance, null);
      Al.DestroySampleInstance(sampleInstance);
      sampleInstance = null;

      Al.DestroySample(sample);
      sample = null;
    }
    if (voice is not null)
      Al.DestroyVoice(voice);
    if (mixer is not null)
      Al.DestroyMixer(mixer);

    Al.ShutdownTtfAddon();
    Al.ShutdownFontAddon();
    Al.UninstallAudio();
    Al.ShutdownImageAddon();
    Al.ShutdownNativeDialogAddon();
    Al.UninstallMouse();
    Al.UninstallJoystick();
    Al.UninstallKeyboard();
    Al.UninstallSystem();

    Console.WriteLine($"Size of int: {Marshal.SizeOf<int>()}");
    Console.WriteLine($"Size IntPtr: {Marshal.SizeOf<IntPtr>()}");
    Console.WriteLine($"Size of locked region: {Marshal.SizeOf<AllegroLockedRegion>()}");
    Console.WriteLine($"Size of color: {Marshal.SizeOf<AllegroColor>()}");

    Console.WriteLine("Done.");
  }
}