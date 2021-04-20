using System;
using System.Runtime.InteropServices;
using AllegroDotNet.Enums;
using AllegroDotNet.Models;
using AllegroDotNet.Native;

namespace AllegroDotNet
{
    /// <summary>
    /// Allegro game library methods.
    /// </summary>
    public static partial class Al
    {
        public static bool InstallAudio()
            => al_install_audio();

        public static void UninstallAudio()
            => al_uninstall_audio();

        public static bool IsAudioInstalled()
            => al_is_audio_installed();

        public static bool ReserveSamples(int samples)
            => al_reserve_samples(samples);

        public static uint GetAllegroAudioVersion()
            => al_get_allegro_audio_version();

        public static ulong GetAudioDepthSize(AudioDepth depth)
            => (ulong)al_get_audio_depth_size((int)depth);

        public static ulong GetChannelCount(ChannelConf conf)
            => (ulong)al_get_channel_count((int)conf);

        public static void FillSilence(uint samples, AudioDepth depth, ChannelConf channelConf)
        {
            throw new NotImplementedException();
        }

        public static AllegroVoice CreateVoice(uint freq, AudioDepth depth, ChannelConf channelConf)
        {
            var nativeVoice = al_create_voice(freq, (int)depth, (int)channelConf);
            return nativeVoice == IntPtr.Zero ? null : new AllegroVoice { NativeIntPtr = nativeVoice };
        }

        public static void DestroyVoice(AllegroVoice voice)
            => al_destroy_voice(voice.NativeIntPtr);

        public static void DetachVoice(AllegroVoice voice)
           => al_detach_voice(voice.NativeIntPtr);

        public static bool AttachAudioStreamToVoice(AllegroAudioStream stream, AllegroVoice voice)
            => al_attach_audio_stream_to_voice(stream.NativeIntPtr, voice.NativeIntPtr);

        public static bool AttachMixerToVoice(AllegroMixer mixer, AllegroVoice voice)
            => al_attach_mixer_to_voice(mixer.NativeIntPtr, voice.NativeIntPtr);

        public static bool AttachSampleInstanceToVoice(AllegroSampleInstance instance, AllegroVoice voice)
            => al_attach_sample_instance_to_voice(instance.NativeIntPtr, voice.NativeIntPtr);

        public static uint GetVoiceFrequency(AllegroVoice voice)
            => al_get_voice_frequency(voice.NativeIntPtr);

        public static ChannelConf GetVoiceChannels(AllegroVoice voice)
            => (ChannelConf)al_get_voice_channels(voice.NativeIntPtr);

        public static AudioDepth GetVoiceDepth(AllegroVoice voice)
            => (AudioDepth)al_get_voice_depth(voice.NativeIntPtr);

        public static bool GetVoicePlaying(AllegroVoice voice)
            => al_get_voice_playing(voice.NativeIntPtr);

        public static bool SetVoicePlaying(AllegroVoice voice, bool val)
            => al_set_voice_playing(voice.NativeIntPtr, val);

        public static uint GetVoicePosition(AllegroVoice voice)
            => al_get_voice_position(voice.NativeIntPtr);

        public static bool SetVoicePosition(AllegroVoice voice, uint val)
            => al_set_voice_position(voice.NativeIntPtr, val);

        public static AllegroSample CreateSample(ref byte[] buf, uint samples, uint freq, AudioDepth depth, ChannelConf channelConf, bool freeBuf)
        {
            var nativeSample = al_create_sample(ref buf, samples, freq, (int)depth, (int)channelConf, freeBuf);
            return nativeSample == IntPtr.Zero ? null : new AllegroSample { NativeIntPtr = nativeSample };
        }

        public static void DestroySample(AllegroSample sample)
            => al_destroy_sample(sample.NativeIntPtr);

        public static bool PlaySample(AllegroSample sample, float gain, float pan, float speed, PlayMode loop, AllegroSampleId retId)
        {
            if (retId == null)
            {
                return al_play_sample(sample.NativeIntPtr, gain, pan, speed, (int)loop, IntPtr.Zero);
            }
            else
            {
                return al_play_sample(sample.NativeIntPtr, gain, pan, speed, (int)loop, ref retId.Native);
            }
        }

        public static void StopSample(AllegroSampleId sampleId)
            => al_stop_sample(ref sampleId.Native);

        public static void StopSamples()
            => al_stop_samples();

        public static ChannelConf GetSampleChannels(AllegroSample sample)
            => (ChannelConf)al_get_sample_channels(sample.NativeIntPtr);

        public static AudioDepth GetSampleDepth(AllegroSample sample)
            => (AudioDepth)al_get_sample_channels(sample.NativeIntPtr);

        public static uint GetSampleFrequency(AllegroSample sample)
            => al_get_sample_frequency(sample.NativeIntPtr);

        public static uint GetSampleLength(AllegroSample sample)
            => al_get_sample_length(sample.NativeIntPtr);

        public static byte[] GetSampleData(AllegroSample sample)
        {
            throw new NotImplementedException();
        }

        public static AllegroSampleInstance CreateSampleInstance(AllegroSample sampleData)
        {
            var nativeSampleInstance = al_create_sample_instance(sampleData.NativeIntPtr);
            return nativeSampleInstance == IntPtr.Zero ? null : new AllegroSampleInstance { NativeIntPtr = nativeSampleInstance };
        }

        public static void DestroySampleInstance(AllegroSampleInstance sampleInstance)
            => al_destroy_sample_instance(sampleInstance.NativeIntPtr);

        public static bool PlaySampleInstance(AllegroSampleInstance sampleInstance)
            => al_play_sample_instance(sampleInstance.NativeIntPtr);

        public static bool StopSampleInstance(AllegroSampleInstance sampleInstance)
            => al_stop_sample_instance(sampleInstance.NativeIntPtr);

        public static ChannelConf GetSampleInstanceChannels(AllegroSampleInstance sampleInstance)
            => (ChannelConf)al_get_sample_instance_channels(sampleInstance.NativeIntPtr);

        public static AudioDepth GetSampleInstanceDepth(AllegroSampleInstance sampleInstance)
            => (AudioDepth)al_get_sample_instance_depth(sampleInstance.NativeIntPtr);

        public static uint GetSampleInstanceFrequency(AllegroSampleInstance sampleInstance)
            => al_get_sample_instance_frequency(sampleInstance.NativeIntPtr);

        public static uint GetSampleInstanceLength(AllegroSampleInstance sampleInstance)
            => al_get_sample_instance_length(sampleInstance.NativeIntPtr);

        public static bool SetSampleInstanceLength(AllegroSampleInstance sampleInstance, uint val)
            => al_set_sample_instance_length(sampleInstance.NativeIntPtr, val);

        public static uint GetSampleInstancePosition(AllegroSampleInstance sampleInstance)
            => al_get_sample_instance_position(sampleInstance.NativeIntPtr);

        public static bool SetSampleInstancePosition(AllegroSampleInstance sampleInstance, uint val)
            => al_set_sample_instance_position(sampleInstance.NativeIntPtr, val);

        public static float GetSampleInstanceSpeed(AllegroSampleInstance sampleInstance)
            => al_get_sample_instance_speed(sampleInstance.NativeIntPtr);

        public static bool SetSampleInstanceSpeed(AllegroSampleInstance sampleInstance, float val)
            => al_set_sample_instance_speed(sampleInstance.NativeIntPtr, val);

        public static float GetSampleInstanceGain(AllegroSampleInstance sampleInstance)
            => al_get_sample_instance_gain(sampleInstance.NativeIntPtr);

        public static bool SetSampleInstanceGain(AllegroSampleInstance sampleInstance, float val)
            => al_set_sample_instance_gain(sampleInstance.NativeIntPtr, val);

        public static float GetSampleInstancePan(AllegroSampleInstance sampleInstance)
            => al_get_sample_instance_pan(sampleInstance.NativeIntPtr);

        public static bool SetSampleInstancePan(AllegroSampleInstance sampleInstance, float val)
            => al_set_sample_instance_pan(sampleInstance.NativeIntPtr, val);

        public static float GetSampleInstanceTime(AllegroSampleInstance sampleInstance)
            => al_get_sample_instance_time(sampleInstance.NativeIntPtr);

        public static PlayMode GetSampleInstancePlaymode(AllegroSampleInstance sampleInstance)
            => (PlayMode)al_get_sample_instance_playmode(sampleInstance.NativeIntPtr);

        public static bool SetSampleInstancePlayMode(AllegroSampleInstance sampleInstance, PlayMode val)
            => al_set_sample_instance_playmode(sampleInstance.NativeIntPtr, (int)val);

        public static bool GetSampleInstancePlaying(AllegroSampleInstance sampleInstance)
            => al_get_sample_instance_playing(sampleInstance.NativeIntPtr);

        public static bool SetSampleInstancePlaying(AllegroSampleInstance sampleInstance, bool val)
            => al_set_sample_instance_playing(sampleInstance.NativeIntPtr, val);

        public static bool GetSampleInstanceAttached(AllegroSampleInstance sampleInstance)
            => al_get_sample_instance_attached(sampleInstance.NativeIntPtr);

        public static bool DetachSampleInstance(AllegroSampleInstance sampleInstance)
            => al_detach_sample_instance(sampleInstance.NativeIntPtr);

        public static AllegroSample GetSample(AllegroSampleInstance sampleInstance)
        {
            var nativeSample = al_get_sample(sampleInstance.NativeIntPtr);
            return nativeSample == null ? null : new AllegroSample { NativeIntPtr = nativeSample };
        }

        public static bool SetSample(AllegroSampleInstance sampleInstance, AllegroSample sample)
            => al_set_sample(sampleInstance.NativeIntPtr, sample.NativeIntPtr);

        public static AllegroMixer CreateMixer(uint freq, AudioDepth depth, ChannelConf channelConf)
        {
            var nativeMixer = al_create_mixer(freq, (int)depth, (int)channelConf);
            return nativeMixer == null ? null : new AllegroMixer { NativeIntPtr = nativeMixer };
        }

        public static void DestroyMixer(AllegroMixer mixer)
            => al_destroy_mixer(mixer.NativeIntPtr);

        public static bool SetDefaultMixer(AllegroMixer mixer)
            => al_set_default_mixer(mixer.NativeIntPtr);

        public static bool RestoreDefaultMixer()
            => al_restore_default_mixer();

        public static AllegroVoice GetDefaultVoice()
        {
            var nativeVoice = al_get_default_voice();
            return nativeVoice == IntPtr.Zero ? null : new AllegroVoice { NativeIntPtr = nativeVoice };
        }

        public static void SetDefaultVoice(AllegroVoice voice)
            => al_set_default_voice(voice.NativeIntPtr);

        public static bool AttachMixerToMixer(AllegroMixer stream, AllegroMixer mixer)
            => al_attach_mixer_to_mixer(stream.NativeIntPtr, mixer.NativeIntPtr);

        public static bool AttachSampleInstanceToMixer(AllegroSampleInstance sampleInstance, AllegroMixer mixer)
            => al_attach_sample_instance_to_mixer(sampleInstance.NativeIntPtr, mixer.NativeIntPtr);

        public static bool AttachAudioStreamToMixer(AllegroAudioStream stream, AllegroMixer mixer)
            => al_attach_audio_stream_to_mixer(stream.NativeIntPtr, mixer.NativeIntPtr);

        public static uint GetMixerFrequency(AllegroMixer mixer)
            => al_get_mixer_frequency(mixer.NativeIntPtr);

        public static bool SetMixerFrequency(AllegroMixer mixer, uint val)
            => al_set_mixer_frequency(mixer.NativeIntPtr, val);

        public static ChannelConf GetMixerChannels(AllegroMixer mixer)
            => (ChannelConf)al_get_mixer_channels(mixer.NativeIntPtr);

        public static AudioDepth GetMixerDepth(AllegroMixer mixer)
            => (AudioDepth)al_get_mixer_depth(mixer.NativeIntPtr);

        public static float GetMixerGain(AllegroMixer mixer)
            => al_get_mixer_gain(mixer.NativeIntPtr);

        public static bool SetMixerGain(AllegroMixer mixer, float newGain)
            => al_set_mixer_gain(mixer.NativeIntPtr, newGain);

        public static MixerQuality GetMixerQuality(AllegroMixer mixer)
            => (MixerQuality)al_get_mixer_quality(mixer.NativeIntPtr);

        public static bool SetMixerQuality(AllegroMixer mixer, MixerQuality newQuality)
            => al_set_mixer_quality(mixer.NativeIntPtr, (int)newQuality);

        public static bool GetMixerPlaying(AllegroMixer mixer)
            => al_get_mixer_playing(mixer.NativeIntPtr);

        public static bool SetMixerPlaying(AllegroMixer mixer, bool val)
            => al_set_mixer_playing(mixer.NativeIntPtr, val);

        public static bool GetMixerAttached(AllegroMixer mixer)
            => al_get_mixer_attached(mixer.NativeIntPtr);

        public static bool DetachMixer(AllegroMixer mixer)
            => al_detach_mixer(mixer.NativeIntPtr);

        public static bool SetMixerPostProcessCallback(AllegroMixer mixer)
        {
            throw new NotImplementedException();
        }

        public static AllegroAudioStream CreateAudioStream(ulong fragCount, uint fragSamples, uint freq, AudioDepth depth, ChannelConf channelConf)
        {
            var nativeAudioStream = al_create_audio_stream(new UIntPtr(fragCount), fragSamples, freq, (int)depth, (int)channelConf);
            return nativeAudioStream == IntPtr.Zero ? null : new AllegroAudioStream { NativeIntPtr = nativeAudioStream };
        }

        public static void DestroyAudioStream(AllegroAudioStream stream)
            => al_destroy_audio_stream(stream.NativeIntPtr);

        public static AllegroEventSource GetAudioStreamEventSource(AllegroAudioStream stream)
        {
            var nativeEventSource = al_get_audio_stream_event_source(stream.NativeIntPtr);
            return nativeEventSource == IntPtr.Zero ? null : new AllegroEventSource { NativeIntPtr = nativeEventSource };
        }

        public static void DrainAudioStream(AllegroAudioStream stream)
            => al_drain_audio_stream(stream.NativeIntPtr);

        public static bool RewindAudioStream(AllegroAudioStream stream)
            => al_rewind_audio_stream(stream.NativeIntPtr);

        public static uint GetAudioStreamFrequency(AllegroAudioStream stream)
            => al_get_audio_stream_frequency(stream.NativeIntPtr);

        public static ChannelConf GetAudioStreamChannels(AllegroAudioStream stream)
            => (ChannelConf)al_get_audio_stream_channels(stream.NativeIntPtr);

        public static AudioDepth GetAudioStreamDepth(AllegroAudioStream stream)
            => (AudioDepth)al_get_audio_stream_depth(stream.NativeIntPtr);

        public static uint GetAudioStreamLength(AllegroAudioStream stream)
            => al_get_audio_stream_length(stream.NativeIntPtr);

        public static float GetAudioStreamSpeed(AllegroAudioStream stream)
            => al_get_audio_stream_speed(stream.NativeIntPtr);

        public static bool SetAudioStreamSpeed(AllegroAudioStream stream, float val)
            => al_set_audio_stream_speed(stream.NativeIntPtr, val);

        public static float GetAudioStreamGain(AllegroAudioStream stream)
            => al_get_audio_stream_gain(stream.NativeIntPtr);

        public static bool SetAudioStreamGain(AllegroAudioStream stream, float val)
            => al_set_audio_stream_gain(stream.NativeIntPtr, val);

        public static float GetAudioStreamPan(AllegroAudioStream stream)
            => al_get_audio_stream_pan(stream.NativeIntPtr);

        public static bool SetAudioStreamPan(AllegroAudioStream stream, float val)
            => al_set_audio_stream_pan(stream.NativeIntPtr, val);

        public static bool GetAudioStreamPlaying(AllegroAudioStream stream)
            => al_get_audio_stream_playing(stream.NativeIntPtr);

        public static bool SetAudioStreamPlaying(AllegroAudioStream stream, bool val)
            => al_set_audio_stream_playing(stream.NativeIntPtr, val);

        public static PlayMode GetAudioStreamPlaymode(AllegroAudioStream stream)
            => (PlayMode)al_get_audio_stream_playmode(stream.NativeIntPtr);

        public static bool SetAudioStreamPlaymode(AllegroAudioStream stream, PlayMode mode)
            => al_set_audio_stream_playmode(stream.NativeIntPtr, (int)mode);

        public static bool GetAudioStreamAttached(AllegroAudioStream stream)
            => al_get_audio_stream_attached(stream.NativeIntPtr);

        public static bool DetachAudioStream(AllegroAudioStream stream)
            => al_detach_audio_stream(stream.NativeIntPtr);

        public static ulong GetAudioStreamPlayedSamples(AllegroAudioStream stream)
            => al_get_audio_stream_played_samples(stream.NativeIntPtr);

        public static byte[] GetAudioStreamFragment(AllegroAudioStream stream)
        {
            throw new NotImplementedException();
        }

        public static bool SetAudioStreamFragment(AllegroAudioStream stream, byte[] val)
        {
            throw new NotImplementedException();
        }

        public static uint GetAudioStreamFragments(AllegroAudioStream stream)
            => al_get_audio_stream_fragments(stream.NativeIntPtr);

        public static uint GetAvailableAudioStreamFragments(AllegroAudioStream stream)
            => al_get_available_audio_stream_fragments(stream.NativeIntPtr);

        public static bool SeekAudioStreamSecs(AllegroAudioStream stream, double time)
            => al_seek_audio_stream_secs(stream.NativeIntPtr, time);

        public static double GetAudioStreamPositionSecs(AllegroAudioStream stream)
            => al_get_audio_stream_position_secs(stream.NativeIntPtr);

        public static double GetAudioStreamLengthSecs(AllegroAudioStream stream)
            => al_get_audio_stream_length_secs(stream.NativeIntPtr);

        public static bool SetAudioStreamLoopSecs(AllegroAudioStream stream, double start, double end)
            => al_set_audio_stream_loop_secs(stream.NativeIntPtr, start, end);

        public static bool RegisterSampleLoader(string ext, Action loader)
        {
            throw new NotImplementedException();
        }

        public static bool RegisterSampleLoaderF(string ext, Action loader)
        {
            throw new NotImplementedException();
        }

        public static bool RegisterSampleSaver(string ext, Action saver)
        {
            throw new NotImplementedException();
        }

        public static bool RegisterSampleSaverF(string ext, Action saver)
        {
            throw new NotImplementedException();
        }

        public static bool RegisterAudioStreamLoader(string ext, Action streamLoader, ulong bufferCount, uint samples)
        {
            throw new NotImplementedException();
        }

        public static bool RegisterAudioStreamLoaderF(string ext, Action streamLoader, ulong bufferCount, uint samples)
        {
            throw new NotImplementedException();
        }

        public static AllegroSample LoadSample(string filename)
        {
            var nativeSample = al_load_sample(filename);
            return nativeSample == IntPtr.Zero ? null : new AllegroSample { NativeIntPtr = nativeSample };
        }

        public static AllegroSample LoadSampleF(AllegroFile fp, string ident)
        {
            var nativeSample = al_load_sample_f(fp.NativeIntPtr, ident);
            return nativeSample == IntPtr.Zero ? null : new AllegroSample { NativeIntPtr = nativeSample };
        }

        public static AllegroAudioStream LoadAudioStream(string filename, ulong bufferCount, uint samples)
        {
            var nativeStream = al_load_audio_stream(filename, new UIntPtr(bufferCount), samples);
            return nativeStream == IntPtr.Zero ? null : new AllegroAudioStream { NativeIntPtr = nativeStream };
        }

        public static AllegroAudioStream LoadAudioStreamF(AllegroFile fp, string ident, ulong bufferCount, uint samples)
        {
            var nativeStream = al_load_audio_stream_f(fp.NativeIntPtr, ident, new UIntPtr(bufferCount), samples);
            return nativeStream == IntPtr.Zero ? null : new AllegroAudioStream { NativeIntPtr = nativeStream };
        }

        public static bool SaveSample(string filename, AllegroSample sample)
            => al_save_sample(filename, sample.NativeIntPtr);

        public static bool SaveSampleF(AllegroFile fp, string ident, AllegroSample sample)
            => al_save_sample_f(fp.NativeIntPtr, ident, sample.NativeIntPtr);

        #region P/Invokes
        [DllImport(Constants.AllegroMonolithDllFilename)]
        private static extern bool al_install_audio();

        [DllImport(Constants.AllegroMonolithDllFilename)]
        private static extern void al_uninstall_audio();

        [DllImport(Constants.AllegroMonolithDllFilename)]
        private static extern bool al_is_audio_installed();

        [DllImport(Constants.AllegroMonolithDllFilename)]
        private static extern bool al_reserve_samples(int reserve_samples);

        [DllImport(Constants.AllegroMonolithDllFilename)]
        private static extern uint al_get_allegro_audio_version();

        [DllImport(Constants.AllegroMonolithDllFilename)]
        private static extern UIntPtr al_get_audio_depth_size(int depth);

        [DllImport(Constants.AllegroMonolithDllFilename)]
        private static extern UIntPtr al_get_channel_count(int conf);

        [DllImport(Constants.AllegroMonolithDllFilename)]
        private static extern void al_fill_silence(IntPtr buf, uint samples, int depth, int chan_conf);

        [DllImport(Constants.AllegroMonolithDllFilename)]
        private static extern IntPtr al_create_voice(uint freq, int depth, int chan_conf);

        [DllImport(Constants.AllegroMonolithDllFilename)]
        private static extern void al_destroy_voice(IntPtr voice);

        [DllImport(Constants.AllegroMonolithDllFilename)]
        private static extern void al_detach_voice(IntPtr voice);

        [DllImport(Constants.AllegroMonolithDllFilename)]
        private static extern bool al_attach_audio_stream_to_voice(IntPtr stream, IntPtr voice);

        [DllImport(Constants.AllegroMonolithDllFilename)]
        private static extern bool al_attach_mixer_to_voice(IntPtr mixer, IntPtr voice);

        [DllImport(Constants.AllegroMonolithDllFilename)]
        private static extern bool al_attach_sample_instance_to_voice(IntPtr spl, IntPtr voice);

        [DllImport(Constants.AllegroMonolithDllFilename)]
        private static extern uint al_get_voice_frequency(IntPtr voice);

        [DllImport(Constants.AllegroMonolithDllFilename)]
        private static extern int al_get_voice_channels(IntPtr voice);

        [DllImport(Constants.AllegroMonolithDllFilename)]
        private static extern int al_get_voice_depth(IntPtr voice);

        [DllImport(Constants.AllegroMonolithDllFilename)]
        private static extern bool al_get_voice_playing(IntPtr voice);

        [DllImport(Constants.AllegroMonolithDllFilename)]
        private static extern bool al_set_voice_playing(IntPtr voice, bool val);

        [DllImport(Constants.AllegroMonolithDllFilename)]
        private static extern uint al_get_voice_position(IntPtr voice);

        [DllImport(Constants.AllegroMonolithDllFilename)]
        private static extern bool al_set_voice_position(IntPtr voice, uint val);

        [DllImport(Constants.AllegroMonolithDllFilename)]
        private static extern IntPtr al_create_sample(
            ref byte[] buf,
            uint samples,
            uint freq,
            int depth,
            int chan_conf,
            bool free_buf);

        [DllImport(Constants.AllegroMonolithDllFilename)]
        private static extern void al_destroy_sample(IntPtr spl);

        [DllImport(Constants.AllegroMonolithDllFilename)]
        private static extern bool al_play_sample(IntPtr spl, float gain, float pan, float speed, int loop, IntPtr ret_id);
        [DllImport(Constants.AllegroMonolithDllFilename)]
        private static extern bool al_play_sample(IntPtr spl, float gain, float pan, float speed, int loop, ref NativeSampleId ret_id);

        [DllImport(Constants.AllegroMonolithDllFilename)]
        private static extern void al_stop_sample(ref NativeSampleId spl_id);

        [DllImport(Constants.AllegroMonolithDllFilename)]
        private static extern void al_stop_samples();

        [DllImport(Constants.AllegroMonolithDllFilename)]
        private static extern int al_get_sample_channels(IntPtr spl);

        [DllImport(Constants.AllegroMonolithDllFilename)]
        private static extern int al_get_sample_depth(IntPtr spl);

        [DllImport(Constants.AllegroMonolithDllFilename)]
        private static extern uint al_get_sample_frequency(IntPtr spl);

        [DllImport(Constants.AllegroMonolithDllFilename)]
        private static extern uint al_get_sample_length(IntPtr spl);

        [DllImport(Constants.AllegroMonolithDllFilename)]
        private static extern IntPtr al_get_sample_data(IntPtr spl);

        [DllImport(Constants.AllegroMonolithDllFilename)]
        private static extern IntPtr al_create_sample_instance(IntPtr sample_data);

        [DllImport(Constants.AllegroMonolithDllFilename)]
        private static extern void al_destroy_sample_instance(IntPtr spl);

        [DllImport(Constants.AllegroMonolithDllFilename)]
        private static extern bool al_play_sample_instance(IntPtr spl);

        [DllImport(Constants.AllegroMonolithDllFilename)]
        private static extern bool al_stop_sample_instance(IntPtr spl);

        [DllImport(Constants.AllegroMonolithDllFilename)]
        private static extern int al_get_sample_instance_channels(IntPtr spl);

        [DllImport(Constants.AllegroMonolithDllFilename)]
        private static extern int al_get_sample_instance_depth(IntPtr spl);

        [DllImport(Constants.AllegroMonolithDllFilename)]
        private static extern uint al_get_sample_instance_frequency(IntPtr spl);

        [DllImport(Constants.AllegroMonolithDllFilename)]
        private static extern uint al_get_sample_instance_length(IntPtr spl);

        [DllImport(Constants.AllegroMonolithDllFilename)]
        private static extern bool al_set_sample_instance_length(IntPtr spl, uint val);

        [DllImport(Constants.AllegroMonolithDllFilename)]
        private static extern uint al_get_sample_instance_position(IntPtr spl);

        [DllImport(Constants.AllegroMonolithDllFilename)]
        private static extern bool al_set_sample_instance_position(IntPtr spl, uint val);

        [DllImport(Constants.AllegroMonolithDllFilename)]
        private static extern float al_get_sample_instance_speed(IntPtr spl);

        [DllImport(Constants.AllegroMonolithDllFilename)]
        private static extern bool al_set_sample_instance_speed(IntPtr spl, float val);

        [DllImport(Constants.AllegroMonolithDllFilename)]
        private static extern float al_get_sample_instance_gain(IntPtr spl);

        [DllImport(Constants.AllegroMonolithDllFilename)]
        private static extern bool al_set_sample_instance_gain(IntPtr spl, float val);

        [DllImport(Constants.AllegroMonolithDllFilename)]
        private static extern float al_get_sample_instance_pan(IntPtr spl);

        [DllImport(Constants.AllegroMonolithDllFilename)]
        private static extern bool al_set_sample_instance_pan(IntPtr spl, float val);

        [DllImport(Constants.AllegroMonolithDllFilename)]
        private static extern float al_get_sample_instance_time(IntPtr spl);

        [DllImport(Constants.AllegroMonolithDllFilename)]
        private static extern int al_get_sample_instance_playmode(IntPtr spl);

        [DllImport(Constants.AllegroMonolithDllFilename)]
        private static extern bool al_set_sample_instance_playmode(IntPtr spl, int val);

        [DllImport(Constants.AllegroMonolithDllFilename)]
        private static extern bool al_get_sample_instance_playing(IntPtr spl);

        [DllImport(Constants.AllegroMonolithDllFilename)]
        private static extern bool al_set_sample_instance_playing(IntPtr spl, bool val);

        [DllImport(Constants.AllegroMonolithDllFilename)]
        private static extern bool al_get_sample_instance_attached(IntPtr spl);

        [DllImport(Constants.AllegroMonolithDllFilename)]
        private static extern bool al_detach_sample_instance(IntPtr spl);

        [DllImport(Constants.AllegroMonolithDllFilename)]
        private static extern IntPtr al_get_sample(IntPtr spl);

        [DllImport(Constants.AllegroMonolithDllFilename)]
        private static extern bool al_set_sample(IntPtr spl, IntPtr data);

        [DllImport(Constants.AllegroMonolithDllFilename)]
        private static extern IntPtr al_create_mixer(uint freq, int depth, int chan_conf);

        [DllImport(Constants.AllegroMonolithDllFilename)]
        private static extern void al_destroy_mixer(IntPtr mixer);

        [DllImport(Constants.AllegroMonolithDllFilename)]
        private static extern IntPtr al_get_default_mixer();

        [DllImport(Constants.AllegroMonolithDllFilename)]
        private static extern bool al_set_default_mixer(IntPtr mixer);

        [DllImport(Constants.AllegroMonolithDllFilename)]
        private static extern bool al_restore_default_mixer();

        [DllImport(Constants.AllegroMonolithDllFilename)]
        private static extern IntPtr al_get_default_voice();

        [DllImport(Constants.AllegroMonolithDllFilename)]
        private static extern void al_set_default_voice(IntPtr voice);

        [DllImport(Constants.AllegroMonolithDllFilename)]
        private static extern bool al_attach_mixer_to_mixer(IntPtr stream, IntPtr mixer);

        [DllImport(Constants.AllegroMonolithDllFilename)]
        private static extern bool al_attach_sample_instance_to_mixer(IntPtr spl, IntPtr mixer);

        [DllImport(Constants.AllegroMonolithDllFilename)]
        private static extern bool al_attach_audio_stream_to_mixer(IntPtr stream, IntPtr mixer);

        [DllImport(Constants.AllegroMonolithDllFilename)]
        private static extern uint al_get_mixer_frequency(IntPtr mixer);

        [DllImport(Constants.AllegroMonolithDllFilename)]
        private static extern bool al_set_mixer_frequency(IntPtr mixer, uint val);

        [DllImport(Constants.AllegroMonolithDllFilename)]
        private static extern int al_get_mixer_channels(IntPtr mixer);

        [DllImport(Constants.AllegroMonolithDllFilename)]
        private static extern int al_get_mixer_depth(IntPtr mixer);

        [DllImport(Constants.AllegroMonolithDllFilename)]
        private static extern float al_get_mixer_gain(IntPtr mixer);

        [DllImport(Constants.AllegroMonolithDllFilename)]
        private static extern bool al_set_mixer_gain(IntPtr mixer, float new_gain);

        [DllImport(Constants.AllegroMonolithDllFilename)]
        private static extern int al_get_mixer_quality(IntPtr mixer);

        [DllImport(Constants.AllegroMonolithDllFilename)]
        private static extern bool al_set_mixer_quality(IntPtr mixer, int new_quality);

        [DllImport(Constants.AllegroMonolithDllFilename)]
        private static extern bool al_get_mixer_playing(IntPtr mixer);

        [DllImport(Constants.AllegroMonolithDllFilename)]
        private static extern bool al_set_mixer_playing(IntPtr mixer, bool val);

        [DllImport(Constants.AllegroMonolithDllFilename)]
        private static extern bool al_get_mixer_attached(IntPtr mixer);

        [DllImport(Constants.AllegroMonolithDllFilename)]
        private static extern bool al_detach_mixer(IntPtr mixer);

        [DllImport(Constants.AllegroMonolithDllFilename)]
        private static extern bool al_set_mixer_postprocess_callback(IntPtr mixer, IntPtr pp_callback, IntPtr pp_callback_userdata);

        [DllImport(Constants.AllegroMonolithDllFilename)]
        private static extern IntPtr al_create_audio_stream(UIntPtr fragment_count, uint frag_samples, uint freq, int depth, int chan_conf);

        [DllImport(Constants.AllegroMonolithDllFilename)]
        private static extern void al_destroy_audio_stream(IntPtr stream);

        [DllImport(Constants.AllegroMonolithDllFilename)]
        private static extern IntPtr al_get_audio_stream_event_source(IntPtr stream);

        [DllImport(Constants.AllegroMonolithDllFilename)]
        private static extern void al_drain_audio_stream(IntPtr stream);

        [DllImport(Constants.AllegroMonolithDllFilename)]
        private static extern bool al_rewind_audio_stream(IntPtr stream);

        [DllImport(Constants.AllegroMonolithDllFilename)]
        private static extern uint al_get_audio_stream_frequency(IntPtr stream);

        [DllImport(Constants.AllegroMonolithDllFilename)]
        private static extern int al_get_audio_stream_channels(IntPtr stream);

        [DllImport(Constants.AllegroMonolithDllFilename)]
        private static extern int al_get_audio_stream_depth(IntPtr stream);

        [DllImport(Constants.AllegroMonolithDllFilename)]
        private static extern uint al_get_audio_stream_length(IntPtr stream);

        [DllImport(Constants.AllegroMonolithDllFilename)]
        private static extern float al_get_audio_stream_speed(IntPtr stream);

        [DllImport(Constants.AllegroMonolithDllFilename)]
        private static extern bool al_set_audio_stream_speed(IntPtr stream, float val);

        [DllImport(Constants.AllegroMonolithDllFilename)]
        private static extern float al_get_audio_stream_gain(IntPtr stream);

        [DllImport(Constants.AllegroMonolithDllFilename)]
        private static extern bool al_set_audio_stream_gain(IntPtr stream, float val);

        [DllImport(Constants.AllegroMonolithDllFilename)]
        private static extern float al_get_audio_stream_pan(IntPtr stream);

        [DllImport(Constants.AllegroMonolithDllFilename)]
        private static extern bool al_set_audio_stream_pan(IntPtr stream, float val);

        [DllImport(Constants.AllegroMonolithDllFilename)]
        private static extern bool al_get_audio_stream_playing(IntPtr stream);

        [DllImport(Constants.AllegroMonolithDllFilename)]
        private static extern bool al_set_audio_stream_playing(IntPtr stream, bool val);

        [DllImport(Constants.AllegroMonolithDllFilename)]
        private static extern int al_get_audio_stream_playmode(IntPtr stream);

        [DllImport(Constants.AllegroMonolithDllFilename)]
        private static extern bool al_set_audio_stream_playmode(IntPtr stream, int val);

        [DllImport(Constants.AllegroMonolithDllFilename)]
        private static extern bool al_get_audio_stream_attached(IntPtr stream);

        [DllImport(Constants.AllegroMonolithDllFilename)]
        private static extern bool al_detach_audio_stream(IntPtr stream);

        [DllImport(Constants.AllegroMonolithDllFilename)]
        private static extern ulong al_get_audio_stream_played_samples(IntPtr stream);

        [DllImport(Constants.AllegroMonolithDllFilename)]
        private static extern IntPtr al_get_audio_stream_fragment(IntPtr stream);

        [DllImport(Constants.AllegroMonolithDllFilename)]
        private static extern bool al_set_audio_stream_fragment(IntPtr stream, IntPtr val);

        [DllImport(Constants.AllegroMonolithDllFilename)]
        private static extern uint al_get_audio_stream_fragments(IntPtr stream);

        [DllImport(Constants.AllegroMonolithDllFilename)]
        private static extern uint al_get_available_audio_stream_fragments(IntPtr stream);

        [DllImport(Constants.AllegroMonolithDllFilename)]
        private static extern bool al_seek_audio_stream_secs(IntPtr stream, double time);

        [DllImport(Constants.AllegroMonolithDllFilename)]
        private static extern double al_get_audio_stream_position_secs(IntPtr stream);

        [DllImport(Constants.AllegroMonolithDllFilename)]
        private static extern double al_get_audio_stream_length_secs(IntPtr stream);

        [DllImport(Constants.AllegroMonolithDllFilename)]
        private static extern bool al_set_audio_stream_loop_secs(IntPtr stream, double start, double end);

        [DllImport(Constants.AllegroMonolithDllFilename)]
        private static extern bool al_register_sample_loader(
            [MarshalAs(UnmanagedType.LPStr)] string ext,
            IntPtr loader);

        [DllImport(Constants.AllegroMonolithDllFilename)]
        private static extern bool al_register_sample_loader_f(
            [MarshalAs(UnmanagedType.LPStr)] string ext,
            IntPtr loader);

        [DllImport(Constants.AllegroMonolithDllFilename)]
        private static extern bool al_register_sample_saver(
            [MarshalAs(UnmanagedType.LPStr)] string ext,
            IntPtr saver);

        [DllImport(Constants.AllegroMonolithDllFilename)]
        private static extern bool al_register_sample_saver_f(
            [MarshalAs(UnmanagedType.LPStr)] string ext,
            IntPtr saver);

        [DllImport(Constants.AllegroMonolithDllFilename)]
        private static extern bool al_register_audio_stream_loader(
            [MarshalAs(UnmanagedType.LPStr)] string ext,
            IntPtr stream_loader);

        [DllImport(Constants.AllegroMonolithDllFilename)]
        private static extern bool al_register_audio_stream_loader_f(
            [MarshalAs(UnmanagedType.LPStr)] string ext,
            IntPtr stream_loader);

        [DllImport(Constants.AllegroMonolithDllFilename)]
        private static extern IntPtr al_load_sample([MarshalAs(UnmanagedType.LPStr)] string filename);

        [DllImport(Constants.AllegroMonolithDllFilename)]
        private static extern IntPtr al_load_sample_f(IntPtr fp, [MarshalAs(UnmanagedType.LPStr)] string ident);

        [DllImport(Constants.AllegroMonolithDllFilename)]
        private static extern IntPtr al_load_audio_stream(
            [MarshalAs(UnmanagedType.LPStr)] string filename,
            UIntPtr buffer_count,
            uint samples);

        [DllImport(Constants.AllegroMonolithDllFilename)]
        private static extern IntPtr al_load_audio_stream_f(
            IntPtr fp,
            [MarshalAs(UnmanagedType.LPStr)] string ident,
            UIntPtr buffer_count,
            uint samples);

        [DllImport(Constants.AllegroMonolithDllFilename)]
        private static extern bool al_save_sample([MarshalAs(UnmanagedType.LPStr)] string filename, IntPtr spl);

        [DllImport(Constants.AllegroMonolithDllFilename)]
        private static extern bool al_save_sample_f(
            IntPtr fp,
            [MarshalAs(UnmanagedType.LPStr)] string ident,
            IntPtr spl);
        #endregion
    }
}
