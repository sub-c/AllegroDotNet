#pragma once

#include "PCH.h"

#include "NativePointer.h"

namespace AllegroDotNet::Wrapper
{
	public ref class AllegroConfigEntry sealed : public NativePointer<ALLEGRO_CONFIG_ENTRY>
	{
	internal:
		AllegroConfigEntry(ALLEGRO_CONFIG_ENTRY* newConfigEntry);
	};
}
