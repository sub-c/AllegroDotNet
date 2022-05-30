using SubC.AllegroDotNet.Enums;
using SubC.AllegroDotNet.Models;
using SubC.AllegroDotNet.Native;
using System;
using System.Runtime.InteropServices;
using static SubC.AllegroDotNet.Native.NativeDelegates;

namespace SubC.AllegroDotNet
{
  public static partial class Al
  {
    public static bool InstallAudio()
    {
      return NativeFunctions.AlInstallAudio();
    }

    public static void UninstallAudio()
    {
      NativeFunctions.AlUninstallAudio();
    }

    public static bool IsAudioInstalled()
    {
      return NativeFunctions.AlIsAudioInstalled();
    }

    public static bool ReserveSamples(int samples)
    {
      return NativeFunctions.AlReserveSamples(samples);
    }

    public static uint GetAllegroAudioVersion()
    {
      return NativeFunctions.AlGetAllegroAudioVersion();
    }

    public static long GetAudioDepthSize(AudioDepth depth)
    {
      return NativeFunctions.AlGetAudioDepthSize((int)depth);
    }

    public static long GetChannelCount(ChannelConfig config)
    {
      return NativeFunctions.AlGetChannelCount((int)config);
    }

    public static void FillSilence(IntPtr buf, uint samples, AudioDepth depth, ChannelConfig config)
    {
      NativeFunctions.AlFillSilence(buf, samples, (int)depth, (int)config);
    }

    public static AllegroVoice? CreateVoice(uint freq, AudioDepth depth, ChannelConfig config)
    {
      var nativeVoice = NativeFunctions.AlCreateVoice(freq, (int)depth, (int)config);
      return NativePointerModel.Create<AllegroVoice>(nativeVoice);
    }

    public static void DestroyVoice(AllegroVoice? voice)
    {
      NativeFunctions.AlDestroyVoice(NativePointerModel.GetPointer(voice));
    }

    public static void DetachVoice(AllegroVoice? voice)
    {
      NativeFunctions.AlDetachVoice(NativePointerModel.GetPointer(voice));
    }

    public static bool AttachAudioStreamToVoice(AllegroAudioStream? stream, AllegroVoice? voice)
    {
      return NativeFunctions.AlAttachAudioStreamToVoice(
        NativePointerModel.GetPointer(stream),
        NativePointerModel.GetPointer(voice));
    }

    public static bool AttachMixerToVoice(AllegroMixer? mixer, AllegroVoice? voice)
    {
      return NativeFunctions.AlAttachMixerToVoice(
        NativePointerModel.GetPointer(mixer),
        NativePointerModel.GetPointer(voice));
    }

    public static bool AttachSampleInstanceToVoice(AllegroSampleInstance? instance, AllegroVoice? voice)
    {
      return NativeFunctions.AlAttachSampleInstanceToVoice(
        NativePointerModel.GetPointer(instance),
        NativePointerModel.GetPointer(voice));
    }

    public static uint GetVoiceFrequency(AllegroVoice? voice)
    {
      return NativeFunctions.AlGetVoiceFrequency(NativePointerModel.GetPointer(voice));
    }

    public static ChannelConfig GetVoiceChannels(AllegroVoice? voice)
    {
      return (ChannelConfig)NativeFunctions.AlGetVoiceChannels(NativePointerModel.GetPointer(voice));
    }

    public static AudioDepth GetVoiceDepth(AllegroVoice? voice)
    {
      return (AudioDepth)NativeFunctions.AlGetVoiceDepth(NativePointerModel.GetPointer(voice));
    }

    public static bool GetVoicePlaying(AllegroVoice? voice)
    {
      return NativeFunctions.AlGetVoicePlaying(NativePointerModel.GetPointer(voice));
    }

    public static bool SetVoicePlaying(AllegroVoice? voice, bool playing)
    {
      return NativeFunctions.AlSetVoicePlaying(NativePointerModel.GetPointer(voice), playing);
    }

    public static uint GetVoicePosition(AllegroVoice? voice)
    {
      return NativeFunctions.AlGetVoicePosition(NativePointerModel.GetPointer(voice));
    }

    public static bool SetVoicePosition(AllegroVoice? voice, uint position)
    {
      return NativeFunctions.AlSetVoicePosition(NativePointerModel.GetPointer(voice), position);
    }

    public static AllegroSample? CreateSample(IntPtr buffer, uint samples, uint frequency, AudioDepth depth, ChannelConfig config, bool freeBuffer)
    {
      var nativeSample = NativeFunctions.AlCreateSample(buffer, samples, frequency, (int)depth, (int)config, freeBuffer);
      return NativePointerModel.Create<AllegroSample>(nativeSample);
    }

    public static void DestroySample(AllegroSample? sample)
    {
      NativeFunctions.AlDestroySample(NativePointerModel.GetPointer(sample));
    }

    public static bool PlaySample(AllegroSample? sample, float gain, float pan, float speed, Playmode playmode, AllegroSampleID? retID)
    {
      var nativeRetID = NativePointerModel.GetPointer(retID);
      var result = NativeFunctions.AlPlaySample(NativePointerModel.GetPointer(sample), gain, pan, speed, (int)playmode, nativeRetID);
      if (retID != null)
      {
        retID.NativePointer = nativeRetID;
      }
      return result;
    }

    public static void StopSample(AllegroSampleID sampleID)
    {
      NativeFunctions.AlStopSample(NativePointerModel.GetPointer(sampleID));
    }

    public static void StopSamples()
    {
      NativeFunctions.AlStopSamples();
    }

    public static ChannelConfig GetSampleChannels(AllegroSample? sample)
    {
      return (ChannelConfig)NativeFunctions.AlGetSampleChannels(NativePointerModel.GetPointer(sample));
    }

    public static AudioDepth GetSampleDepth(AllegroSample? sample)
    {
      return (AudioDepth)NativeFunctions.AlGetSampleDepth(NativePointerModel.GetPointer(sample));
    }

    public static uint GetSampleFrequency(AllegroSample? sample)
    {
      return NativeFunctions.AlGetSampleFrequency(NativePointerModel.GetPointer(sample));
    }

    public static uint GetSampleLength(AllegroSample? sample)
    {
      return NativeFunctions.AlGetSampleLength(NativePointerModel.GetPointer(sample));
    }

    public static IntPtr GetSampleData(AllegroSample? sample)
    {
      return NativeFunctions.AlGetSampleData(NativePointerModel.GetPointer(sample));
    }

    public static AllegroSampleInstance? CreateSampleInstance(AllegroSample? sample)
    {
      var nativeInstance = NativeFunctions.AlCreateSampleInstance(NativePointerModel.GetPointer(sample));
      return NativePointerModel.Create<AllegroSampleInstance>(nativeInstance);
    }

    public static void DestroySampleInstance(AllegroSampleInstance? instance)
    {
      NativeFunctions.AlDestroySampleInstance(NativePointerModel.GetPointer(instance));
    }

    public static bool PlaySampleInstance(AllegroSampleInstance? instance)
    {
      return NativeFunctions.AlPlaySampleInstance(NativePointerModel.GetPointer(instance));
    }

    public static bool StopSampleInstance(AllegroSampleInstance? instance)
    {
      return NativeFunctions.AlStopSampleInstance(NativePointerModel.GetPointer(instance));
    }

    public static ChannelConfig GetSampleInstanceChannels(AllegroSampleInstance? instance)
    {
      return (ChannelConfig)NativeFunctions.AlGetSampleInstanceChannels(NativePointerModel.GetPointer(instance));
    }

    public static AudioDepth GetSampleInstanceDepth(AllegroSampleInstance? instance)
    {
      return (AudioDepth)NativeFunctions.AlGetSampleInstanceDepth(NativePointerModel.GetPointer(instance));
    }

    public static uint GetSampleInstanceFrequency(AllegroSampleInstance? instance)
    {
      return NativeFunctions.AlGetSampleInstanceFrequency(NativePointerModel.GetPointer(instance));
    }

    public static uint GetSampleInstanceLength(AllegroSampleInstance? instance)
    {
      return NativeFunctions.AlGetSampleInstanceLength(NativePointerModel.GetPointer(instance));
    }

    public static bool SetSampleInstanceLength(AllegroSampleInstance? instance, uint length)
    {
      return NativeFunctions.AlSetSampleInstanceLength(NativePointerModel.GetPointer(instance), length);
    }

    public static uint GetSampleInstancePosition(AllegroSampleInstance? instance)
    {
      return NativeFunctions.AlGetSampleInstancePosition(NativePointerModel.GetPointer(instance));
    }

    public static bool SetSampleInstancePosition(AllegroSampleInstance? instance, uint position)
    {
      return NativeFunctions.AlSetSampleInstancePosition(NativePointerModel.GetPointer(instance), position);
    }

    public static float GetSampleInstanceSpeed(AllegroSampleInstance? instance)
    {
      return NativeFunctions.AlGetSampleInstanceSpeed(NativePointerModel.GetPointer(instance));
    }

    public static bool SetSampleInstanceSpeed(AllegroSampleInstance? instance, float speed)
    {
      return NativeFunctions.AlSetSampleInstanceSpeed(NativePointerModel.GetPointer(instance), speed);
    }

    public static float GetSampleInstanceGain(AllegroSampleInstance? instance)
    {
      return NativeFunctions.AlGetSampleInstanceGain(NativePointerModel.GetPointer(instance));
    }

    public static bool SetSampleInstanceGain(AllegroSampleInstance? instance, float gain)
    {
      return NativeFunctions.AlSetSampleInstanceGain(NativePointerModel.GetPointer(instance), gain);
    }

    public static float GetSampleInstancePan(AllegroSampleInstance? instance)
    {
      return NativeFunctions.AlGetSampleInstanceGain(NativePointerModel.GetPointer(instance));
    }

    public static bool SetSampleInstancePan(AllegroSampleInstance? instance, float pan)
    {
      return NativeFunctions.AlSetSampleInstancePan(NativePointerModel.GetPointer(instance), pan);
    }

    public static float GetSampleInstanceTime(AllegroSampleInstance? instance)
    {
      return NativeFunctions.AlGetSampleInstanceTime(NativePointerModel.GetPointer(instance));
    }

    public static Playmode GetSampleInstancePlaymode(AllegroSampleInstance? instance)
    {
      return (Playmode)NativeFunctions.AlGetSampleInstancePlaymode(NativePointerModel.GetPointer(instance));
    }

    public static bool SetSampleInstancePlaymode(AllegroSampleInstance? instance, Playmode playmode)
    {
      return NativeFunctions.AlSetSampleInstancePlaymode(NativePointerModel.GetPointer(instance), (int)playmode);
    }

    public static bool GetSampleInstancePlaying(AllegroSampleInstance? instance)
    {
      return NativeFunctions.AlGetSampleInstancePlaying(NativePointerModel.GetPointer(instance));
    }

    public static bool SetSampleInstancePlaying(AllegroSampleInstance? instance, bool playing)
    {
      return NativeFunctions.AlSetSampleInstancePlaying(NativePointerModel.GetPointer(instance), playing);
    }

    public static bool GetSampleInstanceAttached(AllegroSampleInstance? instance)
    {
      return NativeFunctions.AlGetSampleInstanceAttached(NativePointerModel.GetPointer(instance));
    }

    public static bool DetachSampleInstance(AllegroSampleInstance? instance)
    {
      return NativeFunctions.AlDetachSampleInstance(NativePointerModel.GetPointer(instance));
    }

    public static AllegroSample? GetSample(AllegroSampleInstance? instance)
    {
      var nativeSample = NativeFunctions.AlGetSample(NativePointerModel.GetPointer(instance));
      return NativePointerModel.Create<AllegroSample>(nativeSample);
    }

    public static bool SetSample(AllegroSampleInstance? instance, AllegroSample? sample)
    {
      return NativeFunctions.AlSetSample(NativePointerModel.GetPointer(instance), NativePointerModel.GetPointer(sample));
    }

    public static AllegroMixer? CreateMixer(uint frequency, AudioDepth depth, ChannelConfig config)
    {
      var nativeMixer = NativeFunctions.AlCreateMixer(frequency, (int)depth, (int)config);
      return NativePointerModel.Create<AllegroMixer>(nativeMixer);
    }

    public static void DestroyMixer(AllegroMixer? mixer)
    {
      NativeFunctions.AlDestroyMixer(NativePointerModel.GetPointer(mixer));
    }

    public static AllegroMixer? GetDefaultMixer()
    {
      var nativeMixer = NativeFunctions.AlGetDefaultMixer();
      return NativePointerModel.Create<AllegroMixer>(nativeMixer);
    }

    public static bool SetDefaultMixer(AllegroMixer? mixer)
    {
      return NativeFunctions.AlSetDefaultMixer(NativePointerModel.GetPointer(mixer));
    }

    public static bool RestoreDefaultMixer()
    {
      return NativeFunctions.AlRestoreDefaultMixer();
    }

    public static AllegroVoice? GetDefaultVoice()
    {
      var nativeVoice = NativeFunctions.AlGetDefaultVoice();
      return NativePointerModel.Create<AllegroVoice>(nativeVoice);
    }

    public static void SetDefaultVoice(AllegroVoice? voice)
    {
      NativeFunctions.AlSetDefaultVoice(NativePointerModel.GetPointer(voice));
    }

    public static bool AttachMixerToMixer(AllegroMixer? slaveMixer, AllegroMixer? masterMixer)
    {
      return NativeFunctions.AlAttachMixerToMixer(
        NativePointerModel.GetPointer(slaveMixer),
        NativePointerModel.GetPointer(masterMixer));
    }

    public static bool AttachSampleInstanceToMixer(AllegroSampleInstance? instance, AllegroMixer? mixer)
    {
      return NativeFunctions.AlAttachSampleInstanceToMixer(
        NativePointerModel.GetPointer(instance),
        NativePointerModel.GetPointer(mixer));
    }

    public static bool AttachAudioStreamToMixer(AllegroAudioStream? stream, AllegroMixer? mixer)
    {
      return NativeFunctions.AlAttachAudioStreamToMixer(
        NativePointerModel.GetPointer(stream),
        NativePointerModel.GetPointer(mixer));
    }

    public static uint GetMixerFrequency(AllegroMixer? mixer)
    {
      return NativeFunctions.AlGetMixerFrequency(NativePointerModel.GetPointer(mixer));
    }

    public static bool SetMixerFrequency(AllegroMixer? mixer, uint frequency)
    {
      return NativeFunctions.AlSetMixerFrequency(NativePointerModel.GetPointer(mixer), frequency);
    }

    public static ChannelConfig GetMixerChannels(AllegroMixer? mixer)
    {
      return (ChannelConfig)NativeFunctions.AlGetMixerChannels(NativePointerModel.GetPointer(mixer));
    }

    public static AudioDepth GetMixerDepth(AllegroMixer? mixer)
    {
      return (AudioDepth)NativeFunctions.AlGetMixerDepth(NativePointerModel.GetPointer(mixer));
    }

    public static float GetMixerGain(AllegroMixer? mixer)
    {
      return NativeFunctions.AlGetMixerGain(NativePointerModel.GetPointer(mixer));
    }

    public static bool SetMixerGain(AllegroMixer? mixer, float gain)
    {
      return NativeFunctions.AlSetMixerGain(NativePointerModel.GetPointer(mixer), gain);
    }

    public static MixerQuality GetMixerQuality(AllegroMixer? mixer)
    {
      return (MixerQuality)NativeFunctions.AlGetMixerQuality(NativePointerModel.GetPointer(mixer));
    }

    public static bool SetMixerQuality(AllegroMixer? mixer, MixerQuality quality)
    {
      return NativeFunctions.AlSetMixerQuality(NativePointerModel.GetPointer(mixer), (int)quality);
    }

    public static bool GetMixerPlaying(AllegroMixer? mixer)
    {
      return NativeFunctions.AlGetMixerPlaying(NativePointerModel.GetPointer(mixer));
    }

    public static bool SetMixerPlaying(AllegroMixer? mixer, bool playing)
    {
      return NativeFunctions.AlSetMixerPlaying(NativePointerModel.GetPointer(mixer), playing);
    }

    public static bool GetMixerAttached(AllegroMixer? mixer)
    {
      return NativeFunctions.AlGetMixerAttached(NativePointerModel.GetPointer(mixer));
    }

    public static bool DetachMixer(AllegroMixer? mixer)
    {
      return NativeFunctions.AlDetachMixer(NativePointerModel.GetPointer(mixer));
    }

    public static bool SetMixerPostprocessCallback(AllegroMixer? mixer, MixerPostprocessCallback callback, IntPtr callbackUserData)
    {
      return NativeFunctions.AlSetMixerPostprocessCallback(NativePointerModel.GetPointer(mixer), callback, callbackUserData);
    }

    public static AllegroAudioStream? CreateAudioStream(
      long fragments,
      uint samples,
      uint frequency,
      AudioDepth depth,
      ChannelConfig config)
    {
      var nativeStream = NativeFunctions.AlCreateAudioStream(fragments, samples, frequency, (int)depth, (int)config);
      return NativePointerModel.Create<AllegroAudioStream>(nativeStream);
    }

    public static void DestroyAudioStream(AllegroAudioStream? stream)
    {
      NativeFunctions.AlDestroyAudioStream(NativePointerModel.GetPointer(stream));
    }

    public static AllegroEventSource? GetAudioStreamEventSource(AllegroAudioStream? stream)
    {
      var nativeSource = NativeFunctions.AlGetAudioStreamEventSource(NativePointerModel.GetPointer(stream));
      return NativePointerModel.Create<AllegroEventSource>(nativeSource);
    }

    public static void DrainAudioStream(AllegroAudioStream? stream)
    {
      NativeFunctions.AlDrainAudioStream(NativePointerModel.GetPointer(stream));
    }

    public static bool RewindAudioStream(AllegroAudioStream? stream)
    {
      return NativeFunctions.AlRewindAudioStream(NativePointerModel.GetPointer(stream));
    }

    public static uint GetAudioStreamFrequency(AllegroAudioStream? stream)
    {
      return NativeFunctions.AlGetAudioStreamFrequency(NativePointerModel.GetPointer(stream));
    }

    public static ChannelConfig GetAudioStreamChannels(AllegroAudioStream? stream)
    {
      return (ChannelConfig)NativeFunctions.AlGetAudioStreamChannels(NativePointerModel.GetPointer(stream));
    }

    public static AudioDepth GetAudioStreamDepth(AllegroAudioStream? stream)
    {
      return (AudioDepth)NativeFunctions.AlGetAudioStreamDepth(NativePointerModel.GetPointer(stream));
    }

    public static uint GetAudioStreamLength(AllegroAudioStream? stream)
    {
      return NativeFunctions.AlGetAudioStreamLength(NativePointerModel.GetPointer(stream));
    }

    public static float GetAudioStreamSpeed(AllegroAudioStream? stream)
    {
      return NativeFunctions.AlGetAudioStreamSpeed(NativePointerModel.GetPointer(stream));
    }

    public static bool SetAudioStreamSpeed(AllegroAudioStream? stream, float speed)
    {
      return NativeFunctions.AlSetAudioStreamSpeed(NativePointerModel.GetPointer(stream), speed);
    }

    public static float GetAudioStreamGain(AllegroAudioStream? stream)
    {
      return NativeFunctions.AlGetAudioStreamGain(NativePointerModel.GetPointer(stream));
    }

    public static bool SetAudioStreamGain(AllegroAudioStream? stream, float gain)
    {
      return NativeFunctions.AlSetAudioStreamGain(NativePointerModel.GetPointer(stream), gain);
    }

    public static float GetAudioStreamPan(AllegroAudioStream? stream)
    {
      return NativeFunctions.AlGetAudioStreamPan(NativePointerModel.GetPointer(stream));
    }

    public static bool SetAudioStreamPan(AllegroAudioStream? stream, float pan)
    {
      return NativeFunctions.AlSetAudioStreamPan(NativePointerModel.GetPointer(stream), pan);
    }

    public static bool GetAudioStreamPlaying(AllegroAudioStream? stream)
    {
      return NativeFunctions.AlGetAudioStreamPlaying(NativePointerModel.GetPointer(stream));
    }

    public static bool SetAudioStreamPlaying(AllegroAudioStream? stream, bool playing)
    {
      return NativeFunctions.AlSetAudioStreamPlaying(NativePointerModel.GetPointer(stream), playing);
    }

    public static Playmode GetAudioStreamPlaymode(AllegroAudioStream? stream)
    {
      return (Playmode)NativeFunctions.AlGetAudioStreamPlaymode(NativePointerModel.GetPointer(stream));
    }

    public static bool SetAudioStreamPlaymode(AllegroAudioStream? stream, Playmode mode)
    {
      return NativeFunctions.AlSetAudioStreamPlaymode(NativePointerModel.GetPointer(stream), (int)mode);
    }

    public static bool GetAudioStreamAttached(AllegroAudioStream? stream)
    {
      return NativeFunctions.AlGetAudioStreamAttached(NativePointerModel.GetPointer(stream));
    }

    public static bool DetachAudioStream(AllegroAudioStream? stream)
    {
      return NativeFunctions.AlDetachAudioStream(NativePointerModel.GetPointer(stream));
    }

    public static ulong GetAudioStreamPlayedSamples(AllegroAudioStream? stream)
    {
      return NativeFunctions.AlGetAudioStreamPlayedSamples(NativePointerModel.GetPointer(stream));
    }

    public static IntPtr GetAudioStreamFragment(AllegroAudioStream? stream)
    {
      return NativeFunctions.AlGetAudioStreamFragment(NativePointerModel.GetPointer(stream));
    }

    public static bool SetAudioStreamFragment(AllegroAudioStream? stream, IntPtr fragment)
    {
      return NativeFunctions.AlSetAudioStreamFragment(NativePointerModel.GetPointer(stream), fragment);
    }

    public static uint GetAudioStreamFragments(AllegroAudioStream? stream)
    {
      return NativeFunctions.AlGetAudioStreamFragments(NativePointerModel.GetPointer(stream));
    }

    public static uint GetAvailableAudioStreamFragments(AllegroAudioStream? stream)
    {
      return NativeFunctions.AlGetAvailableAudioStreamFragments(NativePointerModel.GetPointer(stream));
    }

    public static bool SeekAudioStreamSecs(AllegroAudioStream? stream, double time)
    {
      return NativeFunctions.AlSeekAudioStreamSecs(NativePointerModel.GetPointer(stream), time);
    }

    public static double GetAudioStreamPositionSecs(AllegroAudioStream? stream)
    {
      return NativeFunctions.AlGetAudioStreamPositionSecs(NativePointerModel.GetPointer(stream));
    }

    public static double GetAudioStreamLengthSecs(AllegroAudioStream? stream)
    {
      return NativeFunctions.AlGetAudioStreamLengthSecs(NativePointerModel.GetPointer(stream));
    }

    public static bool SetAudioStreamLoopSecs(AllegroAudioStream? stream, double start, double end)
    {
      return NativeFunctions.AlSetAudioStreamLoopSecs(NativePointerModel.GetPointer(stream), start, end);
    }

    public static bool RegisterSampleLoader(string extension, RegisterSampleLoader loader)
    {
      var nativeExtension = Marshal.StringToHGlobalAnsi(extension);
      var result = NativeFunctions.AlRegisterSampleLoader(nativeExtension, loader);
      Marshal.FreeHGlobal(nativeExtension);
      return result;
    }

    public static bool RegisterSampleLoaderF(string extension, RegisterSampleLoaderF loader)
    {
      var nativeExtension = Marshal.StringToHGlobalAnsi(extension);
      var result = NativeFunctions.AlRegisterSampleLoaderF(nativeExtension, loader);
      Marshal.FreeHGlobal(nativeExtension);
      return result;
    }

    public static bool RegisterSampleSaver(string extension, RegisterSampleSaver saver)
    {
      var nativeExtension = Marshal.StringToHGlobalAnsi(extension);
      var result = NativeFunctions.AlRegisterSampleSaver(nativeExtension, saver);
      Marshal.FreeHGlobal(nativeExtension);
      return result;
    }

    public static bool RegisterSampleSaverF(string extension, RegisterSampleSaverF saver)
    {
      var nativeExtension = Marshal.StringToHGlobalAnsi(extension);
      var result = NativeFunctions.AlRegisterSampleSaverF(nativeExtension, saver);
      Marshal.FreeHGlobal(nativeExtension);
      return result;
    }

    public static bool RegisterAudioStreamLoader(string extension, RegisterAudioStreamLoader loader)
    {
      var nativeExtension = Marshal.StringToHGlobalAnsi(extension);
      var result = NativeFunctions.AlRegisterAudioStreamLoader(nativeExtension, loader);
      Marshal.FreeHGlobal(nativeExtension);
      return result;
    }

    public static bool RegisterAudioStreamLoaderF(string extension, RegisterAudioStreamLoaderF loader)
    {
      var nativeExtension = Marshal.StringToHGlobalAnsi(extension);
      var result = NativeFunctions.AlRegisterAudioStreamLoaderF(nativeExtension, loader);
      Marshal.FreeHGlobal(nativeExtension);
      return result;
    }

    public static AllegroSample? LoadSample(string filename)
    {
      var nativeFilename = Marshal.StringToHGlobalAnsi(filename);
      var result = NativeFunctions.AlLoadSample(nativeFilename);
      Marshal.FreeHGlobal(nativeFilename);
      return NativePointerModel.Create<AllegroSample>(result);
    }

    public static AllegroSample? LoadSampleF(AllegroFile? file, string identifier)
    {
      var nativeIdentifier = Marshal.StringToHGlobalAnsi(identifier);
      var result = NativeFunctions.AlLoadSampleF(NativePointerModel.GetPointer(file), nativeIdentifier);
      Marshal.FreeHGlobal(nativeIdentifier);
      return NativePointerModel.Create<AllegroSample>(result);
    }

    public static AllegroAudioStream? LoadAudioStream(string filename, long buffers, uint samples)
    {
      var nativeFilename = Marshal.StringToHGlobalAnsi(filename);
      var result = NativeFunctions.AlLoadAudioStream(nativeFilename, buffers, samples);
      Marshal.FreeHGlobal(nativeFilename);
      return NativePointerModel.Create<AllegroAudioStream>(result);
    }

    public static AllegroAudioStream? LoadAudioStreamF(AllegroFile? file, string identifier, long buffers, uint samples)
    {
      var nativeIdentifier = Marshal.StringToHGlobalAnsi(identifier);
      var result = NativeFunctions.AlLoadAudioStreamF(NativePointerModel.GetPointer(file), nativeIdentifier, buffers, samples);
      Marshal.FreeHGlobal(nativeIdentifier);
      return NativePointerModel.Create<AllegroAudioStream>(result);
    }

    public static bool SaveSample(string filename, AllegroSample? sample)
    {
      var nativeFilename = Marshal.StringToHGlobalAnsi(filename);
      var result = NativeFunctions.AlSaveSample(nativeFilename, NativePointerModel.GetPointer(sample));
      Marshal.FreeHGlobal(nativeFilename);
      return result;
    }

    public static bool SaveSampleF(AllegroFile? file, string identifier, AllegroSample? sample)
    {
      var nativeIdentifier = Marshal.StringToHGlobalAnsi(identifier);
      var result = NativeFunctions.AlSaveSampleF(
        NativePointerModel.GetPointer(file),
        nativeIdentifier,
        NativePointerModel.GetPointer(sample));
      Marshal.FreeHGlobal(nativeIdentifier);
      return result;
    }

    public static bool RegisterSampleIdentifier(string extension, RegisterSampleIdentifier identifier)
    {
      throw new NotImplementedException();
    }

    public static string IdentifySample(string filename)
    {
      throw new NotImplementedException();
    }

    public static string IdentifySampleF(AllegroFile file)
    {
      throw new NotImplementedException();
    }
  }
}
