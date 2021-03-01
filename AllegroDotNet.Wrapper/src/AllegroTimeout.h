#pragma once

#include "PCH.h"

#include "NativePointer.h"

namespace AllegroDotNet::Wrapper
{
	public ref class AllegroTimeout sealed : public NativePointer<ALLEGRO_TIMEOUT>
	{
	internal:
		AllegroTimeout(ALLEGRO_TIMEOUT* nativeTimeout) : NativePointer(nativeTimeout)
		{
		}
	};
}
