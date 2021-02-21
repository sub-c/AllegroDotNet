#include "PCH.h"

#include "AllegroEventSource.h"

namespace AllegroDotNet::Wrapper
{
	AllegroEventSource::AllegroEventSource()
		: NativePointer(new ALLEGRO_EVENT_SOURCE())
	{
	}

	AllegroEventSource::AllegroEventSource(ALLEGRO_EVENT_SOURCE* nativeEventSource)
		: NativePointer(nativeEventSource)
	{
	}
}
