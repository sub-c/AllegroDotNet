#pragma once

#include "PCH.h"

#include "NativePointer.h"

namespace AllegroDotNet::Wrapper
{
	public ref class AllegroJoystick : public NativePointer<ALLEGRO_JOYSTICK>
	{
	internal:
		AllegroJoystick(ALLEGRO_JOYSTICK* nativeJoystick);
	};
}
