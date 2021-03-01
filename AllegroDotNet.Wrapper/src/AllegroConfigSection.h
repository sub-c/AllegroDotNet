#include "PCH.h"

#include "NativePointer.h"

namespace AllegroDotNet::Wrapper
{
	public ref class AllegroConfigSection sealed : public NativePointer<ALLEGRO_CONFIG_SECTION>
	{
	internal:
		AllegroConfigSection(ALLEGRO_CONFIG_SECTION* newConfigSection) : NativePointer(newConfigSection)
		{
		}
	};
}
