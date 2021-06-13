using System;

namespace SubC.AllegroDotNet.Models
{
    public sealed class AllegroEvent_User
    {
        public IntPtr Data1 => _allegroEvent.NativeEvent.user.data1;
        public IntPtr Data2 => _allegroEvent.NativeEvent.user.data2;
        public IntPtr Data3 => _allegroEvent.NativeEvent.user.data3;
        public IntPtr Data4 => _allegroEvent.NativeEvent.user.data4;

        private readonly AllegroEvent _allegroEvent = null;

        internal AllegroEvent_User(AllegroEvent allegroEvent)
        {
            _allegroEvent = allegroEvent;
        }
    }
}
