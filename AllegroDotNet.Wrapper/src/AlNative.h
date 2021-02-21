#pragma once

namespace AllegroDotNet::Wrapper
{
	class AlNative final
	{
	public:
		// System - AlNativeSystem.cpp
		static void native_assert_handler(const char* expr, const char* file, int line, const char* func);
		static void native_trace_handler(const char* message);
	};
}
