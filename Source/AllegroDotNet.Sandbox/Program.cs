using SubC.AllegroDotNet;
using SubC.AllegroDotNet.Enums;
using SubC.AllegroDotNet.Extensions;
using SubC.AllegroDotNet.Models;
using System.Runtime.InteropServices;

Console.WriteLine("Starting...");

Console.WriteLine($"Is system installed? {Al.IsSystemInstalled()}");
Console.WriteLine($"Install system: {Al.Init()}");
Console.WriteLine($"Is system installed? {Al.IsSystemInstalled()}");
Console.WriteLine($"Current Allegro library version: {Al.GetAllegroVersion()}");
Console.WriteLine($"Install keyboard: {Al.InstallKeyboard()}");
Console.WriteLine($"Install joystick: {Al.InstallJoystick()}");
Console.WriteLine($"Number of joysticks: {Al.GetNumJoysticks()}");
Console.WriteLine($"Install mouse: {Al.InstallMouse()}");

Console.WriteLine($"Install video: {Al.InitVideoAddon()}");
Console.WriteLine($"Video version: {Al.GetAllegroVideoVersion()}");

Console.WriteLine($"Install image: {Al.InitImageAddon()}");
Console.WriteLine($"Is image installed? {Al.IsImageAddonInitialized()}");
Console.WriteLine($"Image version: {Al.GetAllegroImageVersion()}");

Console.WriteLine($"Install font: {Al.InitFontAddon()}");

Console.WriteLine($"Memfile version: {Al.GetAllegroMemfileVersion()}");

Console.WriteLine($"Install ACodec: {Al.InitACodecAddon()}");
Console.WriteLine($"ACodec version: {Al.GetAllegroACodecVersion()}");

Console.WriteLine($"Install audio: {Al.InstallAudio()}");

Console.WriteLine($"Install primitives: {Al.InitPrimitivesAddon()}");

Console.WriteLine($"Install touch: {Al.InstallTouchInput()}");

var voice = Al.CreateVoice(44100, AudioDepth.Int16, ChannelConfig.Channels2);
var mixer = Al.CreateMixer(44100, AudioDepth.Int16, ChannelConfig.Channels2);
var attachResult = Al.AttachMixerToVoice(mixer, voice);
Console.WriteLine($"Was mixer/voice attached? {attachResult}");

var sample = Al.LoadSample(@"D:\game_over.ogg");
Console.WriteLine($"Loaded sample? {sample != null}");
if (sample is not null)
{
  var sampleInstance = Al.CreateSampleInstance(sample);
  var a1 = Al.AttachSampleInstanceToMixer(sampleInstance, mixer);
  var b1 = Al.SetSampleInstancePlaymode(sampleInstance, PlayMode.Once);
  var c1 = Al.PlaySampleInstance(sampleInstance);
}

var displayAdapter = 0; // Al.GetNewDisplayAdapter();
Console.WriteLine($"New display adapter: {displayAdapter}");
var getAdapterInfo = Al.GetMonitorInfo(displayAdapter, out var displayAdapterInfo);
Console.WriteLine($"Get adapter info - monitor size: {getAdapterInfo} - {displayAdapterInfo.X1}, {displayAdapterInfo.Y1} x {displayAdapterInfo.X2}, {displayAdapterInfo.Y2}");

Console.WriteLine($"Num of display modes: {Al.GetNumDisplayModes()}");
var dispMode = new AllegroDisplayMode();
dispMode = Al.GetDisplayMode(3, ref dispMode) ?? new AllegroDisplayMode();
Console.WriteLine($"Display mode 3: {dispMode.Width}x{dispMode.Height}x{dispMode.RefreshRate}");

Al.SetNewDisplayFlags(DisplayFlags.ProgrammablePipeline | DisplayFlags.Windowed | DisplayFlags.OpenGL);
var display = Al.CreateDisplay(1280, 720);
var shaderSource = Al.GetDefaultShaderSource(ShaderPlatform.Auto, ShaderType.PixelShader);
var testColor = Al.MapRgb(64, 128, 255);


if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
{
  var winHandle = Al.GetWinWindowHandle(display);
  Console.WriteLine($"Window handle: {winHandle}");

  try
  {
    _ = Al.GetD3dDevice(display);
  }
  catch (Exception exception)
  {
    Console.WriteLine($"Could not get D3D device, no Direct3D support? {exception.Message}");
  }
}


var myFix = Al.IToFix(512);
var myInt = Al.FixToI(myFix);
Console.WriteLine($"Fixed is: {myFix.Fixed}, integer is {myInt}");


Console.WriteLine($"OpenGL version: {Al.GetOpenGLVersion()}");
Console.WriteLine($"OpenGL varient: {Al.GetOpenGLVariant()}");


Console.WriteLine($"Init native dialog: {Al.InitNativeDialogAddon()}");
var textLog = Al.OpenNativeTextLog("test title", TextLogFlags.Monospace | TextLogFlags.NoClose);
Al.AppendNativeTextLog(textLog, "A test message appended to the text log.");


var transform1 = new AllegroTransform();
transform1.M[0,1] = 5;
var transform2 = new AllegroTransform();
transform2.M[0,2] = 10;
Al.CopyTransform(ref transform1, in transform2);
//Al.UseTransform(in transform1);
var usedTransform = Al.GetCurrentTransform();


var myUtf = Al.UstrNew("hello");
var myUtfCopy = Al.CstrDup(myUtf);
Console.WriteLine($"Utf copy: {myUtfCopy}");
Al.UstrFree(myUtf);

Al.SetMemoryInterface(null);


var myState = new AllegroState();
Al.StoreState(myState, StateFlags.Bitmap);
Al.RestoreState(myState);


var myPath = Al.CreatePath(@"C:\MyFolder\MySubFolder\MyFile.txt");
var myCstrPath = Al.PathCstr(myPath, '|');
Console.WriteLine($"Path using | as delim: {myCstrPath}");

myCstrPath = Al.PathCstr(myPath, Path.DirectorySeparatorChar);
Console.WriteLine($"Path using DirSepChar: {myCstrPath}");
Al.DestroyPath(myPath);


Console.WriteLine($"CPUs: {Al.GetCpuCount()}");
Console.WriteLine($"RAM: {Al.GetRamSize()}");


Console.WriteLine($"Color version: {Al.GetAllegroColorVersion()}");


var config = Al.CreateConfig();
Al.SetConfigValue(config, "Cow", "Horns", "2");
Al.AddConfigComment(config, "Dog", "Never add a dog.");
var isConfigSaved = Al.SaveConfigFile(@"C:\Users\Public\Documents\allegro-test.cfg", config);
Al.DestroyConfig(config);
Console.WriteLine($"Was config saved: {isConfigSaved}");

config = Al.LoadConfig(@"C:\Users\Public\Documents\allegro-test.cfg");
if (config is not null)
{
  var configSection = Al.GetFirstConfigSection(config, out var section);
  var configEntry = Al.GetFirstConfigEntry(config, configSection, out var entry);
  var configValue = Al.GetConfigValue(config, configSection, configEntry);
  Console.WriteLine($"First config section, entry, value: {configSection}, {configEntry}, {configValue}");
}


var defaultFont = Al.CreateBuiltinFont() ?? throw new NullReferenceException("Could not create built-in font.");

var displayEventSource = Al.GetDisplayEventSource(display);
var eventQueue = Al.CreateEventQueue();
Al.RegisterEventSource(eventQueue, displayEventSource);

var timer = Al.CreateTimer(Al.BpsToSecs(60));
var timerEventSource = Al.GetTimerEventSource(timer);
Al.RegisterEventSource(eventQueue, timerEventSource);
Al.StartTimer(timer);

var color = Al.MapRgb(64, 128, 255);
Console.WriteLine($"RGB color components: {color.R}, {color.G}, {color.B}");
byte r = 0, g = 0, b = 0, a = 0;
Al.UnmapRgba(color, ref r, ref g, ref b, ref a);
Console.WriteLine($"Unmapped RGBA: {r}, {g}, {b}, {a}");

var newBitmapFlags = Al.GetNewBitmapFlags();
Console.WriteLine($"New bitmap flags: {newBitmapFlags}");
var newBitmapFormat = Al.GetNewBitmapFormat();
Console.WriteLine($"New bitmap format: {newBitmapFormat}");
Al.SetNewBitmapFlags(BitmapFlags.ConvertBitmap);
var bitmap = Al.CreateBitmap(256, 128);
Console.WriteLine($"Can create bitmap? {bitmap is not null}");
Console.WriteLine($"Bitmap widthXheight: {Al.GetBitmapWidth(bitmap)}x{Al.GetBitmapHeight(bitmap)}");
Al.DestroyBitmap(bitmap);


Al.InitUserEventSource(out var myUserEventSource);
Al.RegisterEventSource(eventQueue, myUserEventSource);
var myUserEvent = new AllegroEvent();
Al.EmitUserEvent(myUserEventSource, myUserEvent, null);
Al.UnregisterEventSource(eventQueue, myUserEventSource);
Al.DestroyUserEventSource(myUserEventSource);


Al.GetBlender(out var myOp, out var mySrc, out var myDest);
Console.WriteLine($"Blender op: {myOp}, src {mySrc}, dest: {myDest}");
var blendColor = Al.GetBlendColor();
Console.WriteLine($"Blender color: {blendColor.R},{blendColor.G},{blendColor.B}:{blendColor.A}");


var myEvent = new AllegroEvent();
var keyState = new AllegroKeyboardState();
var mouseState = new AllegroMouseState();
var touchState = new AllegroTouchInputState();
while (true)
{
  eventQueue.WaitForEvent(ref myEvent); //Al.WaitForEvent(eventQueue, ref myEvent);
  Al.GetKeyboardState(ref keyState);
  Al.GetMouseState(ref mouseState);
  Al.GetTouchInputState(ref touchState);

  if (myEvent.Type == EventType.DisplayClose || Al.KeyDown(ref keyState, KeyCode.KeyEscape))
    break;
  
  if (myEvent.Type == EventType.Timer)
  {
    Al.ClearToColor(color);
    Al.DrawRoundedRectangle(32, 32, 512, 128, 10, 10, Al.MapRgb(255, 255, 255), 5);
    Al.DrawText(defaultFont, Al.MapRgb(255, 255, 255), 8, 8, FontAlignFlags.Left, $"the default font! - MouseXY: {mouseState.X},{mouseState.Y}");
    Al.FlipDisplay();
  }
}

Al.CloseNativeTextLog(textLog);
Al.DestroyDisplay(display);

Al.DestroyTimer(timer);

Al.UnregisterEventSource(eventQueue, displayEventSource);
Al.DestroyEventQueue(eventQueue);

Al.DestroyFont(defaultFont);

Al.ShutdownVideoAddon();
Al.UninstallTouchInput();
Al.ShutdownNativeDialogAddon();
Al.ShutdownPrimitivesAddon();
Al.UninstallAudio();
Al.ShutdownFontAddon();
Al.ShutdownImageAddon();
Al.UninstallMouse();
Al.UninstallJoystick();
Al.UninstallKeyboard();
Al.UninstallSystem();

Console.WriteLine("Done.");
