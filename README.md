# AllegroDotNet
The AllegroDotNet project aims to make the [Allegro 5 game programming library](https://liballeg.org/) to be useable from C# and feel .NET-like.
Native C functions, pointers, and structs are wrapped by C# methods and classes and avoid exposing pointers whenever possible.

Using AllegroDotNet will allow you to create game and multimedia applications in C#.


## Requirements
* Target x64 architecture (AnyCPU or x86 will not work)
* Native Allegro 5 (v5.2.8) library available (see Quick Start)

## Quick Start (Windows)
1) Add NuGet package references to [SubC.AllegroDotNet](https://www.nuget.org/packages/SubC.AllegroDotNet) and [SubC.AllegroDotNet.Win64](https://www.nuget.org/packages/SubC.AllegroDotNet.Win64).
2) Add the following test code to your source code:
```C#
using SubC.AllegroDotNet;
// ...
Al.InstallSystem(Al.ALLEGRO_VERSION_INT, null);
var display = Al.CreateDisplay(1280, 720) ?? throw new Exception();
Al.Rest(3);
Al.DestroyDisplay(display);
Al.UninstallSystem();
```
3) Compile and run.

For more example code, see the AllegroDotNet.Sandbox project in this repository.

## Differences between Allegro 5 and AllegroDotNet
AllegroDotNet tries to mimic Allegro 5 as closely as possible while also translating the original C library to modern .NET. You can use documentation and tutorials for Allegro 5 with AllegroDotNet, as long as you note the differences between the two:

* AllegroDotNet uses .NET-style naming conventions, so Allegro 5's snake casing is turned into pascal casing.
  
* Allegro 5 prefixed all functions with `al_`. AllegroDotNet instead puts all functions into the static class `Al`. For example, `al_init()` becomes `Al.Init()`.

* Allegro 5 functions are all placed in the static `SubC.AllegroDotNet.Al` class.

* Allegro 5 pointers (ex: `ALLEGRO_BITMAP*`) are turned into classes (ex: `AllegroBitmap`). These classes are all in the `SubC.AllegroDotNet.Models` namespace.

* Allegro 5 constants (ex: `ALLEGRO_NO_PRESERVE_TEXTURE`) are grouped and turned into enumerations (ex: `BitmapFlags.NoPreserveTexture`). These enumerations are all in the `SubC.AllegroDotNet.Enums` namespace.

* Allegro 5 macros (ex: `ALLEGRO_BPS_TO_SECS(x)`) are turned into static methods (ex: `Al.BpmToSecs(x)`). These static methods are part of the `SubC.AllegroDotNet.Al` static class.

## Notes about using AllegroDotNet:

* Currently AllegroDotNet uses Allegro version 5.2.8.

* If the Allegro function takes or returns a string, that involves extra marshalling from managed/unmanaged code. While this isn't "slow", it isn't as fast as passing pointers and numbers around.

* Not every Allegro 5 function is available (ex: no shader, color addon, or video streaming addon routines). More functions will be added in the future.

* No testing has been done on OSX, and minimal testing was done on Linux. Would you want to test it on those platforms?

## Troubleshooting
* If you get "unbalanced stack" errors, ensure your application is targeting *x64* architecture. *AnyCPU* will not work.

* If calling `Al.Init()` is failing, ensure you have the correct version of the Allegro 5 library. Currently, AllegroDotNet requires v5.2.8. See NuGet packages SubC.AllegroDotNet.Win64 or SubC.AllegroDotNet.Linux64 for known working native Allegro libraries to use.

* AllegroDotNet requires a monolith version of Allegro to be available (ex: `allegro_monolith-5.2.dll`).

* If you'd rather use the offical Allegro 5 binaries instead of `SubC.AllegroDotNet.Win64`, that is also an option. However, you will need to do the work to make sure the monolith .DLL file is available to your executable (the NuGet package automatically adds the .DLL to your project's output).

* You will get "missing function" errors if the native Allegro 5 library you are using is missing functions for addons it expects to be available (ex: you compiled your own .DLL and did not include native dialog functions, acodec functions, etc).

* You may get additional errors if your .DLL did not have dependencies statically linked. You can solve this by using a static-linked Allegro 5 .DLL (such as from `SubC.AllegroDotNet.Win64`), or place the needed .DLLs with your program output (flac.dll, zlib.dll, etc).


# AllegroDotNet.Extensions
This extension project adds object-oriented extension methods to (some of) the AllegroDotNet classes. Example:
```C#
Al.RegisterEventSource(myEventSource, Al.GetDisplayEventSource(myDisplay))
```
becomes
```C#
myEventSource.RegisterEventSource(myDisplay.GetDisplayEventSource());
```


## Closing
Thanks to the Allegro team, it's an awesome library that I've been using since the DOS / DJGPP days.
