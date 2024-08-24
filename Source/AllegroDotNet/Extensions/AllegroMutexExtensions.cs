﻿using SubC.AllegroDotNet.Models;

namespace SubC.AllegroDotNet.Extensions;

/// <summary>
/// This class provides extension methods for the <see cref="AllegroMutex"/> class
/// that can be used as shortcuts or object-oriented methods for Allegro.
/// </summary>
public static class AllegroMutexExtensions
{
    public static void LockMutex(this AllegroMutex? mutex)
       => Al.LockMutex(mutex);

    public static void UnlockMutex(this AllegroMutex? mutex)
      => Al.UnlockMutex(mutex);

    public static void DestroyMutex(this AllegroMutex? mutex)
      => Al.DestroyMutex(mutex);
}
