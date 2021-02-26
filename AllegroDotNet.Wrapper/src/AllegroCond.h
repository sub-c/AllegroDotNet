#pragma once

#include "PCH.h"

#include "NativePointer.h"

namespace AllegroDotNet::Wrapper
{
	public ref class AllegroCond sealed : public NativePointer<ALLEGRO_COND>
	{
	internal:
		AllegroCond(ALLEGRO_COND* nativeCond);
	};
}
