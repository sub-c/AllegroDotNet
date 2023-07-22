namespace SubC.AllegroDotNet.Models;

/// <summary>
/// This abstract class wraps a native Allegro structure.
/// </summary>
/// <typeparam name="T">The native (marshal-able) Allegro structure.</typeparam>
public abstract class NativeStruct<T>
  where T : struct
{
  internal T Struct = new();
}