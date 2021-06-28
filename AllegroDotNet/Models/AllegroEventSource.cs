using SubC.AllegroDotNet.Native;

namespace SubC.AllegroDotNet.Models
{
    /// <summary>
    /// An event source is any object which can generate events. For example, an <see cref="AllegroDisplay"/> can generate events, and you can get
    /// the <see cref="AllegroEventSource"/> pointer from an <see cref="AllegroDisplay"/> with Al.GetDisplayEventSource().
    /// <para>
    /// You may create your own "user" event sources that emit custom events.
    /// </para>
    /// </summary>
    public sealed class AllegroEventSource : NativePointerWrapper
    {
        internal AllegroEventSource()
        {
        }
    }
}
