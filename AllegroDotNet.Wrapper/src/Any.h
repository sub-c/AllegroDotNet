#pragma once

#include "AllegroEvent.h"
#include "AllegroEventSource.h"

namespace AllegroDotNet::Wrapper
{
	public ref class Any
	{
	public:
		property AllegroEventSource^ Source
		{
			AllegroEventSource^ get()
			{
				return gcnew AllegroEventSource(nativeSourceEvent_->any.source);
			}
		}

		property Double Timestamp
		{
			Double get()
			{
				return nativeSourceEvent_->any.timestamp;
			}
		}

	internal:
		Any(ALLEGRO_EVENT* nativeSourceEvent)
		{
			nativeSourceEvent_ = nativeSourceEvent;
		}

	private:
		ALLEGRO_EVENT* nativeSourceEvent_ { nullptr };
	};
}
