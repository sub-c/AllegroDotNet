namespace SubC.AllegroDotNet.Native;

public interface IInteropProvider
{
    T GetFunctionPointer<T>() where T : Delegate;
}
