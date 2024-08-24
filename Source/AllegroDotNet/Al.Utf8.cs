using SubC.AllegroDotNet.Models;
using SubC.AllegroDotNet.Native;
using System.Text;

namespace SubC.AllegroDotNet;

/// <summary>
/// This static class contains the Allegro 5 library methods.
/// </summary>
public static partial class Al
{
    public static AllegroUstr? UstrNew(string s)
    {
        using var nativeS = new CStringAnsi(s);
        var pointer = Interop.Core.AlUstrNew(nativeS.Pointer);
        return NativePointer.Create<AllegroUstr>(pointer);
    }

    public static AllegroUstr? UstrNewFromBuffer(byte[] s, ulong size)
    {
        var pointer = Interop.Core.AlUstrNewFromBuffer(s, new UIntPtr(size));
        return NativePointer.Create<AllegroUstr>(pointer);
    }

    public static void UstrFree(AllegroUstr? ustr)
    {
        Interop.Core.AlUstrFree(NativePointer.Get(ustr));
    }

    public static string? Cstr(AllegroUstr? ustr)
    {
        var pointer = Interop.Core.AlCstr(NativePointer.Get(ustr));
        return CStringAnsi.ToCSharpString(pointer);
    }

    public static void UstrToBuffer(AllegroUstr? ustr, byte[] buffer, int size)
    {
        Interop.Core.AlUstrToBuffer(NativePointer.Get(ustr), buffer, size);
    }

    /// <summary>
    /// Creates a null-terminated copy of the string. Any embedded null bytes will still be present in the returned string.
    /// The returned native string does not need to be freed; AllegroDotNet will free it for you after making a copy
    /// of it as a managed string.
    /// </summary>
    /// <param name="ustr">The UTF string instance.</param>
    /// <returns>Null if an error occurs, otherwise the string of the <see cref="AllegroUstr"/> instance.</returns>
    public static string? CstrDup(AllegroUstr? ustr)
    {
        var pointer = Interop.Core.AlCstrDup(NativePointer.Get(ustr));
        var result = CStringAnsi.ToCSharpString(pointer);

        if (NativePointer.Get(ustr) != IntPtr.Zero)
            Interop.Core.AlFreeWithContext(pointer, 0, IntPtr.Zero, IntPtr.Zero);

        return result;
    }

    public static AllegroUstr? UstrDup(AllegroUstr? ustr)
    {
        var pointer = Interop.Core.AlUstrDup(NativePointer.Get(ustr));
        return NativePointer.Create<AllegroUstr>(pointer);
    }

    public static AllegroUstr? UstrDupSubstr(AllegroUstr? ustr, int start, int end)
    {
        var pointer = Interop.Core.AlUstrDupSubstr(NativePointer.Get(ustr), start, end);
        return NativePointer.Create<AllegroUstr>(pointer);
    }

    public static AllegroUstr? UstrEmptyString()
    {
        var pointer = Interop.Core.AlUstrEmptyString();
        return NativePointer.Create<AllegroUstr>(pointer);
    }

    public static AllegroUstr? RefCstr(ref AllegroUstrInfo ustrInfo, IntPtr cStringPointer)
    {
        var pointer = Interop.Core.AlRefCstr(ref ustrInfo, cStringPointer);
        return NativePointer.Create<AllegroUstr>(pointer);
    }

    public static AllegroUstr? RefBuffer(ref AllegroUstrInfo ustrInfo, IntPtr buffer, ulong size)
    {
        var pointer = Interop.Core.AlRefBuffer(ref ustrInfo, buffer, new UIntPtr(size));
        return NativePointer.Create<AllegroUstr>(pointer);
    }

    public static AllegroUstr? RefUstr(ref AllegroUstrInfo ustrInfo, AllegroUstr? ustr2, int start, int end)
    {
        var pointer = Interop.Core.AlRefUstr(ref ustrInfo, NativePointer.Get(ustr2), start, end);
        return NativePointer.Create<AllegroUstr>(pointer);
    }

    public static ulong UstrSize(AllegroUstr? ustr)
    {
        var result = Interop.Core.AlUstrSize(NativePointer.Get(ustr));
        return result.ToUInt64();
    }

    public static ulong UstrLength(AllegroUstr? ustr)
    {
        var result = Interop.Core.AlUstrLength(NativePointer.Get(ustr));
        return result.ToUInt64();
    }

    public static int UstrOffset(AllegroUstr? ustr, int index)
    {
        return Interop.Core.AlUstrOffset(NativePointer.Get(ustr), index);
    }

    public static bool UstrNext(AllegroUstr? ustr, ref int pos)
    {
        return Interop.Core.AlUstrNext(NativePointer.Get(ustr), ref pos) != 0;
    }

    public static bool UstrPrev(AllegroUstr? ustr, ref int pos)
    {
        return Interop.Core.AlUstrPrev(NativePointer.Get(ustr), ref pos) != 0;
    }

    public static int UstrGet(AllegroUstr? ustr, int pos)
    {
        return Interop.Core.AlUstrGet(NativePointer.Get(ustr), pos);
    }

    public static int UstrGetNext(AllegroUstr? ustr, ref int pos)
    {
        return Interop.Core.AlUstrGetNext(NativePointer.Get(ustr), ref pos);
    }

    public static int UstrPrevGet(AllegroUstr? ustr, ref int pos)
    {
        return Interop.Core.AlUstrPrevGet(NativePointer.Get(ustr), ref pos);
    }

    public static bool UstrInsert(AllegroUstr? ustr1, int pos, AllegroUstr? ustr2)
    {
        return Interop.Core.AlUstrInsert(NativePointer.Get(ustr1), pos, NativePointer.Get(ustr2)) != 0;
    }

    public static bool UstrInsertCstr(AllegroUstr? ustr, int pos, string s)
    {
        using var nativeS = new CStringAnsi(s);
        return Interop.Core.AlUstrInsertCstr(NativePointer.Get(ustr), pos, nativeS.Pointer) != 0;
    }

    public static ulong UstrInsertChr(AllegroUstr? ustr, int pos, int c)
    {
        return Interop.Core.AlUstrInsertChr(NativePointer.Get(ustr), pos, c).ToUInt64();
    }

    public static bool UstrAppend(AllegroUstr? ustr1, AllegroUstr? ustr2)
    {
        return Interop.Core.AlUstrAppend(NativePointer.Get(ustr1), NativePointer.Get(ustr2)) != 0;
    }

    public static bool UstrAppendCstr(AllegroUstr? ustr, string s)
    {
        using var nativeS = new CStringAnsi(s);
        return Interop.Core.AlUstrAppendCstr(NativePointer.Get(ustr), nativeS.Pointer) != 0;
    }

    public static ulong UstrAppendChr(AllegroUstr? ustr, int c)
    {
        return Interop.Core.AlUstrAppendChr(NativePointer.Get(ustr), c).ToUInt64();
    }

    public static bool UstrRemoveChr(AllegroUstr? ustr, int pos)
    {
        return Interop.Core.AlUstrRemoveChr(NativePointer.Get(ustr), pos) != 0;
    }

    public static bool UstrRemoveRange(AllegroUstr? ustr, int start, int end)
    {
        return Interop.Core.AlUstrRemoveRange(NativePointer.Get(ustr), start, end) != 0;
    }

    public static bool UstrTruncate(AllegroUstr? ustr, int start)
    {
        return Interop.Core.AlUstrTruncate(NativePointer.Get(ustr), start) != 0;
    }

    public static bool UstrLtrimWs(AllegroUstr? ustr)
    {
        return Interop.Core.AlUstrLtrimWs(NativePointer.Get(ustr)) != 0;
    }

    public static bool UstrRtrimWs(AllegroUstr? ustr)
    {
        return Interop.Core.AlUstrRtrimWs(NativePointer.Get(ustr)) != 0;
    }

    public static bool UstrTrimWs(AllegroUstr? ustr)
    {
        return Interop.Core.AlUstrTrimWs(NativePointer.Get(ustr)) != 0;
    }

    public static bool UstrAssign(AllegroUstr? ustr1, AllegroUstr? ustr2)
    {
        return Interop.Core.AlUstrAssign(NativePointer.Get(ustr1), NativePointer.Get(ustr2)) != 0;
    }

    public static bool UstrAssignSubstr(AllegroUstr? ustr1, AllegroUstr? ustr2, int start, int end)
    {
        return Interop.Core.AlUstrAssignSubstr(NativePointer.Get(ustr1), NativePointer.Get(ustr2), start, end) != 0;
    }

    public static bool UstrAssignCstr(AllegroUstr? ustr, string s)
    {
        using var nativeS = new CStringAnsi(s);
        return Interop.Core.AlUstrAssignCstr(NativePointer.Get(ustr), nativeS.Pointer) != 0;
    }

    public static ulong UstrSetChr(AllegroUstr? ustr, int start, int c)
    {
        return Interop.Core.AlUstrSetChr(NativePointer.Get(ustr), start, c).ToUInt64();
    }

    public static bool UstrReplaceRange(AllegroUstr? ustr1, int start, int end, AllegroUstr? ustr2)
    {
        return Interop.Core.AlUstrReplaceRange(NativePointer.Get(ustr1), start, end, NativePointer.Get(ustr2)) != 0;
    }

    public static int UstrFindChr(AllegroUstr? ustr, int start, int c)
    {
        return Interop.Core.AlUstrFindChr(NativePointer.Get(ustr), start, c);
    }

    public static int UstrRfindChr(AllegroUstr? ustr, int end, int c)
    {
        return Interop.Core.AlUstrRfindChr(NativePointer.Get(ustr), end, c);
    }

    public static int UstrFindSet(AllegroUstr? ustr, int start, AllegroUstr? accept)
    {
        return Interop.Core.AlUstrFindSet(NativePointer.Get(ustr), start, NativePointer.Get(accept));
    }

    public static int UstrFindSetCstr(AllegroUstr? ustr, int start, string accept)
    {
        using var nativeAccept = new CStringAnsi(accept);
        return Interop.Core.AlUstrFindCstr(NativePointer.Get(ustr), start, nativeAccept.Pointer);
    }

    public static int UstrFindCset(AllegroUstr? ustr, int start, AllegroUstr? reject)
    {
        return Interop.Core.AlUstrFindCset(NativePointer.Get(ustr), start, NativePointer.Get(reject));
    }

    public static int UstrFindCsetCstr(AllegroUstr? ustr, int start, string reject)
    {
        using var nativeReject = new CStringAnsi(reject);
        return Interop.Core.AlUstrFindCsetCstr(NativePointer.Get(ustr), start, nativeReject.Pointer);
    }

    public static int UstrFindStr(AllegroUstr? haystack, int start, AllegroUstr? needle)
    {
        return Interop.Core.AlUstrFindStr(NativePointer.Get(haystack), start, NativePointer.Get(needle));
    }

    public static int UstrFindCstr(AllegroUstr? haystack, int start, string needle)
    {
        using var nativeNeedle = new CStringAnsi(needle);
        return Interop.Core.AlUstrFindCstr(NativePointer.Get(haystack), start, nativeNeedle.Pointer);
    }

    public static int UstrRfindStr(AllegroUstr? haystack, int end, AllegroUstr? needle)
    {
        return Interop.Core.AlUstrRfindStr(NativePointer.Get(haystack), end, NativePointer.Get(needle));
    }

    public static int UstrRfindCstr(AllegroUstr? haystack, int end, string needle)
    {
        using var nativeNeedle = new CStringAnsi(needle);
        return Interop.Core.AlUstrRfindCstr(NativePointer.Get(haystack), end, nativeNeedle.Pointer);
    }

    public static bool UstrFindReplace(AllegroUstr? ustr, int start, AllegroUstr? find, AllegroUstr? replace)
    {
        return Interop.Core.AlUstrFindReplace(NativePointer.Get(ustr), start, NativePointer.Get(find), NativePointer.Get(replace)) != 0;
    }

    public static bool UstrFindReplaceCstr(AllegroUstr? ustr, int start, string find, string replace)
    {
        using var nativeFind = new CStringAnsi(find);
        using var nativeReplace = new CStringAnsi(replace);
        return Interop.Core.AlUstrFindReplaceCstr(NativePointer.Get(ustr), start, nativeFind.Pointer, nativeReplace.Pointer) != 0;
    }

    public static bool UstrEqual(AllegroUstr? ustr1, AllegroUstr? ustr2)
    {
        return Interop.Core.AlUstrEqual(NativePointer.Get(ustr1), NativePointer.Get(ustr2)) != 0;
    }

    public static int UstrCompare(AllegroUstr? ustr1, AllegroUstr? ustr2)
    {
        return Interop.Core.AlUstrCompare(NativePointer.Get(ustr1), NativePointer.Get(ustr2));
    }

    public static int UstrNcompare(AllegroUstr? ustr1, AllegroUstr? ustr2, int n)
    {
        return Interop.Core.AlUstrNcompare(NativePointer.Get(ustr1), NativePointer.Get(ustr2), n);
    }

    public static bool UstrHasPrefix(AllegroUstr? ustr1, AllegroUstr? ustr2)
    {
        return Interop.Core.AlUstrHasPrefix(NativePointer.Get(ustr1), NativePointer.Get(ustr2)) != 0;
    }

    public static bool UstrHasPrefixCstr(AllegroUstr? ustr, string s)
    {
        using var nativeS = new CStringAnsi(s);
        return Interop.Core.AlUstrHasPrefixCstr(NativePointer.Get(ustr), nativeS.Pointer) != 0;
    }

    public static bool UstrHasSuffix(AllegroUstr? ustr1, AllegroUstr? ustr2)
    {
        return Interop.Core.AlUstrHasSuffix(NativePointer.Get(ustr1), NativePointer.Get(ustr2)) != 0;
    }

    public static bool UstrHasSuffixCstr(AllegroUstr? ustr, string s)
    {
        using var nativeS = new CStringAnsi(s);
        return Interop.Core.AlUstrHasSuffixCstr(NativePointer.Get(ustr), nativeS.Pointer) != 0;
    }

    public static AllegroUstr? UstrNewFromUtf16(string s)
    {
        var sBytes = Encoding.Unicode.GetBytes(s);
        var sChars = Encoding.Unicode.GetChars(sBytes);
        var pointer = Interop.Core.AlUstrNewFromUtf16(sChars);
        return NativePointer.Create<AllegroUstr>(pointer);
    }

    public static ulong UstrSizeUtf16(AllegroUstr? ustr)
    {
        return Interop.Core.AlUstrSizeUtf16(NativePointer.Get(ustr)).ToUInt64();
    }

    public static ulong UstrEncodeUtf16(AllegroUstr? ustr, char[] s, ulong n)
    {
        return Interop.Core.AlUstrEncodeUtf16(NativePointer.Get(ustr), s, new UIntPtr(n)).ToUInt64();
    }

    public static ulong Utf8Width(int c)
    {
        return Interop.Core.AlUtf8Width(c).ToUInt64();
    }

    public static ulong Utf8Encode(byte[] s, int c)
    {
        return Interop.Core.AlUtf8Encode(s, c).ToUInt64();
    }

    public static ulong Utf16Width(int c)
    {
        return Interop.Core.AlUtf16Width(c).ToUInt64();
    }

    public static ulong Utf16Encode(char[] s, int c)
    {
        return Interop.Core.AlUtf16Encode(s, c).ToUInt64();
    }
}
