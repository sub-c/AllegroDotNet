namespace SubC.AllegroDotNet.Enums;

[Flags]
public enum AudioDepth : int
{
  Int8 = 0x00,
  Int16 = 0x01,
  Int24 = 0x02,
  Float32 = 0x03,
  Unsigned = 0x08,
  UInt8 = Int8 | Unsigned,
  UInt16 = Int16 | Unsigned,
  UInt24 = Int24 | Unsigned
}
