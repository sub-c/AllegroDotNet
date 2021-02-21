#pragma once

#include "PCH.h"

namespace AllegroDotNet::Wrapper
{
	public ref class Mouse
	{
	public:

	internal:
		Mouse(ALLEGRO_EVENT* nativeSourceEvent)
		{
			nativeSourceEvent_ = nativeSourceEvent;
		}

	private:
		ALLEGRO_EVENT* nativeSourceEvent_ { nullptr };
	};
}
