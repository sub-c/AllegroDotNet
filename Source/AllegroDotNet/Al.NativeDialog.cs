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

    public static AllegroMenu? CreateMenu()
    {
      var nativeMenu = NativeFunctions.AlCreateMenu();
      return NativePointerModel.Create<AllegroMenu>(nativeMenu);
    }

    public static AllegroMenu? CreatePopupMenu()
    {
      var nativeMenu = NativeFunctions.AlCreatePopupMenu();
      return NativePointerModel.Create<AllegroMenu>(nativeMenu);
    }

    public static AllegroMenu? BuildMenu(AllegroMenuInfo? info)
    {
      throw new NotImplementedException();
    }

    public static int AppendMenuItem(AllegroMenu? parent, string title, ushort id, MenuItem flags, AllegroBitmap? icon, AllegroMenu? submenu)
    {
      var nativeTitle = Marshal.StringToHGlobalAnsi(title);
      var result = NativeFunctions.AlAppendMenuItem(
        NativePointerModel.GetPointer(parent),
        nativeTitle,
        id,
        (int)flags,
        NativePointerModel.GetPointer(icon),
        NativePointerModel.GetPointer(submenu));
      Marshal.FreeHGlobal(nativeTitle);
      return result;
    }

    public static int InsertMenuItem(
      AllegroMenu? parent,
      int position,
      string title,
      ushort id,
      MenuItem flags,
      AllegroBitmap? icon,
      AllegroMenu? submenu)
    {
      var nativeTitle = Marshal.StringToHGlobalAnsi(title);
      var result = NativeFunctions.AlInsertMenuItem(
        NativePointerModel.GetPointer(parent),
        position,
        nativeTitle,
        id,
        (int)flags,
        NativePointerModel.GetPointer(icon),
        NativePointerModel.GetPointer(submenu));
      Marshal.FreeHGlobal(nativeTitle);
      return result;
    }

    public static bool RemoveMenuItem(AllegroMenu? menu, int position)
    {
      return NativeFunctions.AlRemoveMenuItem(NativePointerModel.GetPointer(menu), position);
    }

    public static AllegroMenu? CloneMenu(AllegroMenu? menu)
    {
      var nativeMenu = NativeFunctions.AlCloneMenu(NativePointerModel.GetPointer(menu));
      return NativePointerModel.Create<AllegroMenu>(nativeMenu);
    }

    public static AllegroMenu? CloneMenuForPopup(AllegroMenu? menu)
    {
      var nativeMenu = NativeFunctions.AlCloneMenuForPopup(NativePointerModel.GetPointer(menu));
      return NativePointerModel.Create<AllegroMenu>(nativeMenu);
    }

    public static void DestroyMenu(AllegroMenu? menu)
    {
      NativeFunctions.AlDestroyMenu(NativePointerModel.GetPointer(menu));
    }

    public static string? GetMenuItemCaption(AllegroMenu? menu, int position)
    {
      var nativeCaption = NativeFunctions.AlGetMenuItemCaption(NativePointerModel.GetPointer(menu), position);
      return Marshal.PtrToStringAnsi(nativeCaption);
    }

    public static void SetMenuItemCaption(AllegroMenu? menu, int position, string caption)
    {
      var nativeCaption = Marshal.StringToHGlobalAnsi(caption);
      NativeFunctions.AlSetMenuItemCaption(NativePointerModel.GetPointer(menu), position, nativeCaption);
      Marshal.FreeHGlobal(nativeCaption);
    }

    public static MenuItem GetMenuItemFlags(AllegroMenu? menu, int position)
    {
      return (MenuItem)NativeFunctions.AlGetMenuItemFlags(NativePointerModel.GetPointer(menu), position);
    }

    public static void SetMenuItemFlags(AllegroMenu? menu, int position, MenuItem flags)
    {
      NativeFunctions.AlSetMenuItemFlags(NativePointerModel.GetPointer(menu), position, (int)flags);
    }

    public static AllegroBitmap? GetMenuItemIcon(AllegroMenu? menu, int position)
    {
      var nativeBitmap = NativeFunctions.AlGetMenuItemIcon(NativePointerModel.GetPointer(menu), position);
      return NativePointerModel.Create<AllegroBitmap>(nativeBitmap);
    }

    public static void SetMenuItemIcon(AllegroMenu? menu, int position, AllegroBitmap? icon)
    {
      NativeFunctions.AlSetMenuItemIcon(NativePointerModel.GetPointer(menu), position, NativePointerModel.GetPointer(icon));
    }

    public static AllegroMenu? FindMenu(AllegroMenu? haystack, ushort id)
    {
      var nativeMenu = NativeFunctions.AlFindMenu(NativePointerModel.GetPointer(haystack), id);
      return NativePointerModel.Create<AllegroMenu>(nativeMenu);
    }

    public static bool FindMenuItem(AllegroMenu haystack, ushort id, AllegroMenu menu, ref int? index)
    {
      int nativeIndex = index == null ? 0 : index.Value;
      var result = NativeFunctions.AlFindMenuItem(
        NativePointerModel.GetPointer(haystack),
        id,
        ref menu.NativePointer,
        ref nativeIndex);
      if (index != null)
      {
        index = nativeIndex;
      }
      return result;
    }

    public static AllegroEventSource? GetDefaultMenuEventSource()
    {
      var nativeSource = NativeFunctions.AlGetDefaultMenuEventSource();
      return NativePointerModel.Create<AllegroEventSource>(nativeSource);
    }

    public static AllegroEventSource? EnableMenuEventSource(AllegroMenu? menu)
    {
      var nativeSource = NativeFunctions.AlEnableMenuEventSource(NativePointerModel.GetPointer(menu));
      return NativePointerModel.Create<AllegroEventSource>(nativeSource);
    }

    public static void DisableMenuEventSource(AllegroMenu? menu)
    {
      NativeFunctions.AlDisableMenuEventSource(NativePointerModel.GetPointer(menu));
    }

    public static AllegroMenu? GetDisplayMenu(AllegroDisplay? display)
    {
      var nativeMenu = NativeFunctions.AlGetDisplayMenu(NativePointerModel.GetPointer(display));
      return NativePointerModel.Create<AllegroMenu>(nativeMenu);
    }

    public static bool SetDisplayMenu(AllegroDisplay? display, AllegroMenu? menu)
    {
      return NativeFunctions.AlSetDisplayMenu(NativePointerModel.GetPointer(display), NativePointerModel.GetPointer(menu));
    }

    public static bool PopupMenu(AllegroMenu? popupMenu, AllegroDisplay? display)
    {
      return NativeFunctions.AlPopupMenu(NativePointerModel.GetPointer(popupMenu), NativePointerModel.GetPointer(display));
    }

    public static AllegroMenu? RemoveDisplayMenu(AllegroDisplay? display)
    {
      var nativeMenu = NativeFunctions.AlRemoveDisplayMenu(NativePointerModel.GetPointer(display));
      return NativePointerModel.Create<AllegroMenu>(nativeMenu);
    }
  }
}