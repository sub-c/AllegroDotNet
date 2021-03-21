#pragma once

#include "PCH.h"

#include "NativeDisposableStruct.h"

namespace AllegroDotNet::Wrapper
{
	public ref class AllegroColor sealed : NativeDisposableStruct<ALLEGRO_COLOR>
	{
	public:
		property Single A
		{
			Single get()
			{
				return GetNativePointer()->a;
			}

			void set(Single value)
			{
				GetNativePointer()->a = value;
			}
		}

		property Single B
		{
			Single get()
			{
				return GetNativePointer()->b;
			}

			void set(Single value)
			{
				GetNativePointer()->b = value;
			}
		}

		property Single G
		{
			Single get()
			{
				return GetNativePointer()->g;
			}

			void set(Single value)
			{
				GetNativePointer()->g = value;
			}
		}

		property Single R
		{
			Single get()
			{
				return GetNativePointer()->r;
			}

			void set(Single value)
			{
				GetNativePointer()->r = value;
			}
		}

	internal:
		AllegroColor() : NativeDisposableStruct()
		{
		}

		AllegroColor(ALLEGRO_COLOR nativeColor) : NativeDisposableStruct()
		{
			auto* nativePointer = GetNativePointer();
			nativePointer->r = nativeColor.r;
			nativePointer->g = nativeColor.g;
			nativePointer->b = nativeColor.b;
			nativePointer->a = nativeColor.a;
		}
	};
}
