#pragma once

#include "PCH.h"

#include "NativePointer.h"

namespace AllegroDotNet::Wrapper
{
	public ref class AllegroMutex sealed : public NativePointer<ALLEGRO_MUTEX>
	{
	internal:
		AllegroMutex(ALLEGRO_MUTEX* nativeMutex) : NativePointer(nativeMutex)
		{
		}
	};
}
