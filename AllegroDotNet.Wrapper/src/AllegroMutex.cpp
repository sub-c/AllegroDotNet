#include "PCH.h"

#include "AllegroMutex.h"

namespace AllegroDotNet::Wrapper
{
	AllegroMutex::AllegroMutex(ALLEGRO_MUTEX* nativeMutex)
		: NativePointer(nativeMutex)
	{
	}
}
