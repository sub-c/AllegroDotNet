using SubC.AllegroDotNet.Models;
using SubC.AllegroDotNet.Native;

namespace SubC.AllegroDotNet;

/// <summary>
/// This static class contains the Allegro 5 library methods.
/// </summary>
public static partial class Al
{
  public static AllegroPath? CreatePath(string path)
  {
    using var nativePath = new CStringAnsi(path);
    var pointer = Interop.Core.AlCreatePath(nativePath.Pointer);
    return NativePointer.Create<AllegroPath>(pointer);
  }

  public static AllegroPath? CreatePathForDirectory(string path)
  {
    using var nativePath = new CStringAnsi(path);
    var pointer = Interop.Core.AlCreatePathForDirectory(nativePath.Pointer);
    return NativePointer.Create<AllegroPath>(pointer);
  }

  public static void DestroyPath(AllegroPath? path)
  {
    Interop.Core.AlDestroyPath(NativePointer.Get(path));
  }

  public static AllegroPath? ClonePath(AllegroPath? path)
  {
    var pointer = Interop.Core.AlClonePath(NativePointer.Get(path));
    return NativePointer.Create<AllegroPath>(pointer);
  }

  public static bool JoinPaths(AllegroPath? path, AllegroPath? tail)
  {
    return Interop.Core.AlJoinPaths(NativePointer.Get(path), NativePointer.Get(tail)) != 0;
  }

  public static bool RebasePath(AllegroPath? head, AllegroPath? tail)
  {
    return Interop.Core.AlRebasePath(NativePointer.Get(head), NativePointer.Get(tail)) != 0;
  }

  public static string? GetPathDrive(AllegroPath? path)
  {
    var pointer = Interop.Core.AlGetPathDrive(NativePointer.Get(path));
    return CStringAnsi.ToCSharpString(pointer);
  }

  public static int GetPathNumComponents(AllegroPath? path)
  {
    return Interop.Core.AlGetPathNumComponents(NativePointer.Get(path));
  }

  public static string? GetPathComponent(AllegroPath? path, int i)
  {
    var pointer = Interop.Core.AlGetPathComponent(NativePointer.Get(path), i);
    return CStringAnsi.ToCSharpString(pointer);
  }

  public static string? GetPathTail(AllegroPath? path)
  {
    var pointer = Interop.Core.AlGetPathTail(NativePointer.Get(path));
    return CStringAnsi.ToCSharpString(pointer);
  }

  public static string? GetPathFilename(AllegroPath? path)
  {
    var pointer = Interop.Core.AlGetPathFilename(NativePointer.Get(path));
    return CStringAnsi.ToCSharpString(pointer);
  }

  public static string? GetPathBasename(AllegroPath? path)
  {
    var pointer = Interop.Core.AlGetPathBasename(NativePointer.Get(path));
    return CStringAnsi.ToCSharpString(pointer);
  }

  public static string? GetPathExtension(AllegroPath? path)
  {
    var pointer = Interop.Core.AlGetPathExtension(NativePointer.Get(path));
    return CStringAnsi.ToCSharpString(pointer);
  }

  public static void SetPathDrive(AllegroPath? path, string? drive)
  {
    using var nativeDrive = new CStringAnsi(drive);
    Interop.Core.AlSetPathDrive(NativePointer.Get(path), nativeDrive.Pointer);
  }

  public static void AppendPathComponent(AllegroPath? path, string? component)
  {
    using var nativeComponent = new CStringAnsi(component);
    Interop.Core.AlAppendPathComponent(NativePointer.Get(path), nativeComponent.Pointer);
  }

  public static void InsertPathComponent(AllegroPath? path, int i, string? component)
  {
    using var nativeComponent = new CStringAnsi(component);
    Interop.Core.AlInsertPathComponent(NativePointer.Get(path), i, nativeComponent.Pointer);
  }

  public static void ReplacePathComponent(AllegroPath? path, int i, string? component)
  {
    using var nativeComponent = new CStringAnsi(component);
    Interop.Core.AlReplacePathComponent(NativePointer.Get(path), i, nativeComponent.Pointer);
  }

  public static void RemovePathComponent(AllegroPath? path, int i)
  {
    Interop.Core.AlRemovePathComponent(NativePointer.Get(path), i);
  }

  public static void DropPathTail(AllegroPath? path)
  {
    Interop.Core.AlDropPathTail(NativePointer.Get(path));
  }

  public static void SetPathFilename(AllegroPath? path, string? filename)
  {
    using var nativeFilename = new CStringAnsi(filename);
    Interop.Core.AlSetPathFilename(NativePointer.Get(path), nativeFilename.Pointer);
  }

  public static bool SetPathExtension(AllegroPath? path, string? extension)
  {
    using var nativeExtension = new CStringAnsi(extension);
    return Interop.Core.AlSetPathExtension(NativePointer.Get(path), nativeExtension.Pointer) != 0;
  }

  public static string? PathCstr(AllegroPath? path, char delim)
  {
    var pointer = Interop.Core.AlPathCstr(NativePointer.Get(path), (byte)delim);
    return CStringAnsi.ToCSharpString(pointer);
  }

  public static AllegroUstr? PathUstr(AllegroPath? path, char delim)
  {
    var pointer = Interop.Core.AlPathUstr(NativePointer.Get(path), (byte)delim);
    return NativePointer.Create<AllegroUstr>(pointer);
  }

  public static bool MakePathCanonical(AllegroPath? path)
  {
    return Interop.Core.AlMakePathCanonical(NativePointer.Get(path)) != 0;
  }
}
