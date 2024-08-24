using System.Diagnostics;
using System.Runtime.InteropServices;

namespace SubC.AllegroDotNet.Models;

/// <summary>
/// This structure represents a color in Allegro.
/// </summary>
[DebuggerDisplay("R = {R}, G = {G}, B = {B}, A = {A}")]
[StructLayout(LayoutKind.Sequential)]
public struct AllegroColor
{
    /// <summary>
    /// Gets or sets the alpha component.
    /// </summary>
    public float A
    {
        readonly get => a;
        set => a = value;
    }

    /// <summary>
    /// Gets or sets the blue component.
    /// </summary>
    public float B
    {
        readonly get => b;
        set => b = value;
    }

    /// <summary>
    /// Gets or sets the green component.
    /// </summary>
    public float G
    {
        readonly get => g;
        set => g = value;
    }

    /// <summary>
    /// Gets or sets the red component.
    /// </summary>
    public float R
    {
        readonly get => r;
        set => r = value;
    }

    internal float r;
    internal float g;
    internal float b;
    internal float a;
}
