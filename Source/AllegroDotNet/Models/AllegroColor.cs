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

    public float G
    {
      get => g;
      set => g = value;
    }

    public float B
    {
      get => b;
      set => b = value;
    }

    public float A
    {
      get => a;
      set => a = value;
    }

    internal float r;
    internal float g;
    internal float b;
    internal float a;
  }
}