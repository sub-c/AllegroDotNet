#pragma once

#include "PCH.h"

#include "NativeDisposableStruct.h"

namespace AllegroDotNet::Wrapper
{
	public ref class AllegroKeyboardState : NativeDisposableStruct<ALLEGRO_KEYBOARD_STATE>
	{
	public:
		AllegroKeyboardState();
	};
}
