using SubC.AllegroDotNet.Models;
using SubC.AllegroDotNet.Native;

namespace SubC.AllegroDotNet;

public static partial class Al
{
  /// <summary>
  /// This function sets both the <see cref="AllegroFileInterface"/> and <see cref="AllegroFsInterface"/> for the calling thread.
  /// Subsequent calls to al_fopen on the calling thread will be handled by PHYSFS_open(). Operations on the files returned by
  /// al_fopen will then be performed through PhysicsFS. Calls to the Allegro filesystem functions, such as al_read_directory
  /// or al_create_fs_entry, on the calling thread will be diverted to PhysicsFS.
  /// To remember and restore another file I/O backend, you can use al_store_state/al_restore_state.
  /// </summary>
  public static void SetPhysfsFileInterface()
  {
    NativeFunctions.AlSetPhysfsFileInterface();
  }

  /// <summary>
  /// Gets the compiled version of the PhysFS addon.
  /// </summary>
  /// <returns>The compiled version of the PhysFS addon, in the same format as <see cref="Al.GetAllegroVersion"/></returns>
  public static uint GetAllegroPhysfsVersion()
  {
    return NativeFunctions.AlGetAllegroPhysfsVersion();
  }
}
