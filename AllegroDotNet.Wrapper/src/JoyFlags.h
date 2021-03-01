#pragma once

#include "PCH.h"

namespace AllegroDotNet::Wrapper
{
	using namespace System;

	public enum class JoyFlags : Int32
	{
		Analogue = ALLEGRO_JOYFLAG_ANALOGUE,
		Digital = ALLEGRO_JOYFLAG_DIGITAL
	};
}
