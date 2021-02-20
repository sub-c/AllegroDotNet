#pragma once

namespace AllegroDotNet::Wrapper
{
	using namespace System;

	template <typename T>
	public ref class NativePointerWrapper
	{
	public:
		property Boolean IsNull
		{
			Boolean get()
			{
				return GetNativePointer() == nullptr;
			}
		}

	internal:
		T GetNativePointer()
		{
			return static_cast<T>(nativePointer_.ToPointer());
		}

		void SetNativePointer(T newPointer)
		{
			nativePointer_ = IntPtr(newPointer);
		}

	protected:
		NativePointerWrapper(T nativePointer)
		{
			SetNativePointer(nativePointer);
		}

		virtual ~NativePointerWrapper()
		{
		}

		!NativePointerWrapper()
		{
		}

	private:
		IntPtr nativePointer_ { IntPtr::Zero };
	};
}
