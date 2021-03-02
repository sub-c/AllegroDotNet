#pragma once

#include "PCH.h"

#include "NativeDisposableStruct.h"

namespace AllegroDotNet::Wrapper
{
	public ref class AllegroTimeout sealed : public NativeDisposableStruct<ALLEGRO_TIMEOUT>
	{
	public:
		AllegroTimeout() : NativeDisposableStruct()
		{
		}
	};
}
