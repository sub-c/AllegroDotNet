#pragma once

#include "PCH.h"

#include "AllegroEventSource.h"

namespace AllegroDotNet::Wrapper
{
	public ref class AllegroUserEvent
	{
	public:
		property Object^ Data1
		{
			Object^ get()
			{
				return data1_;
			}

			void set(Object^ value)
			{
				data1_ = value;
			}
		}

		property Object^ Data2
		{
			Object^ get()
			{
				return data2_;
			}

			void set(Object^ value)
			{
				data2_ = value;
			}
		}

		property Object^ Data3
		{
			Object^ get()
			{
				return data3_;
			}

			void set(Object^ value)
			{
				data3_ = value;
			}
		}

		property Object^ Data4
		{
			Object^ get()
			{
				return data4_;
			}

			void set(Object^ value)
			{
				data4_ = value;
			}
		}

		property AllegroEventSource^ Source
		{
			AllegroEventSource^ get()
			{
				return source_;
			}

			void set(AllegroEventSource^ value)
			{
				source_ = value;
			}
		}

		property UInt32 Type
		{
			UInt32 get()
			{
				return type_;
			}

			void set(UInt32 value)
			{
				type_ = value;
			}
		}

	internal:
		AllegroUserEvent(ALLEGRO_EVENT* nativeSourceEvent)
		{
			nativeSourceEvent_ = nativeSourceEvent;
		}

	private:
		Object^ data1_ { nullptr };
		Object^ data2_ { nullptr };
		Object^ data3_ { nullptr };
		Object^ data4_ { nullptr };
		ALLEGRO_EVENT* nativeSourceEvent_ { nullptr };
		AllegroEventSource^ source_ { nullptr };
		ALLEGRO_EVENT_TYPE type_ { 0 };
	};
}
