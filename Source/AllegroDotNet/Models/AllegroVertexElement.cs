namespace SubC.AllegroDotNet.Models
{
  public sealed class AllegroVertexElement
  {
    internal NativeAllegroVertexElement NativeVertexElement = new();

    internal struct NativeAllegroVertexElement
    {
      public int attribute;
      public int storage;
      public int offset;
    }
  }
}
