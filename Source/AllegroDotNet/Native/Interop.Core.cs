using SubC.AllegroDotNet.Models;
using System.Runtime.InteropServices;
using static SubC.AllegroDotNet.Native.Interop.CoreContext;

namespace SubC.AllegroDotNet.Native;

internal static partial class Interop
{
  public static CoreContext Core => _coreContext ??= new();

  private static CoreContext? _coreContext;

  public sealed class CoreContext
  {
    #region Configuration Files Routines

    public al_create_config AlCreateConfig { get; }
    public al_destroy_config AlDestroyConfig { get; }
    public al_load_config_file AlLoadConfigFile { get; }
    public al_load_config_file_f AlLoadConfigFileF { get; }
    public al_save_config_file AlSaveConfigFile { get; }
    public al_save_config_file_f AlSaveConfigFileF { get; }
    public al_add_config_section AlAddConfigSection { get; }
    public al_remove_config_section AlRemoveConfigSection { get; }
    public al_add_config_comment AlAddConfigComment { get; }
    public al_get_config_value AlGetConfigValue { get; }
    public al_set_config_value AlSetConfigValue { get; }
    public al_remove_config_key AlRemoveConfigKey { get; }
    public al_get_first_config_section AlGetFirstConfigSection { get; }
    public al_get_next_config_section AlGetNextConfigSection { get; }
    public al_get_first_config_entry AlGetFirstConfigEntry { get; }
    public al_get_next_config_entry AlGetNextConfigEntry { get; }
    public al_merge_config AlMergeConfig { get; }
    public al_merge_config_into AlMergeConfigInto { get; }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_create_config();
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_destroy_config(IntPtr config);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_load_config_file(IntPtr filename);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_load_config_file_f(IntPtr file);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte al_save_config_file(IntPtr filename, IntPtr config);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte al_save_config_file_f(IntPtr file, IntPtr config);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_add_config_section(IntPtr config, IntPtr name);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte al_remove_config_section(IntPtr config, IntPtr section);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_add_config_comment(IntPtr config, IntPtr section, IntPtr comment);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_config_value(IntPtr config, IntPtr section, IntPtr key);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_set_config_value(IntPtr config, IntPtr section, IntPtr key, IntPtr value);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte al_remove_config_key(IntPtr config, IntPtr section, IntPtr key);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_first_config_section(IntPtr config, ref IntPtr iterator);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_next_config_section(ref IntPtr iterator);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_first_config_entry(IntPtr config, IntPtr section, ref IntPtr iterator);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_next_config_entry(ref IntPtr iterator);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_merge_config(IntPtr cfg1, IntPtr cfg2);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_merge_config_into(IntPtr master, IntPtr add);

    #endregion

    #region Display Routines

    public al_create_display AlCreateDisplay { get; }
    public al_destroy_display AlDestroyDisplay { get; }
    public al_get_new_display_flags AlGetNewDisplayFlags { get; }
    public al_set_new_display_flags AlSetNewDisplayFlags { get; }
    public al_get_new_display_option AlGetNewDisplayOption { get; }
    public al_set_new_display_option AlSetNewDisplayOption { get; }
    public al_reset_new_display_options AlResetNewDisplayOptions { get; }
    public al_get_new_window_position AlGetNewWindowPosition { get; }
    public al_set_new_window_position AlSetNewWindowPosition { get; }
    public al_get_new_display_refresh_rate AlGetNewDisplayRefreshRate { get; }
    public al_set_new_display_refresh_rate AlSetNewDisplayRefreshRate { get; }
    public al_get_display_event_source AlGetDisplayEventSource { get; }
    public al_get_backbuffer AlGetBackbuffer { get; }
    public al_flip_display AlFlipDisplay { get; }
    public al_update_display_region AlUpdateDisplayRegion { get; }
    public al_wait_for_vsync AlWaitForVsync { get; }
    public al_get_display_width AlGetDisplayWidth { get; }
    public al_get_display_height AlGetDisplayHeight { get; }
    public al_resize_display AlResizeDisplay { get; }
    public al_acknowledge_resize AlAcknowledgeResize { get; }
    public al_get_window_position AlGetWindowPosition { get; }
    public al_set_window_position AlSetWindowPosition { get; }
    public al_get_window_constraints AlGetWindowConstraints { get; }
    public al_set_window_constraints AlSetWindowConstraints { get; }
    public al_apply_window_constraints AlApplyWindowConstraints { get; }
    public al_get_display_flags AlGetDisplayFlags { get; }
    public al_set_display_flag AlSetDisplayFlag { get; }
    public al_get_display_option AlGetDisplayOption { get; }
    public al_set_display_option AlSetDisplayOption { get; }
    public al_get_display_format AlGetDisplayFormat { get; }
    public al_get_display_orientation AlGetDisplayOrientation { get; }
    public al_get_display_refresh_rate AlGetDisplayRefreshRate { get; }
    public al_set_window_title AlSetWindowTitle { get; }
    public al_set_new_window_title AlSetNewWindowTitle { get; }
    public al_get_new_window_title AlGetNewWindowTitle { get; }
    public al_set_display_icon AlSetDisplayIcon { get; }
    public al_set_display_icons AlSetDisplayIcons { get; }
    public al_acknowledge_drawing_halt AlAcknowledgeDrawingHalt { get; }
    public al_acknowledge_drawing_resume AlAcknowledgeDrawingResume { get; }
    public al_inhibit_screensaver AlInhibitScreensaver { get; }
    public al_get_clipboard_text AlGetClipboardText { get; }
    public al_set_clipboard_text AlSetClipboardText { get; }
    public al_clipboard_has_text AlClipboardHasText { get; }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_create_display(int w, int h);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_destroy_display(IntPtr display);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_new_display_flags();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_set_new_display_flags(int flags);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_new_display_option(int option, ref int importance);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_set_new_display_option(int option, int value, int importance);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_reset_new_display_options();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_get_new_window_position(ref int x, ref int y);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_set_new_window_position(int x, int y);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_new_display_refresh_rate();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_set_new_display_refresh_rate(int refresh_rate);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_display_event_source(IntPtr display);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_backbuffer(IntPtr display);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_flip_display();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_update_display_region(int x, int y, int width, int height);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte al_wait_for_vsync();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_display_width(IntPtr display);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_display_height(IntPtr display);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte al_resize_display(IntPtr display, int width, int height);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte al_acknowledge_resize(IntPtr display);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_get_window_position(IntPtr display, ref int x, ref int y);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_set_window_position(IntPtr display, int x, int y);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte al_get_window_constraints(IntPtr display, ref int min_w, ref int min_h, ref int max_w, ref int max_h);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte al_set_window_constraints(IntPtr display, int min_w, int min_h, int max_w, int max_h);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte al_apply_window_constraints(IntPtr display, byte onoff);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_display_flags(IntPtr display);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte al_set_display_flag(IntPtr display, int flag, byte onoff);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_display_option(IntPtr display, int option);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_set_display_option(IntPtr display, int option, int value);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_display_format(IntPtr display);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_display_orientation(IntPtr display);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_display_refresh_rate(IntPtr display);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_set_window_title(IntPtr display, IntPtr title);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_set_new_window_title(IntPtr title);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_new_window_title();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_set_display_icon(IntPtr display, IntPtr icon);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_set_display_icons(IntPtr display, int num_icons, IntPtr[] icon);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_acknowledge_drawing_halt(IntPtr display);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_acknowledge_drawing_resume(IntPtr display);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte al_inhibit_screensaver(byte inhibit);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_clipboard_text(IntPtr display);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte al_set_clipboard_text(IntPtr display, IntPtr text);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte al_clipboard_has_text(IntPtr display);

    #endregion

    #region Event Routines

    public al_create_event_queue AlCreateEventQueue { get; }
    public al_destroy_event_queue AlDestroyEventQueue { get; }
    public al_register_event_source AlRegisterEventSource { get; }
    public al_unregister_event_source AlUnregisterEventSource { get; }
    public al_is_event_source_registered AlIsEventSourceRegistered { get; }
    public al_pause_event_queue AlPauseEventQueue { get; }
    public al_is_event_queue_paused AlIsEventQueuePaused { get; }
    public al_is_event_queue_empty AlIsEventQueueEmpty { get; }
    public al_get_next_event AlGetNextEvent { get; }
    public al_peek_next_event AlPeekNextEvent { get; }
    public al_drop_next_event AlDropNextEvent { get; }
    public al_flush_event_queue AlFlushEventQueue { get; }
    public al_wait_for_event AlWaitForEvent { get; }
    public al_wait_for_event_timed AlWaitForEventTimed { get; }
    public al_wait_for_event_until AlWaitForEventUntil { get; }
    public al_init_user_event_source AlInitUserEventSource { get; }
    public al_destroy_user_event_source AlDestroyUserEventSource { get; }
    public al_emit_user_event AlEmitUserEvent { get; }
    public al_unref_user_event AlUnrefUserEvent { get; }
    public al_get_event_source_data AlGetEventSourceData { get; }
    public al_set_event_source_data AlSetEventSourceData { get; }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_create_event_queue();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_destroy_event_queue(IntPtr queue);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_register_event_source(IntPtr queue, IntPtr source);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_unregister_event_source(IntPtr queue, IntPtr source);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte al_is_event_source_registered(IntPtr queue, IntPtr source);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_pause_event_queue(IntPtr queue, byte pause);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte al_is_event_queue_paused(IntPtr queue);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte al_is_event_queue_empty(IntPtr queue);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte al_get_next_event(IntPtr queue, ref AllegroEvent ret_event);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte al_peek_next_event(IntPtr queue, ref AllegroEvent ret_event);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte al_drop_next_event(IntPtr queue);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_flush_event_queue(IntPtr queue);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_wait_for_event(IntPtr queue, ref AllegroEvent ret_event);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte al_wait_for_event_timed(IntPtr queue, ref AllegroEvent ret_event, float secs);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte al_wait_for_event_until(IntPtr queue, ref AllegroEvent ret_event, IntPtr timeout);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_init_user_event_source(IntPtr source);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_destroy_user_event_source(IntPtr source);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte al_emit_user_event(IntPtr source, ref AllegroEvent @event, Delegates.UserEventDeconstructor? dtor);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_unref_user_event(ref AllegroUserEvent @event);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_event_source_data(IntPtr source);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_set_event_source_data(IntPtr source, IntPtr data);

    #endregion

    #region File I/O Routines

    public al_fopen AlFOpen { get; } 
    public al_fopen_interface AlFOpenInterface { get; }
    public al_fopen_slice AlFOpenSlice { get; }
    public al_fclose AlFClose { get; }
    public al_fread AlFRead { get; }
    public al_fwrite AlFWrite { get; }
    public al_fflush AlFFlush { get; }
    public al_ftell AlFTell { get; }
    public al_fseek AlFSeek { get; }
    public al_feof AlFEof { get; }
    public al_ferror AlFError { get; }
    public al_ferrmsg AlFErrMsg { get; }
    public al_fclearerr AlFClearErr { get; }
    public al_fungetc AlFUngetC { get; }
    public al_fsize AlFSize { get; }
    public al_fgetc AlFGetC { get; }
    public al_fputc AlFPutC { get; }
    public al_fread16le AlFRead16LE { get; }
    public al_fread16be AlFRead16BE { get; }
    public al_fwrite16le AlFWrite16LE { get; }
    public al_fwrite16be AlFWrite16BE { get; }
    public al_fread32le AlFRead32LE { get; }
    public al_fread32be AlFRead32BE { get; }
    public al_fwrite32le AlFWrite32LE { get; }
    public al_fwrite32be AlFWrite32BE { get; }
    public al_fgets AlFGetS { get; }
    public al_fget_ustr AlFGetUstr { get; }
    public al_fputs AlFPutS { get; }
    public al_fopen_fd AlFOpenFd { get; }
    public al_make_temp_file AlMakeTempFile { get; }
    public al_set_new_file_interface AlSetNewFileInterface { get; }
    public al_set_standard_file_interface AlSetStandardFileInterface { get; }
    public al_get_new_file_interface AlGetNewFileInterface { get; }
    public al_create_file_handle AlCreateFileHandle { get; }
    public al_get_file_userdata AlGetFileUserdata { get; }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_fopen(IntPtr path, IntPtr mode);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_fopen_interface(IntPtr drv, IntPtr path, IntPtr mode);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_fopen_slice(IntPtr fp, long initial_size, IntPtr mode);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte al_fclose(IntPtr f);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate long al_fread(IntPtr f, byte[] ptr, long size);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate long al_fwrite(IntPtr f, byte[] ptr, long size);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte al_fflush(IntPtr f);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate long al_ftell(IntPtr f);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte al_fseek(IntPtr f, long offset, int whence);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte al_feof(IntPtr f);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_ferror(IntPtr f);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_ferrmsg(IntPtr f);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_fclearerr(IntPtr f);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_fungetc(IntPtr f, int c);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate long al_fsize(IntPtr f);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_fgetc(IntPtr f);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_fputc(IntPtr f, int c);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate short al_fread16le(IntPtr f);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate short al_fread16be(IntPtr f);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate long al_fwrite16le(IntPtr f, short w);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate long al_fwrite16be(IntPtr f, short w);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_fread32le(IntPtr f);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_fread32be(IntPtr f);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate long al_fwrite32le(IntPtr f, int l);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate long al_fwrite32be(IntPtr f, int l);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_fgets(IntPtr f, IntPtr buf, long max);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_fget_ustr(IntPtr f);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_fputs(IntPtr f, IntPtr p);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_fopen_fd(int fd, IntPtr mode);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_make_temp_file(IntPtr template, ref IntPtr ret_path);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_set_new_file_interface(ref AllegroFileInterface file_interface);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_set_standard_file_interface();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_new_file_interface();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_create_file_handle(ref AllegroFileInterface drv, IntPtr userdata);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_file_userdata(IntPtr f);

    #endregion

    #region File System Routines

    public al_create_fs_entry AlCreateFsEntry { get; }
    public al_destroy_fs_entry AlDestroyFsEntry { get; }
    public al_get_fs_entry_name AlGetFsEntryName { get; }
    public al_update_fs_entry AlUpdateFsEntry { get; }
    public al_get_fs_entry_mode AlGetFsEntryMode { get; }
    public al_get_fs_entry_atime AlGetFsEntryAtime { get; }
    public al_get_fs_entry_ctime AlGetFsEntryCtime { get; }
    public al_get_fs_entry_mtime AlGetFsEntryMtime { get; }
    public al_get_fs_entry_size AlGetFsEntrySize { get; }
    public al_fs_entry_exists AlFsEntryExists { get; }
    public al_remove_fs_entry AlRemoveFsEntry { get; }
    public al_filename_exists AlFilenameExists { get; }
    public al_remove_filename AlRemoveFilename { get; }
    public al_open_directory AlOpenDirectory { get; }
    public al_read_directory AlReadDirectory { get; }
    public al_close_directory AlCloseDirectory { get; }
    public al_get_current_directory AlGetCurrentDirectory { get; }
    public al_change_directory AlChangeDirectory { get; }
    public al_make_directory AlMakeDirectory { get; }
    public al_open_fs_entry ALOpenFsEntry { get; }
    public al_for_each_fs_entry AlForEachFsEntry { get; }
    public al_set_fs_interface AlSetFsInterface { get; }
    public al_set_standard_fs_interface AlSetStandardFsInterface { get; }
    public al_get_fs_interface AlGetFsInterface { get; }


    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_create_fs_entry(IntPtr path);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_destroy_fs_entry(IntPtr fh);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_fs_entry_name(IntPtr e);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte al_update_fs_entry(IntPtr e);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate uint al_get_fs_entry_mode(IntPtr e);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate ulong al_get_fs_entry_atime(IntPtr e);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate ulong al_get_fs_entry_ctime(IntPtr e);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate ulong al_get_fs_entry_mtime(IntPtr e);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate ulong al_get_fs_entry_size(IntPtr e);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte al_fs_entry_exists(IntPtr e);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte al_remove_fs_entry(IntPtr e);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte al_filename_exists(IntPtr path);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte al_remove_filename(IntPtr path);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte al_open_directory(IntPtr e);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_read_directory(IntPtr e);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte al_close_directory(IntPtr e);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_current_directory();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte al_change_directory(IntPtr path);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte al_make_directory(IntPtr path);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_open_fs_entry(IntPtr e, IntPtr mode);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_for_each_fs_entry(IntPtr dir, Delegates.ForEachFsCallback callback, IntPtr extra);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_set_fs_interface(ref AllegroFileInterface fs_interface);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_set_standard_fs_interface();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_fs_interface();

    #endregion

    #region Fixed Point Math Routines

    public al_itofix AlIToFix { get; }
    public al_fixtoi AlFixToI { get; }
    public al_fixfloor AlFixFloor { get; }
    public al_fixceil AlFixCeil { get; }
    public al_ftofix AlFToFix { get; }
    public al_fixtof AlFixToF { get; }
    public al_fixmul AlFixMul { get; }
    public al_fixdiv AlFixDiv { get; }
    public al_fixadd AlFixAdd { get; }
    public al_fixsub AlFixSub { get; }
    public al_fixsin AlFixSin { get; }
    public al_fixcos AlFixCos { get; }
    public al_fixtan AlFixTan { get; }
    public al_fixasin AlFixAsin { get; }
    public al_fixacos AlFixAcos { get; }
    public al_fixatan AlFixAtan { get; }
    public al_fixatan2 AlFixAtan2 { get; }
    public al_fixsqrt AlFixSqrt { get; }
    public al_fixhypot AlFixHypot { get; }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_itofix(int x);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_fixtoi(int x);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_fixfloor(int x);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_fixceil(int x);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_ftofix(double x);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate double al_fixtof(int x);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_fixmul(int x, int y);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_fixdiv(int x, int y);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_fixadd(int x, int y);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_fixsub(int x, int y);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_fixsin(int x);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_fixcos(int x);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_fixtan(int x);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_fixasin(int x);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_fixacos(int x);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_fixatan(int x);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_fixatan2(int y, int x);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_fixsqrt(int x);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_fixhypot(int x, int y);


    #endregion

    #region Fullscreen Routines

    public al_get_display_mode AlGetDisplayMode { get; }
    public al_get_num_display_modes AlGetNumDisplayModes { get; }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_display_mode(int index, ref AllegroDisplayMode mode);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_num_display_modes();

    #endregion

    #region Graphics Routines

    public al_map_rgb AlMapRgb { get; }
    public al_map_rgb_f AlMapRgbF { get; }
    public al_map_rgba AlMapRgba { get; }
    public al_premul_rgba AlPremulRgba { get; }
    public al_map_rgba_f AlMapRgbaF { get; }
    public al_premul_rgba_f AlPremulRgbaF { get; }
    public al_unmap_rgb AlUnmapRgb { get; }
    public al_unmap_rgb_f AlUnmapRgbF { get; }
    public al_unmap_rgba AlUnmapRgba { get; }
    public al_unmap_rgba_f AlUnmapRgbaF { get; }
    public al_get_pixel_size AlGetPixelSize { get; }
    public al_get_pixel_format_bits AlGetPixelFormatBits { get; }
    public al_get_pixel_block_size AlGetPixelBlockSize { get; }
    public al_get_pixel_block_width AlGetPixelBlockWidth { get; }
    public al_get_pixel_block_height AlGetPixelBlockHeight { get; }
    public al_lock_bitmap AlLockBitmap { get; }
    public al_lock_bitmap_region AlLockBitmapRegion { get; }
    public al_unlock_bitmap AlUnlockBitmap { get; }
    public al_lock_bitmap_blocked AlLockBitmapBlocked { get; }
    public al_lock_bitmap_region_blocked AlLockBitmapRegionBlocked { get; }
    public al_create_bitmap AlCreateBitmap { get; }
    public al_create_sub_bitmap AlCreateSubBitmap { get; }
    public al_clone_bitmap AlCloneBitmap { get; }
    public al_convert_bitmap AlConvertBitmap { get; }
    public al_convert_memory_bitmaps AlConvertMemoryBitmaps { get; }
    public al_destroy_bitmap AlDestroyBitmap { get; }
    public al_get_new_bitmap_flags AlGetNewBitmapFlags { get; }
    public al_get_new_bitmap_format AlGetNewBitmapFormat { get; }
    public al_set_new_bitmap_flags AlSetNewBitmapFlags { get; }
    public al_add_new_bitmap_flag AlAddNewBitmapFlag { get; }
    public al_set_new_bitmap_format AlSetNewBitmapFormat { get; }
    public al_get_bitmap_flags AlGetBitmapFlags { get; }
    public al_get_bitmap_format AlGetBitmapFormat { get; }
    public al_get_bitmap_height AlGetBitmapHeight { get; }
    public al_get_bitmap_width AlGetBitmapWidth { get; }
    public al_get_pixel AlGetPixel { get; }
    public al_is_bitmap_locked AlIsBitmapLocked { get; }
    public al_is_compatible_bitmap AlIsCompatibleBitmap { get; }
    public al_is_sub_bitmap AlIsSubBitmap { get; }
    public al_get_parent_bitmap AlGetParentBitmap { get; }
    public al_get_bitmap_x AlGetBitmapX { get; }
    public al_get_bitmap_y AlGetBitmapY { get; }
    public al_reparent_bitmap AlReparentBitmap { get; }
    public al_clear_to_color AlClearToColor { get; }
    public al_clear_depth_buffer AlClearDepthBuffer { get; }
    public al_draw_bitmap AlDrawBitmap { get; }
    public al_draw_tinted_bitmap AlDrawTintedBitmap { get; }
    public al_draw_bitmap_region AlDrawBitmapRegion { get; }
    public al_draw_tinted_bitmap_region AlDrawTintedBitmapRegion { get; }
    public al_draw_pixel AlDrawPixel { get; }
    public al_draw_rotated_bitmap AlDrawRotatedBitmap { get; }
    public al_draw_tinted_rotated_bitmap AlDrawTintedRotatedBitmap { get; }
    public al_draw_scaled_rotated_bitmap AlDrawScaledRotatedBitmap { get; }
    public al_draw_tinted_scaled_rotated_bitmap AlDrawTintedScaledRotatedBitmap { get; }
    public al_draw_tinted_scaled_rotated_bitmap_region AlDrawTintedScaledRotatedBitmapRegion { get; }
    public al_draw_scaled_bitmap AlDrawScaledBitmap { get; }
    public al_draw_tinted_scaled_bitmap AlDrawTintedScaledBitmap { get; }
    public al_get_target_bitmap AlGetTargetBitmap { get; }
    public al_put_pixel AlPutPixel { get; }
    public al_put_blended_pixel AlPutBlendedPixel { get; }
    public al_set_target_bitmap AlSetTargetBitmap { get; }
    public al_set_target_backbuffer AlSetTargetBackbuffer { get; }
    public al_get_current_display AlGetCurrentDisplay { get; }
    public al_get_blender AlGetBlender { get; }
    public al_get_separate_blender AlGetSeparateBlender { get; }
    public al_get_blend_color AlGetBlendColor { get; }
    public al_set_blender AlSetBlender { get; }
    public al_set_separate_blender AlSetSeparateBlender { get; }
    public al_set_blend_color AlSetBlendColor { get; }
    public al_get_clipping_rectangle AlGetClippingRectangle { get; }
    public al_set_clipping_rectangle AlSetClippingRectangle { get; }
    public al_reset_clipping_rectangle AlResetClippingRectangle { get; }
    public al_convert_mask_to_alpha AlConvertMaskToAlpha { get; }
    public al_hold_bitmap_drawing AlHoldBitmapDrawing { get; }
    public al_is_bitmap_drawing_held AlIsBitmapDrawingHeld { get; }
    public al_load_bitmap AlLoadBitmap { get; }
    public al_load_bitmap_flags AlLoadBitmapFlags { get; }
    public al_load_bitmap_f AlLoadBitmapF { get; }
    public al_load_bitmap_flags_f AlLoadBitmapFlagsF { get; }
    public al_save_bitmap AlSaveBitmap { get; }
    public al_save_bitmap_f AlSaveBitmapF { get; }
    public al_set_render_state AlSetRenderState { get; }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate AllegroColor al_map_rgb(byte r, byte g, byte b);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate AllegroColor al_map_rgb_f(float r, float g, float b);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate AllegroColor al_map_rgba(byte r, byte g, byte b, byte a);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate AllegroColor al_premul_rgba(byte r, byte g, byte b, byte a);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate AllegroColor al_map_rgba_f(float r, float g, float b, float a);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate AllegroColor al_premul_rgba_f(float r, float g, float b, float a);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_unmap_rgb(AllegroColor color, ref byte r, ref byte g, ref byte b);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_unmap_rgb_f(AllegroColor color, ref float r, ref float g, ref float b);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_unmap_rgba(AllegroColor color, ref byte r, ref byte g, ref byte b, ref byte a);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_unmap_rgba_f(AllegroColor color, ref float r, ref float g, ref float b, ref float a);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_pixel_size(int format);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_pixel_format_bits(int format);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_pixel_block_size(int format);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_pixel_block_width(int format);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_pixel_block_height(int format);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_lock_bitmap(IntPtr bitmap, int format, int flags);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_lock_bitmap_region(IntPtr bitmap, int x, int y, int width, int height, int format, int flags);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_unlock_bitmap(IntPtr bitmap);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_lock_bitmap_blocked(IntPtr bitmap, int flags);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_lock_bitmap_region_blocked(IntPtr bitmap, int x_block, int y_block, int width_block, int height_block, int flags);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_create_bitmap(int w, int h);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_create_sub_bitmap(IntPtr parent, int x, int y, int w, int h);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_clone_bitmap(IntPtr bitmap);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_convert_bitmap(IntPtr bitmap);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_convert_memory_bitmaps();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_destroy_bitmap(IntPtr bitmap);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_new_bitmap_flags();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_new_bitmap_format();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_set_new_bitmap_flags(int flags);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_add_new_bitmap_flag(int flag);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_set_new_bitmap_format(int format);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_bitmap_flags(IntPtr bitmap);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_bitmap_format(IntPtr bitmap);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_bitmap_height(IntPtr bitmap);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_bitmap_width(IntPtr bitmap);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate AllegroColor al_get_pixel(IntPtr bitmap, int x, int y);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte al_is_bitmap_locked(IntPtr bitmap);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte al_is_compatible_bitmap(IntPtr bitmap);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte al_is_sub_bitmap(IntPtr bitmap);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_parent_bitmap(IntPtr bitmap);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_bitmap_x(IntPtr bitmap);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_bitmap_y(IntPtr bitmap);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_reparent_bitmap(IntPtr bitmap, IntPtr parent, int x, int y, int w, int h);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_clear_to_color(AllegroColor color);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_clear_depth_buffer(float z);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_draw_bitmap(IntPtr bitmap, float dx, float dy, int flags);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_draw_tinted_bitmap(IntPtr bitmap, AllegroColor tint, float dx, float dy, int flags);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_draw_bitmap_region(IntPtr bitmap, float sx, float sy, float sw, float sh, float dx, float dy, int flags);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_draw_tinted_bitmap_region(IntPtr bitmap, AllegroColor tint, float sx, float sy, float sw, float sh, float dx, float dy, int flags);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_draw_pixel(float x, float y, AllegroColor color);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_draw_rotated_bitmap(IntPtr bitmap, float cx, float cy, float dx, float dy, float angle, int flags);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_draw_tinted_rotated_bitmap(IntPtr bitmap, AllegroColor tint, float cx, float cy, float dx, float dy, float angle, int flags);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_draw_scaled_rotated_bitmap(IntPtr bitmap, float cx, float cy, float dx, float dy, float xscale, float yscale, float angle, int flags);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_draw_tinted_scaled_rotated_bitmap(IntPtr bitmap, AllegroColor tint, float cx, float cy, float dx, float dy, float xscale, float yscale, float angle, int flags);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_draw_tinted_scaled_rotated_bitmap_region(IntPtr bitmap, float sx, float sy, float sw, float sh, AllegroColor tint, float cx, float cy, float dx, float dy, float xscale, float yscale, float angle, int flags);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_draw_scaled_bitmap(IntPtr bitmap, float sx, float sy, float sw, float sh, float dx, float dy, float dw, float dh, int flags);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_draw_tinted_scaled_bitmap(IntPtr bitmap, AllegroColor tint, float sx, float sy, float sw, float sh, float dx, float dy, float dw, float dh, int flags);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_target_bitmap();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_put_pixel(int x, int y, AllegroColor color);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_put_blended_pixel(int x, int y, AllegroColor color);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_set_target_bitmap(IntPtr bitmap);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_set_target_backbuffer(IntPtr display);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_current_display();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_get_blender(ref int op, ref int src, ref int dst);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_get_separate_blender(ref int op, ref int src, ref int dst, ref int alpha_op, ref int alpha_src, ref int alpha_dst);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate AllegroColor al_get_blend_color();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_set_blender(int op, int src, int dst);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_set_separate_blender(int op, int src, int dst, int alpha_op, int alpha_src, int alpha_dst);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_set_blend_color(AllegroColor color);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_get_clipping_rectangle(ref int x, ref int y, ref int w, ref int h);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_set_clipping_rectangle(int x, int y, int width, int height);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_reset_clipping_rectangle();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_convert_mask_to_alpha(IntPtr bitmap, AllegroColor mask_color);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_hold_bitmap_drawing(byte hold);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte al_is_bitmap_drawing_held();

    //[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    //public delegate byte al_register_bitmap_loader(IntPtr extension, BitmapLoaderDelegate? loader);

    //[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    //public delegate byte al_register_bitmap_saver(IntPtr extension, BitmapSaverDelegate? saver);

    //[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    //public delegate byte al_register_bitmap_loader_f(IntPtr extension, BitmapLoaderFDelegate? fs_loader);

    //[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    //public delegate byte al_register_bitmap_saver_f(IntPtr extension, BitmapSaverFDelegate? fs_saver);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_load_bitmap(IntPtr filename);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_load_bitmap_flags(IntPtr filename, int flags);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_load_bitmap_f(IntPtr fp, IntPtr ident);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_load_bitmap_flags_f(IntPtr fp, IntPtr ident, int flags);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte al_save_bitmap(IntPtr filename, IntPtr bitmap);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte al_save_bitmap_f(IntPtr fp, IntPtr ident, IntPtr bitmap);

    //[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    //public delegate byte al_register_bitmap_identifier(IntPtr extension, BitmapIdentifierDelegate? identifier);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_identify_bitmap(IntPtr filename);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_identify_bitmap_f(IntPtr fp);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_set_render_state(int state, int value);

    #endregion

    #region Joystick Routines

    public al_install_joystick AlInstallJoystick { get; }
    public al_uninstall_joystick AlUninstallJoystick { get; }
    public al_is_joystick_installed AlIsJoystickInstalled { get; }
    public al_reconfigure_joysticks AlReconfigureJoysticks { get; }
    public al_get_num_joysticks AlGetNumJoysticks { get; }
    public al_get_joystick AlGetJoystick { get; }
    public al_release_joystick AlReleaseJoystick { get; }
    public al_get_joystick_active AlGetJoystickActive { get; }
    public al_get_joystick_name AlGetJoystickName { get; }
    public al_get_joystick_num_sticks AlGetJoystickNumSticks { get; }
    public al_get_joystick_stick_flags AlGetJoystickStickFlags { get; }
    public al_get_joystick_stick_name AlGetJoystickStickName { get; }
    public al_get_joystick_num_axes AlGetJoystickNumAxes { get; }
    public al_get_joystick_axis_name AlGetJoystickAxisName { get; }
    public al_get_joystick_num_buttons AlGetJoystickNumButtons { get; }
    public al_get_joystick_button_name AlGetJoystickButtonName { get; }
    public al_get_joystick_state AlGetJoystickState { get; }
    public al_get_joystick_event_source AlGetJoystickEventSource { get; }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte al_install_joystick();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_uninstall_joystick();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte al_is_joystick_installed();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte al_reconfigure_joysticks();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_num_joysticks();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_joystick(int num);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_release_joystick(IntPtr joy);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte al_get_joystick_active(IntPtr joy);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_joystick_name(IntPtr joy);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_joystick_stick_name(IntPtr joy, int stick);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_joystick_axis_name(IntPtr joy, int stick, int axis);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_joystick_button_name(IntPtr joy, int button);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_joystick_stick_flags(IntPtr joy, int stick);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_joystick_num_sticks(IntPtr joy);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_joystick_num_axes(IntPtr joy, int stick);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_joystick_num_buttons(IntPtr joy);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_get_joystick_state(IntPtr joy, ref AllegroJoystickState ret_state);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_joystick_event_source();

    #endregion

    #region Keyboard Routines

    public al_install_keyboard AlInstallKeyboard { get; }
    public al_is_keyboard_installed AlIsKeyboardInstalled { get; }
    public al_uninstall_keyboard AlUninstallKeyboard { get; }
    public al_get_keyboard_state AlGetKeyboardState { get; }
    public al_key_down AlKeyDown { get; }
    public al_keycode_to_name AlKeycodeToName { get; }
    public al_set_keyboard_leds AlSetKeyboardLeds { get; }
    public al_get_keyboard_event_source AlGetKeyboardEventSource { get; }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte al_install_keyboard();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte al_is_keyboard_installed();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_uninstall_keyboard();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_get_keyboard_state(ref AllegroKeyboardState ret_state);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte al_key_down(ref AllegroKeyboardState state, int keycode);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_keycode_to_name(int keycode);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte al_can_set_keyboard_leds();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte al_set_keyboard_leds(int leds);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_keyboard_event_source();

    #endregion

    #region Memory Management Routines

    public al_malloc_with_context AlMallocWithContext { get; }
    public al_free_with_context AlFreeWithContext { get; }
    public al_realloc_with_context AlReallocWithContext { get; }
    public al_calloc_with_context AlCallocWithContext { get; }
    public al_set_memory_interface AlSetMemoryInterface { get; }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_malloc_with_context(UIntPtr n, int line, IntPtr file, IntPtr func);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_free_with_context(IntPtr ptr, int line, IntPtr file, IntPtr func);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_realloc_with_context(IntPtr ptr, UIntPtr n, int line, IntPtr file, IntPtr func);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_calloc_with_context(UIntPtr count, UIntPtr n, int line, IntPtr file, IntPtr func);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_set_memory_interface(IntPtr memory_interface);

    #endregion

    #region Monitor Routines

    public al_get_new_display_adapter AlGetNewDisplayAdapter { get; }
    public al_set_new_display_adapter AlSetNewDisplayAdapter { get; }
    public al_get_monitor_info AlGetMonitorInfo { get; }
    public al_get_monitor_dpi AlGetMonitorDpi { get; }
    public al_get_num_video_adapters AlGetNumVideoAdapters { get; }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_new_display_adapter();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_set_new_display_adapter(int adapter);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte al_get_monitor_info(int adapter, ref AllegroMonitorInfo info);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_monitor_dpi(int adapter);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_num_video_adapters();

    #endregion

    #region Mouse Routines

    public al_install_mouse AlInstallMouse { get; }
    public al_is_mouse_installed AlIsMouseInstalled { get; }
    public al_uninstall_mouse AlUninstallMouse { get; }
    public al_get_mouse_num_axes AlGetMouseNumAxes { get; }
    public al_get_mouse_num_buttons AlGetMouseNumButtons { get; }
    public al_get_mouse_state AlGetMouseState { get; }
    public al_get_mouse_state_axis AlGetMouseStateAxis { get; }
    public al_mouse_button_down AlMouseButtonDown { get; }
    public al_set_mouse_xy AlSetMouseXY { get; }
    public al_set_mouse_z AlSetMouseZ { get; }
    public al_set_mouse_w AlSetMouseW { get; }
    public al_set_mouse_axis AlSetMouseAxis { get; }
    public al_get_mouse_event_source AlGetMouseEventSource { get; }
    public al_set_mouse_wheel_precision AlSetMouseWheelPrecision { get; }
    public al_get_mouse_wheel_precision AlGetMouseWheelPrecision { get; }
    public al_create_mouse_cursor AlCreateMouseCursor { get; }
    public al_destroy_mouse_cursor AlDestroyMouseCursor { get; }
    public al_set_mouse_cursor AlSetMouseCursor { get; }
    public al_set_system_mouse_cursor AlSetSystemMouseCursor { get; }
    public al_get_mouse_cursor_position AlGetMouseCursorPosition { get; }
    public al_hide_mouse_cursor AlHideMouseCursor { get; }
    public al_show_mouse_cursor AlShowMouseCursor { get; }
    public al_grab_mouse AlGrabMouse { get; }
    public al_ungrab_mouse AlUngrabMouse { get; }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte al_install_mouse();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte al_is_mouse_installed();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_uninstall_mouse();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate uint al_get_mouse_num_axes();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate uint al_get_mouse_num_buttons();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_get_mouse_state(ref AllegroMouseState ret_state);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_mouse_state_axis(ref AllegroMouseState state, int axis);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte al_mouse_button_down(ref AllegroMouseState state, int button);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte al_set_mouse_xy(IntPtr display, int x, int y);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte al_set_mouse_z(int z);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte al_set_mouse_w(int w);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte al_set_mouse_axis(int which, int value);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_mouse_event_source();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_set_mouse_wheel_precision(int precision);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_mouse_wheel_precision();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_create_mouse_cursor(IntPtr bitmap, int x_focus, int y_focus);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_destroy_mouse_cursor(IntPtr cursor);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte al_set_mouse_cursor(IntPtr display, IntPtr cursor);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte al_set_system_mouse_cursor(IntPtr display, int cursor_id);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte al_get_mouse_cursor_position(ref int ret_x, ref int ret_y);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte al_hide_mouse_cursor(IntPtr display);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte al_show_mouse_cursor(IntPtr display);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte al_grab_mouse(IntPtr display);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte al_ungrab_mouse();

    #endregion

    #region Path Routines

    public al_create_path AlCreatePath { get; }
    public al_create_path_for_directory AlCreatePathForDirectory { get; }
    public al_destroy_path AlDestroyPath { get; }
    public al_clone_path AlClonePath { get; }
    public al_join_paths AlJoinPaths { get; }
    public al_rebase_path AlRebasePath { get; }
    public al_get_path_drive AlGetPathDrive { get; }
    public al_get_path_num_components AlGetPathNumComponents { get; }
    public al_get_path_component AlGetPathComponent { get; }
    public al_get_path_tail AlGetPathTail { get; }
    public al_get_path_filename AlGetPathFilename { get; }
    public al_get_path_basename AlGetPathBasename { get; }
    public al_get_path_extension AlGetPathExtension { get; }
    public al_set_path_drive AlSetPathDrive { get; }
    public al_append_path_component AlAppendPathComponent { get; }
    public al_insert_path_component AlInsertPathComponent { get; }
    public al_replace_path_component AlReplacePathComponent { get; }
    public al_remove_path_component AlRemovePathComponent { get; }
    public al_drop_path_tail AlDropPathTail { get; }
    public al_set_path_filename AlSetPathFilename { get; }
    public al_set_path_extension AlSetPathExtension { get; }
    public al_path_cstr AlPathCstr { get; }
    public al_path_ustr AlPathUstr { get; }
    public al_make_path_canonical AlMakePathCanonical { get; }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_create_path(IntPtr str);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_create_path_for_directory(IntPtr str);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_destroy_path(IntPtr path);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_clone_path(IntPtr path);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte al_join_paths(IntPtr path, IntPtr tail);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte al_rebase_path(IntPtr head, IntPtr tail);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_path_drive(IntPtr path);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_path_num_components(IntPtr path);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_path_component(IntPtr path, int i);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_path_tail(IntPtr path);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_path_filename(IntPtr path);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_path_basename(IntPtr path);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_path_extension(IntPtr path);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_set_path_drive(IntPtr path, IntPtr drive);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_append_path_component(IntPtr path, IntPtr s);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_insert_path_component(IntPtr path, int i, IntPtr s);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_replace_path_component(IntPtr path, int i, IntPtr s);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_remove_path_component(IntPtr path, int i);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_drop_path_tail(IntPtr path);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_set_path_filename(IntPtr path, IntPtr filename);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte al_set_path_extension(IntPtr path, IntPtr extension);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_path_cstr(IntPtr path, byte delim);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_path_ustr(IntPtr path, byte delim);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte al_make_path_canonical(IntPtr path);

    #endregion

    #region Shader Routines

    public al_create_shader AlCreateShader { get; }
    public al_attach_shader_source AlAttachShaderSource { get; }
    public al_attach_shader_source_file AlAttachShaderSourceFile { get; }
    public al_build_shader AlBuildShader { get; }
    public al_get_shader_log AlGetShaderLog { get; }
    public al_get_shader_platform AlGetShaderPlatform { get; }
    public al_use_shader AlUseShader { get; }
    public al_destroy_shader AlDestroyShader { get; }
    public al_set_shader_sampler AlSetShaderSampler { get; }
    public al_set_shader_matrix AlSetShaderMatrix { get; }
    public al_set_shader_int AlSetShaderInt { get; }
    public al_set_shader_float AlSetShaderFloat { get; }
    public al_set_shader_bool AlSetShaderBool { get; }
    public al_set_shader_int_vector AlSetShaderIntVector { get; }
    public al_set_shader_float_vector AlSetShaderFloatVector { get; }
    public al_get_default_shader_source AlGetDefaultShaderSource { get; }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_create_shader(int platform);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte al_attach_shader_source(IntPtr shader, int type, IntPtr source);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte al_attach_shader_source_file(IntPtr shader, int type, IntPtr filename);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte al_build_shader(IntPtr shader);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_shader_log(IntPtr shader);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_shader_platform(IntPtr shader);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte al_use_shader(IntPtr shader);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_destroy_shader(IntPtr shader);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte al_set_shader_sampler(IntPtr name, IntPtr bitmap, int unit);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte al_set_shader_matrix(IntPtr name, in AllegroTransform transform);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte al_set_shader_int(IntPtr name, int i);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte al_set_shader_float(IntPtr name, float f);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte al_set_shader_bool(IntPtr name, byte b);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte al_set_shader_int_vector(IntPtr name, int num_components, ref int i, int num_elems);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte al_set_shader_float_vector(IntPtr name, int num_components, ref float f, int num_elems);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_default_shader_source(int platform, int type);

    #endregion

    #region State Routines

    public al_restore_state AlRestoreState { get; }
    public al_store_state AlStoreState { get; }
    public al_get_errno AlGetErrno { get; }
    public al_set_errno AlSetErrno { get; }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_restore_state(ref AllegroState state);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_store_state(ref AllegroState state, int flags);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_errno();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_set_errno(int errnum);

    #endregion

    #region System Routines

    public al_install_system AlInstallSystem { get; }
    public al_uninstall_system AlUninstallSystem { get; }
    public al_is_system_installed AlIsSystemInstalled { get; }
    public al_get_allegro_version AlGetAllegroVersion { get; }
    public al_get_standard_path AlGetStandardPath { get; }
    public al_set_exe_name AlSetExeName { get; }
    public al_set_app_name AlSetAppName { get; }
    public al_set_org_name AlSetOrgName { get; }
    public al_get_app_name AlGetAppName { get; }
    public al_get_org_name AlGetOrgName { get; }
    public al_get_system_config AlGetSystemConfig { get; }
    public al_get_system_id AlGetSystemId { get; }
    public al_register_assert_handler AlRegisterAssertHandler { get; }
    public al_register_trace_handler AlRegisterTraceHandler { get; }
    public al_get_cpu_count AlGetCpuCount { get; }
    public al_get_ram_size AlGetRamSize { get; }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte al_install_system(int version, Delegates.AtExitDelegate? atExit);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_uninstall_system();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte al_is_system_installed();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate uint al_get_allegro_version();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_standard_path(int id);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_set_exe_name(IntPtr path);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_set_app_name(IntPtr path);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_set_org_name(IntPtr path);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_app_name();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_org_name();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_system_config();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_system_id();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_register_assert_handler(Delegates.RegisterAssertHandlerDelegate? handler);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_register_trace_handler(Delegates.RegisterTraceHandlerDelegate? handler);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_cpu_count();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_ram_size();

    #endregion

    #region Thread Routines

    public al_create_thread AlCreateThread { get; }
    public al_start_thread AlStartThread { get; }
    public al_join_thread AlJoinThread { get; }
    public al_set_thread_should_stop AlSetThreadShouldStop { get; }
    public al_get_thread_should_stop AlGetThreadShouldStop { get; }
    public al_destroy_thread AlDestroyThread { get; }
    public al_run_detached_thread AlRunDetachedThread { get; }
    public al_create_mutex AlCreateMutex { get; }
    public al_create_mutex_recursive AlCreateMutexRecursive { get; }
    public al_lock_mutex AlLockMutex { get; }
    public al_unlock_mutex AlUnlockMutex { get; }
    public al_destroy_mutex AlDestroyMutex { get; }
    public al_create_cond AlCreateCond { get; }
    public al_destroy_cond AlDestroyCond { get; }
    public al_wait_cond AlWaitCond { get; }
    public al_wait_cond_until AlWaitCondUntil { get; }
    public al_broadcast_cond AlBroadcastCond { get; }
    public al_signal_cond AlSignalCond { get; }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_create_thread(Delegates.ThreadExecutionDelegate proc, IntPtr arg);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_start_thread(IntPtr thread);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_join_thread(IntPtr thread, ref IntPtr ret_value);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_set_thread_should_stop(IntPtr thread);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte al_get_thread_should_stop(IntPtr thread);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_destroy_thread(IntPtr thread);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_run_detached_thread(Delegates.ThreadDetachedExecutionDelegate proc, IntPtr arg);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_create_mutex();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_create_mutex_recursive();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_lock_mutex(IntPtr mutex);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_unlock_mutex(IntPtr mutex);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_destroy_mutex(IntPtr mutex);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_create_cond();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_destroy_cond(IntPtr cond);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_wait_cond(IntPtr cond, IntPtr mutex);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_wait_cond_until(IntPtr cond, IntPtr mutex, IntPtr timeout);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_broadcast_cond(IntPtr cond);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_signal_cond(IntPtr cond);

    #endregion

    #region Time Routines

    public al_get_time AlGetTime { get; }
    public al_rest AlRest { get; }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate double al_get_time();

    //[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    //public delegate void al_init_timeout(ref AllegroTimeout timeout, double seconds);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_rest(double seconds);

    #endregion

    #region Timer Routines

    public al_create_timer AlCreateTimer { get; }
    public al_start_timer AlStartTimer { get; }
    public al_resume_timer AlResumeTimer { get; }
    public al_stop_timer AlStopTimer { get; }
    public al_get_timer_started AlGetTimerStarted { get; }
    public al_destroy_timer AlDestroyTimer { get; }
    public al_get_timer_count AlGetTimerCount { get; }
    public al_set_timer_count AlSetTimerCount { get; }
    public al_add_timer_count AlAddTimerCount { get; }
    public al_get_timer_speed AlGetTimerSpeed { get; }
    public al_set_timer_speed AlSetTimerSpeed { get; }
    public al_get_timer_event_source AlGetTimerEventSource { get; }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_create_timer(double speed_secs);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_start_timer(IntPtr timer);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_resume_timer(IntPtr timer);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_stop_timer(IntPtr timer);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte al_get_timer_started(IntPtr timer);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_destroy_timer(IntPtr timer);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate long al_get_timer_count(IntPtr timer);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_set_timer_count(IntPtr timer, long new_count);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_add_timer_count(IntPtr timer, long diff);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate double al_get_timer_speed(IntPtr timer);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_set_timer_speed(IntPtr timer, double new_speed_secs);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_timer_event_source(IntPtr timer);

    #endregion

    #region Touch Routines

    public al_install_touch_input AlInstallTouchInput { get; }
    public al_uninstall_touch_input AlUninstallTouchInput { get; }
    public al_is_touch_input_installed AlIsTouchInputInstalled { get; }
    public al_get_touch_input_state AlGetTouchInputState { get; }
    public al_get_touch_input_event_source AlGetTouchInputEventSource { get; }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte al_install_touch_input();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_uninstall_touch_input();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte al_is_touch_input_installed();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_get_touch_input_state(ref AllegroTouchInputState ret_state);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_touch_input_event_source();

    #endregion

    #region Transform Routines

    public al_copy_transform AlCopyTransform { get; }
    public al_use_transform AlUseTransform { get; }
    public al_get_current_transform AlGetCurrentTransform { get; }
    public al_use_projection_transform AlUseProjectionTransform { get; }
    public al_get_current_projection_transform AlGetCurrentProjectionTransform { get; }
    public al_get_current_inverse_transform AlGetCurrentInverseTransform { get; }
    public al_invert_transform AlInvertTransform { get; }
    public al_transpose_transform AlTransposeTransform { get; }
    public al_check_inverse AlCheckInverse { get; }
    public al_identity_transform AlIdentityTransform { get; }
    public al_build_transform AlBuildTransform { get; }
    public al_build_camera_transform AlBuildCameraTransform { get; }
    public al_translate_transform AlTranslateTransform { get; }
    public al_rotate_transform AlRotateTransform { get; }
    public al_scale_transform AlScaleTransform { get; }
    public al_transform_coordinates AlTransformCoordinates { get; }
    public al_transform_coordinates_3d AlTransformCoordinates3D { get; }
    public al_transform_coordinates_4d AlTransformCoordinates4D { get; }
    public al_transform_coordinates_3d_projective AlTransformCoordinates3DProjective { get; }
    public al_compose_transform AlComposeTransform { get; }
    public al_orthographic_transform AlOrthographicTransform { get; }
    public al_perspective_transform AlPerspectiveTransform { get; }
    public al_translate_transform_3d AlTranslateTransform3D { get; }
    public al_scale_transform_3d AlScaleTransform3D { get; }
    public al_rotate_transform_3d AlRotateTransform3D { get; }
    public al_horizontal_shear_transform AlHorizontalShearTransform { get; }
    public al_vertical_shear_transform AlVerticalShearTransform { get; }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_copy_transform(ref AllegroTransform dest, in AllegroTransform src);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_use_transform(ref AllegroTransform trans);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_current_transform();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_use_projection_transform(ref AllegroTransform trans);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_current_projection_transform();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_current_inverse_transform();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_invert_transform(ref AllegroTransform trans);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_transpose_transform(ref AllegroTransform trans);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_check_inverse(ref AllegroTransform trans, float tol);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_identity_transform(ref AllegroTransform trans);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_build_transform(ref AllegroTransform trans, float x, float y, float sx, float sy, float theta);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_build_camera_transform(
      ref AllegroTransform trans,
      float position_x,
      float position_y,
      float position_z,
      float look_x,
      float look_y,
      float look_z,
      float up_x,
      float up_y,
      float up_z);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_translate_transform(ref AllegroTransform trans, float x, float y);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_rotate_transform(ref AllegroTransform trans, float theta);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_scale_transform(ref AllegroTransform trans, float sx, float sy);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_transform_coordinates(ref AllegroTransform trans, ref float x, ref float y);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_transform_coordinates_3d(ref AllegroTransform trans, ref float x, ref float y, ref float z);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_transform_coordinates_4d(ref AllegroTransform trans, ref float x, ref float y, ref float z, ref float w);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_transform_coordinates_3d_projective(ref AllegroTransform trans, ref float x, ref float y, ref float z);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_compose_transform(ref AllegroTransform trans, in AllegroTransform other);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_orthographic_transform(
      ref AllegroTransform trans,
      float left,
      float top,
      float n,
      float right,
      float bottom,
      float f);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_perspective_transform(
      ref AllegroTransform trans,
      float left,
      float top,
      float n,
      float right,
      float bottom,
      float f);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_translate_transform_3d(ref AllegroTransform trans, float x, float y, float z);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_scale_transform_3d(ref AllegroTransform trans, float sx, float sy, float sz);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_rotate_transform_3d(ref AllegroTransform trans, float x, float y, float z, float angle);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_horizontal_shear_transform(ref AllegroTransform trans, float theta);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_vertical_shear_transform(ref AllegroTransform trans, float theta);

    #endregion

    #region UTF8 Routines

    public al_ustr_new AlUstrNew { get; }
    public al_ustr_new_from_buffer AlUstrNewFromBuffer { get; }
    public al_ustr_free AlUstrFree { get; }
    public al_cstr AlCstr { get; }
    public al_ustr_to_buffer AlUstrToBuffer { get; }
    public al_cstr_dup AlCstrDup { get; }
    public al_ustr_dup AlUstrDup { get; }
    public al_ustr_dup_substr AlUstrDupSubstr { get; }
    public al_ustr_empty_string AlUstrEmptyString { get; }
    public al_ref_cstr AlRefCstr { get; }
    public al_ref_buffer AlRefBuffer { get; }
    public al_ref_ustr AlRefUstr { get; }
    public al_ustr_size AlUstrSize { get; }
    public al_ustr_length AlUstrLength { get; }
    public al_ustr_offset AlUstrOffset { get; }
    public al_ustr_next AlUstrNext { get; }
    public al_ustr_prev AlUstrPrev { get; }
    public al_ustr_get AlUstrGet { get; }
    public al_ustr_get_next AlUstrGetNext { get; }
    public al_ustr_prev_get AlUstrPrevGet { get; }
    public al_ustr_insert AlUstrInsert { get; }
    public al_ustr_insert_cstr AlUstrInsertCstr { get; }
    public al_ustr_insert_chr AlUstrInsertChr { get; }
    public al_ustr_append AlUstrAppend { get; }
    public al_ustr_append_cstr AlUstrAppendCstr { get; }
    public al_ustr_append_chr AlUstrAppendChr { get; }
    public al_ustr_remove_chr AlUstrRemoveChr { get; }
    public al_ustr_remove_range AlUstrRemoveRange { get; }
    public al_ustr_truncate AlUstrTruncate { get; }
    public al_ustr_ltrim_ws AlUstrLtrimWs { get; }
    public al_ustr_rtrim_ws AlUstrRtrimWs { get; }
    public al_ustr_trim_ws AlUstrTrimWs { get; }
    public al_ustr_assign AlUstrAssign { get; }
    public al_ustr_assign_substr AlUstrAssignSubstr { get; }
    public al_ustr_assign_cstr AlUstrAssignCstr { get; }
    public al_ustr_set_chr AlUstrSetChr { get; }
    public al_ustr_replace_range AlUstrReplaceRange { get; }
    public al_ustr_find_chr AlUstrFindChr { get; }
    public al_ustr_rfind_chr AlUstrRfindChr { get; }
    public al_ustr_find_set AlUstrFindSet { get; }
    public al_ustr_find_set_cstr AlUstrFindSetCstr { get; }
    public al_ustr_find_cset AlUstrFindCset { get; }
    public al_ustr_find_cset_cstr AlUstrFindCsetCstr { get; }
    public al_ustr_find_str AlUstrFindStr { get; }
    public al_ustr_find_cstr AlUstrFindCstr { get; }
    public al_ustr_rfind_str AlUstrRfindStr { get; }
    public al_ustr_rfind_cstr AlUstrRfindCstr { get; }
    public al_ustr_find_replace AlUstrFindReplace { get; }
    public al_ustr_find_replace_cstr AlUstrFindReplaceCstr { get; }
    public al_ustr_equal AlUstrEqual { get; }
    public al_ustr_compare AlUstrCompare { get; }
    public al_ustr_ncompare AlUstrNcompare { get; }
    public al_ustr_has_prefix AlUstrHasPrefix { get; }
    public al_ustr_has_prefix_cstr AlUstrHasPrefixCstr { get; }
    public al_ustr_has_suffix AlUstrHasSuffix { get; }
    public al_ustr_has_suffix_cstr AlUstrHasSuffixCstr { get; }
    public al_ustr_new_from_utf16 AlUstrNewFromUtf16 { get; }
    public al_ustr_size_utf16 AlUstrSizeUtf16 { get; }
    public al_ustr_encode_utf16 AlUstrEncodeUtf16 { get; }
    public al_utf8_width AlUtf8Width { get; }
    public al_utf8_encode AlUtf8Encode { get; }
    public al_utf16_width AlUtf16Width { get; }
    public al_utf16_encode AlUtf16Encode { get; }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_ustr_new(IntPtr s);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_ustr_new_from_buffer(in byte[] s, UIntPtr size);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_ustr_free(IntPtr us);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_cstr(IntPtr us);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_ustr_to_buffer(IntPtr us, byte[] buffer, int size);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_cstr_dup(IntPtr us);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_ustr_dup(IntPtr us);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_ustr_dup_substr(IntPtr us, int start_pos, int end_pos);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_ustr_empty_string();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_ref_cstr(ref AllegroUstrInfo info, IntPtr s);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_ref_buffer(ref AllegroUstrInfo info, IntPtr s, UIntPtr size);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_ref_ustr(ref AllegroUstrInfo info, IntPtr us, int start_pos, int end_pos);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate UIntPtr al_ustr_size(IntPtr us);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate UIntPtr al_ustr_length(IntPtr us);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_ustr_offset(IntPtr us, int index);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte al_ustr_next(IntPtr us, ref int pos);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte al_ustr_prev(IntPtr us, ref int pos);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_ustr_get(IntPtr ub, int pos);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_ustr_get_next(IntPtr us, ref int pos);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_ustr_prev_get(IntPtr us, ref int pos);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte al_ustr_insert(IntPtr us1, int pos, IntPtr us2);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte al_ustr_insert_cstr(IntPtr us, int pos, IntPtr s);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate UIntPtr al_ustr_insert_chr(IntPtr us, int pos, int c);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte al_ustr_append(IntPtr us1, IntPtr us2);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte al_ustr_append_cstr(IntPtr us, IntPtr s);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate UIntPtr al_ustr_append_chr(IntPtr us, int c);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte al_ustr_remove_chr(IntPtr us, int pos);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte al_ustr_remove_range(IntPtr us, int start_pos, int end_pos);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte al_ustr_truncate(IntPtr us, int start_pos);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte al_ustr_ltrim_ws(IntPtr us);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte al_ustr_rtrim_ws(IntPtr us);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte al_ustr_trim_ws(IntPtr us);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte al_ustr_assign(IntPtr us1, IntPtr us2);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte al_ustr_assign_substr(IntPtr us1, IntPtr us2, int start_pos, int end_pos);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte al_ustr_assign_cstr(IntPtr us, IntPtr s);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate UIntPtr al_ustr_set_chr(IntPtr us, int start_pos, int c);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte al_ustr_replace_range(IntPtr us1, int start_pos, int end_pos, IntPtr us2);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_ustr_find_chr(IntPtr us, int start_pos, int c);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_ustr_rfind_chr(IntPtr us, int end_pos, int c);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_ustr_find_set(IntPtr us, int start_pos, IntPtr accept);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_ustr_find_set_cstr(IntPtr us, int start_pos, IntPtr accept);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_ustr_find_cset(IntPtr us, int start_pos, IntPtr reject);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_ustr_find_cset_cstr(IntPtr us, int start_pos, IntPtr reject);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_ustr_find_str(IntPtr haystack, int start_pos, IntPtr needle);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_ustr_find_cstr(IntPtr haystack, int start_pos, IntPtr needle);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_ustr_rfind_str(IntPtr haystack, int end_pos, IntPtr needle);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_ustr_rfind_cstr(IntPtr haystack, int end_position, IntPtr needle);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte al_ustr_find_replace(IntPtr us, int start_pos, IntPtr find, IntPtr replace);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte al_ustr_find_replace_cstr(IntPtr us, int start_pos, IntPtr find, IntPtr replace);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte al_ustr_equal(IntPtr us1, IntPtr us2);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_ustr_compare(IntPtr us1, IntPtr us2);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_ustr_ncompare(IntPtr us1, IntPtr us2, int n);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte al_ustr_has_prefix(IntPtr us1, IntPtr us2);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte al_ustr_has_prefix_cstr(IntPtr us1, IntPtr s2);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte al_ustr_has_suffix(IntPtr us1, IntPtr us2);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte al_ustr_has_suffix_cstr(IntPtr us1, IntPtr s2);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_ustr_new_from_utf16(char[] s);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate UIntPtr al_ustr_size_utf16(IntPtr us);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate UIntPtr al_ustr_encode_utf16(IntPtr us, char[] s, UIntPtr n);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate UIntPtr al_utf8_width(int c);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate UIntPtr al_utf8_encode(byte[] s, int c);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate UIntPtr al_utf16_width(int c);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate UIntPtr al_utf16_encode(char[] s, int c);

    #endregion

    public CoreContext()
    {
      // Configuration routines
      AlCreateConfig = LoadFunction<al_create_config>();
      AlDestroyConfig = LoadFunction<al_destroy_config>();
      AlLoadConfigFile = LoadFunction<al_load_config_file>();
      AlLoadConfigFileF = LoadFunction<al_load_config_file_f>();
      AlSaveConfigFile = LoadFunction<al_save_config_file>();
      AlSaveConfigFileF = LoadFunction<al_save_config_file_f>();
      AlAddConfigSection = LoadFunction<al_add_config_section>();
      AlRemoveConfigSection = LoadFunction<al_remove_config_section>();
      AlAddConfigComment = LoadFunction<al_add_config_comment>();
      AlGetConfigValue = LoadFunction<al_get_config_value>();
      AlSetConfigValue = LoadFunction<al_set_config_value>();
      AlRemoveConfigKey = LoadFunction<al_remove_config_key>();
      AlGetFirstConfigSection = LoadFunction<al_get_first_config_section>();
      AlGetNextConfigSection = LoadFunction<al_get_next_config_section>();
      AlGetFirstConfigEntry = LoadFunction<al_get_first_config_entry>();
      AlGetNextConfigEntry = LoadFunction<al_get_next_config_entry>();
      AlMergeConfig = LoadFunction<al_merge_config>();
      AlMergeConfigInto = LoadFunction<al_merge_config_into>();

      // Display routines
      AlCreateDisplay = LoadFunction<al_create_display>();
      AlDestroyDisplay = LoadFunction<al_destroy_display>();
      AlGetNewDisplayFlags = LoadFunction<al_get_new_display_flags>();
      AlSetNewDisplayFlags = LoadFunction<al_set_new_display_flags>();
      AlGetNewDisplayOption = LoadFunction<al_get_new_display_option>();
      AlSetNewDisplayOption = LoadFunction<al_set_new_display_option>();
      AlResetNewDisplayOptions = LoadFunction<al_reset_new_display_options>();
      AlGetNewWindowPosition = LoadFunction<al_get_new_window_position>();
      AlSetNewWindowPosition = LoadFunction<al_set_new_window_position>();
      AlGetNewDisplayRefreshRate = LoadFunction<al_get_new_display_refresh_rate>();
      AlSetNewDisplayRefreshRate = LoadFunction<al_set_new_display_refresh_rate>();
      AlGetDisplayEventSource = LoadFunction<al_get_display_event_source>();
      AlGetBackbuffer = LoadFunction<al_get_backbuffer>();
      AlFlipDisplay = LoadFunction<al_flip_display>();
      AlUpdateDisplayRegion = LoadFunction<al_update_display_region>();
      AlWaitForVsync = LoadFunction<al_wait_for_vsync>();
      AlGetDisplayWidth = LoadFunction<al_get_display_width>();
      AlGetDisplayHeight = LoadFunction<al_get_display_height>();
      AlResizeDisplay = LoadFunction<al_resize_display>();
      AlAcknowledgeResize = LoadFunction<al_acknowledge_resize>();
      AlGetWindowPosition = LoadFunction<al_get_window_position>();
      AlSetWindowPosition = LoadFunction<al_set_window_position>();
      AlGetWindowConstraints = LoadFunction<al_get_window_constraints>();
      AlSetWindowConstraints = LoadFunction<al_set_window_constraints>();
      AlApplyWindowConstraints = LoadFunction<al_apply_window_constraints>();
      AlGetDisplayFlags = LoadFunction<al_get_display_flags>();
      AlSetDisplayFlag = LoadFunction<al_set_display_flag>();
      AlGetDisplayOption = LoadFunction<al_get_display_option>();
      AlSetDisplayOption = LoadFunction<al_set_display_option>();
      AlGetDisplayFormat = LoadFunction<al_get_display_format>();
      AlGetDisplayOrientation = LoadFunction<al_get_display_orientation>();
      AlGetDisplayRefreshRate = LoadFunction<al_get_display_refresh_rate>();
      AlSetWindowTitle = LoadFunction<al_set_window_title>();
      AlSetNewWindowTitle = LoadFunction<al_set_new_window_title>();
      AlGetNewWindowTitle = LoadFunction<al_get_new_window_title>();
      AlSetDisplayIcon = LoadFunction<al_set_display_icon>();
      AlSetDisplayIcons = LoadFunction<al_set_display_icons>();
      AlAcknowledgeDrawingHalt = LoadFunction<al_acknowledge_drawing_halt>();
      AlAcknowledgeDrawingResume = LoadFunction<al_acknowledge_drawing_resume>();
      AlInhibitScreensaver = LoadFunction<al_inhibit_screensaver>();
      AlGetClipboardText = LoadFunction<al_get_clipboard_text>();
      AlSetClipboardText = LoadFunction<al_set_clipboard_text>();
      AlClipboardHasText = LoadFunction<al_clipboard_has_text>();

      // Event routines
      AlCreateEventQueue = LoadFunction<al_create_event_queue>();
      AlDestroyEventQueue = LoadFunction<al_destroy_event_queue>();
      AlRegisterEventSource = LoadFunction<al_register_event_source>();
      AlUnregisterEventSource = LoadFunction<al_unregister_event_source>();
      AlIsEventSourceRegistered = LoadFunction<al_is_event_source_registered>();
      AlPauseEventQueue = LoadFunction<al_pause_event_queue>();
      AlIsEventQueuePaused = LoadFunction<al_is_event_queue_paused>();
      AlIsEventQueueEmpty = LoadFunction<al_is_event_queue_empty>();
      AlGetNextEvent = LoadFunction<al_get_next_event>();
      AlPeekNextEvent = LoadFunction<al_peek_next_event>();
      AlDropNextEvent = LoadFunction<al_drop_next_event>();
      AlFlushEventQueue = LoadFunction<al_flush_event_queue>();
      AlWaitForEvent = LoadFunction<al_wait_for_event>();
      AlWaitForEventTimed = LoadFunction<al_wait_for_event_timed>();
      AlWaitForEventUntil = LoadFunction<al_wait_for_event_until>();
      AlInitUserEventSource = LoadFunction<al_init_user_event_source>();
      AlDestroyUserEventSource = LoadFunction<al_destroy_user_event_source>();
      AlEmitUserEvent = LoadFunction<al_emit_user_event>();
      AlUnrefUserEvent = LoadFunction<al_unref_user_event>();
      AlGetEventSourceData = LoadFunction<al_get_event_source_data>();
      AlSetEventSourceData = LoadFunction<al_set_event_source_data>();

      // File I/O routines
      AlFOpen = LoadFunction<al_fopen>();
      AlFOpenInterface = LoadFunction<al_fopen_interface>();
      AlFOpenSlice = LoadFunction<al_fopen_slice>();
      AlFClose = LoadFunction<al_fclose>();
      AlFRead = LoadFunction<al_fread>();
      AlFWrite = LoadFunction<al_fwrite>();
      AlFFlush = LoadFunction<al_fflush>();
      AlFTell = LoadFunction<al_ftell>();
      AlFSeek = LoadFunction<al_fseek>();
      AlFEof = LoadFunction<al_feof>();
      AlFError = LoadFunction<al_ferror>();
      AlFErrMsg = LoadFunction<al_ferrmsg>();
      AlFClearErr = LoadFunction<al_fclearerr>();
      AlFUngetC = LoadFunction<al_fungetc>();
      AlFSize = LoadFunction<al_fsize>();
      AlFGetC = LoadFunction<al_fgetc>();
      AlFPutC = LoadFunction<al_fputc>();
      AlFRead16LE = LoadFunction<al_fread16le>();
      AlFRead16BE = LoadFunction<al_fread16be>();
      AlFWrite16LE = LoadFunction<al_fwrite16le>();
      AlFWrite16BE = LoadFunction<al_fwrite16be>();
      AlFRead32LE = LoadFunction<al_fread32le>();
      AlFRead32BE = LoadFunction<al_fread32be>();
      AlFWrite32LE = LoadFunction<al_fwrite32le>();
      AlFWrite32BE = LoadFunction<al_fwrite32be>();
      AlFGetS = LoadFunction<al_fgets>();
      AlFGetUstr = LoadFunction<al_fget_ustr>();
      AlFPutS = LoadFunction<al_fputs>();
      AlFOpenFd = LoadFunction<al_fopen_fd>();
      AlMakeTempFile = LoadFunction<al_make_temp_file>();
      AlSetNewFileInterface = LoadFunction<al_set_new_file_interface>();
      AlSetStandardFileInterface = LoadFunction<al_set_standard_file_interface>();
      AlGetNewFileInterface = LoadFunction<al_get_new_file_interface>();
      AlCreateFileHandle = LoadFunction<al_create_file_handle>();
      AlGetFileUserdata = LoadFunction<al_get_file_userdata>();

      // File system routines
      AlCreateFsEntry = LoadFunction<al_create_fs_entry>();
      AlDestroyFsEntry = LoadFunction<al_destroy_fs_entry>();
      AlGetFsEntryName = LoadFunction<al_get_fs_entry_name>();
      AlUpdateFsEntry = LoadFunction<al_update_fs_entry>();
      AlGetFsEntryMode = LoadFunction<al_get_fs_entry_mode>();
      AlGetFsEntryAtime = LoadFunction<al_get_fs_entry_atime>();
      AlGetFsEntryCtime = LoadFunction<al_get_fs_entry_ctime>();
      AlGetFsEntryMtime = LoadFunction<al_get_fs_entry_mtime>();
      AlGetFsEntrySize = LoadFunction<al_get_fs_entry_size>();
      AlFsEntryExists = LoadFunction<al_fs_entry_exists>();
      AlRemoveFsEntry = LoadFunction<al_remove_fs_entry>();
      AlFilenameExists = LoadFunction<al_filename_exists>();
      AlRemoveFilename = LoadFunction<al_remove_filename>();
      AlOpenDirectory = LoadFunction<al_open_directory>();
      AlReadDirectory = LoadFunction<al_read_directory>();
      AlCloseDirectory = LoadFunction<al_close_directory>();
      AlGetCurrentDirectory = LoadFunction<al_get_current_directory>();
      AlChangeDirectory = LoadFunction<al_change_directory>();
      AlMakeDirectory = LoadFunction<al_make_directory>();
      ALOpenFsEntry = LoadFunction<al_open_fs_entry>();
      AlForEachFsEntry = LoadFunction<al_for_each_fs_entry>();
      AlSetFsInterface = LoadFunction<al_set_fs_interface>();
      AlSetStandardFsInterface = LoadFunction<al_set_standard_fs_interface>();
      AlGetFsInterface = LoadFunction<al_get_fs_interface>();

      // Fixed point math routines
      AlIToFix = LoadFunction<al_itofix>();
      AlFixToI = LoadFunction<al_fixtoi>();
      AlFixFloor = LoadFunction<al_fixfloor>();
      AlFixCeil = LoadFunction<al_fixceil>();
      AlFToFix = LoadFunction<al_ftofix>();
      AlFixToF = LoadFunction<al_fixtof>();
      AlFixMul = LoadFunction<al_fixmul>();
      AlFixDiv = LoadFunction<al_fixdiv>();
      AlFixAdd = LoadFunction<al_fixadd>();
      AlFixSub = LoadFunction<al_fixsub>();
      AlFixSin = LoadFunction<al_fixsin>();
      AlFixCos = LoadFunction<al_fixcos>();
      AlFixTan = LoadFunction<al_fixtan>();
      AlFixAsin = LoadFunction<al_fixasin>();
      AlFixAcos = LoadFunction<al_fixacos>();
      AlFixAtan = LoadFunction<al_fixatan>();
      AlFixAtan2 = LoadFunction<al_fixatan2>();
      AlFixSqrt = LoadFunction<al_fixsqrt>();
      AlFixHypot = LoadFunction<al_fixhypot>();

      // Fullscreen routines
      AlGetDisplayMode = LoadFunction<al_get_display_mode>();
      AlGetNumDisplayModes = LoadFunction<al_get_num_display_modes>();

      // Graphics routines
      AlMapRgb = LoadFunction<al_map_rgb>();
      AlMapRgbF = LoadFunction<al_map_rgb_f>();
      AlMapRgba = LoadFunction<al_map_rgba>();
      AlPremulRgba = LoadFunction<al_premul_rgba>();
      AlMapRgbaF = LoadFunction<al_map_rgba_f>();
      AlPremulRgbaF = LoadFunction<al_premul_rgba_f>();
      AlUnmapRgb = LoadFunction<al_unmap_rgb>();
      AlUnmapRgbF = LoadFunction<al_unmap_rgb_f>();
      AlUnmapRgba = LoadFunction<al_unmap_rgba>();
      AlUnmapRgbaF = LoadFunction<al_unmap_rgba_f>();
      AlGetPixelSize = LoadFunction<al_get_pixel_size>();
      AlGetPixelFormatBits = LoadFunction<al_get_pixel_format_bits>();
      AlGetPixelBlockSize = LoadFunction<al_get_pixel_block_size>();
      AlGetPixelBlockWidth = LoadFunction<al_get_pixel_block_width>();
      AlGetPixelBlockHeight = LoadFunction<al_get_pixel_block_height>();
      AlLockBitmap = LoadFunction<al_lock_bitmap>();
      AlLockBitmapRegion = LoadFunction<al_lock_bitmap_region>();
      AlUnlockBitmap = LoadFunction<al_unlock_bitmap>();
      AlLockBitmapBlocked = LoadFunction<al_lock_bitmap_blocked>();
      AlLockBitmapRegionBlocked = LoadFunction<al_lock_bitmap_region_blocked>();
      AlCreateBitmap = LoadFunction<al_create_bitmap>();
      AlCreateSubBitmap = LoadFunction<al_create_sub_bitmap>();
      AlCloneBitmap = LoadFunction<al_clone_bitmap>();
      AlConvertBitmap = LoadFunction<al_convert_bitmap>();
      AlConvertMemoryBitmaps = LoadFunction<al_convert_memory_bitmaps>();
      AlDestroyBitmap = LoadFunction<al_destroy_bitmap>();
      AlGetNewBitmapFlags = LoadFunction<al_get_new_bitmap_flags>();
      AlGetNewBitmapFormat = LoadFunction<al_get_new_bitmap_format>();
      AlSetNewBitmapFlags = LoadFunction<al_set_new_bitmap_flags>();
      AlAddNewBitmapFlag = LoadFunction<al_add_new_bitmap_flag>();
      AlSetNewBitmapFormat = LoadFunction<al_set_new_bitmap_format>();
      AlGetBitmapFlags = LoadFunction<al_get_bitmap_flags>();
      AlGetBitmapFormat = LoadFunction<al_get_bitmap_format>();
      AlGetBitmapHeight = LoadFunction<al_get_bitmap_height>();
      AlGetBitmapWidth = LoadFunction<al_get_bitmap_width>();
      AlGetPixel = LoadFunction<al_get_pixel>();
      AlIsBitmapLocked = LoadFunction<al_is_bitmap_locked>();
      AlIsCompatibleBitmap = LoadFunction<al_is_compatible_bitmap>();
      AlIsSubBitmap = LoadFunction<al_is_sub_bitmap>();
      AlGetParentBitmap = LoadFunction<al_get_parent_bitmap>();
      AlGetBitmapX = LoadFunction<al_get_bitmap_x>();
      AlGetBitmapY = LoadFunction<al_get_bitmap_y>();
      AlReparentBitmap = LoadFunction<al_reparent_bitmap>();
      AlClearToColor = LoadFunction<al_clear_to_color>();
      AlClearDepthBuffer = LoadFunction<al_clear_depth_buffer>();
      AlDrawBitmap = LoadFunction<al_draw_bitmap>();
      AlDrawTintedBitmap = LoadFunction<al_draw_tinted_bitmap>();
      AlDrawBitmapRegion = LoadFunction<al_draw_bitmap_region>();
      AlDrawTintedBitmapRegion = LoadFunction<al_draw_tinted_bitmap_region>();
      AlDrawPixel = LoadFunction<al_draw_pixel>();
      AlDrawRotatedBitmap = LoadFunction<al_draw_rotated_bitmap>();
      AlDrawTintedRotatedBitmap = LoadFunction<al_draw_tinted_rotated_bitmap>();
      AlDrawScaledRotatedBitmap = LoadFunction<al_draw_scaled_rotated_bitmap>();
      AlDrawTintedScaledRotatedBitmap = LoadFunction<al_draw_tinted_scaled_rotated_bitmap>();
      AlDrawTintedScaledRotatedBitmapRegion = LoadFunction<al_draw_tinted_scaled_rotated_bitmap_region>();
      AlDrawScaledBitmap = LoadFunction<al_draw_scaled_bitmap>();
      AlDrawTintedScaledBitmap = LoadFunction<al_draw_tinted_scaled_bitmap>();
      AlGetTargetBitmap = LoadFunction<al_get_target_bitmap>();
      AlPutPixel = LoadFunction<al_put_pixel>();
      AlPutBlendedPixel = LoadFunction<al_put_blended_pixel>();
      AlSetTargetBitmap = LoadFunction<al_set_target_bitmap>();
      AlSetTargetBackbuffer = LoadFunction<al_set_target_backbuffer>();
      AlGetCurrentDisplay = LoadFunction<al_get_current_display>();
      AlGetBlender = LoadFunction<al_get_blender>();
      AlGetSeparateBlender = LoadFunction<al_get_separate_blender>();
      AlGetBlendColor = LoadFunction<al_get_blend_color>();
      AlSetBlender = LoadFunction<al_set_blender>();
      AlSetSeparateBlender = LoadFunction<al_set_separate_blender>();
      AlSetBlendColor = LoadFunction<al_set_blend_color>();
      AlGetClippingRectangle = LoadFunction<al_get_clipping_rectangle>();
      AlSetClippingRectangle = LoadFunction<al_set_clipping_rectangle>();
      AlResetClippingRectangle = LoadFunction<al_reset_clipping_rectangle>();
      AlConvertMaskToAlpha = LoadFunction<al_convert_mask_to_alpha>();
      AlHoldBitmapDrawing = LoadFunction<al_hold_bitmap_drawing>();
      AlIsBitmapDrawingHeld = LoadFunction<al_is_bitmap_drawing_held>();
      AlLoadBitmap = LoadFunction<al_load_bitmap>();
      AlLoadBitmapFlags = LoadFunction<al_load_bitmap_flags>();
      AlLoadBitmapF = LoadFunction<al_load_bitmap_f>();
      AlLoadBitmapFlagsF = LoadFunction<al_load_bitmap_flags_f>();
      AlSaveBitmap = LoadFunction<al_save_bitmap>();
      AlSaveBitmapF = LoadFunction<al_save_bitmap_f>();
      AlSetRenderState = LoadFunction<al_set_render_state>();

      // Joystick routines
      AlInstallJoystick = LoadFunction<al_install_joystick>();
      AlUninstallJoystick = LoadFunction<al_uninstall_joystick>();
      AlIsJoystickInstalled = LoadFunction<al_is_joystick_installed>();
      AlReconfigureJoysticks = LoadFunction<al_reconfigure_joysticks>();
      AlGetNumJoysticks = LoadFunction<al_get_num_joysticks>();
      AlGetJoystick = LoadFunction<al_get_joystick>();
      AlReleaseJoystick = LoadFunction<al_release_joystick>();
      AlGetJoystickActive = LoadFunction<al_get_joystick_active>();
      AlGetJoystickName = LoadFunction<al_get_joystick_name>();
      AlGetJoystickNumSticks = LoadFunction<al_get_joystick_num_sticks>();
      AlGetJoystickStickFlags = LoadFunction<al_get_joystick_stick_flags>();
      AlGetJoystickStickName = LoadFunction<al_get_joystick_stick_name>();
      AlGetJoystickNumAxes = LoadFunction<al_get_joystick_num_axes>();
      AlGetJoystickAxisName = LoadFunction<al_get_joystick_axis_name>();
      AlGetJoystickNumButtons = LoadFunction<al_get_joystick_num_buttons>();
      AlGetJoystickButtonName = LoadFunction<al_get_joystick_button_name>();
      AlGetJoystickState = LoadFunction<al_get_joystick_state>();
      AlGetJoystickEventSource = LoadFunction<al_get_joystick_event_source>();

      // Keyboard routines
      AlInstallKeyboard = LoadFunction<al_install_keyboard>();
      AlIsKeyboardInstalled = LoadFunction<al_is_keyboard_installed>();
      AlUninstallKeyboard = LoadFunction<al_uninstall_keyboard>();
      AlGetKeyboardState = LoadFunction<al_get_keyboard_state>();
      AlKeyDown = LoadFunction<al_key_down>();
      AlKeycodeToName = LoadFunction<al_keycode_to_name>();
      AlSetKeyboardLeds = LoadFunction<al_set_keyboard_leds>();
      AlGetKeyboardEventSource = LoadFunction<al_get_keyboard_event_source>();

      // Memory management routines
      AlMallocWithContext = LoadFunction<al_malloc_with_context>();
      AlFreeWithContext = LoadFunction<al_free_with_context>();
      AlReallocWithContext = LoadFunction<al_realloc_with_context>();
      AlCallocWithContext = LoadFunction<al_calloc_with_context>();
      AlSetMemoryInterface = LoadFunction<al_set_memory_interface>();

      // Monitor routines
      AlGetNewDisplayAdapter = LoadFunction<al_get_new_display_adapter>();
      AlSetNewDisplayAdapter = LoadFunction<al_set_new_display_adapter>();
      AlGetMonitorInfo = LoadFunction<al_get_monitor_info>();
      AlGetMonitorDpi = LoadFunction<al_get_monitor_dpi>();
      AlGetNumVideoAdapters = LoadFunction<al_get_num_video_adapters>();

      // Mouse routines
      AlInstallMouse = LoadFunction<al_install_mouse>();
      AlIsMouseInstalled = LoadFunction<al_is_mouse_installed>();
      AlUninstallMouse = LoadFunction<al_uninstall_mouse>();
      AlGetMouseNumAxes = LoadFunction<al_get_mouse_num_axes>();
      AlGetMouseNumButtons = LoadFunction<al_get_mouse_num_buttons>();
      AlGetMouseState = LoadFunction<al_get_mouse_state>();
      AlGetMouseStateAxis = LoadFunction<al_get_mouse_state_axis>();
      AlMouseButtonDown = LoadFunction<al_mouse_button_down>();
      AlSetMouseXY = LoadFunction<al_set_mouse_xy>();
      AlSetMouseZ = LoadFunction<al_set_mouse_z>();
      AlSetMouseW = LoadFunction<al_set_mouse_w>();
      AlSetMouseAxis = LoadFunction<al_set_mouse_axis>();
      AlGetMouseEventSource = LoadFunction<al_get_mouse_event_source>();
      AlSetMouseWheelPrecision = LoadFunction<al_set_mouse_wheel_precision>();
      AlGetMouseWheelPrecision = LoadFunction<al_get_mouse_wheel_precision>();
      AlCreateMouseCursor = LoadFunction<al_create_mouse_cursor>();
      AlDestroyMouseCursor = LoadFunction<al_destroy_mouse_cursor>();
      AlSetMouseCursor = LoadFunction<al_set_mouse_cursor>();
      AlSetSystemMouseCursor = LoadFunction<al_set_system_mouse_cursor>();
      AlGetMouseCursorPosition = LoadFunction<al_get_mouse_cursor_position>();
      AlHideMouseCursor = LoadFunction<al_hide_mouse_cursor>();
      AlShowMouseCursor = LoadFunction<al_show_mouse_cursor>();
      AlGrabMouse = LoadFunction<al_grab_mouse>();
      AlUngrabMouse = LoadFunction<al_ungrab_mouse>();

      // Path routines
      AlCreatePath = LoadFunction<al_create_path>();
      AlCreatePathForDirectory = LoadFunction<al_create_path_for_directory>();
      AlDestroyPath = LoadFunction<al_destroy_path>();
      AlClonePath = LoadFunction<al_clone_path>();
      AlJoinPaths = LoadFunction<al_join_paths>();
      AlRebasePath = LoadFunction<al_rebase_path>();
      AlGetPathDrive = LoadFunction<al_get_path_drive>();
      AlGetPathNumComponents = LoadFunction<al_get_path_num_components>();
      AlGetPathComponent = LoadFunction<al_get_path_component>();
      AlGetPathTail = LoadFunction<al_get_path_tail>();
      AlGetPathFilename = LoadFunction<al_get_path_filename>();
      AlGetPathBasename = LoadFunction<al_get_path_basename>();
      AlGetPathExtension = LoadFunction<al_get_path_extension>();
      AlSetPathDrive = LoadFunction<al_set_path_drive>();
      AlAppendPathComponent = LoadFunction<al_append_path_component>();
      AlInsertPathComponent = LoadFunction<al_insert_path_component>();
      AlReplacePathComponent = LoadFunction<al_replace_path_component>();
      AlRemovePathComponent = LoadFunction<al_remove_path_component>();
      AlDropPathTail = LoadFunction<al_drop_path_tail>();
      AlSetPathFilename = LoadFunction<al_set_path_filename>();
      AlSetPathExtension = LoadFunction<al_set_path_extension>();
      AlPathCstr = LoadFunction<al_path_cstr>();
      AlPathUstr = LoadFunction<al_path_ustr>();
      AlMakePathCanonical = LoadFunction<al_make_path_canonical>();

      // Shader routines
      AlCreateShader = LoadFunction<al_create_shader>();
      AlAttachShaderSource = LoadFunction<al_attach_shader_source>();
      AlAttachShaderSourceFile = LoadFunction<al_attach_shader_source_file>();
      AlBuildShader = LoadFunction<al_build_shader>();
      AlGetShaderLog = LoadFunction<al_get_shader_log>();
      AlGetShaderPlatform = LoadFunction<al_get_shader_platform>();
      AlUseShader = LoadFunction<al_use_shader>();
      AlDestroyShader = LoadFunction<al_destroy_shader>();
      AlSetShaderSampler = LoadFunction<al_set_shader_sampler>();
      AlSetShaderMatrix = LoadFunction<al_set_shader_matrix>();
      AlSetShaderInt = LoadFunction<al_set_shader_int>();
      AlSetShaderFloat = LoadFunction<al_set_shader_float>();
      AlSetShaderBool = LoadFunction<al_set_shader_bool>();
      AlSetShaderIntVector = LoadFunction<al_set_shader_int_vector>();
      AlSetShaderFloatVector = LoadFunction<al_set_shader_float_vector>();
      AlGetDefaultShaderSource = LoadFunction<al_get_default_shader_source>();

      // State routines
      AlRestoreState = LoadFunction<al_restore_state>();
      AlStoreState = LoadFunction<al_store_state>();
      AlGetErrno = LoadFunction<al_get_errno>();
      AlSetErrno = LoadFunction<al_set_errno>();

      // System routines
      AlInstallSystem = LoadFunction<al_install_system>();
      AlUninstallSystem = LoadFunction<al_uninstall_system>();
      AlIsSystemInstalled = LoadFunction<al_is_system_installed>();
      AlGetAllegroVersion = LoadFunction<al_get_allegro_version>();
      AlGetStandardPath = LoadFunction<al_get_standard_path>();
      AlSetExeName = LoadFunction<al_set_exe_name>();
      AlSetAppName = LoadFunction<al_set_app_name>();
      AlSetOrgName = LoadFunction<al_set_org_name>();
      AlGetAppName = LoadFunction<al_get_app_name>();
      AlGetOrgName = LoadFunction<al_get_org_name>();
      AlGetSystemConfig = LoadFunction<al_get_system_config>();
      AlGetSystemId = LoadFunction<al_get_system_id>();
      AlRegisterAssertHandler = LoadFunction<al_register_assert_handler>();
      AlRegisterTraceHandler = LoadFunction<al_register_trace_handler>();
      AlGetCpuCount = LoadFunction<al_get_cpu_count>();
      AlGetRamSize = LoadFunction<al_get_ram_size>();

      // Thread routines
      AlCreateThread = LoadFunction<al_create_thread>();
      AlStartThread = LoadFunction<al_start_thread>();
      AlJoinThread = LoadFunction<al_join_thread>();
      AlSetThreadShouldStop = LoadFunction<al_set_thread_should_stop>();
      AlGetThreadShouldStop = LoadFunction<al_get_thread_should_stop>();
      AlDestroyThread = LoadFunction<al_destroy_thread>();
      AlRunDetachedThread = LoadFunction<al_run_detached_thread>();
      AlCreateMutex = LoadFunction<al_create_mutex>();
      AlCreateMutexRecursive = LoadFunction<al_create_mutex_recursive>();
      AlLockMutex = LoadFunction<al_lock_mutex>();
      AlUnlockMutex = LoadFunction<al_unlock_mutex>();
      AlDestroyMutex = LoadFunction<al_destroy_mutex>();
      AlCreateCond = LoadFunction<al_create_cond>();
      AlDestroyCond = LoadFunction<al_destroy_cond>();
      AlWaitCond = LoadFunction<al_wait_cond>();
      AlWaitCondUntil = LoadFunction<al_wait_cond_until>();
      AlBroadcastCond = LoadFunction<al_broadcast_cond>();
      AlSignalCond = LoadFunction<al_signal_cond>();

      // Time routines
      AlGetTime = LoadFunction<al_get_time>();
      AlRest = LoadFunction<al_rest>();

      // Timer routines
      AlCreateTimer = LoadFunction<al_create_timer>();
      AlStartTimer = LoadFunction<al_start_timer>();
      AlResumeTimer = LoadFunction<al_resume_timer>();
      AlStopTimer = LoadFunction<al_stop_timer>();
      AlGetTimerStarted = LoadFunction<al_get_timer_started>();
      AlDestroyTimer = LoadFunction<al_destroy_timer>();
      AlGetTimerCount = LoadFunction<al_get_timer_count>();
      AlSetTimerCount = LoadFunction<al_set_timer_count>();
      AlAddTimerCount = LoadFunction<al_add_timer_count>();
      AlGetTimerSpeed = LoadFunction<al_get_timer_speed>();
      AlSetTimerSpeed = LoadFunction<al_set_timer_speed>();
      AlGetTimerEventSource = LoadFunction<al_get_timer_event_source>();

      // Touch routines
      AlInstallTouchInput = LoadFunction<al_install_touch_input>();
      AlUninstallTouchInput = LoadFunction<al_uninstall_touch_input>();
      AlIsTouchInputInstalled = LoadFunction<al_is_touch_input_installed>();
      AlGetTouchInputState = LoadFunction<al_get_touch_input_state>();
      AlGetTouchInputEventSource = LoadFunction<al_get_touch_input_event_source>();

      // Transform routines
      AlCopyTransform = LoadFunction<al_copy_transform>();
      AlUseTransform = LoadFunction<al_use_transform>();
      AlGetCurrentTransform = LoadFunction<al_get_current_transform>();
      AlUseProjectionTransform = LoadFunction<al_use_projection_transform>();
      AlGetCurrentProjectionTransform = LoadFunction<al_get_current_projection_transform>();
      AlGetCurrentInverseTransform = LoadFunction<al_get_current_inverse_transform>();
      AlInvertTransform = LoadFunction<al_invert_transform>();
      AlTransposeTransform = LoadFunction<al_transpose_transform>();
      AlCheckInverse = LoadFunction<al_check_inverse>();
      AlIdentityTransform = LoadFunction<al_identity_transform>();
      AlBuildTransform = LoadFunction<al_build_transform>();
      AlBuildCameraTransform = LoadFunction<al_build_camera_transform>();
      AlTranslateTransform = LoadFunction<al_translate_transform>();
      AlRotateTransform = LoadFunction<al_rotate_transform>();
      AlScaleTransform = LoadFunction<al_scale_transform>();
      AlTransformCoordinates = LoadFunction<al_transform_coordinates>();
      AlTransformCoordinates3D = LoadFunction<al_transform_coordinates_3d>();
      AlTransformCoordinates4D = LoadFunction<al_transform_coordinates_4d>();
      AlTransformCoordinates3DProjective = LoadFunction<al_transform_coordinates_3d_projective>();
      AlComposeTransform = LoadFunction<al_compose_transform>();
      AlOrthographicTransform = LoadFunction<al_orthographic_transform>();
      AlPerspectiveTransform = LoadFunction<al_perspective_transform>();
      AlTranslateTransform3D = LoadFunction<al_translate_transform_3d>();
      AlScaleTransform3D = LoadFunction<al_scale_transform_3d>();
      AlRotateTransform3D = LoadFunction<al_rotate_transform_3d>();
      AlHorizontalShearTransform = LoadFunction<al_horizontal_shear_transform>();
      AlVerticalShearTransform = LoadFunction<al_vertical_shear_transform>();

      // UTF-8 routines
      AlUstrNew = LoadFunction<al_ustr_new>();
      AlUstrNewFromBuffer = LoadFunction<al_ustr_new_from_buffer>();
      AlUstrFree = LoadFunction<al_ustr_free>();
      AlCstr = LoadFunction<al_cstr>();
      AlUstrToBuffer = LoadFunction<al_ustr_to_buffer>();
      AlCstrDup = LoadFunction<al_cstr_dup>();
      AlUstrDup = LoadFunction<al_ustr_dup>();
      AlUstrDupSubstr = LoadFunction<al_ustr_dup_substr>();
      AlUstrEmptyString = LoadFunction<al_ustr_empty_string>();
      AlRefCstr = LoadFunction<al_ref_cstr>();
      AlRefBuffer = LoadFunction<al_ref_buffer>();
      AlRefUstr = LoadFunction<al_ref_ustr>();
      AlUstrSize = LoadFunction<al_ustr_size>();
      AlUstrLength = LoadFunction<al_ustr_length>();
      AlUstrOffset = LoadFunction<al_ustr_offset>();
      AlUstrNext = LoadFunction<al_ustr_next>();
      AlUstrPrev = LoadFunction<al_ustr_prev>();
      AlUstrGet = LoadFunction<al_ustr_get>();
      AlUstrGetNext = LoadFunction<al_ustr_get_next>();
      AlUstrPrevGet = LoadFunction<al_ustr_prev_get>();
      AlUstrInsert = LoadFunction<al_ustr_insert>();
      AlUstrInsertCstr = LoadFunction<al_ustr_insert_cstr>();
      AlUstrInsertChr = LoadFunction<al_ustr_insert_chr>();
      AlUstrAppend = LoadFunction<al_ustr_append>();
      AlUstrAppendCstr = LoadFunction<al_ustr_append_cstr>();
      AlUstrAppendChr = LoadFunction<al_ustr_append_chr>();
      AlUstrRemoveChr = LoadFunction<al_ustr_remove_chr>();
      AlUstrRemoveRange = LoadFunction<al_ustr_remove_range>();
      AlUstrTruncate = LoadFunction<al_ustr_truncate>();
      AlUstrLtrimWs = LoadFunction<al_ustr_ltrim_ws>();
      AlUstrRtrimWs = LoadFunction<al_ustr_rtrim_ws>();
      AlUstrTrimWs = LoadFunction<al_ustr_trim_ws>();
      AlUstrAssign = LoadFunction<al_ustr_assign>();
      AlUstrAssignSubstr = LoadFunction<al_ustr_assign_substr>();
      AlUstrAssignCstr = LoadFunction<al_ustr_assign_cstr>();
      AlUstrSetChr = LoadFunction<al_ustr_set_chr>();
      AlUstrReplaceRange = LoadFunction<al_ustr_replace_range>();
      AlUstrFindChr = LoadFunction<al_ustr_find_chr>();
      AlUstrRfindChr = LoadFunction<al_ustr_rfind_chr>();
      AlUstrFindSet = LoadFunction<al_ustr_find_set>();
      AlUstrFindSetCstr = LoadFunction<al_ustr_find_set_cstr>();
      AlUstrFindCset = LoadFunction<al_ustr_find_cset>();
      AlUstrFindCsetCstr = LoadFunction<al_ustr_find_cset_cstr>();
      AlUstrFindStr = LoadFunction<al_ustr_find_str>();
      AlUstrFindCstr = LoadFunction<al_ustr_find_cstr>();
      AlUstrRfindStr = LoadFunction<al_ustr_rfind_str>();
      AlUstrRfindCstr = LoadFunction<al_ustr_rfind_cstr>();
      AlUstrFindReplace = LoadFunction<al_ustr_find_replace>();
      AlUstrFindReplaceCstr = LoadFunction<al_ustr_find_replace_cstr>();
      AlUstrEqual = LoadFunction<al_ustr_equal>();
      AlUstrCompare = LoadFunction<al_ustr_compare>();
      AlUstrNcompare = LoadFunction<al_ustr_ncompare>();
      AlUstrHasPrefix = LoadFunction<al_ustr_has_prefix>();
      AlUstrHasPrefixCstr = LoadFunction<al_ustr_has_prefix_cstr>();
      AlUstrHasSuffix = LoadFunction<al_ustr_has_suffix>();
      AlUstrHasSuffixCstr = LoadFunction<al_ustr_has_suffix_cstr>();
      AlUstrNewFromUtf16 = LoadFunction<al_ustr_new_from_utf16>();
      AlUstrSizeUtf16 = LoadFunction<al_ustr_size_utf16>();
      AlUstrEncodeUtf16 = LoadFunction<al_ustr_encode_utf16>();
      AlUtf8Width = LoadFunction<al_utf8_width>();
      AlUtf8Encode = LoadFunction<al_utf8_encode>();
      AlUtf16Width = LoadFunction<al_utf16_width>();
      AlUtf16Encode = LoadFunction<al_utf16_encode>();
    }
  }
}
