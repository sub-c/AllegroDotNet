#pragma once

#include "PCH.h"

#include "NativePointerWrapper.h"

namespace AllegroDotNet::Wrapper
{
	public ref class AllegroConfig : public NativePointerWrapper<ALLEGRO_CONFIG*>
	{
	internal:
		AllegroConfig(ALLEGRO_CONFIG* nativeConfig);
		virtual ~AllegroConfig();
		!AllegroConfig();
	};
}
