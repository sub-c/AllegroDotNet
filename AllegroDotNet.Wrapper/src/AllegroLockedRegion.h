#pragma once

#include "PCH.h"

#include "NativePointer.h"
#include "PixelFormat.h"

namespace AllegroDotNet::Wrapper
{
	public ref class AllegroLockedRegion sealed : public NativePointer<ALLEGRO_LOCKED_REGION>
	{
	public:
		property IntPtr Data
		{
			IntPtr get()
			{
				return IntPtr(GetNativePointer()->data);
			}
		}

		property PixelFormat Format
		{
			PixelFormat get()
			{
				return static_cast<PixelFormat>(GetNativePointer()->format);
			}
		}

		property Int32 Pitch
		{
			Int32 get()
			{
				return GetNativePointer()->pitch;
			}
		}

		property Int32 PixelSize
		{
			Int32 get()
			{
				return GetNativePointer()->pixel_size;
			}
		}

	internal:
		AllegroLockedRegion(ALLEGRO_LOCKED_REGION* nativeLockedRegion) : NativePointer(nativeLockedRegion)
		{
		}
	};
}
