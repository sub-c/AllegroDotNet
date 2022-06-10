# AllegroDotNet
The AllegroDotNet project aims to make the [Allegro 5 game programming library](https://liballeg.org/) to be useable from C# and feel .NET-like.
Native C functions, pointers, and structs are wrapped by C# methods and classes and avoid exposing pointers whenever possible.

Using AllegroDotNet will allow you to create game and multimedia applications in C#.

## Requirements
* Target x64 (*NOT AnyCPU*)
* .NET Standard 2.0 -OR- .NET 6 project
* Native Allegro 5 (v5.2.8) library available

## Quick Start (Windows)
1) Add a NuGet package reference to `SubC.AllegroDotNet`.
2) Add a NuGet package reference to `SubC.AllegroDotNet.Win64` (or add your own Allegro 5 monolith .DLL (`allegro_monolith-5.2.dll`) to your project output).
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
The Allegro 5 library prefixes all library calls with __al__. AllegroDotNet puts all Allegro methods in the __Al__ namespace. Additionally, AllegroDotNet removes all underscores from Allegro 5 library functions and formats the method with pascal-style casing. This means that once you pick up on these naming differences, the original Allegro 5 documentation applies to AllegroDotNet. For example:
* Allegro 5's function to initialize the image addon is `al_init_image_addon()`.
* AllegroDotNet's method to initialize the image addon is `Al.InitImageAddon()`.

Where Allegro 5 used pointers for bitmaps, samples, etc, AllegroDotNet instead uses C# classes.
* Allegro 5 represented bitmaps with `ALLEGRO_BITMAP *`.
* AllegroDotNet represents a bitmap as `AllegroBitmap`. These models are in the `SubC.AllegroDotNet.Models` namespace.

Where Allegro 5 used enumerations / defined constants for flags, AllegroDotNet always uses C# enums.
* Allegro 5 `al_set_new_bitmap_flags(int flags)` takes flags that you must remember/look up, like ALLEGRO_NO_PRESERVE_TEXTURE.
* AllegroDotNet `Al.SetNewBitmapFlags(BitmapFlags flags)` takes an enumeration type, which allows your IDE to show you the values of that enumeration to suggest values to pass. These enumerations are in the `SubC.AllegroDotNet.Enums` namespace.

Some final notes about using AllegroDotNet:

* Currently AllegroDotNet uses Allegro v5.2.8.

* If the Allegro function takes or returns a string, that involves extra marshalling from managed/unmanaged code. While this isn't "slow", it isn't as fast as passing pointers and numbers around.

* Not all of Allegro 5 API is implemented yet; ex: unicode/UTF-8 support is not currently implemented.

* No testing has been done on OSX, and minimal testing was done on Linux. Additional testing from the community would be helpful!

## Troubleshooting
* If you get "unbalanced stack" errors, ensure your application is targeting *x64* architecture. *AnyCPU* will not work.

* Note you need the correct version of the Allegro 5 library or the call to `Al.Init()` will fail. Currently, AllegroDotNet supports v5.2.8; verify you have the correct version of Allegro if you encounter problems calling `Al.Init()`.

* AllegroDotNet requires a monolith version of Allegro (ie, `allegro_monolith-5.2.dll`) to be available to use the native Allegro 5 library.

* You will get "missing function" errors if the `allegro_monolith-5.2.dll` library (on Windows) is missing functions for addons it expects to be available (ex: your .DLL did not include native dialog functions, acodec functions, etc).

* You may get additional errors if your .DLL did not have dependencies statically linked. You can solve this by using a static-linked Allegro 5 .DLL (such as from `SubC.AllegroDotNet.Win64`), or place the needed .DLLs with your program output (flac.dll, zlib.dll, etc).

## Closing
Thanks to the Allegro team; it's an awesome library that I've been using since the DOS / DJGPP days!
