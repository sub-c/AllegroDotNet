#include "PCH.h"

#include "Al.h"
#include "AllegroTimeout.h"

namespace AllegroDotNet::Wrapper
{
	Double Al::GetTime()
	{
		return al_get_time();
	}

	void Al::InitTimeout(AllegroTimeout^ timeout, Double seconds)
	{
		auto* nativeTimeout = timeout->GetNativePointer();
		al_init_timeout(nativeTimeout, seconds);
	}

	void Al::Rest(Double seconds)
	{
		al_rest(seconds);
	}
}
