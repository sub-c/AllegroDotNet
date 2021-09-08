# AllegroDotNet
The AllegroDotNet projects aims to make the original [Allegro 5 game programming library](https://liballeg.org/) (written in C) to be useable from C# and feel .NET-like.
Native C functions, pointers, and structs are wrapped with C# methods and classes.

Using AllegroDotNet will allow you to create game and multimedia applications in C#.

# Requirements
* Visual Studio 2019+
* .NET Core 3.1+
* Your application targets Windows

Targetting additional OSes is possible, but will require the Allegro 5 library & dependencies available to AllegroDotNet at runtime, as well as adding the OS-specific library loading interop in the `NativeLibrary.cs` class.

# Quick Start (Windows)
1) Make a new .NET Core 3.1 console project in Visual Studio 2019.
2) Add the [AllegroDotNet](https://www.nuget.org/packages/AllegroDotNet/) and [AllegroDotNet.Dependencies](https://www.nuget.org/packages/AllegroDotNet.Dependencies/) Nuget packages to your project.
3) Add the following code to your `Program.cs` file `using` statements:
```C#
using AllegroDotNet;
using AllegroDotNet.Dependencies;
```
4) Add the following code to your `Program.cs` file `Main()` method:
```C#
AlDependencyManager.ExtractAllegroDotNetDlls();
Al.InstallSystem(AlConstants.AllegroVersionInt);
var display = Al.CreateDisplay(1920, 1080);
Al.ClearToColor(Al.MapRgb(0, 32, 32));
Al.FlipDisplay();
Al.Rest(2);
Al.DestroyDisplay(display);
Al.UninstallSystem();
```

# Using AllegroDotNet
The original Allegro 5 library prefixes all library calls with __al__; AllegroDotNet prefixes all library calls in the __Al__ namespace. Otherwise, the library function names are the same, except for casing which follows .NET coding conventions (ie, pascal-casing). For example, the original Allegro 5 library function `al_init_image_addon()` becomes `Al.InitImageAddon()` in AllegroDotNet.

The [offical Allegro documentation](https://liballeg.org/a5docs/trunk/) is compatible with AllegroDotNet: whatever the function did in Allegro 5, that same function is invoked by AllegroDotNet using native platform invokes.

Parameters are changed to not use pointers, and instead use C# classes. For example, the original Allegro 5 library function `al_set_target_bitmap(ALLEGRO_BITMAP *bitmap)` becomes `Al.SetTargetBitmap(AllegroBitmap bitmap)` in AllegroDotNet.

# Dependencies
1) However you built the Allegro 5 library, you'll need any dependencies needed to load it; for Windows Visual Studio 2019 builds, that means you'll need the [Visual C++ Redistributable](https://visualstudio.microsoft.com/downloads/#microsoft-visual-c-redistributable-for-visual-studio-2019) to be installed.
2) You will also need any dependencies needed by Allegro 5, such as the libpng library to load .PNG files, etc.
3) Finally, You will need the Allegro 5 monolith library itself.

You can either provide these yourself, or use the [AllegroDotNet.Dependencies](https://www.nuget.org/packages/AllegroDotNet.Dependencies/) Nuget package to provide them for you (call `AlDependencyManager.ExtractAllegroDotNetDlls();` to automatically extract the libraries needed) (Windows-only for now).

# Notes
- Not __EVERY__ Allegro function is implemented, but most of them are including events, graphics, sound, displays, input, timers, fonts, and configuration (among others). It's enough to make a game!
- Some areas of functionality are not implemented at all (ex: fixed-point math, haptic).
- This project is not fully released yet. There may be bugs in how the interopability is handled; not every method has been verified to work!

# Closing
Thanks to the Allegro team; it's an awesome library and I've been using it since 1999!

You can contact me at halolockdown at yahoo dot com.
