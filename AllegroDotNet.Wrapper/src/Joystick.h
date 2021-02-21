#pragma once

#include "PCH.h"

#include "AllegroJoystick.h"

namespace AllegroDotNet::Wrapper
{
	public ref class Joystick
	{
	public:
		property Int32 Axis
		{
			Int32 get()
			{
				return nativeSourceEvent_->joystick.axis;
			}
		}

		property Int32 Button
		{
			Int32 get()
			{
				return nativeSourceEvent_->joystick.button;
			}
		}

		property AllegroJoystick^ ID
		{
			AllegroJoystick^ get()
			{
				managedJoystick_->SetNativePointer(nativeSourceEvent_->joystick.id);
				return managedJoystick_;
			}
		}

		property Single Pos
		{
			Single get()
			{
				return nativeSourceEvent_->joystick.pos;
			}
		}

		property Int32 Stick
		{
			Int32 get()
			{
				return nativeSourceEvent_->joystick.stick;
			}
		}

	internal:
		Joystick(ALLEGRO_EVENT* nativeSourceEvent)
		{
			nativeSourceEvent_ = nativeSourceEvent;
		}

	private:
		AllegroJoystick^ managedJoystick_ { gcnew AllegroJoystick(nullptr) };
		ALLEGRO_EVENT* nativeSourceEvent_ { nullptr };
	};
}
