namespace SubC.AllegroDotNet.Enums
{
  public enum RenderState : int
  {
    None = 0,
    AlphaTest = 0x0010,
    WriteMask,
    DepthTest,
    DepthFunction,
    AlphaFunction,
    AlphaTestValue
  }
}