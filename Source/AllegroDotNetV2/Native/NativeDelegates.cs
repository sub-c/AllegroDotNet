using System.Runtime.InteropServices;
using SubC.AllegroDotNet.Native.Structs;
using static SubC.AllegroDotNet.Native.Delegates;

namespace SubC.AllegroDotNet.Native;

internal static class NativeDelegates
{
  #region Display Routines

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
  public delegate byte al_emit_user_event(IntPtr source, ref AllegroEvent @event, UserEventDeconstructor? dtor);

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_unref_user_event(ref AllegroEvent @event);

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_get_event_source_data(IntPtr source);

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_set_event_source_data(IntPtr source, IntPtr data);
  
  #endregion

  #region Fullscreen Routines

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_get_display_mode(int index, ref Native.Structs.AllegroDisplayMode mode);

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate int al_get_num_display_modes();
  
  #endregion
  
  #region Graphics Routines

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate Native.Structs.AllegroColor al_map_rgb(byte r, byte g, byte b);

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate Native.Structs.AllegroColor al_map_rgb_f(float r, float g, float b);

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate Native.Structs.AllegroColor al_map_rgba(byte r, byte g, byte b, byte a);

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate Native.Structs.AllegroColor al_premul_rgba(byte r, byte g, byte b, byte a);

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate Native.Structs.AllegroColor al_map_rgba_f(float r, float g, float b, float a);

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate Native.Structs.AllegroColor al_premul_rgba_f(float r, float g, float b, float a);

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_unmap_rgb(Native.Structs.AllegroColor color, ref byte r, ref byte g, ref byte b);

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_unmap_rgb_f(Native.Structs.AllegroColor color, ref float r, ref float g, ref float b);

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_unmap_rgba(Native.Structs.AllegroColor color, ref byte r, ref byte g, ref byte b, ref byte a);

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_unmap_rgba_f(Native.Structs.AllegroColor color, ref float r, ref float g, ref float b, ref float a);

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

  public static al_is_bitmap_locked AlIsBitmapLocked = null!;

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

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate byte al_register_bitmap_loader(IntPtr extension, BitmapLoaderDelegate? loader);

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate byte al_register_bitmap_saver(IntPtr extension, BitmapSaverDelegate? saver);

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate byte al_register_bitmap_loader_f(IntPtr extension, BitmapLoaderFDelegate? fs_loader);

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate byte al_register_bitmap_saver_f(IntPtr extension, BitmapSaverFDelegate? fs_saver);

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_load_bitmap(IntPtr filename);

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_load_bitmap_flags(IntPtr filename, int flags);

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_load_bitmap_f(IntPtr fp, IntPtr ident);

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_load_bitmap_flags_f(IntPtr fp, IntPtr ident, int flags);

  public static al_load_bitmap_flags_f AlLoadBitmapFlagsF = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate byte al_save_bitmap(IntPtr filename, IntPtr bitmap);

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate byte al_save_bitmap_f(IntPtr fp, IntPtr ident, IntPtr bitmap);

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate byte al_register_bitmap_identifier(IntPtr extension, BitmapIdentifierDelegate? identifier);

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_identify_bitmap(IntPtr filename);

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_identify_bitmap_f(IntPtr fp);

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_set_render_state(int state, int value);
  
  #endregion
  
  #region Image I/O Routines

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate byte al_init_image_addon();

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate byte al_is_image_addon_initialized();

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_shutdown_image_addon();

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate uint al_get_allegro_image_version();

  #endregion

  #region Keyboard Routines

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate byte al_install_keyboard();

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate byte al_is_keyboard_installed();

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_uninstall_keyboard();

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_get_keyboard_state(ref Native.Structs.AllegroKeyboardState state);

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate bool al_key_down(ref Native.Structs.AllegroKeyboardState state, int keycode);

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_keycode_to_name(int keycode);

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate byte al_can_set_keyboard_leds();

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate byte al_set_keyboard_leds(int leds);

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_get_keyboard_event_source();

  #endregion
  
  #region System Routines
  
  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate byte al_install_system(int version, AtExitDelegate? atExit);
  
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

  public static al_set_app_name AlSetAppName = null!;

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

  public static al_get_system_id AlGetSystemID = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_register_assert_handler(RegisterAssertHandlerDelegate? handler);

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_register_trace_handler(RegisterTraceHandlerDelegate? handler);

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate int al_get_cpu_count();

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate int al_get_ram_size();

  #endregion

  #region Time Routines

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate double al_get_time();

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_init_timeout(ref AllegroTimeout timeout, double seconds);

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_rest(double seconds);

  #endregion
  
  #region Timer Routines

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
}