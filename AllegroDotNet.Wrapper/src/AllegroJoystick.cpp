#include "PCH.h"

#include "AllegroJoystick.h"

namespace AllegroDotNet::Wrapper
{
	AllegroJoystick::AllegroJoystick(ALLEGRO_JOYSTICK* nativeJoystick)
		: NativePointer(nativeJoystick)
	{
	}
}
