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
        /// Restores part of the state of the current thread from the given ALLEGRO_STATE object.
        /// </summary>
        /// <param name="state">The state to restore.</param>
        public static void RestoreState(AllegroState state) =>
            AllegroLibrary.AlRestoreState(ref state.Native);

        /// <summary>
        /// Stores part of the state of the current thread in the given ALLEGRO_STATE object.
        /// </summary>
        /// <param name="state">The state to store into.</param>
        /// <param name="flags">The state(s) to store.</param>
        public static void StoreState(AllegroState state, StateFlags flags) =>
            AllegroLibrary.AlStoreState(ref state.Native, (int)flags);

        /// <summary>
        /// Some Allegro functions will set an error number as well as returning an error code. Call this function to
        /// retrieve the last error number set for the calling thread.
        /// </summary>
        /// <returns>The last error number set for the calling thread.</returns>
        public static int GetErrNo() =>
            AllegroLibrary.AlGetErrno();

        /// <summary>
        /// Set the error number for the calling thread.
        /// </summary>
        /// <param name="errNum">The error number.</param>
        public static void SetErrNo(int errNum) =>
            AllegroLibrary.AlSetErrno(errNum);
    }
}
