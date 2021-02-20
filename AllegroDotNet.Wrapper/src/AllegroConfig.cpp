#include "PCH.h"

#include "AllegroConfig.h"

namespace AllegroDotNet::Wrapper
{
	AllegroConfig::AllegroConfig(ALLEGRO_CONFIG* nativeConfig)
		: NativePointerWrapper(nativeConfig)
	{
	}

	AllegroConfig::~AllegroConfig()
	{
	}

	AllegroConfig::!AllegroConfig()
	{
	}
}
