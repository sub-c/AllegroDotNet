#pragma once

#include "PCH.h"

namespace AllegroDotNet::Wrapper
{
	using namespace System;

	public enum class DisplayOption : Int32
	{
		AccAlphaSize = ALLEGRO_ACC_ALPHA_SIZE,
		AccBlueSize = ALLEGRO_ACC_BLUE_SIZE,
		AccGreenSize = ALLEGRO_ACC_GREEN_SIZE,
		AccRedSize = ALLEGRO_ACC_RED_SIZE,
		AlphaShift = ALLEGRO_ALPHA_SHIFT,
		AlphaSize = ALLEGRO_ALPHA_SIZE,
		AutoConvertBitmaps = ALLEGRO_AUTO_CONVERT_BITMAPS,
		AuxBuffers = ALLEGRO_AUX_BUFFERS,
		BlueShift = ALLEGRO_BLUE_SHIFT,
		BlueSize = ALLEGRO_BLUE_SIZE,
		CanDrawIntoBitmap = ALLEGRO_CAN_DRAW_INTO_BITMAP,
		ColorSize = ALLEGRO_COLOR_SIZE,
		CompatibleDisplay = ALLEGRO_COMPATIBLE_DISPLAY,
		DepthSize = ALLEGRO_DEPTH_SIZE,
		FloatColor = ALLEGRO_FLOAT_COLOR,
		FloatDepth = ALLEGRO_FLOAT_DEPTH,
		GreenShift = ALLEGRO_GREEN_SHIFT,
		GreenSize = ALLEGRO_GREEN_SIZE,
		MaxBitmapSize = ALLEGRO_MAX_BITMAP_SIZE,
		OpenGLMajorVersion = ALLEGRO_OPENGL_MAJOR_VERSION,
		OpenGLMinorVersion = ALLEGRO_OPENGL_MINOR_VERSION,
		RedShift = ALLEGRO_RED_SHIFT,
		RedSize = ALLEGRO_RED_SIZE,
		RenderMethod = ALLEGRO_RENDER_METHOD,
		SampleBuffers = ALLEGRO_SAMPLE_BUFFERS,
		Samples = ALLEGRO_SAMPLES,
		SingleBuffer = ALLEGRO_SINGLE_BUFFER,
		StencilSize = ALLEGRO_STENCIL_SIZE,
		Stereo = ALLEGRO_STEREO,
		SupportedOrientations = ALLEGRO_SUPPORTED_ORIENTATIONS,
		SupportNpotBitmap = ALLEGRO_SUPPORT_NPOT_BITMAP,
		SupportSeparateAlpha = ALLEGRO_SUPPORT_SEPARATE_ALPHA,
		SwapMethod = ALLEGRO_SWAP_METHOD,
		UpdateDisplayRegion = ALLEGRO_UPDATE_DISPLAY_REGION,
		VSync = ALLEGRO_VSYNC
	};
}
