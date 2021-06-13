namespace SubC.AllegroDotNet.Models
{
    /// <summary>
    /// Opaque filesystem entry object. Represents a file or a directory (check with
    /// <see cref="Al.GetFsEntryMode"/>). There are no user accessible member variables.
    /// </summary>
    public sealed class AllegroFSEntry : NativePointerWrapper
    {
        internal AllegroFSEntry()
        {
        }
    }
}
