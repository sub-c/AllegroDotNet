namespace SubC.AllegroDotNet.Enums;

[Flags]
public enum MessageBoxFlags : int
{
  Warn = 1 << 0,
  Error = 1 << 1,
  OkCancel = 1 << 2,
  YesNo = 1 << 3,
  Question = 1 << 4
}
