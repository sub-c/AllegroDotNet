using System;

namespace SubC.AllegroDotNet.Models
{
  public abstract class NativePointerModel
  {
    internal IntPtr NativePointer;

    internal static T? Create<T>(IntPtr nativePointer)
        where T : NativePointerModel, new()
    {
      return nativePointer == IntPtr.Zero
          ? null
          : new T { NativePointer = nativePointer };
    }

    internal static IntPtr GetPointer<T>(T? nativePointerModel)
      where T : NativePointerModel
    {
      return nativePointerModel == null
        ? IntPtr.Zero
        : nativePointerModel.NativePointer;
    }
  }
}