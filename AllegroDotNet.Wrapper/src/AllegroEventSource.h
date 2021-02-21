#pragma once

#include "PCH.h"

#include "NativePointer.h"

namespace AllegroDotNet::Wrapper
{
	public ref class AllegroEventSource : public NativePointer<ALLEGRO_EVENT_SOURCE>
	{
	public:
		AllegroEventSource();

	internal:
		AllegroEventSource(ALLEGRO_EVENT_SOURCE* nativeEventSource);
	};
}
