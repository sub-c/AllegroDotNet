#pragma once

#include "PCH.h"

namespace AllegroDotNet::Wrapper
{
	using namespace System;

	public enum class BlenderFactor : Int32
	{
		Alpha = ALLEGRO_ALPHA,
		ConstColor = ALLEGRO_CONST_COLOR,
		DestColor = ALLEGRO_DEST_COLOR,
		InverseAlpha = ALLEGRO_INVERSE_ALPHA,
		InverseConstColor = ALLEGRO_INVERSE_CONST_COLOR,
		InverseDestColor = ALLEGRO_INVERSE_DEST_COLOR,
		InverseSrcColor = ALLEGRO_INVERSE_SRC_COLOR,
		One = ALLEGRO_ONE,
		SrcColor = ALLEGRO_SRC_COLOR,
		Zero = ALLEGRO_ZERO
	};
}
