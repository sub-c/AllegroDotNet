#pragma once

#include "PCH.h"

#include "AllegroDisplay.h"

namespace AllegroDotNet::Wrapper
{
	public ref class Touch
	{
	public:
		property Boolean Primary
		{
			Boolean get()
			{
				return nativeSourceEvent_->touch.primary;
			}
		}

		property AllegroDisplay^ Display
		{
			AllegroDisplay^ get()
			{
				managedDisplay_->SetNativePointer(nativeSourceEvent_->touch.display);
				return managedDisplay_;
			}
		}

		property Int32 DX
		{
			Int32 get()
			{
				return nativeSourceEvent_->touch.dx;
			}
		}

		property Int32 DY
		{
			Int32 get()
			{
				return nativeSourceEvent_->touch.dy;
			}
		}

		property Int32 ID
		{
			Int32 get()
			{
				return nativeSourceEvent_->touch.id;
			}
		}

		property Int32 X
		{
			Int32 get()
			{
				return nativeSourceEvent_->touch.x;
			}
		}

		property Int32 Y
		{
			Int32 get()
			{
				return nativeSourceEvent_->touch.y;
			}
		}

	internal:
		Touch(ALLEGRO_EVENT* nativeSourceEvent)
		{
			nativeSourceEvent_ = nativeSourceEvent;
		}

	private:
		AllegroDisplay^ managedDisplay_ { gcnew AllegroDisplay(nullptr) };
		ALLEGRO_EVENT* nativeSourceEvent_ { nullptr };
	};
}
