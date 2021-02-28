#pragma once

#include "PCH.h"

namespace AllegroDotNet::Wrapper
{
	using namespace System;

	public enum class Importance : Int32
	{
		DontCare = ALLEGRO_DONTCARE,
		Require = ALLEGRO_REQUIRE,
		Suggest = ALLEGRO_SUGGEST
	};
}
