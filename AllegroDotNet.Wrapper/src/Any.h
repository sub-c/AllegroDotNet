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
				managedEventSource_->SetNativePointer(nativeSourceEvent_->any.source);
				return managedEventSource_;
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
		AllegroEventSource^ managedEventSource_ { gcnew AllegroEventSource(nullptr) };
		ALLEGRO_EVENT* nativeSourceEvent_ { nullptr };
	};
}
