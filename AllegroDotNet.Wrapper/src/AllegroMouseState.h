#pragma once

#include "PCH.h"

#include "NativeDisposableStruct.h"

namespace AllegroDotNet::Wrapper
{
	public ref class AllegroMouseState sealed : public NativeDisposableStruct<ALLEGRO_MOUSE_STATE>
	{
	public:
		property Int32 Buttons
		{
			Int32 get() { return GetNativePointer()->buttons; }
		}

		property Single Pressure
		{
			Single get() { return GetNativePointer()->pressure; }
		}

		property Int32 W
		{
			Int32 get() { return GetNativePointer()->w; }
		}

		property Int32 X
		{
			Int32 get() { return GetNativePointer()->x; }
		}

		property Int32 Y
		{
			Int32 get() { return GetNativePointer()->y; }
		}

		property Int32 Z
		{
			Int32 get() { return GetNativePointer()->z; }
		}

		AllegroMouseState() : NativeDisposableStruct()
		{
		}
	};
}
