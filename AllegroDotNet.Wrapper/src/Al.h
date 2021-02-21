#pragma once

namespace AllegroDotNet::Wrapper
{
	enum class StandardPath;
	enum class SystemID;

	ref class AllegroBitmap;
	ref class AllegroConfig;
	ref class AllegroDisplay;
	ref class AllegroKeyboardState;
	ref class AllegroPath;

	using namespace System;

	public ref class Al
	{
	public:
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
	};
}
