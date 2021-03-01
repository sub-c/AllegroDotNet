#pragma once

#include "PCH.h"

#include "NativePointer.h"

namespace AllegroDotNet::Wrapper
{
	using namespace System;

	public ref class Button sealed : public NativePointer<ALLEGRO_JOYSTICK_STATE>
	{
	public:
		property Int32 default[Int32]
		{
			Int32 get(Int32 i)
			{
				return GetNativePointer()->button[i];
			}
		}
		
	internal:
		Button(ALLEGRO_JOYSTICK_STATE* nativeJoystickState) : NativePointer(nativeJoystickState)
		{
		}
	};
}
