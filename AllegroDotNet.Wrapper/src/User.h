#pragma once

#include "PCH.h"

namespace AllegroDotNet::Wrapper
{
	public ref class User
	{
	public:

	internal:
		User(ALLEGRO_EVENT* nativeSourceEvent)
		{
			nativeSourceEvent_ = nativeSourceEvent;
		}

	private:
		ALLEGRO_EVENT* nativeSourceEvent_ { nullptr };
	};
}
