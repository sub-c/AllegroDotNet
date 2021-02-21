#pragma once

#include "PCH.h"

#include "NativePointer.h"

namespace AllegroDotNet::Wrapper
{
	public ref class AllegroConfig : NativePointer<ALLEGRO_CONFIG>
	{
	internal:
		AllegroConfig(ALLEGRO_CONFIG* nativeConfig);
	};
}
