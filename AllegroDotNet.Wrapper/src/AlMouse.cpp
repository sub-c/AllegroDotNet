#include "PCH.h"

#include "Al.h"
#include "AllegroBitmap.h"
#include "AllegroDisplay.h"
#include "AllegroEventSource.h"
#include "AllegroMouseCursor.h"
#include "AllegroMouseState.h"

namespace AllegroDotNet::Wrapper
{
	AllegroEventSource^ Al::GetMouseEventSource()
	{
		auto* nativeEventSource = al_get_mouse_event_source();
		return gcnew AllegroEventSource(nativeEventSource);
	}

	AllegroMouseCursor^ Al::CreateMouseCursor(AllegroBitmap^ bmp, Int32 xFocus, Int32 yFocus)
	{
		auto* nativeBmp = bmp->GetNativePointer();
		auto* nativeMouseCursor = al_create_mouse_cursor(nativeBmp, xFocus, yFocus);
		return gcnew AllegroMouseCursor(nativeMouseCursor);
	}

	Boolean Al::GetMouseCursorPosition(Int32^ retX, Int32^ retY)
	{
		int nativeX, nativeY;
		auto nativeReturnValue = al_get_mouse_cursor_position(&nativeX, &nativeY);
		retX = nativeX;
		retY = nativeY;
		return nativeReturnValue;
	}

	Boolean Al::GrabMouse(AllegroDisplay^ display)
	{
		auto* nativeDisplay = display->GetNativePointer();
		return al_grab_mouse(nativeDisplay);
	}

	Boolean Al::HideMouseCursor(AllegroDisplay^ display)
	{
		auto* nativeDisplay = display->GetNativePointer();
		return al_hide_mouse_cursor(nativeDisplay);
	}

	Boolean Al::InstallMouse()
	{
		return al_install_mouse();
	}

	Boolean Al::IsMouseInstalled()
	{
		return al_is_mouse_installed();
	}

	Boolean Al::MouseButtonDown(AllegroMouseState^ state, Int32 button)
	{
		auto* nativeState = state->GetNativePointer();
		return al_mouse_button_down(nativeState, button);
	}

	Boolean Al::SetMouseAxis(Int32 which, Int32 value)
	{
		return al_set_mouse_axis(which, value);
	}

	Boolean Al::SetMouseCursor(AllegroDisplay^ display, AllegroMouseCursor^ cursor)
	{
		auto* nativeDisplay = display->GetNativePointer();
		auto* nativeCursor = cursor->GetNativePointer();
		return al_set_mouse_cursor(nativeDisplay, nativeCursor);
	}

	Boolean Al::SetMouseW(Int32 w)
	{
		return al_set_mouse_w(w);
	}

	Boolean Al::SetMouseXY(AllegroDisplay^ display, Int32 x, Int32 y)
	{
		auto* nativeDisplay = display->GetNativePointer();
		return al_set_mouse_xy(nativeDisplay, x, y);
	}

	Boolean Al::SetMouseZ(Int32 z)
	{
		return al_set_mouse_z(z);
	}

	Boolean Al::SetSystemMouseCursor(AllegroDisplay^ display, SystemMouseCursor cursorId)
	{
		auto* nativeDisplay = display->GetNativePointer();
		auto nativeCursorId = static_cast<ALLEGRO_SYSTEM_MOUSE_CURSOR>(cursorId);
		return al_set_system_mouse_cursor(nativeDisplay, nativeCursorId);
	}

	Boolean Al::ShowMouseCursor(AllegroDisplay^ display)
	{
		auto* nativeDisplay = display->GetNativePointer();
		return al_show_mouse_cursor(nativeDisplay);
	}

	Boolean Al::UngrabMouse()
	{
		return al_ungrab_mouse();
	}

	Int32 Al::GetMouseStateAxis(AllegroMouseState^ state, Int32 axis)
	{
		auto* nativeState = state->GetNativePointer();
		return al_get_mouse_state_axis(nativeState, axis);
	}

	Int32 Al::GetMouseWheelPrecision()
	{
		return al_get_mouse_wheel_precision();
	}

	UInt32 Al::GetMouseNumAxes()
	{
		return al_get_mouse_num_axes();
	}

	UInt32 Al::GetMouseNumButtons()
	{
		return al_get_mouse_num_buttons();
	}

	void Al::DestroyMouseCursor(AllegroMouseCursor^ cursor)
	{
		auto* nativeCursor = cursor->GetNativePointer();
		al_destroy_mouse_cursor(nativeCursor);
	}

	void Al::GetMouseState(AllegroMouseState^ retState)
	{
		auto* nativeRetState = retState->GetNativePointer();
		al_get_mouse_state(nativeRetState);
	}

	void Al::SetMouseWheelPrecision(Int32 precision)
	{
		al_set_mouse_wheel_precision(precision);
	}

	void Al::UninstallMouse()
	{
		al_uninstall_mouse();
	}
}
