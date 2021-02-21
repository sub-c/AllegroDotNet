#pragma once

#include "PCH.h"

namespace AllegroDotNet::Wrapper
{
	using namespace System;

	[System::FlagsAttribute]
	public enum class DisplayFlags : Int32
	{
		Direct3D = ALLEGRO_DIRECT3D_INTERNAL,
		Frameless = ALLEGRO_FRAMELESS,
		FullScreen = ALLEGRO_FULLSCREEN,
		FullScreenWindow = ALLEGRO_FULLSCREEN_WINDOW,
		GenerateExposeEvents = ALLEGRO_GENERATE_EXPOSE_EVENTS,
		GtkTopLevel = ALLEGRO_GTK_TOPLEVEL_INTERNAL,
		Maximized = ALLEGRO_MAXIMIZED,
		NoFrame = ALLEGRO_NOFRAME,
		OpenGL = ALLEGRO_OPENGL,
		OpenGL30 = ALLEGRO_OPENGL_3_0,
		OpenGLESProfile = ALLEGRO_OPENGL_ES_PROFILE,
		OpenGLForwardCompatible = ALLEGRO_OPENGL_FORWARD_COMPATIBLE,
		ProgrammablePipeline = ALLEGRO_PROGRAMMABLE_PIPELINE,
		Resizable = ALLEGRO_RESIZABLE,
		Windowed = ALLEGRO_WINDOWED
	};
}
