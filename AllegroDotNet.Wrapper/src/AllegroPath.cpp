#include "PCH.h"

#include "AllegroPath.h"

namespace AllegroDotNet::Wrapper
{
	AllegroPath::AllegroPath(ALLEGRO_PATH* nativePath)
		: NativePointer(nativePath)
	{
	}
}
