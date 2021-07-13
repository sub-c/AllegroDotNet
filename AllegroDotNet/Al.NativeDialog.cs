using System;
using System.Runtime.InteropServices;
using SubC.AllegroDotNet.Enums;
using SubC.AllegroDotNet.Models;
using SubC.AllegroDotNet.Native.Libraries;

namespace SubC.AllegroDotNet
{
    /// <summary>
    /// Allegro game library methods.
    /// </summary>
    public static partial class Al
    {
        public static bool InitNativeDialogAddon() =>
            AllegroLibrary.AlInitNativeDialogAddon();

        public static bool IsNativeDialogAddonInitialized() =>
            AllegroLibrary.AlIsNativeDialogAddonInitialized();

        public static void ShutdownNativeDialogAddon() =>
            AllegroLibrary.AlShutdownNativeDialogAddon();

        public static AllegroFileChooser CreateNativeFileDialog(
            string initialPath,
            string title,
            string patterns,
            FileChooserMode mode)
        {
            var nativeFileDialog = AllegroLibrary.AlCreateNativeFileDialog(initialPath, title, patterns, (int)mode);
            return nativeFileDialog == IntPtr.Zero ? null : new AllegroFileChooser { NativeIntPtr = nativeFileDialog };
        }

        public static bool ShowNativeFileDialog(AllegroDisplay display, AllegroFileChooser dialog) =>
            AllegroLibrary.AlShowNativeFileDialog(display.NativeIntPtr, dialog.NativeIntPtr);

        public static int GetNativeFileDialogCount(AllegroFileChooser dialog) =>
            AllegroLibrary.AlGetNativeFileDialogCount(dialog.NativeIntPtr);

        public static string GetNativeFileDialogPath(AllegroFileChooser dialog, ulong i)
        {
            var nativePath = AllegroLibrary.AlGetNativeFileDialogPath(dialog.NativeIntPtr, new UIntPtr(i));
            return nativePath == IntPtr.Zero ? null : Marshal.PtrToStringAnsi(nativePath);
        }

        public static void DestroyNativeFileDialog(AllegroFileChooser dialog) =>
            AllegroLibrary.AlDestroyNativeFileDialog(dialog.NativeIntPtr);

        public static int ShowNativeMessageBox(
            AllegroDisplay display,
            string title,
            string heading,
            string text,
            string buttons,
            MessageBoxFlags flags)
        {
            var nativeDisplay = display == null ? IntPtr.Zero : display.NativeIntPtr;
            return AllegroLibrary.AlShowNativeMessageBox(nativeDisplay, title, heading, text, buttons, (int)flags);
        }

        public static AllegroTextLog OpenNativeTextLog(string title, TextLogFlags flags)
        {
            var nativeTextLog = AllegroLibrary.AlOpenNativeTextLog(title, (int)flags);
            return nativeTextLog == IntPtr.Zero ? null : new AllegroTextLog { NativeIntPtr = nativeTextLog };
        }

        public static void CloseNativeTextLog(AllegroTextLog textLog) =>
            AllegroLibrary.AlCloseNativeTextLog(textLog.NativeIntPtr);

        public static void AppendNativeTextLog(AllegroTextLog textLog, string message) =>
            AllegroLibrary.AlAppendNativeTextLog(textLog.NativeIntPtr, message);

        public static AllegroEventSource GetNativeTextLogEventSource(AllegroTextLog textLog)
        {
            var nativeEventSource = AllegroLibrary.AlGetNativeTextLogEventSource(textLog.NativeIntPtr);
            return nativeEventSource == IntPtr.Zero ? null : new AllegroEventSource { NativeIntPtr = nativeEventSource };
        }

        public static uint GetAllegroNativeDialogVersion() =>
            AllegroLibrary.AlGetAllegroNativeDialogVersion();


        public static AllegroMenu CreateMenu()
        {
            var nativeMenu = AllegroLibrary.AlCreateMenu();
            return nativeMenu == IntPtr.Zero ? null : new AllegroMenu { NativeIntPtr = nativeMenu };
        }

        public static AllegroMenu CreatePopupMenu()
        {
            var nativeMenu = AllegroLibrary.AlCreatePopupMenu();
            return nativeMenu == IntPtr.Zero ? null : new AllegroMenu { NativeIntPtr = nativeMenu };
        }

        public static AllegroMenu BuildMenu(AllegroMenuInfo info)
        {
            var nativeMenu = AllegroLibrary.AlBuildMenu(info.NativeIntPtr);
            return nativeMenu == IntPtr.Zero ? null : new AllegroMenu { NativeIntPtr = nativeMenu };
        }

        public static int AppendMenuItem(
            AllegroMenu parent,
            string title,
            ushort id,
            MenuFlags flags,
            AllegroBitmap icon,
            AllegroMenu submenu)
        {
            var nativeIcon = icon == null ? IntPtr.Zero : icon.NativeIntPtr;
            var nativeSubmenu = submenu == null ? IntPtr.Zero : submenu.NativeIntPtr;
            return AllegroLibrary.AlAppendMenuItem(parent.NativeIntPtr, title, id, (int)flags, nativeIcon, nativeSubmenu);
        }

        public static int InsertMenuItem(
            AllegroMenu parent,
            int pos,
            string title,
            ushort id,
            MenuFlags flags,
            AllegroBitmap icon,
            AllegroMenu submenu)
        {
            var nativeIcon = icon == null ? IntPtr.Zero : icon.NativeIntPtr;
            var nativeSubmenu = submenu == null ? IntPtr.Zero : submenu.NativeIntPtr;
            return AllegroLibrary.AlInsertMenuItem(parent.NativeIntPtr, pos, title, id, (int)flags, nativeIcon, nativeSubmenu);
        }

        public static bool RemoveMenuItem(AllegroMenu menu, int pos) =>
            AllegroLibrary.AlRemoveMenuItem(menu.NativeIntPtr, pos);

        public static AllegroMenu CloneMenu(AllegroMenu menu)
        {
            var nativeCloneMenu = AllegroLibrary.AlCloneMenu(menu.NativeIntPtr);
            return nativeCloneMenu == IntPtr.Zero ? null : new AllegroMenu { NativeIntPtr = nativeCloneMenu };
        }

        public static AllegroMenu CloneMenuForPopup(AllegroMenu menu)
        {
            var nativeCloneMenu = AllegroLibrary.AlCloneMenuForPopup(menu.NativeIntPtr);
            return nativeCloneMenu == IntPtr.Zero ? null : new AllegroMenu { NativeIntPtr = nativeCloneMenu };
        }

        public static void DestroyMenu(AllegroMenu menu) =>
            AllegroLibrary.AlDestroyMenu(menu.NativeIntPtr);

        public static string GetMenuItemCaption(AllegroMenu menu, int pos)
        {
            var nativeString = AllegroLibrary.AlGetMenuItemCaption(menu.NativeIntPtr, pos);
            return nativeString == IntPtr.Zero ? null : Marshal.PtrToStringAnsi(nativeString);
        }

        public static void SetMenuItemCaption(AllegroMenu menu, int pos, string caption) =>
            AllegroLibrary.AlSetMenuItemCaption(menu.NativeIntPtr, pos, caption);

        public static int GetMenuItemFlags(AllegroMenu menu, int pos) =>
            AllegroLibrary.AlGetMenuItemFlags(menu.NativeIntPtr, pos);

        public static void SetMenuItemFlags(AllegroMenu menu, int pos, MenuFlags flags) =>
            AllegroLibrary.AlSetMenuItemFlags(menu.NativeIntPtr, pos, (int)flags);

        public static AllegroBitmap GetMenuItemIcon(AllegroMenu menu, int pos)
        {
            var nativeBitmap = AllegroLibrary.AlGetMenuItemIcon(menu.NativeIntPtr, pos);
            return nativeBitmap == IntPtr.Zero ? null : new AllegroBitmap { NativeIntPtr = nativeBitmap };
        }

        public static void SetMenuItemIcon(AllegroMenu menu, int pos, AllegroBitmap icon) =>
            AllegroLibrary.AlSetMenuItemIcon(menu.NativeIntPtr, pos, icon.NativeIntPtr);

        public static AllegroMenu FindMenu(AllegroMenu haystack, ushort id)
        {
            var nativeMenu = AllegroLibrary.AlFindMenu(haystack.NativeIntPtr, id);
            return nativeMenu == IntPtr.Zero ? null : new AllegroMenu { NativeIntPtr = nativeMenu };
        }

        public static bool FindMenuItem(AllegroMenu haystack, ushort id, AllegroMenu menu, ref int index)
        {
            var nativeMenu = menu == null ? IntPtr.Zero : menu.NativeIntPtr;
            var returnValue = AllegroLibrary.AlFindMenuItem(haystack.NativeIntPtr, id, ref nativeMenu, ref index);
            if (menu != null)
            {
                menu.NativeIntPtr = nativeMenu;
            }
            return returnValue;
        }

        public static AllegroEventSource GetDefaultMenuEventSource()
        {
            var nativeEventSource = AllegroLibrary.AlGetDefaultMenuEventSource();
            return nativeEventSource == IntPtr.Zero ? null : new AllegroEventSource { NativeIntPtr = nativeEventSource };
        }

        public static AllegroEventSource EnableMenuEventSource(AllegroMenu menu)
        {
            var nativeEventSource = AllegroLibrary.AlEnableMenuEventSource(menu.NativeIntPtr);
            return nativeEventSource == IntPtr.Zero ? null : new AllegroEventSource { NativeIntPtr = nativeEventSource };
        }

        public static void DisableMenuEventSource(AllegroMenu menu) =>
            AllegroLibrary.AlDisableMenuEventSource(menu.NativeIntPtr);

        public static AllegroMenu GetDisplayMenu(AllegroDisplay display)
        {
            var nativeMenu = AllegroLibrary.AlGetDisplayMenu(display.NativeIntPtr);
            return nativeMenu == IntPtr.Zero ? null : new AllegroMenu { NativeIntPtr = nativeMenu };
        }

        public static bool SetDisplayMenu(AllegroDisplay display, AllegroMenu menu) =>
            AllegroLibrary.AlSetDisplayMenu(display.NativeIntPtr, menu.NativeIntPtr);

        public static bool PopupMenu(AllegroMenu popup, AllegroDisplay display) =>
            AllegroLibrary.AlPopupMenu(popup.NativeIntPtr, display.NativeIntPtr);

        public static AllegroMenu RemoveDisplayMenu(AllegroDisplay display)
        {
            var nativeMenu = AllegroLibrary.AlRemoveDisplayMenu(display.NativeIntPtr);
            return nativeMenu == IntPtr.Zero ? null : new AllegroMenu { NativeIntPtr = nativeMenu };
        }

        #region P/Invokes
        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //private static extern bool al_init_native_dialog_addon();

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //private static extern bool al_is_native_dialog_addon_initialized();

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //private static extern void al_shutdown_native_dialog_addon();

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //private static extern IntPtr al_create_native_file_dialog([MarshalAs(UnmanagedType.LPStr)] string initial_path, [MarshalAs(UnmanagedType.LPStr)] string title, [MarshalAs(UnmanagedType.LPStr)] string patterns, int mode);

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //private static extern bool al_show_native_file_dialog(IntPtr display, IntPtr dialog);

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //private static extern int al_get_native_file_dialog_count(IntPtr dialog);

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //private static extern IntPtr al_get_native_file_dialog_path(IntPtr dialog, UIntPtr i);

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //private static extern void al_destroy_native_file_dialog(IntPtr dialog);

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //private static extern int al_show_native_message_box(IntPtr display, [MarshalAs(UnmanagedType.LPStr)] string title, [MarshalAs(UnmanagedType.LPStr)] string heading, [MarshalAs(UnmanagedType.LPStr)] string text, [MarshalAs(UnmanagedType.LPStr)] string buttons, int flags);

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //private static extern IntPtr al_open_native_text_log([MarshalAs(UnmanagedType.LPStr)] string title, int flags);

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //private static extern void al_close_native_text_log(IntPtr textlog);

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //private static extern void al_append_native_text_log(IntPtr textlog, string format, __arglist);

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //private static extern IntPtr al_get_native_text_log_event_source(IntPtr textlog);

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //private static extern uint al_get_allegro_native_dialog_version();

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //private static extern IntPtr al_create_menu();

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //private static extern IntPtr al_create_popup_menu();

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //private static extern IntPtr al_build_menu(IntPtr info);

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //private static extern int al_append_menu_item(IntPtr parent, [MarshalAs(UnmanagedType.LPStr)] string title, ushort id, int flags, IntPtr icon, IntPtr submenu);

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //private static extern int al_insert_menu_item(IntPtr parent, int pos, [MarshalAs(UnmanagedType.LPStr)] string title, ushort id, int flags, IntPtr icon, IntPtr submenu);

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //private static extern bool al_remove_menu_item(IntPtr menu, int pos);

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //private static extern IntPtr al_clone_menu(IntPtr menu);

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //private static extern IntPtr al_clone_menu_for_popup(IntPtr menu);

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //private static extern void al_destroy_menu(IntPtr menu);

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //private static extern IntPtr al_get_menu_item_caption(IntPtr menu, int pos);

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //private static extern void al_set_menu_item_caption(IntPtr menu, int pos, [MarshalAs(UnmanagedType.LPStr)] string caption);

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //private static extern int al_get_menu_item_flags(IntPtr menu, int pos);

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //private static extern void al_set_menu_item_flags(IntPtr menu, int pos, int flags);

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //private static extern IntPtr al_get_menu_item_icon(IntPtr menu, int pos);

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //private static extern void al_set_menu_item_icon(IntPtr menu, int pos, IntPtr icon);

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //private static extern IntPtr al_find_menu(IntPtr haystack, ushort id);

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //private static extern bool al_find_menu_item(IntPtr haystack, ushort id, ref IntPtr menu, ref int index);

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //private static extern IntPtr al_get_default_menu_event_source();

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //private static extern IntPtr al_enable_menu_event_source(IntPtr menu);

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //private static extern void al_disable_menu_event_source(IntPtr menu);

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //private static extern IntPtr al_get_display_menu(IntPtr display);

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //private static extern bool al_set_display_menu(IntPtr display, IntPtr menu);

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //private static extern bool al_popup_menu(IntPtr popup, IntPtr display);

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //private static extern IntPtr al_remove_display_menu(IntPtr display);
        #endregion
    }
}
