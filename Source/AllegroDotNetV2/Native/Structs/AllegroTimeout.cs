using System.Runtime.InteropServices;

namespace SubC.AllegroDotNet.Native.Structs;

/// <summary>
/// An opaque structure representing a timeout.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct AllegroTimeout
{
  private readonly long __pad1__;
  private readonly long __pad2__;
}