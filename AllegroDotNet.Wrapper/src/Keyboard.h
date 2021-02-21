#pragma once

#include "PCH.h"

namespace AllegroDotNet::Wrapper
{
	public ref class Keyboard
	{
	public:

	internal:
		Keyboard(ALLEGRO_EVENT* nativeSourceEvent)
		{
			nativeSourceEvent_ = nativeSourceEvent;
		}

	private:
		ALLEGRO_EVENT* nativeSourceEvent_ { nullptr };
	};
}
