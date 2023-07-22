using System.Runtime.InteropServices;

namespace SubC.AllegroDotNet.Native;

internal static partial class Interop
{
  public static Context Context { get; } = new();
  
  public static T LoadFunction<T>()
  {
    if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
      return Linux.LoadFunction<T>();
    
    if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
      return Windows.LoadFunction<T>();

    return (T)new object();
  }
}