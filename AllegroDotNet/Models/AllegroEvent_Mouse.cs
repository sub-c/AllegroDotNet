using SubC.AllegroDotNet.Enums;

namespace SubC.AllegroDotNet.Models
{
    /// <summary>
    /// This clas holds mouse event data.
    /// </summary>
    public sealed class AllegroEvent_Mouse
    {
        /// <summary>
        /// The mouse button which was pressed, numbering from 1.
        /// </summary>
        public uint Button => _allegroEvent.NativeEvent.mouse.button;

        /// <summary>
        /// Change in the w-coordinate value since the previous <see cref="EventType.MouseAxes"/> event. 
        /// </summary>
        public int DW => _allegroEvent.NativeEvent.mouse.dw;

        /// <summary>
        /// Change in the x-coordinate value since the previous <see cref="EventType.MouseAxes"/> event.
        /// </summary>
        public int DX => _allegroEvent.NativeEvent.mouse.dx;

        /// <summary>
        /// Change in the y-coordinate value since the previous <see cref="EventType.MouseAxes"/> event. 
        /// </summary>
        public int DY => _allegroEvent.NativeEvent.mouse.dy;

        /// <summary>
        /// Change in the z-coordinate value since the previous <see cref="EventType.MouseAxes"/> event.
        /// </summary>
        public int DZ => _allegroEvent.NativeEvent.mouse.dz;

        /// <summary>
        /// Pressure, ranging from 0.0 to 1.0. 
        /// </summary>
        public float Pressure => _allegroEvent.NativeEvent.mouse.pressure;

        /// <summary>
        /// w-coordinate. This usually means the horizontal axis of a mouse wheel. 
        /// </summary>
        public int W => _allegroEvent.NativeEvent.mouse.w;

        /// <summary>
        /// x-coordinate
        /// </summary>
        public int X => _allegroEvent.NativeEvent.mouse.x;

        /// <summary>
        /// y-coordinate
        /// </summary>
        public int Y => _allegroEvent.NativeEvent.mouse.y;

        /// <summary>
        /// z-coordinate. This usually means the vertical axis of a mouse wheel, where up is positive and down is negative. 
        /// </summary>
        public int Z => _allegroEvent.NativeEvent.mouse.z;

        private readonly AllegroEvent _allegroEvent;

        internal AllegroEvent_Mouse(AllegroEvent allegroEvent)
        {
            _allegroEvent = allegroEvent;
        }
    }
}
