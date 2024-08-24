using System.Runtime.InteropServices;

namespace SubC.AllegroDotNet.Models;

/// <summary>
/// An opaque structure representing a sample being played.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct AllegroSampleID
{
    private int _index;
    private int _id;
}
