#pragma once

#include "PCH.h"

#include "NativePointer.h"

namespace AllegroDotNet::Wrapper
{
	public ref class AllegroJoystick sealed : public NativePointer<ALLEGRO_JOYSTICK>
	{
	internal:
		AllegroJoystick(ALLEGRO_JOYSTICK* nativeJoystick) : NativePointer(nativeJoystick)
		{
		}
	};
}
