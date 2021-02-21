#include "PCH.h"

#include "AllegroBitmap.h"

namespace AllegroDotNet::Wrapper
{
	AllegroBitmap::AllegroBitmap(ALLEGRO_BITMAP* nativeBitmap)
		: NativePointer(nativeBitmap)
	{
	}
}
