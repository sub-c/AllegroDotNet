#pragma once

#include "PCH.h"

#include "NativePointer.h"

namespace AllegroDotNet::Wrapper
{
	public ref class AllegroEventSource sealed : public NativePointer<ALLEGRO_EVENT_SOURCE>
	{
	public:
		AllegroEventSource() : NativePointer(new ALLEGRO_EVENT_SOURCE())
		{
		}

	internal:
		AllegroEventSource(ALLEGRO_EVENT_SOURCE* nativeEventSource) : NativePointer(nativeEventSource)
		{
		}

		Object^ Data { nullptr };
	};
}
