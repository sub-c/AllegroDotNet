using SubC.AllegroDotNet.Enums;
using SubC.AllegroDotNet.Native;

namespace SubC.AllegroDotNet.Models
{
    /// <summary>
    /// An <see cref="AllegroEvent"/> is a union of all builtin event structures, i.e. it is an object large enough to
    /// hold the data of any event type. All events have the following fields in common:
    /// 
    /// type(ALLEGRO_EVENT_TYPE)
    /// Indicates the type of event. 
    /// any.source (ALLEGRO_EVENT_SOURCE *)
    /// The event source which generated the event. 
    /// any.timestamp (double)
    /// When the event was generated. 
    /// 
    /// By examining the type field you can then access type-specific fields. The any.source field tells you which
    /// event source generated that particular event. The any.timestamp field tells you when the event was generated.
    /// The time is referenced to the same starting point as al_get_time.
    /// 
    /// Each event is of one of the following types, with the usable fields given.
    /// </summary>
    public sealed class AllegroEvent
    {
        /// <summary>
        /// Data common to all events.
        /// </summary>
        public AllegroEvent_All All { get; } = null;

        /// <summary>
        /// Display event data.
        /// </summary>
        public AllegroEvent_Display Display { get; } = null;

        /// <summary>
        /// Joystick event data.
        /// </summary>
        public AllegroEvent_Joystick Joystick { get; } = null;

        /// <summary>
        /// Keyboard event data.
        /// </summary>
        public AllegroEvent_Keyboard Keyboard { get; } = null;

        /// <summary>
        /// Mouse event data.
        /// </summary>
        public AllegroEvent_Mouse Mouse { get; } = null;

        /// <summary>
        /// Timer event data.
        /// </summary>
        public AllegroEvent_Timer Timer { get; } = null;

        /// <summary>
        /// Touch event data.
        /// </summary>
        public AllegroEvent_Touch Touch { get; } = null;

        /// <summary>
        /// The event type.
        /// </summary>
        public EventType Type => (EventType)NativeEvent.type;

        /// <summary>
        /// User event data.
        /// </summary>
        public AllegroEvent_User User { get; } = null;

        internal NativeAllegroEvent NativeEvent = new NativeAllegroEvent();

        /// <summary>
        /// Initialize a new instance of the <see cref="AllegroEvent"/> class.
        /// </summary>
        public AllegroEvent()
        {
            All = new AllegroEvent_All(this);
            Display = new AllegroEvent_Display(this);
            Joystick = new AllegroEvent_Joystick(this);
            Keyboard = new AllegroEvent_Keyboard(this);
            Mouse = new AllegroEvent_Mouse(this);
            Timer = new AllegroEvent_Timer(this);
            Touch = new AllegroEvent_Touch(this);
            User = new AllegroEvent_User(this);
        }
    }
}
