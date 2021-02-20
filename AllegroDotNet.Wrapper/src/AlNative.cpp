#include "PCH.h"

#include "Al.h"
#include "AlNative.h"

namespace AllegroDotNet::Wrapper
{

	void AlNative::native_assert_handler(const char* expr, const char* file, int line, const char* func)
	{
		auto managedExpr = gcnew String(expr);
		auto managedFile = gcnew String(file);
		auto managedFunc = gcnew String(func);
		Al::ManagedAssertHandler(managedExpr, managedFile, line, managedFunc);
	}

	void AlNative::native_trace_handler(const char* message)
	{
		auto managedMessage = gcnew String(message);
		Al::ManagedTraceHandler(managedMessage);
	}
}
