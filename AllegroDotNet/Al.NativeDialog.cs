using System;
using System.Runtime.InteropServices;
using AllegroDotNet.Enums;
using AllegroDotNet.Models;

namespace AllegroDotNet
{
    /// <summary>
    /// Allegro game library methods.
    /// </summary>
    public static partial class Al
    {
        public static bool InitNativeDialogAddon()
            => al_init_native_dialog_addon();

        public static bool IsNativeDialogAddonInitialized()
            => al_is_native_dialog_addon_initialized();

        public static void ShutdownNativeDialogAddon()
            => al_shutdown_native_dialog_addon();

        public static AllegroFileChooser CreateNativeFileDialog(
            string initialPath,
            string title,
            string patterns,
            FileChooserMode mode)
        {
            var nativeFileDialog = al_create_native_file_dialog(initialPath, title, patterns, (int)mode);
            return nativeFileDialog == IntPtr.Zero ? null : new AllegroFileChooser { NativeIntPtr = nativeFileDialog };
        }

        public static bool ShowNativeFileDialog(AllegroDisplay display, AllegroFileChooser dialog)
            => al_show_native_file_dialog(display.NativeIntPtr, dialog.NativeIntPtr);

        public static int GetNativeFileDialogCount(AllegroFileChooser dialog)
            => al_get_native_file_dialog_count(dialog.NativeIntPtr);

        public static string GetNativeFileDialogPath(AllegroFileChooser dialog, ulong i)
        {
            var nativePath = al_get_native_file_dialog_path(dialog.NativeIntPtr, new UIntPtr(i));
            return nativePath == IntPtr.Zero ? null : Marshal.PtrToStringAnsi(nativePath);
        }

        public static void DestroyNativeFileDialog(AllegroFileChooser dialog)
            => al_destroy_native_file_dialog(dialog.NativeIntPtr);

        public static int ShowNativeMessageBox(
            AllegroDisplay display,
            string title,
            string heading,
            string text,
            string buttons,
            MessageBoxFlags flags)
        {
            var nativeDisplay = display == null ? IntPtr.Zero : display.NativeIntPtr;
            return al_show_native_message_box(nativeDisplay, title, heading, text, buttons, (int)flags);
        }

        public static AllegroTextLog OpenNativeTextLog(string title, TextLogFlags flags)
        {
            var nativeTextLog = al_open_native_text_log(title, (int)flags);
            return nativeTextLog == IntPtr.Zero ? null : new AllegroTextLog { NativeIntPtr = nativeTextLog };
        }

        public static void CloseNativeTextLog(AllegroTextLog textLog)
            => al_close_native_text_log(textLog.NativeIntPtr);

        public static void AppendNativeTextLog(AllegroTextLog textLog, string message)
            => al_append_native_text_log(textLog.NativeIntPtr, message, __arglist());

        public static AllegroEventSource GetNativeTextLogEventSource(AllegroTextLog textLog)
        {
            var nativeEventSource = al_get_native_text_log_event_source(textLog.NativeIntPtr);
            return nativeEventSource == IntPtr.Zero ? null : new AllegroEventSource { NativeIntPtr = nativeEventSource };
        }

        public static uint GetAllegroNativeDialogVersion()
            => al_get_allegro_native_dialog_version();
        
        public static AllegroMenu CreateMenu()
        {
            var nativeMenu = al_create_menu();
            return nativeMenu == IntPtr.Zero ? null : new AllegroMenu { NativeIntPtr = nativeMenu };
        }

        public static AllegroMenu CreatePopupMenu()
        {
            var nativeMenu = al_create_popup_menu();
            return nativeMenu == IntPtr.Zero ? null : new AllegroMenu { NativeIntPtr = nativeMenu };
        }

        public static AllegroMenu BuildMenu(AllegroMenuInfo info)
        {
            var nativeMenu = al_build_menu(info.NativeIntPtr);
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
            return al_append_menu_item(parent.NativeIntPtr, title, id, (int)flags, nativeIcon, nativeSubmenu);
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
            return al_insert_menu_item(parent.NativeIntPtr, pos, title, id, (int)flags, nativeIcon, nativeSubmenu);
        }

        public static bool RemoveMenuItem(AllegroMenu menu, int pos)
            => al_remove_menu_item(menu.NativeIntPtr, pos);

        public static AllegroMenu CloneMenu(AllegroMenu menu)
        {
            var nativeCloneMenu = al_clone_menu(menu.NativeIntPtr);
            return nativeCloneMenu == IntPtr.Zero ? null : new AllegroMenu { NativeIntPtr = nativeCloneMenu };
        }

        public static AllegroMenu CloneMenuForPopup(AllegroMenu menu)
        {
            var nativeCloneMenu = al_clone_menu_for_popup(menu.NativeIntPtr);
            return nativeCloneMenu == IntPtr.Zero ? null : new AllegroMenu { NativeIntPtr = nativeCloneMenu };
        }

        public static void DestroyMenu(AllegroMenu menu)
            => al_destroy_menu(menu.NativeIntPtr);

        public static string GetMenuItemCaption(AllegroMenu menu, int pos)
        {
            var nativeString = al_get_menu_item_caption(menu.NativeIntPtr, pos);
            return nativeString == IntPtr.Zero ? null : Marshal.PtrToStringAnsi(nativeString);
        }

        public static void SetMenuItemCaption(AllegroMenu menu, int pos, string caption)
            => al_set_menu_item_caption(menu.NativeIntPtr, pos, caption);

        public static int GetMenuItemFlags(AllegroMenu menu, int pos)
            => al_get_menu_item_flags(menu.NativeIntPtr, pos);

        public static void SetMenuItemFlags(AllegroMenu menu, int pos, MenuFlags flags)
            => al_set_menu_item_flags(menu.NativeIntPtr, pos, (int)flags);

        public static AllegroBitmap GetMenuItemIcon(AllegroMenu menu, int pos)
        {
            var nativeBitmap = al_get_menu_item_icon(menu.NativeIntPtr, pos);
            return nativeBitmap == IntPtr.Zero ? null : new AllegroBitmap { NativeIntPtr = nativeBitmap };
        }

        public static void SetMenuItemIcon(AllegroMenu menu, int pos, AllegroBitmap icon)
            => al_set_menu_item_icon(menu.NativeIntPtr, pos, icon.NativeIntPtr);

        public static AllegroMenu FindMenu(AllegroMenu haystack, ushort id)
        {
            var nativeMenu = al_find_menu(haystack.NativeIntPtr, id);
            return nativeMenu == IntPtr.Zero ? null : new AllegroMenu { NativeIntPtr = nativeMenu };
        }

        public static bool FindMenuItem(AllegroMenu haystack, ushort id, AllegroMenu menu, ref int index)
        {
            var nativeMenu = menu == null ? IntPtr.Zero : menu.NativeIntPtr;
            var returnValue = al_find_menu_item(haystack.NativeIntPtr, id, ref nativeMenu, ref index);
            if (menu != null)
            {
                menu.NativeIntPtr = nativeMenu;
            }
            return returnValue;
        }

        public static AllegroEventSource GetDefaultMenuEventSource()
        {
            var nativeEventSource = al_get_default_menu_event_source();
            return nativeEventSource == IntPtr.Zero ? null : new AllegroEventSource { NativeIntPtr = nativeEventSource };
        }

        public static AllegroEventSource EnableMenuEventSource(AllegroMenu menu)
        {
            var nativeEventSource = al_enable_menu_event_source(menu.NativeIntPtr);
            return nativeEventSource == IntPtr.Zero ? null : new AllegroEventSource { NativeIntPtr = nativeEventSource };
        }

        public static void DisableMenuEventSource(AllegroMenu menu)
            => al_disable_menu_event_source(menu.NativeIntPtr);

        public static AllegroMenu GetDisplayMenu(AllegroDisplay display)
        {
            var nativeMenu = al_get_display_menu(display.NativeIntPtr);
            return nativeMenu == IntPtr.Zero ? null : new AllegroMenu { NativeIntPtr = nativeMenu };
        }

        public static bool SetDisplayMenu(AllegroDisplay display, AllegroMenu menu)
            => al_set_display_menu(display.NativeIntPtr, menu.NativeIntPtr);

        public static bool PopupMenu(AllegroMenu popup, AllegroDisplay display)
            => al_popup_menu(popup.NativeIntPtr, display.NativeIntPtr);

        public static AllegroMenu RemoveDisplayMenu(AllegroDisplay display)
        {
            var nativeMenu = al_remove_display_menu(display.NativeIntPtr);
            return nativeMenu == IntPtr.Zero ? null : new AllegroMenu { NativeIntPtr = nativeMenu };
        }

        #region P/Invokes
        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern bool al_init_native_dialog_addon();

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern bool al_is_native_dialog_addon_initialized();

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern void al_shutdown_native_dialog_addon();

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern IntPtr al_create_native_file_dialog(
            [MarshalAs(UnmanagedType.LPStr)] string initial_path,
            [MarshalAs(UnmanagedType.LPStr)] string title,
            [MarshalAs(UnmanagedType.LPStr)] string patterns,
            int mode);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern bool al_show_native_file_dialog(IntPtr display, IntPtr dialog);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern int al_get_native_file_dialog_count(IntPtr dialog);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern IntPtr al_get_native_file_dialog_path(IntPtr dialog, UIntPtr i);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern void al_destroy_native_file_dialog(IntPtr dialog);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern int al_show_native_message_box(
            IntPtr display,
            [MarshalAs(UnmanagedType.LPStr)] string title,
            [MarshalAs(UnmanagedType.LPStr)] string heading,
            [MarshalAs(UnmanagedType.LPStr)] string text,
            [MarshalAs(UnmanagedType.LPStr)] string buttons,
            int flags);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern IntPtr al_open_native_text_log([MarshalAs(UnmanagedType.LPStr)] string title, int flags);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern void al_close_native_text_log(IntPtr textlog);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern void al_append_native_text_log(IntPtr textlog, string format, __arglist);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern IntPtr al_get_native_text_log_event_source(IntPtr textlog);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern uint al_get_allegro_native_dialog_version();

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern IntPtr al_create_menu();

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern IntPtr al_create_popup_menu();

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern IntPtr al_build_menu(IntPtr info);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern int al_append_menu_item(
            IntPtr parent,
            [MarshalAs(UnmanagedType.LPStr)] string title,
            ushort id,
            int flags,
            IntPtr icon,
            IntPtr submenu);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern int al_insert_menu_item(
            IntPtr parent,
            int pos,
            [MarshalAs(UnmanagedType.LPStr)] string title,
            ushort id,
            int flags,
            IntPtr icon,
            IntPtr submenu);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern bool al_remove_menu_item(IntPtr menu, int pos);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern IntPtr al_clone_menu(IntPtr menu);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern IntPtr al_clone_menu_for_popup(IntPtr menu);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern void al_destroy_menu(IntPtr menu);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern IntPtr al_get_menu_item_caption(IntPtr menu, int pos);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern void al_set_menu_item_caption(
            IntPtr menu,
            int pos,
            [MarshalAs(UnmanagedType.LPStr)] string caption);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern int al_get_menu_item_flags(IntPtr menu, int pos);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern void al_set_menu_item_flags(IntPtr menu, int pos, int flags);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern IntPtr al_get_menu_item_icon(IntPtr menu, int pos);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern void al_set_menu_item_icon(IntPtr menu, int pos, IntPtr icon);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern IntPtr al_find_menu(IntPtr haystack, ushort id);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern bool al_find_menu_item(IntPtr haystack, ushort id, ref IntPtr menu, ref int index);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern IntPtr al_get_default_menu_event_source();

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern IntPtr al_enable_menu_event_source(IntPtr menu);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern void al_disable_menu_event_source(IntPtr menu);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern IntPtr al_get_display_menu(IntPtr display);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern bool al_set_display_menu(IntPtr display, IntPtr menu);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern bool al_popup_menu(IntPtr popup, IntPtr display);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern IntPtr al_remove_display_menu(IntPtr display);
        #endregion
    }
}
