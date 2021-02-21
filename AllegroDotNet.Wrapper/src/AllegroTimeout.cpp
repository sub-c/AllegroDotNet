#include "PCH.h"

#include "AllegroTimeout.h"

namespace AllegroDotNet::Wrapper
{
	AllegroTimeout::AllegroTimeout(ALLEGRO_TIMEOUT* nativeTimeout)
		: NativePointer(nativeTimeout)
	{
	}
}
