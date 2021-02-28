#include "PCH.h"

#include "AllegroConfigSection.h"

namespace AllegroDotNet::Wrapper
{
	AllegroConfigSection::AllegroConfigSection(ALLEGRO_CONFIG_SECTION* newConfigSection)
		: NativePointer(newConfigSection)
	{
	}
}
