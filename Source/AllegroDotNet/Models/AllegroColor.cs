using System.Runtime.InteropServices;

namespace SubC.AllegroDotNet.Models
{
  [StructLayout(LayoutKind.Sequential, Pack = 1)]
  public struct AllegroColor
  {
    public float R
    {
      get => r;
      set => r = value;
    }

    public byte RByte
    {
      get => (byte)(r * 255f);
      set => r = (value / 255f);
    }

    public float G
    {
      get => g;
      set => g = value;
    }

    public byte GByte
    {
      get => (byte)(g * 255f);
      set => g = (value / 255f);
    }

    public float B
    {
      get => b;
      set => b = value;
    }

    public byte BByte
    {
      get => (byte)(b * 255f);
      set => b = (value / 255f);
    }

    public float A
    {
      get => a;
      set => a = value;
    }

    public byte AByte
    {
      get => (byte)(a * 255f);
      set => a = (value / 255f);
    }

    internal float r;
    internal float g;
    internal float b;
    internal float a;
  }
}