using SubC.AllegroDotNet.Models;

namespace SubC.AllegroDotNet.Native;

/// <summary>
/// This static class contains the delegates used by Allegro 5 functions.
/// </summary>
public static class Delegates
{
  /// <summary>
  /// The delegate used as the at exit function.
  /// </summary>
  public delegate int AtExitDelegate(VoidDelegate voidDelegate);

  /// <summary>
  /// The delegate used as the bitmap identifier using an <see cref="AllegroFile"/>.
  /// </summary>
  public delegate byte BitmapIdentifierDelegate(IntPtr allegroFile);

  /// <summary>
  /// The delegate used to load a bitmap from a given filename.
  /// </summary>
  public delegate IntPtr BitmapLoaderDelegate(IntPtr filename, int flags);

  /// <summary>
  /// The delegate used to load a bitmap from a given <see cref="AllegroFile"/>.
  /// </summary>
  public delegate IntPtr BitmapLoaderFDelegate(IntPtr allegroFile, int flags);

  /// <summary>
  /// The delegate used to save a bitmap to a given filename.
  /// </summary>
  public delegate byte BitmapSaverDelegate(IntPtr filename, IntPtr bitmap);

  /// <summary>
  /// The delegate used to save a bitmap to a given <see cref="AllegroFile"/>.
  /// </summary>
  public delegate byte BitmapSaverFDelegate(IntPtr allegroFile, IntPtr bitmap);
  
  /// <summary>
  /// The delegate used to handle asserts.
  /// </summary>
  public delegate void RegisterAssertHandlerDelegate(IntPtr expr, IntPtr file, int line, IntPtr func);
  
  /// <summary>
  /// The delegate used to handle traces.
  /// </summary>
  public delegate void RegisterTraceHandlerDelegate(IntPtr message);

  /// <summary>
  /// The delegate used to deconstruct/free data from a user event.
  /// </summary>
  public delegate void UserEventDeconstructor(IntPtr userEvent);
  
  /// <summary>
  /// The delegate invoked without parameters or a return value.
  /// </summary>
  public delegate void VoidDelegate();
}