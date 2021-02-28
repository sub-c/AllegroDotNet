#include "PCH.h"

#include "AllegroFile.h"

namespace AllegroDotNet::Wrapper
{
	AllegroFile::AllegroFile(ALLEGRO_FILE* newFile)
		: NativePointer(newFile)
	{
	}
}
