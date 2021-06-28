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

        /// <summary>
        /// Plays a sample on one of the sample instances created by <see cref="ReserveSamples(int)"/>.
        /// Playback may fail because all the reserved sample instances are currently used.
        /// </summary>
        /// <param name="sample">The sample to play.</param>
        /// <param name="gain">Relative volume at which the sample is played; 1.0 is normal.</param>
        /// <param name="pan">0.0 is centred, -1.0 is left, 1.0 is right, or <see cref="AlConstants.AllegroAudioPanNone"/>.</param>
        /// <param name="speed">Relative speed at which the sample is played; 1.0 is normal.</param>
        /// <param name="loop">Play once, loop forever, or loop bi-directionally (forwards then backwards, repeating).</param>
        /// <param name="retId">
        /// If non-<c>null</c> the variable which this points to will be assigned an id representing the sample
        /// being played. If <see cref="PlaySample(AllegroSample, float, float, float, PlayMode, AllegroSampleId)"/>
        /// returns false, then the contents of <c>retId</c> are invalid and must not be used as argument to other
        /// functions.
        /// </param>
        /// <returns>True on success, false on failure.</returns>
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

        /// <summary>
        /// Stop the sample started by
        /// <see cref="PlaySample(AllegroSample, float, float, float, PlayMode, AllegroSampleId)"/>.
        /// </summary>
        /// <param name="sampleId">The sample ID to stop playing.</param>
        public static void StopSample(AllegroSampleId sampleId)
            => al_stop_sample(ref sampleId.Native);

        /// <summary>
        /// Stop all samples started by
        /// <see cref="PlaySample(AllegroSample, float, float, float, PlayMode, AllegroSampleId)"/>.
        /// </summary>
        public static void StopSamples()
            => al_stop_samples();

        /// <summary>
        /// Return the channel configuration of the sample.
        /// </summary>
        /// <param name="sample">The sample.</param>
        /// <returns>The channel configuration.</returns>
        public static ChannelConf GetSampleChannels(AllegroSample sample)
            => (ChannelConf)al_get_sample_channels(sample.NativeIntPtr);

        /// <summary>
        /// Return the audio depth of the sample.
        /// </summary>
        /// <param name="sample">The sample.</param>
        /// <returns>The audio depth.</returns>
        public static AudioDepth GetSampleDepth(AllegroSample sample)
            => (AudioDepth)al_get_sample_channels(sample.NativeIntPtr);

        /// <summary>
        /// Return the frequency (in Hz) of the sample.
        /// </summary>
        /// <param name="sample">The sample.</param>
        /// <returns>The frequency.</returns>
        public static uint GetSampleFrequency(AllegroSample sample)
            => al_get_sample_frequency(sample.NativeIntPtr);

        /// <summary>
        /// Return the length of the sample in sample values.
        /// </summary>
        /// <param name="sample">The sample.</param>
        /// <returns>The length in sample values.</returns>
        public static uint GetSampleLength(AllegroSample sample)
            => al_get_sample_length(sample.NativeIntPtr);

        /// <summary>
        /// Return a pointer to the raw sample data.
        /// </summary>
        /// <param name="sample">The sample.</param>
        /// <returns>The raw sample data bytes.</returns>
        public static byte[] GetSampleData(AllegroSample sample)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Creates a sample instance, using the supplied sample data. The instance must be attached to a mixer
        /// (or voice) in order to actually produce output.
        /// <para>
        /// The argument may be NULL. You can then set the sample data later with al_set_sample.
        /// </para>
        /// </summary>
        /// <param name="sampleData">The sample.</param>
        /// <returns>The created sample instance.</returns>
        public static AllegroSampleInstance CreateSampleInstance(AllegroSample sampleData)
        {
            var nativeSampleInstance = al_create_sample_instance(sampleData.NativeIntPtr);
            return nativeSampleInstance == IntPtr.Zero ? null : new AllegroSampleInstance { NativeIntPtr = nativeSampleInstance };
        }

        /// <summary>
        /// Detaches the sample instance from anything it may be attached to and frees it (the sample data, i.e. its
        /// <see cref="AllegroSample"/>, is not freed!).
        /// </summary>
        /// <param name="sampleInstance">The sample instance.</param>
        public static void DestroySampleInstance(AllegroSampleInstance sampleInstance)
            => al_destroy_sample_instance(sampleInstance.NativeIntPtr);

        /// <summary>
        /// Play the sample instance.
        /// </summary>
        /// <param name="sampleInstance">The sample instance.</param>
        /// <returns>Returns true on success, false on failure.</returns>
        public static bool PlaySampleInstance(AllegroSampleInstance sampleInstance)
            => al_play_sample_instance(sampleInstance.NativeIntPtr);

        /// <summary>
        /// Stop an sample instance playing.
        /// </summary>
        /// <param name="sampleInstance">The sample instance.</param>
        /// <returns>Returns true on success, false on failure.</returns>
        public static bool StopSampleInstance(AllegroSampleInstance sampleInstance)
            => al_stop_sample_instance(sampleInstance.NativeIntPtr);

        /// <summary>
        /// Return the channel configuration of the sample instance’s sample data.
        /// </summary>
        /// <param name="sampleInstance">The sample instance.</param>
        /// <returns>The channel configuration.</returns>
        public static ChannelConf GetSampleInstanceChannels(AllegroSampleInstance sampleInstance)
            => (ChannelConf)al_get_sample_instance_channels(sampleInstance.NativeIntPtr);

        /// <summary>
        /// Return the audio depth of the sample instance’s sample data.
        /// </summary>
        /// <param name="sampleInstance">The sample instance.</param>
        /// <returns>The audio depth.</returns>
        public static AudioDepth GetSampleInstanceDepth(AllegroSampleInstance sampleInstance)
            => (AudioDepth)al_get_sample_instance_depth(sampleInstance.NativeIntPtr);

        /// <summary>
        /// Return the frequency (in Hz) of the sample instance’s sample data.
        /// </summary>
        /// <param name="sampleInstance">The sample instance.</param>
        /// <returns>The frequency (in Hz) of the sample data.</returns>
        public static uint GetSampleInstanceFrequency(AllegroSampleInstance sampleInstance)
            => al_get_sample_instance_frequency(sampleInstance.NativeIntPtr);

        /// <summary>
        /// Return the length of the sample instance in sample values. This property may differ from the length of the
        /// instance’s sample data.
        /// </summary>
        /// <param name="sampleInstance">The sample instance.</param>
        /// <returns>Length in sample values.</returns>
        public static uint GetSampleInstanceLength(AllegroSampleInstance sampleInstance)
            => al_get_sample_instance_length(sampleInstance.NativeIntPtr);

        /// <summary>
        /// Set the length of the sample instance in sample values. This can be used to play only parts of the
        /// underlying sample. Be careful not to exceed the actual length of the sample data, though.
        /// </summary>
        /// <param name="sampleInstance">The sample length.</param>
        /// <param name="val">The new length in sample values.</param>
        /// <returns>
        /// True on success, false on failure. Will fail if the sample instance is currently playing.
        /// </returns>
        public static bool SetSampleInstanceLength(AllegroSampleInstance sampleInstance, uint val)
            => al_set_sample_instance_length(sampleInstance.NativeIntPtr, val);

        /// <summary>
        /// Get the playback position of a sample instance.
        /// </summary>
        /// <param name="sampleInstance">The sample instance.</param>
        /// <returns>The playback position.</returns>
        public static uint GetSampleInstancePosition(AllegroSampleInstance sampleInstance)
            => al_get_sample_instance_position(sampleInstance.NativeIntPtr);

        /// <summary>
        /// Set the playback position of a sample instance.
        /// </summary>
        /// <param name="sampleInstance">The sample instance.</param>
        /// <param name="val">The playback position.</param>
        /// <returns>True on success, false on failure.</returns>
        public static bool SetSampleInstancePosition(AllegroSampleInstance sampleInstance, uint val)
            => al_set_sample_instance_position(sampleInstance.NativeIntPtr, val);

        /// <summary>
        /// Return the relative playback speed of the sample instance.
        /// </summary>
        /// <param name="sampleInstance">The sample instance.</param>
        /// <returns>Relative playback speed.</returns>
        public static float GetSampleInstanceSpeed(AllegroSampleInstance sampleInstance)
            => al_get_sample_instance_speed(sampleInstance.NativeIntPtr);

        /// <summary>
        /// Set the relative playback speed of the sample instance. 1.0 means normal speed.
        /// </summary>
        /// <param name="sampleInstance">The sample instance.</param>
        /// <param name="val">The relative playback speed.</param>
        /// <returns>
        /// True on success, false on failure. Will fail if the sample instance is attached directly to a voice.
        /// </returns>
        public static bool SetSampleInstanceSpeed(AllegroSampleInstance sampleInstance, float val)
            => al_set_sample_instance_speed(sampleInstance.NativeIntPtr, val);

        /// <summary>
        /// Return the playback gain of the sample instance.
        /// </summary>
        /// <param name="sampleInstance">The sample instance.</param>
        /// <returns>The playback gain.</returns>
        public static float GetSampleInstanceGain(AllegroSampleInstance sampleInstance)
            => al_get_sample_instance_gain(sampleInstance.NativeIntPtr);

        /// <summary>
        /// Set the playback gain of the sample instance.
        /// </summary>
        /// <param name="sampleInstance">The sample instance.</param>
        /// <param name="val">The playback gain.</param>
        /// <returns>T
        /// rue on success, false on failure. Will fail if the sample instance is attached directly to a voice.
        /// </returns>
        public static bool SetSampleInstanceGain(AllegroSampleInstance sampleInstance, float val)
            => al_set_sample_instance_gain(sampleInstance.NativeIntPtr, val);

        /// <summary>
        /// Get the pan value of the sample instance.
        /// </summary>
        /// <param name="sampleInstance">The sample instance.</param>
        /// <returns>The pan value.</returns>
        public static float GetSampleInstancePan(AllegroSampleInstance sampleInstance)
            => al_get_sample_instance_pan(sampleInstance.NativeIntPtr);

        /// <summary>
        /// Set the pan value on a sample instance. A value of -1.0 means to play the sample only through the left
        /// speaker; +1.0 means only through the right speaker; 0.0 means the sample is centre balanced. A special
        /// value <see cref="AlConstants.AllegroAudioPanNone"/> disables panning and plays the sample at its original
        /// level. This will be louder than a pan value of 0.0.
        /// </summary>
        /// <param name="sampleInstance">The sample instance.</param>
        /// <param name="val">The pan value.</param>
        /// <returns>
        /// True on success, false on failure. Will fail if the sample instance is attached directly to a voice.
        /// </returns>
        public static bool SetSampleInstancePan(AllegroSampleInstance sampleInstance, float val)
            => al_set_sample_instance_pan(sampleInstance.NativeIntPtr, val);

        /// <summary>
        /// Return the length of the sample instance in seconds, assuming a playback speed of 1.0.
        /// </summary>
        /// <param name="sampleInstance">The sample instance.</param>
        /// <returns>Length in seconds, assuming playback speed of 1.0.</returns>
        public static float GetSampleInstanceTime(AllegroSampleInstance sampleInstance)
            => al_get_sample_instance_time(sampleInstance.NativeIntPtr);

        /// <summary>
        /// Return the playback mode of the sample instance.
        /// </summary>
        /// <param name="sampleInstance">The sample instance.</param>
        /// <returns>The playback mode.</returns>
        public static PlayMode GetSampleInstancePlaymode(AllegroSampleInstance sampleInstance)
            => (PlayMode)al_get_sample_instance_playmode(sampleInstance.NativeIntPtr);

        /// <summary>
        /// Set the playback mode of the sample instance.
        /// </summary>
        /// <param name="sampleInstance">The sample instance.</param>
        /// <param name="val">The playmode mode.</param>
        /// <returns>True on success, false on failure.</returns>
        public static bool SetSampleInstancePlayMode(AllegroSampleInstance sampleInstance, PlayMode val)
            => al_set_sample_instance_playmode(sampleInstance.NativeIntPtr, (int)val);

        /// <summary>
        /// Return true if the sample instance is in the playing state. This may be true even if the instance is
        /// not attached to anything.
        /// </summary>
        /// <param name="sampleInstance">The sample instance.</param>
        /// <returns>True if the sample is in the playing state, otherwise false.</returns>
        public static bool GetSampleInstancePlaying(AllegroSampleInstance sampleInstance)
            => al_get_sample_instance_playing(sampleInstance.NativeIntPtr);

        /// <summary>
        /// Change whether the sample instance is playing. The instance does not need to be attached to anything.
        /// </summary>
        /// <param name="sampleInstance">The sample instance.</param>
        /// <param name="val">True is playing, false is not playing.</param>
        /// <returns>True on success, otherwise false.</returns>
        public static bool SetSampleInstancePlaying(AllegroSampleInstance sampleInstance, bool val)
            => al_set_sample_instance_playing(sampleInstance.NativeIntPtr, val);

        /// <summary>
        /// Return whether the sample instance is attached to something.
        /// </summary>
        /// <param name="sampleInstance">The sample instance.</param>
        /// <returns>True if attached to something, otherwise false.</returns>
        public static bool GetSampleInstanceAttached(AllegroSampleInstance sampleInstance)
            => al_get_sample_instance_attached(sampleInstance.NativeIntPtr);

        /// <summary>
        /// Detach the sample instance from whatever it’s attached to, if anything.
        /// </summary>
        /// <param name="sampleInstance">The sample instance.</param>
        /// <returns>True on success, otherwise false.</returns>
        public static bool DetachSampleInstance(AllegroSampleInstance sampleInstance)
            => al_detach_sample_instance(sampleInstance.NativeIntPtr);

        /// <summary>
        /// Return the sample data that the sample instance plays.
        /// <para>
        /// Note this returns a pointer to an internal structure, not the <see cref="AllegroSample"/> that you may
        /// have passed to <see cref="SetSample(AllegroSampleInstance, AllegroSample)"/>. However, the sample buffer
        /// of the returned <see cref="AllegroSample"/> will be the same as the one that was used to create the sample
        /// (passed to <see cref="CreateSample(ref byte[], uint, uint, AudioDepth, ChannelConf, bool)"/>). You can
        /// use <see cref="GetSampleData(AllegroSample)"/> on the return value to retrieve and compare it.
        /// </para>
        /// </summary>
        /// <param name="sampleInstance">The sample instance.</param>
        /// <returns>The sample data from the sample instance, otherwise null.</returns>
        public static AllegroSample GetSample(AllegroSampleInstance sampleInstance)
        {
            var nativeSample = al_get_sample(sampleInstance.NativeIntPtr);
            return nativeSample == null ? null : new AllegroSample { NativeIntPtr = nativeSample };
        }

        /// <summary>
        /// Change the sample data that a sample instance plays. This can be quite an involved process.
        /// <para>
        /// First, the sample is stopped if it is not already.
        /// </para>
        /// <para>
        /// Next, if data is <c>null</c>, the sample is detached from its parent (if any).
        /// </para>
        /// <para>
        /// If data is not <c>null</c>, the sample may be detached and reattached to its parent(if any). This is not
        /// necessary if the old sample data and new sample data have the same frequency, depth and channel
        /// configuration. Reattaching may not always succeed.
        /// </para>
        /// <para>
        /// On success, the sample remains stopped. The playback position and loop end points are reset to their
        /// default values. The loop mode remains unchanged.
        /// </para>
        /// <para>
        /// Returns true on success, false on failure. On failure, the sample will be stopped and detached from its
        /// parent.
        /// </para>
        /// </summary>
        /// <param name="sampleInstance">The sample instance.</param>
        /// <param name="sample">The sample.</param>
        /// <returns>
        /// True on success, otherwise false. On failure, the sample will be stopped and detached from its parent.
        /// </returns>
        public static bool SetSample(AllegroSampleInstance sampleInstance, AllegroSample sample)
            => al_set_sample(sampleInstance.NativeIntPtr, sample.NativeIntPtr);

        /// <summary>
        /// Creates a mixer to attach sample instances, audio streams, or other mixers to. It will mix into a buffer
        /// at the requested frequency (in Hz) and channel count.
        /// <para>
        /// The only supported audio depths are <see cref="AudioDepth.Float32"/> and <see cref="AudioDepth.Int16"/>
        /// (not yet complete).
        /// </para>
        /// <para>
        /// To actually produce any output, the mixer will have to be attached to a voice using
        /// <see cref="AttachMixerToVoice(AllegroMixer, AllegroVoice)"/>.
        /// </para>
        /// <para>
        /// Reasonable default arguments are: <c>CreateMixer(44100, <see cref="AudioDepth.Float32"/>,
        /// <see cref="ChannelConf.Conf2"/>)</c>
        /// </para>
        /// </summary>
        /// <param name="freq">The frequency.</param>
        /// <param name="depth">The sample depth.</param>
        /// <param name="channelConf">The channel configuration.</param>
        /// <returns>The mixer on success, otherwise null.</returns>
        public static AllegroMixer CreateMixer(uint freq, AudioDepth depth, ChannelConf channelConf)
        {
            var nativeMixer = al_create_mixer(freq, (int)depth, (int)channelConf);
            return nativeMixer == IntPtr.Zero ? null : new AllegroMixer { NativeIntPtr = nativeMixer };
        }

        /// <summary>
        /// Destroys the mixer.
        /// </summary>
        /// <param name="mixer">The mixer.</param>
        public static void DestroyMixer(AllegroMixer mixer)
            => al_destroy_mixer(mixer.NativeIntPtr);

        /// <summary>
        /// Return the default mixer, or <c>null</c> if one has not been set. Although different configurations of
        /// mixers and voices can be used, in most cases a single mixer attached to a voice is what you want. The
        /// default mixer is used by <see cref="PlaySample(AllegroSample, float, float, float, PlayMode, AllegroSampleId)"/>.
        /// </summary>
        /// <returns>The default mixer, or <c>null</c> if one has not been set.</returns>
        public static AllegroMixer GetDefaultMixer()
        {
            var nativeMixer = al_get_default_mixer();
            return nativeMixer == IntPtr.Zero ? null : new AllegroMixer { NativeIntPtr = nativeMixer };
        }

        /// <summary>
        /// Sets the default mixer. All samples started with
        /// <see cref="PlaySample(AllegroSample, float, float, float, PlayMode, AllegroSampleId)"/> will be stopped and
        /// all sample instances returned by al_lock_sample_id (UNSTABLE API, NOT IN ALLEGRODOTNET) will be
        /// invalidated. If you are using your own mixer, this should be called before
        /// <see cref="ReserveSamples(int)"/>.
        /// </summary>
        /// <param name="mixer">The mixer.</param>
        /// <returns>True on success, otherwise false.</returns>
        public static bool SetDefaultMixer(AllegroMixer mixer)
            => al_set_default_mixer(mixer.NativeIntPtr);

        /// <summary>
        /// Restores Allegro’s default mixer and attaches it to the default voice. If the default mixer hasn’t been
        /// created before, it will be created. If the default voice hasn’t been set via
        /// <see cref="SetDefaultVoice(AllegroVoice)"/> or created before, it will also be created. All samples
        /// started with <see cref="PlaySample(AllegroSample, float, float, float, PlayMode, AllegroSampleId)"/>
        /// will be stopped and all sample instances returned by al_lock_sample_id (UNSTABLE API, NOT IN
        /// ALLEGRODOTNET) will be invalidated.
        /// </summary>
        /// <returns>True on success, otherwise false.</returns>
        public static bool RestoreDefaultMixer()
            => al_restore_default_mixer();

        /// <summary>
        /// Returns the default voice or <c>null</c> if there is none.
        /// </summary>
        /// <returns>The default voice, or <c>null</c> if none.</returns>
        public static AllegroVoice GetDefaultVoice()
        {
            var nativeVoice = al_get_default_voice();
            return nativeVoice == IntPtr.Zero ? null : new AllegroVoice { NativeIntPtr = nativeVoice };
        }

        /// <summary>
        /// You can call this before calling <see cref="RestoreDefaultMixer"/> to provide the voice which should be
        /// used. Any previous voice will be destroyed. You can also pass <c>null</c> to destroy the current default
        /// voice.
        /// </summary>
        /// <param name="voice"></param>
        public static void SetDefaultVoice(AllegroVoice voice)
            => al_set_default_voice(voice.NativeIntPtr);

        /// <summary>
        /// Attaches the mixer passed as the first argument onto the mixer passed as the second argument. The first
        /// mixer (that is going to be attached) must not already be attached to anything. Both mixers must use the
        /// same frequency, audio depth and channel configuration.
        /// <para>
        /// It is invalid to attach a mixer to itself.
        /// </para>
        /// </summary>
        /// <param name="stream">The mixer to join to another.</param>
        /// <param name="mixer">The mixer to be joined to.</param>
        /// <returns>True on success, false on error.</returns>
        public static bool AttachMixerToMixer(AllegroMixer stream, AllegroMixer mixer)
            => al_attach_mixer_to_mixer(stream.NativeIntPtr, mixer.NativeIntPtr);

        /// <summary>
        /// Attach a sample instance to a mixer. The instance must not already be attached to anything.
        /// </summary>
        /// <param name="sampleInstance">The sample instance.</param>
        /// <param name="mixer">The mixer.</param>
        /// <returns>True on success, false on failure.</returns>
        public static bool AttachSampleInstanceToMixer(AllegroSampleInstance sampleInstance, AllegroMixer mixer)
            => al_attach_sample_instance_to_mixer(sampleInstance.NativeIntPtr, mixer.NativeIntPtr);

        /// <summary>
        /// Attach an audio stream to a mixer. The stream must not already be attached to anything.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <param name="mixer">The mixer.</param>
        /// <returns>True on success, false on failure.</returns>
        public static bool AttachAudioStreamToMixer(AllegroAudioStream stream, AllegroMixer mixer)
            => al_attach_audio_stream_to_mixer(stream.NativeIntPtr, mixer.NativeIntPtr);

        /// <summary>
        /// Return the mixer frequency (in Hz).
        /// </summary>
        /// <param name="mixer">The mixer.</param>
        /// <returns>The mixer frequency (in Hz).</returns>
        public static uint GetMixerFrequency(AllegroMixer mixer)
            => al_get_mixer_frequency(mixer.NativeIntPtr);

        /// <summary>
        /// Set the mixer frequency (in Hz). This will only work if the mixer is not attached to anything.
        /// </summary>
        /// <param name="mixer">The mixer.</param>
        /// <param name="val">The frequency.</param>
        /// <returns>True on success, otherwise false.</returns>
        public static bool SetMixerFrequency(AllegroMixer mixer, uint val)
            => al_set_mixer_frequency(mixer.NativeIntPtr, val);

        /// <summary>
        /// Return the mixer channel configuration.
        /// </summary>
        /// <param name="mixer">The mixer.</param>
        /// <returns>The mixer channel configuration.</returns>
        public static ChannelConf GetMixerChannels(AllegroMixer mixer)
            => (ChannelConf)al_get_mixer_channels(mixer.NativeIntPtr);

        /// <summary>
        /// Return the mixer audio depth.
        /// </summary>
        /// <param name="mixer">The mixer.</param>
        /// <returns>The mixer audio depth.</returns>
        public static AudioDepth GetMixerDepth(AllegroMixer mixer)
            => (AudioDepth)al_get_mixer_depth(mixer.NativeIntPtr);

        /// <summary>
        /// Return the mixer gain (amplification factor). The default is 1.0.
        /// </summary>
        /// <param name="mixer">The mixer.</param>
        /// <returns>The mixer gain.</returns>
        public static float GetMixerGain(AllegroMixer mixer)
            => al_get_mixer_gain(mixer.NativeIntPtr);

        /// <summary>
        /// Set the mixer gain (amplification factor).
        /// </summary>
        /// <param name="mixer">The mixer.</param>
        /// <param name="newGain">The gain (default is 1.0).</param>
        /// <returns>True on success, false on failure.</returns>
        public static bool SetMixerGain(AllegroMixer mixer, float newGain)
            => al_set_mixer_gain(mixer.NativeIntPtr, newGain);

        /// <summary>
        /// Return the mixer quality.
        /// </summary>
        /// <param name="mixer">The mixer.</param>
        /// <returns>The mixer quality.</returns>
        public static MixerQuality GetMixerQuality(AllegroMixer mixer)
            => (MixerQuality)al_get_mixer_quality(mixer.NativeIntPtr);

        /// <summary>
        /// Set the mixer quality. This can only succeed if the mixer does not have anything attached to it.
        /// </summary>
        /// <param name="mixer">The mixer.</param>
        /// <param name="newQuality">The new mixer quality.</param>
        /// <returns>True on success, false on failure.</returns>
        public static bool SetMixerQuality(AllegroMixer mixer, MixerQuality newQuality)
            => al_set_mixer_quality(mixer.NativeIntPtr, (int)newQuality);

        /// <summary>
        /// Return true if the mixer is playing.
        /// </summary>
        /// <param name="mixer">The mixer.</param>
        /// <returns>True if the mixer is playing, otherwise false.</returns>
        public static bool GetMixerPlaying(AllegroMixer mixer)
            => al_get_mixer_playing(mixer.NativeIntPtr);

        /// <summary>
        /// Change whether the mixer is playing.
        /// </summary>
        /// <param name="mixer">The mixer.</param>
        /// <param name="val">True for playing, false for not playing.</param>
        /// <returns>True on success, false on failure.</returns>
        public static bool SetMixerPlaying(AllegroMixer mixer, bool val)
            => al_set_mixer_playing(mixer.NativeIntPtr, val);

        /// <summary>
        /// Return true if the mixer is attached to something.
        /// </summary>
        /// <param name="mixer">The mixer.</param>
        /// <returns>True if the mixer is attached to something, otherwise null.</returns>
        public static bool GetMixerAttached(AllegroMixer mixer)
            => al_get_mixer_attached(mixer.NativeIntPtr);

        /// <summary>
        /// Detach the mixer from whatever it is attached to, if anything.
        /// </summary>
        /// <param name="mixer">The mixer.</param>
        /// <returns>True if successful, otherwise null.</returns>
        public static bool DetachMixer(AllegroMixer mixer)
            => al_detach_mixer(mixer.NativeIntPtr);

        /// <summary>
        /// <para>(NOT IMPLEMENTED)</para>
        /// Sets a post-processing filter function that’s called after the attached streams have been mixed.
        /// The buffer’s format will be whatever the mixer was created with. The sample count and user-data
        /// pointer is also passed.
        /// </summary>
        /// <param name="mixer">The mixer.</param>
        /// <returns>True on success, false otherwise.</returns>
        public static bool SetMixerPostProcessCallback(AllegroMixer mixer)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Creates an <see cref="AllegroAudioStream"/>. The stream will be set to play by default. It will feed
        /// audio data from a buffer, which is split into a number of fragments.
        /// <para>
        /// A sample that is referred to by the <c>fragSamples</c> parameter refers to a sequence channel intensities.
        /// E.g. if you’re making a stereo stream with the frag_samples set to 4, then the layout of the data in the
        /// fragment will be: <c>LRLRLRLR</c> Where L and R are the intensities for the left and right channels
        /// respectively. A single sample, then, refers to the LR pair in this example.
        /// </para>
        /// <para>
        /// The choice of <c>fragCount</c>, <c>fragSamples</c> and <c>freq</c> influences the audio delay. The
        /// delay in seconds can be expressed as: <c>delay = fragment_count * frag_samples / freq</c>. This is only
        /// the delay due to Allegro’s streaming, there may be additional delay caused by sound drivers and/or
        /// hardware.
        /// </para>
        /// <para>
        /// Unlike many Allegro objects, audio streams are not implicitly destroyed when Allegro is shut down.
        /// You must destroy them manually with <see cref="DestroyAudioStream(AllegroAudioStream)"/> before the audio
        /// system is shut down.
        /// </para>
        /// </summary>
        /// <param name="fragCount">
        /// How many fragments to use for the audio stream. Usually only two fragments are required - splitting
        /// the audio buffer in two halves. But it means that the only time when new data can be supplied is whenever
        /// one half has finished playing. When using many fragments, you usually will use fewer samples for one, so
        /// there always will be (small) fragments available to be filled with new data.
        /// </param>
        /// <param name="fragSamples">The size of a fragment in samples.</param>
        /// <param name="freq">The frequency, in Hertz.</param>
        /// <param name="depth">Must be one of the values listed for <see cref="AudioDepth"/>.</param>
        /// <param name="channelConf">Must be one of the values listed for <see cref="ChannelConf"/>.</param>
        /// <returns>The audio stream on success, otherwise <c>null</c>.</returns>
        public static AllegroAudioStream CreateAudioStream(ulong fragCount, uint fragSamples, uint freq, AudioDepth depth, ChannelConf channelConf)
        {
            var nativeAudioStream = al_create_audio_stream(new UIntPtr(fragCount), fragSamples, freq, (int)depth, (int)channelConf);
            return nativeAudioStream == IntPtr.Zero ? null : new AllegroAudioStream { NativeIntPtr = nativeAudioStream };
        }

        /// <summary>
        /// Destroy an audio stream which was created with
        /// <see cref="CreateAudioStream(ulong, uint, uint, AudioDepth, ChannelConf)"/> or
        /// <see cref="LoadAudioStream(string, ulong, uint)"/>. If the stream is still attached to a mixer or voice,
        /// <see cref="DetachAudioStream(AllegroAudioStream)"/> is automatically called on it first.
        /// </summary>
        /// <param name="stream">The audio stream.</param>
        public static void DestroyAudioStream(AllegroAudioStream stream)
            => al_destroy_audio_stream(stream.NativeIntPtr);

        /// <summary>
        /// Retrieve the associated event source. See <see cref="GetAudioStreamFragment(AllegroAudioStream)"/> for a
        /// description of the <see cref="EventType.AudioStreamFragment"/> event that audio streams emit.
        /// </summary>
        /// <param name="stream">The audio stream.</param>
        /// <returns>The event source.</returns>
        public static AllegroEventSource GetAudioStreamEventSource(AllegroAudioStream stream)
        {
            var nativeEventSource = al_get_audio_stream_event_source(stream.NativeIntPtr);
            return nativeEventSource == IntPtr.Zero ? null : new AllegroEventSource { NativeIntPtr = nativeEventSource };
        }

        /// <summary>
        /// You should call this to finalise an audio stream that you will no longer be feeding, to wait for all
        /// pending buffers to finish playing. The stream’s playing state will change to false.
        /// </summary>
        /// <param name="stream">The audio stream.</param>
        public static void DrainAudioStream(AllegroAudioStream stream)
            => al_drain_audio_stream(stream.NativeIntPtr);

        /// <summary>
        /// Set the streaming file playing position to the beginning. Returns true on success. Currently this can only
        /// be called on streams created with <see cref="LoadAudioStream(string, ulong, uint)"/>,
        /// <see cref="LoadAudioStreamF(AllegroFile, string, ulong, uint)"/> and the format-specific functions
        /// underlying those functions.
        /// </summary>
        /// <param name="stream">The audio stream.</param>
        /// <returns>True on success, otherwise false.</returns>
        public static bool RewindAudioStream(AllegroAudioStream stream)
            => al_rewind_audio_stream(stream.NativeIntPtr);

        /// <summary>
        /// Return the stream frequency (in Hz).
        /// </summary>
        /// <param name="stream">The audio stream.</param>
        /// <returns>The frequency in Hz.</returns>
        public static uint GetAudioStreamFrequency(AllegroAudioStream stream)
            => al_get_audio_stream_frequency(stream.NativeIntPtr);

        /// <summary>
        /// Return the stream channel configuration.
        /// </summary>
        /// <param name="stream">The audio stream.</param>
        /// <returns>The channel configuration.</returns>
        public static ChannelConf GetAudioStreamChannels(AllegroAudioStream stream)
            => (ChannelConf)al_get_audio_stream_channels(stream.NativeIntPtr);

        /// <summary>
        /// Return the stream audio depth.
        /// </summary>
        /// <param name="stream">The audio stream.</param>
        /// <returns>The audio depth.</returns>
        public static AudioDepth GetAudioStreamDepth(AllegroAudioStream stream)
            => (AudioDepth)al_get_audio_stream_depth(stream.NativeIntPtr);

        /// <summary>
        /// Return the stream length in samples.
        /// </summary>
        /// <param name="stream">The audio stream.</param>
        /// <returns>The length in samples.</returns>
        public static uint GetAudioStreamLength(AllegroAudioStream stream)
            => al_get_audio_stream_length(stream.NativeIntPtr);

        /// <summary>
        /// Return the relative playback speed of the stream.
        /// </summary>
        /// <param name="stream">The audio stream.</param>
        /// <returns>The relative playback speed.</returns>
        public static float GetAudioStreamSpeed(AllegroAudioStream stream)
            => al_get_audio_stream_speed(stream.NativeIntPtr);

        /// <summary>
        /// Set the relative playback speed of the stream. 1.0 means normal speed.
        /// </summary>
        /// <param name="stream">The audio stream.</param>
        /// <param name="val">The playback speed.</param>
        /// <returns>
        /// True on success, false on failure. Will fail if the audio stream is attached directly to a voice.
        /// </returns>
        public static bool SetAudioStreamSpeed(AllegroAudioStream stream, float val)
            => al_set_audio_stream_speed(stream.NativeIntPtr, val);

        /// <summary>
        /// Return the playback gain of the stream.
        /// </summary>
        /// <param name="stream">The audio stream.</param>
        /// <returns>The playback gain.</returns>
        public static float GetAudioStreamGain(AllegroAudioStream stream)
            => al_get_audio_stream_gain(stream.NativeIntPtr);

        /// <summary>
        /// Set the playback gain of the stream.
        /// </summary>
        /// <param name="stream">The audio stream.</param>
        /// <param name="val">The playback gain.</param>
        /// <returns>
        /// True on success, false on failure. Will fail if the audio stream is attached directly to a voice.
        /// </returns>
        public static bool SetAudioStreamGain(AllegroAudioStream stream, float val)
            => al_set_audio_stream_gain(stream.NativeIntPtr, val);

        /// <summary>
        /// Get the pan value of the stream; 0.0 means center balanced, -1.0 is only left-speaker, 1.0 is only right.
        /// </summary>
        /// <param name="stream">The audio stream.</param>
        /// <returns>The pan value.</returns>
        public static float GetAudioStreamPan(AllegroAudioStream stream)
            => al_get_audio_stream_pan(stream.NativeIntPtr);

        /// <summary>
        /// Set the pan value on an audio stream. A value of -1.0 means to play the stream only through the left
        /// speaker; +1.0 means only through the right speaker; 0.0 means the sample is centre balanced. A
        /// special value <see cref="AlConstants.AllegroAudioPanNone"/> disables panning and plays the stream at
        /// its original level. This will be louder than a pan value of 0.0.
        /// </summary>
        /// <param name="stream">The audio stream.</param>
        /// <param name="val">The pan value.</param>
        /// <returns>
        /// True on success, false on failure. Will fail if the audio stream is attached directly to a voice.
        /// </returns>
        public static bool SetAudioStreamPan(AllegroAudioStream stream, float val)
            => al_set_audio_stream_pan(stream.NativeIntPtr, val);

        /// <summary>
        /// Return true if the stream is playing.
        /// </summary>
        /// <param name="stream">The audio stream.</param>
        /// <returns>True if the stream is playing.</returns>
        public static bool GetAudioStreamPlaying(AllegroAudioStream stream)
            => al_get_audio_stream_playing(stream.NativeIntPtr);

        /// <summary>
        /// Change whether the stream is playing.
        /// </summary>
        /// <param name="stream">The audio stream.</param>
        /// <param name="val">True to play, false to stop.</param>
        /// <returns>True on success, false on failure.</returns>
        public static bool SetAudioStreamPlaying(AllegroAudioStream stream, bool val)
            => al_set_audio_stream_playing(stream.NativeIntPtr, val);

        /// <summary>
        /// Return the playback mode of the stream.
        /// </summary>
        /// <param name="stream">The audio stream.</param>
        /// <returns>The playback mode of the stream.</returns>
        public static PlayMode GetAudioStreamPlaymode(AllegroAudioStream stream)
            => (PlayMode)al_get_audio_stream_playmode(stream.NativeIntPtr);

        /// <summary>
        /// Set the playback mode of the stream.
        /// </summary>
        /// <param name="stream">The audio stream.</param>
        /// <param name="mode">The play mode.</param>
        /// <returns>True on success, false on failure.</returns>
        public static bool SetAudioStreamPlaymode(AllegroAudioStream stream, PlayMode mode)
            => al_set_audio_stream_playmode(stream.NativeIntPtr, (int)mode);

        /// <summary>
        /// Return whether the stream is attached to something.
        /// </summary>
        /// <param name="stream">The audio stream.</param>
        /// <returns>True if the stream is attached to something, otherwise false.</returns>
        public static bool GetAudioStreamAttached(AllegroAudioStream stream)
            => al_get_audio_stream_attached(stream.NativeIntPtr);

        /// <summary>
        /// Detach the stream from whatever it’s attached to, if anything.
        /// </summary>
        /// <param name="stream">The audio stream.</param>
        /// <returns>True if the stream is still attached to something, otherwise false.</returns>
        public static bool DetachAudioStream(AllegroAudioStream stream)
            => al_detach_audio_stream(stream.NativeIntPtr);

        /// <summary>
        /// Get the number of samples consumed by the parent since the audio stream was started.
        /// </summary>
        /// <param name="stream">The audio stream.</param>
        /// <returns>Number of samples consumed by the parent since started.</returns>
        public static ulong GetAudioStreamPlayedSamples(AllegroAudioStream stream)
            => al_get_audio_stream_played_samples(stream.NativeIntPtr);

        /// <summary>
        /// When using Allegro’s audio streaming, you will use this function to continuously provide new sample data
        /// to a stream.
        /// <para>
        /// If the stream is ready for new data, the function will return the address of an internal buffer to be
        /// filled with audio data. The length and format of the buffer are specified with
        /// <see cref="CreateAudioStream(ulong, uint, uint, AudioDepth, ChannelConf)"/> or can be queried with the
        /// various functions described here. Once the buffer is filled, you must signal this to Allegro by passing
        /// the buffer to <see cref="SetAudioStreamFragment(AllegroAudioStream, byte[])"/>.
        /// </para>
        /// <para>
        /// Note: If you listen to events from the stream, an <see cref="EventType.AudioStreamFragment"/> event will
        /// be generated whenever a new fragment is ready. However, getting an event is not a guarantee that
        /// <see cref="GetAudioStreamFragment(AllegroAudioStream)"/> will not return <c>null</c>, so you still must
        /// check for it.
        /// </para>
        /// </summary>
        /// <param name="stream">The audio stream.</param>
        /// <returns>The audio stream fragment.</returns>
        public static byte[] GetAudioStreamFragment(AllegroAudioStream stream)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This function needs to be called for every successful call of
        /// <see cref="GetAudioStreamFragment(AllegroAudioStream)"/> to indicate that the buffer (pointed to by
        /// val) is filled with new data.
        /// </summary>
        /// <param name="stream">The audio stream.</param>
        /// <param name="val">The audio stream fragment data.</param>
        /// <returns>True on success, otherwise false.</returns>
        public static bool SetAudioStreamFragment(AllegroAudioStream stream, byte[] val)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns the number of fragments this stream uses. This is the same value as passed to
        /// <see cref="CreateAudioStream(ulong, uint, uint, AudioDepth, ChannelConf)"/> when a new stream is created.
        /// </summary>
        /// <param name="stream">The audio stream.</param>
        /// <returns>The number of fragments in use.</returns>
        public static uint GetAudioStreamFragments(AllegroAudioStream stream)
            => al_get_audio_stream_fragments(stream.NativeIntPtr);

        /// <summary>
        /// Returns the number of available fragments in the stream, that is, fragments which are not currently
        /// filled with data for playback.
        /// </summary>
        /// <param name="stream">The audio stream.</param>
        /// <returns>The number of fragments not filled with data.</returns>
        public static uint GetAvailableAudioStreamFragments(AllegroAudioStream stream)
            => al_get_available_audio_stream_fragments(stream.NativeIntPtr);

        /// <summary>
        /// Set the streaming file playing position to time. Returns true on success. Currently this can only be called
        /// on streams created with <see cref="LoadAudioStream(string, ulong, uint)"/>,
        /// <see cref="LoadAudioStream(string, ulong, uint)"/> and the format-specific functions underlying those
        /// functions.
        /// </summary>
        /// <param name="stream">The audio stream.</param>
        /// <param name="time">The file playing position.</param>
        /// <returns>True on success, otherwise false.</returns>
        public static bool SeekAudioStreamSecs(AllegroAudioStream stream, double time)
            => al_seek_audio_stream_secs(stream.NativeIntPtr, time);

        /// <summary>
        /// Return the position of the stream in seconds. Currently this can only be called on streams created with
        /// <see cref="LoadAudioStream(string, ulong, uint)"/>.
        /// </summary>
        /// <param name="stream">The audio stream.</param>
        /// <returns>The position of the stream in seconds.</returns>
        public static double GetAudioStreamPositionSecs(AllegroAudioStream stream)
            => al_get_audio_stream_position_secs(stream.NativeIntPtr);

        /// <summary>
        /// Currently this can only be called on streams created with
        /// <see cref="LoadAudioStream(string, ulong, uint)"/>,
        /// <see cref="LoadAudioStreamF(AllegroFile, string, ulong, uint)"/> and the format-specific functions
        /// underlying those functions.
        /// </summary>
        /// <param name="stream">The audio stream.</param>
        /// <returns>The length of the stream in seconds, if known. Otherwise returns zero.</returns>
        public static double GetAudioStreamLengthSecs(AllegroAudioStream stream)
            => al_get_audio_stream_length_secs(stream.NativeIntPtr);

        /// <summary>
        /// Sets the loop points for the stream in seconds. Currently this can only be called on streams created with
        /// <see cref="LoadAudioStream(string, ulong, uint)"/>, 
        /// <see cref="LoadAudioStreamF(AllegroFile, string, ulong, uint)"/> and the format-specific functions
        /// underlying those functions.
        /// </summary>
        /// <param name="stream">The audio stream.</param>
        /// <param name="start">The loop start point.</param>
        /// <param name="end">The loop end point.</param>
        /// <returns>True on success, otherwise false.</returns>
        public static bool SetAudioStreamLoopSecs(AllegroAudioStream stream, double start, double end)
            => al_set_audio_stream_loop_secs(stream.NativeIntPtr, start, end);

        /// <summary>
        /// NOT IMPLEMENTED
        /// </summary>
        /// <param name="ext"></param>
        /// <param name="loader"></param>
        /// <returns></returns>
        public static bool RegisterSampleLoader(string ext, Action loader)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// NOT IMPLEMENTED
        /// </summary>
        /// <param name="ext"></param>
        /// <param name="loader"></param>
        /// <returns></returns>
        public static bool RegisterSampleLoaderF(string ext, Action loader)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// NOT IMPLEMENTED
        /// </summary>
        /// <param name="ext"></param>
        /// <param name="saver"></param>
        /// <returns></returns>
        public static bool RegisterSampleSaver(string ext, Action saver)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// NOT IMPLEMENTED
        /// </summary>
        /// <param name="ext"></param>
        /// <param name="saver"></param>
        /// <returns></returns>
        public static bool RegisterSampleSaverF(string ext, Action saver)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// NOT IMPLEMENTED
        /// </summary>
        /// <param name="ext"></param>
        /// <param name="streamLoader"></param>
        /// <param name="bufferCount"></param>
        /// <param name="samples"></param>
        /// <returns></returns>
        public static bool RegisterAudioStreamLoader(string ext, Action streamLoader, ulong bufferCount, uint samples)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// NOT IMPLEMENTED
        /// </summary>
        /// <param name="ext"></param>
        /// <param name="streamLoader"></param>
        /// <param name="bufferCount"></param>
        /// <param name="samples"></param>
        /// <returns></returns>
        public static bool RegisterAudioStreamLoaderF(string ext, Action streamLoader, ulong bufferCount, uint samples)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Loads a few different audio file formats based on their extension. Note that this stores the entire file in
        /// memory at once, which may be time consuming. To read the file as it is needed, use
        /// <see cref="LoadAudioStream(string, ulong, uint)"/>.
        /// </summary>
        /// <param name="filename">The sample filename.</param>
        /// <returns>The sample on success, NULL on failure.</returns>
        public static AllegroSample LoadSample(string filename)
        {
            var nativeSample = al_load_sample(filename);
            return nativeSample == IntPtr.Zero ? null : new AllegroSample { NativeIntPtr = nativeSample };
        }

        /// <summary>
        /// Loads an audio file from an <see cref="AllegroFile"/> stream into an <see cref="AllegroSample"/>. The file
        /// type is determined by the passed ‘ident’ parameter, which is a file name extension including the leading
        /// dot.
        /// <para>
        /// Note that this stores the entire file in memory at once, which may be time consuming. To read the file as
        /// it is needed, use <see cref="LoadAudioStreamF(AllegroFile, string, ulong, uint)"/>.
        /// </para>
        /// <para>
        /// Note: the allegro_audio library does not support any audio file formats by default. You must use the
        /// Allegro ACodec addon, or register your own format handler.
        /// </para>
        /// </summary>
        /// <param name="fp">The Allegro file.</param>
        /// <param name="ident">The </param>
        /// <returns>The sample on success, NULL on failure. The file remains open afterwards.</returns>
        public static AllegroSample LoadSampleF(AllegroFile fp, string ident)
        {
            var nativeSample = al_load_sample_f(fp.NativeIntPtr, ident);
            return nativeSample == IntPtr.Zero ? null : new AllegroSample { NativeIntPtr = nativeSample };
        }

        /// <summary>
        /// Loads an audio file from disk as it is needed.
        /// <para>
        /// Unlike regular streams, the one returned by this function need not be fed by the user; the library will
        /// automatically read more of the file as it is needed. The stream will contain <c>bufferCount</c> buffers
        /// with samples samples.
        /// </para>
        /// <para>
        /// The audio stream will start in the playing state. It should be attached to a voice or mixer to generate
        /// any output. See <see cref="AllegroAudioStream"/> for more details.
        /// </para>
        /// <para>
        /// Note: the allegro_audio library does not support any audio file formats by default. You must use the
        /// allegro_acodec addon, or register your own format handler.
        /// </para>
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <param name="bufferCount">The buffer count.</param>
        /// <param name="samples">The amount of samples.</param>
        /// <returns>The audio stream, or null on error.</returns>
        public static AllegroAudioStream LoadAudioStream(string filename, ulong bufferCount, uint samples)
        {
            var nativeStream = al_load_audio_stream(filename, new UIntPtr(bufferCount), samples);
            return nativeStream == IntPtr.Zero ? null : new AllegroAudioStream { NativeIntPtr = nativeStream };
        }

        /// <summary>
        /// Loads an audio file from <see cref="AllegroFile"/> stream as it is needed.
        /// <para>
        /// Unlike regular streams, the one returned by this function need not be fed by the user; the library will
        /// automatically read more of the file as it is needed. The stream will contain <c>bufferCount</c> buffers
        /// with samples samples.
        /// </para>
        /// <para>
        /// The file type is determined by the passed ‘ident’ parameter, which is a file name extension including the
        /// leading dot.
        /// </para>
        /// <para>
        /// The audio stream will start in the playing state. It should be attached to a voice or mixer to generate any
        /// output. See <see cref="AllegroAudioStream"/> for more details.
        /// </para>
        /// </summary>
        /// <param name="fp">The Allegro file.</param>
        /// <param name="ident">The identifying extension.</param>
        /// <param name="bufferCount">The buffer count.</param>
        /// <param name="samples">The amount of samples.</param>
        /// <returns>
        /// Returns the stream on success, NULL on failure. On success the file should be considered owned by the audio
        /// stream, and will be closed when the audio stream is destroyed. On failure the file will be closed.
        /// </returns>
        public static AllegroAudioStream LoadAudioStreamF(AllegroFile fp, string ident, ulong bufferCount, uint samples)
        {
            var nativeStream = al_load_audio_stream_f(fp.NativeIntPtr, ident, new UIntPtr(bufferCount), samples);
            return nativeStream == IntPtr.Zero ? null : new AllegroAudioStream { NativeIntPtr = nativeStream };
        }

        /// <summary>
        /// Writes a sample into a file. Currently, wav is the only supported format, and the extension must be “.wav”.
        /// </summary>
        /// <param name="filename">The filename</param>
        /// <param name="sample">The sample.</param>
        /// <returns>True on success, false on error.</returns>
        public static bool SaveSample(string filename, AllegroSample sample)
            => al_save_sample(filename, sample.NativeIntPtr);

        /// <summary>
        /// Writes a sample into a <see cref="AllegroFile"/> filestream. Currently, wav is the only supported format,
        /// and the extension must be “.wav”.
        /// <para>
        /// Note: the allegro_audio library does not support any audio file formats by default. You must use the
        /// allegro_acodec addon, or register your own format handler.
        /// </para>
        /// </summary>
        /// <param name="fp">The Allegro file.</param>
        /// <param name="ident">The identifying extension.</param>
        /// <param name="sample">The sample.</param>
        /// <returns>True on success, false on error. The file remains open afterwards.</returns>
        public static bool SaveSampleF(AllegroFile fp, string ident, AllegroSample sample)
            => al_save_sample_f(fp.NativeIntPtr, ident, sample.NativeIntPtr);

        #region P/Invokes
        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern bool al_install_audio();

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern void al_uninstall_audio();

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern bool al_is_audio_installed();

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern bool al_reserve_samples(int reserve_samples);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern uint al_get_allegro_audio_version();

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern UIntPtr al_get_audio_depth_size(int depth);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern UIntPtr al_get_channel_count(int conf);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern void al_fill_silence(IntPtr buf, uint samples, int depth, int chan_conf);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern IntPtr al_create_voice(uint freq, int depth, int chan_conf);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern void al_destroy_voice(IntPtr voice);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern void al_detach_voice(IntPtr voice);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern bool al_attach_audio_stream_to_voice(IntPtr stream, IntPtr voice);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern bool al_attach_mixer_to_voice(IntPtr mixer, IntPtr voice);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern bool al_attach_sample_instance_to_voice(IntPtr spl, IntPtr voice);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern uint al_get_voice_frequency(IntPtr voice);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern int al_get_voice_channels(IntPtr voice);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern int al_get_voice_depth(IntPtr voice);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern bool al_get_voice_playing(IntPtr voice);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern bool al_set_voice_playing(IntPtr voice, bool val);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern uint al_get_voice_position(IntPtr voice);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern bool al_set_voice_position(IntPtr voice, uint val);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern IntPtr al_create_sample(
            ref byte[] buf,
            uint samples,
            uint freq,
            int depth,
            int chan_conf,
            bool free_buf);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern void al_destroy_sample(IntPtr spl);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern bool al_play_sample(IntPtr spl, float gain, float pan, float speed, int loop, IntPtr ret_id);
        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern bool al_play_sample(IntPtr spl, float gain, float pan, float speed, int loop, ref NativeSampleId ret_id);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern void al_stop_sample(ref NativeSampleId spl_id);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern void al_stop_samples();

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern int al_get_sample_channels(IntPtr spl);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern int al_get_sample_depth(IntPtr spl);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern uint al_get_sample_frequency(IntPtr spl);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern uint al_get_sample_length(IntPtr spl);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern IntPtr al_get_sample_data(IntPtr spl);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern IntPtr al_create_sample_instance(IntPtr sample_data);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern void al_destroy_sample_instance(IntPtr spl);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern bool al_play_sample_instance(IntPtr spl);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern bool al_stop_sample_instance(IntPtr spl);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern int al_get_sample_instance_channels(IntPtr spl);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern int al_get_sample_instance_depth(IntPtr spl);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern uint al_get_sample_instance_frequency(IntPtr spl);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern uint al_get_sample_instance_length(IntPtr spl);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern bool al_set_sample_instance_length(IntPtr spl, uint val);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern uint al_get_sample_instance_position(IntPtr spl);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern bool al_set_sample_instance_position(IntPtr spl, uint val);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern float al_get_sample_instance_speed(IntPtr spl);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern bool al_set_sample_instance_speed(IntPtr spl, float val);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern float al_get_sample_instance_gain(IntPtr spl);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern bool al_set_sample_instance_gain(IntPtr spl, float val);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern float al_get_sample_instance_pan(IntPtr spl);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern bool al_set_sample_instance_pan(IntPtr spl, float val);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern float al_get_sample_instance_time(IntPtr spl);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern int al_get_sample_instance_playmode(IntPtr spl);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern bool al_set_sample_instance_playmode(IntPtr spl, int val);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern bool al_get_sample_instance_playing(IntPtr spl);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern bool al_set_sample_instance_playing(IntPtr spl, bool val);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern bool al_get_sample_instance_attached(IntPtr spl);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern bool al_detach_sample_instance(IntPtr spl);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern IntPtr al_get_sample(IntPtr spl);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern bool al_set_sample(IntPtr spl, IntPtr data);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern IntPtr al_create_mixer(uint freq, int depth, int chan_conf);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern void al_destroy_mixer(IntPtr mixer);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern IntPtr al_get_default_mixer();

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern bool al_set_default_mixer(IntPtr mixer);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern bool al_restore_default_mixer();

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern IntPtr al_get_default_voice();

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern void al_set_default_voice(IntPtr voice);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern bool al_attach_mixer_to_mixer(IntPtr stream, IntPtr mixer);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern bool al_attach_sample_instance_to_mixer(IntPtr spl, IntPtr mixer);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern bool al_attach_audio_stream_to_mixer(IntPtr stream, IntPtr mixer);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern uint al_get_mixer_frequency(IntPtr mixer);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern bool al_set_mixer_frequency(IntPtr mixer, uint val);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern int al_get_mixer_channels(IntPtr mixer);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern int al_get_mixer_depth(IntPtr mixer);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern float al_get_mixer_gain(IntPtr mixer);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern bool al_set_mixer_gain(IntPtr mixer, float new_gain);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern int al_get_mixer_quality(IntPtr mixer);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern bool al_set_mixer_quality(IntPtr mixer, int new_quality);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern bool al_get_mixer_playing(IntPtr mixer);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern bool al_set_mixer_playing(IntPtr mixer, bool val);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern bool al_get_mixer_attached(IntPtr mixer);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern bool al_detach_mixer(IntPtr mixer);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern bool al_set_mixer_postprocess_callback(IntPtr mixer, IntPtr pp_callback, IntPtr pp_callback_userdata);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern IntPtr al_create_audio_stream(UIntPtr fragment_count, uint frag_samples, uint freq, int depth, int chan_conf);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern void al_destroy_audio_stream(IntPtr stream);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern IntPtr al_get_audio_stream_event_source(IntPtr stream);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern void al_drain_audio_stream(IntPtr stream);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern bool al_rewind_audio_stream(IntPtr stream);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern uint al_get_audio_stream_frequency(IntPtr stream);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern int al_get_audio_stream_channels(IntPtr stream);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern int al_get_audio_stream_depth(IntPtr stream);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern uint al_get_audio_stream_length(IntPtr stream);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern float al_get_audio_stream_speed(IntPtr stream);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern bool al_set_audio_stream_speed(IntPtr stream, float val);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern float al_get_audio_stream_gain(IntPtr stream);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern bool al_set_audio_stream_gain(IntPtr stream, float val);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern float al_get_audio_stream_pan(IntPtr stream);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern bool al_set_audio_stream_pan(IntPtr stream, float val);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern bool al_get_audio_stream_playing(IntPtr stream);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern bool al_set_audio_stream_playing(IntPtr stream, bool val);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern int al_get_audio_stream_playmode(IntPtr stream);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern bool al_set_audio_stream_playmode(IntPtr stream, int val);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern bool al_get_audio_stream_attached(IntPtr stream);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern bool al_detach_audio_stream(IntPtr stream);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern ulong al_get_audio_stream_played_samples(IntPtr stream);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern IntPtr al_get_audio_stream_fragment(IntPtr stream);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern bool al_set_audio_stream_fragment(IntPtr stream, IntPtr val);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern uint al_get_audio_stream_fragments(IntPtr stream);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern uint al_get_available_audio_stream_fragments(IntPtr stream);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern bool al_seek_audio_stream_secs(IntPtr stream, double time);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern double al_get_audio_stream_position_secs(IntPtr stream);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern double al_get_audio_stream_length_secs(IntPtr stream);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern bool al_set_audio_stream_loop_secs(IntPtr stream, double start, double end);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern bool al_register_sample_loader(
            [MarshalAs(UnmanagedType.LPStr)] string ext,
            IntPtr loader);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern bool al_register_sample_loader_f(
            [MarshalAs(UnmanagedType.LPStr)] string ext,
            IntPtr loader);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern bool al_register_sample_saver(
            [MarshalAs(UnmanagedType.LPStr)] string ext,
            IntPtr saver);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern bool al_register_sample_saver_f(
            [MarshalAs(UnmanagedType.LPStr)] string ext,
            IntPtr saver);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern bool al_register_audio_stream_loader(
            [MarshalAs(UnmanagedType.LPStr)] string ext,
            IntPtr stream_loader);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern bool al_register_audio_stream_loader_f(
            [MarshalAs(UnmanagedType.LPStr)] string ext,
            IntPtr stream_loader);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern IntPtr al_load_sample([MarshalAs(UnmanagedType.LPStr)] string filename);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern IntPtr al_load_sample_f(IntPtr fp, [MarshalAs(UnmanagedType.LPStr)] string ident);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern IntPtr al_load_audio_stream(
            [MarshalAs(UnmanagedType.LPStr)] string filename,
            UIntPtr buffer_count,
            uint samples);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern IntPtr al_load_audio_stream_f(
            IntPtr fp,
            [MarshalAs(UnmanagedType.LPStr)] string ident,
            UIntPtr buffer_count,
            uint samples);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern bool al_save_sample([MarshalAs(UnmanagedType.LPStr)] string filename, IntPtr spl);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern bool al_save_sample_f(
            IntPtr fp,
            [MarshalAs(UnmanagedType.LPStr)] string ident,
            IntPtr spl);
        #endregion
    }
}
