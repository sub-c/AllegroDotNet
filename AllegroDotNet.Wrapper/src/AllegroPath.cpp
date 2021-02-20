#include "PCH.h"

#include "AllegroPath.h"

namespace AllegroDotNet::Wrapper
{
	AllegroPath::AllegroPath(ALLEGRO_PATH* nativePath)
		: NativePointerWrapper(nativePath)
	{
	}

	AllegroPath::~AllegroPath()
	{
	}

	AllegroPath::!AllegroPath()
	{
	}
}
