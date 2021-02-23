#include "PCH.h"

#include "Al.h"
#include "AllegroEvent.h"
#include "AllegroEventQueue.h"
#include "AllegroEventSource.h"
#include "AllegroTimeout.h"
#include "AllegroUserEvent.h"

namespace AllegroDotNet::Wrapper
{
	AllegroEventQueue^ Al::CreateEventQueue()
	{
		auto* nativeEventQueue = al_create_event_queue();
		return gcnew AllegroEventQueue(nativeEventQueue);
	}

	Boolean Al::DropNextEvent(AllegroEventQueue^ queue)
	{
		auto* nativeEventQueue = queue->GetNativePointer();
		return al_drop_next_event(nativeEventQueue);
	}

	Boolean Al::EmitUserEvent(AllegroEventSource^ source, AllegroEvent^ event, Action<AllegroUserEvent^>^ dtor)
	{
		return false;
	}

	Boolean Al::GetNextEvent(AllegroEventQueue^ queue, AllegroEvent^ retEvent)
	{
		auto* nativeEventQueue = queue->GetNativePointer();
		auto* nativeEvent = retEvent->GetNativePointer();
		return al_get_next_event(nativeEventQueue, nativeEvent);
	}

	Boolean Al::IsEventQueueEmpty(AllegroEventQueue^ queue)
	{
		auto* nativeEventQueue = queue->GetNativePointer();
		return al_is_event_queue_empty(nativeEventQueue);
	}

	Boolean Al::IsEventQueuePaused(AllegroEventQueue^ queue)
	{
		auto* nativeEventQueue = queue->GetNativePointer();
		return al_is_event_queue_paused(nativeEventQueue);
	}

	Boolean Al::IsEventSourceRegistered(AllegroEventQueue^ queue, AllegroEventSource^ source)
	{
		auto* nativeEventQueue = queue->GetNativePointer();
		auto* nativeEventSource = source->GetNativePointer();
		return al_is_event_source_registered(nativeEventQueue, nativeEventSource);
	}

	Boolean Al::PeekNextEvent(AllegroEventQueue^ queue, AllegroEvent^ retEvent)
	{
		auto* nativeEventQueue = queue->GetNativePointer();
		auto* nativeEvent = retEvent->GetNativePointer();
		return al_peek_next_event(nativeEventQueue, nativeEvent);
	}

	Boolean Al::WaitForEventTimed(AllegroEventQueue^ queue, AllegroEvent^ retEvent, Single secs)
	{
		auto* nativeEventQueue = queue->GetNativePointer();
		auto* nativeEvent = retEvent->GetNativePointer();
		return al_wait_for_event_timed(nativeEventQueue, nativeEvent, secs);
	}

	Boolean Al::WaitForEventUntil(AllegroEventQueue^ queue, AllegroEvent^ retEvent, AllegroTimeout^ timeout)
	{
		auto* nativeEventQueue = queue->GetNativePointer();
		auto* nativeEvent = retEvent->GetNativePointer();
		auto* nativeTimeout = timeout->GetNativePointer();
		return al_wait_for_event_until(nativeEventQueue, nativeEvent, nativeTimeout);
	}

	Object^ Al::GetEventSourceData(AllegroEventSource^ source)
	{
		return source->Data;
	}

	void Al::DestroyEventQueue(AllegroEventQueue^ queue)
	{
		auto* nativeEventQueue = queue->GetNativePointer();
		al_destroy_event_queue(nativeEventQueue);
	}

	void Al::DestroyUserEventSource(AllegroEventSource^ source)
	{
		auto* nativeEventSource = source->GetNativePointer();
		al_destroy_user_event_source(nativeEventSource);
	}

	void Al::FlushEventQueue(AllegroEventQueue^ queue)
	{
		auto* nativeEventQueue = queue->GetNativePointer();
		al_flush_event_queue(nativeEventQueue);
	}

	void Al::InitUserEventSource(AllegroEventSource^ source)
	{
		auto* nativeEventSource = source->GetNativePointer();
		al_init_user_event_source(nativeEventSource);
	}

	void Al::PauseEventQueue(AllegroEventQueue^ queue, Boolean pause)
	{
		auto* nativeEventQueue = queue->GetNativePointer();
		al_pause_event_queue(nativeEventQueue, pause);
	}

	void Al::RegisterEventSource(AllegroEventQueue^ queue, AllegroEventSource^ source)
	{
		auto* nativeEventQueue = queue->GetNativePointer();
		auto* nativeEventSource = source->GetNativePointer();
		al_register_event_source(nativeEventQueue, nativeEventSource);
	}

	void Al::SetEventSourceData(AllegroEventSource^ source, Object^ data)
	{
		source->Data = data;
	}

	void Al::UnrefUserEvent(AllegroUserEvent^ userEvent)
	{
	}

	void Al::UnregisterEventSource(AllegroEventQueue^ queue, AllegroEventSource^ source)
	{
		auto* nativeEventQueue = queue->GetNativePointer();
		auto* nativeEventSource = source->GetNativePointer();
		al_unregister_event_source(nativeEventQueue, nativeEventSource);
	}

	void Al::WaitForEvent(AllegroEventQueue^ queue, AllegroEvent^ retEvent)
	{
		auto* nativeEventQueue = queue->GetNativePointer();
		auto* nativeRetEvent = retEvent->GetNativePointer();
		al_wait_for_event(nativeEventQueue, nativeRetEvent);
	}
}
