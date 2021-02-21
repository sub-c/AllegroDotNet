#include "PCH.h"

#include "AllegroConfig.h"

namespace AllegroDotNet::Wrapper
{
	AllegroConfig::AllegroConfig(ALLEGRO_CONFIG* nativeConfig)
		: NativePointer(nativeConfig)
	{
	}
}
