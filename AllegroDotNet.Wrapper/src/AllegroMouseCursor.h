#pragma once

#include "PCH.h"

#include "NativePointer.h"

namespace AllegroDotNet::Wrapper
{
	public ref class AllegroMouseCursor sealed : public NativePointer<ALLEGRO_MOUSE_CURSOR>
	{
	internal:
		AllegroMouseCursor(ALLEGRO_MOUSE_CURSOR* nativeMouseCursor) : NativePointer(nativeMouseCursor)
		{
		}
	};
}
