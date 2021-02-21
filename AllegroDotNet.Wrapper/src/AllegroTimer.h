#pragma once

#include "PCH.h"

#include "NativePointer.h"

namespace AllegroDotNet::Wrapper
{
	public ref class AllegroTimer sealed : public NativePointer<ALLEGRO_TIMER>
	{
	internal:
		AllegroTimer(ALLEGRO_TIMER* nativeTimer);
	};
}
