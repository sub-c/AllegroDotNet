#include "PCH.h"

#include "Al.h"
#include "AllegroConfig.h"
#include "AllegroConfigEntry.h"
#include "AllegroConfigSection.h"
#include "AllegroFile.h"

#include <msclr/marshal.h>

namespace AllegroDotNet::Wrapper
{
	using namespace msclr::interop;

	AllegroConfig^ Al::CreateConfig()
	{
		auto* nativeConfig = al_create_config();
		return gcnew AllegroConfig(nativeConfig);
	}

	AllegroConfig^ Al::LoadConfigFile(String^ filename)
	{
		marshal_context marshalContext;
		const auto* nativeFilename = marshalContext.marshal_as<const char*>(filename);
		auto* nativeConfig = al_load_config_file(nativeFilename);
		return gcnew AllegroConfig(nativeConfig);
	}

	AllegroConfig^ Al::LoadConfigFileF(AllegroFile^ file)
	{
		auto* nativeFile = file->GetNativePointer();
		auto* nativeConfig = al_load_config_file_f(nativeFile);
		return gcnew AllegroConfig(nativeConfig);
	}

	AllegroConfig^ Al::MergeConfig(AllegroConfig^ config1, AllegroConfig^ config2)
	{
		auto* nativeConfig1 = config1->GetNativePointer();
		auto* nativeConfig2 = config2->GetNativePointer();
		auto* nativeReturnedConfig = al_merge_config(nativeConfig1, nativeConfig2);
		return gcnew AllegroConfig(nativeReturnedConfig);
	}

	Boolean Al::RemoveConfigKey(AllegroConfig^ config, String^ section, String^ key)
	{
		auto* nativeConfig = config->GetNativePointer();
		marshal_context marshalContext;
		const auto* nativeSection = marshalContext.marshal_as<const char*>(section);
		const auto* nativeKey = marshalContext.marshal_as<const char*>(key);
		return al_remove_config_key(nativeConfig, nativeSection, nativeKey);
	}

	Boolean Al::RemoveConfigSection(AllegroConfig^ config, String^ section)
	{
		auto* nativeConfig = config->GetNativePointer();
		marshal_context marshalContext;
		const auto* nativeSection = marshalContext.marshal_as<const char*>(section);
		return al_remove_config_section(nativeConfig, nativeSection);
	}

	Boolean Al::SaveConfigFile(String^ filename, AllegroConfig^ config)
	{
		marshal_context marshalContext;
		const auto* nativeFilename = marshalContext.marshal_as<const char*>(filename);
		auto* nativeConfig = config->GetNativePointer();
		return al_save_config_file(nativeFilename, nativeConfig);
	}

	Boolean Al::SaveConfigFileF(AllegroFile^ file, AllegroConfig^ config)
	{
		auto* nativeFile = file->GetNativePointer();
		auto* nativeConfig = config->GetNativePointer();
		return al_save_config_file_f(nativeFile, nativeConfig);
	}

	String^ Al::GetConfigValue(AllegroConfig^ config, String^ section, String^ key)
	{
		auto* nativeConfig = config->GetNativePointer();
		marshal_context marshalContext;
		const auto* nativeSection = marshalContext.marshal_as<const char*>(section);
		const auto* nativeKey = marshalContext.marshal_as<const char*>(key);
		const auto* nativeReturnValue = al_get_config_value(nativeConfig, nativeSection, nativeKey);
		return gcnew String(nativeReturnValue);
	}

	String^ Al::GetFirstConfigEntry(AllegroConfig^ config, String^ section, [OutAttribute] AllegroConfigEntry^% iterator)
	{
		auto* nativeConfig = config->GetNativePointer();
		marshal_context marshalContext;
		const auto* nativeSection = marshalContext.marshal_as<const char*>(section);
		ALLEGRO_CONFIG_ENTRY* nativeConfigEntry;
		const auto* nativeReturnValue = al_get_first_config_entry(nativeConfig, nativeSection, &nativeConfigEntry);
		iterator = gcnew AllegroConfigEntry(nativeConfigEntry);
		return gcnew String(nativeReturnValue);
	}

	String^ Al::GetFirstConfigSection(AllegroConfig^ config, [OutAttribute] AllegroConfigSection^% iterator)
	{
		auto* nativeConfig = config->GetNativePointer();
		ALLEGRO_CONFIG_SECTION* nativeIterator;
		const auto* nativeReturnValue = al_get_first_config_section(nativeConfig, &nativeIterator);
		iterator = gcnew AllegroConfigSection(nativeIterator);
		return gcnew String(nativeReturnValue);
	}

	String^ Al::GetNextConfigEntry(AllegroConfigEntry^ iterator)
	{
		auto* nativeIterator = iterator->GetNativePointer();
		const auto* nativeReturnValue = al_get_next_config_entry(&nativeIterator);
		return gcnew String(nativeReturnValue);
	}

	String^ Al::GetNextConfigSection(AllegroConfigSection^ iterator)
	{
		auto* nativeIterator = iterator->GetNativePointer();
		const auto* nativeReturnValue = al_get_next_config_section(&nativeIterator);
		return gcnew String(nativeReturnValue);
	}

	void Al::AddConfigComment(AllegroConfig^ config, String^ section, String^ comment)
	{
		auto* nativeConfig = config->GetNativePointer();
		marshal_context marshalContext;
		const auto* nativeSection = marshalContext.marshal_as<const char*>(section);
		const auto* nativeComment = marshalContext.marshal_as<const char*>(comment);
		al_add_config_comment(nativeConfig, nativeSection, nativeComment);
	}

	void Al::AddConfigSection(AllegroConfig^ config, String^ name)
	{
		auto* nativeConfig = config->GetNativePointer();
		marshal_context marshalContext;
		const auto* nativeName = marshalContext.marshal_as<const char*>(name);
		al_add_config_section(nativeConfig, nativeName);
	}

	void Al::DestroyConfig(AllegroConfig^ config)
	{
		auto* nativeConfig = config->GetNativePointer();
		al_destroy_config(nativeConfig);

	}

	void Al::MergeConfigInto(AllegroConfig^ master, AllegroConfig^ add)
	{
		auto* nativeMaster = master->GetNativePointer();
		auto* nativeAdd = add->GetNativePointer();
		al_merge_config_into(nativeMaster, nativeAdd);

	}

	void Al::SetConfigValue(AllegroConfig^ config, String^ section, String^ key, String^ value)
	{
		auto* nativeConfig = config->GetNativePointer();
		marshal_context marshalContext;
		const auto* nativeSection = marshalContext.marshal_as<const char*>(section);
		const auto* nativeKey = marshalContext.marshal_as<const char*>(key);
		const auto* nativeValue = marshalContext.marshal_as<const char*>(value);
		al_set_config_value(nativeConfig, nativeSection, nativeKey, nativeValue);

	}
}
