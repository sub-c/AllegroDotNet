using SubC.AllegroDotNet.Models;

namespace SubC.AllegroDotNet.Extensions
{
  public static class AllegroPathExtensions
  {
    public static void DestroyPath(this AllegroPath? path)
      => Al.DestroyPath(path);

    public static AllegroPath? ClonePath(this AllegroPath? path)
      => Al.ClonePath(path);

    public static bool JoinPaths(this AllegroPath? path, AllegroPath? tailPath)
      => Al.JoinPaths(path, tailPath);

    public static bool RebasePath(this AllegroPath? headPath, AllegroPath? tailPath)
      => Al.RebasePath(headPath, tailPath);

    public static string? GetPathDrive(this AllegroPath? path)
      => Al.GetPathDrive(path);

    public static int GetPathNumComponents(this AllegroPath? path)
      => Al.GetPathNumComponents(path);

    public static string? GetPathComponent(this AllegroPath? path, int index)
      => Al.GetPathComponent(path, index);

    public static string? GetPathTail(this AllegroPath? path)
      => Al.GetPathTail(path);

    public static string? GetPathFilename(this AllegroPath? path)
      => Al.GetPathFilename(path);

    public static string? GetPathBasename(this AllegroPath? path)
      => Al.GetPathBasename(path);

    public static string? GetPathExtension(this AllegroPath? path)
      => Al.GetPathExtension(path);

    public static void SetPathDrive(this AllegroPath? path, string drive)
      => Al.SetPathDrive(path, drive);

    public static void AppendPathComponent(this AllegroPath? path, string directory)
      => Al.AppendPathComponent(path, directory);

    public static void InsertPathComponent(this AllegroPath? path, int index, string component)
      => Al.InsertPathComponent(path, index, component);

    public static void ReplacePathComponent(this AllegroPath? path, int index, string component)
      => Al.ReplacePathComponent(path, index, component);

    public static void RemovePathComponent(this AllegroPath? path, int index)
      => Al.RemovePathComponent(path, index);

    public static void DropPathTail(this AllegroPath? path)
      => Al.DropPathTail(path);

    public static void SetPathFilename(this AllegroPath? path, string filename)
      => Al.SetPathFilename(path, filename);

    public static bool SetPathExtension(this AllegroPath? path, string extension)
      => Al.SetPathExtension(path, extension);

    public static string? PathCstr(this AllegroPath? path, char deliminator)
      => Al.PathCstr(path, deliminator);

    public static string? PathCstr(this AllegroPath? path)
      => Al.PathCstr(path, Al.ALLEGRO_NATIVE_PATH_SEP);

    public static AllegroUstr? PathUstr(this AllegroPath? path, char deliminator)
      => Al.PathUstr(path, deliminator);

    public static AllegroUstr? PathUstr(this AllegroPath? path)
      => Al.PathUstr(path, Al.ALLEGRO_NATIVE_PATH_SEP);

    public static bool MakePathCanonical(this AllegroPath? path)
      => Al.MakePathCanonical(path);
  }
}
