namespace SubC.AllegroDotNet.Enums;

public enum StateFlags
{
  NewDisplayParameters = 0x0001,
  NewBitmapParameters = 0x0002,
  Display = 0x0004,
  TargetBitmap = 0x0008,
  Blender = 0x0010,
  NewFileInterface = 0x0020,
  Transform = 0x0040,
  ProjectionTransform = 0x0100,
  Bitmap = TargetBitmap | NewBitmapParameters,
  All = 0xffff
}
