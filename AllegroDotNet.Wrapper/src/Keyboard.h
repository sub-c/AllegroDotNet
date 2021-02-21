#pragma once

#include "PCH.h"

#include "AllegroDisplay.h"
#include "KeyCode.h"
#include "KeyModFlags.h"

namespace AllegroDotNet::Wrapper
{
	public ref class Keyboard
	{
	public:
		property AllegroDisplay^ Display
		{
			AllegroDisplay^ get()
			{
				managedDisplay_->SetNativePointer(nativeSourceEvent_->keyboard.display);
				return managedDisplay_;
			}
		}

		property KeyCode KeyCode
		{
			AllegroDotNet::Wrapper::KeyCode get()
			{
				return static_cast<AllegroDotNet::Wrapper::KeyCode>(nativeSourceEvent_->keyboard.keycode);
			}
		}

		property KeyModFlags Modifiers
		{
			KeyModFlags get()
			{
				return static_cast<KeyModFlags>(nativeSourceEvent_->keyboard.modifiers);
			}
		}

		property Boolean Repeat
		{
			Boolean get()
			{
				return nativeSourceEvent_->keyboard.repeat;
			}
		}

		property Int32 Unichar
		{
			Int32 get()
			{
				return nativeSourceEvent_->keyboard.unichar;
			}
		}

	internal:
		Keyboard(ALLEGRO_EVENT* nativeSourceEvent)
		{
			nativeSourceEvent_ = nativeSourceEvent;
		}

	private:
		AllegroDisplay^ managedDisplay_ { gcnew AllegroDisplay(nullptr) };
		ALLEGRO_EVENT* nativeSourceEvent_ { nullptr };
	};
}
