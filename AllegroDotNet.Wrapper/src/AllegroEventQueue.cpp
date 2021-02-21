#include "PCH.h"

#include "AllegroEventQueue.h"

namespace AllegroDotNet::Wrapper
{
	AllegroEventQueue::AllegroEventQueue(ALLEGRO_EVENT_QUEUE* nativeEventQueue)
		: NativePointer(nativeEventQueue)
	{
	}
}
