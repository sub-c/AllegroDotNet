#pragma once

#include "PCH.h"

namespace AllegroDotNet::Wrapper
{
	using namespace System;

	public enum class BitmapLoadFlags : Int32
	{
		KeepBitmapFormat = ALLEGRO_KEEP_BITMAP_FORMAT,
		KeepIndex = ALLEGRO_KEEP_INDEX,
		NoPremultipliedAlpha = ALLEGRO_NO_PREMULTIPLIED_ALPHA
	};
}
