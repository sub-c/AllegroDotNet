using SubC.AllegroDotNet.Models;
using SubC.AllegroDotNet.Native;
using System.Runtime.InteropServices;

namespace SubC.AllegroDotNet
{
  public static partial class Al
  {
    public static AllegroPath? CreatePath(string pathString)
    {
      var nativeString = Marshal.StringToHGlobalAnsi(pathString);
      var nativePath = NativeFunctions.AlCreatePath(nativeString);
      Marshal.FreeHGlobal(nativeString);
      return NativePointerModel.Create<AllegroPath>(nativePath);
    }

    public static AllegroPath? CreatePathForDirectory(string directoryString)
    {
      var nativeString = Marshal.StringToHGlobalAnsi(directoryString);
      var nativePath = NativeFunctions.AlCreatePath(nativeString);
      Marshal.FreeHGlobal(nativeString);
      return NativePointerModel.Create<AllegroPath>(nativePath);
    }

    public static void DestroyPath(AllegroPath? path)
    {
      NativeFunctions.AlDestroyPath(NativePointerModel.GetPointer(path));
    }

    public static AllegroPath? ClonePath(AllegroPath? path)
    {
      var nativePath = NativeFunctions.AlClonePath(NativePointerModel.GetPointer(path));
      return NativePointerModel.Create<AllegroPath>(nativePath);
    }

    public static bool JoinPaths(AllegroPath? path, AllegroPath? tailPath)
    {
      return NativeFunctions.AlJoinPaths(NativePointerModel.GetPointer(path), NativePointerModel.GetPointer(tailPath));
    }

    public static bool RebasePath(AllegroPath? headPath, AllegroPath? tailPath)
    {
      return NativeFunctions.AlJoinPaths(NativePointerModel.GetPointer(headPath), NativePointerModel.GetPointer(tailPath));
    }

    public static string? GetPathDrive(AllegroPath? path)
    {
      var nativeValue = NativeFunctions.AlGetPathDrive(NativePointerModel.GetPointer(path));
      return Marshal.PtrToStringAnsi(nativeValue);
    }

    public static int GetPathNumComponents(AllegroPath? path)
    {
      return NativeFunctions.AlGetPathNumComponents(NativePointerModel.GetPointer(path));
    }

    public static string? GetPathComponent(AllegroPath? path, int i)
    {
      var nativeValue = NativeFunctions.AlGetPathComponent(NativePointerModel.GetPointer(path), i);
      return Marshal.PtrToStringAnsi(nativeValue);
    }

    public static string? GetPathTail(AllegroPath? path)
    {
      var nativeValue = NativeFunctions.AlGetPathTail(NativePointerModel.GetPointer(path));
      return Marshal.PtrToStringAnsi(nativeValue);
    }

    public static string? GetPathFilename(AllegroPath? path)
    {
      var nativeValue = NativeFunctions.AlGetPathFilename(NativePointerModel.GetPointer(path));
      return Marshal.PtrToStringAnsi(nativeValue);
    }

    public static string? GetPathBasename(AllegroPath? path)
    {
      var nativeValue = NativeFunctions.AlGetPathBasename(NativePointerModel.GetPointer(path));
      return Marshal.PtrToStringAnsi(nativeValue);
    }

    public static string? GetPathExtension(AllegroPath? path)
    {
      var nativeValue = NativeFunctions.AlGetPathExtension(NativePointerModel.GetPointer(path));
      return Marshal.PtrToStringAnsi(nativeValue);
    }

    public static void SetPathDrive(AllegroPath? path, string drive)
    {
      var nativeDrive = Marshal.StringToHGlobalAnsi(drive);
      NativeFunctions.AlSetPathDrive(NativePointerModel.GetPointer(path), nativeDrive);
      Marshal.FreeHGlobal(nativeDrive);
    }

    public static void AppendPathComponent(AllegroPath? path, string directory)
    {
      var nativeDirectory = Marshal.StringToHGlobalAnsi(directory);
      NativeFunctions.AlAppendPathComponent(NativePointerModel.GetPointer(path), nativeDirectory);
      Marshal.FreeHGlobal(nativeDirectory);
    }

    public static void InsertPathComponent(AllegroPath? path, int index, string component)
    {
      var nativeDirectory = Marshal.StringToHGlobalAnsi(component);
      NativeFunctions.AlInsertPathComponent(NativePointerModel.GetPointer(path), index, nativeDirectory);
      Marshal.FreeHGlobal(nativeDirectory);
    }

    public static void ReplacePathComponent(AllegroPath? path, int index, string component)
    {
      var nativeComponent = Marshal.StringToHGlobalAnsi(component);
      NativeFunctions.AlReplacePathComponent(NativePointerModel.GetPointer(path), index, nativeComponent);
      Marshal.FreeHGlobal(nativeComponent);
    }

    public static void RemovePathComponent(AllegroPath? path, int index)
    {
      NativeFunctions.AlRemovePathComponent(NativePointerModel.GetPointer(path), index);
    }

    public static void DropPathTail(AllegroPath? path)
    {
      NativeFunctions.AlDropPathTail(NativePointerModel.GetPointer(path));
    }

    public static void SetPathFilename(AllegroPath? path, string filename)
    {
      var nativeFilename = Marshal.StringToHGlobalAnsi(filename);
      NativeFunctions.AlSetPathFilename(NativePointerModel.GetPointer(path), nativeFilename);
      Marshal.FreeHGlobal(nativeFilename);
    }

    public static bool SetPathExtension(AllegroPath? path, string extension)
    {
      var nativeExtension = Marshal.StringToHGlobalAnsi(extension);
      var result = NativeFunctions.AlSetPathExtension(NativePointerModel.GetPointer(path), nativeExtension);
      Marshal.FreeHGlobal(nativeExtension);
      return result;
    }

    public static string? PathCstr(AllegroPath? path, char deliminator)
    {
      var nativeValue = NativeFunctions.AlPathCstr(NativePointerModel.GetPointer(path), deliminator);
      return Marshal.PtrToStringAnsi(nativeValue);
    }

    public static AllegroUstr? PathUstr(AllegroPath? path, char deliminator)
    {
      var nativeUstr = NativeFunctions.AlPathUstr(NativePointerModel.GetPointer(path), deliminator);
      return NativePointerModel.Create<AllegroUstr>(nativeUstr);
    }

    public static bool MakePathCanonical(AllegroPath? path)
    {
      return NativeFunctions.AlMakePathCanonical(NativePointerModel.GetPointer(path));
    }
  }
}