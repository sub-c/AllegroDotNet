using SubC.AllegroDotNet.Enums;
using SubC.AllegroDotNet.Models;
using SubC.AllegroDotNet.Native;
using System.Runtime.InteropServices;

namespace SubC.AllegroDotNet;

/// <summary>
/// This static class contains the Allegro 5 library methods.
/// </summary>
public static partial class Al
{
    public static AllegroShader? CreateShader(ShaderPlatform platform)
    {
        var pointer = Interop.Core.AlCreateShader((int)platform);
        return NativePointer.Create<AllegroShader>(pointer);
    }

    public static bool AttachShaderSource(AllegroShader? shader, ShaderType type, string? source)
    {
        using var nativeSource = new CStringAnsi(source);
        return Interop.Core.AlAttachShaderSource(NativePointer.Get(shader), (int)type, nativeSource.Pointer) != 0;
    }

    public static bool AttachShaderSourceFile(AllegroShader? shader, ShaderType type, string filename)
    {
        using var nativeFilename = new CStringAnsi(filename);
        return Interop.Core.AlAttachShaderSourceFile(NativePointer.Get(shader), (int)type, nativeFilename.Pointer) != 0;
    }

    public static bool BuildShader(AllegroShader? shader)
    {
        return Interop.Core.AlBuildShader(NativePointer.Get(shader)) != 0;
    }

    public static string? GetShaderLog(AllegroShader? shader)
    {
        var pointer = Interop.Core.AlGetShaderLog(NativePointer.Get(shader));
        return Marshal.PtrToStringAnsi(pointer);
    }

    public static ShaderPlatform GetShaderPlatform(AllegroShader? shader)
    {
        return (ShaderPlatform)Interop.Core.AlGetShaderPlatform(NativePointer.Get(shader));
    }

    public static bool UseShader(AllegroShader? shader)
    {
        return Interop.Core.AlUseShader(NativePointer.Get(shader)) != 0;
    }

    public static void DestroyShader(AllegroShader? shader)
    {
        Interop.Core.AlDestroyShader(NativePointer.Get(shader));
    }

    public static bool SetShaderSampler(string? name, AllegroBitmap? bitmap, int unit)
    {
        using var nativeName = new CStringAnsi(name);
        return Interop.Core.AlSetShaderSampler(nativeName.Pointer, NativePointer.Get(bitmap), unit) != 0;
    }

    public static bool SetShaderMatrix(string? name, in AllegroTransform matrix)
    {
        using var nativeName = new CStringAnsi(name);
        return Interop.Core.AlSetShaderMatrix(nativeName.Pointer, in matrix) != 0;
    }

    public static bool SetShaderInt(string? name, int i)
    {
        using var nativeName = new CStringAnsi(name);
        return Interop.Core.AlSetShaderInt(nativeName.Pointer, i) != 0;
    }

    public static bool SetShaderFloat(string? name, float f)
    {
        using var nativeName = new CStringAnsi(name);
        return Interop.Core.AlSetShaderFloat(nativeName.Pointer, f) != 0;
    }

    public static bool SetShaderBool(string? name, bool b)
    {
        using var nativeName = new CStringAnsi(name);
        return Interop.Core.AlSetShaderBool(nativeName.Pointer, (byte)(b ? 1 : 0)) != 0;
    }

    public static bool SetShaderIntVector(string? name, int componentCount, ref int i, int elementCount)
    {
        using var nativeName = new CStringAnsi(name);
        return Interop.Core.AlSetShaderIntVector(nativeName.Pointer, componentCount, ref i, elementCount) != 0;
    }

    public static bool SetShaderFloatVector(string? name, int componentCount, ref float f, int elementCount)
    {
        using var nativeName = new CStringAnsi(name);
        return Interop.Core.AlSetShaderFloatVector(nativeName.Pointer, componentCount, ref f, elementCount) != 0;
    }

    public static string? GetDefaultShaderSource(ShaderPlatform platform, ShaderType type)
    {
        var pointer = Interop.Core.AlGetDefaultShaderSource((int)platform, (int)type);
        return CStringAnsi.ToCSharpString(pointer);
    }
}
