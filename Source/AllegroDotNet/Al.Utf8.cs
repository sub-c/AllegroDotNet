using SubC.AllegroDotNet.Models;
using SubC.AllegroDotNet.Native;
using System;
using System.Runtime.InteropServices;

namespace SubC.AllegroDotNet;

public static partial class Al
{
  public static AllegroUstr? UstrNew(string cstr)
  {
    var nativeString = Marshal.StringToHGlobalAnsi(cstr);
    var result = NativeFunctions.AlUstrNew(nativeString);
    Marshal.FreeHGlobal(nativeString);
    return NativePointerModel.Create<AllegroUstr>(result);
  }

  public static AllegroUstr? UStrNewFromBuffer(IntPtr buffer, long size)
  {
    var result = NativeFunctions.AlUstrNewFromBuffer(buffer, size);
    return NativePointerModel.Create<AllegroUstr>(result);
  }

  public static void UstrFree(AllegroUstr? ustr)
  {
    NativeFunctions.AlUstrFree(NativePointerModel.GetPointer(ustr));
  }

  public static string Cstr(AllegroUstr? ustr)
  {
    var result = NativeFunctions.AlCstr(NativePointerModel.GetPointer(ustr));
    return Marshal.PtrToStringAnsi(result) ?? string.Empty;
  }

  public static void UstrToBuffer(AllegroUstr? ustr, IntPtr buffer, int size)
  {
    NativeFunctions.AlUstrToBuffer(NativePointerModel.GetPointer(ustr), buffer, size);
  }

  public static string CstrDup(AllegroUstr? ustr)
  {
    var result = NativeFunctions.AlCstrDup(NativePointerModel.GetPointer(ustr));
    return Marshal.PtrToStringAnsi(result) ?? string.Empty;
  }

  public static AllegroUstr? UstrDup(AllegroUstr? ustr)
  {
    var result = NativeFunctions.AlUstrDup(NativePointerModel.GetPointer(ustr));
    return NativePointerModel.Create<AllegroUstr>(result);
  }

  public static AllegroUstr? UstrDupSubstr(AllegroUstr? ustr, int startPosition, int endPosition)
  {
    var result = NativeFunctions.AlUstrDupSubstr(NativePointerModel.GetPointer(ustr), startPosition, endPosition);
    return NativePointerModel.Create<AllegroUstr>(result);
  }

  public static AllegroUstr? UstrEmptyString()
  {
    var result = NativeFunctions.AlUstrEmptyString();
    return NativePointerModel.Create<AllegroUstr>(result);
  }

  public static AllegroUstr? RefCstr(AllegroUstrInfo info, string str)
  {
    var nativeStr = Marshal.StringToHGlobalAnsi(str);
    var result = NativeFunctions.AlRefCstr(ref info.NativeUstrInfo, nativeStr);
    Marshal.FreeHGlobal(nativeStr);
    return NativePointerModel.Create<AllegroUstr>(result);
  }

  public static AllegroUstr? RefBuffer(AllegroUstrInfo info, string str, long size)
  {
    var nativeStr = Marshal.StringToHGlobalAnsi(str);
    var result = NativeFunctions.AlRefBuffer(ref info.NativeUstrInfo, nativeStr, size);
    Marshal.FreeHGlobal(nativeStr);
    return NativePointerModel.Create<AllegroUstr>(result);
  }

  public static AllegroUstr? RefUstr(AllegroUstrInfo info, AllegroUstr? ustr, int startPosition, int endPosition)
  {
    var result = NativeFunctions.AlRefUstr(ref info.NativeUstrInfo, NativePointerModel.GetPointer(ustr), startPosition, endPosition);
    return NativePointerModel.Create<AllegroUstr>(result);
  }

  public static long UstrSize(AllegroUstr? ustr)
  {
    return NativeFunctions.AlUstrSize(NativePointerModel.GetPointer(ustr));
  }

  public static long UstrLength(AllegroUstr? ustr)
  {
    return NativeFunctions.AlUstrLength(NativePointerModel.GetPointer(ustr));
  }

  public static int UstrOffset(AllegroUstr? ustr, int index)
  {
    return NativeFunctions.AlUstrOffset(NativePointerModel.GetPointer(ustr), index);
  }

  public static bool UstrNext(AllegroUstr? ustr, ref int pos)
  {
    return NativeFunctions.AlUstrNext(NativePointerModel.GetPointer(ustr), ref pos);
  }

  public static bool UstrPrev(AllegroUstr? ustr, ref int pos)
  {
    return NativeFunctions.AlUstrPrev(NativePointerModel.GetPointer(ustr), ref pos);
  }

  public static int UstrGet(AllegroUstr? ustr, int pos)
  {
    return NativeFunctions.AlUstrGet(NativePointerModel.GetPointer(ustr), pos);
  }

  public static int UstrGetNext(AllegroUstr? ustr, ref int pos)
  {
    return NativeFunctions.AlUstrGetNext(NativePointerModel.GetPointer(ustr), ref pos);
  }

  public static int UstrPrevGet(AllegroUstr? ustr, ref int pos)
  {
    return NativeFunctions.AlUstrPrevGet(NativePointerModel.GetPointer(ustr), ref pos);
  }

  public static bool UstrInsert(AllegroUstr? ustr1, int pos, AllegroUstr? ustr2)
  {
    return NativeFunctions.AlUstrInsert(NativePointerModel.GetPointer(ustr1), pos, NativePointerModel.GetPointer(ustr2));
  }

  public static bool UstrInsertCstr(AllegroUstr? ustr, int pos, string str)
  {
    var nativeStr = Marshal.StringToHGlobalAnsi(str);
    var result = NativeFunctions.AlUstrInsertCstr(NativePointerModel.GetPointer(ustr), pos, nativeStr);
    Marshal.FreeHGlobal(nativeStr);
    return result;
  }

  public static long UstrInsertChr(AllegroUstr? ustr, int pos, int c)
  {
    return NativeFunctions.AlUstrInsertChr(NativePointerModel.GetPointer(ustr), pos, c);
  }

  public static bool UstrAppend(AllegroUstr? ustr1, AllegroUstr? ustr2)
  {
    return NativeFunctions.AlUstrAppend(NativePointerModel.GetPointer(ustr1), NativePointerModel.GetPointer(ustr2));
  }

  public static bool UstrAppendCstr(AllegroUstr? ustr, string str)
  {
    var nativeStr = Marshal.StringToHGlobalAnsi(str);
    var result = NativeFunctions.AlUstrAppendCstr(NativePointerModel.GetPointer(ustr), nativeStr);
    Marshal.FreeHGlobal(nativeStr);
    return result;
  }

  public static long UstrAppendChr(AllegroUstr? ustr, int c)
  {
    return NativeFunctions.AlUstrAppendChr(NativePointerModel.GetPointer(ustr), c);
  }

  public static bool UstrRemoveChr(AllegroUstr? ustr, int pos)
  {
    return NativeFunctions.AlUstrRemoveChr(NativePointerModel.GetPointer(ustr), pos);
  }

  public static bool UstrRemoveRange(AllegroUstr? ustr, int startPosition, int endPosition)
  {
    return NativeFunctions.AlUstrRemoveRange(NativePointerModel.GetPointer(ustr), startPosition, endPosition);
  }

  public static bool UstrTruncate(AllegroUstr? ustr, int startPosition)
  {
    return NativeFunctions.AlUstrTruncate(NativePointerModel.GetPointer(ustr), startPosition);
  }

  public static bool UstrLtrimWs(AllegroUstr? ustr)
  {
    return NativeFunctions.AlUstrLtrimWs(NativePointerModel.GetPointer(ustr));
  }

  public static bool UstrRtrimWs(AllegroUstr? ustr)
  {
    return NativeFunctions.AlUstrRtrimWs(NativePointerModel.GetPointer(ustr));
  }

  public static bool UstrTrimWs(AllegroUstr? ustr)
  {
    return NativeFunctions.AlUstrTrimWs(NativePointerModel.GetPointer(ustr));
  }

  public static bool UstrAssign(AllegroUstr? ustr1, AllegroUstr? ustr2)
  {
    return NativeFunctions.AlUstrAssign(NativePointerModel.GetPointer(ustr1), NativePointerModel.GetPointer(ustr2));
  }

  public static bool UstrAssignSubstr(AllegroUstr? ustr1, AllegroUstr? ustr2, int startPosition, int endPosition)
  {
    return NativeFunctions.AlUstrAssignSubstr(
      NativePointerModel.GetPointer(ustr1),
      NativePointerModel.GetPointer(ustr2),
      startPosition,
      endPosition);
  }

  public static bool UstrAssignCstr(AllegroUstr? ustr, string str)
  {
    var nativeStr = Marshal.StringToHGlobalAnsi(str);
    var result = NativeFunctions.AlUstrAssignCstr(NativePointerModel.GetPointer(ustr), nativeStr);
    Marshal.FreeHGlobal(nativeStr);
    return result;
  }

  public static long UstrSetChr(AllegroUstr? ustr, int startPosition, int c)
  {
    return NativeFunctions.AlUstrSetChr(NativePointerModel.GetPointer(ustr), startPosition, c);
  }

  public static bool UstrReplaceRange(AllegroUstr? ustr1, int startPosition, int endPosition, AllegroUstr? ustr2)
  {
    return NativeFunctions.AlUstrReplaceRange(
      NativePointerModel.GetPointer(ustr1),
      startPosition,
      endPosition,
      NativePointerModel.GetPointer(ustr2));
  }

  public static int UstrFindChr(AllegroUstr? ustr, int startPosition, int c)
  {
    return NativeFunctions.AlUstrFindChr(NativePointerModel.GetPointer(ustr), startPosition, c);
  }

  public static int UstrRfindChr(AllegroUstr? ustr, int endPosition, int c)
  {
    return NativeFunctions.AlUstrRFindChr(NativePointerModel.GetPointer(ustr), endPosition, c);
  }

  public static int UstrFindSet(AllegroUstr? ustr, int startPosition, AllegroUstr? accept)
  {
    return NativeFunctions.AlUstrFindSet(NativePointerModel.GetPointer(ustr), startPosition, NativePointerModel.GetPointer(accept));
  }

  public static int UstrFindSetCstr(AllegroUstr? ustr, int startPosition, string accept)
  {
    var nativeAccept = Marshal.StringToHGlobalAnsi(accept);
    var result = NativeFunctions.AlUstrFindSetCstr(NativePointerModel.GetPointer(ustr), startPosition, nativeAccept);
    Marshal.FreeHGlobal(nativeAccept);
    return result;
  }

  public static int UstrFindCset(AllegroUstr? ustr, int startPosition, AllegroUstr? reject)
  {
    return NativeFunctions.AlUstrFindCset(NativePointerModel.GetPointer(ustr), startPosition, NativePointerModel.GetPointer(reject));
  }

  public static int UstrFindCsetCstr(AllegroUstr? ustr, int startPosition, string reject)
  {
    var nativeReject = Marshal.StringToHGlobalAnsi(reject);
    var result = NativeFunctions.AlUstrFindCsetCstr(NativePointerModel.GetPointer(ustr), startPosition, nativeReject);
    Marshal.FreeHGlobal(nativeReject);
    return result;
  }

  public static int UstrFindStr(AllegroUstr? haystack, int startPosition, AllegroUstr? needle)
  {
    return NativeFunctions.AlUstrFindStr(NativePointerModel.GetPointer(haystack), startPosition, NativePointerModel.GetPointer(needle));
  }

  public static int UstrFindCstr(AllegroUstr? haystack, int startPosition, string needle)
  {
    var nativeNeedle = Marshal.StringToHGlobalAnsi(needle);
    var result = NativeFunctions.AlUstrFindCstr(NativePointerModel.GetPointer(haystack), startPosition, nativeNeedle);
    Marshal.FreeHGlobal(nativeNeedle);
    return result;
  }

  public static int UstrRfindStr(AllegroUstr? haystack, int endPosition, AllegroUstr? needle)
  {
    return NativeFunctions.AlUstrRfindStr(NativePointerModel.GetPointer(haystack), endPosition, NativePointerModel.GetPointer(needle));
  }

  public static int UstrRfindCstr(AllegroUstr? haystack, int endPosition, string needle)
  {
    var nativeNeedle = Marshal.StringToHGlobalAnsi(needle);
    var result = NativeFunctions.AlUstrRfindCstr(NativePointerModel.GetPointer(haystack), endPosition, nativeNeedle);
    Marshal.FreeHGlobal(nativeNeedle);
    return result;
  }

  public static bool UstrFindReplace(AllegroUstr? ustr, int startPosition, AllegroUstr? find, AllegroUstr? replace)
  {
    return NativeFunctions.AlUstrFindReplace(
      NativePointerModel.GetPointer(ustr),
      startPosition,
      NativePointerModel.GetPointer(find),
      NativePointerModel.GetPointer(replace));
  }

  public static bool UstrFindReplaceCstr(AllegroUstr? ustr, int startPosition, string find, string replace)
  {
    var nativeFind = Marshal.StringToHGlobalAnsi(find);
    var nativeReplace = Marshal.StringToHGlobalAnsi(replace);
    var result = NativeFunctions.AlUstrFindReplaceCstr(
      NativePointerModel.GetPointer(ustr),
      startPosition,
      nativeFind,
      nativeReplace);
    Marshal.FreeHGlobal(nativeFind);
    Marshal.FreeHGlobal(nativeReplace);
    return result;
  }

  public static bool UstrEqual(AllegroUstr? ustr1, AllegroUstr? ustr2)
  {
    return NativeFunctions.AlUstrEqual(NativePointerModel.GetPointer(ustr1), NativePointerModel.GetPointer(ustr2));
  }

  public static int UstrCompare(AllegroUstr? ustr1, AllegroUstr? ustr2)
  {
    return NativeFunctions.AlUstrCompare(NativePointerModel.GetPointer(ustr1), NativePointerModel.GetPointer(ustr2));
  }

  public static int UstrNcompare(AllegroUstr? ustr1, AllegroUstr? ustr2, int n)
  {
    return NativeFunctions.AlUstrNcompare(NativePointerModel.GetPointer(ustr1), NativePointerModel.GetPointer(ustr2), n);
  }

  public static bool UstrHasPrefix(AllegroUstr? ustr1, AllegroUstr? ustr2)
  {
    return NativeFunctions.AlUstrHasPrefix(NativePointerModel.GetPointer(ustr1), NativePointerModel.GetPointer(ustr2));
  }

  public static bool UstrHasPrefixCstr(AllegroUstr? ustr, string str)
  {
    var nativeStr = Marshal.StringToHGlobalAnsi(str);
    var result = NativeFunctions.AlUstrHasPrefixCstr(NativePointerModel.GetPointer(ustr), nativeStr);
    Marshal.FreeHGlobal(nativeStr);
    return result;
  }

  public static bool UstrHasSuffix(AllegroUstr? ustr1, AllegroUstr? ustr2)
  {
    return NativeFunctions.AlUstrHasSuffix(NativePointerModel.GetPointer(ustr1), NativePointerModel.GetPointer(ustr2));
  }

  public static bool UstrHasSuffixCstr(AllegroUstr? ustr, string str)
  {
    var nativeStr = Marshal.StringToHGlobalAnsi(str);
    var result = NativeFunctions.AlUstrHasSuffixCstr(NativePointerModel.GetPointer(ustr), nativeStr);
    Marshal.FreeHGlobal(nativeStr);
    return result;
  }

  public static AllegroUstr? UstrNewFromUtf16(string str)
  {
    var nativeStr = Marshal.StringToHGlobalUni(str);
    var result = NativeFunctions.AlUstrNewFromUtf16(nativeStr);
    Marshal.FreeHGlobal(nativeStr);
    return NativePointerModel.Create<AllegroUstr>(result);
  }

  public static long UstrSizeUtf16(AllegroUstr? ustr)
  {
    var nativeUstr = NativePointerModel.GetPointer(ustr);
    return NativeFunctions.AlUstrSizeUtf16(nativeUstr);
  }

  public static long UstrEncodeUtf16(AllegroUstr? ustr, IntPtr buffer, long size)
  {
    var nativeUstr = NativePointerModel.GetPointer(ustr);
    return NativeFunctions.AlUstrEncodeUtf16(nativeUstr, buffer, size);
  }

  public static long Utf8Width(int c)
  {
    return NativeFunctions.AlUtf8Width(c);
  }

  public static long Utf8Encode(IntPtr buffer, int c)
  {
    return NativeFunctions.AlUtf8Encode(buffer, c);
  }

  public static long Utf16Width(int c)
  {
    return NativeFunctions.AlUtf16Width(c);
  }

  public static long Utf16Encode(IntPtr buffer, int c)
  {
    return NativeFunctions.AlUtf16Encode(buffer, c);
  }
}
