using static SubC.AllegroDotNet.Native.NativeDelegates;

namespace SubC.AllegroDotNet.Native;

internal partial class Context
{
  public sealed class CoreApi
  {
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

    #endregion

    #region Fullscreen Routines
    
    public al_get_display_mode AlGetDisplayMode { get; }
    public al_get_num_display_modes AlGetNumDisplayModes { get; }
    
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
    public al_register_bitmap_loader AlRegisterBitmapLoader { get; }
    public al_register_bitmap_saver AlRegisterBitmapSaver { get; }
    public al_register_bitmap_loader_f AlRegisterBitmapLoaderF { get; }
    public al_register_bitmap_saver_f AlRegisterBitmapSaverF { get; }
    public al_load_bitmap AlLoadBitmap { get; }
    public al_load_bitmap_flags AlLoadBitmapFlags { get; }
    public al_load_bitmap_f AlLoadBitmapF { get; }
    public al_load_bitmap_flags_f AlLoadBitmapFlagsF { get; }
    public al_save_bitmap AlSaveBitmap { get; }
    public al_save_bitmap_f AlSaveBitmapF { get; }
    public al_register_bitmap_identifier AlRegisterBitmapIdentifier { get; }
    public al_identify_bitmap AlIdentifyBitmap { get; }
    public al_identify_bitmap_f AlIdentifyBitmapF { get; }
    public al_set_render_state AlSetRenderState { get; }
    
    #endregion

    #region Keyboard Routines

    public al_install_keyboard AlInstallKeyboard { get; }
    public al_is_keyboard_installed AlIsKeyboardInstalled { get; }
    public al_uninstall_keyboard AlUninstallKeyboard { get; }
    public al_get_keyboard_state AlGetKeyboardState { get; }
    public al_key_down AlKeyDown { get; }
    public al_keycode_to_name AlKeycodeToName { get; }
    // public al_can_set_keyboard_leds AlCanSetKeyboardLeds { get; } // Allegro 5.2.9+
    public al_set_keyboard_leds AlSetKeyboardLeds { get; }
    public al_get_keyboard_event_source AlGetKeyboardEventSource { get; }

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

    #endregion

    #region Time Routines
    
    public al_get_time AlGetTime { get; }
    public al_init_timeout AlInitTimeout { get; }
    public al_rest AlRest { get; }
    
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

    #endregion

    public CoreApi()
    {
      // Display routines
      AlCreateDisplay = Interop.LoadFunction<al_create_display>();
      AlDestroyDisplay = Interop.LoadFunction<al_destroy_display>();
      AlGetNewDisplayFlags = Interop.LoadFunction<al_get_new_display_flags>();
      AlSetNewDisplayFlags = Interop.LoadFunction<al_set_new_display_flags>();
      AlGetNewDisplayOption = Interop.LoadFunction<al_get_new_display_option>();
      AlSetNewDisplayOption = Interop.LoadFunction<al_set_new_display_option>();
      AlResetNewDisplayOptions = Interop.LoadFunction<al_reset_new_display_options>();
      AlGetNewWindowPosition = Interop.LoadFunction<al_get_new_window_position>();
      AlSetNewWindowPosition = Interop.LoadFunction<al_set_new_window_position>();
      AlGetNewDisplayRefreshRate = Interop.LoadFunction<al_get_new_display_refresh_rate>();
      AlSetNewDisplayRefreshRate = Interop.LoadFunction<al_set_new_display_refresh_rate>();
      AlGetDisplayEventSource = Interop.LoadFunction<al_get_display_event_source>();
      AlGetBackbuffer = Interop.LoadFunction<al_get_backbuffer>();
      AlFlipDisplay = Interop.LoadFunction<al_flip_display>();
      AlUpdateDisplayRegion = Interop.LoadFunction<al_update_display_region>();
      AlWaitForVsync = Interop.LoadFunction<al_wait_for_vsync>();
      AlGetDisplayWidth = Interop.LoadFunction<al_get_display_width>();
      AlGetDisplayHeight = Interop.LoadFunction<al_get_display_height>();
      AlResizeDisplay = Interop.LoadFunction<al_resize_display>();
      AlAcknowledgeResize = Interop.LoadFunction<al_acknowledge_resize>();
      AlGetWindowPosition = Interop.LoadFunction<al_get_window_position>();
      AlSetWindowPosition = Interop.LoadFunction<al_set_window_position>();
      AlGetWindowConstraints = Interop.LoadFunction<al_get_window_constraints>();
      AlSetWindowConstraints = Interop.LoadFunction<al_set_window_constraints>();
      AlApplyWindowConstraints = Interop.LoadFunction<al_apply_window_constraints>();
      AlGetDisplayFlags = Interop.LoadFunction<al_get_display_flags>();
      AlSetDisplayFlag = Interop.LoadFunction<al_set_display_flag>();
      AlGetDisplayOption = Interop.LoadFunction<al_get_display_option>();
      AlSetDisplayOption = Interop.LoadFunction<al_set_display_option>();
      AlGetDisplayFormat = Interop.LoadFunction<al_get_display_format>();
      AlGetDisplayOrientation = Interop.LoadFunction<al_get_display_orientation>();
      AlGetDisplayRefreshRate = Interop.LoadFunction<al_get_display_refresh_rate>();
      AlSetWindowTitle = Interop.LoadFunction<al_set_window_title>();
      AlSetNewWindowTitle = Interop.LoadFunction<al_set_new_window_title>();
      AlGetNewWindowTitle = Interop.LoadFunction<al_get_new_window_title>();
      AlSetDisplayIcon = Interop.LoadFunction<al_set_display_icon>();
      AlSetDisplayIcons = Interop.LoadFunction<al_set_display_icons>();
      AlAcknowledgeDrawingHalt = Interop.LoadFunction<al_acknowledge_drawing_halt>();
      AlAcknowledgeDrawingResume = Interop.LoadFunction<al_acknowledge_drawing_resume>();
      AlInhibitScreensaver = Interop.LoadFunction<al_inhibit_screensaver>();
      AlGetClipboardText = Interop.LoadFunction<al_get_clipboard_text>();
      AlSetClipboardText = Interop.LoadFunction<al_set_clipboard_text>();
      AlClipboardHasText = Interop.LoadFunction<al_clipboard_has_text>();

      // Event routines
      AlCreateEventQueue = Interop.LoadFunction<al_create_event_queue>();
      AlDestroyEventQueue = Interop.LoadFunction<al_destroy_event_queue>();
      AlRegisterEventSource = Interop.LoadFunction<al_register_event_source>();
      AlUnregisterEventSource = Interop.LoadFunction<al_unregister_event_source>();
      AlIsEventSourceRegistered = Interop.LoadFunction<al_is_event_source_registered>();
      AlPauseEventQueue = Interop.LoadFunction<al_pause_event_queue>();
      AlIsEventQueuePaused = Interop.LoadFunction<al_is_event_queue_paused>();
      AlIsEventQueueEmpty = Interop.LoadFunction<al_is_event_queue_empty>();
      AlGetNextEvent = Interop.LoadFunction<al_get_next_event>();
      AlPeekNextEvent = Interop.LoadFunction<al_peek_next_event>();
      AlDropNextEvent = Interop.LoadFunction<al_drop_next_event>();
      AlFlushEventQueue = Interop.LoadFunction<al_flush_event_queue>();
      AlWaitForEvent = Interop.LoadFunction<al_wait_for_event>();
      AlWaitForEventTimed = Interop.LoadFunction<al_wait_for_event_timed>();
      AlWaitForEventUntil = Interop.LoadFunction<al_wait_for_event_until>();
      AlInitUserEventSource = Interop.LoadFunction<al_init_user_event_source>();
      AlDestroyUserEventSource = Interop.LoadFunction<al_destroy_user_event_source>();
      AlEmitUserEvent = Interop.LoadFunction<al_emit_user_event>();
      AlUnrefUserEvent = Interop.LoadFunction<al_unref_user_event>();
      AlGetEventSourceData = Interop.LoadFunction<al_get_event_source_data>();
      AlSetEventSourceData = Interop.LoadFunction<al_set_event_source_data>();
      
      // Fullscreen routines
      AlGetDisplayMode = Interop.LoadFunction<al_get_display_mode>();
      AlGetNumDisplayModes = Interop.LoadFunction<al_get_num_display_modes>();
      
      // Graphics routines
      AlMapRgb = Interop.LoadFunction<al_map_rgb>();
      AlMapRgbF = Interop.LoadFunction<al_map_rgb_f>();
      AlMapRgba = Interop.LoadFunction<al_map_rgba>();
      AlPremulRgba = Interop.LoadFunction<al_premul_rgba>();
      AlMapRgbaF = Interop.LoadFunction<al_map_rgba_f>();
      AlPremulRgbaF = Interop.LoadFunction<al_premul_rgba_f>();
      AlUnmapRgb = Interop.LoadFunction<al_unmap_rgb>();
      AlUnmapRgbF = Interop.LoadFunction<al_unmap_rgb_f>();
      AlUnmapRgba = Interop.LoadFunction<al_unmap_rgba>();
      AlUnmapRgbaF = Interop.LoadFunction<al_unmap_rgba_f>();
      AlGetPixelSize = Interop.LoadFunction<al_get_pixel_size>();
      AlGetPixelFormatBits = Interop.LoadFunction<al_get_pixel_format_bits>();
      AlGetPixelBlockSize = Interop.LoadFunction<al_get_pixel_block_size>();
      AlGetPixelBlockWidth = Interop.LoadFunction<al_get_pixel_block_width>();
      AlGetPixelBlockHeight = Interop.LoadFunction<al_get_pixel_block_height>();
      AlLockBitmap = Interop.LoadFunction<al_lock_bitmap>();
      AlLockBitmapRegion = Interop.LoadFunction<al_lock_bitmap_region>();
      AlUnlockBitmap = Interop.LoadFunction<al_unlock_bitmap>();
      AlLockBitmapBlocked = Interop.LoadFunction<al_lock_bitmap_blocked>();
      AlLockBitmapRegionBlocked = Interop.LoadFunction<al_lock_bitmap_region_blocked>();
      AlCreateBitmap = Interop.LoadFunction<al_create_bitmap>();
      AlCreateSubBitmap = Interop.LoadFunction<al_create_sub_bitmap>();
      AlCloneBitmap = Interop.LoadFunction<al_clone_bitmap>();
      AlConvertBitmap = Interop.LoadFunction<al_convert_bitmap>();
      AlConvertMemoryBitmaps = Interop.LoadFunction<al_convert_memory_bitmaps>();
      AlDestroyBitmap = Interop.LoadFunction<al_destroy_bitmap>();
      AlGetNewBitmapFlags = Interop.LoadFunction<al_get_new_bitmap_flags>();
      AlGetNewBitmapFormat = Interop.LoadFunction<al_get_new_bitmap_format>();
      AlSetNewBitmapFlags = Interop.LoadFunction<al_set_new_bitmap_flags>();
      AlAddNewBitmapFlag = Interop.LoadFunction<al_add_new_bitmap_flag>();
      AlSetNewBitmapFormat = Interop.LoadFunction<al_set_new_bitmap_format>();
      AlGetBitmapFlags = Interop.LoadFunction<al_get_bitmap_flags>();
      AlGetBitmapFormat = Interop.LoadFunction<al_get_bitmap_format>();
      AlGetBitmapHeight = Interop.LoadFunction<al_get_bitmap_height>();
      AlGetBitmapWidth = Interop.LoadFunction<al_get_bitmap_width>();
      AlGetPixel = Interop.LoadFunction<al_get_pixel>();
      AlIsBitmapLocked = Interop.LoadFunction<al_is_bitmap_locked>();
      AlIsCompatibleBitmap = Interop.LoadFunction<al_is_compatible_bitmap>();
      AlIsSubBitmap = Interop.LoadFunction<al_is_sub_bitmap>();
      AlGetParentBitmap = Interop.LoadFunction<al_get_parent_bitmap>();
      AlGetBitmapX = Interop.LoadFunction<al_get_bitmap_x>();
      AlGetBitmapY = Interop.LoadFunction<al_get_bitmap_y>();
      AlReparentBitmap = Interop.LoadFunction<al_reparent_bitmap>();
      AlClearToColor = Interop.LoadFunction<al_clear_to_color>();
      AlClearDepthBuffer = Interop.LoadFunction<al_clear_depth_buffer>();
      AlDrawBitmap = Interop.LoadFunction<al_draw_bitmap>();
      AlDrawTintedBitmap = Interop.LoadFunction<al_draw_tinted_bitmap>();
      AlDrawBitmapRegion = Interop.LoadFunction<al_draw_bitmap_region>();
      AlDrawTintedBitmapRegion = Interop.LoadFunction<al_draw_tinted_bitmap_region>();
      AlDrawPixel = Interop.LoadFunction<al_draw_pixel>();
      AlDrawRotatedBitmap = Interop.LoadFunction<al_draw_rotated_bitmap>();
      AlDrawTintedRotatedBitmap = Interop.LoadFunction<al_draw_tinted_rotated_bitmap>();
      AlDrawScaledRotatedBitmap = Interop.LoadFunction<al_draw_scaled_rotated_bitmap>();
      AlDrawTintedScaledRotatedBitmap = Interop.LoadFunction<al_draw_tinted_scaled_rotated_bitmap>();
      AlDrawTintedScaledRotatedBitmapRegion = Interop.LoadFunction<al_draw_tinted_scaled_rotated_bitmap_region>();
      AlDrawScaledBitmap = Interop.LoadFunction<al_draw_scaled_bitmap>();
      AlDrawTintedScaledBitmap = Interop.LoadFunction<al_draw_tinted_scaled_bitmap>();
      AlGetTargetBitmap = Interop.LoadFunction<al_get_target_bitmap>();
      AlPutPixel = Interop.LoadFunction<al_put_pixel>();
      AlPutBlendedPixel = Interop.LoadFunction<al_put_blended_pixel>();
      AlSetTargetBitmap = Interop.LoadFunction<al_set_target_bitmap>();
      AlSetTargetBackbuffer = Interop.LoadFunction<al_set_target_backbuffer>();
      AlGetCurrentDisplay = Interop.LoadFunction<al_get_current_display>();
      AlGetBlender = Interop.LoadFunction<al_get_blender>();
      AlGetSeparateBlender = Interop.LoadFunction<al_get_separate_blender>();
      AlGetBlendColor = Interop.LoadFunction<al_get_blend_color>();
      AlSetBlender = Interop.LoadFunction<al_set_blender>();
      AlSetSeparateBlender = Interop.LoadFunction<al_set_separate_blender>();
      AlSetBlendColor = Interop.LoadFunction<al_set_blend_color>();
      AlGetClippingRectangle = Interop.LoadFunction<al_get_clipping_rectangle>();
      AlSetClippingRectangle = Interop.LoadFunction<al_set_clipping_rectangle>();
      AlResetClippingRectangle = Interop.LoadFunction<al_reset_clipping_rectangle>();
      AlConvertMaskToAlpha = Interop.LoadFunction<al_convert_mask_to_alpha>();
      AlHoldBitmapDrawing = Interop.LoadFunction<al_hold_bitmap_drawing>();
      AlIsBitmapDrawingHeld = Interop.LoadFunction<al_is_bitmap_drawing_held>();
      AlRegisterBitmapLoader = Interop.LoadFunction<al_register_bitmap_loader>();
      AlRegisterBitmapSaver = Interop.LoadFunction<al_register_bitmap_saver>();
      AlRegisterBitmapLoaderF = Interop.LoadFunction<al_register_bitmap_loader_f>();
      AlRegisterBitmapSaverF = Interop.LoadFunction<al_register_bitmap_saver_f>();
      AlLoadBitmap = Interop.LoadFunction<al_load_bitmap>();
      AlLoadBitmapFlags = Interop.LoadFunction<al_load_bitmap_flags>();
      AlLoadBitmapF = Interop.LoadFunction<al_load_bitmap_f>();
      AlLoadBitmapFlagsF = Interop.LoadFunction<al_load_bitmap_flags_f>();
      AlSaveBitmap = Interop.LoadFunction<al_save_bitmap>();
      AlSaveBitmapF = Interop.LoadFunction<al_save_bitmap_f>();
      AlRegisterBitmapIdentifier = Interop.LoadFunction<al_register_bitmap_identifier>();
      AlIdentifyBitmap = Interop.LoadFunction<al_identify_bitmap>();
      AlIdentifyBitmapF = Interop.LoadFunction<al_identify_bitmap_f>();
      AlSetRenderState = Interop.LoadFunction<al_set_render_state>();

      // Keyboard routines
      AlInstallKeyboard = Interop.LoadFunction<al_install_keyboard>();
      AlIsKeyboardInstalled = Interop.LoadFunction<al_is_keyboard_installed>();
      AlUninstallKeyboard = Interop.LoadFunction<al_uninstall_keyboard>();
      AlGetKeyboardState = Interop.LoadFunction<al_get_keyboard_state>();
      AlKeyDown = Interop.LoadFunction<al_key_down>();
      AlKeycodeToName = Interop.LoadFunction<al_keycode_to_name>();
      //AlCanSetKeyboardLeds = Interop.LoadFunction<al_can_set_keyboard_leds>(); // Allegro 5.2.9+
      AlSetKeyboardLeds = Interop.LoadFunction<al_set_keyboard_leds>();
      AlGetKeyboardEventSource = Interop.LoadFunction<al_get_keyboard_event_source>();
      
      // System routines
      AlInstallSystem = Interop.LoadFunction<al_install_system>();
      AlUninstallSystem = Interop.LoadFunction<al_uninstall_system>();
      AlIsSystemInstalled = Interop.LoadFunction<al_is_system_installed>();
      AlGetAllegroVersion = Interop.LoadFunction<al_get_allegro_version>();
      AlGetStandardPath = Interop.LoadFunction<al_get_standard_path>();
      AlSetExeName = Interop.LoadFunction<al_set_exe_name>();
      AlSetAppName = Interop.LoadFunction<al_set_app_name>();
      AlSetOrgName = Interop.LoadFunction<al_set_org_name>();
      AlGetAppName = Interop.LoadFunction<al_get_app_name>();
      AlGetOrgName = Interop.LoadFunction<al_get_org_name>();
      AlGetSystemConfig = Interop.LoadFunction<al_get_system_config>();
      AlGetSystemId = Interop.LoadFunction<al_get_system_id>();
      AlRegisterAssertHandler = Interop.LoadFunction<al_register_assert_handler>();
      AlRegisterTraceHandler = Interop.LoadFunction<al_register_trace_handler>();
      AlGetCpuCount = Interop.LoadFunction<al_get_cpu_count>();
      AlGetRamSize = Interop.LoadFunction<al_get_ram_size>();

      // Time routines
      AlGetTime = Interop.LoadFunction<al_get_time>();
      AlInitTimeout = Interop.LoadFunction<al_init_timeout>();
      AlRest = Interop.LoadFunction<al_rest>();
      
      // Timer routines
      AlCreateTimer = Interop.LoadFunction<al_create_timer>();
      AlStartTimer = Interop.LoadFunction<al_start_timer>();
      AlResumeTimer = Interop.LoadFunction<al_resume_timer>();
      AlStopTimer = Interop.LoadFunction<al_stop_timer>();
      AlGetTimerStarted = Interop.LoadFunction<al_get_timer_started>();
      AlDestroyTimer = Interop.LoadFunction<al_destroy_timer>();
      AlGetTimerCount = Interop.LoadFunction<al_get_timer_count>();
      AlSetTimerCount = Interop.LoadFunction<al_set_timer_count>();
      AlAddTimerCount = Interop.LoadFunction<al_add_timer_count>();
      AlGetTimerSpeed = Interop.LoadFunction<al_get_timer_speed>();
      AlSetTimerSpeed = Interop.LoadFunction<al_set_timer_speed>();
      AlGetTimerEventSource = Interop.LoadFunction<al_get_timer_event_source>();
    }
  }
}