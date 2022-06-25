# AllegroDotNet
The AllegroDotNet project aims to make the [Allegro 5 game programming library](https://liballeg.org/) to be useable from C# and feel .NET-like.
Native C functions, pointers, and structs are wrapped by C# methods and classes and avoid exposing pointers whenever possible.

Using AllegroDotNet will allow you to create game and multimedia applications in C#.

## Requirements
* .NET Standard 2.0 -or- .NET 6 project
* Target x64 architecture
* Native Allegro 5 (v5.2.8) library available (see Quick Start for the NuGet package if you don't have one)

## Quick Start (Windows)
1) Add a NuGet package reference to `SubC.AllegroDotNet`.
2) Add a NuGet package reference to `SubC.AllegroDotNet.Win64` (or add your own Allegro v5.2.8 monolith .DLL (`allegro_monolith-5.2.dll`) to your project output).
3) Add the following test code to your source code:
```C#
using SubC.AllegroDotNet;
// ...
Al.InstallSystem(Al.ALLEGRO_VERSION_INT, null);
var display = Al.CreateDisplay(1280, 720) ?? throw new Exception();
Al.Rest(3);
Al.DestroyDisplay(display);
Al.UninstallSystem();
```
4) Compile and run.

## Using AllegroDotNet
AllegroDotNet tries to be as familiar for users of Allegro 5 as possible. The Allegro 5 documentation applies to AllegroDotNet, because AllegroDotNet is only wrapping Allegro 5 functionality. There are just a few differences:
* AllegroDotNet uses .NET-style naming conventions, making all functions use pascal casing and removing underscores.
* AllegroDotNet removes the `al_` prefix from all functions.
* AllegroDotNet places all Allegro functions in the static class named `Al`.
* For example, `al_init_image_addon()` in Allegro 5 becomes `Al.InitImageAddon()` in AllegroDotNet.

Where Allegro 5 used pointers (ie, `ALLEGRO_BITMAP*`), AllegroDotNet uses classes (ie, `AllegroBitmap`). These classes are in the `SubC.AllegroDotNet.Models` namespace.

Where Allegro 5 used defined constants (ie, `ALLEGRO_NO_PRESERVE_TEXTURE`), AllegroDotNet uses enumerations (ie, `BitmapFlags.NoPreserveTexture`). Enumerations are in the `SubC.AllegroDotNet.Enums` namespace.

Where Allegro 5 used macros (ie, `ALLEGRO_BPS_TO_SECS(x)`), AllegroDotNet uses methods (ie, `Al.BpmToSecs(x)`).

Some final notes about using AllegroDotNet:

* Currently AllegroDotNet uses Allegro v5.2.8.

* If the Allegro function takes or returns a string, that involves extra marshalling from managed/unmanaged code. While this isn't "slow", it isn't as fast as passing pointers and numbers around.

* Not all of Allegro 5 API is implemented yet; ex: some UTF-8 support is not currently implemented.

* No testing has been done on OSX, and minimal testing was done on Linux. Additional testing from the community would be helpful!

## Troubleshooting
* If you get "unbalanced stack" errors, ensure your application is targeting *x64* architecture. *AnyCPU* will not work.

* If calling `Al.Init()` is failing, ensure you have the correct version of the Allegro 5 library. Currently, AllegroDotNet requires v5.2.8. See NuGet packages SubC.AllegroDotNet.Win64 or SubC.AllegroDotNet.Linux64 for known working native Allegro libraries to use.

* AllegroDotNet requires a monolith version of Allegro (ie, `allegro_monolith-5.2.dll`) to be available.

* You will get "missing function" errors if the native Allegro 5 library is missing functions for addons it expects to be available (ex: you compiled your own .DLL and did not include native dialog functions, acodec functions, etc).

* You may get additional errors if your .DLL did not have dependencies statically linked. You can solve this by using a static-linked Allegro 5 .DLL (such as from `SubC.AllegroDotNet.Win64`), or place the needed .DLLs with your program output (flac.dll, zlib.dll, etc).

## Closing
Thanks to the Allegro team; it's an awesome library that I've been using since the DOS / DJGPP days!
