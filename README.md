# AllegroDotNet

## :question: What is it?

The AllegroDotNet project aims to make the [Allegro 5 game programming library](https://liballeg.org/) available in C# and feel .NET-like.
Using AllegroDotNet will allow you to create game and multimedia applications in C#.

## :star: Requirements

* A native Allegro 5.2.x library binary.

## :boom: Quick Start (Windows)

1) Add NuGet package references to [SubC.AllegroDotNet](https://www.nuget.org/packages/SubC.AllegroDotNet) and [SubC.AllegroDotNet.Win64](https://www.nuget.org/packages/SubC.AllegroDotNet.Win64).

2) Add the following test code to your source code:

```C#
using SubC.AllegroDotNet;
// ...
Al.Init();
var display = Al.CreateDisplay(1280, 720) ?? throw new Exception();
Al.Rest(3);
Al.DestroyDisplay(display);
Al.UninstallSystem();
```

3) Compile and run.

For more example code, see the `Source/Ex.<whatever>` projects such as `Source/Ex.Camera/`.

## :fire: Slow Start

AllegroDotNet is a wrapper for the Allegro 5 library. Care was taken to make Allegro feel like .NET, instead of a tool-generated wrapper that requires you to pass `IntPtr` everywhere.

You must provide the native Allegro 5 library, but the NuGet package `SubC.AllegroDotNet.Win64` can provide it for you if you are targeting Windows.

The 'bit-ness' of your .NET application must match the version of Allegro 5: if you're targetting `AnyCPU` in your .NET application, and your OS is 64-bit, then you must provide the x64 library version of Allegro 5 or it won't work.

Existing documentation of Allegro 5 is valid with AllegroDotNet. The static class `Al` contains all the Allegro 5 functions.

Function names have changed, so that what was `al_init()` in C has now become `Al.Init()` in C#.

## :floppy_disk: Native Allegro 5 Library

Remember to match 'bit-ness': if your .NET application is targetting `AnyCPU`, then it will be x86 on 32-bit systems, and x64 on 64-bit systems. The same version of Allegro 5 will not work on both: you must make sure you provide the correct version of the native Allegro 5 library for your target architecture.

The native Allegro library may require a runtime for your target platform, such as the Visual C++ Redistributable `vc_redist.x64.exe` on Windows. Your development machine may already have this installed, but other machines may not.
This is a requirement you can forget about when testing on other machines.

The method `Al.Init()` tries to initialize Allegro with any known versions in the `LibraryVersion` enumeration. If you want/need to specify the version, you need to call `Al.InstallSystem()` instead.

When specifying the version of Allegro 5 with `Al.InstallSystem()`, you can provide either an integer of the version as per usual from C, or use the enumeration `LibraryVersion` to specify some well-known versions such as 5.2.8 (`LibraryVersion.V528`).

## :newspaper: Differences Between Allegro and AllegroDotNet

* All Allegro functions are provided in the `Al` static class (example: `Al.InstallKeyboard()`).

* Most Allegro 5 opaque types (example: `ALLEGRO_BITMAP*`) are turned into classes (example: `AllegroBitmap`). They are located in the `SubC.AllegroDotNet.Models` namespace.

* The remaining Allegro 5 types (example: `ALLEGRO_COLOR`) are turned into structures (example: `AllegroColor`). You will often need to pass them with the `ref` keyword to facilitate marshalling them to the native C library correctly and quickly.

* Allegro 5 constant values (example: `ALLEGRO_NO_PRESERVE_TEXTURE`) are grouped into enumerations (example: `BitmapFlags.NoPreserveTexture`). These enumerations are in the `SubC.AllegroDotNet.Enums` namespace.

* Allegro 5 macros (example: `ALLEGRO_BPS_TO_SECS(x)`) are turned into static methods (example: `Al.BpsToSecs(x)`).

* The method `Al.Init()` only is aware of versions in the `LibraryVersion` enumeration. If you need to initialize a version of Allegro not in this enumeration, you need to call `Al.InstallSystem()` with the correct integer parameter (same as from C code).

* When calling `Al.InitUserEventSource()`, native memory is allocated for the event source. When you are done with the event source, call `Al.DestroyUserEventSource()`. This is different than native Allegro 5 where the `ALLEGRO_EVENT_SOURCE` is allocated by the user, instead of the API methods.

* If the Allegro function takes or returns a string, that involves extra marshalling from managed/unmanaged code. While this isn't "slow", it isn't as fast as passing pointers and numbers around.

## :memo: Custom Interop Providers

AllegroDotNet has built-in interop providers for Windows, OS X, and Linux. These built-in providers expect to find the default, non-debug names of the Allegro 5 library when trying to load functions (ex: `allegro-5.2.dll`).

If you want to support other operating systems or the debug-named Allegro 5 library, you can create your own interop provider. To do so:

* Make a class that implements the `SubC.AllegroDotNet.Native.IInteropProvider` interface (see the existing interop providers for examples).
* Call `Al.SetupInteropProvider()` before you call any Allegro function, passing it your custom interop provider.
* Call AllegroDotNet functions as usual.

## :warning: Troubleshooting

* If you get "access violation" errors when trying to call to Allegro functions, ensure you do not have multiple versions of the Allegro library in your path. For example, on Windows systems, if you have a MinGW Allegro .DLL file in the path, and another VC++ Allegro .DLL next to your .EXE, AllegroDotNet will load both libraries and can invoke the function from the wrong .DLL library.

	* If this is a legitimate concern for you, you may provide your own more strict interop provider. See the above 'Custom Interop Providers' section for how to write your own.

* If you get "unbalanced stack" or "attempted to read or write protected memory" errors, ensure your application is running the correct "bit-ness" that matches the version of Allegro 5 being used. You cannot use x64 Allegro 5 in your 32-bit .NET application or vice-versa.

* If calling `Al.InstallSystem()` is failing, ensure the version of Allegro 5 you are trying to load is available. You cannot load Allegro 5.2.8 if you pass `LibraryVersion.V529` (5.2.9) to `Al.InstallSystem()`. Also ensure the library files (ie, .DLL files on Windows) are available to your executable.

* If you get "missing function" errors, you may be using a native version of Allegro 5 that does not have functions available that are expected by AllegroDotNet. For example, if you did not include audio or acodec support in your Allegro 5 library, but you try to use any of those functions, you will get an error.

* You may get errors if your native library files do not have their dependencies available or are not statically linked. You can solve this by providing the needed libraries (flac.dll, zlib.dll, etc) or by using a statically-linked native Allegro library.

## :x: Unimplemented Routines

* Any function marked as "Unstable API" (ex: haptic functions).
* PhysFS addon, as this would also require wrapping the PhysFS library.
