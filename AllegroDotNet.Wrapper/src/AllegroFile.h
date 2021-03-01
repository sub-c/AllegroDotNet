#pragma once

#include "PCH.h"

#include "NativePointer.h"

namespace AllegroDotNet::Wrapper
{
	public ref class AllegroFile sealed : public NativePointer<ALLEGRO_FILE>
	{
	internal:
		AllegroFile(ALLEGRO_FILE* newFile) : NativePointer(newFile)
		{
		}
	};
}
