#pragma once

#include "PCH.h"

#include "NativePointer.h"

namespace AllegroDotNet::Wrapper
{
	public ref class AllegroPath sealed : public NativePointer<ALLEGRO_PATH>
	{
	internal:
		AllegroPath(ALLEGRO_PATH* nativePath) : NativePointer(nativePath)
		{
		}
	};
}
