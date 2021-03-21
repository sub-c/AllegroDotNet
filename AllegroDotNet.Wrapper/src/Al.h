#pragma once

#include "PCH.h"

// Enumerations
#include "BitmapFlags.h"
#include "BitmapFlip.h"
#include "BitmapLoadFlags.h"
#include "BlenderFactor.h"
#include "BlenderOperation.h"
#include "DisplayFlags.h"
#include "DisplayOption.h"
#include "DisplayOrientation.h"
#include "EventType.h"
#include "Importance.h"
#include "JoyFlags.h"
#include "KeyCode.h"
#include "KeyModFlags.h"
#include "LockFlags.h"
#include "PixelFormat.h"
#include "RenderFunction.h"
#include "RenderState.h"
#include "StandardPath.h"
#include "SystemID.h"
#include "SystemMouseCursor.h"

namespace AllegroDotNet::Wrapper
{
	enum class BitmapFlags;
	enum class BitmapFlip;
	enum class BitmapLoadFlags;
	enum class BlenderFactor;
	enum class BlenderOperation;
	enum class DisplayFlags;
	enum class DisplayOption;
	enum class DisplayOrientation;
	enum class Importance;
	enum class JoyFlags;
	enum class KeyCode;
	enum class KeyModFlags;
	enum class LockFlags;
	enum class PixelFormat;
	enum class RenderFunction;
	enum class RenderState;
	enum class RenderState;
	enum class StandardPath;
	enum class SystemID;
	enum class SystemMouseCursor;

	ref class AllegroBitmap;
	ref class AllegroColor;
	ref class AllegroCond;
	ref class AllegroConfig;
	ref class AllegroConfigEntry;
	ref class AllegroConfigSection;
	ref class AllegroDisplay;
	ref class AllegroDisplayMode;
	ref class AllegroEvent;
	ref class AllegroEventQueue;
	ref class AllegroEventSource;
	ref class AllegroFile;
	ref class AllegroJoystick;
	ref class AllegroJoystickState;
	ref class AllegroKeyboardState;
	ref class AllegroLockedRegion;
	ref class AllegroMouseCursor;
	ref class AllegroMouseState;
	ref class AllegroPath;
	ref class AllegroTimeout;
	ref class AllegroTimer;
	ref class AllegroUserEvent;

	using namespace System;
	using namespace System::Runtime::InteropServices;

	public ref class Al sealed
	{
	public:
		// Configuration Files - AlConfig.cpp =================================
		static AllegroConfig^ CreateConfig();
		static AllegroConfig^ LoadConfigFile(String^ filename);
		static AllegroConfig^ LoadConfigFileF(AllegroFile^ file);
		static AllegroConfig^ MergeConfig(AllegroConfig^ config1, AllegroConfig^ config2);
		static Boolean RemoveConfigKey(AllegroConfig^ config, String^ section, String^ key);
		static Boolean RemoveConfigSection(AllegroConfig^ config, String^ section);
		static Boolean SaveConfigFile(String^ filename, AllegroConfig^ config);
		static Boolean SaveConfigFileF(AllegroFile^ file, AllegroConfig^ config);
		static String^ GetConfigValue(AllegroConfig^ config, String^ section, String^ key);
		static String^ GetFirstConfigEntry(AllegroConfig^ config, String^ section, [OutAttribute] AllegroConfigEntry^% iterator);
		static String^ GetFirstConfigSection(AllegroConfig^ config, [OutAttribute] AllegroConfigSection^% iterator);
		static String^ GetNextConfigEntry(AllegroConfigEntry^ iterator);
		static String^ GetNextConfigSection(AllegroConfigSection^ iterator);
		static void AddConfigComment(AllegroConfig^ config, String^ section, String^ comment);
		static void AddConfigSection(AllegroConfig^ config, String^ name);
		static void DestroyConfig(AllegroConfig^ config);
		static void MergeConfigInto(AllegroConfig^ master, AllegroConfig^ add);
		static void SetConfigValue(AllegroConfig^ config, String^ section, String^ key, String^ value);

		// Displays - AlDisplay.cpp ===========================================
		literal Int32 NewWindowTitleMaxSize = ALLEGRO_NEW_WINDOW_TITLE_MAX_SIZE;

		static AllegroBitmap^ GetBackbuffer(AllegroDisplay^ display);
		static AllegroDisplay^ CreateDisplay(Int32 w, Int32 h);
		static AllegroEventSource^ GetDisplayEventSource(AllegroDisplay^ display);
		static Boolean AcknowledgeResize(AllegroDisplay^ display);
		static Boolean ClipboardHasText(AllegroDisplay^ display);
		static Boolean GetWindowConstraints(AllegroDisplay^ display, Int32% minW, Int32% minH, Int32% maxW, Int32% maxH);
		static Boolean InhibitScreensaver(Boolean inhibit);
		static Boolean ResizeDisplay(AllegroDisplay^ display, Int32 width, Int32 height);
		static Boolean SetClipboardText(AllegroDisplay^ display, String^ text);
		static Boolean SetDisplayFlag(AllegroDisplay^ display, DisplayFlags flag, Boolean onOff);
		static Boolean SetWindowConstraints(AllegroDisplay^ display, Int32 minW, Int32 minH, Int32 maxW, Int32 maxH);
		static Boolean WaitForVSync();
		static DisplayFlags GetDisplayFlags(AllegroDisplay^ display);
		static DisplayFlags GetNewDisplayFlags();
		static DisplayOrientation GetDisplayOrientation(AllegroDisplay^ display);
		static Int32 GetDisplayHeight(AllegroDisplay^ display);
		static Int32 GetDisplayOption(AllegroDisplay^ display, DisplayOption option);
		static Int32 GetDisplayRefreshRate(AllegroDisplay^ display);
		static Int32 GetDisplayWidth(AllegroDisplay^ display);
		static Int32 GetNewDisplayOption(DisplayOption option, Importance% importance);
		static Int32 GetNewDisplayRefreshRate();
		static PixelFormat GetDisplayFormat(AllegroDisplay^ display);
		static String^ GetClipboardText(AllegroDisplay^ display);
		static String^ GetNewWindowTitle();
		static void AcknowledgeDrawingHalt(AllegroDisplay^ display);
		static void AcknowledgeDrawingResume(AllegroDisplay^ display);
		static void ApplyWindowConstraints(AllegroDisplay^ display, Boolean onOff);
		static void DestroyDisplay(AllegroDisplay^ display);
		static void FlipDisplay();
		static void GetNewWindowPosition(Int32% x, Int32% y);
		static void GetWindowPosition(AllegroDisplay^ display, Int32% x, Int32% y);
		static void ResetNewDisplayOptions();
		static void SetDisplayIcon(AllegroDisplay^ display, AllegroBitmap^ icon);
		static void SetDisplayIcons(AllegroDisplay^ display, Int32 numIcons, array<AllegroBitmap^>^ icons);
		static void SetDisplayOption(AllegroDisplay^ display, DisplayOption option, Int32 value);
		static void SetNewDisplayFlags(DisplayFlags flags);
		static void SetNewDisplayOption(DisplayOption option, Int32 value, Importance importance);
		static void SetNewDisplayRefreshRate(Int32 refreshRate);
		static void SetNewWindowPosition(Int32 x, Int32 y);
		static void SetNewWindowTitle(String^ title);
		static void SetWindowPosition(AllegroDisplay^ display, Int32 x, Int32 y);
		static void SetWindowTitle(AllegroDisplay^ display, String^ title);
		static void UpdateDisplayRegion(Int32 x, Int32 y, Int32 width, Int32 height);

		// Event system and events - AlEvent.cpp ====================================
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

		// Fullscreen modes - AlFullscreen.cpp ======================================
		static AllegroDisplayMode^ GetDisplayMode(Int32 index, AllegroDisplayMode^ mode);
		static Int32 GetNumDisplayModes();

		// Graphics routines - AlGraphics.cpp =======================================
		// colors
		static AllegroColor^ MapRgb(Byte r, Byte g, Byte b);
		static AllegroColor^ MapRgbA(Byte r, Byte g, Byte b, Byte a);
		static AllegroColor^ MapRgbAF(Single r, Single g, Single b, Single a);
		static AllegroColor^ MapRgbF(Single r, Single g, Single b);
		static AllegroColor^ PremulRgbA(Byte r, Byte g, Byte b, Byte a);
		static AllegroColor^ PremulRgbAF(Single r, Single g, Single b, Single a);
		static void UnmapRgb(AllegroColor^ color, Byte% r, Byte% g, Byte% b);
		static void UnmapRgbA(AllegroColor^ color, Byte% r, Byte% g, Byte% b, Byte% a);
		static void UnmapRgbAF(AllegroColor^ color, Single% r, Single% g, Single% b, Single% a);
		static void UnmapRgbF(AllegroColor^ color, Single% r, Single% g, Single% b);

		// locking and pixel formats
		static AllegroLockedRegion^ LockBitmap(AllegroBitmap^ bitmap, PixelFormat format, LockFlags flags);
		static AllegroLockedRegion^ LockBitmapBlocked(AllegroBitmap^ bitmap, LockFlags flags);
		static AllegroLockedRegion^ LockBitmapRegion(AllegroBitmap^ bitmap, Int32 x, Int32 y, Int32 width, Int32 height, PixelFormat format, LockFlags flags);
		static AllegroLockedRegion^ LockBitmapRegionBlocked(AllegroBitmap^ bitmap, Int32 xBlock, Int32 yBlock, Int32 widthBlock, Int32 heightBlock, LockFlags flags);
		static Int32 GetPixelBlockHeight(PixelFormat format);
		static Int32 GetPixelBlockSize(PixelFormat format);
		static Int32 GetPixelBlockWidth(PixelFormat format);
		static Int32 GetPixelFormatBits(PixelFormat format);
		static Int32 GetPixelSize(PixelFormat format);
		static void UnlockBitmap(AllegroBitmap^ bitmap);

		// bitmap creation
		static AllegroBitmap^ CloneBitmap(AllegroBitmap^ bitmap);
		static AllegroBitmap^ CreateBitmap(Int32 w, Int32 h);
		static AllegroBitmap^ CreateSubBitmap(AllegroBitmap^ parent, Int32 x, Int32 y, Int32 w, Int32 h);
		static BitmapFlags GetNewBitmapFlags();
		static PixelFormat GetNewBitmapFormat();
		static void AddNewBitmapFlag(BitmapFlags flag);
		static void ConvertBitmap(AllegroBitmap^ bitmap);
		static void ConvertMemoryBitmaps();
		static void DestroyBitmap(AllegroBitmap^ bitmap);
		static void SetNewBitmapFlags(BitmapFlags flags);
		static void SetNewBitmapFormat(PixelFormat format);

		// bitmap properties
		static AllegroBitmap^ GetParentBitmap(AllegroBitmap^ bitmap);
		static AllegroColor^ GetPixel(AllegroBitmap^ bitmap, Int32 x, Int32 y);
		static BitmapFlags GetBitmapFlags(AllegroBitmap^ bitmap);
		static Boolean IsBitmapLocked(AllegroBitmap^ bitmap);
		static Boolean IsCompatibleBitmap(AllegroBitmap^ bitmap);
		static Boolean IsSubBitmap(AllegroBitmap^ bitmap);
		static Int32 GetBitmapHeight(AllegroBitmap^ bitmap);
		static Int32 GetBitmapWidth(AllegroBitmap^ bitmap);
		static Int32 GetBitmapX(AllegroBitmap^ bitmap);
		static Int32 GetBitmapY(AllegroBitmap^ bitmap);
		static PixelFormat GetBitmapFormat(AllegroBitmap^ bitmap);
		static void ReparentBitmap(AllegroBitmap^ bitmap, AllegroBitmap^ parent, Int32 x, Int32 y, Int32 w, Int32 h);

		// drawing operations
		static AllegroBitmap^ GetTargetBitmap();
		static void ClearDepthBuffer(Single z);
		static void ClearToColor(AllegroColor^ color);
		static void DrawBitmap(AllegroBitmap^ bitmap, Single dx, Single dy, BitmapFlip flags);
		static void DrawBitmapRegion(AllegroBitmap^ bitmap, Single sx, Single sy, Single sw, Single sh, Single dx, Single dy, BitmapFlip flags);
		static void DrawPixel(Single x, Single y, AllegroColor^ color);
		static void DrawRotatedBitmap(AllegroBitmap^ bitmap, Single cx, Single cy, Single dx, Single dy, Single angle, BitmapFlip flags);
		static void DrawScaledBitmap(AllegroBitmap^ bitmap, Single sx, Single sy, Single sw, Single sh, Single dx, Single dy, Single dw, Single dh, BitmapFlip flags);
		static void DrawScaledRotatedBitmap(AllegroBitmap^ bitmap, Single cx, Single cy, Single dx, Single dy, Single xScale, Single yScale, Single angle, BitmapFlip flags);
		static void DrawTintedBitmap(AllegroBitmap^ bitmap, AllegroColor^ tint, Single dx, Single dy, BitmapFlip flags);
		static void DrawTintedBitmapRegion(AllegroBitmap^ bitmap, AllegroColor^ tint, Single sx, Single sy, Single sw, Single sh, Single dx, Single dy, BitmapFlip flags);
		static void DrawTintedRotatedBitmap(AllegroBitmap^ bitmap, AllegroColor^ tint, Single cx, Single cy, Single dx, Single dy, Single angle, BitmapFlip flags);
		static void DrawTintedScaledBitmap(AllegroBitmap^ bitmap, AllegroColor^ tint, Single sx, Single sy, Single sw, Single sh, Single dx, Single dy, Single dw, Single dh, BitmapFlip flags);
		static void DrawTintedScaledRotatedBitmap(AllegroBitmap^ bitmap, AllegroColor^ tint, Single cx, Single cy, Single dx, Single dy, Single xScale, Single yScale, Single angle, BitmapFlip flags);
		static void DrawTintedScaledRotatedBitmapRegion(AllegroBitmap^ bitmap, Single sx, Single sy, Single sw, Single sh, AllegroColor^ tint, Single cx, Single cy, Single dx, Single dy, Single xScale, Single yScale, Single angle, BitmapFlip flags);
		static void PutBlendedPixel(Int32 x, Int32 y, AllegroColor^ color);
		static void PutPixel(Int32 x, Int32 y, AllegroColor^ color);

		// target bitmap
		static AllegroDisplay^ GetCurrentDisplay();
		static void SetTargetBackbuffer(AllegroDisplay^ display);
		static void SetTargetBitmap(AllegroBitmap^ bitmap);

		// blending modes
		static AllegroColor^ GetBlendColor();
		static void GetBlender([Out] BlenderOperation% op, [Out] BlenderFactor% src, [Out] BlenderFactor% dst);
		static void GetSeparateBlender([Out] BlenderOperation% op, [Out] BlenderFactor% src, [Out] BlenderFactor% dst, [Out] BlenderOperation% alphaOp, [Out] BlenderFactor% alphaSrc, [Out] BlenderFactor% alphaDst);
		static void SetBlender(BlenderOperation op, BlenderFactor src, BlenderFactor dst);
		static void SetBlendColor(AllegroColor^ color);
		static void SetSeparateBlender(BlenderOperation op, BlenderFactor src, BlenderFactor dst, BlenderOperation alphaOp, BlenderFactor alphaSrc, BlenderFactor alphaDst);

		// clipping
		static void GetClippingRectangle([Out] Int32% x, [Out] Int32% y, [Out] Int32% w, [Out] Int32% h);
		static void ResetClippingRectangle();
		static void SetClippingRectangle(Int32 x, Int32 y, Int32 w, Int32 h);

		// graphics utility functions
		static void ConvertMaskToAlpha(AllegroBitmap^ bitmap, AllegroColor^ maskColor);

		// deferred drawing
		static Boolean IsBitmapDrawingHeld();
		static void HoldBitmapDrawing(Boolean hold);

		// image I/O
		static AllegroBitmap^ LoadBitmapA(String^ filename);
		static AllegroBitmap^ LoadBitmapF(AllegroFile^ fp, String^ ident);
		static AllegroBitmap^ LoadBitmapFlags(String^ filename, BitmapLoadFlags flags);
		static AllegroBitmap^ LoadBitmapFlagsF(AllegroFile^ fp, String^ ident, BitmapLoadFlags flags);
		static Boolean RegisterBitmapIdentifier(String^ extension, Func<AllegroFile^, Boolean>^ identifier);
		static Boolean RegisterBitmapLoader(String^ extension, Func<String^, Int32, AllegroBitmap^>^ loader);
		static Boolean RegisterBitmapLoaderF(String^ extension, Func<AllegroFile^, Int32, AllegroBitmap^>^ loader);
		static Boolean RegisterBitmapSaver(String^ extension, Func<String^, Int32, Boolean>^ saver);
		static Boolean RegisterBitmapSaverF(String^ extension, Func<AllegroFile^, AllegroBitmap^, Boolean>^ saver);
		static Boolean SaveBitmap(String^ filename, AllegroBitmap^ bitmap);
		static Boolean SaveBitmapF(AllegroFile^ fp, String^ ident, AllegroBitmap^ bitmap);
		static String^ IdentifyBitmap(String^ filename);
		static String^ IdentifyBitmapF(AllegroFile^ fp);

		// render state
		static void SetRenderState(RenderState state, Int32 value);

		// Joystick routines - AlJoystick.cpp =======================================
		static AllegroEventSource^ GetJoystickEventSource();
		static AllegroJoystick^ GetJoystick(Int32 num);
		static Boolean GetJoystickActive(AllegroJoystick^ joy);
		static Boolean InstallJoystick();
		static Boolean IsJoystickInstalled();
		static Boolean ReconfigureJoysticks();
		static Int32 GetJoystickNumAxes(AllegroJoystick^ joy, Int32 stick);
		static Int32 GetJoystickNumButtons(AllegroJoystick^ joy);
		static Int32 GetJoystickNumSticks(AllegroJoystick^ joy);
		static Int32 GetNumJoysticks();
		static JoyFlags GetJoystickStickFlags(AllegroJoystick^ joy, Int32 stick);
		static String^ GetJoystickAxisName(AllegroJoystick^ joy, Int32 stick, Int32 axis);
		static String^ GetJoystickButtonName(AllegroJoystick^ joy, Int32 button);
		static String^ GetJoystickName(AllegroJoystick^ joy);
		static String^ GetJoystickStickName(AllegroJoystick^ joy, Int32 stick);
		static void GetJoystickState(AllegroJoystick^ joy, AllegroJoystickState^ retState);
		static void ReleaseJoystick(AllegroJoystick^ joy);
		static void UninstallJoystick();

		// Keyboard routines - AlKeyboard.cpp =======================================
		static AllegroEventSource^ GetKeyboardEventSource();
		static Boolean InstallKeyboard();
		static Boolean IsKeyboardInstalled();
		static Boolean KeyDown(AllegroKeyboardState^ state, KeyCode keyCode);
		static Boolean SetKeyboardLeds(KeyModFlags leds);
		static String^ KeyCodeToName(KeyCode keyCode);
		static void GetKeyboardState(AllegroKeyboardState^ retState);
		static void UninstallKeyboard();

		// Mouse routines - AlMouse.cpp =======================================
		static AllegroEventSource^ GetMouseEventSource();
		static AllegroMouseCursor^ CreateMouseCursor(AllegroBitmap^ bmp, Int32 xFocus, Int32 yFocus);
		static Boolean GetMouseCursorPosition(Int32^ retX, Int32^ retY);
		static Boolean GrabMouse(AllegroDisplay^ display);
		static Boolean HideMouseCursor(AllegroDisplay^ display);
		static Boolean InstallMouse();
		static Boolean IsMouseInstalled();
		static Boolean MouseButtonDown(AllegroMouseState^ state, Int32 button);
		static Boolean SetMouseAxis(Int32 which, Int32 value);
		static Boolean SetMouseCursor(AllegroDisplay^ display, AllegroMouseCursor^ cursor);
		static Boolean SetMouseW(Int32 w);
		static Boolean SetMouseXY(AllegroDisplay^ display, Int32 x, Int32 y);
		static Boolean SetMouseZ(Int32 z);
		static Boolean SetSystemMouseCursor(AllegroDisplay^ display, SystemMouseCursor cursorId);
		static Boolean ShowMouseCursor(AllegroDisplay^ display);
		static Boolean UngrabMouse();
		static Int32 GetMouseStateAxis(AllegroMouseState^ state, Int32 axis);
		static Int32 GetMouseWheelPrecision();
		static UInt32 GetMouseNumAxes();
		static UInt32 GetMouseNumButtons();
		static void DestroyMouseCursor(AllegroMouseCursor^ cursor);
		static void GetMouseState(AllegroMouseState^ retState);
		static void SetMouseWheelPrecision(Int32 precision);
		static void UninstallMouse();

		// System - AlSystem.cpp ==============================================
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

		// Time routines - AlTime.cpp =========================================
		static Double GetTime();
		static void InitTimeout(AllegroTimeout^ timeout, Double seconds);
		static void Rest(Double seconds);

		// Timer routines - AlTimer.cpp =============================================
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
