using System.Runtime.InteropServices;

namespace SubC.AllegroDotNet.Native;

internal static partial class Interop
{
    public static AudioContext Audio => _audioContext ??= new();

    private static AudioContext? _audioContext;

    public sealed class AudioContext
    {
        #region Audio Routines

        public al_install_audio AlInstallAudio { get; }
        public al_uninstall_audio AlUninstallAudio { get; }
        public al_is_audio_installed AlIsAudioInstalled { get; }
        public al_reserve_samples AlReserveSamples { get; }
        public al_play_sample AlPlaySample { get; }
        public al_stop_sample AlStopSample { get; }
        public al_stop_samples AlStopSamples { get; }
        public al_create_sample AlCreateSample { get; }
        public al_load_sample AlLoadSample { get; }
        public al_load_sample_f AlLoadSampleF { get; }
        public al_save_sample AlSaveSample { get; }
        public al_save_sample_f AlSaveSampleF { get; }
        public al_destroy_sample AlDestroySample { get; }
        public al_get_sample_channels AlGetSampleChannels { get; }
        public al_get_sample_depth AlGetSampleDepth { get; }
        public al_get_sample_frequency AlGetSampleFrequency { get; }
        public al_get_sample_length AlGetSampleLength { get; }
        public al_get_sample_data AlGetSampleData { get; }
        public al_create_sample_instance AlCreateSampleInstance { get; }
        public al_destroy_sample_instance AlDestroySampleInstance { get; }
        public al_play_sample_instance AlPlaySampleInstance { get; }
        public al_stop_sample_instance AlStopSampleInstance { get; }
        public al_get_sample_instance_channels AlGetSampleInstanceChannels { get; }
        public al_get_sample_instance_depth AlGetSampleInstanceDepth { get; }
        public al_get_sample_instance_frequency AlGetSampleInstanceFrequency { get; }
        public al_get_sample_instance_length AlGetSampleInstanceLength { get; }
        public al_set_sample_instance_length AlSetSampleInstanceLength { get; }
        public al_get_sample_instance_position AlGetSampleInstancePosition { get; }
        public al_set_sample_instance_position AlSetSampleInstancePosition { get; }
        public al_get_sample_instance_speed AlGetSampleInstanceSpeed { get; }
        public al_set_sample_instance_speed AlSetSampleInstanceSpeed { get; }
        public al_get_sample_instance_gain AlGetSampleInstanceGain { get; }
        public al_set_sample_instance_gain AlSetSampleInstanceGain { get; }
        public al_get_sample_instance_pan AlGetSampleInstancePan { get; }
        public al_set_sample_instance_pan AlSetSampleInstancePan { get; }
        public al_get_sample_instance_time AlGetSampleInstanceTime { get; }
        public al_get_sample_instance_playmode AlGetSampleInstancePlaymode { get; }
        public al_set_sample_instance_playmode AlSetSampleInstancePlaymode { get; }
        public al_get_sample_instance_playing AlGetSampleInstancePlaying { get; }
        public al_set_sample_instance_playing AlSetSampleInstancePlaying { get; }
        public al_get_sample_instance_attached AlGetSampleInstanceAttached { get; }
        public al_detach_sample_instance AlDetachSampleInstance { get; }
        public al_get_sample AlGetSample { get; }
        public al_set_sample AlSetSample { get; }
        public al_create_audio_stream AlCreateAudioStream { get; }
        public al_load_audio_stream AlLoadAudioStream { get; }
        public al_load_audio_stream_f AlLoadAudioStreamF { get; }
        public al_destroy_audio_stream AlDestroyAudioStream { get; }
        public al_get_audio_stream_event_source AlGetAudioStreamEventSource { get; }
        public al_drain_audio_stream AlDrainAudioStream { get; }
        public al_rewind_audio_stream AlRewindAudioStream { get; }
        public al_get_audio_stream_frequency AlGetAudioStreamFrequency { get; }
        public al_get_audio_stream_channels AlGetAudioStreamChannels { get; }
        public al_get_audio_stream_depth AlGetAudioStreamDepth { get; }
        public al_get_audio_stream_length AlGetAudioStreamLength { get; }
        public al_get_audio_stream_speed AlGetAudioStreamSpeed { get; }
        public al_set_audio_stream_speed AlSetAudioStreamSpeed { get; }
        public al_get_audio_stream_gain AlGetAudioStreamGain { get; }
        public al_set_audio_stream_gain AlSetAudioStreamGain { get; }
        public al_get_audio_stream_pan AlGetAudioStreamPan { get; }
        public al_set_audio_stream_pan AlSetAudioStreamPan { get; }
        public al_get_audio_stream_playing AlGetAudioStreamPlaying { get; }
        public al_set_audio_stream_playing AlSetAudioStreamPlaying { get; }
        public al_get_audio_stream_playmode AlGetAudioStreamPlaymode { get; }
        public al_set_audio_stream_playmode AlSetAudioStreamPlaymode { get; }
        public al_get_audio_stream_attached AlGetAudioStreamAttached { get; }
        public al_detach_audio_stream AlDetachAudioStream { get; }
        public al_get_audio_stream_played_samples AlGetAudioStreamPlayedSamples { get; }
        public al_get_audio_stream_fragment AlGetAudioStreamFragment { get; }
        public al_set_audio_stream_fragment AlSetAudioStreamFragment { get; }
        public al_get_audio_stream_fragments AlGetAudioStreamFragments { get; }
        public al_get_available_audio_stream_fragments AlGetAvailableAudioStreamFragments { get; }
        public al_seek_audio_stream_secs AlSeekAudioStreamSecs { get; }
        public al_get_audio_stream_position_secs AlGetAudioStreamPositionSecs { get; }
        public al_get_audio_stream_length_secs AlGetAudioStreamLengthSecs { get; }
        public al_set_audio_stream_loop_secs AlSetAudioStreamLoopSecs { get; }
        public al_register_sample_loader AlRegisterSampleLoader { get; }
        public al_register_sample_loader_f AlRegisterSampleLoaderF { get; }
        public al_register_sample_saver AlRegisterSampleSaver { get; }
        public al_register_sample_saver_f AlRegisterSampleSaverF { get; }
        public al_register_audio_stream_loader AlRegisterAudioStreamLoader { get; }
        public al_register_audio_stream_loader_f AlRegisterAudioStreamLoaderF { get; }
        public al_register_sample_identifier AlRegisterSampleIdentifier { get; }
        public al_identify_sample AlIdentifySample { get; }
        public al_identify_sample_f AlIdentifySampleF { get; }
        public al_get_num_audio_output_devices AlGetNumAudioOutputDevices { get; }
        public al_get_audio_output_device AlGetAudioOutputDevice { get; }
        public al_get_audio_device_name AlGetAudioDeviceName { get; }
        public al_create_voice AlCreateVoice { get; }
        public al_destroy_voice AlDestroyVoice { get; }
        public al_detach_voice AlDetachVoice { get; }
        public al_attach_audio_stream_to_voice AlAttachAudioStreamToVoice { get; }
        public al_attach_mixer_to_voice AlAttachMixerToVoice { get; }
        public al_attach_sample_instance_to_voice AlAttachSampleInstanceToVoice { get; }
        public al_get_voice_frequency AlGetVoiceFrequency { get; }
        public al_get_voice_channels AlGetVoiceChannels { get; }
        public al_get_voice_depth AlGetVoiceDepth { get; }
        public al_get_voice_playing AlGetVoicePlaying { get; }
        public al_set_voice_playing AlSetVoicePlaying { get; }
        public al_get_voice_position AlGetVoicePosition { get; }
        public al_set_voice_position AlSetVoicePosition { get; }
        public al_create_mixer AlCreateMixer { get; }
        public al_destroy_mixer AlDestroyMixer { get; }
        public al_get_default_mixer AlGetDefaultMixer { get; }
        public al_set_default_mixer AlSetDefaultMixer { get; }
        public al_restore_default_mixer AlRestoreDefaultMixer { get; }
        public al_get_default_voice AlGetDefaultVoice { get; }
        public al_set_default_voice AlSetDefaultVoice { get; }
        public al_attach_mixer_to_mixer AlAttachMixerToMixer { get; }
        public al_attach_sample_instance_to_mixer AlAttachSampleInstanceToMixer { get; }
        public al_attach_audio_stream_to_mixer AlAttachAudioStreamToMixer { get; }
        public al_get_mixer_frequency AlGetMixerFrequency { get; }
        public al_set_mixer_frequency AlSetMixerFrequency { get; }
        public al_get_mixer_channels AlGetMixerChannels { get; }
        public al_get_mixer_depth AlGetMixerDepth { get; }
        public al_get_mixer_gain AlGetMixerGain { get; }
        public al_set_mixer_gain AlSetMixerGain { get; }
        public al_get_mixer_quality AlGetMixerQuality { get; }
        public al_set_mixer_quality AlSetMixerQuality { get; }
        public al_get_mixer_playing AlGetMixerPlaying { get; }
        public al_set_mixer_playing AlSetMixerPlaying { get; }
        public al_get_mixer_attached AlGetMixerAttached { get; }
        public al_detach_mixer AlDetachMixer { get; }
        public al_set_mixer_postprocess_callback AlSetMixerPostprocessCallback { get; }
        public al_get_allegro_audio_version AlGetAllegroAudioVersion { get; }
        public al_get_audio_depth_size AlGetAudioDepthSize { get; }
        public al_get_channel_count AlGetChannelCount { get; }
        public al_fill_silence AlFillSilence { get; }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate byte al_install_audio();

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_uninstall_audio();

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate byte al_is_audio_installed();

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate byte al_reserve_samples(int reserve_samples);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate byte al_play_sample(IntPtr spl, float gain, float pan, float speed, int loop, IntPtr ret_id);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_stop_sample(IntPtr spl_id);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_stop_samples();

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_create_sample(byte[] buf, uint samples, uint freq, int depth, int chan_conf, byte free_buf);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_load_sample(IntPtr filename);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_load_sample_f(IntPtr fp, IntPtr ident);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate byte al_save_sample(IntPtr filename, IntPtr spl);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate byte al_save_sample_f(IntPtr fp, IntPtr ident, IntPtr spl);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_destroy_sample(IntPtr spl);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int al_get_sample_channels(IntPtr spl);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int al_get_sample_depth(IntPtr spl);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate uint al_get_sample_frequency(IntPtr spl);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate uint al_get_sample_length(IntPtr spl);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_get_sample_data(IntPtr spl);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_create_sample_instance(IntPtr sample_data);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_destroy_sample_instance(IntPtr spl);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate byte al_play_sample_instance(IntPtr spl);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate byte al_stop_sample_instance(IntPtr spl);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int al_get_sample_instance_channels(IntPtr spl);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int al_get_sample_instance_depth(IntPtr spl);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate uint al_get_sample_instance_frequency(IntPtr spl);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate uint al_get_sample_instance_length(IntPtr spl);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate byte al_set_sample_instance_length(IntPtr spl, uint val);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate uint al_get_sample_instance_position(IntPtr spl);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate byte al_set_sample_instance_position(IntPtr spl, uint val);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate float al_get_sample_instance_speed(IntPtr spl);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate byte al_set_sample_instance_speed(IntPtr spl, float val);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate float al_get_sample_instance_gain(IntPtr spl);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate byte al_set_sample_instance_gain(IntPtr spl, float val);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate float al_get_sample_instance_pan(IntPtr spl);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate byte al_set_sample_instance_pan(IntPtr spl, float val);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate float al_get_sample_instance_time(IntPtr spl);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int al_get_sample_instance_playmode(IntPtr spl);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate byte al_set_sample_instance_playmode(IntPtr spl, int val);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate byte al_get_sample_instance_playing(IntPtr spl);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate byte al_set_sample_instance_playing(IntPtr spl, byte val);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate byte al_get_sample_instance_attached(IntPtr spl);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate byte al_detach_sample_instance(IntPtr spl);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_get_sample(IntPtr spl);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate byte al_set_sample(IntPtr spl, IntPtr data);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_create_audio_stream(long fragment_count, uint frag_samples, uint freq, int depth, int chan_conf);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_load_audio_stream(IntPtr filename, long buffer_count, uint samples);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_load_audio_stream_f(IntPtr fp, IntPtr ident, long buffer_count, uint samples);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_destroy_audio_stream(IntPtr stream);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_get_audio_stream_event_source(IntPtr stream);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_drain_audio_stream(IntPtr stream);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate byte al_rewind_audio_stream(IntPtr stream);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate uint al_get_audio_stream_frequency(IntPtr stream);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int al_get_audio_stream_channels(IntPtr stream);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int al_get_audio_stream_depth(IntPtr stream);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate uint al_get_audio_stream_length(IntPtr stream);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate float al_get_audio_stream_speed(IntPtr stream);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate byte al_set_audio_stream_speed(IntPtr stream, float val);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate float al_get_audio_stream_gain(IntPtr stream);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate byte al_set_audio_stream_gain(IntPtr stream, float val);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate float al_get_audio_stream_pan(IntPtr stream);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate byte al_set_audio_stream_pan(IntPtr stream, float val);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate byte al_get_audio_stream_playing(IntPtr stream);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate byte al_set_audio_stream_playing(IntPtr stream, byte val);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int al_get_audio_stream_playmode(IntPtr stream);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate byte al_set_audio_stream_playmode(IntPtr stream, int val);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate byte al_get_audio_stream_attached(IntPtr stream);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate byte al_detach_audio_stream(IntPtr stream);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate ulong al_get_audio_stream_played_samples(IntPtr stream);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_get_audio_stream_fragment(IntPtr stream);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate byte al_set_audio_stream_fragment(IntPtr stream, IntPtr val);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate uint al_get_audio_stream_fragments(IntPtr stream);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate uint al_get_available_audio_stream_fragments(IntPtr stream);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate byte al_seek_audio_stream_secs(IntPtr stream, double time);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate double al_get_audio_stream_position_secs(IntPtr stream);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate double al_get_audio_stream_length_secs(IntPtr stream);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate byte al_set_audio_stream_loop_secs(IntPtr stream, double start, double end);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate byte al_register_sample_loader(IntPtr ext, Delegates.RegisterSampleLoaderDelegate loader);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate byte al_register_sample_loader_f(IntPtr ext, Delegates.RegisterSampleLoaderFDelegate loader);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate byte al_register_sample_saver(IntPtr ext, Delegates.RegisterSampleSaverDelegate saver);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate byte al_register_sample_saver_f(IntPtr ext, Delegates.RegisterSampleSaverFDelegate saver);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate byte al_register_audio_stream_loader(IntPtr ext, Delegates.RegisterAudioStreamLoader loader);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate byte al_register_audio_stream_loader_f(IntPtr ext, Delegates.RegisterAudioStreamFLoader loader);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate byte al_register_sample_identifier(IntPtr ext, Delegates.RegisterSampleIdentifierDelegate identifier);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_identify_sample(IntPtr filename);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_identify_sample_f(IntPtr fp);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int al_get_num_audio_output_devices();

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_get_audio_output_device(int index);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_get_audio_device_name(IntPtr device);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_create_voice(uint freq, int depth, int chan_conf);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_destroy_voice(IntPtr voice);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_detach_voice(IntPtr voice);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate byte al_attach_audio_stream_to_voice(IntPtr stream, IntPtr voice);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate byte al_attach_mixer_to_voice(IntPtr mixer, IntPtr voice);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate byte al_attach_sample_instance_to_voice(IntPtr spl, IntPtr voice);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate uint al_get_voice_frequency(IntPtr voice);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int al_get_voice_channels(IntPtr voice);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int al_get_voice_depth(IntPtr voice);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate byte al_get_voice_playing(IntPtr voice);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate byte al_set_voice_playing(IntPtr voice, byte val);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate uint al_get_voice_position(IntPtr voice);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate byte al_set_voice_position(IntPtr voice, uint val);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate byte al_voice_has_attachments(IntPtr voice);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_create_mixer(uint freq, int depth, int chan_conf);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_destroy_mixer(IntPtr mixer);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_get_default_mixer();

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate byte al_set_default_mixer(IntPtr mixer);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate byte al_restore_default_mixer();

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_get_default_voice();

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_set_default_voice(IntPtr voice);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate byte al_attach_mixer_to_mixer(IntPtr stream, IntPtr mixer);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate byte al_attach_sample_instance_to_mixer(IntPtr spl, IntPtr mixer);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate byte al_attach_audio_stream_to_mixer(IntPtr stream, IntPtr mixer);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate uint al_get_mixer_frequency(IntPtr mixer);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate byte al_set_mixer_frequency(IntPtr mixer, uint val);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int al_get_mixer_channels(IntPtr mixer);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int al_get_mixer_depth(IntPtr mixer);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate float al_get_mixer_gain(IntPtr mixer);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate byte al_set_mixer_gain(IntPtr mixer, float gain);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int al_get_mixer_quality(IntPtr mixer);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate byte al_set_mixer_quality(IntPtr mixer, int new_quality);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate byte al_get_mixer_playing(IntPtr mixer);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate byte al_set_mixer_playing(IntPtr mixer, byte val);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate byte al_get_mixer_attached(IntPtr mixer);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate byte al_mixer_has_attachments(IntPtr mixer);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate byte al_detach_mixer(IntPtr mixer);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate byte al_set_mixer_postprocess_callback(
          IntPtr mixer,
          Delegates.SetMixerPostProcessCallbackDelegate pp_callback,
          IntPtr pp_userdata);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate uint al_get_allegro_audio_version();

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate UIntPtr al_get_audio_depth_size(int depth);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate UIntPtr al_get_channel_count(int conf);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_fill_silence(IntPtr buf, uint samples, int depth, int chan_conf);

        #endregion

        public AudioContext()
        {
            AlInstallAudio = LoadFunction<al_install_audio>();
            AlUninstallAudio = LoadFunction<al_uninstall_audio>();
            AlIsAudioInstalled = LoadFunction<al_is_audio_installed>();
            AlReserveSamples = LoadFunction<al_reserve_samples>();
            AlPlaySample = LoadFunction<al_play_sample>();
            AlStopSample = LoadFunction<al_stop_sample>();
            AlStopSamples = LoadFunction<al_stop_samples>();
            AlCreateSample = LoadFunction<al_create_sample>();
            AlLoadSample = LoadFunction<al_load_sample>();
            AlLoadSampleF = LoadFunction<al_load_sample_f>();
            AlSaveSample = LoadFunction<al_save_sample>();
            AlSaveSampleF = LoadFunction<al_save_sample_f>();
            AlDestroySample = LoadFunction<al_destroy_sample>();
            AlGetSampleChannels = LoadFunction<al_get_sample_channels>();
            AlGetSampleDepth = LoadFunction<al_get_sample_depth>();
            AlGetSampleFrequency = LoadFunction<al_get_sample_frequency>();
            AlGetSampleLength = LoadFunction<al_get_sample_length>();
            AlGetSampleData = LoadFunction<al_get_sample_data>();
            AlCreateSampleInstance = LoadFunction<al_create_sample_instance>();
            AlDestroySampleInstance = LoadFunction<al_destroy_sample_instance>();
            AlPlaySampleInstance = LoadFunction<al_play_sample_instance>();
            AlStopSampleInstance = LoadFunction<al_stop_sample_instance>();
            AlGetSampleInstanceChannels = LoadFunction<al_get_sample_instance_channels>();
            AlGetSampleInstanceDepth = LoadFunction<al_get_sample_instance_depth>();
            AlGetSampleInstanceFrequency = LoadFunction<al_get_sample_instance_frequency>();
            AlGetSampleInstanceLength = LoadFunction<al_get_sample_instance_length>();
            AlSetSampleInstanceLength = LoadFunction<al_set_sample_instance_length>();
            AlGetSampleInstancePosition = LoadFunction<al_get_sample_instance_position>();
            AlSetSampleInstancePosition = LoadFunction<al_set_sample_instance_position>();
            AlGetSampleInstanceSpeed = LoadFunction<al_get_sample_instance_speed>();
            AlSetSampleInstanceSpeed = LoadFunction<al_set_sample_instance_speed>();
            AlGetSampleInstanceGain = LoadFunction<al_get_sample_instance_gain>();
            AlSetSampleInstanceGain = LoadFunction<al_set_sample_instance_gain>();
            AlGetSampleInstancePan = LoadFunction<al_get_sample_instance_pan>();
            AlSetSampleInstancePan = LoadFunction<al_set_sample_instance_pan>();
            AlGetSampleInstanceTime = LoadFunction<al_get_sample_instance_time>();
            AlGetSampleInstancePlaymode = LoadFunction<al_get_sample_instance_playmode>();
            AlSetSampleInstancePlaymode = LoadFunction<al_set_sample_instance_playmode>();
            AlGetSampleInstancePlaying = LoadFunction<al_get_sample_instance_playing>();
            AlSetSampleInstancePlaying = LoadFunction<al_set_sample_instance_playing>();
            AlGetSampleInstanceAttached = LoadFunction<al_get_sample_instance_attached>();
            AlDetachSampleInstance = LoadFunction<al_detach_sample_instance>();
            AlGetSample = LoadFunction<al_get_sample>();
            AlSetSample = LoadFunction<al_set_sample>();
            AlCreateAudioStream = LoadFunction<al_create_audio_stream>();
            AlLoadAudioStream = LoadFunction<al_load_audio_stream>();
            AlLoadAudioStreamF = LoadFunction<al_load_audio_stream_f>();
            AlDestroyAudioStream = LoadFunction<al_destroy_audio_stream>();
            AlGetAudioStreamEventSource = LoadFunction<al_get_audio_stream_event_source>();
            AlDrainAudioStream = LoadFunction<al_drain_audio_stream>();
            AlRewindAudioStream = LoadFunction<al_rewind_audio_stream>();
            AlGetAudioStreamFrequency = LoadFunction<al_get_audio_stream_frequency>();
            AlGetAudioStreamChannels = LoadFunction<al_get_audio_stream_channels>();
            AlGetAudioStreamDepth = LoadFunction<al_get_audio_stream_depth>();
            AlGetAudioStreamLength = LoadFunction<al_get_audio_stream_length>();
            AlGetAudioStreamSpeed = LoadFunction<al_get_audio_stream_speed>();
            AlSetAudioStreamSpeed = LoadFunction<al_set_audio_stream_speed>();
            AlGetAudioStreamGain = LoadFunction<al_get_audio_stream_gain>();
            AlSetAudioStreamGain = LoadFunction<al_set_audio_stream_gain>();
            AlGetAudioStreamPan = LoadFunction<al_get_audio_stream_pan>();
            AlSetAudioStreamPan = LoadFunction<al_set_audio_stream_pan>();
            AlGetAudioStreamPlaying = LoadFunction<al_get_audio_stream_playing>();
            AlSetAudioStreamPlaying = LoadFunction<al_set_audio_stream_playing>();
            AlGetAudioStreamPlaymode = LoadFunction<al_get_audio_stream_playmode>();
            AlSetAudioStreamPlaymode = LoadFunction<al_set_audio_stream_playmode>();
            AlGetAudioStreamAttached = LoadFunction<al_get_audio_stream_attached>();
            AlDetachAudioStream = LoadFunction<al_detach_audio_stream>();
            AlGetAudioStreamPlayedSamples = LoadFunction<al_get_audio_stream_played_samples>();
            AlGetAudioStreamFragment = LoadFunction<al_get_audio_stream_fragment>();
            AlSetAudioStreamFragment = LoadFunction<al_set_audio_stream_fragment>();
            AlGetAudioStreamFragments = LoadFunction<al_get_audio_stream_fragments>();
            AlGetAvailableAudioStreamFragments = LoadFunction<al_get_available_audio_stream_fragments>();
            AlSeekAudioStreamSecs = LoadFunction<al_seek_audio_stream_secs>();
            AlGetAudioStreamPositionSecs = LoadFunction<al_get_audio_stream_position_secs>();
            AlGetAudioStreamLengthSecs = LoadFunction<al_get_audio_stream_length_secs>();
            AlSetAudioStreamLoopSecs = LoadFunction<al_set_audio_stream_loop_secs>();
            AlRegisterSampleLoader = LoadFunction<al_register_sample_loader>();
            AlRegisterSampleLoaderF = LoadFunction<al_register_sample_loader_f>();
            AlRegisterSampleSaver = LoadFunction<al_register_sample_saver>();
            AlRegisterSampleSaverF = LoadFunction<al_register_sample_saver_f>();
            AlRegisterAudioStreamLoader = LoadFunction<al_register_audio_stream_loader>();
            AlRegisterAudioStreamLoaderF = LoadFunction<al_register_audio_stream_loader_f>();
            AlRegisterSampleIdentifier = LoadFunction<al_register_sample_identifier>();
            AlIdentifySample = LoadFunction<al_identify_sample>();
            AlIdentifySampleF = LoadFunction<al_identify_sample_f>();
            AlGetNumAudioOutputDevices = LoadFunction<al_get_num_audio_output_devices>();
            AlGetAudioOutputDevice = LoadFunction<al_get_audio_output_device>();
            AlGetAudioDeviceName = LoadFunction<al_get_audio_device_name>();
            AlCreateVoice = LoadFunction<al_create_voice>();
            AlDestroyVoice = LoadFunction<al_destroy_voice>();
            AlDetachVoice = LoadFunction<al_detach_voice>();
            AlAttachAudioStreamToVoice = LoadFunction<al_attach_audio_stream_to_voice>();
            AlAttachMixerToVoice = LoadFunction<al_attach_mixer_to_voice>();
            AlAttachSampleInstanceToVoice = LoadFunction<al_attach_sample_instance_to_voice>();
            AlGetVoiceFrequency = LoadFunction<al_get_voice_frequency>();
            AlGetVoiceChannels = LoadFunction<al_get_voice_channels>();
            AlGetVoiceDepth = LoadFunction<al_get_voice_depth>();
            AlGetVoicePlaying = LoadFunction<al_get_voice_playing>();
            AlSetVoicePlaying = LoadFunction<al_set_voice_playing>();
            AlGetVoicePosition = LoadFunction<al_get_voice_position>();
            AlSetVoicePosition = LoadFunction<al_set_voice_position>();
            AlCreateMixer = LoadFunction<al_create_mixer>();
            AlDestroyMixer = LoadFunction<al_destroy_mixer>();
            AlGetDefaultMixer = LoadFunction<al_get_default_mixer>();
            AlSetDefaultMixer = LoadFunction<al_set_default_mixer>();
            AlRestoreDefaultMixer = LoadFunction<al_restore_default_mixer>();
            AlGetDefaultVoice = LoadFunction<al_get_default_voice>();
            AlSetDefaultVoice = LoadFunction<al_set_default_voice>();
            AlAttachMixerToMixer = LoadFunction<al_attach_mixer_to_mixer>();
            AlAttachSampleInstanceToMixer = LoadFunction<al_attach_sample_instance_to_mixer>();
            AlAttachAudioStreamToMixer = LoadFunction<al_attach_audio_stream_to_mixer>();
            AlGetMixerFrequency = LoadFunction<al_get_mixer_frequency>();
            AlSetMixerFrequency = LoadFunction<al_set_mixer_frequency>();
            AlGetMixerChannels = LoadFunction<al_get_mixer_channels>();
            AlGetMixerDepth = LoadFunction<al_get_mixer_depth>();
            AlGetMixerGain = LoadFunction<al_get_mixer_gain>();
            AlSetMixerGain = LoadFunction<al_set_mixer_gain>();
            AlGetMixerQuality = LoadFunction<al_get_mixer_quality>();
            AlSetMixerQuality = LoadFunction<al_set_mixer_quality>();
            AlGetMixerPlaying = LoadFunction<al_get_mixer_playing>();
            AlSetMixerPlaying = LoadFunction<al_set_mixer_playing>();
            AlGetMixerAttached = LoadFunction<al_get_mixer_attached>();
            AlDetachMixer = LoadFunction<al_detach_mixer>();
            AlSetMixerPostprocessCallback = LoadFunction<al_set_mixer_postprocess_callback>();
            AlGetAllegroAudioVersion = LoadFunction<al_get_allegro_audio_version>();
            AlGetAudioDepthSize = LoadFunction<al_get_audio_depth_size>();
            AlGetChannelCount = LoadFunction<al_get_channel_count>();
            AlFillSilence = LoadFunction<al_fill_silence>();
        }
    }
}
