using System;

namespace SubC.AllegroDotNet.Models
{
    /// <summary>
    /// This event holds user event data.
    /// </summary>
    public sealed class AllegroEvent_User
    {
        /// <summary>
        /// Native pointer to user event data.
        /// </summary>
        public IntPtr Data1 => _allegroEvent.NativeEvent.user.data1;

        /// <summary>
        /// Native pointer to user event data.
        /// </summary>
        public IntPtr Data2 => _allegroEvent.NativeEvent.user.data2;

        /// <summary>
        /// Native pointer to user event data.
        /// </summary>
        public IntPtr Data3 => _allegroEvent.NativeEvent.user.data3;

        /// <summary>
        /// Native pointer to user event data.
        /// </summary>
        public IntPtr Data4 => _allegroEvent.NativeEvent.user.data4;

        private readonly AllegroEvent _allegroEvent = null;

        internal AllegroEvent_User(AllegroEvent allegroEvent)
        {
            _allegroEvent = allegroEvent;
        }
    }
}
