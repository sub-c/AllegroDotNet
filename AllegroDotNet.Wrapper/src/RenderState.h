#pragma once

#include "PCH.h"

namespace AllegroDotNet::Wrapper
{
	using namespace System;

	public enum class RenderState
	{
		AlphaFunction = ALLEGRO_ALPHA_FUNCTION,
		AlphaTest = ALLEGRO_ALPHA_TEST,
		AlphaTestValue = ALLEGRO_ALPHA_TEST_VALUE,
		DepthFunction = ALLEGRO_DEPTH_FUNCTION,
		DepthTest = ALLEGRO_DEPTH_TEST,
		WriteMask = ALLEGRO_WRITE_MASK
	};
}
