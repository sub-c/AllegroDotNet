#pragma once

#include "PCH.h"

#include "NativePointer.h"

namespace AllegroDotNet::Wrapper
{
	using namespace System;

	public ref class StickAxis sealed : public NativePointer<ALLEGRO_JOYSTICK_STATE>
	{
	public:
		property Single default[Int32, Int32]
		{
			Single get(Int32 s, Int32 a)
			{
				return GetNativePointer()->stick[s].axis[a];
			}
		}

	internal:
		StickAxis(ALLEGRO_JOYSTICK_STATE* newJoystickState) : NativePointer(newJoystickState)
		{
		}
	};
}
