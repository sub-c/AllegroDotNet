namespace SubC.AllegroDotNet.Enums
{
  public enum FSMode : int
  {
    Read = 1,
    Write = 1 << 1,
    Execute = 1 << 2,
    Hidden = 1 << 3,
    IsFile = 1 << 4,
    IsDir = 1 << 5
  }
}