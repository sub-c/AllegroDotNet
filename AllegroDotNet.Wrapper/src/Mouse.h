#pragma once

#include "PCH.h"

#include "AllegroDisplay.h"

namespace AllegroDotNet::Wrapper
{
	public ref class Mouse
	{
	public:
		property UInt32 Button
		{
			UInt32 get()
			{
				return nativeSourceEvent_->mouse.button;
			}
		}

		property AllegroDisplay^ Display
		{
			AllegroDisplay^ get()
			{
				managedDisplay_->SetNativePointer(nativeSourceEvent_->mouse.display);
				return managedDisplay_;
			}
		}

		property Int32 DW
		{
			Int32 get()
			{
				return nativeSourceEvent_->mouse.dw;
			}
		}

		property Int32 DX
		{
			Int32 get()
			{
				return nativeSourceEvent_->mouse.dx;
			}
		}

		property Int32 DY
		{
			Int32 get()
			{
				return nativeSourceEvent_->mouse.dy;
			}
		}

		property Int32 DZ
		{
			Int32 get()
			{
				return nativeSourceEvent_->mouse.dz;
			}
		}

		property Int32 Pressure
		{
			Int32 get()
			{
				return nativeSourceEvent_->mouse.pressure;
			}
		}

		property Int32 W
		{
			Int32 get()
			{
				return nativeSourceEvent_->mouse.w;
			}
		}

		property Int32 X
		{
			Int32 get()
			{
				return nativeSourceEvent_->mouse.x;
			}
		}

		property Int32 Y
		{
			Int32 get()
			{
				return nativeSourceEvent_->mouse.y;
			}
		}

		property Int32 Z
		{
			Int32 get()
			{
				return nativeSourceEvent_->mouse.z;
			}
		}

	internal:
		Mouse(ALLEGRO_EVENT* nativeSourceEvent)
		{
			nativeSourceEvent_ = nativeSourceEvent;
		}

	private:
		AllegroDisplay^ managedDisplay_ { gcnew AllegroDisplay(nullptr) };
		ALLEGRO_EVENT* nativeSourceEvent_ { nullptr };
	};
}
