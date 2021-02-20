#include "PCH.h"

#include "Al.h"
#include "AllegroConfig.h"
#include "AllegroPath.h"
#include "AlNative.h"
#include "SystemID.h"

#include <msclr/marshal.h>

namespace AllegroDotNet::Wrapper
{
	using namespace msclr::interop;

	AllegroConfig^ Al::GetSystemConfig()
	{
		auto* nativeSystemConfig = al_get_system_config();
		return gcnew AllegroConfig(nativeSystemConfig);
	}

	AllegroPath^ Al::GetStandardPath(StandardPath id)
	{
		auto nativeId = (int)id;
		auto* nativePath = al_get_standard_path(nativeId);
		return gcnew AllegroPath(nativePath);
	}

	Boolean Al::Init()
	{
		return al_init();
	}

	Boolean Al::IsSystemInstalled()
	{
		return al_is_system_installed();
	}

	Int32 Al::GetCpuCount()
	{
		return al_get_cpu_count();
	}

	Int32 Al::GetRamSize()
	{
		return al_get_ram_size();
	}

	String^ Al::GetAppName()
	{
		auto* nativeAppName = al_get_app_name();
		return gcnew String(nativeAppName);
	}

	String^ Al::GetOrgName()
	{
		auto* nativeOrgName = al_get_org_name();
		return gcnew String(nativeOrgName);
	}

	SystemID Al::GetSystemID()
	{
		auto nativeSystemID = al_get_system_id();
		return (SystemID)nativeSystemID;
	}

	UInt32 Al::GetAllegroVersion()
	{
		return al_get_allegro_version();
	}

	void Al::RegisterAssertHandler(Action<String^, String^, Int32, String^>^ handler)
	{
		ManagedAssertHandler = handler;
		if (handler == nullptr)
		{
			al_register_assert_handler(nullptr);
		}
		else
		{
			al_register_assert_handler(AlNative::native_assert_handler);
		}
	}

	void Al::RegisterTraceHandler(Action<String^>^ handler)
	{
		ManagedTraceHandler = handler;
		if (handler == nullptr)
		{
			al_register_trace_handler(nullptr);
		}
		else
		{
			al_register_trace_handler(AlNative::native_trace_handler);
		}
	}

	void Al::SetAppName(String^ name)
	{
		marshal_context marshalContext;
		const auto* nativeAppName = marshalContext.marshal_as<const char*>(name);
		al_set_app_name(nativeAppName);
	}

	void Al::SetExeName(String^ name)
	{
		marshal_context marshalContext;
		const auto* nativeExeName = marshalContext.marshal_as<const char*>(name);
		al_set_app_name(nativeExeName);
	}

	void Al::SetOrgName(String^ name)
	{
		marshal_context marshalContext;
		const auto* nativeOrgName = marshalContext.marshal_as<const char*>(name);
		al_set_org_name(nativeOrgName);
	}

	void Al::UninstallSystem()
	{
		al_uninstall_system();
	}
}