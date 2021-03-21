#pragma once

#include "PCH.h"

namespace AllegroDotNet::Wrapper
{
	using namespace System;

	public enum class BitmapFlip : Int32
	{
		Horizontal = ALLEGRO_FLIP_HORIZONTAL,
		Vertical = ALLEGRO_FLIP_VERTICAL
	};
}
