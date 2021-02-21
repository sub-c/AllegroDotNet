#pragma once

#include "PCH.h"

namespace AllegroDotNet::Wrapper
{
	using namespace System;

	[System::FlagsAttribute]
	public enum class KeyModFlags : Int32
	{
		Accent1 = ALLEGRO_KEYMOD_ACCENT1,
		Accent2 = ALLEGRO_KEYMOD_ACCENT2,
		Accent3 = ALLEGRO_KEYMOD_ACCENT3,
		Accent4 = ALLEGRO_KEYMOD_ACCENT4,
		Alt = ALLEGRO_KEYMOD_ALT,
		AltGr = ALLEGRO_KEYMOD_ALTGR,
		CapsLock = ALLEGRO_KEYMOD_CAPSLOCK,
		Command = ALLEGRO_KEYMOD_COMMAND,
		Ctrl = ALLEGRO_KEYMOD_CTRL,
		InAltSeq = ALLEGRO_KEYMOD_INALTSEQ,
		LWin = ALLEGRO_KEYMOD_LWIN,
		Menu = ALLEGRO_KEYMOD_MENU,
		NumLock = ALLEGRO_KEYMOD_NUMLOCK,
		RWin = ALLEGRO_KEYMOD_RWIN,
		ScrollLock = ALLEGRO_KEYMOD_SCROLLLOCK,
		Shift = ALLEGRO_KEYMOD_SHIFT,
	};
}
