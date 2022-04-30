using System;

namespace SubC.AllegroDotNet.Enums
{
  [Flags]
  public enum DisplayFlags : int
  {
    Windowed = 1 << 0,
    Fullscreen = 1 << 1,
    OpenGL = 1 << 2,
    Direct3DInternal = 1 << 3,
    Resizable = 1 << 4,
    Frameless = 1 << 5,
    NoFrame = Frameless,
    GenerateExposeEvents = 1 << 6,
    OpenGL30 = 1 << 7,
    OpenGLForwardCompatible = 1 << 8,
    FullscreenWindow = 1 << 9,
    Minimized = 1 << 10,
    ProgrammablePipeline = 1 << 11,
    GTKTopLevelDomain = 1 << 12,
    Maximized = 1 << 13,
    OpenGLESProfile = 1 << 14,
  }
}