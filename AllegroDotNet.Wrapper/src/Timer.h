#pragma once

#include "PCH.h"

#include "AllegroTimer.h"

namespace AllegroDotNet::Wrapper
{
	public ref class Timer
	{
	public:
		property Int64 Count
		{
			Int64 get()
			{
				return nativeSourceEvent_->timer.count;
			}
		}

		property AllegroTimer^ Source
		{
			AllegroTimer^ get()
			{
				managedTimer_->SetNativePointer(nativeSourceEvent_->timer.source);
				return managedTimer_;
			}
		}

	internal:
		Timer(ALLEGRO_EVENT* nativeSourceEvent)
		{
			nativeSourceEvent_ = nativeSourceEvent;
		}

	private:
		AllegroTimer^ managedTimer_ { gcnew AllegroTimer(nullptr) };
		ALLEGRO_EVENT* nativeSourceEvent_ { nullptr };
	};
}
