#pragma once

#include "PCH.h"

namespace AllegroDotNet::Wrapper
{
	using namespace System;

	public enum class RenderFunction : Int32
	{
		Always = ALLEGRO_RENDER_ALWAYS,
		Equal = ALLEGRO_RENDER_EQUAL,
		Greater = ALLEGRO_RENDER_GREATER,
		GreaterEqual = ALLEGRO_RENDER_GREATER_EQUAL,
		Less = ALLEGRO_RENDER_LESS,
		LessEqual = ALLEGRO_RENDER_LESS_EQUAL,
		Never = ALLEGRO_RENDER_NEVER,
		NotEqual = ALLEGRO_RENDER_NOT_EQUAL
	};
}

