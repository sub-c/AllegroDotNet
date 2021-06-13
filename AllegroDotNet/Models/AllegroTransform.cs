using SubC.AllegroDotNet.Native;

namespace SubC.AllegroDotNet.Models
{
    /// <summary>
    /// Defines the generic transformation type, a 4x4 matrix. 2D transforms use only a small subsection of this
    /// matrix, namely the top left 2x2 matrix, and the right most 2x1 matrix, for a total of 6 values.
    /// </summary>
    public sealed class AllegroTransform
    {
        internal NativeTransform Native = new NativeTransform(initialize: true);
    }
}
