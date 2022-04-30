using SubC.AllegroDotNet.Enums;
using SubC.AllegroDotNet.Models;
using SubC.AllegroDotNet.Native;
using System;
using System.Runtime.InteropServices;

namespace SubC.AllegroDotNet
{
  public static partial class Al
  {
    public static bool InitNativeDialogAddon()
    {
      return NativeFunctions.AlInitNativeDialogAddon();
    }

    public static bool IsNativeDialogAddonInitialized()
    {
      return NativeFunctions.AlIsNativeDialogAddonInitialized();
    }

    public static void ShutdownNativeDialogAddon()
    {
      NativeFunctions.AlShutdownNativeDialogAddon();
    }

    public static AllegroFileChooser? CreateNativeFileDialog(string initialPath, string title, string pattern, FileChooser mode)
    {
      var nativeInitialPath = Marshal.StringToHGlobalAnsi(initialPath);
      var nativeTitle = Marshal.StringToHGlobalAnsi(title);
      var nativePattern = Marshal.StringToHGlobalAnsi(pattern);
      var nativeChooser = NativeFunctions.AlCreateNativeFileDialog(nativeInitialPath, nativeTitle, nativePattern, (int)mode);
      Marshal.FreeHGlobal(nativePattern);
      Marshal.FreeHGlobal(nativeTitle);
      Marshal.FreeHGlobal(nativeInitialPath);
      return NativePointerModel.Create<AllegroFileChooser>(nativeChooser);
    }

    public static bool ShowNativeFileDialog(AllegroDisplay display, AllegroFileChooser fileChooser)
    {
      return NativeFunctions.AlShowNativeFileDialog(display.NativePointer, fileChooser.NativePointer);
    }

    public static int GetNativeFileDialogCount(AllegroFileChooser fileChooser)
    {
      return NativeFunctions.AlGetNativeFileDialogCount(fileChooser.NativePointer);
    }

    public static string? GetNativeFileDialogPath(AllegroFileChooser fileChooser, ulong index)
    {
      var nativePath = NativeFunctions.AlGetNativeFileDialogPath(fileChooser.NativePointer, index);
      return Marshal.PtrToStringAnsi(nativePath);
    }

    public static void DestroyNativeFileDialog(AllegroFileChooser fileChooser)
    {
      NativeFunctions.AlDestroyNativeFileDialog(fileChooser.NativePointer);
    }

    public static MessageBoxResponse ShowNativeMessageBox(AllegroDisplay? display, string title, string heading, string text, string? buttons, MessageBoxFlags flags)
    {
      var nativeDisplay = display == null ? IntPtr.Zero : display.NativePointer;
      var nativeTitle = Marshal.StringToHGlobalAnsi(title);
      var nativeHeading = Marshal.StringToHGlobalAnsi(heading);
      var nativeText = Marshal.StringToHGlobalAnsi(text);
      var nativeButtons = buttons == null ? IntPtr.Zero : Marshal.StringToHGlobalAnsi(buttons);
      var value = NativeFunctions.AlShowNativeMessageBox(nativeDisplay, nativeTitle, nativeHeading, nativeText, nativeButtons, (int)flags);
      if (nativeButtons != IntPtr.Zero)
      {
        Marshal.FreeHGlobal(nativeButtons);
      }
      Marshal.FreeHGlobal(nativeText);
      Marshal.FreeHGlobal(nativeHeading);
      Marshal.FreeHGlobal(nativeTitle);
      return (MessageBoxResponse)value;
    }

    public static AllegroTextLog? OpenNativeTextLog(string title, TextLogFlags flags)
    {
      var nativeTitle = Marshal.StringToHGlobalAnsi(title);
      var nativeTextLog = NativeFunctions.AlOpenNativeTextLog(nativeTitle, (int)flags);
      Marshal.FreeHGlobal(nativeTitle);
      return NativePointerModel.Create<AllegroTextLog>(nativeTextLog);
    }

    public static void CloseNativeTextLog(AllegroTextLog textLog)
    {
      NativeFunctions.AlCloseNativeTextLog(textLog.NativePointer);
    }

    public static void AppendNativeTextLog(AllegroTextLog textLog, string format)
    {
      var nativeFormat = Marshal.StringToHGlobalAnsi(format);
      NativeFunctions.AlAppendNativeTextLog(textLog.NativePointer, nativeFormat);
      Marshal.FreeHGlobal(nativeFormat);
    }

    public static AllegroEventSource? GetNativeTextLogEventSource(AllegroTextLog textLog)
    {
      var nativeSource = NativeFunctions.AlGetNativeTextLogEventSource(textLog.NativePointer);
      return NativePointerModel.Create<AllegroEventSource>(nativeSource);
    }

    public static uint GetAllegroNativeDialogVersion()
    {
      return NativeFunctions.AlGetAllegroNativeDialogVersion();
    }
  }
}