using System;

namespace SubC.AllegroDotNet.Enums
{
  [Flags]
  public enum FileChooser : int
  {
    None = 0,
    FileMustExist = 1,
    Save = 2,
    Folder = 4,
    Pictures = 8,
    ShowHidden = 16,
    Multiple = 32
  }
}