#pragma once

#include "PCH.h"

namespace AllegroDotNet::Wrapper
{
	using namespace System;

	public enum class DisplayOrientation : Int32
	{
		Orientation0Degrees = ALLEGRO_DISPLAY_ORIENTATION_0_DEGREES,
		Orientation180Degrees = ALLEGRO_DISPLAY_ORIENTATION_180_DEGREES,
		Orientation270Degrees = ALLEGRO_DISPLAY_ORIENTATION_270_DEGREES,
		Orientation90Degrees = ALLEGRO_DISPLAY_ORIENTATION_90_DEGREES,
		OrientationFaceDown = ALLEGRO_DISPLAY_ORIENTATION_FACE_DOWN,
		OrientationFaceUp = ALLEGRO_DISPLAY_ORIENTATION_FACE_UP,
		OrientationUnknown = ALLEGRO_DISPLAY_ORIENTATION_UNKNOWN,
	};
}
