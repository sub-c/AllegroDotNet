using System.Runtime.InteropServices;

namespace SubC.AllegroDotNet.Models;

[StructLayout(LayoutKind.Sequential)]
public struct AllegroVertexElement
{
  public int Attribute
  {
    readonly get => attribute;
    set => attribute = value;
  }

  public int Offset
  {
    readonly get => offset;
    set => offset = value;
  }

  public int Storage
  {
    readonly get => storage;
    set => storage = value;
  }

  private int attribute;
  private int storage;
  private int offset;
}
