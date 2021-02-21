#pragma once

#include "PCH.h"

#include "NativePointer.h"

namespace AllegroDotNet::Wrapper
{
	public ref class AllegroDisplay sealed : NativePointer<ALLEGRO_DISPLAY>
	{
	internal:
		AllegroDisplay(ALLEGRO_DISPLAY* nativeDisplay);
	};
}
