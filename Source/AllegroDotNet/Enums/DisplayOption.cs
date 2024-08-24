namespace SubC.AllegroDotNet.Enums;

/// <summary>
/// A display option, specifying details of the display context to be created within the window itself.
/// </summary>
public enum DisplayOption : int
{
    /// <summary>
    /// Size of red.
    /// </summary>
    RedSize = 0,

    /// <summary>
    /// Size of green.
    /// </summary>
    GreenSize = 1,

    /// <summary>
    /// Size of blue.
    /// </summary>
    BlueSize = 2,

    /// <summary>
    /// Size of alpha.
    /// </summary>
    AlphaSize = 3,

    /// <summary>
    /// Layout of red.
    /// </summary>
    RedShift = 4,

    /// <summary>
    /// Layout of green.
    /// </summary>
    GreenShift = 5,

    /// <summary>
    /// Layout of blue.
    /// </summary>
    BlueShift = 6,

    /// <summary>
    /// Layout of alpha.
    /// </summary>
    AlphaShift = 7,

    /// <summary>
    /// Size of red accumulator.
    /// </summary>
    AccRedSize = 8,

    /// <summary>
    /// Size of green accumulator.
    /// </summary>
    AccGreenSize = 9,

    /// <summary>
    /// Size of blue accumulator.
    /// </summary>
    AccBlueSize = 10,

    /// <summary>
    /// Size of alpha accumulator.
    /// </summary>
    AccAlphaSize = 11,

    /// <summary>
    /// Stereo display.
    /// </summary>
    Stereo = 12,

    /// <summary>
    /// Number of auxiliary buffers.
    /// </summary>
    AuxBuffers = 13,

    /// <summary>
    /// Specific bit depth.
    /// </summary>
    ColorSize = 14,

    /// <summary>
    /// Size (in bits) of depth buffer.
    /// </summary>
    DepthSize = 15,

    /// <summary>
    /// Size (in bits) of stencil buffer.
    /// </summary>
    StencilSize = 16,

    /// <summary>
    /// Use multisampling (1) or not (0).
    /// </summary>
    SampleBuffers = 17,

    /// <summary>
    /// Number of samples to use per pixel, or 0.
    /// </summary>
    Samples = 18,

    /// <summary>
    /// Use hardware acceleration (1) or not (0).
    /// </summary>
    RenderMethod = 19,

    /// <summary>
    /// Whether to use floating point color components.
    /// </summary>
    FloatColor = 20,

    /// <summary>
    /// Whether to use a floating point depth buffer.
    /// </summary>
    FloatDepth = 21,

    /// <summary>
    /// Use single buffer (1) or another update method (0).
    /// </summary>
    SingleBuffer = 22,

    /// <summary>
    /// Use no display swapping (0), double-buffering (1), or flipping/some other update method (2).
    /// </summary>
    SwapMethod = 23,

    /// <summary>
    /// Indicates if the display is compatible with Allegro 5 drawing functions.
    /// </summary>
    CompatibleDisplay = 24,

    /// <summary>
    /// Set to (1) if the display is capable of updating just a region, or (0) if calling
    /// <see cref="Al.UpdateDisplayRegion"/> is equivalent to <see cref="Al.FlipDisplay"/>.
    /// </summary>
    UpdateDisplayRegion = 25,

    /// <summary>
    /// Set to (0) to not modify configured v-sync settings, (1) to wait for a vertical sync when calling
    /// <see cref="Al.FlipDisplay"/>, or (2) to force v-sync off.
    /// </summary>
    VSync = 26,

    /// <summary>
    /// When queried this returns the maximum size (width as well as height) a bitmap can have for this display.
    /// Calls to <see cref="Al.CreateBitmap"/> or <see cref="Al.LoadBitmap"/> for bitmaps larger than this size
    /// will fail. It does not apply to memory bitmaps which always can have arbitrary size (but are slow for drawing). 
    /// </summary>
    MaxBitmapSize = 27,

    /// <summary>
    /// Set to 1 if textures used for bitmaps on this display can have a size which is not a power of two. This is
    /// mostly useful if you use Allegro to load textures as otherwise only power-of-two textures will be used
    /// internally as bitmap storage. 
    /// </summary>
    SupportNpotBitmap = 28,

    /// <summary>
    /// Set to 1 if you can use <see cref="Al.SetTargetBitmap"/> on bitmaps of this display to draw into them.
    /// If this is not the case software emulation will be used when drawing into display bitmaps (which can be very
    /// slow). 
    /// </summary>
    CanDrawIntoBitmap = 29,

    /// <summary>
    /// This is set to 1 if the <see cref="Al.SetSeparateBlender"/> function is supported. Otherwise the alpha
    /// parameters will be ignored. 
    /// </summary>
    SupportSeparateAlpha = 30,

    /// <summary>
    /// This is on by default. It causes any existing memory bitmaps with the <see cref="BitmapFlags.ConvertBitmap"/>
    /// flag to be converted to a display bitmap of the newly created display with the option set.
    /// </summary>
    AutoConvertBitmaps = 31,

    /// <summary>
    /// The supported display orientations.
    /// </summary>
    SupportedOrientations = 32,

    /// <summary>
    /// The OpenGL major version.
    /// </summary>
    OpenGLMajorVersion = 33,

    /// <summary>
    /// The OpenGL minor version.
    /// </summary>
    OpenGLMinorVersion = 34
}
