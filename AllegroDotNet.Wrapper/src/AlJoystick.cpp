#include "PCH.h"

#include "Al.h"
#include "AllegroEventSource.h"
#include "AllegroJoystick.h"
#include "AllegroJoystickState.h"
#include "JoyFlags.h"

namespace AllegroDotNet::Wrapper
{
	AllegroEventSource^ Al::GetJoystickEventSource()
	{
		auto* nativeEventSource = al_get_joystick_event_source();
		return gcnew AllegroEventSource(nativeEventSource);
	}

	AllegroJoystick^ Al::GetJoystick(Int32 num)
	{
		auto* nativeReturnValue = al_get_joystick(num);
		return gcnew AllegroJoystick(nativeReturnValue);
	}

	Boolean Al::GetJoystickActive(AllegroJoystick^ joy)
	{
		auto* nativeJoy = joy->GetNativePointer();
		return al_get_joystick_active(nativeJoy);
	}

	Boolean Al::InstallJoystick()
	{
		return al_install_joystick();
	}

	Boolean Al::IsJoystickInstalled()
	{
		return al_is_joystick_installed();
	}

	Boolean Al::ReconfigureJoysticks()
	{
		return al_reconfigure_joysticks();
	}

	Int32 Al::GetJoystickNumAxes(AllegroJoystick^ joy, Int32 stick)
	{
		auto* nativeJoy = joy->GetNativePointer();
		return al_get_joystick_num_axes(nativeJoy, stick);
	}

	Int32 Al::GetJoystickNumButtons(AllegroJoystick^ joy)
	{
		auto* nativeJoy = joy->GetNativePointer();
		return al_get_joystick_num_buttons(nativeJoy);
	}

	Int32 Al::GetJoystickNumSticks(AllegroJoystick^ joy)
	{
		auto* nativeJoy = joy->GetNativePointer();
		return al_get_joystick_num_sticks(nativeJoy);
	}

	Int32 Al::GetNumJoysticks()
	{
		return al_get_num_joysticks();
	}

	JoyFlags Al::GetJoystickStickFlags(AllegroJoystick^ joy, Int32 stick)
	{
		auto* nativeJoy = joy->GetNativePointer();
		auto nativeFlags = al_get_joystick_stick_flags(nativeJoy, stick);
		return static_cast<JoyFlags>(nativeFlags);
	}

	String^ Al::GetJoystickAxisName(AllegroJoystick^ joy, Int32 stick, Int32 axis)
	{
		auto* nativeJoy = joy->GetNativePointer();
		const auto* nativeReturnValue = al_get_joystick_axis_name(nativeJoy, stick, axis);
		return gcnew String(nativeReturnValue);
	}

	String^ Al::GetJoystickButtonName(AllegroJoystick^ joy, Int32 button)
	{
		auto* nativeJoy = joy->GetNativePointer();
		const auto* nativeReturnValue = al_get_joystick_button_name(nativeJoy, button);
		return gcnew String(nativeReturnValue);
	}

	String^ Al::GetJoystickName(AllegroJoystick^ joy)
	{
		auto* nativeJoy = joy->GetNativePointer();
		const auto* nativeReturnValue = al_get_joystick_name(nativeJoy);
		return gcnew String(nativeReturnValue);
	}

	String^ Al::GetJoystickStickName(AllegroJoystick^ joy, Int32 stick)
	{
		auto* nativeJoy = joy->GetNativePointer();
		const auto* nativeReturnValue = al_get_joystick_stick_name(nativeJoy, stick);
		return gcnew String(nativeReturnValue);
	}

	void Al::GetJoystickState(AllegroJoystick^ joy, AllegroJoystickState^ retState)
	{
		auto* nativeJoy = joy->GetNativePointer();
		auto* nativeRetState = retState->GetNativePointer();
		al_get_joystick_state(nativeJoy, nativeRetState);
	}

	void Al::ReleaseJoystick(AllegroJoystick^ joy)
	{
		auto* nativeJoy = joy->GetNativePointer();
		al_release_joystick(nativeJoy);
	}

	void Al::UninstallJoystick()
	{
		al_uninstall_joystick();
	}
}
