# AllegroDotNet
The AllegroDotNet projects aims to make the original [Allegro game programming library](https://liballeg.org/) (written in C) to be useable from C# and feel somewhat .NET-like.
It achieves this goal by wrapping the native C function calls with platform-invoke calls in C#. Additional wrapping is done to not expose any native pointer types, so what was an ALLEGRO_BITMAP* struct-pointer in C is now an AllegroBitmap class in C#.

The current supported requirements:
* Visual Studio 2019+
* .NET Core 3.1+
* Your application targets Windows

Changing the IDE or target platform is certainly possible given platform-invoke is part of .NET and not Windows-specific, but is not officially supported *at this time*.

# Quick Start (Windows)
1) Make a new .NET Core 3.1 console project in Visual Studio 2019+
2) Right-click your project in the solution explorer, and pick "Manage Nuget packages..."
3) Click the "Browse" tab, then search for "AllegroDotNet"
4) Install [AllegroDotNet](https://www.nuget.org/packages/AllegroDotNet/) and [AllegroDotNet.Dependencies](https://www.nuget.org/packages/AllegroDotNet.Dependencies/) Nuget packages

Then try adding this code below in your Program.cs file:

- (in your using statements:)

```C#
using AllegroDotNet;
using AllegroDotNet.Dependencies;
```

- (in your Main() method:)

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

If you can't tell, AllegroDotNet mimics original Allegro function calls by putting them all in the __Al__ namespace. For example, the original Allegro function `al_init_image_addon()` is now `Al.InitImageAddon()`. You can use the [offical Allegro documentation](https://liballeg.org/a5docs/trunk/) as documentation for AllegroDotNet: if the method is implemented in AllegroDotNet, then take the native Allegro method, drop the 'al_' and turn it into 'Al.', then turn the rest of the method into pascal-casing without any underscores.

# Dependencies

The AllegroDotNet.Dependencies library has Allegro and required third-party DLLs included inside. Calling `AlDependencyManager.ExtractAllegroDotNetDlls()` will extract those DLLs to the user's temporary folder and point the DLL search path there. The version of Allegro included (5.2.7.0) in this library was compiled with VS2019 and includes features I (Sub-C) wanted. It may not include what you want!

Note the licenses of the included software in this dependency project and how they apply to your game/application. If you would like a different build of Allegro included in this project, you can always clone the repo and replace the included DLL(s).

The included DLLs include support for:
- Most all of the core Allegro functions
- Image addon and PNG support
- Audio and AudioCodec addons, with OGG/Vorbis/Theora/FLAC support
- Font addon and TrueType support
- Native Dialog addon

# Notes

- Not __EVERY__ Allegro function is implemented, but most of them are including events, graphics, sound, displays, input, timers, fonts, and configuration (among others). It's enough to make a game!
- Some areas of functionality are not implemented at all (ex: fixed-point math, haptic).
- This project is not fully released yet. There may be bugs in how the interopability is handled; not every method has been verified to work!

# Closing

Thanks to the Allegro team; it's an awesome library and I've been using it since 1999!

You can contact me at halolockdown at yahoo dot com.
