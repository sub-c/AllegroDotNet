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
        /// <summary>
        /// Initialise the native dialog addon.
        /// </summary>
        /// <returns>Returns true on success, false on error.</returns>
        public static bool InitNativeDialogAddon() =>
            AllegroLibrary.AlInitNativeDialogAddon();

        /// <summary>
        /// Returns true if the native dialog addon is initialized, otherwise returns false.
        /// </summary>
        /// <returns>True if the native dialog addon is initialized, otherwise returns false.</returns>
        public static bool IsNativeDialogAddonInitialized() =>
            AllegroLibrary.AlIsNativeDialogAddonInitialized();

        /// <summary>
        /// Shut down the native dialog addon.
        /// </summary>
        public static void ShutdownNativeDialogAddon() =>
            AllegroLibrary.AlShutdownNativeDialogAddon();

        /// <summary>
        /// Creates a new native file dialog. You should only have one such dialog opened at a time.
        /// </summary>
        /// <param name="initialPath">
        /// The initial search path and filename. Can be <c>null</c>. To start with a blank
        /// file name the string should end with a directory separator (this should be the common case).
        /// </param>
        /// <param name="title">Title of the dialog.</param>
        /// <param name="patterns">
        /// A list of semi-colon separated patterns to match. This should not contain any whitespace characters.
        /// If a pattern contains the ‘/’ character, then it is treated as a MIME type (e.g. ‘image/png’). Not all
        /// platforms support file patterns. If the native dialog does not provide support, this parameter is ignored.
        /// </param>
        /// <param name="mode">The mode.</param>
        /// <returns>
        /// A handle to the dialog which you can pass to
        /// <see cref="ShowNativeFileDialog(AllegroDisplay, AllegroFileChooser)"/> to display it, and from which you
        /// then can query the results using <see cref="GetNativeFileDialogCount(AllegroFileChooser)"/> and 
        /// <see cref="GetNativeFileDialogPath(AllegroFileChooser, ulong)"/>. When you are done, call
        /// <see cref="DestroyNativeFileDialog(AllegroFileChooser)"/> on it. If a dialog window could not be created
        /// then this function returns <c>null</c>.
        /// </returns>
        public static AllegroFileChooser CreateNativeFileDialog(
            string initialPath,
            string title,
            string patterns,
            FileChooserMode mode)
        {
            var nativeFileDialog = AllegroLibrary.AlCreateNativeFileDialog(initialPath, title, patterns, (int)mode);
            return nativeFileDialog == IntPtr.Zero ? null : new AllegroFileChooser { NativeIntPtr = nativeFileDialog };
        }

        /// <summary>
        /// Show the dialog window. The display may be NULL, otherwise the given display is treated as the parent
        /// if possible. This function blocks the calling thread until it returns, so you may want to spawn a thread
        /// with <see cref="CreateThread(AlConstants.ThreadProcessDelegate, IntPtr)"/> and call it from inside that
        /// thread.
        /// </summary>
        /// <param name="display">The parent display or null.</param>
        /// <param name="dialog">The dialog instance.</param>
        /// <returns>Returns true on success, false on failure.</returns>
        public static bool ShowNativeFileDialog(AllegroDisplay display, AllegroFileChooser dialog)
        {
            var nativeDisplay = display == null ? IntPtr.Zero : display.NativeIntPtr;
            return AllegroLibrary.AlShowNativeFileDialog(nativeDisplay, dialog.NativeIntPtr);
        }

        /// <summary>
        /// Returns the number of files selected, or 0 if the dialog was cancelled.
        /// </summary>
        /// <param name="dialog">The dialog instance.</param>
        /// <returns>The number of files selected, or 0 if the dialog was cancelled.</returns>
        public static int GetNativeFileDialogCount(AllegroFileChooser dialog) =>
            AllegroLibrary.AlGetNativeFileDialogCount(dialog.NativeIntPtr);

        /// <summary>
        /// Returns one of the selected paths with index i. The index should range from 0 to the return value of
        /// <see cref="GetNativeFileDialogCount(AllegroFileChooser)"/> - 1.
        /// </summary>
        /// <param name="dialog">The dialog instance.</param>
        /// <param name="i">The index.</param>
        /// <returns>Returns one of the selected paths with index i.</returns>
        public static string GetNativeFileDialogPath(AllegroFileChooser dialog, ulong i)
        {
            var nativePath = AllegroLibrary.AlGetNativeFileDialogPath(dialog.NativeIntPtr, new UIntPtr(i));
            return nativePath == IntPtr.Zero ? null : Marshal.PtrToStringAnsi(nativePath);
        }

        /// <summary>
        /// Frees up all resources used by the file dialog.
        /// </summary>
        /// <param name="dialog">The dialog instance.</param>
        public static void DestroyNativeFileDialog(AllegroFileChooser dialog) =>
            AllegroLibrary.AlDestroyNativeFileDialog(dialog.NativeIntPtr);

        /// <summary>
        /// Show a native GUI message box. This can be used for example to display an error message if creation of an
        /// initial display fails. The display may be <c>null</c>, otherwise the given display is treated as the parent
        /// if possible.
        /// <para>
        /// The message box will have a single “OK” button and use the style informative dialog boxes usually have on
        /// the native system. If the buttons parameter is not NULL, you can instead specify the button text in a
        /// string, with buttons separated by a vertical bar (|).
        /// </para>
        /// <para>Note: buttons parameter is currently unimplemented on Windows.</para>
        /// <para>
        /// <see cref="ShowNativeMessageBox(AllegroDisplay, string, string, string, string, MessageBoxFlags)"/> may be
        /// called without Allegro being installed. This is useful to report an error during initialisation of Allegro
        /// itself.
        /// </para>
        /// </summary>
        /// <param name="display">The display instance or <c>null</c>.</param>
        /// <param name="title">The title.</param>
        /// <param name="heading">The dialog text heading.</param>
        /// <param name="text">The dialog text.</param>
        /// <param name="buttons">Button text separated by | (unimplemented on Windows).</param>
        /// <param name="flags">Dialog flags.</param>
        /// <returns>
        /// 0 if the dialog window was closed without activating a button, 1 if the OK or Yes button was pressed,
        /// 2 if the Cancel or No button was pressed.
        /// </returns>
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

        /// <summary>
        /// Opens a window to which you can append log messages with
        /// <see cref="AppendNativeTextLog(AllegroTextLog, string)"/>. This can be useful for debugging if you don’t
        /// want to depend on a console being available.
        /// </summary>
        /// <param name="title"></param>
        /// <param name="flags"></param>
        /// <returns>
        /// Returns <c>null</c> if there was an error opening the window, or if text log windows are not implemented
        /// on the platform. Otherwise, the text log instance.
        /// </returns>
        public static AllegroTextLog OpenNativeTextLog(string title, TextLogFlags flags)
        {
            var nativeTextLog = AllegroLibrary.AlOpenNativeTextLog(title, (int)flags);
            return nativeTextLog == IntPtr.Zero ? null : new AllegroTextLog { NativeIntPtr = nativeTextLog };
        }

        /// <summary>
        /// Closes a message log window opened with <see cref="OpenNativeTextLog(string, TextLogFlags)"/> earlier.
        /// </summary>
        /// <param name="textLog">The text log instance.</param>
        public static void CloseNativeTextLog(AllegroTextLog textLog) =>
            AllegroLibrary.AlCloseNativeTextLog(textLog.NativeIntPtr);

        /// <summary>
        /// Appends a line of text to the message log window and scrolls to the bottom (if the line would not be
        /// visible otherwise). A line is continued until you add a newline character.
        /// </summary>
        /// <param name="textLog">The text log instance.</param>
        /// <param name="message">The text message.</param>
        public static void AppendNativeTextLog(AllegroTextLog textLog, string message) =>
            AllegroLibrary.AlAppendNativeTextLog(textLog.NativeIntPtr, message);

        /// <summary>
        /// Get an event source for a text log window.
        /// </summary>
        /// <param name="textLog">The text log instance.</param>
        /// <returns>The event source instance, or null on error.</returns>
        public static AllegroEventSource GetNativeTextLogEventSource(AllegroTextLog textLog)
        {
            var nativeEventSource = AllegroLibrary.AlGetNativeTextLogEventSource(textLog.NativeIntPtr);
            return nativeEventSource == IntPtr.Zero ? null : new AllegroEventSource { NativeIntPtr = nativeEventSource };
        }

        /// <summary>
        /// Returns the (compiled) version of the addon, in the same format as <see cref="GetAllegroVersion"/>.
        /// </summary>
        /// <returns>The (compiled) version of the addon.</returns>
        public static uint GetAllegroNativeDialogVersion() =>
            AllegroLibrary.AlGetAllegroNativeDialogVersion();

        /// <summary>
        /// Creates a menu container that can hold menu items.
        /// </summary>
        /// <returns>Returns <c>null</c> on failure.</returns>
        public static AllegroMenu CreateMenu()
        {
            var nativeMenu = AllegroLibrary.AlCreateMenu();
            return nativeMenu == IntPtr.Zero ? null : new AllegroMenu { NativeIntPtr = nativeMenu };
        }

        /// <summary>
        /// Creates a menu container for popup menus. Only the root (outermost) menu should be created with this
        /// function. Sub menus of popups should be created with <see cref="CreateMenu"/>.
        /// </summary>
        /// <returns>Returns <c>null</c> on failure.</returns>
        public static AllegroMenu CreatePopupMenu()
        {
            var nativeMenu = AllegroLibrary.AlCreatePopupMenu();
            return nativeMenu == IntPtr.Zero ? null : new AllegroMenu { NativeIntPtr = nativeMenu };
        }

        /// <summary>
        /// Builds a menu based on the specifications of a sequence of <see cref="AllegroMenuInfo"/> elements.
        /// </summary>
        /// <param name="info">Menu info instance.</param>
        /// <returns>
        /// Returns a pointer to the root <see cref="AllegroMenu"/>, or <c>null</c> on failure. To gain
        /// access to the other menus and items, you will need to search for them using
        /// <see cref="FindMenuItem(AllegroMenu, ushort, AllegroMenu, ref int)"/>.
        /// </returns>
        public static AllegroMenu BuildMenu(AllegroMenuInfo info)
        {
            var nativeMenu = AllegroLibrary.AlBuildMenu(info.NativeIntPtr);
            return nativeMenu == IntPtr.Zero ? null : new AllegroMenu { NativeIntPtr = nativeMenu };
        }

        /// <summary>
        /// Appends a menu item to the end of the menu. See
        /// <see cref="InsertMenuItem(AllegroMenu, int, string, ushort, MenuFlags, AllegroBitmap, AllegroMenu)"/>
        /// for more information.
        /// </summary>
        /// <param name="parent">Parent menu instance.</param>
        /// <param name="title">The menu title.</param>
        /// <param name="id">The menu ID.</param>
        /// <param name="flags">The menu flags.</param>
        /// <param name="icon">The menu item icon.</param>
        /// <param name="submenu">The submenu instance, if any.</param>
        /// <returns>True/non-zero on success, otherwise false/zero (?).</returns>
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

        /// <summary>
        /// Inserts a menu item at the spot specified. See the introductory text for a detailed explanation of how the
        /// pos parameter is interpreted. The parent menu can be a popup menu or a regular menu. To underline one
        /// character in the title, prefix it with an ampersand.
        /// </summary>
        /// <param name="parent">The parent menu instance.</param>
        /// <param name="pos">The position (positive = ID, 0 or less is absolute position).</param>
        /// <param name="title">The title of the menu item.</param>
        /// <param name="id">The ID of the menu item.</param>
        /// <param name="flags">The menu flags.</param>
        /// <param name="icon">The submenu icon, if any.</param>
        /// <param name="submenu">The submenu instance, if any.</param>
        /// <returns>True/non-zero on success, otherwise false/zero (?).</returns>
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

        /// <summary>
        /// Removes the specified item from the menu and destroys it. If the item contains a sub-menu, it too is
        /// destroyed. Any references to it are invalidated. If you want to preserve that sub-menu, you should
        /// first make a copy with <see cref="CloneMenu(AllegroMenu)"/>. This is safe to call on a menu that is
        /// currently being displayed.
        /// </summary>
        /// <param name="menu">The menu instance.</param>
        /// <param name="pos">The position (positive = ID, 0 or less is absolute position).</param>
        /// <returns>Returns true if an item was removed.</returns>
        public static bool RemoveMenuItem(AllegroMenu menu, int pos) =>
            AllegroLibrary.AlRemoveMenuItem(menu.NativeIntPtr, pos);

        /// <summary>
        /// Makes a copy of a menu so that it can be reused on another display. The menu being cloned can be anything:
        /// a regular menu, a popup menu, or a sub-menu.
        /// </summary>
        /// <param name="menu">The menu instance.</param>
        /// <returns>Returns the cloned menu on success.</returns>
        public static AllegroMenu CloneMenu(AllegroMenu menu)
        {
            var nativeCloneMenu = AllegroLibrary.AlCloneMenu(menu.NativeIntPtr);
            return nativeCloneMenu == IntPtr.Zero ? null : new AllegroMenu { NativeIntPtr = nativeCloneMenu };
        }

        /// <summary>
        /// Exactly like <see cref="CloneMenu(AllegroMenu)"/>, except that the copy is for a popup menu.
        /// </summary>
        /// <param name="menu">The menu instance.</param>
        /// <returns>Returns the cloned popup menu on success.</returns>
        public static AllegroMenu CloneMenuForPopup(AllegroMenu menu)
        {
            var nativeCloneMenu = AllegroLibrary.AlCloneMenuForPopup(menu.NativeIntPtr);
            return nativeCloneMenu == IntPtr.Zero ? null : new AllegroMenu { NativeIntPtr = nativeCloneMenu };
        }

        /// <summary>
        /// Destroys an entire menu, including its sub-menus. Any references to it or a sub-menu are no longer valid.
        /// It is safe to call this on a menu that is currently being displayed.
        /// </summary>
        /// <param name="menu">The menu instance.</param>
        public static void DestroyMenu(AllegroMenu menu) =>
            AllegroLibrary.AlDestroyMenu(menu.NativeIntPtr);

        /// <summary>
        /// Returns the caption associated with the menu item. It is valid as long as the caption is not modified.
        /// </summary>
        /// <param name="menu">The menu instance.</param>
        /// <param name="pos">The position (positive = ID, 0 or less is absolute position).</param>
        /// <returns>The menu item caption string, or <c>null</c> if not found.</returns>
        public static string GetMenuItemCaption(AllegroMenu menu, int pos)
        {
            var nativeString = AllegroLibrary.AlGetMenuItemCaption(menu.NativeIntPtr, pos);
            return nativeString == IntPtr.Zero ? null : Marshal.PtrToStringAnsi(nativeString);
        }

        /// <summary>
        /// Updates the menu item caption with the new caption. This will invalidate any previous calls to
        /// <see cref="GetMenuItemCaption(AllegroMenu, int)"/>.
        /// </summary>
        /// <param name="menu">The menu instance.</param>
        /// <param name="pos">The position (positive = ID, 0 or less is absolute position).</param>
        /// <param name="caption">The caption string.</param>
        public static void SetMenuItemCaption(AllegroMenu menu, int pos, string caption) =>
            AllegroLibrary.AlSetMenuItemCaption(menu.NativeIntPtr, pos, caption);

        /// <summary>
        /// Returns the currently set flags. See
        /// <see cref="InsertMenuItem(AllegroMenu, int, string, ushort, MenuFlags, AllegroBitmap, AllegroMenu)"/> for a
        /// description of the available flags. Returns -1 if the item was not found.
        /// </summary>
        /// <param name="menu">The menu instance.</param>
        /// <param name="pos">The position (positive = ID, 0 or less is absolute position).</param>
        /// <returns>The current menu flags, or -1 if item was not found.</returns>
        public static MenuFlags GetMenuItemFlags(AllegroMenu menu, int pos) =>
            (MenuFlags)AllegroLibrary.AlGetMenuItemFlags(menu.NativeIntPtr, pos);

        /// <summary>
        /// Updates the menu item’s flags. See
        /// <see cref="InsertMenuItem(AllegroMenu, int, string, ushort, MenuFlags, AllegroBitmap, AllegroMenu)"/> for a
        /// description of the available flags.
        /// </summary>
        /// <param name="menu">The menu instance.</param>
        /// <param name="pos">The position (positive = ID, 0 or less is absolute position).</param>
        /// <param name="flags">The menu flags to set.</param>
        public static void SetMenuItemFlags(AllegroMenu menu, int pos, MenuFlags flags) =>
            AllegroLibrary.AlSetMenuItemFlags(menu.NativeIntPtr, pos, (int)flags);

        /// <summary>
        /// Returns the icon associated with the menu. It is safe to draw to the returned bitmap, but you must call
        /// <see cref="SetMenuItemIcon(AllegroMenu, int, AllegroBitmap)"/> in order for the changes to be applied.
        /// </summary>
        /// <param name="menu">The menu instance.</param>
        /// <param name="pos">The position (positive = ID, 0 or less is absolute position).</param>
        /// <returns>The icon associated with the menu, or null if the item was not found/has no icon.</returns>
        public static AllegroBitmap GetMenuItemIcon(AllegroMenu menu, int pos)
        {
            var nativeBitmap = AllegroLibrary.AlGetMenuItemIcon(menu.NativeIntPtr, pos);
            return nativeBitmap == IntPtr.Zero ? null : new AllegroBitmap { NativeIntPtr = nativeBitmap };
        }

        /// <summary>
        /// Sets the icon for the specified menu item. The menu assumes ownership of the
        /// <see cref="AllegroBitmap"/> and may invalidate the pointer, so you must clone it if you wish to continue
        /// using it.
        /// <para>
        /// If a video bitmap is passed, it will automatically be converted to a memory bitmap, so it is preferable to
        /// pass a memory bitmap.
        /// </para>
        /// </summary>
        /// <param name="menu">The menu instance.</param>
        /// <param name="pos">The position (positive = ID, 0 or less is absolute position).</param>
        /// <param name="icon">The icon bitmap instance.</param>
        public static void SetMenuItemIcon(AllegroMenu menu, int pos, AllegroBitmap icon) =>
            AllegroLibrary.AlSetMenuItemIcon(menu.NativeIntPtr, pos, icon.NativeIntPtr);

        /// <summary>
        /// Searches in the haystack menu for any submenu with the given id. (Note that this only represents a literal
        /// ID, and cannot be used as an index.)
        /// </summary>
        /// <param name="haystack">The menu instance haystack to search in.</param>
        /// <param name="id">The submenu ID.</param>
        /// <returns>Returns the menu, if found. Otherwise returns NULL.</returns>
        public static AllegroMenu FindMenu(AllegroMenu haystack, ushort id)
        {
            var nativeMenu = AllegroLibrary.AlFindMenu(haystack.NativeIntPtr, id);
            return nativeMenu == IntPtr.Zero ? null : new AllegroMenu { NativeIntPtr = nativeMenu };
        }

        /// <summary>
        /// Searches in the haystack menu for an item with the given id. (Note that this only represents a literal ID,
        /// and cannot be used as an index.)
        /// <para>
        /// If menu and index are not <c>null</c>, they will be set as the parent menu containing the item and the
        /// zero-based (positive) index of the item. (If the menu item was not found, then their values are undefined.)
        /// </para>
        /// </summary>
        /// <param name="haystack">The menu instance haystack to search in.</param>
        /// <param name="id">The submenu ID.</param>
        /// <param name="menu">If non-null, will be the parent menu containing the item.</param>
        /// <param name="index">If menu is non-null, the index of the item.</param>
        /// <returns>Returns true if the menu item was found.</returns>
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

        /// <summary>
        /// Returns the default event source used for menu clicks. If a menu was not given its own event source via
        /// <see cref="EnableMenuEventSource(AllegroMenu)"/>, then it will use this default source.
        /// </summary>
        /// <returns>The default event source used for menu clicks.</returns>
        public static AllegroEventSource GetDefaultMenuEventSource()
        {
            var nativeEventSource = AllegroLibrary.AlGetDefaultMenuEventSource();
            return nativeEventSource == IntPtr.Zero ? null : new AllegroEventSource { NativeIntPtr = nativeEventSource };
        }

        /// <summary>
        /// Enables a unique event source for this menu. It and all of its sub-menus will use this event source.
        /// (It is safe to call this multiple times on the same menu.)
        /// </summary>
        /// <param name="menu">The menu instance.</param>
        /// <returns>Returns the event source.</returns>
        public static AllegroEventSource EnableMenuEventSource(AllegroMenu menu)
        {
            var nativeEventSource = AllegroLibrary.AlEnableMenuEventSource(menu.NativeIntPtr);
            return nativeEventSource == IntPtr.Zero ? null : new AllegroEventSource { NativeIntPtr = nativeEventSource };
        }

        /// <summary>
        /// Disables a unique event source for the menu, causing it to use the default event source.
        /// </summary>
        /// <param name="menu">The menu instance.</param>
        public static void DisableMenuEventSource(AllegroMenu menu) =>
            AllegroLibrary.AlDisableMenuEventSource(menu.NativeIntPtr);

        /// <summary>
        /// Returns the menu associated with the display, or NULL if it does not have a menu.
        /// </summary>
        /// <param name="display">The display instance.</param>
        /// <returns>Returns the menu associated with the display, or NULL if it does not have a menu.</returns>
        public static AllegroMenu GetDisplayMenu(AllegroDisplay display)
        {
            var nativeMenu = AllegroLibrary.AlGetDisplayMenu(display.NativeIntPtr);
            return nativeMenu == IntPtr.Zero ? null : new AllegroMenu { NativeIntPtr = nativeMenu };
        }

        /// <summary>
        /// Associates the menu with the display and shows it. If there was a previous menu associated with the
        /// display, it will be destroyed. If you don’t want that to happen, you should first remove the menu
        /// with <see cref="RemoveDisplayMenu(AllegroDisplay)"/>.
        /// <para>
        /// If the menu is already attached to a display, it will not be attached to the new display. If menu is
        /// <c>null</c>, the current menu will still be destroyed.
        /// </para>
        /// <para>
        /// Note: Attaching a menu may cause the window as available to your application to be resized! You should
        /// listen for a resize event, check how much space was lost, and resize the window accordingly if you want
        /// to maintain your window’s prior size.
        /// </para>
        /// </summary>
        /// <param name="display">The display instance.</param>
        /// <param name="menu">The menu instance.</param>
        /// <returns>Returns true if successful.</returns>
        public static bool SetDisplayMenu(AllegroDisplay display, AllegroMenu menu) =>
            AllegroLibrary.AlSetDisplayMenu(display.NativeIntPtr, menu.NativeIntPtr);

        /// <summary>
        /// Displays a context menu next to the mouse cursor. The menu must have been created with
        /// <see cref="CreatePopupMenu"/>. It generates events just like a regular display menu does. It is possible
        /// that the menu will be canceled without any selection being made.
        /// <para>
        /// The display parameter indicates which window the menu is associated with (when you process the menu click
        /// event), but does not actually affect where the menu is located on the screen.
        /// </para>
        /// <para>
        /// Note: On Linux this function will fail if any of the mouse keys are held down. I.e. it will only reliably
        /// work if you handle it in <see cref="EventType.MouseButtonUp"/> events and even then only if that event
        /// corresponds to the final mouse button that was pressed.
        /// </para>
        /// </summary>
        /// <param name="popup">The popup menu instance.</param>
        /// <param name="display">The display instance.</param>
        /// <returns>Returns true if the context menu was displayed.</returns>
        public static bool PopupMenu(AllegroMenu popup, AllegroDisplay display) =>
            AllegroLibrary.AlPopupMenu(popup.NativeIntPtr, display.NativeIntPtr);

        /// <summary>
        /// Detaches the menu associated with the display and returns it. The menu can then be used on a different
        /// display.
        /// <para>
        /// If you simply want to destroy the active menu, you can call
        /// <see cref="SetDisplayMenu(AllegroDisplay, AllegroMenu)"/> with a <c>null</c> menu.
        /// </para>
        /// </summary>
        /// <param name="display">The display instance.</param>
        /// <returns>The detached menu.</returns>
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
