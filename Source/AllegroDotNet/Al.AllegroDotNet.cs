using SubC.AllegroDotNet.Native;

namespace SubC.AllegroDotNet;

/// <summary>
/// This static class contains the Allegro 5 library methods.
/// </summary>
public static partial class Al
{
    /// <summary>
    /// This method sets a custom instance of <see cref="IInteropProvider"/> to load the Allegro 5 library and functions.
    /// Usually you do not need to call this because AllegroDotNet will use built-in providers for Windows or Linux.
    /// </summary>
    /// <param name="interopProvider">The custom instance of the interop provider.</param>
    /// <exception cref="Exception">
    /// Thrown if the interop provider has already been set. Ensure no Allegro methods are called before this method is called.
    /// </exception>
    public static void SetupInteropProvider(IInteropProvider interopProvider)
    {
        if (Interop.InteropProvider is not null)
            throw new Exception($"Cannot set interop provider: provider is already set to '{Interop.InteropProvider.GetType().Name}'. Set the provider before calling any Allegro functions.");

        Interop.InteropProvider = interopProvider;
    }
}
