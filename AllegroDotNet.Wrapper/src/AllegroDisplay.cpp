#include "PCH.h"

#include "AllegroDisplay.h"

namespace AllegroDotNet::Wrapper
{
	AllegroDisplay::AllegroDisplay(ALLEGRO_DISPLAY* nativeDisplay)
		: NativePointer(nativeDisplay)
	{
	}
}
