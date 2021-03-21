#pragma once

#include "PCH.h"

namespace AllegroDotNet::Wrapper
{
	using namespace System;

	public enum class LockFlags : Int32
	{
		ReadOnly = ALLEGRO_LOCK_READONLY,
		ReadWrite = ALLEGRO_LOCK_READWRITE,
		WriteOnly = ALLEGRO_LOCK_WRITEONLY
	};
}
