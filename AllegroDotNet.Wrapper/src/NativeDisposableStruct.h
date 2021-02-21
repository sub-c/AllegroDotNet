#pragma once

namespace AllegroDotNet::Wrapper
{
	using namespace System;

	template <typename T>
	public ref class NativeDisposableStruct
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
		NativeDisposableStruct()
		{
			SetNativePointer(new T());
		}

		virtual ~NativeDisposableStruct()
		{
			if (isDisposed_)
			{
				return;
			}
			this->!NativeDisposableStruct();
			isDisposed_ = true;
		}

		!NativeDisposableStruct()
		{
			delete GetNativePointer();
			SetNativePointer(nullptr);
		}

	private:
		Boolean isDisposed_ { false };
		IntPtr nativePointer_ { IntPtr(nullptr) };
	};
}
