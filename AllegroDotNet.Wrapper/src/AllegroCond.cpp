#include "PCH.h"

#include "AllegroCond.h"

namespace AllegroDotNet::Wrapper
{
	AllegroCond::AllegroCond(ALLEGRO_COND* nativeCond)
		: NativePointer(nativeCond)
	{
	}
}
