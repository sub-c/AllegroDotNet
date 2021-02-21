#pragma once

#include "PCH.h"

#include "NativePointer.h"

namespace AllegroDotNet::Wrapper
{
	public ref class AllegroDisplay : NativePointer<ALLEGRO_DISPLAY>
	{
	internal:
		AllegroDisplay(ALLEGRO_DISPLAY* nativeDisplay);
	};
}
