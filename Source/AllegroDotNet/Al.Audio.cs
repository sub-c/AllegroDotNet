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
  public static bool InstallAudio()
  {
    return Interop.Audio.AlInstallAudio() != 0;
  }

  public static void UninstallAudio()
  {
    Interop.Audio.AlUninstallAudio();
  }

  public static bool IsAudioInstalled()
  {
    return Interop.Audio.AlIsAudioInstalled() != 0;
  }

  public static bool ReserveSamples(int samples)
  {
    return Interop.Audio.AlReserveSamples(samples) != 0;
  }

  public static bool PlaySample(
    AllegroSample? sample,
    float gain,
    float pan,
    float speed,
    PlayMode loop,
    ref AllegroSampleID? retID)
  {
    if (retID is null)
      return Interop.Audio.AlPlaySample(NativePointer.Get(sample), gain, pan, speed, (int)loop, IntPtr.Zero) != 0;

    var nativeSampleIDSize = Marshal.SizeOf<AllegroSampleID>();
    var nativeRetID = Marshal.AllocHGlobal(nativeSampleIDSize);

    try
    {
      Marshal.StructureToPtr(retID, nativeRetID, false);
      var result = Interop.Audio.AlPlaySample(NativePointer.Get(sample), gain, pan, speed, (int)loop, nativeRetID) != 0;
      retID = Marshal.PtrToStructure<AllegroSampleID>(nativeRetID);
      return result;
    }
    finally
    {
      Marshal.FreeHGlobal(nativeRetID);
    }
  }

  public static void StopSample(ref AllegroSampleID? sampleID)
  {
    if (sampleID is null)
    {
      Interop.Audio.AlStopSample(IntPtr.Zero);
      return;
    }

    var nativeSampleIDSize = Marshal.SizeOf<AllegroSampleID>();
    var nativeSampleID = Marshal.AllocHGlobal(nativeSampleIDSize);

    try
    {
      Marshal.StructureToPtr(sampleID, nativeSampleID, false);
      Interop.Audio.AlStopSample(nativeSampleID);
      sampleID = Marshal.PtrToStructure<AllegroSampleID>(nativeSampleID);
    }
    finally
    {
      Marshal.FreeHGlobal(nativeSampleID);
    }
  }

  public static void StopSamples()
  {
    Interop.Audio.AlStopSamples();
  }

  public static AllegroSample? CreateSample(byte[] buffer, uint samples, uint frequency, AudioDepth depth, ChannelConfig channelConfig, bool freeBuffer)
  {
    var pointer = Interop.Audio.AlCreateSample(buffer, samples, frequency, (int)depth, (int)channelConfig, (byte)(freeBuffer ? 1 : 0));
    return NativePointer.Create<AllegroSample>(pointer);
  }

  public static AllegroSample? LoadSample(string filename)
  {
    using var nativeFilename = new CStringAnsi(filename);
    var pointer = Interop.Audio.AlLoadSample(nativeFilename.Pointer);
    return NativePointer.Create<AllegroSample>(pointer);
  }

  public static AllegroSample? LoadSampleF(AllegroFile? file, string identifier)
  {
    using var nativeIdentifier = new CStringAnsi(identifier);
    var pointer = Interop.Audio.AlLoadSampleF(NativePointer.Get(file), nativeIdentifier.Pointer);
    return NativePointer.Create<AllegroSample>(pointer);
  }

  public static bool SaveSample(string filename, AllegroSample? sample)
  {
    using var nativeFilename = new CStringAnsi(filename);
    return Interop.Audio.AlSaveSample(nativeFilename.Pointer, NativePointer.Get(sample)) != 0;
  }

  public static bool SaveSampleF(AllegroFile? file, string identifier, AllegroSample? sample)
  {
    using var nativeFilename = new CStringAnsi(identifier);
    return Interop.Audio.AlSaveSampleF(NativePointer.Get(file), nativeFilename.Pointer, NativePointer.Get(sample)) != 0;
  }

  public static void DestroySample(AllegroSample? sample)
  {
    Interop.Audio.AlDestroySample(NativePointer.Get(sample));
  }

  public static ChannelConfig GetSampleChannels(AllegroSample? sample)
  {
    return (ChannelConfig)Interop.Audio.AlGetSampleChannels(NativePointer.Get(sample));
  }

  public static AudioDepth GetSampleDepth(AllegroSample? sample)
  {
    return (AudioDepth)Interop.Audio.AlGetSampleDepth(NativePointer.Get(sample));
  }

  public static uint GetSampleFrequency(AllegroSample? sample)
  {
    return Interop.Audio.AlGetSampleFrequency(NativePointer.Get(sample));
  }

  public static uint GetSampleLength(AllegroSample? sample)
  {
    return Interop.Audio.AlGetSampleLength(NativePointer.Get(sample));
  }

  public static IntPtr GetSampleData(AllegroSample? sample)
  {
    return Interop.Audio.AlGetSampleData(NativePointer.Get(sample));
  }

  public static AllegroSampleInstance? CreateSampleInstance(AllegroSample? sample)
  {
    var pointer = Interop.Audio.AlCreateSampleInstance(NativePointer.Get(sample));
    return NativePointer.Create<AllegroSampleInstance>(pointer);
  }

  public static void DestroySampleInstance(AllegroSampleInstance? instance)
  {
    Interop.Audio.AlDestroySampleInstance(NativePointer.Get(instance));
  }

  public static bool PlaySampleInstance(AllegroSampleInstance? instance)
  {
    return Interop.Audio.AlPlaySampleInstance(NativePointer.Get(instance)) != 0;
  }

  public static bool StopSampleInstance(AllegroSampleInstance? instance)
  {
    return Interop.Audio.AlStopSampleInstance(NativePointer.Get(instance)) != 0;
  }

  public static ChannelConfig GetSampleInstanceChannels(AllegroSampleInstance? instance)
  {
    return (ChannelConfig)Interop.Audio.AlGetSampleInstanceChannels(NativePointer.Get(instance));
  }

  public static AudioDepth GetSampleInstanceDepth(AllegroSampleInstance? instance)
  {
    return (AudioDepth)Interop.Audio.AlGetSampleInstanceDepth(NativePointer.Get(instance));
  }

  public static uint GetSampleInstanceFrequency(AllegroSampleInstance? instance)
  {
    return Interop.Audio.AlGetSampleInstanceFrequency(NativePointer.Get(instance));
  }

  public static uint GetSampleInstanceLength(AllegroSampleInstance? instance)
  {
    return Interop.Audio.AlGetSampleInstanceLength(NativePointer.Get(instance));
  }

  public static bool SetSampleInstanceLength(AllegroSampleInstance? instance, uint length)
  {
    return Interop.Audio.AlSetSampleInstanceLength(NativePointer.Get(instance), length) != 0;
  }

  public static uint GetSampleInstancePosition(AllegroSampleInstance? instance)
  {
    return Interop.Audio.AlGetSampleInstancePosition(NativePointer.Get(instance));
  }

  public static bool SetSampleInstancePosition(AllegroSampleInstance? instance, uint position)
  {
    return Interop.Audio.AlSetSampleInstancePosition(NativePointer.Get(instance), position) != 0;
  }

  public static float GetSampleInstanceSpeed(AllegroSampleInstance? instance)
  {
    return Interop.Audio.AlGetSampleInstanceSpeed(NativePointer.Get(instance));
  }

  public static bool SetSampleInstanceSpeed(AllegroSampleInstance? instance, float speed)
  {
    return Interop.Audio.AlSetSampleInstanceSpeed(NativePointer.Get(instance), speed) != 0;
  }

  public static float GetSampleInstanceGain(AllegroSampleInstance? instance)
  {
    return Interop.Audio.AlGetSampleInstanceGain(NativePointer.Get(instance));
  }

  public static bool SetSampleInstanceGain(AllegroSampleInstance? instance, float gain)
  {
    return Interop.Audio.AlSetSampleInstanceGain(NativePointer.Get(instance), gain) != 0;
  }

  public static float GetSampleInstancePan(AllegroSampleInstance? instance)
  {
    return Interop.Audio.AlGetSampleInstancePan(NativePointer.Get(instance));
  }

  public static bool SetSampleInstancePan(AllegroSampleInstance? instance, float pan)
  {
    return Interop.Audio.AlSetSampleInstancePan(NativePointer.Get(instance), pan) != 0;
  }

  public static float GetSampleInstanceTime(AllegroSampleInstance? instance)
  {
    return Interop.Audio.AlGetSampleInstanceTime(NativePointer.Get(instance));
  }

  public static PlayMode GetSampleInstancePlaymode(AllegroSampleInstance? instance)
  {
    return (PlayMode)Interop.Audio.AlGetSampleInstancePlaymode(NativePointer.Get(instance));
  }

  public static bool SetSampleInstancePlaymode(AllegroSampleInstance? instance, PlayMode playmode)
  {
    return Interop.Audio.AlSetSampleInstancePlaymode(NativePointer.Get(instance), (int)playmode) != 0;
  }

  public static bool GetSampleInstancePlaying(AllegroSampleInstance? instance)
  {
    return Interop.Audio.AlGetSampleInstancePlaying(NativePointer.Get(instance)) != 0;
  }

  public static bool SetSampleInstancePlaying(AllegroSampleInstance? instance, bool isPlaying)
  {
    return Interop.Audio.AlSetSampleInstancePlaying(NativePointer.Get(instance), (byte)(isPlaying ? 1 : 0)) != 0;
  }

  public static bool GetSampleInstanceAttached(AllegroSampleInstance? instance)
  {
    return Interop.Audio.AlGetSampleInstanceAttached(NativePointer.Get(instance)) != 0;
  }

  public static bool DetachSampleInstance(AllegroSampleInstance? instance)
  {
    return Interop.Audio.AlDetachSampleInstance(NativePointer.Get(instance)) != 0;
  }

  public static AllegroSample? GetSample(AllegroSampleInstance? instance)
  {
    var pointer = Interop.Audio.AlGetSample(NativePointer.Get(instance));
    return NativePointer.Create<AllegroSample>(pointer);
  }

  public static bool SetSample(AllegroSampleInstance? instance, AllegroSample? sample)
  {
    return Interop.Audio.AlSetSample(NativePointer.Get(instance), NativePointer.Get(sample)) != 0;
  }

  public static AllegroAudioStream? CreateAudioStream(
    long count,
    uint samples,
    uint freqency,
    AudioDepth depth,
    ChannelConfig channelConfig)
  {
    var pointer = Interop.Audio.AlCreateAudioStream(count, samples, freqency, (int)depth, (int)channelConfig);
    return NativePointer.Create<AllegroAudioStream>(pointer);
  }

  public static AllegroAudioStream? LoadAudioStream(string filename, long count, uint samples)
  {
    using var nativeFilename = new CStringAnsi(filename);
    var pointer = Interop.Audio.AlLoadAudioStream(nativeFilename.Pointer, count, samples);
    return NativePointer.Create<AllegroAudioStream>(pointer);
  }

  public static AllegroAudioStream? LoadAudioStreamF(AllegroFile? file, string identifier, long bufferCount, uint samples)
  {
    using var nativeIdentifier = new CStringAnsi(identifier);
    var pointer = Interop.Audio.AlLoadAudioStreamF(NativePointer.Get(file), nativeIdentifier.Pointer, bufferCount, samples);
    return NativePointer.Create<AllegroAudioStream>(pointer);
  }

  public static void DestroyAudioStream(AllegroAudioStream? stream)
  {
    Interop.Audio.AlDestroyAudioStream(NativePointer.Get(stream));
  }

  public static AllegroEventSource? GetAudioStreamEventSource(AllegroAudioStream? stream)
  {
    var pointer = Interop.Audio.AlGetAudioStreamEventSource(NativePointer.Get(stream));
    return NativePointer.Create<AllegroEventSource>(pointer);
  }

  public static void DrainAudioStream(AllegroAudioStream? stream)
  {
    Interop.Audio.AlDrainAudioStream(NativePointer.Get(stream));
  }

  public static bool RewindAudioStream(AllegroAudioStream? stream)
  {
    return Interop.Audio.AlRewindAudioStream(NativePointer.Get(stream)) != 0;
  }

  public static uint GetAudioStreamFrequency(AllegroAudioStream? stream)
  {
    return Interop.Audio.AlGetAudioStreamFrequency(NativePointer.Get(stream));
  }

  public static ChannelConfig GetAudioStreamChannels(AllegroAudioStream? stream)
  {
    return (ChannelConfig)Interop.Audio.AlGetAudioStreamChannels(NativePointer.Get(stream));
  }

  public static AudioDepth GetAudioStreamDepth(AllegroAudioStream? stream)
  {
    return (AudioDepth)Interop.Audio.AlGetAudioStreamDepth(NativePointer.Get(stream));
  }

  public static uint GetAudioStreamLength(AllegroAudioStream? stream)
  {
    return Interop.Audio.AlGetAudioStreamLength(NativePointer.Get(stream));
  }

  public static float GetAudioStreamSpeed(AllegroAudioStream? stream)
  {
    return Interop.Audio.AlGetAudioStreamSpeed(NativePointer.Get(stream));
  }

  public static bool SetAudioStreamSpeed(AllegroAudioStream? stream, float speed)
  {
    return Interop.Audio.AlSetAudioStreamSpeed(NativePointer.Get(stream), speed) != 0;
  }

  public static float GetAudioStreamGain(AllegroAudioStream? stream)
  {
    return Interop.Audio.AlGetAudioStreamGain(NativePointer.Get(stream));
  }

  public static bool SetAudioStreamGain(AllegroAudioStream? stream, float gain)
  {
    return Interop.Audio.AlSetAudioStreamGain(NativePointer.Get(stream), gain) != 0;
  }

  public static float GetAudioStreamPan(AllegroAudioStream? stream)
  {
    return Interop.Audio.AlGetAudioStreamPan(NativePointer.Get(stream));
  }

  public static bool SetAudioStreamPan(AllegroAudioStream? stream, float pan)
  {
    return Interop.Audio.AlSetAudioStreamPan(NativePointer.Get(stream), pan) != 0;
  }

  public static bool GetAudioStreamPlaying(AllegroAudioStream? stream)
  {
    return Interop.Audio.AlGetAudioStreamPlaying(NativePointer.Get(stream)) != 0;
  }

  public static bool SetAudioStreamPlaying(AllegroAudioStream? stream, bool isPlaying)
  {
    return Interop.Audio.AlSetAudioStreamPlaying(NativePointer.Get(stream), (byte)(isPlaying ? 1 : 0)) != 0;
  }

  public static PlayMode GetAudioStreamPlaymode(AllegroAudioStream? stream)
  {
    return (PlayMode)Interop.Audio.AlGetAudioStreamPlaymode(NativePointer.Get(stream));
  }

  public static bool SetAudioStreamPlaymode(AllegroAudioStream? stream, PlayMode mode)
  {
    return Interop.Audio.AlSetAudioStreamPlaymode(NativePointer.Get(stream), (int)mode) != 0;
  }

  public static bool GetAudioStreamAttached(AllegroAudioStream? stream)
  {
    return Interop.Audio.AlGetAudioStreamAttached(NativePointer.Get(stream)) != 0;
  }

  public static bool DetachAudioStream(AllegroAudioStream? stream)
  {
    return Interop.Audio.AlDetachAudioStream(NativePointer.Get(stream)) != 0;
  }

  public static ulong GetAudioStreamPlayedSamples(AllegroAudioStream? stream)
  {
    return Interop.Audio.AlGetAudioStreamPlayedSamples(NativePointer.Get(stream));
  }

  public static IntPtr GetAudioStreamFragment(AllegroAudioStream? stream)
  {
    return Interop.Audio.AlGetAudioStreamFragment(NativePointer.Get(stream));
  }

  public static bool SetAudioStreamFragment(AllegroAudioStream? stream, IntPtr fragment)
  {
    return Interop.Audio.AlSetAudioStreamFragment(NativePointer.Get(stream), fragment) != 0;
  }

  public static uint GetAudioStreamFragments(AllegroAudioStream? stream)
  {
    return Interop.Audio.AlGetAudioStreamFragments(NativePointer.Get(stream));
  }

  public static uint GetAvailableAudioStreamFragments(AllegroAudioStream? stream)
  {
    return Interop.Audio.AlGetAvailableAudioStreamFragments(NativePointer.Get(stream));
  }

  public static bool SeekAudioStreamSecs(AllegroAudioStream? stream, double seconds)
  {
    return Interop.Audio.AlSeekAudioStreamSecs(NativePointer.Get(stream), seconds) != 0;
  }

  public static double GetAudioStreamPositionSecs(AllegroAudioStream? stream)
  {
    return Interop.Audio.AlGetAudioStreamPositionSecs(NativePointer.Get(stream));
  }

  public static double GetAudioStreamLengthSecs(AllegroAudioStream? stream)
  {
    return Interop.Audio.AlGetAudioStreamLengthSecs(NativePointer.Get(stream));
  }

  public static bool SetAudioStreamLoopSecs(AllegroAudioStream? stream, double start, double end)
  {
    return Interop.Audio.AlSetAudioStreamLoopSecs(NativePointer.Get(stream), start, end) != 0;
  }

  public static bool RegisterSampleLoader(string extension, Delegates.RegisterSampleLoaderDelegate loader)
  {
    using var nativeExtension = new CStringAnsi(extension);
    return Interop.Audio.AlRegisterSampleLoader(nativeExtension.Pointer, loader) != 0;
  }

  public static bool RegisterSampleLoaderF(string extension, Delegates.RegisterSampleLoaderFDelegate loader)
  {
    using var nativeExtension = new CStringAnsi(extension);
    return Interop.Audio.AlRegisterSampleLoaderF(nativeExtension.Pointer, loader) != 0;
  }

  public static bool RegisterSampleSaver(string extension, Delegates.RegisterSampleSaverDelegate saver)
  {
    using var nativeExtension = new CStringAnsi(extension);
    return Interop.Audio.AlRegisterSampleSaver(nativeExtension.Pointer, saver) != 0;
  }

  public static bool RegisterSampleSaverF(string extension, Delegates.RegisterSampleSaverFDelegate saver)
  {
    using var nativeExtension = new CStringAnsi(extension);
    return Interop.Audio.AlRegisterSampleSaverF(nativeExtension.Pointer, saver) != 0;
  }

  public static bool RegisterAudioStreamLoader(string extension, Delegates.RegisterAudioStreamLoader loader)
  {
    using var nativeExtension = new CStringAnsi(extension);
    return Interop.Audio.AlRegisterAudioStreamLoader(nativeExtension.Pointer, loader) != 0;
  }

  public static bool RegisterAudioStreamLoaderF(string extension, Delegates.RegisterAudioStreamFLoader loader)
  {
    using var nativeExtension = new CStringAnsi(extension);
    return Interop.Audio.AlRegisterAudioStreamLoaderF(nativeExtension.Pointer, loader) != 0;
  }

  public static bool RegisterSampleIdentifier(string extension, Delegates.RegisterSampleIdentifierDelegate identifier)
  {
    using var nativeExtension = new CStringAnsi(extension);
    return Interop.Audio.AlRegisterSampleIdentifier(nativeExtension.Pointer, identifier) != 0;
  }

  public static string? IdentifySample(string filename)
  {
    using var nativeFilename = new CStringAnsi(filename);
    var pointer = Interop.Audio.AlIdentifySample(nativeFilename.Pointer);
    return Marshal.PtrToStringAnsi(pointer);
  }

  public static string? IdentifySampleF(AllegroFile? file)
  {
    var pointer = Interop.Audio.AlIdentifySampleF(NativePointer.Get(file));
    return Marshal.PtrToStringAnsi(pointer);
  }

  public static int GetNumAudioOutputDevices()
  {
    return Interop.Audio.AlGetNumAudioOutputDevices();
  }

  public static AllegroAudioDevice? GetAudioOutputDevice(int index)
  {
    var pointer = Interop.Audio.AlGetAudioOutputDevice(index);
    return NativePointer.Create<AllegroAudioDevice>(pointer);
  }

  public static string? GetAudioDeviceName(AllegroAudioDevice? device)
  {
    var pointer = Interop.Audio.AlGetAudioDeviceName(NativePointer.Get(device));
    return Marshal.PtrToStringAnsi(pointer);
  }

  public static AllegroVoice? CreateVoice(uint frequency, AudioDepth depth, ChannelConfig channelConfig)
  {
    var pointer = Interop.Audio.AlCreateVoice(frequency, (int)depth, (int)channelConfig);
    return NativePointer.Create<AllegroVoice>(pointer);
  }

  public static void DestroyVoice(AllegroVoice? voice)
  {
    Interop.Audio.AlDestroyVoice(NativePointer.Get(voice));
  }

  public static void DetachVoice(AllegroVoice? voice)
  {
    Interop.Audio.AlDetachVoice(NativePointer.Get(voice));
  }

  public static bool AttachAudioStreamToVoice(AllegroAudioStream? stream, AllegroVoice? voice)
  {
    return Interop.Audio.AlAttachAudioStreamToVoice(NativePointer.Get(stream), NativePointer.Get(voice)) != 0;
  }

  public static bool AttachMixerToVoice(AllegroMixer? mixer, AllegroVoice? voice)
  {
    return Interop.Audio.AlAttachMixerToVoice(NativePointer.Get(mixer), NativePointer.Get(voice)) != 0;
  }

  public static bool AttachSampleInstanceToVoice(AllegroSampleInstance? instance, AllegroVoice? voice)
  {
    return Interop.Audio.AlAttachSampleInstanceToVoice(NativePointer.Get(instance), NativePointer.Get(voice)) != 0;
  }

  public static uint GetVoiceFrequency(AllegroVoice? voice)
  {
    return Interop.Audio.AlGetVoiceFrequency(NativePointer.Get(voice));
  }

  public static ChannelConfig GetVoiceChannels(AllegroVoice? voice)
  {
    return (ChannelConfig)Interop.Audio.AlGetVoiceChannels(NativePointer.Get(voice));
  }

  public static AudioDepth GetVoiceDepth(AllegroVoice? voice)
  {
    return (AudioDepth)Interop.Audio.AlGetVoiceDepth(NativePointer.Get(voice));
  }

  public static bool GetVoicePlaying(AllegroVoice? voice)
  {
    return Interop.Audio.AlGetVoicePlaying(NativePointer.Get(voice)) != 0;
  }

  public static bool SetVoicePlaying(AllegroVoice? voice, bool isPlaying)
  {
    return Interop.Audio.AlSetVoicePlaying(NativePointer.Get(voice), (byte)(isPlaying ? 1 : 0)) != 0;
  }

  public static uint GetVoicePosition(AllegroVoice? voice)
  {
    return Interop.Audio.AlGetVoicePosition(NativePointer.Get(voice));
  }

  public static bool SetVoicePosition(AllegroVoice? voice, uint position)
  {
    return Interop.Audio.AlSetVoicePosition(NativePointer.Get(voice), position) != 0;
  }

  public static AllegroMixer? CreateMixer(uint frequency, AudioDepth depth, ChannelConfig channelConfig)
  {
    var pointer = Interop.Audio.AlCreateMixer(frequency, (int)depth, (int)channelConfig);
    return NativePointer.Create<AllegroMixer>(pointer);
  }

  public static void DestroyMixer(AllegroMixer? mixer)
  {
    Interop.Audio.AlDestroyMixer(NativePointer.Get(mixer));
  }

  public static AllegroMixer? GetDefaultMixer()
  {
    var pointer = Interop.Audio.AlGetDefaultMixer();
    return NativePointer.Create<AllegroMixer>(pointer);
  }

  public static bool SetDefaultMixer(AllegroMixer? mixer)
  {
    return Interop.Audio.AlSetDefaultMixer(NativePointer.Get(mixer)) != 0;
  }

  public static bool RestoreDefaultMixer()
  {
    return Interop.Audio.AlRestoreDefaultMixer() != 0;
  }

  public static AllegroVoice? GetDefaultVoice()
  {
    var pointer = Interop.Audio.AlGetDefaultVoice();
    return NativePointer.Create<AllegroVoice>(pointer);
  }

  public static void SetDefaultVoice(AllegroVoice? voice)
  {
    Interop.Audio.AlSetDefaultVoice(NativePointer.Get(voice));
  }

  public static bool AttachMixerToMixer(AllegroMixer? mixerToAttach, AllegroMixer? mixerToAttachTo)
  {
    return Interop.Audio.AlAttachMixerToMixer(NativePointer.Get(mixerToAttach), NativePointer.Get(mixerToAttachTo)) != 0;
  }

  public static bool AttachSampleInstanceToMixer(AllegroSampleInstance? instance, AllegroMixer? mixer)
  {
    return Interop.Audio.AlAttachSampleInstanceToMixer(NativePointer.Get(instance), NativePointer.Get(mixer)) != 0;
  }

  public static bool AttachAudioStreamToMixer(AllegroAudioStream? stream, AllegroMixer? mixer)
  {
    return Interop.Audio.AlAttachAudioStreamToMixer(NativePointer.Get(stream), NativePointer.Get(mixer)) != 0;
  }

  public static uint GetMixerFrequency(AllegroMixer? mixer)
  {
    return Interop.Audio.AlGetMixerFrequency(NativePointer.Get(mixer));
  }

  public static bool SetMixerFrequency(AllegroMixer? mixer, uint frequency)
  {
    return Interop.Audio.AlSetMixerFrequency(NativePointer.Get(mixer), frequency) != 0;
  }

  public static ChannelConfig GetMixerChannels(AllegroMixer? mixer)
  {
    return (ChannelConfig)Interop.Audio.AlGetMixerChannels(NativePointer.Get(mixer));
  }

  public static AudioDepth GetMixerDepth(AllegroMixer? mixer)
  {
    return (AudioDepth)Interop.Audio.AlGetMixerDepth(NativePointer.Get(mixer));
  }

  public static float GetMixerGain(AllegroMixer? mixer)
  {
    return Interop.Audio.AlGetMixerGain(NativePointer.Get(mixer));
  }

  public static bool SetMixerGain(AllegroMixer? mixer, float gain)
  {
    return Interop.Audio.AlSetMixerGain(NativePointer.Get(mixer), gain) != 0;
  }

  public static MixerQuality GetMixerQuality(AllegroMixer? mixer)
  {
    return (MixerQuality)Interop.Audio.AlGetMixerQuality(NativePointer.Get(mixer));
  }

  public static bool SetMixerQuality(AllegroMixer? mixer, MixerQuality quality)
  {
    return Interop.Audio.AlSetMixerQuality(NativePointer.Get(mixer), (int)quality) != 0;
  }

  public static bool GetMixerPlaying(AllegroMixer? mixer)
  {
    return Interop.Audio.AlGetMixerPlaying(NativePointer.Get(mixer)) != 0;
  }

  public static bool SetMixerPlaying(AllegroMixer? mixer, bool isPlaying)
  {
    return Interop.Audio.AlSetMixerPlaying(NativePointer.Get(mixer), (byte)(isPlaying ? 1 : 0)) != 0;
  }

  public static bool GetMixerAttached(AllegroMixer? mixer)
  {
    return Interop.Audio.AlGetMixerAttached(NativePointer.Get(mixer)) != 0;
  }

  public static bool DetachMixer(AllegroMixer? mixer)
  {
    return Interop.Audio.AlDetachMixer(NativePointer.Get(mixer)) != 0;
  }

  public static bool SetMixerPostprocessCallback(
    AllegroMixer? mixer,
    Delegates.SetMixerPostProcessCallbackDelegate callback,
    IntPtr callbackData)
  {
    return Interop.Audio.AlSetMixerPostprocessCallback(NativePointer.Get(mixer), callback, callbackData) != 0;
  }

  public static uint GetAllegroAudioVersion()
  {
    return Interop.Audio.AlGetAllegroAudioVersion();
  }

  public static ulong GetAudioDepthSize(AudioDepth depth)
  {
    var cSizeT = Interop.Audio.AlGetAudioDepthSize((int)depth);
    return cSizeT.ToUInt64();
  }

  public static ulong GetChannelCount(ChannelConfig channels)
  {
    var cSizeT = Interop.Audio.AlGetChannelCount((int)channels);
    return cSizeT.ToUInt64();
  }

  public static void FillSilence(IntPtr buffer, uint samples, AudioDepth depth, ChannelConfig channels)
  {
    Interop.Audio.AlFillSilence(buffer, samples, (int)depth, (int)channels);
  }
}
