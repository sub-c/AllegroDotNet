#pragma once

#include "PCH.h"

#include "Any.h"
#include "Display.h"
#include "EventType.h"
#include "Joystick.h"
#include "Keyboard.h"
#include "Mouse.h"
#include "NativeDisposableStruct.h"
#include "Timer.h"
#include "Touch.h"
#include "AllegroUserEvent.h"

namespace AllegroDotNet::Wrapper
{
	public ref class AllegroEvent sealed : public NativeDisposableStruct<ALLEGRO_EVENT>
	{
	public:
		property EventType EventType
		{
			AllegroDotNet::Wrapper::EventType get()
			{
				return static_cast<AllegroDotNet::Wrapper::EventType>(GetNativePointer()->type);
			}
		}

		initonly Any^ Any { gcnew AllegroDotNet::Wrapper::Any(this->GetNativePointer()) };
		initonly Display^ Display { gcnew AllegroDotNet::Wrapper::Display(this->GetNativePointer()) };
		initonly Joystick^ Joystick { gcnew AllegroDotNet::Wrapper::Joystick(this->GetNativePointer()) };
		initonly Keyboard^ Keyboard { gcnew AllegroDotNet::Wrapper::Keyboard(this->GetNativePointer()) };
		initonly Mouse^ Mouse { gcnew AllegroDotNet::Wrapper::Mouse(this->GetNativePointer()) };
		initonly Timer^ Timer { gcnew AllegroDotNet::Wrapper::Timer(this->GetNativePointer()) };
		initonly Touch^ Touch { gcnew AllegroDotNet::Wrapper::Touch(this->GetNativePointer()) };
		initonly AllegroUserEvent^ AllegroUserEvent { gcnew AllegroDotNet::Wrapper::AllegroUserEvent(this->GetNativePointer()) };

		AllegroEvent() : NativeDisposableStruct()
		{
		}
	};
}
