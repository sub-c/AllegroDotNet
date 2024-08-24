using SubC.AllegroDotNet.InteropProviders;
using System.Runtime.InteropServices;

namespace SubC.AllegroDotNet.Native;

internal static partial class Interop
{
    public static IInteropProvider? InteropProvider { get; set; }

    public static T LoadFunction<T>()
        where T : Delegate
    {
        if (InteropProvider is null)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                InteropProvider = new InteropProviderLinux();
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                InteropProvider = new InteropProviderOSX();
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                InteropProvider = new InteropProviderWindows();
            else
                throw new PlatformNotSupportedException("The operating system is not supported by AllegroDotNet.");
        }

        var functionPointer = InteropProvider.GetFunctionPointer<T>();

        return functionPointer is null
            ? throw new Exception($"Cannot get function pointer for function '{typeof(T).Name}'.")
            : functionPointer;
    }
}
