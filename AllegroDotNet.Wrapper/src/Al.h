#pragma once

namespace AllegroDotNet::Wrapper
{
	enum class StandardPath;
	enum class SystemID;

	ref class AllegroBitmap;
	ref class AllegroConfig;
	ref class AllegroDisplay;
	ref class AllegroEvent;
	ref class AllegroEventQueue;
	ref class AllegroEventSource;
	ref class AllegroKeyboardState;
	ref class AllegroPath;
	ref class AllegroTimeout;
	ref class AllegroTimer;
	ref class AllegroUserEvent;

	using namespace System;

	public ref class Al sealed
	{
	public:
		// Event system and events - AlEvent.cpp
		static AllegroEventQueue^ CreateEventQueue();
		static Boolean DropNextEvent(AllegroEventQueue^ queue);
		static Boolean EmitUserEvent(AllegroEventSource^ source, AllegroEvent^ event, Action<AllegroUserEvent^>^ dtor);
		static Boolean GetNextEvent(AllegroEventQueue^ queue, AllegroEvent^ retEvent);
		static Boolean IsEventQueueEmpty(AllegroEventQueue^ queue);
		static Boolean IsEventQueuePaused(AllegroEventQueue^ queue);
		static Boolean IsEventSourceRegistered(AllegroEventQueue^ queue, AllegroEventSource^ source);
		static Boolean PeekNextEvent(AllegroEventQueue^ queue, AllegroEvent^ retEvent);
		static Boolean WaitForEventTimed(AllegroEventQueue^ queue, AllegroEvent^ retEvent, Single secs);
		static Boolean WaitForEventUntil(AllegroEventQueue^ queue, AllegroEvent^ retEvent, AllegroTimeout^ timeout);
		static Object^ GetEventSourceData(AllegroEventSource^ source);
		static void DestroyEventQueue(AllegroEventQueue^ queue);
		static void DestroyUserEventSource(AllegroEventSource^ source);
		static void FlushEventQueue(AllegroEventQueue^ queue);
		static void InitUserEventSource(AllegroEventSource^ source);
		static void PauseEventQueue(AllegroEventQueue^ queue, Boolean pause);
		static void RegisterEventSource(AllegroEventQueue^ queue, AllegroEventSource^ source);
		static void SetEventSourceData(AllegroEventSource^ source, Object^ data);
		static void UnrefUserEvent(AllegroUserEvent^ userEvent);
		static void UnregisterEventSource(AllegroEventQueue^ queue, AllegroEventSource^ source);
		static void WaitForEvent(AllegroEventQueue^ queue, AllegroEvent^ retEvent);

		// System - AlSystem.cpp
		static AllegroConfig^ GetSystemConfig();
		static AllegroPath^ GetStandardPath(StandardPath id);
		static Boolean Init();
		static Boolean IsSystemInstalled();
		static Int32 GetCpuCount();
		static Int32 GetRamSize();
		static String^ GetAppName();
		static String^ GetOrgName();
		static SystemID GetSystemID();
		static UInt32 GetAllegroVersion();
		static void RegisterAssertHandler(Action<String^, String^, Int32, String^>^ handler);
		static void RegisterTraceHandler(Action<String^>^ handler);
		static void SetAppName(String^ name);
		static void SetExeName(String^ name);
		static void SetOrgName(String^ name);
		static void UninstallSystem();

		static Action<String^, String^, Int32, String^>^ ManagedAssertHandler = nullptr;
		static Action<String^>^ ManagedTraceHandler = nullptr;

		// Timer routines - AlTimer.cpp
		static AllegroEventSource^ GetTimerEventSource(AllegroTimer^ timer);
		static AllegroTimer^ CreateTimer(Double speedSecs);
		static Boolean GetTimerStarted(AllegroTimer^ timer);
		static Double BpmToSecs(Double bpm);
		static Double BpsToSecs(Double bps);
		static Double GetTimerSpeed(AllegroTimer^ timer);
		static Double MSecsToSecs(Double mSecs);
		static Double USecsToSecs(Double uSecs);
		static Int64 GetTimerCount(AllegroTimer^ timer);
		static void AddTimerCount(AllegroTimer^ timer, Int64 diff);
		static void DestroyTimer(AllegroTimer^ timer);
		static void ResumeTimer(AllegroTimer^ timer);
		static void SetTimerCount(AllegroTimer^ timer, Int64 newCount);
		static void SetTimerSpeed(AllegroTimer^ timer, Double newSpeedSecs);
		static void StartTimer(AllegroTimer^ timer);
		static void StopTimer(AllegroTimer^ timer);
	};
}
