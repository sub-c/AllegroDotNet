#pragma once

#include "PCH.h"

#include "PixelFormat.h"
#include "NativeDisposableStruct.h"

namespace AllegroDotNet::Wrapper
{
	public ref class AllegroDisplayMode sealed : public NativeDisposableStruct<ALLEGRO_DISPLAY_MODE>
	{
	public:
		property Int32 Height
		{
			Int32 get()
			{
				return GetNativePointer()->height;
			}
		}

		property Int32 RefreshRate
		{
			Int32 get()
			{
				return GetNativePointer()->refresh_rate;
			}
		}

		property PixelFormat Format
		{
			PixelFormat get()
			{
				return static_cast<PixelFormat>(GetNativePointer()->format);
			}
		}

		property Int32 Width
		{
			Int32 get()
			{
				return GetNativePointer()->width;
			}
		}

		AllegroDisplayMode() : NativeDisposableStruct()
		{
		}

	internal:
		AllegroDisplayMode(ALLEGRO_DISPLAY_MODE* nativeDisplayMode) : NativeDisposableStruct()
		{
			delete GetNativePointer();
			SetNativePointer(nativeDisplayMode);
		}
	};
}
