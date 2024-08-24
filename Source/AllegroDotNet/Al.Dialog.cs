using SubC.AllegroDotNet.Enums;
using SubC.AllegroDotNet.Models;
using SubC.AllegroDotNet.Native;

namespace SubC.AllegroDotNet;

/// <summary>
/// This static class contains the Allegro 5 library methods.
/// </summary>
public static partial class Al
{
    public static bool InitNativeDialogAddon()
    {
        return Interop.Dialog.AlInitNativeDialogAddon() != 0;
    }

    public static bool IsNativeDialogAddonInitialized()
    {
        return Interop.Dialog.AlIsNativeDialogAddonInitialized() != 0;
    }

    public static void ShutdownNativeDialogAddon()
    {
        Interop.Dialog.AlShutdownNativeDialogAddon();
    }

    public static AllegroFileChooser? CreateNativeFileDialog(string initialPath, string title, string patterns, FileChooserFlags flags)
    {
        using var nativeInitialPath = new CStringAnsi(initialPath);
        using var nativeTitle = new CStringAnsi(title);
        using var nativePatterns = new CStringAnsi(patterns);
        var pointer = Interop.Dialog.AlCreateNativeFileDialog(
          nativeInitialPath.Pointer,
          nativeTitle.Pointer,
          nativePatterns.Pointer,
          (int)flags);
        return NativePointer.Create<AllegroFileChooser>(pointer);
    }

    public static bool ShowNativeFileDialog(AllegroDisplay? display, AllegroFileChooser? dialog)
    {
        return Interop.Dialog.AlShowNativeFileDialog(NativePointer.Get(display), NativePointer.Get(dialog)) != 0;
    }

    public static int GetNativeFileDialogCount(AllegroFileChooser? dialog)
    {
        return Interop.Dialog.AlGetNativeFileDialogCount(NativePointer.Get(dialog));
    }

    public static string? GetNativeFileDialogPath(AllegroFileChooser? dialog, ulong i)
    {
        var pointer = Interop.Dialog.AlGetNativeFileDialogPath(NativePointer.Get(dialog), new UIntPtr(i));
        return CStringAnsi.ToCSharpString(pointer);
    }

    public static void DestroyNativeFileDialog(AllegroFileChooser? dialog)
    {
        Interop.Dialog.AlDestroyNativeFileDialog(NativePointer.Get(dialog));
    }

    public static MessageBoxResponse ShowNativeMessageBox(
      AllegroDisplay? display,
      string? title,
      string? heading,
      string? text,
      string? buttons,
      MessageBoxFlags flags)
    {
        using var nativeTitle = new CStringAnsi(title);
        using var nativeHeading = new CStringAnsi(heading);
        using var nativeText = new CStringAnsi(text);
        using var nativeButtons = new CStringAnsi(buttons);
        return (MessageBoxResponse)Interop.Dialog.AlShowNativeMessageBox(
          NativePointer.Get(display),
          nativeTitle.Pointer,
          nativeHeading.Pointer,
          nativeText.Pointer,
          nativeButtons.Pointer,
          (int)flags);
    }

    public static AllegroTextLog? OpenNativeTextLog(string? title, TextLogFlags flags)
    {
        using var nativeTitle = new CStringAnsi(title);
        var pointer = Interop.Dialog.AlOpenNativeTextLog(nativeTitle.Pointer, (int)flags);
        return NativePointer.Create<AllegroTextLog>(pointer);
    }

    public static void CloseNativeTextLog(AllegroTextLog? log)
    {
        Interop.Dialog.AlCloseNativeTextLog(NativePointer.Get(log));
    }

    public static void AppendNativeTextLog(AllegroTextLog? log, string? s)
    {
        using var nativeS = new CStringAnsi(s);
        Interop.Dialog.AlAppendNativeTextLog(NativePointer.Get(log), nativeS.Pointer);
    }

    public static AllegroEventSource? GetNativeTextLogEventSource(AllegroTextLog? log)
    {
        var pointer = Interop.Dialog.AlGetNativeTextLogEventSource(NativePointer.Get(log));
        return NativePointer.Create<AllegroEventSource>(pointer);
    }

    public static uint GetAllegroNativeDialogVersion()
    {
        return Interop.Dialog.AlGetAllegroNativeDialogVersion();
    }

    public static AllegroMenu? CreateMenu()
    {
        var pointer = Interop.Dialog.AlCreateMenu();
        return NativePointer.Create<AllegroMenu>(pointer);
    }

    public static AllegroMenu? CreatePopupMenu()
    {
        var pointer = Interop.Dialog.AlCreatePopupMenu();
        return NativePointer.Create<AllegroMenu>(pointer);
    }

    public static AllegroMenu? BuildMenu(ref AllegroMenuInfo info)
    {
        var pointer = Interop.Dialog.AlBuildMenu(ref info);
        return NativePointer.Create<AllegroMenu>(pointer);
    }

    public static int AppendMenuItem(
      AllegroMenu? parent,
      string? title,
      ushort id,
      MenuItemFlags flags,
      AllegroBitmap? icon,
      AllegroMenu? submenu)
    {
        using var nativeTitle = new CStringAnsi(title);
        return Interop.Dialog.AlAppendMenuItem(
          NativePointer.Get(parent),
          nativeTitle.Pointer,
          id,
          (int)flags,
          NativePointer.Get(icon),
          NativePointer.Get(submenu));
    }

    public static int InsertMenuItem(
      AllegroMenu? parent,
      int pos,
      string? title,
      ushort id,
      MenuItemFlags flags,
      AllegroBitmap? icon,
      AllegroMenu? submenu)
    {
        using var nativeTitle = new CStringAnsi(title);
        return Interop.Dialog.AlInsertMenuItem(
          NativePointer.Get(parent),
          pos,
          nativeTitle.Pointer,
          id,
          (int)flags,
          NativePointer.Get(icon),
          NativePointer.Get(submenu));
    }

    public static bool RemoveMenuItem(AllegroMenu? menu, int pos)
    {
        return Interop.Dialog.AlRemoveMenuItem(NativePointer.Get(menu), pos) != 0;
    }

    public static AllegroMenu? CloneMenu(AllegroMenu? menu)
    {
        var pointer = Interop.Dialog.AlCloneMenu(NativePointer.Get(menu));
        return NativePointer.Create<AllegroMenu>(pointer);
    }

    public static AllegroMenu? CloneMenuForPopup(AllegroMenu? menu)
    {
        var pointer = Interop.Dialog.AlCloneMenuForPopup(NativePointer.Get(menu));
        return NativePointer.Create<AllegroMenu>(pointer);
    }

    public static void DestroyMenu(AllegroMenu? menu)
    {
        Interop.Dialog.AlDestroyMenu(NativePointer.Get(menu));
    }

    public static string? GetMenuItemCaption(AllegroMenu? menu, int pos)
    {
        var pointer = Interop.Dialog.AlGetMenuItemCaption(NativePointer.Get(menu), pos);
        return CStringAnsi.ToCSharpString(pointer);
    }

    public static void SetMenuItemCaption(AllegroMenu? menu, int pos, string? caption)
    {
        using var nativeCaption = new CStringAnsi(caption);
        Interop.Dialog.AlSetMenuItemCaption(NativePointer.Get(menu), pos, nativeCaption.Pointer);
    }

    public static int GetMenuItemFlags(AllegroMenu? menu, int pos)
    {
        return Interop.Dialog.AlGetMenuItemFlags(NativePointer.Get(menu), pos);
    }

    public static void SetMenuItemFlags(AllegroMenu? menu, int pos, MenuItemFlags flags)
    {
        Interop.Dialog.AlSetMenuItemFlags(NativePointer.Get(menu), pos, (int)flags);
    }

    public static AllegroBitmap? GetMenuItemIcon(AllegroMenu? menu, int pos)
    {
        var pointer = Interop.Dialog.AlGetMenuItemIcon(NativePointer.Get(menu), pos);
        return NativePointer.Create<AllegroBitmap>(pointer);
    }

    public static void SetMenuItemIcon(AllegroMenu? menu, int pos, AllegroBitmap? icon)
    {
        Interop.Dialog.AlSetMenuItemIcon(NativePointer.Get(menu), pos, NativePointer.Get(icon));
    }

    public static AllegroMenu? FindMenu(AllegroMenu? haystack, ushort id)
    {
        var pointer = Interop.Dialog.AlFindMenu(NativePointer.Get(haystack), id);
        return NativePointer.Create<AllegroMenu>(pointer);
    }

    public static bool FindMenuItem(AllegroMenu? haystack, ushort id, AllegroMenu? menu, ref int index)
    {
        var menuPointer = NativePointer.Get(menu);
        var result = Interop.Dialog.AlFindMenuItem(NativePointer.Get(haystack), id, ref menuPointer, ref index);
        if (menu is not null)
            menu.Pointer = menuPointer;
        return result != 0;
    }

    public static AllegroEventSource? GetDefaultMenuEventSource()
    {
        var pointer = Interop.Dialog.AlGetDefaultMenuEventSource();
        return NativePointer.Create<AllegroEventSource>(pointer);
    }

    public static AllegroEventSource? EnableMenuEventSource(AllegroMenu? menu)
    {
        var pointer = Interop.Dialog.AlEnableMenuEventSource(NativePointer.Get(menu));
        return NativePointer.Create<AllegroEventSource>(pointer);
    }

    public static void DisableMenuEventSource(AllegroMenu? menu)
    {
        Interop.Dialog.AlDisableMenuEventSource(NativePointer.Get(menu));
    }

    public static AllegroMenu? GetDisplayMenu(AllegroDisplay? display)
    {
        var pointer = Interop.Dialog.AlGetDisplayMenu(NativePointer.Get(display));
        return NativePointer.Create<AllegroMenu>(pointer);
    }

    public static bool SetDisplayMenu(AllegroDisplay? display, AllegroMenu? menu)
    {
        return Interop.Dialog.AlSetDisplayMenu(NativePointer.Get(display), NativePointer.Get(menu)) != 0;
    }

    public static bool PopupMenu(AllegroMenu? popup, AllegroDisplay? display)
    {
        return Interop.Dialog.AlPopupMenu(NativePointer.Get(popup), NativePointer.Get(display)) != 0;
    }

    public static AllegroMenu? RemoveDisplayMenu(AllegroDisplay? display)
    {
        var pointer = Interop.Dialog.AlRemoveDisplayMenu(NativePointer.Get(display));
        return NativePointer.Create<AllegroMenu>(pointer);
    }
}
