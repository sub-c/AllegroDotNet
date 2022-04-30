﻿using SubC.AllegroDotNet;
using SubC.AllegroDotNet.Enums;
using SubC.AllegroDotNet.Models;
using System;
using System.Runtime.InteropServices;

internal static class Program
{
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

    Console.WriteLine($"InstallAudio: {Al.InstallAudio()}");
    Console.WriteLine($"ReserveSamples: {Al.ReserveSamples(16)}");
    Console.WriteLine($"InitACodec: {Al.InitAcodecAddon()}");
    var sample = Al.LoadSample("D:/intro_music.ogg");
    if (sample != null)
    {
      Al.PlaySample(sample, 1, 0, 1, Playmode.Once, null);
    }

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

    var state = new AllegroState();
    Al.StoreState(state, StateFlags.All);
    Al.RestoreState(state);

    var timeout = new AllegroTimeout();
    Al.InitTimeout(timeout, 2);

    var display = Al.CreateDisplay(1280, 720) ?? throw new Exception("disp null");
    var displayEventSource = Al.GetDisplayEventSource(display) ?? throw new Exception("disp source null");

    //var fileDialog = Al.CreateNativeFileDialog("D:/", "My title", "*.*", FileChooser.FileMustExist) ?? throw new NullReferenceException(); ;
    //Al.ShowNativeFileDialog(display, fileDialog);

    var mouseCursorBitmap = Al.CreateBitmap(64, 64) ?? throw new Exception();
    Al.SetTargetBitmap(mouseCursorBitmap);
    Al.ClearToColor(Al.MapRgb(50, 50, 200));
    var mouseCursor = Al.CreateMouseCursor(mouseCursorBitmap, 0, 0) ?? throw new Exception();
    Al.SetMouseCursor(display, mouseCursor);

    var timer = Al.CreateTimer(Al.BpsToSecs(60)) ?? throw new Exception("timer null");
    var timerEventSource = Al.GetTimerEventSource(timer) ?? throw new Exception("timer source null");

    var eventQueue = Al.CreateEventQueue() ?? throw new Exception("eq null");
    Al.RegisterEventSource(eventQueue, displayEventSource);
    Al.RegisterEventSource(eventQueue, timerEventSource);
    Al.RegisterEventSource(eventQueue, Al.GetKeyboardEventSource() ?? throw new Exception("key source null"));
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
      }

      if (aEvent.Type == myUserEventType)
      {
        var a = 5;
      }

      if (aEvent.Type == EventType.Timer && Al.IsEventQueueEmpty(eventQueue))
      {
        Al.SetTargetBitmap(bitmap);
        Al.ClearToColor(redColor);
        Al.SetTargetBackbuffer(display);
        Al.DrawBitmap(bitmap, 8, 8, FlipFlags.None);
        Al.FlipDisplay();
      }
    }

    Al.SetThreadShouldStop(thread);
    IntPtr returnIntPtr = new();
    Al.JoinThread(thread, ref returnIntPtr);
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

    if (sample != null)
    {
      Al.DestroySample(sample);
      sample = null;
    }

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