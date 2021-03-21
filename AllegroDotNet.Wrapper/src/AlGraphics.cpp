#include "PCH.h"

#include "Al.h"
#include "AllegroBitmap.h"
#include "AllegroColor.h"
#include "AllegroDisplay.h"
#include "AllegroFile.h"
#include "AllegroLockedRegion.h"
#include "BitmapFlags.h"
#include "BitmapLoadFlags.h"
#include "BlenderFactor.h"
#include "BlenderOperation.h"
#include "LockFlags.h"
#include "PixelFormat.h"
#include "RenderState.h"

#include <msclr/marshal.h>

namespace AllegroDotNet::Wrapper
{
	using namespace msclr::interop;

	// colors
	AllegroColor^ Al::MapRgb(Byte r, Byte g, Byte b)
	{
		auto nativeColor = al_map_rgb(r, g, b);
		return gcnew AllegroColor(nativeColor);
	}

	AllegroColor^ Al::MapRgbA(Byte r, Byte g, Byte b, Byte a)
	{
		auto nativeColor = al_map_rgba(r, g, b, a);
		return gcnew AllegroColor(nativeColor);
	}

	AllegroColor^ Al::MapRgbAF(Single r, Single g, Single b, Single a)
	{
		auto nativeColor = al_map_rgba_f(r, g, b, a);
		return gcnew AllegroColor(nativeColor);
	}

	AllegroColor^ Al::MapRgbF(Single r, Single g, Single b)
	{
		auto nativeColor = al_map_rgb_f(r, g, b);
		return gcnew AllegroColor(nativeColor);
	}

	AllegroColor^ Al::PremulRgbA(Byte r, Byte g, Byte b, Byte a)
	{
		auto nativeColor = al_premul_rgba(r, g, b, a);
		return gcnew AllegroColor(nativeColor);
	}

	AllegroColor^ Al::PremulRgbAF(Single r, Single g, Single b, Single a)
	{
		auto nativeColor = al_premul_rgba_f(r, g, b, a);
		return gcnew AllegroColor(nativeColor);
	}

	void Al::UnmapRgb(AllegroColor^ color, Byte% r, Byte% g, Byte% b)
	{
		auto* nativeColor = color->GetNativePointer();
		unsigned char nativeR, nativeG, nativeB;
		al_unmap_rgb(*nativeColor, &nativeR, &nativeG, &nativeB);
		r = nativeR;
		g = nativeG;
		b = nativeB;
	}

	void Al::UnmapRgbA(AllegroColor^ color, Byte% r, Byte% g, Byte% b, Byte% a)
	{
		auto* nativeColor = color->GetNativePointer();
		unsigned char nativeR, nativeG, nativeB, nativeA;
		al_unmap_rgba(*nativeColor, &nativeR, &nativeG, &nativeB, &nativeA);
		r = nativeR;
		g = nativeG;
		b = nativeB;
		a = nativeA;
	}

	void Al::UnmapRgbAF(AllegroColor^ color, Single% r, Single% g, Single% b, Single% a)
	{
		auto* nativeColor = color->GetNativePointer();
		float nativeR, nativeG, nativeB, nativeA;
		al_unmap_rgba_f(*nativeColor, &nativeR, &nativeG, &nativeB, &nativeA);
		r = nativeR;
		g = nativeG;
		b = nativeB;
		a = nativeA;
	}

	void Al::UnmapRgbF(AllegroColor^ color, Single% r, Single% g, Single% b)
	{
		auto* nativeColor = color->GetNativePointer();
		float nativeR, nativeG, nativeB;
		al_unmap_rgb_f(*nativeColor, &nativeR, &nativeG, &nativeB);
	}

	// locking and pixel formats
	AllegroLockedRegion^ Al::LockBitmap(AllegroBitmap^ bitmap, PixelFormat format, LockFlags flags)
	{
		auto* nativeBitmap = bitmap->GetNativePointer();
		auto nativeFormat = static_cast<int>(format);
		auto nativeFlags = static_cast<int>(flags);
		auto* nativeReturnValue = al_lock_bitmap(nativeBitmap, nativeFormat, nativeFlags);
		return gcnew AllegroLockedRegion(nativeReturnValue);
	}

	AllegroLockedRegion^ Al::LockBitmapBlocked(AllegroBitmap^ bitmap, LockFlags flags)
	{
		auto* nativeBitmap = bitmap->GetNativePointer();
		auto nativeFlags = static_cast<int>(flags);
		auto* nativeReturnValue = al_lock_bitmap_blocked(nativeBitmap, nativeFlags);
		return gcnew AllegroLockedRegion(nativeReturnValue);
	}

	AllegroLockedRegion^ Al::LockBitmapRegion(AllegroBitmap^ bitmap, Int32 x, Int32 y, Int32 width, Int32 height, PixelFormat format, LockFlags flags)
	{
		auto* nativeBitmap = bitmap->GetNativePointer();
		auto nativeFormat = static_cast<int>(format);
		auto nativeFlags = static_cast<int>(flags);
		auto* nativeReturnValue = al_lock_bitmap_region(nativeBitmap, x, y, width, height, nativeFormat, nativeFlags);
		return gcnew AllegroLockedRegion(nativeReturnValue);
	}

	AllegroLockedRegion^ Al::LockBitmapRegionBlocked(AllegroBitmap^ bitmap, Int32 xBlock, Int32 yBlock, Int32 widthBlock, Int32 heightBlock, LockFlags flags)
	{
		auto* nativeBitmap = bitmap->GetNativePointer();
		auto nativeFlags = static_cast<int>(flags);
		auto* nativeReturnValue = al_lock_bitmap_region_blocked(nativeBitmap, xBlock, yBlock, widthBlock, heightBlock, nativeFlags);
		return gcnew AllegroLockedRegion(nativeReturnValue);
	}

	Int32 Al::GetPixelBlockHeight(PixelFormat format)
	{
		auto nativeFormat = static_cast<int>(format);
		return al_get_pixel_block_height(nativeFormat);
	}

	Int32 Al::GetPixelBlockSize(PixelFormat format)
	{
		auto nativeFormat = static_cast<int>(format);
		return al_get_pixel_block_size(nativeFormat);
	}

	Int32 Al::GetPixelBlockWidth(PixelFormat format)
	{
		auto nativeFormat = static_cast<int>(format);
		return al_get_pixel_block_width(nativeFormat);
	}

	Int32 Al::GetPixelFormatBits(PixelFormat format)
	{
		auto nativeFormat = static_cast<int>(format);
		return al_get_pixel_format_bits(nativeFormat);
	}

	Int32 Al::GetPixelSize(PixelFormat format)
	{
		auto nativeFormat = static_cast<int>(format);
		return al_get_pixel_size(nativeFormat);
	}

	void Al::UnlockBitmap(AllegroBitmap^ bitmap)
	{
		auto* nativeBitmap = bitmap->GetNativePointer();
		al_unlock_bitmap(nativeBitmap);
	}

	// bitmap creation
	AllegroBitmap^ Al::CloneBitmap(AllegroBitmap^ bitmap)
	{
		auto* nativeBitmap = bitmap->GetNativePointer();
		auto* nativeReturnValue = al_clone_bitmap(nativeBitmap);
		return gcnew AllegroBitmap(nativeReturnValue);
	}

	AllegroBitmap^ Al::CreateBitmap(Int32 w, Int32 h)
	{
		auto* nativeReturnValue = al_create_bitmap(w, h);
		return gcnew AllegroBitmap(nativeReturnValue);
	}

	AllegroBitmap^ Al::CreateSubBitmap(AllegroBitmap^ parent, Int32 x, Int32 y, Int32 w, Int32 h)
	{
		auto* nativeParent = parent->GetNativePointer();
		auto* nativeReturnValue = al_create_sub_bitmap(nativeParent, x, y, w, h);
		return gcnew AllegroBitmap(nativeReturnValue);
	}

	BitmapFlags Al::GetNewBitmapFlags()
	{
		return static_cast<BitmapFlags>(al_get_new_bitmap_flags());
	}

	PixelFormat Al::GetNewBitmapFormat()
	{
		return static_cast<PixelFormat>(al_get_new_bitmap_format());
	}

	void Al::AddNewBitmapFlag(BitmapFlags flag)
	{
		auto nativeFlag = static_cast<int>(flag);
		al_add_new_bitmap_flag(nativeFlag);
	}

	void Al::ConvertBitmap(AllegroBitmap^ bitmap)
	{
		auto* nativeBitmap = bitmap->GetNativePointer();
		al_convert_bitmap(nativeBitmap);
	}

	void Al::ConvertMemoryBitmaps()
	{
		al_convert_memory_bitmaps();
	}

	void Al::DestroyBitmap(AllegroBitmap^ bitmap)
	{
		auto* nativeBitmap = bitmap->GetNativePointer();
		al_destroy_bitmap(nativeBitmap);
	}

	void Al::SetNewBitmapFlags(BitmapFlags flags)
	{
		auto nativeFlags = static_cast<int>(flags);
		al_set_new_bitmap_flags(nativeFlags);
	}

	void Al::SetNewBitmapFormat(PixelFormat format)
	{
		auto nativeFormat = static_cast<int>(format);
		al_set_new_bitmap_format(nativeFormat);
	}

	// bitmap properties
	AllegroBitmap^ Al::GetParentBitmap(AllegroBitmap^ bitmap)
	{
		auto* nativeBitmap = bitmap->GetNativePointer();
		auto* nativeReturnValue = al_get_parent_bitmap(nativeBitmap);
		return gcnew AllegroBitmap(nativeReturnValue);
	}

	AllegroColor^ Al::GetPixel(AllegroBitmap^ bitmap, Int32 x, Int32 y)
	{
		auto* nativeBitmap = bitmap->GetNativePointer();
		auto nativeReturnValue = al_get_pixel(nativeBitmap, x, y);
		return gcnew AllegroColor(nativeReturnValue);
	}

	BitmapFlags Al::GetBitmapFlags(AllegroBitmap^ bitmap)
	{
		auto* nativeBitmap = bitmap->GetNativePointer();
		auto nativeReturnValue = al_get_bitmap_flags(nativeBitmap);
		return static_cast<BitmapFlags>(nativeReturnValue);
	}

	Boolean Al::IsBitmapLocked(AllegroBitmap^ bitmap)
	{
		auto* nativeBitmap = bitmap->GetNativePointer();
		return al_is_bitmap_locked(nativeBitmap);
	}

	Boolean Al::IsCompatibleBitmap(AllegroBitmap^ bitmap)
	{
		auto* nativeBitmap = bitmap->GetNativePointer();
		return al_is_compatible_bitmap(nativeBitmap);
	}

	Boolean Al::IsSubBitmap(AllegroBitmap^ bitmap)
	{
		auto* nativeBitmap = bitmap->GetNativePointer();
		return al_is_sub_bitmap(nativeBitmap);
	}

	Int32 Al::GetBitmapHeight(AllegroBitmap^ bitmap)
	{
		auto* nativeBitmap = bitmap->GetNativePointer();
		return al_get_bitmap_height(nativeBitmap);
	}

	Int32 Al::GetBitmapWidth(AllegroBitmap^ bitmap)
	{
		auto* nativeBitmap = bitmap->GetNativePointer();
		return al_get_bitmap_width(nativeBitmap);
	}

	Int32 Al::GetBitmapX(AllegroBitmap^ bitmap)
	{
		auto* nativeBitmap = bitmap->GetNativePointer();
		return al_get_bitmap_x(nativeBitmap);
	}

	Int32 Al::GetBitmapY(AllegroBitmap^ bitmap)
	{
		auto* nativeBitmap = bitmap->GetNativePointer();
		return al_get_bitmap_y(nativeBitmap);
	}

	PixelFormat Al::GetBitmapFormat(AllegroBitmap^ bitmap)
	{
		auto* nativeBitmap = bitmap->GetNativePointer();
		auto nativeReturnValue = al_get_bitmap_format(nativeBitmap);
		return static_cast<PixelFormat>(nativeReturnValue);
	}

	void Al::ReparentBitmap(AllegroBitmap^ bitmap, AllegroBitmap^ parent, Int32 x, Int32 y, Int32 w, Int32 h)
	{
		auto* nativeBitmap = bitmap->GetNativePointer();
		auto* nativeParent = parent->GetNativePointer();
		al_reparent_bitmap(nativeBitmap, nativeParent, x, y, w, h);
	}

	// drawing operations
	AllegroBitmap^ Al::GetTargetBitmap()
	{
		auto* nativeReturnValue = al_get_target_bitmap();
		return gcnew AllegroBitmap(nativeReturnValue);
	}

	void Al::ClearDepthBuffer(Single z)
	{
		al_clear_depth_buffer(z);
	}

	void Al::ClearToColor(AllegroColor^ color)
	{
		auto* nativeColor = color->GetNativePointer();
		al_clear_to_color(*nativeColor);
	}

	void Al::DrawBitmap(AllegroBitmap^ bitmap, Single dx, Single dy, BitmapFlip flags)
	{
		auto* nativeBitmap = bitmap->GetNativePointer();
		auto nativeFlags = static_cast<int>(flags);
		al_draw_bitmap(nativeBitmap, dx, dy, nativeFlags);
	}

	void Al::DrawBitmapRegion(AllegroBitmap^ bitmap, Single sx, Single sy, Single sw, Single sh, Single dx, Single dy, BitmapFlip flags)
	{
		auto* nativeBitmap = bitmap->GetNativePointer();
		auto nativeFlags = static_cast<int>(flags);
		al_draw_bitmap_region(nativeBitmap, sx, sy, sw, sh, dx, dy, nativeFlags);
	}

	void Al::DrawPixel(Single x, Single y, AllegroColor^ color)
	{
		auto* nativeColor = color->GetNativePointer();
		al_draw_pixel(x, y, *nativeColor);
	}

	void Al::DrawRotatedBitmap(AllegroBitmap^ bitmap, Single cx, Single cy, Single dx, Single dy, Single angle, BitmapFlip flags)
	{
		auto* nativeBitmap = bitmap->GetNativePointer();
		auto nativeFlags = static_cast<int>(flags);
		al_draw_rotated_bitmap(nativeBitmap, cx, cy, dx, dy, angle, nativeFlags);
	}

	void Al::DrawScaledBitmap(AllegroBitmap^ bitmap, Single sx, Single sy, Single sw, Single sh, Single dx, Single dy, Single dw, Single dh, BitmapFlip flags)
	{
		auto* nativeBitmap = bitmap->GetNativePointer();
		auto nativeFlags = static_cast<int>(flags);
		al_draw_scaled_bitmap(nativeBitmap, sx, sy, sw, sh, dx, dy, dw, dh, nativeFlags);
	}

	void Al::DrawScaledRotatedBitmap(AllegroBitmap^ bitmap, Single cx, Single cy, Single dx, Single dy, Single xScale, Single yScale, Single angle, BitmapFlip flags)
	{
		auto* nativeBitmap = bitmap->GetNativePointer();
		auto nativeFlags = static_cast<int>(flags);
		al_draw_scaled_rotated_bitmap(nativeBitmap, cx, cy, dx, dy, xScale, yScale, angle, nativeFlags);
	}

	void Al::DrawTintedBitmap(AllegroBitmap^ bitmap, AllegroColor^ tint, Single dx, Single dy, BitmapFlip flags)
	{
		auto* nativeBitmap = bitmap->GetNativePointer();
		auto* nativeTint = tint->GetNativePointer();
		auto nativeFlags = static_cast<int>(flags);
		al_draw_tinted_bitmap(nativeBitmap, *nativeTint, dx, dy, nativeFlags);
	}

	void Al::DrawTintedBitmapRegion(AllegroBitmap^ bitmap, AllegroColor^ tint, Single sx, Single sy, Single sw, Single sh, Single dx, Single dy, BitmapFlip flags)
	{
		auto* nativeBitmap = bitmap->GetNativePointer();
		auto* nativeTint = tint->GetNativePointer();
		auto nativeFlags = static_cast<int>(flags);
		al_draw_tinted_bitmap_region(nativeBitmap, *nativeTint, sx, sy, sw, sh, dx, dy, nativeFlags);
	}

	void Al::DrawTintedRotatedBitmap(AllegroBitmap^ bitmap, AllegroColor^ tint, Single cx, Single cy, Single dx, Single dy, Single angle, BitmapFlip flags)
	{
		auto* nativeBitmap = bitmap->GetNativePointer();
		auto* nativeTint = tint->GetNativePointer();
		auto nativeFlags = static_cast<int>(flags);
		al_draw_tinted_rotated_bitmap(nativeBitmap, *nativeTint, cx, cy, dx, dy, angle, nativeFlags);
	}

	void Al::DrawTintedScaledBitmap(AllegroBitmap^ bitmap, AllegroColor^ tint, Single sx, Single sy, Single sw, Single sh, Single dx, Single dy, Single dw, Single dh, BitmapFlip flags)
	{
		auto* nativeBitmap = bitmap->GetNativePointer();
		auto* nativeTint = tint->GetNativePointer();
		auto nativeFlags = static_cast<int>(flags);
		al_draw_tinted_scaled_bitmap(nativeBitmap, *nativeTint, sx, sy, sw, sh, dx, dy, dw, dh, nativeFlags);
	}

	void Al::DrawTintedScaledRotatedBitmap(AllegroBitmap^ bitmap, AllegroColor^ tint, Single cx, Single cy, Single dx, Single dy, Single xScale, Single yScale, Single angle, BitmapFlip flags)
	{
		auto* nativeBitmap = bitmap->GetNativePointer();
		auto* nativeTint = tint->GetNativePointer();
		auto nativeFlags = static_cast<int>(flags);
		al_draw_tinted_scaled_rotated_bitmap(nativeBitmap, *nativeTint, cx, cy, dx, dy, xScale, yScale, angle, nativeFlags);
	}

	void Al::DrawTintedScaledRotatedBitmapRegion(AllegroBitmap^ bitmap, Single sx, Single sy, Single sw, Single sh, AllegroColor^ tint, Single cx, Single cy, Single dx, Single dy, Single xScale, Single yScale, Single angle, BitmapFlip flags)
	{
		auto* nativeBitmap = bitmap->GetNativePointer();
		auto* nativeTint = tint->GetNativePointer();
		auto nativeFlags = static_cast<int>(flags);
		al_draw_tinted_scaled_rotated_bitmap_region(nativeBitmap, sx, sy, sw, sh, *nativeTint, cx, cy, dx, dy, xScale, yScale, angle, nativeFlags);
	}

	void Al::PutBlendedPixel(Int32 x, Int32 y, AllegroColor^ color)
	{
		auto* nativeColor = color->GetNativePointer();
		al_put_blended_pixel(x, y, *nativeColor);
	}

	void Al::PutPixel(Int32 x, Int32 y, AllegroColor^ color)
	{
		auto* nativeColor = color->GetNativePointer();
		al_put_pixel(x, y, *nativeColor);
	}

	// target bitmap
	AllegroDisplay^ Al::GetCurrentDisplay()
	{
		auto* nativeDisplay = al_get_current_display();
		return gcnew AllegroDisplay(nativeDisplay);
	}

	void Al::SetTargetBackbuffer(AllegroDisplay^ display)
	{
		auto* nativeDisplay = display->GetNativePointer();
		al_set_target_backbuffer(nativeDisplay);
	}

	void Al::SetTargetBitmap(AllegroBitmap^ bitmap)
	{
		auto* nativeBitmap = bitmap->GetNativePointer();
		al_set_target_bitmap(nativeBitmap);
	}

	// blending modes
	AllegroColor^ Al::GetBlendColor()
	{
		auto nativeReturnValue = al_get_blend_color();
		return gcnew AllegroColor(nativeReturnValue);
	}

	void Al::GetBlender([Out] BlenderOperation% op, [Out] BlenderFactor% src, [Out] BlenderFactor% dst)
	{
		int nativeOp, nativeSrc, nativeDst;
		al_get_blender(&nativeOp, &nativeSrc, &nativeDst);
		op = static_cast<BlenderOperation>(nativeOp);
		src = static_cast<BlenderFactor>(nativeSrc);
		dst = static_cast<BlenderFactor>(nativeDst);
	}

	void Al::GetSeparateBlender([Out] BlenderOperation% op, [Out] BlenderFactor% src, [Out] BlenderFactor% dst, [Out] BlenderOperation% alphaOp, [Out] BlenderFactor% alphaSrc, [Out] BlenderFactor% alphaDst)
	{
		int nativeOp, nativeSrc, nativeDst, nativeAlphaOp, nativeAlphaSrc, nativeAlphaDst;
		al_get_separate_blender(&nativeOp, &nativeSrc, &nativeDst, &nativeAlphaOp, &nativeAlphaSrc, &nativeAlphaDst);
		op = static_cast<BlenderOperation>(nativeOp);
		src = static_cast<BlenderFactor>(nativeSrc);
		dst = static_cast<BlenderFactor>(nativeDst);
		alphaOp = static_cast<BlenderOperation>(nativeAlphaOp);
		alphaSrc = static_cast<BlenderFactor>(nativeAlphaSrc);
		alphaDst = static_cast<BlenderFactor>(nativeAlphaDst);
	}

	void Al::SetBlender(BlenderOperation op, BlenderFactor src, BlenderFactor dst)
	{
		auto nativeOp = static_cast<int>(op);
		auto nativeSrc = static_cast<int>(src);
		auto nativeDst = static_cast<int>(dst);
		al_set_blender(nativeOp, nativeSrc, nativeDst);
	}

	void Al::SetBlendColor(AllegroColor^ color)
	{
		auto* nativeColor = color->GetNativePointer();
		al_set_blend_color(*nativeColor);
	}

	void Al::SetSeparateBlender(BlenderOperation op, BlenderFactor src, BlenderFactor dst, BlenderOperation alphaOp, BlenderFactor alphaSrc, BlenderFactor alphaDst)
	{
		auto nativeOp = static_cast<int>(op);
		auto nativeSrc = static_cast<int>(src);
		auto nativeDst = static_cast<int>(dst);
		auto nativeAlphaOp = static_cast<int>(alphaOp);
		auto nativeAlphaSrc = static_cast<int>(alphaSrc);
		auto nativeAlphaDst = static_cast<int>(alphaDst);
		al_set_separate_blender(nativeOp, nativeSrc, nativeDst, nativeAlphaOp, nativeAlphaSrc, nativeAlphaDst);
	}

	// clipping
	void Al::GetClippingRectangle([Out] Int32% x, [Out] Int32% y, [Out] Int32% w, [Out] Int32% h)
	{
		int nX, nY, nW, nH;
		al_get_clipping_rectangle(&nX, &nY, &nW, &nH);
		x = nX;
		y = nY;
		w = nW;
		h = nH;
	}

	void Al::ResetClippingRectangle()
	{
		al_reset_clipping_rectangle();
	}

	void Al::SetClippingRectangle(Int32 x, Int32 y, Int32 w, Int32 h)
	{
		al_set_clipping_rectangle(x, y, w, h);
	}

	// graphics utility functions
	void Al::ConvertMaskToAlpha(AllegroBitmap^ bitmap, AllegroColor^ maskColor)
	{
		auto* nativeBitmap = bitmap->GetNativePointer();
		auto* nativeMaskColor = maskColor->GetNativePointer();
		al_convert_mask_to_alpha(nativeBitmap, *nativeMaskColor);
	}

	// deferred drawing
	Boolean Al::IsBitmapDrawingHeld()
	{
		return al_is_bitmap_drawing_held();
	}

	void Al::HoldBitmapDrawing(Boolean hold)
	{
		al_hold_bitmap_drawing(hold);
	}

	// image I/O
	AllegroBitmap^ Al::LoadBitmapA(String^ filename)
	{
		marshal_context marshalContext;
		auto const* nativeFilename = marshalContext.marshal_as<const char*>(filename);
		auto* nativeReturnValue = al_load_bitmap(nativeFilename);
		return gcnew AllegroBitmap(nativeReturnValue);
	}

	AllegroBitmap^ Al::LoadBitmapF(AllegroFile^ fp, String^ ident)
	{
		auto* nativeFp = fp->GetNativePointer();
		marshal_context marshalContext;
		auto const* nativeIdent = marshalContext.marshal_as<const char*>(ident);
		auto* nativeReturnValue = al_load_bitmap_f(nativeFp, nativeIdent);
		return gcnew AllegroBitmap(nativeReturnValue);
	}

	AllegroBitmap^ Al::LoadBitmapFlags(String^ filename, BitmapLoadFlags flags)
	{
		marshal_context marshalContext;
		auto const* nativeFilename = marshalContext.marshal_as<const char*>(filename);
		auto nativeFlags = static_cast<int>(flags);
		auto* nativeReturnValue = al_load_bitmap_flags(nativeFilename, nativeFlags);
		return gcnew AllegroBitmap(nativeReturnValue);
	}

	AllegroBitmap^ Al::LoadBitmapFlagsF(AllegroFile^ fp, String^ ident, BitmapLoadFlags flags)
	{
		auto* nativeFp = fp->GetNativePointer();
		marshal_context marshalContext;
		auto const* nativeIdent = marshalContext.marshal_as<const char*>(ident);
		auto nativeFlags = static_cast<int>(flags);
		auto* nativeReturnValue = al_load_bitmap_flags_f(nativeFp, nativeIdent, nativeFlags);
		return gcnew AllegroBitmap(nativeReturnValue);
	}

	Boolean Al::RegisterBitmapIdentifier(String^ extension, Func<AllegroFile^, Boolean>^ identifier)
	{
		marshal_context marshalContext;
		auto const* nativeExtension = marshalContext.marshal_as<const char*>(extension);
		// register...
		return false;
	}

	Boolean Al::RegisterBitmapLoader(String^ extension, Func<String^, Int32, AllegroBitmap^>^ loader)
	{
		marshal_context marshalContext;
		auto const* nativeExtension = marshalContext.marshal_as<const char*>(extension);
		// register
		return false;
	}

	Boolean Al::RegisterBitmapLoaderF(String^ extension, Func<AllegroFile^, Int32, AllegroBitmap^>^ loader)
	{
		marshal_context marshalContext;
		auto const* nativeExtension = marshalContext.marshal_as<const char*>(extension);
		// register
		return false;
	}

	Boolean Al::RegisterBitmapSaver(String^ extension, Func<String^, Int32, Boolean>^ saver)
	{
		marshal_context marshalContext;
		auto const* nativeExtension = marshalContext.marshal_as<const char*>(extension);
		// register
		return false;
	}

	Boolean Al::RegisterBitmapSaverF(String^ extension, Func<AllegroFile^, AllegroBitmap^, Boolean>^ saver)
	{
		marshal_context marshalContext;
		auto const* nativeExtension = marshalContext.marshal_as<const char*>(extension);
		// register
		return false;
	}

	Boolean Al::SaveBitmap(String^ filename, AllegroBitmap^ bitmap)
	{
		marshal_context marshalContext;
		auto const* nativeFilename = marshalContext.marshal_as<const char*>(filename);
		auto* nativeBitmap = bitmap->GetNativePointer();
		return al_save_bitmap(nativeFilename, nativeBitmap);
	}

	Boolean Al::SaveBitmapF(AllegroFile^ fp, String^ ident, AllegroBitmap^ bitmap)
	{
		auto* nativeFp = fp->GetNativePointer();
		marshal_context marshalContext;
		auto const* nativeIdent = marshalContext.marshal_as<const char*>(ident);
		auto* nativeBitmap = bitmap->GetNativePointer();
		return al_save_bitmap_f(nativeFp, nativeIdent, nativeBitmap);
	}

	String^ Al::IdentifyBitmap(String^ filename)
	{
		marshal_context marshalContext;
		auto const* nativeFilename = marshalContext.marshal_as<const char*>(filename);
		auto const* nativeReturnValue = al_identify_bitmap(nativeFilename);
		return gcnew String(nativeReturnValue);
	}

	String^ Al::IdentifyBitmapF(AllegroFile^ fp)
	{
		auto* nativeFp = fp->GetNativePointer();
		auto const* nativeReturnValue = al_identify_bitmap_f(nativeFp);
		return gcnew String(nativeReturnValue);
	}

	// render state
	void Al::SetRenderState(RenderState state, Int32 value)
	{
		ALLEGRO_RENDER_STATE renderState;
		switch (state)
		{
			case RenderState::AlphaFunction:
				renderState = ALLEGRO_RENDER_STATE::ALLEGRO_ALPHA_FUNCTION;
				break;

			case RenderState::AlphaTest:
				renderState = ALLEGRO_RENDER_STATE::ALLEGRO_ALPHA_TEST;
				break;

			case RenderState::AlphaTestValue:
				renderState = ALLEGRO_RENDER_STATE::ALLEGRO_ALPHA_TEST_VALUE;
				break;

			case RenderState::DepthFunction:
				renderState = ALLEGRO_RENDER_STATE::ALLEGRO_DEPTH_FUNCTION;
				break;

			case RenderState::DepthTest:
				renderState = ALLEGRO_RENDER_STATE::ALLEGRO_DEPTH_TEST;
				break;

			case RenderState::WriteMask:
				renderState = ALLEGRO_RENDER_STATE::ALLEGRO_WRITE_MASK;
				break;
		}
		al_set_render_state(renderState, value);
	}
}