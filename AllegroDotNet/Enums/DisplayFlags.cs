using System;
using SubC.AllegroDotNet.Models;

namespace SubC.AllegroDotNet.Enums
{
    /// <summary>
    /// Flags to specify specific kinds of displays.
    /// </summary>
    [Flags]
    public enum DisplayFlags : int
    {
        /// <summary>
        /// Prefer a windowed mode.
        /// </summary>
        Windowed = 1 << 0,

        /// <summary>
        /// Prefer a fullscreen mode.
        /// </summary>
        FullScreen = 1 << 1,

        /// <summary>
        /// Require the driver to provide an initialized OpenGL context after returning successfully. 
        /// </summary>
        OpenGL = 1 << 2,

        /// <summary>
        /// Require the driver to do rendering with Direct3D and provide a Direct3D device.
        /// </summary>
        Direct3D = 1 << 3,

        /// <summary>
        /// The display is resizable (only applicable if combined with <see cref="Windowed"/>). 
        /// </summary>
        Resizable = 1 << 4,

        /// <summary>
        /// Try to create a window without a frame (i.e. no border or titlebar). This usually does nothing for fullscreen modes, and even in
        /// windowed modes it depends on the underlying platform whether it is supported or not. 
        /// </summary>
        Frameless = 1 << 5,

        /// <summary>
        /// Original name for <see cref="Frameless"/>. This works with older versions of Allegro.
        /// </summary>
        NoFrame = Frameless,

        /// <summary>
        /// Let the display generate expose events.
        /// </summary>
        GenerateExposeEvents = 1 << 6,

        /// <summary>
        /// Require the driver to provide an initialized OpenGL context compatible with OpenGL version 3.0.
        /// </summary>
        OpenGL30 = 1 << 7,

        /// <summary>
        /// If this flag is set, the OpenGL context created with <see cref="OpenGL30"/> will be forward compatible only, meaning that all of the
        /// OpenGL API declared deprecated in OpenGL 3.0 will not be supported. Currently, a display created with this flag will not be compatible
        /// with Allegro drawing routines; the display option <see cref="DisplayOption.CompatibleDisplay"/> will be set to false. 
        /// </summary>
        OpenGLForwardCompatible = 1 << 8,

        /// <summary>
        /// Make the window span the entire screen. Unlike <see cref="FullScreen"/> this will never attempt to modify the screen resolution. Instead
        /// the pixel dimensions of the created display will be the same as the desktop.
        /// <para>
        /// The passed width and height are only used if the window is switched out of fullscreen mode later but will be ignored initially.
        /// </para>
        /// <para>
        /// Under Windows and X11 a fullscreen display created with this flag will behave differently from one created with the
        /// <see cref="FullScreen"/> flag - even if the <see cref="FullScreen"/> display is passed the desktop dimensions. The exact difference is
        /// platform dependent, but some things which may be different is how alt-tab works, how fast you can toggle between fullscreen/windowed mode
        /// or how additional monitors behave while your display is in fullscreen mode.
        /// </para>
        /// <para>
        /// Additionally under X, the use of more than one adapter in multi-head mode or with true Xinerama enabled is impossible due to bugs in
        /// X/GLX, creation will fail if more than one adapter is attempted to be used.
        /// </para>
        /// </summary>
        FullScreenWindow = 1 << 9,

        /// <summary>
        /// The display window will be minimized.
        /// </summary>
        Minimized = 1 << 10,

        /// <summary>
        /// Require a programmable graphics pipeline. This flag is required to use <see cref="AllegroShader"/> objects. 
        /// </summary>
        ProgrammablePipeline = 1 << 11,

        /// <summary>
        /// Create a GTK toplevel window for the display, on X. This flag is conditionally defined by the native dialog addon. You must call
        /// <see cref="Al.InitNativeDialogAddon"/> for it to succeed. <see cref="GtkTopLevel"/> is incompatible with <see cref="FullScreen"/>.
        /// </summary>
        GtkTopLevel = 1 << 12,

        /// <summary>
        /// The display window will be maximized (only applicable if combined with <see cref="Resizable"/>).
        /// </summary>
        Maximized = 1 << 13,

        /// <summary>
        /// Used together with <see cref="OpenGL"/>, requests that the OpenGL context uses the OpenGL ES profile. A specific version can be
        /// requested with al_set_new_display_option. Note: Currently this is only supported by the X11/GLX driver.
        /// </summary>
        OpenGLESProfile = 1 << 14
    }
}
