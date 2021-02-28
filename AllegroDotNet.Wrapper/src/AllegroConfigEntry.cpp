#include "PCH.h"

#include "AllegroConfigEntry.h"

namespace AllegroDotNet::Wrapper
{
	AllegroConfigEntry::AllegroConfigEntry(ALLEGRO_CONFIG_ENTRY* newConfigEntry)
		: NativePointer(newConfigEntry)
	{
	}
}
