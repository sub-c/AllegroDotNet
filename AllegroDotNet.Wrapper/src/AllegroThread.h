#pragma once

#include "PCH.h"

#include "NativePointer.h"

namespace AllegroDotNet::Wrapper
{
	public ref class AllegroThread sealed : public NativePointer<ALLEGRO_THREAD>
	{
	internal:
		AllegroThread(ALLEGRO_THREAD* nativeThread);
	};
}
