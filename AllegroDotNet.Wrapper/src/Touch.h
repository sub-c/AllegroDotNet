#pragma once

#include "PCH.h"

namespace AllegroDotNet::Wrapper
{
	public ref class Touch
	{
	public:

	internal:
		Touch(ALLEGRO_EVENT* nativeSourceEvent)
		{
			nativeSourceEvent_ = nativeSourceEvent;
		}

	private:
		ALLEGRO_EVENT* nativeSourceEvent_ { nullptr };
	};
}
