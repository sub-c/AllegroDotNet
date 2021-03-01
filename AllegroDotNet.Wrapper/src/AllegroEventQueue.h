#pragma once

#include "PCH.h"

#include "NativePointer.h"

namespace AllegroDotNet::Wrapper
{
	public ref class AllegroEventQueue sealed : public NativePointer<ALLEGRO_EVENT_QUEUE>
	{
	internal:
		AllegroEventQueue(ALLEGRO_EVENT_QUEUE* nativeEventQueue) : NativePointer(nativeEventQueue)
		{
		}
	};
}
