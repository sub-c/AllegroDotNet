#include "PCH.h"

#include "NativePointerWrapper.h"

namespace AllegroDotNet::Wrapper
{
	public ref class AllegroPath : public NativePointerWrapper<ALLEGRO_PATH*>
	{
	internal:
		AllegroPath(ALLEGRO_PATH* nativePath);
		virtual ~AllegroPath();
		!AllegroPath();
	};
}
