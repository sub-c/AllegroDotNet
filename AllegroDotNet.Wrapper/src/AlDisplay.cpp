#include "PCH.h"

#include "Al.h"
#include "AllegroBitmap.h"
#include "AllegroDisplay.h"
#include "AllegroEventSource.h"
#include "DisplayFlags.h"
#include "DisplayOption.h"
#include "DisplayOrientation.h"
#include "PixelFormat.h"

#include <msclr/marshal.h>
#include <vector>

namespace AllegroDotNet::Wrapper
{
	using namespace msclr::interop;

	AllegroBitmap^ Al::GetBackbuffer(AllegroDisplay^ display)
	{
		auto* nativeDisplay = display->GetNativePointer();
		auto* nativeBackbuffer = al_get_backbuffer(nativeDisplay);
		return gcnew AllegroBitmap(nativeBackbuffer);
	}

	AllegroDisplay^ Al::CreateDisplay(Int32 w, Int32 h)
	{
		auto* nativeDisplay = al_create_display(w, h);
		return gcnew AllegroDisplay(nativeDisplay);
	}

	AllegroEventSource^ Al::GetDisplayEventSource(AllegroDisplay^ display)
	{
		auto* nativeDisplay = display->GetNativePointer();
		auto* nativeDisplayEventSource = al_get_display_event_source(nativeDisplay);
		return gcnew AllegroEventSource(nativeDisplayEventSource);
	}

	Boolean Al::AcknowledgeResize(AllegroDisplay^ display)
	{
		auto* nativeDisplay = display->GetNativePointer();
		return al_acknowledge_resize(nativeDisplay);
	}

	Boolean Al::ClipboardHasText(AllegroDisplay^ display)
	{
		auto* nativeDisplay = display->GetNativePointer();
		return al_clipboard_has_text(nativeDisplay);
	}

	Boolean Al::GetWindowConstraints(AllegroDisplay^ display, Int32% minW, Int32% minH, Int32% maxW, Int32% maxH)
	{
		auto* nativeDisplay = display->GetNativePointer();
		int nativeMinW, nativeMinH, nativeMaxW, nativeMaxH;
		auto returnValue = al_get_window_constraints(nativeDisplay, &nativeMinW, &nativeMinH, &nativeMaxW, &nativeMaxH);
		minW = nativeMinW;
		minH = nativeMinH;
		maxW = nativeMaxW;
		maxH = nativeMaxH;
		return returnValue;
	}

	Boolean Al::InhibitScreensaver(Boolean inhibit)
	{
		return al_inhibit_screensaver(inhibit);
	}

	Boolean Al::ResizeDisplay(AllegroDisplay^ display, Int32 width, Int32 height)
	{
		auto* nativeDisplay = display->GetNativePointer();
		return al_resize_display(nativeDisplay, width, height);
	}

	Boolean Al::SetClipboardText(AllegroDisplay^ display, String^ text)
	{
		auto* nativeDisplay = display->GetNativePointer();
		marshal_context marshalContext;
		const auto* nativeText = marshalContext.marshal_as<const char*>(text);
		return al_set_clipboard_text(nativeDisplay, nativeText);
	}

	Boolean Al::SetDisplayFlag(AllegroDisplay^ display, DisplayFlags flag, Boolean onOff)
	{
		auto* nativeDisplay = display->GetNativePointer();
		auto nativeFlag = static_cast<int>(flag);
		return al_set_display_flag(nativeDisplay, nativeFlag, onOff);
	}

	Boolean Al::SetWindowConstraints(AllegroDisplay^ display, Int32 minW, Int32 minH, Int32 maxW, Int32 maxH)
	{
		auto* nativeDisplay = display->GetNativePointer();
		return al_set_window_constraints(nativeDisplay, minW, minH, maxW, maxH);
	}

	Boolean Al::WaitForVSync()
	{
		return al_wait_for_vsync();
	}

	DisplayFlags Al::GetDisplayFlags(AllegroDisplay^ display)
	{
		auto* nativeDisplay = display->GetNativePointer();
		return static_cast<DisplayFlags>(al_get_display_flags(nativeDisplay));
	}

	DisplayFlags Al::GetNewDisplayFlags()
	{
		return static_cast<DisplayFlags>(al_get_new_display_flags());
	}

	DisplayOrientation Al::GetDisplayOrientation(AllegroDisplay^ display)
	{
		auto* nativeDisplay = display->GetNativePointer();
		return static_cast<DisplayOrientation>(al_get_display_orientation(nativeDisplay));
	}

	Int32 Al::GetDisplayHeight(AllegroDisplay^ display)
	{
		auto* nativeDisplay = display->GetNativePointer();
		return al_get_display_height(nativeDisplay);
	}

	Int32 Al::GetDisplayOption(AllegroDisplay^ display, DisplayOption option)
	{
		auto* nativeDisplay = display->GetNativePointer();
		auto nativeOption = static_cast<int>(option);
		return al_get_display_option(nativeDisplay, nativeOption);
	}

	Int32 Al::GetDisplayRefreshRate(AllegroDisplay^ display)
	{
		auto* nativeDisplay = display->GetNativePointer();
		return al_get_display_refresh_rate(nativeDisplay);
	}

	Int32 Al::GetDisplayWidth(AllegroDisplay^ display)
	{
		auto* nativeDisplay = display->GetNativePointer();
		return al_get_display_width(nativeDisplay);
	}

	Int32 Al::GetNewDisplayOption(DisplayOption option, Importance% importance)
	{
		auto nativeOption = static_cast<int>(option);
		int nativeImportance;
		auto returnValue = al_get_new_display_option(nativeOption, &nativeImportance);
		importance = static_cast<Importance>(nativeImportance);
		return returnValue;
	}

	Int32 Al::GetNewDisplayRefreshRate()
	{
		return al_get_new_display_refresh_rate();
	}

	PixelFormat Al::GetDisplayFormat(AllegroDisplay^ display)
	{
		auto* nativeDisplay = display->GetNativePointer();
		auto nativePixelFormat = al_get_display_format(nativeDisplay);
		return static_cast<PixelFormat>(nativePixelFormat);
	}

	String^ Al::GetClipboardText(AllegroDisplay^ display)
	{
		auto* nativeDisplay = display->GetNativePointer();
		const auto* nativeClipboardText = al_get_clipboard_text(nativeDisplay);
		return gcnew String(nativeClipboardText);
	}

	String^ Al::GetNewWindowTitle()
	{
		const auto* nativeWindowTitle = al_get_new_window_title();
		return gcnew String(nativeWindowTitle);
	}

	void Al::AcknowledgeDrawingHalt(AllegroDisplay^ display)
	{
		auto* nativeDisplay = display->GetNativePointer();
		al_acknowledge_drawing_halt(nativeDisplay);
	}

	void Al::AcknowledgeDrawingResume(AllegroDisplay^ display)
	{
		auto* nativeDisplay = display->GetNativePointer();
		al_acknowledge_drawing_resume(nativeDisplay);
	}

	void Al::ApplyWindowConstraints(AllegroDisplay^ display, Boolean onOff)
	{
		auto* nativeDisplay = display->GetNativePointer();
		al_apply_window_constraints(nativeDisplay, onOff);
	}

	void Al::DestroyDisplay(AllegroDisplay^ display)
	{
		auto* nativeDisplay = display->GetNativePointer();
		al_destroy_display(nativeDisplay);
	}

	void Al::FlipDisplay()
	{
		al_flip_display();
	}

	void Al::GetNewWindowPosition(Int32% x, Int32% y)
	{
		int nativeX, nativeY;
		al_get_new_window_position(&nativeX, &nativeY);
		x = nativeX;
		y = nativeY;
	}

	void Al::GetWindowPosition(AllegroDisplay^ display, Int32% x, Int32% y)
	{
		auto* nativeDisplay = display->GetNativePointer();
		int nativeX, nativeY;
		al_get_window_position(nativeDisplay, &nativeX, &nativeY);
		x = nativeX;
		y = nativeY;
	}

	void Al::ResetNewDisplayOptions()
	{
		al_reset_new_display_options();
	}

	void Al::SetDisplayIcon(AllegroDisplay^ display, AllegroBitmap^ icon)
	{
		auto* nativeDisplay = display->GetNativePointer();
		auto* nativeIcon = icon->GetNativePointer();
		al_set_display_icon(nativeDisplay, nativeIcon);
	}

	void Al::SetDisplayIcons(AllegroDisplay^ display, Int32 numIcons, array<AllegroBitmap^>^ icons)
	{
		auto* nativeDisplay = display->GetNativePointer();
		std::vector<ALLEGRO_BITMAP*> nativeIcons;
		for each (auto iconBitmap in icons)
		{
			nativeIcons.push_back(iconBitmap->GetNativePointer());
		}
		al_set_display_icons(nativeDisplay, numIcons, nativeIcons.data());
	}

	void Al::SetDisplayOption(AllegroDisplay^ display, DisplayOption option, Int32 value)
	{
		auto* nativeDisplay = display->GetNativePointer();
		auto nativeOption = static_cast<int>(option);
		al_set_display_option(nativeDisplay, nativeOption, value);
	}

	void Al::SetNewDisplayFlags(DisplayFlags flags)
	{
		auto nativeFlags = static_cast<int>(flags);
		al_set_new_display_flags(nativeFlags);
	}

	void Al::SetNewDisplayOption(DisplayOption option, Int32 value, Importance importance)
	{
		auto nativeOption = static_cast<int>(option);
		auto nativeImportance = static_cast<int>(importance);
		al_set_new_display_option(nativeOption, value, nativeImportance);
	}

	void Al::SetNewDisplayRefreshRate(Int32 refreshRate)
	{
		al_set_new_display_refresh_rate(refreshRate);
	}

	void Al::SetNewWindowPosition(Int32 x, Int32 y)
	{
		al_set_new_window_position(x, y);
	}

	void Al::SetNewWindowTitle(String^ title)
	{
		marshal_context marshalContext;
		const auto* nativeTitle = marshalContext.marshal_as<const char*>(title);
		al_set_new_window_title(nativeTitle);
	}

	void Al::SetWindowPosition(AllegroDisplay^ display, Int32 x, Int32 y)
	{
		auto* nativeDisplay = display->GetNativePointer();
		al_set_window_position(nativeDisplay, x, y);
	}

	void Al::SetWindowTitle(AllegroDisplay^ display, String^ title)
	{
		auto* nativeDisplay = display->GetNativePointer();
		marshal_context marshalContext;
		const auto* nativeTitle = marshalContext.marshal_as<const char*>(title);
		al_set_window_title(nativeDisplay, nativeTitle);
	}

	void Al::UpdateDisplayRegion(Int32 x, Int32 y, Int32 width, Int32 height)
	{
		al_update_display_region(x, y, width, height);
	}
}
