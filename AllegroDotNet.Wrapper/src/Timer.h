#pragma once

#include "PCH.h"

namespace AllegroDotNet::Wrapper
{
	public ref class Timer
	{
	public:

	internal:
		Timer(ALLEGRO_EVENT* nativeSourceEvent)
		{
			nativeSourceEvent_ = nativeSourceEvent;
		}

	private:
		ALLEGRO_EVENT* nativeSourceEvent_ { nullptr };
	};
}
