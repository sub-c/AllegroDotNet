#include "PCH.h"

#include "AllegroThread.h"

namespace AllegroDotNet::Wrapper
{
	AllegroThread::AllegroThread(ALLEGRO_THREAD* nativeThread)
		: NativePointer(nativeThread)
	{
	}
}
