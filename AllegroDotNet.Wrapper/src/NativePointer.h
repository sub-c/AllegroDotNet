#pragma once

namespace AllegroDotNet::Wrapper
{
	using namespace System;

	template <typename T>
	public ref class NativePointer
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
		T* GetNativePointer()
		{
			return static_cast<T*>(nativePointer_.ToPointer());
		}

		void SetNativePointer(T* nativePointer)
		{
			nativePointer_ = IntPtr(nativePointer);
		}

	protected:
		NativePointer(T* nativePointer)
		{
			SetNativePointer(nativePointer);
		}

	private:
		IntPtr nativePointer_ { IntPtr(nullptr) };
	};
}
