using SubC.AllegroDotNet.Models;
using System.Runtime.InteropServices;

namespace SubC.AllegroDotNet.Native;

internal static partial class Interop
{
  public static DialogContext Dialog => _dialogContext ??= new();

  private static DialogContext? _dialogContext;

  public sealed class DialogContext
  {
    #region Native Dialog Routines

    public al_init_native_dialog_addon AlInitNativeDialogAddon { get; }
    public al_is_native_dialog_addon_initialized AlIsNativeDialogAddonInitialized { get; }
    public al_shutdown_native_dialog_addon AlShutdownNativeDialogAddon { get; }
    public al_create_native_file_dialog AlCreateNativeFileDialog { get; }
    public al_show_native_file_dialog AlShowNativeFileDialog { get; }
    public al_get_native_file_dialog_count AlGetNativeFileDialogCount { get; }
    public al_get_native_file_dialog_path AlGetNativeFileDialogPath { get; }
    public al_destroy_native_file_dialog AlDestroyNativeFileDialog { get; }
    public al_show_native_message_box AlShowNativeMessageBox { get; }
    public al_open_native_text_log AlOpenNativeTextLog { get; }
    public al_close_native_text_log AlCloseNativeTextLog { get; }
    public al_append_native_text_log AlAppendNativeTextLog { get; }
    public al_get_native_text_log_event_source AlGetNativeTextLogEventSource { get; }
    public al_get_allegro_native_dialog_version AlGetAllegroNativeDialogVersion { get; }
    public al_create_menu AlCreateMenu { get; }
    public al_create_popup_menu AlCreatePopupMenu { get; }
    public al_build_menu AlBuildMenu { get; }
    public al_append_menu_item AlAppendMenuItem { get; }
    public al_insert_menu_item AlInsertMenuItem { get; }
    public al_remove_menu_item AlRemoveMenuItem { get; }
    public al_clone_menu AlCloneMenu { get; }
    public al_clone_menu_for_popup AlCloneMenuForPopup { get; }
    public al_destroy_menu AlDestroyMenu { get; }
    public al_get_menu_item_caption AlGetMenuItemCaption { get; }
    public al_set_menu_item_caption AlSetMenuItemCaption { get; }
    public al_get_menu_item_flags AlGetMenuItemFlags { get; }
    public al_set_menu_item_flags AlSetMenuItemFlags { get; }
    public al_get_menu_item_icon AlGetMenuItemIcon { get; }
    public al_set_menu_item_icon AlSetMenuItemIcon { get; }
    public al_find_menu AlFindMenu { get; }
    public al_find_menu_item AlFindMenuItem { get; }
    public al_get_default_menu_event_source AlGetDefaultMenuEventSource { get; }
    public al_enable_menu_event_source AlEnableMenuEventSource { get; }
    public al_disable_menu_event_source AlDisableMenuEventSource { get; }
    public al_get_display_menu AlGetDisplayMenu { get; }
    public al_set_display_menu AlSetDisplayMenu { get; }
    public al_popup_menu AlPopupMenu { get; }
    public al_remove_display_menu AlRemoveDisplayMenu { get; }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte al_init_native_dialog_addon();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte al_is_native_dialog_addon_initialized();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_shutdown_native_dialog_addon();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_create_native_file_dialog(IntPtr initial_path, IntPtr title, IntPtr patterns, int mode);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte al_show_native_file_dialog(IntPtr display, IntPtr dialog);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_native_file_dialog_count(IntPtr dialog);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_native_file_dialog_path(IntPtr dialog, UIntPtr i);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_destroy_native_file_dialog(IntPtr dialog);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_show_native_message_box(IntPtr display, IntPtr title, IntPtr heading, IntPtr text, IntPtr buttons, int flags);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_open_native_text_log(IntPtr title, int flags);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_close_native_text_log(IntPtr textlog);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_append_native_text_log(IntPtr textlog, IntPtr format);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_native_text_log_event_source(IntPtr textlog);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate uint al_get_allegro_native_dialog_version();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_create_menu();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_create_popup_menu();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_build_menu(ref AllegroMenuInfo info);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_append_menu_item(IntPtr parent, IntPtr title, ushort id, int flags, IntPtr icon, IntPtr submenu);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_insert_menu_item(IntPtr parent, int pos, IntPtr title, ushort id, int flags, IntPtr icon, IntPtr submenu);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte al_remove_menu_item(IntPtr menu, int pos);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_clone_menu(IntPtr menu);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_clone_menu_for_popup(IntPtr menu);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_destroy_menu(IntPtr menu);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_menu_item_caption(IntPtr menu, int pos);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_set_menu_item_caption(IntPtr menu, int pos, IntPtr caption);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_menu_item_flags(IntPtr menu, int pos);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_set_menu_item_flags(IntPtr menu, int pos, int flags);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_menu_item_icon(IntPtr menu, int pos);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_set_menu_item_icon(IntPtr menu, int pos, IntPtr icon);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_find_menu(IntPtr haystack, ushort id);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte al_find_menu_item(IntPtr haystack, ushort id, ref IntPtr menu, ref int index);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_default_menu_event_source();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_enable_menu_event_source(IntPtr menu);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_disable_menu_event_source(IntPtr menu);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_display_menu(IntPtr display);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte al_set_display_menu(IntPtr display, IntPtr menu);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte al_popup_menu(IntPtr menu, IntPtr display);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_remove_display_menu(IntPtr display);

    #endregion

    public DialogContext()
    {
      AlInitNativeDialogAddon = LoadFunction<al_init_native_dialog_addon>();
      AlIsNativeDialogAddonInitialized = LoadFunction<al_is_native_dialog_addon_initialized>();
      AlShutdownNativeDialogAddon = LoadFunction<al_shutdown_native_dialog_addon>();
      AlCreateNativeFileDialog = LoadFunction<al_create_native_file_dialog>();
      AlShowNativeFileDialog = LoadFunction<al_show_native_file_dialog>();
      AlGetNativeFileDialogCount = LoadFunction<al_get_native_file_dialog_count>();
      AlGetNativeFileDialogPath = LoadFunction<al_get_native_file_dialog_path>();
      AlDestroyNativeFileDialog = LoadFunction<al_destroy_native_file_dialog>();
      AlShowNativeMessageBox = LoadFunction<al_show_native_message_box>();
      AlOpenNativeTextLog = LoadFunction<al_open_native_text_log>();
      AlCloseNativeTextLog = LoadFunction<al_close_native_text_log>();
      AlAppendNativeTextLog = LoadFunction<al_append_native_text_log>();
      AlGetNativeTextLogEventSource = LoadFunction<al_get_native_text_log_event_source>();
      AlGetAllegroNativeDialogVersion = LoadFunction<al_get_allegro_native_dialog_version>();
      AlCreateMenu = LoadFunction<al_create_menu>();
      AlCreatePopupMenu = LoadFunction<al_create_popup_menu>();
      AlBuildMenu = LoadFunction<al_build_menu>();
      AlAppendMenuItem = LoadFunction<al_append_menu_item>();
      AlInsertMenuItem = LoadFunction<al_insert_menu_item>();
      AlRemoveMenuItem = LoadFunction<al_remove_menu_item>();
      AlCloneMenu = LoadFunction<al_clone_menu>();
      AlCloneMenuForPopup = LoadFunction<al_clone_menu_for_popup>();
      AlDestroyMenu = LoadFunction<al_destroy_menu>();
      AlGetMenuItemCaption = LoadFunction<al_get_menu_item_caption>();
      AlSetMenuItemCaption = LoadFunction<al_set_menu_item_caption>();
      AlGetMenuItemFlags = LoadFunction<al_get_menu_item_flags>();
      AlSetMenuItemFlags = LoadFunction<al_set_menu_item_flags>();
      AlGetMenuItemIcon = LoadFunction<al_get_menu_item_icon>();
      AlSetMenuItemIcon = LoadFunction<al_set_menu_item_icon>();
      AlFindMenu = LoadFunction<al_find_menu>();
      AlFindMenuItem = LoadFunction<al_find_menu_item>();
      AlGetDefaultMenuEventSource = LoadFunction<al_get_default_menu_event_source>();
      AlEnableMenuEventSource = LoadFunction<al_enable_menu_event_source>();
      AlDisableMenuEventSource = LoadFunction<al_disable_menu_event_source>();
      AlGetDisplayMenu = LoadFunction<al_get_display_menu>();
      AlSetDisplayMenu = LoadFunction<al_set_display_menu>();
      AlPopupMenu = LoadFunction<al_popup_menu>();
      AlRemoveDisplayMenu = LoadFunction<al_remove_display_menu>();
    }
  }
}
