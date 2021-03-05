#include "PCH.h"

#include "Al.h"
#include "AllegroDisplayMode.h"

namespace AllegroDotNet::Wrapper
{
	AllegroDisplayMode^ Al::GetDisplayMode(Int32 index, AllegroDisplayMode^ mode)
	{
		auto* nativeMode = mode->GetNativePointer();
		auto* nativeReturnValue = al_get_display_mode(index, nativeMode);
		return gcnew AllegroDisplayMode(nativeReturnValue);
	}

	Int32 Al::GetNumDisplayModes()
	{
		return al_get_num_display_modes();
	}
}
