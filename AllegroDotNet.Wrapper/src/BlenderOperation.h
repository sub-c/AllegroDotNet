#pragma once

#include "PCH.h"

namespace AllegroDotNet::Wrapper
{
	using namespace System;

	public enum class BlenderOperation : Int32
	{
		Add = ALLEGRO_ADD,
		DestMinusSrc = ALLEGRO_DEST_MINUS_SRC,
		SrcMinusDest = ALLEGRO_SRC_MINUS_DEST
	};
}
