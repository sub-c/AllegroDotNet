#include "PCH.h"

#include "Al.h"
#include "AllegroDisplay.h"
#include "AllegroEventSource.h"
#include "AllegroKeyboardState.h"
#include "KeyCode.h"
#include "KeyModFlags.h"

namespace AllegroDotNet::Wrapper
{
	AllegroEventSource^ Al::GetKeyboardEventSource()
	{
		auto* nativeEventSource = al_get_keyboard_event_source();
		return gcnew AllegroEventSource(nativeEventSource);
	}

	Boolean Al::InstallKeyboard()
	{
		return al_install_keyboard();
	}

	Boolean Al::IsKeyboardInstalled()
	{
		return al_is_keyboard_installed();
	}

	Boolean Al::KeyDown(AllegroKeyboardState^ state, KeyCode keyCode)
	{
		auto* nativeState = state->GetNativePointer();
		auto nativeKeyCode = static_cast<int>(keyCode);
		return al_key_down(nativeState, nativeKeyCode);
	}

	Boolean Al::SetKeyboardLeds(KeyModFlags leds)
	{
		auto nativeLeds = static_cast<int>(leds);
		return al_set_keyboard_leds(nativeLeds);
	}

	String^ Al::KeyCodeToName(KeyCode keyCode)
	{
		auto nativeKeyCode = static_cast<int>(keyCode);
		const auto* nativeReturnValue = al_keycode_to_name(nativeKeyCode);
		return gcnew String(nativeReturnValue);
	}

	void Al::GetKeyboardState(AllegroKeyboardState^ retState)
	{
		auto* nativeKeyboardState = retState->GetNativePointer();
		al_get_keyboard_state(nativeKeyboardState);
	}

	void Al::UninstallKeyboard()
	{
		al_uninstall_keyboard();
	}
}
