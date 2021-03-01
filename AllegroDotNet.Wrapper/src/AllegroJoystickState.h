#pragma once

#include "PCH.h"

#include "Button.h"
#include "NativeDisposableStruct.h"
#include "StickAxis.h"

namespace AllegroDotNet::Wrapper
{
	using namespace System::Collections::Generic;

	public ref class AllegroJoystickState sealed : public NativeDisposableStruct<ALLEGRO_JOYSTICK_STATE>
	{
	public:
		initonly Button^ Button { gcnew AllegroDotNet::Wrapper::Button(GetNativePointer()) };
		initonly StickAxis^ StickAxis { gcnew AllegroDotNet::Wrapper::StickAxis(GetNativePointer()) };

		AllegroJoystickState() : NativeDisposableStruct()
		{
		}
	};
}
