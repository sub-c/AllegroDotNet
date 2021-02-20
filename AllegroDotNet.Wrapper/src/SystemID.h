#pragma once

#include "PCH.h"

namespace AllegroDotNet::Wrapper
{
	using namespace System;

	public enum class SystemID : Int32
	{
		Android = ALLEGRO_SYSTEM_ID_ANDROID,
		GP2XWIZ = ALLEGRO_SYSTEM_ID_GP2XWIZ,
		IOS = ALLEGRO_SYSTEM_ID_IPHONE,
		MacOSX = ALLEGRO_SYSTEM_ID_MACOSX,
		RaspberryPi = ALLEGRO_SYSTEM_ID_RASPBERRYPI,
		Sdl = ALLEGRO_SYSTEM_ID_SDL,
		Unknown = ALLEGRO_SYSTEM_ID_UNKNOWN,
		Windows = ALLEGRO_SYSTEM_ID_WINDOWS,
		Xglx = ALLEGRO_SYSTEM_ID_XGLX
	};
}
