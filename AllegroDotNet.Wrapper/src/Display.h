#pragma once

#include "PCH.h"

#include "AllegroDisplay.h"
#include "DisplayOrientation.h"

namespace AllegroDotNet::Wrapper
{
	public ref class Display
	{
	public:
		property AllegroDisplay^ Source
		{
			AllegroDisplay^ get()
			{
				managedDisplay_->SetNativePointer(nativeSourceEvent_->display.source);
				return managedDisplay_;
			}
		}

		property Int32 Height
		{
			Int32 get()
			{
				return nativeSourceEvent_->display.height;
			}
		}

		property DisplayOrientation Orientation
		{
			DisplayOrientation get()
			{
				return static_cast<DisplayOrientation>(nativeSourceEvent_->display.orientation);
			}
		}

		property Int32 Width
		{
			Int32 get()
			{
				return nativeSourceEvent_->display.width;
			}
		}

		property Int32 X
		{
			Int32 get()
			{
				return nativeSourceEvent_->display.x;
			}
		}

		property Int32 Y
		{
			Int32 get()
			{
				return nativeSourceEvent_->display.y;
			}
		}

	internal:
		Display(ALLEGRO_EVENT* nativeSourceEvent)
		{
			nativeSourceEvent_ = nativeSourceEvent;
		}

	private:
		AllegroDisplay^ managedDisplay_ { gcnew AllegroDisplay(nullptr) };
		ALLEGRO_EVENT* nativeSourceEvent_ { nullptr };
	};
}