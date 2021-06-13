using System;
using System.Runtime.InteropServices;
using SubC.AllegroDotNet.Enums;
using SubC.AllegroDotNet.Models;
using SubC.AllegroDotNet.Native;

namespace SubC.AllegroDotNet
{
    /// <summary>
    /// Allegro game library methods.
    /// </summary>
    public static partial class Al
    {
        /// <summary>
        /// Install the audio subsystem.
        /// <para>
        /// Note: most users will call <see cref="ReserveSamples(int)"/> and <see cref="InitACodecAddon"/> after this.
        /// </para>
        /// </summary>
        /// <returns>True on success, false on failure.</returns>
        public static bool InstallAudio()
            => al_install_audio();

        /// <summary>
        /// Uninstalls the audio subsystem.
        /// </summary>
        public static void UninstallAudio()
            => al_uninstall_audio();

        /// <summary>
        /// Returns true if <see cref="InstallAudio"/> was called previously and returned successfully.
        /// </summary>
        /// <returns>True if audio is already installed, otherwise false.</returns>
        public static bool IsAudioInstalled()
            => al_is_audio_installed();

        /// <summary>
        /// Reserves a number of sample instances, attaching them to the default mixer. If no default mixer is set
        /// when this function is called, then it will create one and attach it to the default voice. If no default
        /// voice has been set, it, too, will be created.
        /// <para>
        /// If you call this function a second time with a smaller number of samples, then the excess internal sample
        /// instances will be destroyed causing some sounds to stop.
        /// </para>
        /// </summary>
        /// <param name="samples">The amount of sample instances to reserve.</param>
        /// <returns>True on success, false on error. <see cref="InstallAudio"/> must have been called first.</returns>
        public static bool ReserveSamples(int samples)
            => al_reserve_samples(samples);

        /// <summary>
        /// Returns the (compiled) version of the addon, in the same format as <see cref="GetAllegroVersion"/>.
        /// </summary>
        /// <returns>The (compiled) version of the audio addon.</returns>
        public static uint GetAllegroAudioVersion()
            => al_get_allegro_audio_version();

        /// <summary>
        /// Return the size of a sample, in bytes, for the given format. The format is one of the values listed under
        /// <see cref="AudioDepth"/>.
        /// </summary>
        /// <param name="depth">The audio format.</param>
        /// <returns>The amount of bytes for a sample in the given format.</returns>
        public static ulong GetAudioDepthSize(AudioDepth depth)
            => (ulong)al_get_audio_depth_size((int)depth);

        /// <summary>
        /// Return the number of channels for the given channel configuration, which is one of the values listed under
        /// <see cref="ChannelConf"/>.
        /// </summary>
        /// <param name="conf">The channel configuration.</param>
        /// <returns>The number of channels for the given channel configuration.</returns>
        public static ulong GetChannelCount(ChannelConf conf)
            => (ulong)al_get_channel_count((int)conf);

        /// <summary>
        /// Fill a buffer with silence, for the given format and channel configuration. The buffer must have enough
        /// space for the given number of samples, and be properly aligned.
        /// </summary>
        /// <param name="samples">Amount of samples.</param>
        /// <param name="depth">The audio format.</param>
        /// <param name="channelConf">The channel configuration.</param>
        public static void FillSilence(uint samples, AudioDepth depth, ChannelConf channelConf)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Creates a voice structure and allocates a voice from the digital sound driver. The passed frequency
        /// (in Hz), sample format and channel configuration are used as a hint to what kind of data will be sent
        /// to the voice. However, the underlying sound driver is free to use non-matching values. For example,
        /// it may be the native format of the sound hardware.
        /// <para>
        /// If a mixer is attached to the voice, the mixer will handle the conversion of all its input streams
        /// to the voice format and care does not have to be taken for this. However if you access the voice
        /// directly, make sure to not rely on the parameters passed to this function, but instead query the
        /// returned voice for the actual settings.
        /// </para>
        /// </summary>
        /// <param name="freq">The frequency in Hz.</param>
        /// <param name="depth">The audio format.</param>
        /// <param name="channelConf">The channel configuration.</param>
        /// <returns>The voice from the digital sound driver on success, otherwise <c>null</c>.</returns>
        public static AllegroVoice CreateVoice(uint freq, AudioDepth depth, ChannelConf channelConf)
        {
            var nativeVoice = al_create_voice(freq, (int)depth, (int)channelConf);
            return nativeVoice == IntPtr.Zero ? null : new AllegroVoice { NativeIntPtr = nativeVoice };
        }

        /// <summary>
        /// Destroys the voice and deallocates it from the digital driver. Does nothing if the voice is <c>null</c>.
        /// </summary>
        /// <param name="voice">The voice instance.</param>
        public static void DestroyVoice(AllegroVoice voice)
        {
            var nativeVoice = voice == null ? IntPtr.Zero : voice.NativeIntPtr;
            al_destroy_voice(nativeVoice);
        }

        /// <summary>
        /// Detaches the mixer, sample instance or audio stream from the voice.
        /// </summary>
        /// <param name="voice">The voice instance.</param>
        public static void DetachVoice(AllegroVoice voice)
           => al_detach_voice(voice.NativeIntPtr);

        /// <summary>
        /// Attaches an audio stream to a voice. The same rules as
        /// <see cref="AttachSampleInstanceToVoice(AllegroSampleInstance, AllegroVoice)"/> apply. This may fail if
        /// the driver can’t create a voice with the buffer count and buffer size the stream uses.
        /// <para>
        /// An audio stream attached directly to a voice has a number of limitations: The audio stream plays
        /// immediately and cannot be stopped. The stream position, speed, gain and panning cannot be changed. At this
        /// time, we don’t recommend attaching audio streams directly to voices. Use a mixer inbetween.
        /// </para>
        /// </summary>
        /// <param name="stream">The stream instance.</param>
        /// <param name="voice">The voice instance.</param>
        /// <returns>True on success, false on failure.</returns>
        public static bool AttachAudioStreamToVoice(AllegroAudioStream stream, AllegroVoice voice)
            => al_attach_audio_stream_to_voice(stream.NativeIntPtr, voice.NativeIntPtr);

        /// <summary>
        /// Attaches a mixer to a voice. It must have the same frequency and channel configuration, but the depth may
        /// be different.
        /// </summary>
        /// <param name="mixer">The mixer instance.</param>
        /// <param name="voice">The voice instance.</param>
        /// <returns>True on success, false on failure.</returns>
        public static bool AttachMixerToVoice(AllegroMixer mixer, AllegroVoice voice)
            => al_attach_mixer_to_voice(mixer.NativeIntPtr, voice.NativeIntPtr);

        /// <summary>
        /// Attaches a sample instance to a voice, and allows it to play. The instance’s gain and loop mode will be
        /// ignored, and it must have the same frequency, channel configuration and depth (including signed-ness) as
        /// the voice. This function may fail if the selected driver doesn’t support preloading sample data.
        /// <para>
        /// At this time, we don’t recommend attaching sample instances directly to voices. Use a mixer inbetween.
        /// </para>
        /// </summary>
        /// <param name="sample">The sample instance.</param>
        /// <param name="voice">The voice instance.</param>
        /// <returns>True on success, false on failure.</returns>
        public static bool AttachSampleInstanceToVoice(AllegroSampleInstance sample, AllegroVoice voice)
            => al_attach_sample_instance_to_voice(sample.NativeIntPtr, voice.NativeIntPtr);

        /// <summary>
        /// Return the frequency of the voice (in Hz), e.g. 44100.
        /// </summary>
        /// <param name="voice">The voice instance.</param>
        /// <returns>The frequency of the voice.</returns>
        public static uint GetVoiceFrequency(AllegroVoice voice)
            => al_get_voice_frequency(voice.NativeIntPtr);

        /// <summary>
        /// Return the channel configuration of the voice.
        /// </summary>
        /// <param name="voice">The voice instance.</param>
        /// <returns>The channel configuration of the voice.</returns>
        public static ChannelConf GetVoiceChannels(AllegroVoice voice)
            => (ChannelConf)al_get_voice_channels(voice.NativeIntPtr);

        /// <summary>
        /// Return the audio depth of the voice.
        /// </summary>
        /// <param name="voice">The voice instance.</param>
        /// <returns>Audio depth of the voice.</returns>
        public static AudioDepth GetVoiceDepth(AllegroVoice voice)
            => (AudioDepth)al_get_voice_depth(voice.NativeIntPtr);

        /// <summary>
        /// Return true if the voice is currently playing.
        /// </summary>
        /// <param name="voice">The voice instance.</param>
        /// <returns>True if the voice is playing, otherwise false.</returns>
        public static bool GetVoicePlaying(AllegroVoice voice)
            => al_get_voice_playing(voice.NativeIntPtr);

        /// <summary>
        /// Change whether a voice is playing or not. This can only work if the voice has a non-streaming object
        /// attached to it, e.g. a sample instance. On success the voice’s current sample position is reset.
        /// </summary>
        /// <param name="voice">The voice instance.</param>
        /// <param name="val">The value to set the playing status to.</param>
        /// <returns>True on success, false on failure.</returns>
        public static bool SetVoicePlaying(AllegroVoice voice, bool val)
            => al_set_voice_playing(voice.NativeIntPtr, val);

        /// <summary>
        /// When the voice has a non-streaming object attached to it, e.g. a sample, returns the voice’s current sample
        /// position. Otherwise, returns zero.
        /// </summary>
        /// <param name="voice">The voice instance.</param>
        /// <returns>Returns the voice’s current sample position. Otherwise, returns zero.</returns>
        public static uint GetVoicePosition(AllegroVoice voice)
            => al_get_voice_position(voice.NativeIntPtr);

        /// <summary>
        /// Set the voice position. This can only work if the voice has a non-streaming object attached to it, e.g.
        /// a sample instance.
        /// </summary>
        /// <param name="voice">The voice instance.</param>
        /// <param name="val">The value to set the position to.</param>
        /// <returns>True on success, otherwise false.</returns>
        public static bool SetVoicePosition(AllegroVoice voice, uint val)
            => al_set_voice_position(voice.NativeIntPtr, val);

        /// <summary>
        /// Create a sample data structure from the supplied buffer. If <c>freeBuf</c> is true then the buffer will
        /// be freed with al_free when the sample data structure is destroyed. For portability (especially Windows),
        /// the buffer should have been allocated with al_malloc. Otherwise you should free the sample data yourself.
        /// </summary>
        /// <param name="buf">Buffer.</param>
        /// <param name="samples">Amount of samples.</param>
        /// <param name="freq">Frequency of sample.</param>
        /// <param name="depth">Size of sample.</param>
        /// <param name="channelConf">Channel configuration.</param>
        /// <param name="freeBuf">If the buffer should be freed when sample is destroyed.</param>
        /// <returns>Sample instance on success, otherwise null.</returns>
        public static AllegroSample CreateSample(ref byte[] buf, uint samples, uint freq, AudioDepth depth, ChannelConf channelConf, bool freeBuf)
        {
            var nativeSample = al_create_sample(ref buf, samples, freq, (int)depth, (int)channelConf, freeBuf);
            return nativeSample == IntPtr.Zero ? null : new AllegroSample { NativeIntPtr = nativeSample };
        }

        /// <summary>
        /// Free the sample data structure. If it was created with the <c>buf</c> parameter set to <c>true</c>, then
        /// the buffer will be freed with <see cref="Free(IntPtr, int, string, string)"/>.
        /// <para>
        /// This function will stop any sample instances which may be playing the buffer referenced by the
        /// <see cref="AllegroSample"/>.
        /// </para>
        /// </summary>
        /// <param name="sample">The sample instance to destroy.</param>
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
        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern bool al_install_audio();

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern void al_uninstall_audio();

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern bool al_is_audio_installed();

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern bool al_reserve_samples(int reserve_samples);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern uint al_get_allegro_audio_version();

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern UIntPtr al_get_audio_depth_size(int depth);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern UIntPtr al_get_channel_count(int conf);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern void al_fill_silence(IntPtr buf, uint samples, int depth, int chan_conf);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern IntPtr al_create_voice(uint freq, int depth, int chan_conf);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern void al_destroy_voice(IntPtr voice);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern void al_detach_voice(IntPtr voice);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern bool al_attach_audio_stream_to_voice(IntPtr stream, IntPtr voice);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern bool al_attach_mixer_to_voice(IntPtr mixer, IntPtr voice);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern bool al_attach_sample_instance_to_voice(IntPtr spl, IntPtr voice);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern uint al_get_voice_frequency(IntPtr voice);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern int al_get_voice_channels(IntPtr voice);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern int al_get_voice_depth(IntPtr voice);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern bool al_get_voice_playing(IntPtr voice);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern bool al_set_voice_playing(IntPtr voice, bool val);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern uint al_get_voice_position(IntPtr voice);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern bool al_set_voice_position(IntPtr voice, uint val);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern IntPtr al_create_sample(
            ref byte[] buf,
            uint samples,
            uint freq,
            int depth,
            int chan_conf,
            bool free_buf);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern void al_destroy_sample(IntPtr spl);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern bool al_play_sample(IntPtr spl, float gain, float pan, float speed, int loop, IntPtr ret_id);
        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern bool al_play_sample(IntPtr spl, float gain, float pan, float speed, int loop, ref NativeSampleId ret_id);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern void al_stop_sample(ref NativeSampleId spl_id);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern void al_stop_samples();

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern int al_get_sample_channels(IntPtr spl);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern int al_get_sample_depth(IntPtr spl);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern uint al_get_sample_frequency(IntPtr spl);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern uint al_get_sample_length(IntPtr spl);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern IntPtr al_get_sample_data(IntPtr spl);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern IntPtr al_create_sample_instance(IntPtr sample_data);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern void al_destroy_sample_instance(IntPtr spl);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern bool al_play_sample_instance(IntPtr spl);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern bool al_stop_sample_instance(IntPtr spl);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern int al_get_sample_instance_channels(IntPtr spl);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern int al_get_sample_instance_depth(IntPtr spl);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern uint al_get_sample_instance_frequency(IntPtr spl);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern uint al_get_sample_instance_length(IntPtr spl);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern bool al_set_sample_instance_length(IntPtr spl, uint val);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern uint al_get_sample_instance_position(IntPtr spl);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern bool al_set_sample_instance_position(IntPtr spl, uint val);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern float al_get_sample_instance_speed(IntPtr spl);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern bool al_set_sample_instance_speed(IntPtr spl, float val);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern float al_get_sample_instance_gain(IntPtr spl);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern bool al_set_sample_instance_gain(IntPtr spl, float val);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern float al_get_sample_instance_pan(IntPtr spl);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern bool al_set_sample_instance_pan(IntPtr spl, float val);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern float al_get_sample_instance_time(IntPtr spl);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern int al_get_sample_instance_playmode(IntPtr spl);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern bool al_set_sample_instance_playmode(IntPtr spl, int val);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern bool al_get_sample_instance_playing(IntPtr spl);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern bool al_set_sample_instance_playing(IntPtr spl, bool val);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern bool al_get_sample_instance_attached(IntPtr spl);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern bool al_detach_sample_instance(IntPtr spl);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern IntPtr al_get_sample(IntPtr spl);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern bool al_set_sample(IntPtr spl, IntPtr data);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern IntPtr al_create_mixer(uint freq, int depth, int chan_conf);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern void al_destroy_mixer(IntPtr mixer);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern IntPtr al_get_default_mixer();

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern bool al_set_default_mixer(IntPtr mixer);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern bool al_restore_default_mixer();

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern IntPtr al_get_default_voice();

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern void al_set_default_voice(IntPtr voice);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern bool al_attach_mixer_to_mixer(IntPtr stream, IntPtr mixer);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern bool al_attach_sample_instance_to_mixer(IntPtr spl, IntPtr mixer);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern bool al_attach_audio_stream_to_mixer(IntPtr stream, IntPtr mixer);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern uint al_get_mixer_frequency(IntPtr mixer);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern bool al_set_mixer_frequency(IntPtr mixer, uint val);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern int al_get_mixer_channels(IntPtr mixer);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern int al_get_mixer_depth(IntPtr mixer);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern float al_get_mixer_gain(IntPtr mixer);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern bool al_set_mixer_gain(IntPtr mixer, float new_gain);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern int al_get_mixer_quality(IntPtr mixer);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern bool al_set_mixer_quality(IntPtr mixer, int new_quality);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern bool al_get_mixer_playing(IntPtr mixer);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern bool al_set_mixer_playing(IntPtr mixer, bool val);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern bool al_get_mixer_attached(IntPtr mixer);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern bool al_detach_mixer(IntPtr mixer);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern bool al_set_mixer_postprocess_callback(IntPtr mixer, IntPtr pp_callback, IntPtr pp_callback_userdata);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern IntPtr al_create_audio_stream(UIntPtr fragment_count, uint frag_samples, uint freq, int depth, int chan_conf);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern void al_destroy_audio_stream(IntPtr stream);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern IntPtr al_get_audio_stream_event_source(IntPtr stream);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern void al_drain_audio_stream(IntPtr stream);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern bool al_rewind_audio_stream(IntPtr stream);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern uint al_get_audio_stream_frequency(IntPtr stream);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern int al_get_audio_stream_channels(IntPtr stream);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern int al_get_audio_stream_depth(IntPtr stream);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern uint al_get_audio_stream_length(IntPtr stream);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern float al_get_audio_stream_speed(IntPtr stream);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern bool al_set_audio_stream_speed(IntPtr stream, float val);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern float al_get_audio_stream_gain(IntPtr stream);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern bool al_set_audio_stream_gain(IntPtr stream, float val);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern float al_get_audio_stream_pan(IntPtr stream);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern bool al_set_audio_stream_pan(IntPtr stream, float val);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern bool al_get_audio_stream_playing(IntPtr stream);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern bool al_set_audio_stream_playing(IntPtr stream, bool val);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern int al_get_audio_stream_playmode(IntPtr stream);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern bool al_set_audio_stream_playmode(IntPtr stream, int val);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern bool al_get_audio_stream_attached(IntPtr stream);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern bool al_detach_audio_stream(IntPtr stream);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern ulong al_get_audio_stream_played_samples(IntPtr stream);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern IntPtr al_get_audio_stream_fragment(IntPtr stream);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern bool al_set_audio_stream_fragment(IntPtr stream, IntPtr val);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern uint al_get_audio_stream_fragments(IntPtr stream);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern uint al_get_available_audio_stream_fragments(IntPtr stream);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern bool al_seek_audio_stream_secs(IntPtr stream, double time);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern double al_get_audio_stream_position_secs(IntPtr stream);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern double al_get_audio_stream_length_secs(IntPtr stream);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern bool al_set_audio_stream_loop_secs(IntPtr stream, double start, double end);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern bool al_register_sample_loader(
            [MarshalAs(UnmanagedType.LPStr)] string ext,
            IntPtr loader);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern bool al_register_sample_loader_f(
            [MarshalAs(UnmanagedType.LPStr)] string ext,
            IntPtr loader);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern bool al_register_sample_saver(
            [MarshalAs(UnmanagedType.LPStr)] string ext,
            IntPtr saver);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern bool al_register_sample_saver_f(
            [MarshalAs(UnmanagedType.LPStr)] string ext,
            IntPtr saver);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern bool al_register_audio_stream_loader(
            [MarshalAs(UnmanagedType.LPStr)] string ext,
            IntPtr stream_loader);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern bool al_register_audio_stream_loader_f(
            [MarshalAs(UnmanagedType.LPStr)] string ext,
            IntPtr stream_loader);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern IntPtr al_load_sample([MarshalAs(UnmanagedType.LPStr)] string filename);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern IntPtr al_load_sample_f(IntPtr fp, [MarshalAs(UnmanagedType.LPStr)] string ident);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern IntPtr al_load_audio_stream(
            [MarshalAs(UnmanagedType.LPStr)] string filename,
            UIntPtr buffer_count,
            uint samples);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern IntPtr al_load_audio_stream_f(
            IntPtr fp,
            [MarshalAs(UnmanagedType.LPStr)] string ident,
            UIntPtr buffer_count,
            uint samples);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern bool al_save_sample([MarshalAs(UnmanagedType.LPStr)] string filename, IntPtr spl);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern bool al_save_sample_f(
            IntPtr fp,
            [MarshalAs(UnmanagedType.LPStr)] string ident,
            IntPtr spl);
        #endregion
    }
}
