using AllegroDotNet.Native;

namespace AllegroDotNet.Models
{
    /// <summary>
    /// Opaque type which holds various states of Allegro.
    /// <para>
    /// In general, the only real global state is the active system driver. All other global state is per-thread,
    /// so if your application has multiple separate threads they never will interfere with each other. (Except
    /// if there are objects accessed by multiple threads of course. Usually you want to minimize that though and
    /// for the remaining cases use synchronization primitives described in the threads section or events described
    /// in the events section to control inter-thread communication.)
    /// </para>
    /// </summary>
    public sealed class AllegroState
    {
        internal NativeState Native = new NativeState(initialize: true);
    }
}
