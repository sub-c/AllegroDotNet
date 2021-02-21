#include "PCH.h"

#include "AllegroTimer.h"

namespace AllegroDotNet::Wrapper
{
	AllegroTimer::AllegroTimer(ALLEGRO_TIMER* nativeTimer)
		: NativePointer(nativeTimer)
	{
	}
}
