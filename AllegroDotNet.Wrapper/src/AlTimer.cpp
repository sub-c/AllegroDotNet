#include "PCH.h"

#include "Al.h"
#include "AllegroEventSource.h"
#include "AllegroTimer.h"

namespace AllegroDotNet::Wrapper
{
	AllegroEventSource^ Al::GetTimerEventSource(AllegroTimer^ timer)
	{
		auto* nativeTimer = timer->GetNativePointer();
		auto* nativeTimerEventSource = al_get_timer_event_source(nativeTimer);
		return gcnew AllegroEventSource(nativeTimerEventSource);
	}

	AllegroTimer^ Al::CreateTimer(Double speedSecs)
	{
		auto* nativeTimer = al_create_timer(speedSecs);
		return gcnew AllegroTimer(nativeTimer);
	}

	Boolean Al::GetTimerStarted(AllegroTimer^ timer)
	{
		auto* nativeTimer = timer->GetNativePointer();
		return al_get_timer_started(nativeTimer);
	}

	Double Al::BpmToSecs(Double bpm)
	{
		return ALLEGRO_BPM_TO_SECS(bpm);
	}

	Double Al::BpsToSecs(Double bps)
	{
		return ALLEGRO_BPS_TO_SECS(bps);
	}

	Double Al::GetTimerSpeed(AllegroTimer^ timer)
	{
		auto* nativeTimer = timer->GetNativePointer();
		return al_get_timer_speed(nativeTimer);
	}

	Double Al::MSecsToSecs(Double mSecs)
	{
		return ALLEGRO_MSECS_TO_SECS(mSecs);
	}

	Double Al::USecsToSecs(Double uSecs)
	{
		return ALLEGRO_USECS_TO_SECS(uSecs);
	}

	Int64 Al::GetTimerCount(AllegroTimer^ timer)
	{
		auto* nativeTimer = timer->GetNativePointer();
		return al_get_timer_count(nativeTimer);
	}

	void Al::AddTimerCount(AllegroTimer^ timer, Int64 diff)
	{
		auto* nativeTimer = timer->GetNativePointer();
		al_add_timer_count(nativeTimer, diff);
	}

	void Al::DestroyTimer(AllegroTimer^ timer)
	{
		auto* nativeTimer = timer->GetNativePointer();
		al_destroy_timer(nativeTimer);
	}

	void Al::ResumeTimer(AllegroTimer^ timer)
	{
		auto* nativeTimer = timer->GetNativePointer();
		al_resume_timer(nativeTimer);
	}

	void Al::SetTimerCount(AllegroTimer^ timer, Int64 newCount)
	{
		auto* nativeTimer = timer->GetNativePointer();
		al_set_timer_count(nativeTimer, newCount);
	}

	void Al::SetTimerSpeed(AllegroTimer^ timer, Double newSpeedSecs)
	{
		auto* nativeTimer = timer->GetNativePointer();
		al_set_timer_speed(nativeTimer, newSpeedSecs);
	}

	void Al::StartTimer(AllegroTimer^ timer)
	{
		auto* nativeTimer = timer->GetNativePointer();
		al_start_timer(nativeTimer);
	}

	void Al::StopTimer(AllegroTimer^ timer)
	{
		auto* nativeTimer = timer->GetNativePointer();
		al_stop_timer(nativeTimer);
	}
}
