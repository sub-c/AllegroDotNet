using System;
using System.Runtime.InteropServices;
using SubC.AllegroDotNet.Enums;
using SubC.AllegroDotNet.Models;

namespace SubC.AllegroDotNet.Native.Libraries
{
    internal static class AllegroLibrary
    {
        private static readonly IntPtr _nativeAllegroLibrary = NativeLibrary.LoadAllegroLibrary();

        #region Audio addon
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_install_audio();
        public static al_install_audio AlInstallAudio =
            NativeLibrary.LoadNativeFunction<al_install_audio>(_nativeAllegroLibrary, "al_install_audio");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_uninstall_audio();
        public static al_uninstall_audio AlUninstallAudio =
            NativeLibrary.LoadNativeFunction<al_uninstall_audio>(_nativeAllegroLibrary, "al_uninstall_audio");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_is_audio_installed();
        public static al_is_audio_installed AlIsAudioInstalled =
            NativeLibrary.LoadNativeFunction<al_is_audio_installed>(_nativeAllegroLibrary, "al_is_audio_installed");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_reserve_samples(int reserve_samples);
        public static al_reserve_samples AlReserveSamples =
            NativeLibrary.LoadNativeFunction<al_reserve_samples>(_nativeAllegroLibrary, "al_reserve_samples");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate uint al_get_allegro_audio_version();
        public static al_get_allegro_audio_version AlGetAllegroAudioVersion =
            NativeLibrary.LoadNativeFunction<al_get_allegro_audio_version>(_nativeAllegroLibrary, "al_get_allegro_audio_version");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate UIntPtr al_get_audio_depth_size(int depth);
        public static al_get_audio_depth_size AlGetAudioDepthSize =
            NativeLibrary.LoadNativeFunction<al_get_audio_depth_size>(_nativeAllegroLibrary, "al_get_audio_depth_size");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate UIntPtr al_get_channel_count(int conf);
        public static al_get_channel_count AlGetChannelCount =
            NativeLibrary.LoadNativeFunction<al_get_channel_count>(_nativeAllegroLibrary, "al_get_channel_count");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_fill_silence(IntPtr buf, uint samples, int depth, int chan_conf);
        public static al_fill_silence AlFillSilence =
            NativeLibrary.LoadNativeFunction<al_fill_silence>(_nativeAllegroLibrary, "al_fill_silence");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_create_voice(uint freq, int depth, int chan_conf);
        public static al_create_voice AlCreateVoice =
            NativeLibrary.LoadNativeFunction<al_create_voice>(_nativeAllegroLibrary, "al_create_voice");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_destroy_voice(IntPtr voice);
        public static al_destroy_voice AlDestroyVoice =
            NativeLibrary.LoadNativeFunction<al_destroy_voice>(_nativeAllegroLibrary, "al_destroy_voice");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_detach_voice(IntPtr voice);
        public static al_detach_voice AlDetachVoice =
            NativeLibrary.LoadNativeFunction<al_detach_voice>(_nativeAllegroLibrary, "al_detach_voice");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_attach_audio_stream_to_voice(IntPtr stream, IntPtr voice);
        public static al_attach_audio_stream_to_voice AlAttachAudioStreamToVoice =
            NativeLibrary.LoadNativeFunction<al_attach_audio_stream_to_voice>(_nativeAllegroLibrary, "al_attach_audio_stream_to_voice");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_attach_mixer_to_voice(IntPtr mixer, IntPtr voice);
        public static al_attach_mixer_to_voice AlAttachMixerToVoice =
            NativeLibrary.LoadNativeFunction<al_attach_mixer_to_voice>(_nativeAllegroLibrary, "al_attach_mixer_to_voice");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_attach_sample_instance_to_voice(IntPtr spl, IntPtr voice);
        public static al_attach_sample_instance_to_voice AlAttachSampleInstanceToVoice =
            NativeLibrary.LoadNativeFunction<al_attach_sample_instance_to_voice>(_nativeAllegroLibrary, "al_attach_sample_instance_to_voice");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate uint al_get_voice_frequency(IntPtr voice);
        public static al_get_voice_frequency AlGetVoiceFrequency =
            NativeLibrary.LoadNativeFunction<al_get_voice_frequency>(_nativeAllegroLibrary, "al_get_voice_frequency");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int al_get_voice_channels(IntPtr voice);
        public static al_get_voice_channels AlGetVoiceChannels =
            NativeLibrary.LoadNativeFunction<al_get_voice_channels>(_nativeAllegroLibrary, "al_get_voice_channels");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int al_get_voice_depth(IntPtr voice);
        public static al_get_voice_depth AlGetVoiceDepth =
            NativeLibrary.LoadNativeFunction<al_get_voice_depth>(_nativeAllegroLibrary, "al_get_voice_depth");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_get_voice_playing(IntPtr voice);
        public static al_get_voice_playing AlGetVoicePlaying =
            NativeLibrary.LoadNativeFunction<al_get_voice_playing>(_nativeAllegroLibrary, "al_get_voice_playing");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_set_voice_playing(IntPtr voice, bool val);
        public static al_set_voice_playing AlSetVoicePlaying =
            NativeLibrary.LoadNativeFunction<al_set_voice_playing>(_nativeAllegroLibrary, "al_set_voice_playing");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate uint al_get_voice_position(IntPtr voice);
        public static al_get_voice_position AlGetVoicePosition =
            NativeLibrary.LoadNativeFunction<al_get_voice_position>(_nativeAllegroLibrary, "al_get_voice_position");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_set_voice_position(IntPtr voice, uint val);
        public static al_set_voice_position AlSetVoicePosition =
            NativeLibrary.LoadNativeFunction<al_set_voice_position>(_nativeAllegroLibrary, "al_set_voice_position");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_create_sample(ref byte[] buf, uint samples, uint freq, int depth, int chan_conf, bool free_buf);
        public static al_create_sample AlCreateSample =
            NativeLibrary.LoadNativeFunction<al_create_sample>(_nativeAllegroLibrary, "al_create_sample");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_destroy_sample(IntPtr spl);
        public static al_destroy_sample AlDestroySample =
            NativeLibrary.LoadNativeFunction<al_destroy_sample>(_nativeAllegroLibrary, "al_destroy_sample");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_play_sample(IntPtr spl, float gain, float pan, float speed, int loop, IntPtr ret_id);
        public static al_play_sample AlPlaySample =
            NativeLibrary.LoadNativeFunction<al_play_sample>(_nativeAllegroLibrary, "al_play_sample");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_stop_sample(ref NativeSampleId spl_id);
        public static al_stop_sample AlStopSample =
            NativeLibrary.LoadNativeFunction<al_stop_sample>(_nativeAllegroLibrary, "al_stop_sample");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_stop_samples();
        public static al_stop_samples AlStopSamples =
            NativeLibrary.LoadNativeFunction<al_stop_samples>(_nativeAllegroLibrary, "al_stop_samples");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int al_get_sample_channels(IntPtr spl);
        public static al_get_sample_channels AlGetSampleChannels =
            NativeLibrary.LoadNativeFunction<al_get_sample_channels>(_nativeAllegroLibrary, "al_get_sample_channels");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int al_get_sample_depth(IntPtr spl);
        public static al_get_sample_depth AlGetSampleDepth =
            NativeLibrary.LoadNativeFunction<al_get_sample_depth>(_nativeAllegroLibrary, "al_get_sample_depth");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate uint al_get_sample_frequency(IntPtr spl);
        public static al_get_sample_frequency AlGetSampleFrequency =
            NativeLibrary.LoadNativeFunction<al_get_sample_frequency>(_nativeAllegroLibrary, "al_get_sample_frequency");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate uint al_get_sample_length(IntPtr spl);
        public static al_get_sample_length AlGetSampleLength =
            NativeLibrary.LoadNativeFunction<al_get_sample_length>(_nativeAllegroLibrary, "al_get_sample_length");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_get_sample_data(IntPtr spl);
        public static al_get_sample_data AlGetSampleData =
            NativeLibrary.LoadNativeFunction<al_get_sample_data>(_nativeAllegroLibrary, "al_get_sample_data");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_create_sample_instance(IntPtr sample_data);
        public static al_create_sample_instance AlCreateSampleInstance =
            NativeLibrary.LoadNativeFunction<al_create_sample_instance>(_nativeAllegroLibrary, "al_create_sample_instance");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_destroy_sample_instance(IntPtr spl);
        public static al_destroy_sample_instance AlDestroySampleInstance =
            NativeLibrary.LoadNativeFunction<al_destroy_sample_instance>(_nativeAllegroLibrary, "al_destroy_sample_instance");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_play_sample_instance(IntPtr spl);
        public static al_play_sample_instance AlPlaySampleInstance =
            NativeLibrary.LoadNativeFunction<al_play_sample_instance>(_nativeAllegroLibrary, "al_play_sample_instance");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_stop_sample_instance(IntPtr spl);
        public static al_stop_sample_instance AlStopSampleInstance =
            NativeLibrary.LoadNativeFunction<al_stop_sample_instance>(_nativeAllegroLibrary, "al_stop_sample_instance");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int al_get_sample_instance_channels(IntPtr spl);
        public static al_get_sample_instance_channels AlGetSampleInstanceChannels =
            NativeLibrary.LoadNativeFunction<al_get_sample_instance_channels>(_nativeAllegroLibrary, "al_get_sample_instance_channels");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int al_get_sample_instance_depth(IntPtr spl);
        public static al_get_sample_instance_depth AlGetSampleInstanceDepth =
            NativeLibrary.LoadNativeFunction<al_get_sample_instance_depth>(_nativeAllegroLibrary, "al_get_sample_instance_depth");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate uint al_get_sample_instance_frequency(IntPtr spl);
        public static al_get_sample_instance_frequency AlGetSampleInstanceFrequency =
            NativeLibrary.LoadNativeFunction<al_get_sample_instance_frequency>(_nativeAllegroLibrary, "al_get_sample_instance_frequency");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate uint al_get_sample_instance_length(IntPtr spl);
        public static al_get_sample_instance_length AlGetSampleInstanceLength =
            NativeLibrary.LoadNativeFunction<al_get_sample_instance_length>(_nativeAllegroLibrary, "al_get_sample_instance_length");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_set_sample_instance_length(IntPtr spl, uint val);
        public static al_set_sample_instance_length AlSetSampleInstanceLength =
            NativeLibrary.LoadNativeFunction<al_set_sample_instance_length>(_nativeAllegroLibrary, "al_set_sample_instance_length");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate uint al_get_sample_instance_position(IntPtr spl);
        public static al_get_sample_instance_position AlGetSampleInstancePosition =
            NativeLibrary.LoadNativeFunction<al_get_sample_instance_position>(_nativeAllegroLibrary, "al_get_sample_instance_position");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_set_sample_instance_position(IntPtr spl, uint val);
        public static al_set_sample_instance_position AlSetSampleInstancePosition =
            NativeLibrary.LoadNativeFunction<al_set_sample_instance_position>(_nativeAllegroLibrary, "al_set_sample_instance_position");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate float al_get_sample_instance_speed(IntPtr spl);
        public static al_get_sample_instance_speed AlGetSampleInstanceSpeed =
            NativeLibrary.LoadNativeFunction<al_get_sample_instance_speed>(_nativeAllegroLibrary, "al_get_sample_instance_speed");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_set_sample_instance_speed(IntPtr spl, float val);
        public static al_set_sample_instance_speed AlSetSampleInstanceSpeed =
            NativeLibrary.LoadNativeFunction<al_set_sample_instance_speed>(_nativeAllegroLibrary, "al_set_sample_instance_speed");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate float al_get_sample_instance_gain(IntPtr spl);
        public static al_get_sample_instance_gain AlGetSampleInstanceGain =
            NativeLibrary.LoadNativeFunction<al_get_sample_instance_gain>(_nativeAllegroLibrary, "al_get_sample_instance_gain");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_set_sample_instance_gain(IntPtr spl, float val);
        public static al_set_sample_instance_gain AlSetSampleInstanceGain =
            NativeLibrary.LoadNativeFunction<al_set_sample_instance_gain>(_nativeAllegroLibrary, "al_set_sample_instance_gain");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate float al_get_sample_instance_pan(IntPtr spl);
        public static al_get_sample_instance_pan AlGetSampleInstancePan =
            NativeLibrary.LoadNativeFunction<al_get_sample_instance_pan>(_nativeAllegroLibrary, "al_get_sample_instance_pan");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_set_sample_instance_pan(IntPtr spl, float val);
        public static al_set_sample_instance_pan AlSetSampleInstancePan =
            NativeLibrary.LoadNativeFunction<al_set_sample_instance_pan>(_nativeAllegroLibrary, "al_set_sample_instance_pan");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate float al_get_sample_instance_time(IntPtr spl);
        public static al_get_sample_instance_time AlGetSampleInstanceTime =
            NativeLibrary.LoadNativeFunction<al_get_sample_instance_time>(_nativeAllegroLibrary, "al_get_sample_instance_time");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int al_get_sample_instance_playmode(IntPtr spl);
        public static al_get_sample_instance_playmode AlGetSampleInstancePlaymode =
            NativeLibrary.LoadNativeFunction<al_get_sample_instance_playmode>(_nativeAllegroLibrary, "al_get_sample_instance_playmode");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_set_sample_instance_playmode(IntPtr spl, int val);
        public static al_set_sample_instance_playmode AlSetSampleInstancePlaymode =
            NativeLibrary.LoadNativeFunction<al_set_sample_instance_playmode>(_nativeAllegroLibrary, "al_set_sample_instance_playmode");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_get_sample_instance_playing(IntPtr spl);
        public static al_get_sample_instance_playing AlGetSampleInstancePlaying =
            NativeLibrary.LoadNativeFunction<al_get_sample_instance_playing>(_nativeAllegroLibrary, "al_get_sample_instance_playing");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_set_sample_instance_playing(IntPtr spl, bool val);
        public static al_set_sample_instance_playing AlSetSampleInstancePlaying =
            NativeLibrary.LoadNativeFunction<al_set_sample_instance_playing>(_nativeAllegroLibrary, "al_set_sample_instance_playing");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_get_sample_instance_attached(IntPtr spl);
        public static al_get_sample_instance_attached AlGetSampleInstanceAttached =
            NativeLibrary.LoadNativeFunction<al_get_sample_instance_attached>(_nativeAllegroLibrary, "al_get_sample_instance_attached");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_detach_sample_instance(IntPtr spl);
        public static al_detach_sample_instance AlDetachSampleInstance =
            NativeLibrary.LoadNativeFunction<al_detach_sample_instance>(_nativeAllegroLibrary, "al_detach_sample_instance");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_get_sample(IntPtr spl);
        public static al_get_sample AlGetSample =
            NativeLibrary.LoadNativeFunction<al_get_sample>(_nativeAllegroLibrary, "al_get_sample");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_set_sample(IntPtr spl, IntPtr data);
        public static al_set_sample AlSetSample =
            NativeLibrary.LoadNativeFunction<al_set_sample>(_nativeAllegroLibrary, "al_set_sample");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_create_mixer(uint freq, int depth, int chan_conf);
        public static al_create_mixer AlCreateMixer =
            NativeLibrary.LoadNativeFunction<al_create_mixer>(_nativeAllegroLibrary, "al_create_mixer");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_destroy_mixer(IntPtr mixer);
        public static al_destroy_mixer AlDestroyMixer =
            NativeLibrary.LoadNativeFunction<al_destroy_mixer>(_nativeAllegroLibrary, "al_destroy_mixer");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_get_default_mixer();
        public static al_get_default_mixer AlGetDefaultMixer =
            NativeLibrary.LoadNativeFunction<al_get_default_mixer>(_nativeAllegroLibrary, "al_get_default_mixer");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_set_default_mixer(IntPtr mixer);
        public static al_set_default_mixer AlSetDefaultMixer =
            NativeLibrary.LoadNativeFunction<al_set_default_mixer>(_nativeAllegroLibrary, "al_set_default_mixer");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_restore_default_mixer();
        public static al_restore_default_mixer AlRestoreDefaultMixer =
            NativeLibrary.LoadNativeFunction<al_restore_default_mixer>(_nativeAllegroLibrary, "al_restore_default_mixer");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_get_default_voice();
        public static al_get_default_voice AlGetDefaultVoice =
            NativeLibrary.LoadNativeFunction<al_get_default_voice>(_nativeAllegroLibrary, "al_get_default_voice");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_set_default_voice(IntPtr voice);
        public static al_set_default_voice AlSetDefaultVoice =
            NativeLibrary.LoadNativeFunction<al_set_default_voice>(_nativeAllegroLibrary, "al_set_default_voice");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_attach_mixer_to_mixer(IntPtr stream, IntPtr mixer);
        public static al_attach_mixer_to_mixer AlAttachMixerToMixer =
            NativeLibrary.LoadNativeFunction<al_attach_mixer_to_mixer>(_nativeAllegroLibrary, "al_attach_mixer_to_mixer");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_attach_sample_instance_to_mixer(IntPtr spl, IntPtr mixer);
        public static al_attach_sample_instance_to_mixer AlAttachSampleInstanceToMixer =
            NativeLibrary.LoadNativeFunction<al_attach_sample_instance_to_mixer>(_nativeAllegroLibrary, "al_attach_sample_instance_to_mixer");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_attach_audio_stream_to_mixer(IntPtr stream, IntPtr mixer);
        public static al_attach_audio_stream_to_mixer AlAttachAudioStreamToMixer =
            NativeLibrary.LoadNativeFunction<al_attach_audio_stream_to_mixer>(_nativeAllegroLibrary, "al_attach_audio_stream_to_mixer");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate uint al_get_mixer_frequency(IntPtr mixer);
        public static al_get_mixer_frequency AlGetMixerFrequency =
            NativeLibrary.LoadNativeFunction<al_get_mixer_frequency>(_nativeAllegroLibrary, "al_get_mixer_frequency");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_set_mixer_frequency(IntPtr mixer, uint val);
        public static al_set_mixer_frequency AlSetMixerFrequency =
            NativeLibrary.LoadNativeFunction<al_set_mixer_frequency>(_nativeAllegroLibrary, "al_set_mixer_frequency");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int al_get_mixer_channels(IntPtr mixer);
        public static al_get_mixer_channels AlGetMixerChannels =
            NativeLibrary.LoadNativeFunction<al_get_mixer_channels>(_nativeAllegroLibrary, "al_get_mixer_channels");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int al_get_mixer_depth(IntPtr mixer);
        public static al_get_mixer_depth AlGetMixerDepth =
            NativeLibrary.LoadNativeFunction<al_get_mixer_depth>(_nativeAllegroLibrary, "al_get_mixer_depth");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate float al_get_mixer_gain(IntPtr mixer);
        public static al_get_mixer_gain AlGetMixerGain =
            NativeLibrary.LoadNativeFunction<al_get_mixer_gain>(_nativeAllegroLibrary, "al_get_mixer_gain");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_set_mixer_gain(IntPtr mixer, float new_gain);
        public static al_set_mixer_gain AlSetMixerGain =
            NativeLibrary.LoadNativeFunction<al_set_mixer_gain>(_nativeAllegroLibrary, "al_set_mixer_gain");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int al_get_mixer_quality(IntPtr mixer);
        public static al_get_mixer_quality AlGetMixerQuality =
            NativeLibrary.LoadNativeFunction<al_get_mixer_quality>(_nativeAllegroLibrary, "al_get_mixer_quality");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_set_mixer_quality(IntPtr mixer, int new_quality);
        public static al_set_mixer_quality AlSetMixerQuality =
            NativeLibrary.LoadNativeFunction<al_set_mixer_quality>(_nativeAllegroLibrary, "al_set_mixer_quality");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_get_mixer_playing(IntPtr mixer);
        public static al_get_mixer_playing AlGetMixerPlaying =
            NativeLibrary.LoadNativeFunction<al_get_mixer_playing>(_nativeAllegroLibrary, "al_get_mixer_playing");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_set_mixer_playing(IntPtr mixer, bool val);
        public static al_set_mixer_playing AlSetMixerPlaying =
            NativeLibrary.LoadNativeFunction<al_set_mixer_playing>(_nativeAllegroLibrary, "al_set_mixer_playing");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_get_mixer_attached(IntPtr mixer);
        public static al_get_mixer_attached AlGetMixerAttached =
            NativeLibrary.LoadNativeFunction<al_get_mixer_attached>(_nativeAllegroLibrary, "al_get_mixer_attached");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_detach_mixer(IntPtr mixer);
        public static al_detach_mixer AlDetachMixer =
            NativeLibrary.LoadNativeFunction<al_detach_mixer>(_nativeAllegroLibrary, "al_detach_mixer");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_set_mixer_postprocess_callback(IntPtr mixer, IntPtr pp_callback, IntPtr pp_callback_userdata);
        public static al_set_mixer_postprocess_callback AlSetMixerPostprocessCallback =
            NativeLibrary.LoadNativeFunction<al_set_mixer_postprocess_callback>(_nativeAllegroLibrary, "al_set_mixer_postprocess_callback");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_create_audio_stream(UIntPtr fragment_count, uint frag_samples, uint freq, int depth, int chan_conf);
        public static al_create_audio_stream AlCreateAudioStream =
            NativeLibrary.LoadNativeFunction<al_create_audio_stream>(_nativeAllegroLibrary, "al_create_audio_stream");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_destroy_audio_stream(IntPtr stream);
        public static al_destroy_audio_stream AlDestroyAudioStream =
            NativeLibrary.LoadNativeFunction<al_destroy_audio_stream>(_nativeAllegroLibrary, "al_destroy_audio_stream");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_get_audio_stream_event_source(IntPtr stream);
        public static al_get_audio_stream_event_source AlGetAudioStreamEventSource =
            NativeLibrary.LoadNativeFunction<al_get_audio_stream_event_source>(_nativeAllegroLibrary, "al_get_audio_stream_event_source");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_drain_audio_stream(IntPtr stream);
        public static al_drain_audio_stream AlDrainAudioStream =
            NativeLibrary.LoadNativeFunction<al_drain_audio_stream>(_nativeAllegroLibrary, "al_drain_audio_stream");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_rewind_audio_stream(IntPtr stream);
        public static al_rewind_audio_stream AlRewindAudioStream =
            NativeLibrary.LoadNativeFunction<al_rewind_audio_stream>(_nativeAllegroLibrary, "al_rewind_audio_stream");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate uint al_get_audio_stream_frequency(IntPtr stream);
        public static al_get_audio_stream_frequency AlGetAudioStreamFrequency =
            NativeLibrary.LoadNativeFunction<al_get_audio_stream_frequency>(_nativeAllegroLibrary, "al_get_audio_stream_frequency");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int al_get_audio_stream_channels(IntPtr stream);
        public static al_get_audio_stream_channels AlGetAudioStreamChannels =
            NativeLibrary.LoadNativeFunction<al_get_audio_stream_channels>(_nativeAllegroLibrary, "al_get_audio_stream_channels");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int al_get_audio_stream_depth(IntPtr stream);
        public static al_get_audio_stream_depth AlGetAudioStreamDepth =
            NativeLibrary.LoadNativeFunction<al_get_audio_stream_depth>(_nativeAllegroLibrary, "al_get_audio_stream_depth");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate uint al_get_audio_stream_length(IntPtr stream);
        public static al_get_audio_stream_length AlGetAudioStreamLength =
            NativeLibrary.LoadNativeFunction<al_get_audio_stream_length>(_nativeAllegroLibrary, "al_get_audio_stream_length");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate float al_get_audio_stream_speed(IntPtr stream);
        public static al_get_audio_stream_speed AlGetAudioStreamSpeed =
            NativeLibrary.LoadNativeFunction<al_get_audio_stream_speed>(_nativeAllegroLibrary, "al_get_audio_stream_speed");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_set_audio_stream_speed(IntPtr stream, float val);
        public static al_set_audio_stream_speed AlSetAudioStreamSpeed =
            NativeLibrary.LoadNativeFunction<al_set_audio_stream_speed>(_nativeAllegroLibrary, "al_set_audio_stream_speed");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate float al_get_audio_stream_gain(IntPtr stream);
        public static al_get_audio_stream_gain AlGetAudioStreamGain =
            NativeLibrary.LoadNativeFunction<al_get_audio_stream_gain>(_nativeAllegroLibrary, "al_get_audio_stream_gain");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_set_audio_stream_gain(IntPtr stream, float val);
        public static al_set_audio_stream_gain AlSetAudioStreamGain =
            NativeLibrary.LoadNativeFunction<al_set_audio_stream_gain>(_nativeAllegroLibrary, "al_set_audio_stream_gain");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate float al_get_audio_stream_pan(IntPtr stream);
        public static al_get_audio_stream_pan AlGetAudioStreamPan =
            NativeLibrary.LoadNativeFunction<al_get_audio_stream_pan>(_nativeAllegroLibrary, "al_get_audio_stream_pan");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_set_audio_stream_pan(IntPtr stream, float val);
        public static al_set_audio_stream_pan AlSetAudioStreamPan =
            NativeLibrary.LoadNativeFunction<al_set_audio_stream_pan>(_nativeAllegroLibrary, "al_set_audio_stream_pan");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_get_audio_stream_playing(IntPtr stream);
        public static al_get_audio_stream_playing AlGetAudioStreamPlaying =
            NativeLibrary.LoadNativeFunction<al_get_audio_stream_playing>(_nativeAllegroLibrary, "al_get_audio_stream_playing");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_set_audio_stream_playing(IntPtr stream, bool val);
        public static al_set_audio_stream_playing AlSetAudioStreamPlaying =
            NativeLibrary.LoadNativeFunction<al_set_audio_stream_playing>(_nativeAllegroLibrary, "al_set_audio_stream_playing");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int al_get_audio_stream_playmode(IntPtr stream);
        public static al_get_audio_stream_playmode AlGetAudioStreamPlaymode =
            NativeLibrary.LoadNativeFunction<al_get_audio_stream_playmode>(_nativeAllegroLibrary, "al_get_audio_stream_playmode");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_set_audio_stream_playmode(IntPtr stream, int val);
        public static al_set_audio_stream_playmode AlSetAudioStreamPlaymode =
            NativeLibrary.LoadNativeFunction<al_set_audio_stream_playmode>(_nativeAllegroLibrary, "al_set_audio_stream_playmode");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_get_audio_stream_attached(IntPtr stream);
        public static al_get_audio_stream_attached AlGetAudioStreamAttached =
            NativeLibrary.LoadNativeFunction<al_get_audio_stream_attached>(_nativeAllegroLibrary, "al_get_audio_stream_attached");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_detach_audio_stream(IntPtr stream);
        public static al_detach_audio_stream AlDetachAudioStream =
            NativeLibrary.LoadNativeFunction<al_detach_audio_stream>(_nativeAllegroLibrary, "al_detach_audio_stream");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate ulong al_get_audio_stream_played_samples(IntPtr stream);
        public static al_get_audio_stream_played_samples AlGetAudioStreamPlayedSamples =
            NativeLibrary.LoadNativeFunction<al_get_audio_stream_played_samples>(_nativeAllegroLibrary, "al_get_audio_stream_played_samples");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_get_audio_stream_fragment(IntPtr stream);
        public static al_get_audio_stream_fragment AlGetAudioStreamFragment =
            NativeLibrary.LoadNativeFunction<al_get_audio_stream_fragment>(_nativeAllegroLibrary, "al_get_audio_stream_fragment");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_set_audio_stream_fragment(IntPtr stream, IntPtr val);
        public static al_set_audio_stream_fragment AlSetAudioStreamFragment =
            NativeLibrary.LoadNativeFunction<al_set_audio_stream_fragment>(_nativeAllegroLibrary, "al_set_audio_stream_fragment");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate uint al_get_audio_stream_fragments(IntPtr stream);
        public static al_get_audio_stream_fragments AlGetAudioStreamFragments =
            NativeLibrary.LoadNativeFunction<al_get_audio_stream_fragments>(_nativeAllegroLibrary, "al_get_audio_stream_fragments");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate uint al_get_available_audio_stream_fragments(IntPtr stream);
        public static al_get_available_audio_stream_fragments AlGetAvailableAudioStreamFragments =
            NativeLibrary.LoadNativeFunction<al_get_available_audio_stream_fragments>(_nativeAllegroLibrary, "al_get_available_audio_stream_fragments");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_seek_audio_stream_secs(IntPtr stream, double time);
        public static al_seek_audio_stream_secs AlSeekAudioStreamSecs =
            NativeLibrary.LoadNativeFunction<al_seek_audio_stream_secs>(_nativeAllegroLibrary, "al_seek_audio_stream_secs");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate double al_get_audio_stream_position_secs(IntPtr stream);
        public static al_get_audio_stream_position_secs AlGetAudioStreamPositionSecs =
            NativeLibrary.LoadNativeFunction<al_get_audio_stream_position_secs>(_nativeAllegroLibrary, "al_get_audio_stream_position_secs");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate double al_get_audio_stream_length_secs(IntPtr stream);
        public static al_get_audio_stream_length_secs AlGetAudioStreamLengthSecs =
            NativeLibrary.LoadNativeFunction<al_get_audio_stream_length_secs>(_nativeAllegroLibrary, "al_get_audio_stream_length_secs");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_set_audio_stream_loop_secs(IntPtr stream, double start, double end);
        public static al_set_audio_stream_loop_secs AlSetAudioStreamLoopSecs =
            NativeLibrary.LoadNativeFunction<al_set_audio_stream_loop_secs>(_nativeAllegroLibrary, "al_set_audio_stream_loop_secs");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_register_sample_loader([MarshalAs(UnmanagedType.LPStr)] string ext, IntPtr loader);
        public static al_register_sample_loader AlRegisterSampleLoader =
            NativeLibrary.LoadNativeFunction<al_register_sample_loader>(_nativeAllegroLibrary, "al_register_sample_loader");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_register_sample_loader_f([MarshalAs(UnmanagedType.LPStr)] string ext, IntPtr loader);
        public static al_register_sample_loader_f AlRegisterSampleLoaderF =
            NativeLibrary.LoadNativeFunction<al_register_sample_loader_f>(_nativeAllegroLibrary, "al_register_sample_loader_f");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_register_sample_saver([MarshalAs(UnmanagedType.LPStr)] string ext, IntPtr saver);
        public static al_register_sample_saver AlRegisterSampleSaver =
            NativeLibrary.LoadNativeFunction<al_register_sample_saver>(_nativeAllegroLibrary, "al_register_sample_saver");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_register_sample_saver_f([MarshalAs(UnmanagedType.LPStr)] string ext, IntPtr saver);
        public static al_register_sample_saver_f AlRegisterSampleSaverF =
            NativeLibrary.LoadNativeFunction<al_register_sample_saver_f>(_nativeAllegroLibrary, "al_register_sample_saver_f");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_register_audio_stream_loader([MarshalAs(UnmanagedType.LPStr)] string ext, IntPtr stream_loader);
        public static al_register_audio_stream_loader AlRegisterAudioStreamLoader =
            NativeLibrary.LoadNativeFunction<al_register_audio_stream_loader>(_nativeAllegroLibrary, "al_register_audio_stream_loader");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_register_audio_stream_loader_f([MarshalAs(UnmanagedType.LPStr)] string ext, IntPtr stream_loader);
        public static al_register_audio_stream_loader_f AlRegisterAudioStreamLoaderF =
            NativeLibrary.LoadNativeFunction<al_register_audio_stream_loader_f>(_nativeAllegroLibrary, "al_register_audio_stream_loader_f");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_load_sample([MarshalAs(UnmanagedType.LPStr)] string filename);
        public static al_load_sample AlLoadSample =
            NativeLibrary.LoadNativeFunction<al_load_sample>(_nativeAllegroLibrary, "al_load_sample");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_load_sample_f(IntPtr fp, [MarshalAs(UnmanagedType.LPStr)] string ident);
        public static al_load_sample_f AlLoadSampleF =
            NativeLibrary.LoadNativeFunction<al_load_sample_f>(_nativeAllegroLibrary, "al_load_sample_f");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_load_audio_stream([MarshalAs(UnmanagedType.LPStr)] string filename, UIntPtr buffer_count, uint samples);
        public static al_load_audio_stream AlLoadAudioStream =
            NativeLibrary.LoadNativeFunction<al_load_audio_stream>(_nativeAllegroLibrary, "al_load_audio_stream");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_load_audio_stream_f(IntPtr fp, [MarshalAs(UnmanagedType.LPStr)] string ident, UIntPtr buffer_count, uint samples);
        public static al_load_audio_stream_f AlLoadAudioStreamF =
            NativeLibrary.LoadNativeFunction<al_load_audio_stream_f>(_nativeAllegroLibrary, "al_load_audio_stream_f");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_save_sample([MarshalAs(UnmanagedType.LPStr)] string filename, IntPtr spl);
        public static al_save_sample AlSaveSample =
            NativeLibrary.LoadNativeFunction<al_save_sample>(_nativeAllegroLibrary, "al_save_sample");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_save_sample_f(IntPtr fp, [MarshalAs(UnmanagedType.LPStr)] string ident, IntPtr spl);
        public static al_save_sample_f AlSaveSampleF =
            NativeLibrary.LoadNativeFunction<al_save_sample_f>(_nativeAllegroLibrary, "al_save_sample_f");
        #endregion

        #region Audio codecs addon
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_init_acodec_addon();
        public static al_init_acodec_addon AlInitAcodecAddon =
            NativeLibrary.LoadNativeFunction<al_init_acodec_addon>(_nativeAllegroLibrary, "al_init_acodec_addon");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_is_acodec_addon_initialized();
        public static al_is_acodec_addon_initialized AlIsAcodecAddonInitialized =
            NativeLibrary.LoadNativeFunction<al_is_acodec_addon_initialized>(_nativeAllegroLibrary, "al_is_acodec_addon_initialized");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate uint al_get_allegro_acodec_version();
        public static al_get_allegro_acodec_version AlGetAllegroAcodecVersion =
            NativeLibrary.LoadNativeFunction<al_get_allegro_acodec_version>(_nativeAllegroLibrary, "al_get_allegro_acodec_version");
        #endregion

        #region Configuration files
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_create_config();
        public static al_create_config AlCreateConfig =
            NativeLibrary.LoadNativeFunction<al_create_config>(_nativeAllegroLibrary, "al_create_config");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_destroy_config(IntPtr config);
        public static al_destroy_config AlDestroyConfig =
            NativeLibrary.LoadNativeFunction<al_destroy_config>(_nativeAllegroLibrary, "al_destroy_config");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_load_config_file([MarshalAs(UnmanagedType.LPStr)] string filename);
        public static al_load_config_file AlLoadConfigFile =
            NativeLibrary.LoadNativeFunction<al_load_config_file>(_nativeAllegroLibrary, "al_load_config_file");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_load_config_file_f(IntPtr file);
        public static al_load_config_file_f AlLoadConfigFileF =
            NativeLibrary.LoadNativeFunction<al_load_config_file_f>(_nativeAllegroLibrary, "al_load_config_file_f");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_save_config_file([MarshalAs(UnmanagedType.LPStr)] string filename, IntPtr config);
        public static al_save_config_file AlSaveConfigFile =
            NativeLibrary.LoadNativeFunction<al_save_config_file>(_nativeAllegroLibrary, "al_save_config_file");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_save_config_file_f(IntPtr file, IntPtr config);
        public static al_save_config_file_f AlSaveConfigFileF =
            NativeLibrary.LoadNativeFunction<al_save_config_file_f>(_nativeAllegroLibrary, "al_save_config_file_f");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_add_config_section(IntPtr config, [MarshalAs(UnmanagedType.LPStr)] string name);
        public static al_add_config_section AlAddConfigSection =
            NativeLibrary.LoadNativeFunction<al_add_config_section>(_nativeAllegroLibrary, "al_add_config_section");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_remove_config_section(IntPtr config, [MarshalAs(UnmanagedType.LPStr)] string section);
        public static al_remove_config_section AlRemoveConfigSection =
            NativeLibrary.LoadNativeFunction<al_remove_config_section>(_nativeAllegroLibrary, "al_remove_config_section");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_add_config_comment(IntPtr config, [MarshalAs(UnmanagedType.LPStr)] string section, [MarshalAs(UnmanagedType.LPStr)] string comment);
        public static al_add_config_comment AlAddConfigComment =
            NativeLibrary.LoadNativeFunction<al_add_config_comment>(_nativeAllegroLibrary, "al_add_config_comment");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_get_config_value(IntPtr config, [MarshalAs(UnmanagedType.LPStr)] string section, [MarshalAs(UnmanagedType.LPStr)] string key);
        public static al_get_config_value AlGetConfigValue =
            NativeLibrary.LoadNativeFunction<al_get_config_value>(_nativeAllegroLibrary, "al_get_config_value");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_set_config_value(IntPtr config, [MarshalAs(UnmanagedType.LPStr)] string section, [MarshalAs(UnmanagedType.LPStr)] string key, [MarshalAs(UnmanagedType.LPStr)] string value);
        public static al_set_config_value AlSetConfigValue =
            NativeLibrary.LoadNativeFunction<al_set_config_value>(_nativeAllegroLibrary, "al_set_config_value");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_remove_config_key(IntPtr config, [MarshalAs(UnmanagedType.LPStr)] string section, [MarshalAs(UnmanagedType.LPStr)] string key);
        public static al_remove_config_key AlRemoveConfigKey =
            NativeLibrary.LoadNativeFunction<al_remove_config_key>(_nativeAllegroLibrary, "al_remove_config_key");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_get_first_config_section(IntPtr config, ref IntPtr iterator);
        public static al_get_first_config_section AlGetFirstConfigSection =
            NativeLibrary.LoadNativeFunction<al_get_first_config_section>(_nativeAllegroLibrary, "al_get_first_config_section");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_get_next_config_section(ref IntPtr iterator);
        public static al_get_next_config_section AlGetNextConfigSection =
            NativeLibrary.LoadNativeFunction<al_get_next_config_section>(_nativeAllegroLibrary, "al_get_next_config_section");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_get_first_config_entry(IntPtr config, [MarshalAs(UnmanagedType.LPStr)] string section, ref IntPtr iterator);
        public static al_get_first_config_entry AlGetFirstConfigEntry =
            NativeLibrary.LoadNativeFunction<al_get_first_config_entry>(_nativeAllegroLibrary, "al_get_first_config_entry");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_get_next_config_entry(ref IntPtr iterator);
        public static al_get_next_config_entry AlGetNextConfigEntry =
            NativeLibrary.LoadNativeFunction<al_get_next_config_entry>(_nativeAllegroLibrary, "al_get_next_config_entry");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_merge_config(IntPtr config1, IntPtr config2);
        public static al_merge_config AlMergeConfig =
            NativeLibrary.LoadNativeFunction<al_merge_config>(_nativeAllegroLibrary, "al_merge_config");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_merge_config_into(IntPtr configMaster, IntPtr configAdd);
        public static al_merge_config_into AlMergeConfigInto =
            NativeLibrary.LoadNativeFunction<al_merge_config_into>(_nativeAllegroLibrary, "al_merge_config_into");
        #endregion

        #region Displays
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_create_display(int w, int h);
        public static al_create_display AlCreateDisplay =
            NativeLibrary.LoadNativeFunction<al_create_display>(_nativeAllegroLibrary, "al_create_display");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_destroy_display(IntPtr display);
        public static al_destroy_display AlDestroyDisplay =
            NativeLibrary.LoadNativeFunction<al_destroy_display>(_nativeAllegroLibrary, "al_destroy_display");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int al_get_new_display_flags();
        public static al_get_new_display_flags AlGetNewDisplayFlags =
            NativeLibrary.LoadNativeFunction<al_get_new_display_flags>(_nativeAllegroLibrary, "al_get_new_display_flags");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_set_new_display_flags(int flags);
        public static al_set_new_display_flags AlSetNewDisplayFlags =
            NativeLibrary.LoadNativeFunction<al_set_new_display_flags>(_nativeAllegroLibrary, "al_set_new_display_flags");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int al_get_new_display_option(int option, ref int importance);
        public static al_get_new_display_option AlGetNewDisplayOption =
            NativeLibrary.LoadNativeFunction<al_get_new_display_option>(_nativeAllegroLibrary, "al_get_new_display_option");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_set_new_display_option(int option, int value, int importance);
        public static al_set_new_display_option AlSetNewDisplayOption =
            NativeLibrary.LoadNativeFunction<al_set_new_display_option>(_nativeAllegroLibrary, "al_set_new_display_option");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_reset_new_display_options();
        public static al_reset_new_display_options AlResetNewDisplayOptions =
            NativeLibrary.LoadNativeFunction<al_reset_new_display_options>(_nativeAllegroLibrary, "al_reset_new_display_options");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_get_new_window_position(ref int x, ref int y);
        public static al_get_new_window_position AlGetNewWindowPosition =
            NativeLibrary.LoadNativeFunction<al_get_new_window_position>(_nativeAllegroLibrary, "al_get_new_window_position");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_set_new_window_position(int x, int y);
        public static al_set_new_window_position AlSetNewWindowPosition =
            NativeLibrary.LoadNativeFunction<al_set_new_window_position>(_nativeAllegroLibrary, "al_set_new_window_position");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int al_get_new_display_refresh_rate();
        public static al_get_new_display_refresh_rate AlGetNewDisplayRefreshRate =
            NativeLibrary.LoadNativeFunction<al_get_new_display_refresh_rate>(_nativeAllegroLibrary, "al_get_new_display_refresh_rate");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_set_new_display_refresh_rate(int refresh_rate);
        public static al_set_new_display_refresh_rate AlSetNewDisplayRefreshRate =
            NativeLibrary.LoadNativeFunction<al_set_new_display_refresh_rate>(_nativeAllegroLibrary, "al_set_new_display_refresh_rate");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_get_display_event_source(IntPtr display);
        public static al_get_display_event_source AlGetDisplayEventSource =
            NativeLibrary.LoadNativeFunction<al_get_display_event_source>(_nativeAllegroLibrary, "al_get_display_event_source");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_get_backbuffer(IntPtr display);
        public static al_get_backbuffer AlGetBackbuffer =
            NativeLibrary.LoadNativeFunction<al_get_backbuffer>(_nativeAllegroLibrary, "al_get_backbuffer");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_flip_display();
        public static al_flip_display AlFlipDisplay =
            NativeLibrary.LoadNativeFunction<al_flip_display>(_nativeAllegroLibrary, "al_flip_display");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_update_display_region(int x, int y, int width, int height);
        public static al_update_display_region AlUpdateDisplayRegion =
            NativeLibrary.LoadNativeFunction<al_update_display_region>(_nativeAllegroLibrary, "al_update_display_region");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_wait_for_vsync();
        public static al_wait_for_vsync AlWaitForVsync =
            NativeLibrary.LoadNativeFunction<al_wait_for_vsync>(_nativeAllegroLibrary, "al_wait_for_vsync");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int al_get_display_width(IntPtr display);
        public static al_get_display_width AlGetDisplayWidth =
            NativeLibrary.LoadNativeFunction<al_get_display_width>(_nativeAllegroLibrary, "al_get_display_width");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int al_get_display_height(IntPtr display);
        public static al_get_display_height AlGetDisplayHeight =
            NativeLibrary.LoadNativeFunction<al_get_display_height>(_nativeAllegroLibrary, "al_get_display_height");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_resize_display(IntPtr display, int width, int height);
        public static al_resize_display AlResizeDisplay =
            NativeLibrary.LoadNativeFunction<al_resize_display>(_nativeAllegroLibrary, "al_resize_display");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_acknowledge_resize(IntPtr display);
        public static al_acknowledge_resize AlAcknowledgeResize =
            NativeLibrary.LoadNativeFunction<al_acknowledge_resize>(_nativeAllegroLibrary, "al_acknowledge_resize");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_get_window_position(IntPtr display, ref int x, ref int y);
        public static al_get_window_position AlGetWindowPosition =
            NativeLibrary.LoadNativeFunction<al_get_window_position>(_nativeAllegroLibrary, "al_get_window_position");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_set_window_position(IntPtr display, int x, int y);
        public static al_set_window_position AlSetWindowPosition =
            NativeLibrary.LoadNativeFunction<al_set_window_position>(_nativeAllegroLibrary, "al_set_window_position");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_get_window_constraints(IntPtr display, ref int min_w, ref int min_h, ref int max_w, ref int max_h);
        public static al_get_window_constraints AlGetWindowConstraints =
            NativeLibrary.LoadNativeFunction<al_get_window_constraints>(_nativeAllegroLibrary, "al_get_window_constraints");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_set_window_constraints(IntPtr display, int min_w, int min_h, int max_w, int max_h);
        public static al_set_window_constraints AlSetWindowConstraints =
            NativeLibrary.LoadNativeFunction<al_set_window_constraints>(_nativeAllegroLibrary, "al_set_window_constraints");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_apply_window_constraints(IntPtr display, bool onOff);
        public static al_apply_window_constraints AlApplyWindowConstraints =
            NativeLibrary.LoadNativeFunction<al_apply_window_constraints>(_nativeAllegroLibrary, "al_apply_window_constraints");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int al_get_display_flags(IntPtr display);
        public static al_get_display_flags AlGetDisplayFlags =
            NativeLibrary.LoadNativeFunction<al_get_display_flags>(_nativeAllegroLibrary, "al_get_display_flags");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_set_display_flag(IntPtr display, int flag, bool onOff);
        public static al_set_display_flag AlSetDisplayFlag =
            NativeLibrary.LoadNativeFunction<al_set_display_flag>(_nativeAllegroLibrary, "al_set_display_flag");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int al_get_display_option(IntPtr display, int options);
        public static al_get_display_option AlGetDisplayOption =
            NativeLibrary.LoadNativeFunction<al_get_display_option>(_nativeAllegroLibrary, "al_get_display_option");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_set_display_option(IntPtr display, int option, int value);
        public static al_set_display_option AlSetDisplayOption =
            NativeLibrary.LoadNativeFunction<al_set_display_option>(_nativeAllegroLibrary, "al_set_display_option");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int al_get_display_format(IntPtr display);
        public static al_get_display_format AlGetDisplayFormat =
            NativeLibrary.LoadNativeFunction<al_get_display_format>(_nativeAllegroLibrary, "al_get_display_format");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int al_get_display_orientation(IntPtr display);
        public static al_get_display_orientation AlGetDisplayOrientation =
            NativeLibrary.LoadNativeFunction<al_get_display_orientation>(_nativeAllegroLibrary, "al_get_display_orientation");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int al_get_display_refresh_rate(IntPtr display);
        public static al_get_display_refresh_rate AlGetDisplayRefreshRate =
            NativeLibrary.LoadNativeFunction<al_get_display_refresh_rate>(_nativeAllegroLibrary, "al_get_display_refresh_rate");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_set_window_title(IntPtr display, [MarshalAs(UnmanagedType.LPStr)] string title);
        public static al_set_window_title AlSetWindowTitle =
            NativeLibrary.LoadNativeFunction<al_set_window_title>(_nativeAllegroLibrary, "al_set_window_title");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_set_new_window_title([MarshalAs(UnmanagedType.LPStr)] string title);
        public static al_set_new_window_title AlSetNewWindowTitle =
            NativeLibrary.LoadNativeFunction<al_set_new_window_title>(_nativeAllegroLibrary, "al_set_new_window_title");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_get_new_window_title();
        public static al_get_new_window_title AlGetNewWindowTitle =
            NativeLibrary.LoadNativeFunction<al_get_new_window_title>(_nativeAllegroLibrary, "al_get_new_window_title");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_set_display_icon(IntPtr display, IntPtr icon);
        public static al_set_display_icon AlSetDisplayIcon =
            NativeLibrary.LoadNativeFunction<al_set_display_icon>(_nativeAllegroLibrary, "al_set_display_icon");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_set_display_icons(IntPtr display, int num_icons, IntPtr bitmaps);
        public static al_set_display_icons AlSetDisplayIcons =
            NativeLibrary.LoadNativeFunction<al_set_display_icons>(_nativeAllegroLibrary, "al_set_display_icons");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_acknowledge_drawing_halt(IntPtr display);
        public static al_acknowledge_drawing_halt AlAcknowledgeDrawingHalt =
            NativeLibrary.LoadNativeFunction<al_acknowledge_drawing_halt>(_nativeAllegroLibrary, "al_acknowledge_drawing_halt");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_acknowledge_drawing_resume(IntPtr display);
        public static al_acknowledge_drawing_resume AlAcknowledgeDrawingResume =
            NativeLibrary.LoadNativeFunction<al_acknowledge_drawing_resume>(_nativeAllegroLibrary, "al_acknowledge_drawing_resume");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_inhibit_screensaver(bool inhibit);
        public static al_inhibit_screensaver AlInhibitScreensaver =
            NativeLibrary.LoadNativeFunction<al_inhibit_screensaver>(_nativeAllegroLibrary, "al_inhibit_screensaver");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_get_clipboard_text(IntPtr display);
        public static al_get_clipboard_text AlGetClipboardText =
            NativeLibrary.LoadNativeFunction<al_get_clipboard_text>(_nativeAllegroLibrary, "al_get_clipboard_text");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_set_clipboard_text(IntPtr display, [MarshalAs(UnmanagedType.LPStr)] string text);
        public static al_set_clipboard_text AlSetClipboardText =
            NativeLibrary.LoadNativeFunction<al_set_clipboard_text>(_nativeAllegroLibrary, "al_set_clipboard_text");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_clipboard_has_text(IntPtr display);
        public static al_clipboard_has_text AlClipboardHasText =
            NativeLibrary.LoadNativeFunction<al_clipboard_has_text>(_nativeAllegroLibrary, "al_clipboard_has_text");
        #endregion

        #region Event system and events
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_create_event_queue();
        public static al_create_event_queue AlCreateEventQueue =
            NativeLibrary.LoadNativeFunction<al_create_event_queue>(_nativeAllegroLibrary, "al_create_event_queue");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_destroy_event_queue(IntPtr queue);
        public static al_destroy_event_queue AlDestroyEventQueue =
            NativeLibrary.LoadNativeFunction<al_destroy_event_queue>(_nativeAllegroLibrary, "al_destroy_event_queue");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_register_event_source(IntPtr queue, IntPtr source);
        public static al_register_event_source AlRegisterEventSource =
            NativeLibrary.LoadNativeFunction<al_register_event_source>(_nativeAllegroLibrary, "al_register_event_source");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_unregister_event_source(IntPtr queue, IntPtr source);
        public static al_unregister_event_source AlUnregisterEventSource =
            NativeLibrary.LoadNativeFunction<al_unregister_event_source>(_nativeAllegroLibrary, "al_unregister_event_source");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_is_event_source_registered(IntPtr queue, IntPtr source);
        public static al_is_event_source_registered AlIsEventSourceRegistered =
            NativeLibrary.LoadNativeFunction<al_is_event_source_registered>(_nativeAllegroLibrary, "al_is_event_source_registered");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_pause_event_queue(IntPtr queue, bool pause);
        public static al_pause_event_queue AlPauseEventQueue =
            NativeLibrary.LoadNativeFunction<al_pause_event_queue>(_nativeAllegroLibrary, "al_pause_event_queue");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_is_event_queue_paused(IntPtr queue);
        public static al_is_event_queue_paused AlIsEventQueuePaused =
            NativeLibrary.LoadNativeFunction<al_is_event_queue_paused>(_nativeAllegroLibrary, "al_is_event_queue_paused");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_is_event_queue_empty(IntPtr queue);
        public static al_is_event_queue_empty AlIsEventQueueEmpty =
            NativeLibrary.LoadNativeFunction<al_is_event_queue_empty>(_nativeAllegroLibrary, "al_is_event_queue_empty");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_get_next_event(IntPtr queue, ref NativeAllegroEvent retEvent);
        public static al_get_next_event AlGetNextEvent =
            NativeLibrary.LoadNativeFunction<al_get_next_event>(_nativeAllegroLibrary, "al_get_next_event");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_peek_next_event(IntPtr queue, ref NativeAllegroEvent retEvent);
        public static al_peek_next_event AlPeekNextEvent =
            NativeLibrary.LoadNativeFunction<al_peek_next_event>(_nativeAllegroLibrary, "al_peek_next_event");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_drop_next_event(IntPtr queue);
        public static al_drop_next_event AlDropNextEvent =
            NativeLibrary.LoadNativeFunction<al_drop_next_event>(_nativeAllegroLibrary, "al_drop_next_event");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_flush_event_queue(IntPtr queue);
        public static al_flush_event_queue AlFlushEventQueue =
            NativeLibrary.LoadNativeFunction<al_flush_event_queue>(_nativeAllegroLibrary, "al_flush_event_queue");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_wait_for_event(IntPtr queue, ref NativeAllegroEvent retEvent);
        public static al_wait_for_event AlWaitForEvent =
            NativeLibrary.LoadNativeFunction<al_wait_for_event>(_nativeAllegroLibrary, "al_wait_for_event");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_wait_for_event_timed(IntPtr queue, ref NativeAllegroEvent retEvent, float seconds);
        public static al_wait_for_event_timed AlWaitForEventTimed =
            NativeLibrary.LoadNativeFunction<al_wait_for_event_timed>(_nativeAllegroLibrary, "al_wait_for_event_timed");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_wait_for_event_until(IntPtr queue, ref NativeAllegroEvent retEvent, ref NativeAllegroTimeout timeout);
        public static al_wait_for_event_until AlWaitForEventUntil =
            NativeLibrary.LoadNativeFunction<al_wait_for_event_until>(_nativeAllegroLibrary, "al_wait_for_event_until");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_init_user_event_source(IntPtr src);
        public static al_init_user_event_source AlInitUserEventSource =
            NativeLibrary.LoadNativeFunction<al_init_user_event_source>(_nativeAllegroLibrary, "al_init_user_event_source");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_destroy_user_event_source(IntPtr src);
        public static al_destroy_user_event_source AlDestroyUserEventSource =
            NativeLibrary.LoadNativeFunction<al_destroy_user_event_source>(_nativeAllegroLibrary, "al_destroy_user_event_source");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_emit_user_event(IntPtr source, ref NativeAllegroEvent allegroEvent, IntPtr dtor);
        public static al_emit_user_event AlEmitUserEvent =
            NativeLibrary.LoadNativeFunction<al_emit_user_event>(_nativeAllegroLibrary, "al_emit_user_event");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_unref_user_event(IntPtr source);
        public static al_unref_user_event AlUnrefUserEvent =
            NativeLibrary.LoadNativeFunction<al_unref_user_event>(_nativeAllegroLibrary, "al_unref_user_event");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_get_event_source_data(IntPtr source);
        public static al_get_event_source_data AlGetEventSourceData =
            NativeLibrary.LoadNativeFunction<al_get_event_source_data>(_nativeAllegroLibrary, "al_get_event_source_data");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_set_event_source_data(IntPtr source, IntPtr data);
        public static al_set_event_source_data AlSetEventSourceData =
            NativeLibrary.LoadNativeFunction<al_set_event_source_data>(_nativeAllegroLibrary, "al_set_event_source_data");
        #endregion

        #region File I/O
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_fopen([MarshalAs(UnmanagedType.LPStr)] string path, [MarshalAs(UnmanagedType.LPStr)] string mode);
        public static al_fopen AlFopen =
            NativeLibrary.LoadNativeFunction<al_fopen>(_nativeAllegroLibrary, "al_fopen");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_fopen_interface(IntPtr drv, [MarshalAs(UnmanagedType.LPStr)] string path, [MarshalAs(UnmanagedType.LPStr)] string mode);
        public static al_fopen_interface AlFopenInterface =
            NativeLibrary.LoadNativeFunction<al_fopen_interface>(_nativeAllegroLibrary, "al_fopen_interface");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_fopen_slice(IntPtr fp, IntPtr initialSize, [MarshalAs(UnmanagedType.LPStr)] string mode);
        public static al_fopen_slice AlFopenSlice =
            NativeLibrary.LoadNativeFunction<al_fopen_slice>(_nativeAllegroLibrary, "al_fopen_slice");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_fclose(IntPtr f);
        public static al_fclose AlFclose =
            NativeLibrary.LoadNativeFunction<al_fclose>(_nativeAllegroLibrary, "al_fclose");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate UIntPtr al_fread(IntPtr f, [MarshalAs(UnmanagedType.LPArray)] ref byte[] ptr, UIntPtr size);
        public static al_fread AlFread =
            NativeLibrary.LoadNativeFunction<al_fread>(_nativeAllegroLibrary, "al_fread");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate UIntPtr al_fwrite(IntPtr f, [MarshalAs(UnmanagedType.LPArray)] ref byte[] ptr, UIntPtr size);
        public static al_fwrite AlFwrite =
            NativeLibrary.LoadNativeFunction<al_fwrite>(_nativeAllegroLibrary, "al_fwrite");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_fflush(IntPtr f);
        public static al_fflush AlFflush =
            NativeLibrary.LoadNativeFunction<al_fflush>(_nativeAllegroLibrary, "al_fflush");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate long al_ftell(IntPtr f);
        public static al_ftell AlFtell =
            NativeLibrary.LoadNativeFunction<al_ftell>(_nativeAllegroLibrary, "al_ftell");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_fseek(IntPtr f, long offset, int whence);
        public static al_fseek AlFseek =
            NativeLibrary.LoadNativeFunction<al_fseek>(_nativeAllegroLibrary, "al_fseek");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_feof(IntPtr f);
        public static al_feof AlFeof =
            NativeLibrary.LoadNativeFunction<al_feof>(_nativeAllegroLibrary, "al_feof");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int al_ferror(IntPtr f);
        public static al_ferror AlFerror =
            NativeLibrary.LoadNativeFunction<al_ferror>(_nativeAllegroLibrary, "al_ferror");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_ferrmsg(IntPtr f);
        public static al_ferrmsg AlFerrmsg =
            NativeLibrary.LoadNativeFunction<al_ferrmsg>(_nativeAllegroLibrary, "al_ferrmsg");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_fclearerr(IntPtr f);
        public static al_fclearerr AlFclearerr =
            NativeLibrary.LoadNativeFunction<al_fclearerr>(_nativeAllegroLibrary, "al_fclearerr");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int al_fungetc(IntPtr f, int c);
        public static al_fungetc AlFungetc =
            NativeLibrary.LoadNativeFunction<al_fungetc>(_nativeAllegroLibrary, "al_fungetc");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate long al_fsize(IntPtr f);
        public static al_fsize AlFsize =
            NativeLibrary.LoadNativeFunction<al_fsize>(_nativeAllegroLibrary, "al_fsize");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int al_fgetc(IntPtr f);
        public static al_fgetc AlFgetc =
            NativeLibrary.LoadNativeFunction<al_fgetc>(_nativeAllegroLibrary, "al_fgetc");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int al_fputc(IntPtr f, int c);
        public static al_fputc AlFputc =
            NativeLibrary.LoadNativeFunction<al_fputc>(_nativeAllegroLibrary, "al_fputc");

        //[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        //public delegate int al_fprintf(IntPtr pfile, [MarshalAs(UnmanagedType.LPStr)] string format, __arglist);
        //public static al_fprintf AlFprintf =
        //    NativeLibrary.LoadNativeFunction<al_fprintf>(_nativeAllegroLibrary, "al_fprintf");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate short al_fread16le(IntPtr f);
        public static al_fread16le AlFread16le =
            NativeLibrary.LoadNativeFunction<al_fread16le>(_nativeAllegroLibrary, "al_fread16le");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate short al_fread16be(IntPtr f);
        public static al_fread16be AlFread16be =
            NativeLibrary.LoadNativeFunction<al_fread16be>(_nativeAllegroLibrary, "al_fread16be");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate UIntPtr al_fwrite16le(IntPtr f, short w);
        public static al_fwrite16le AlFwrite16le =
            NativeLibrary.LoadNativeFunction<al_fwrite16le>(_nativeAllegroLibrary, "al_fwrite16le");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate UIntPtr al_fwrite16be(IntPtr f, short w);
        public static al_fwrite16be AlFwrite16be =
            NativeLibrary.LoadNativeFunction<al_fwrite16be>(_nativeAllegroLibrary, "al_fwrite16be");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int al_fread32le(IntPtr f);
        public static al_fread32le AlFread32le =
            NativeLibrary.LoadNativeFunction<al_fread32le>(_nativeAllegroLibrary, "al_fread32le");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int al_fread32be(IntPtr f);
        public static al_fread32be AlFread32be =
            NativeLibrary.LoadNativeFunction<al_fread32be>(_nativeAllegroLibrary, "al_fread32be");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate UIntPtr al_fwrite32le(IntPtr f, int l);
        public static al_fwrite32le AlFwrite32le =
            NativeLibrary.LoadNativeFunction<al_fwrite32le>(_nativeAllegroLibrary, "al_fwrite32le");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate UIntPtr al_fwrite32be(IntPtr f, int l);
        public static al_fwrite32be AlFwrite32be =
            NativeLibrary.LoadNativeFunction<al_fwrite32be>(_nativeAllegroLibrary, "al_fwrite32be");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_fgets(IntPtr f, [MarshalAs(UnmanagedType.LPArray)] ref byte[] buf, UIntPtr max);
        public static al_fgets AlFgets =
            NativeLibrary.LoadNativeFunction<al_fgets>(_nativeAllegroLibrary, "al_fgets");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_fget_ustr(IntPtr f);
        public static al_fget_ustr AlFgetUstr =
            NativeLibrary.LoadNativeFunction<al_fget_ustr>(_nativeAllegroLibrary, "al_fget_ustr");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int al_fputs(IntPtr f, [MarshalAs(UnmanagedType.LPStr)] string p);
        public static al_fputs AlFputs =
            NativeLibrary.LoadNativeFunction<al_fputs>(_nativeAllegroLibrary, "al_fputs");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_fopen_fd(int fd, [MarshalAs(UnmanagedType.LPStr)] string mode);
        public static al_fopen_fd AlFopenFd =
            NativeLibrary.LoadNativeFunction<al_fopen_fd>(_nativeAllegroLibrary, "al_fopen_fd");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_make_temp_file([MarshalAs(UnmanagedType.LPStr)] string template, ref IntPtr ret_path);
        public static al_make_temp_file AlMakeTempFile =
            NativeLibrary.LoadNativeFunction<al_make_temp_file>(_nativeAllegroLibrary, "al_make_temp_file");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_set_new_file_interface(IntPtr file_interface);
        public static al_set_new_file_interface AlSetNewFileInterface =
            NativeLibrary.LoadNativeFunction<al_set_new_file_interface>(_nativeAllegroLibrary, "al_set_new_file_interface");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_set_standard_file_interface();
        public static al_set_standard_file_interface AlSetStandardFileInterface =
            NativeLibrary.LoadNativeFunction<al_set_standard_file_interface>(_nativeAllegroLibrary, "al_set_standard_file_interface");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_get_new_file_interface();
        public static al_get_new_file_interface AlGetNewFileInterface =
            NativeLibrary.LoadNativeFunction<al_get_new_file_interface>(_nativeAllegroLibrary, "al_get_new_file_interface");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_create_file_handle(IntPtr drv, [MarshalAs(UnmanagedType.LPArray)] ref byte[] userdata);
        public static al_create_file_handle AlCreateFileHandle =
            NativeLibrary.LoadNativeFunction<al_create_file_handle>(_nativeAllegroLibrary, "al_create_file_handle");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_UI1)]
        public delegate byte[] al_get_file_userdata(IntPtr f);
        public static al_get_file_userdata AlGetFileUserdata =
            NativeLibrary.LoadNativeFunction<al_get_file_userdata>(_nativeAllegroLibrary, "al_get_file_userdata");
        #endregion

        #region File system routines
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_create_fs_entry([MarshalAs(UnmanagedType.LPStr)] string path);
        public static al_create_fs_entry AlCreateFsEntry =
            NativeLibrary.LoadNativeFunction<al_create_fs_entry>(_nativeAllegroLibrary, "al_create_fs_entry");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_destroy_fs_entry(IntPtr fh);
        public static al_destroy_fs_entry AlDestroyFsEntry =
            NativeLibrary.LoadNativeFunction<al_destroy_fs_entry>(_nativeAllegroLibrary, "al_destroy_fs_entry");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_get_fs_entry_name(IntPtr e);
        public static al_get_fs_entry_name AlGetFsEntryName =
            NativeLibrary.LoadNativeFunction<al_get_fs_entry_name>(_nativeAllegroLibrary, "al_get_fs_entry_name");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_update_fs_entry(IntPtr e);
        public static al_update_fs_entry AlUpdateFsEntry =
            NativeLibrary.LoadNativeFunction<al_update_fs_entry>(_nativeAllegroLibrary, "al_update_fs_entry");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate uint al_get_fs_entry_mode(IntPtr e);
        public static al_get_fs_entry_mode AlGetFsEntryMode =
            NativeLibrary.LoadNativeFunction<al_get_fs_entry_mode>(_nativeAllegroLibrary, "al_get_fs_entry_mode");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate long al_get_fs_entry_atime(IntPtr e);
        public static al_get_fs_entry_atime AlGetFsEntryAtime =
            NativeLibrary.LoadNativeFunction<al_get_fs_entry_atime>(_nativeAllegroLibrary, "al_get_fs_entry_atime");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate long al_get_fs_entry_ctime(IntPtr e);
        public static al_get_fs_entry_ctime AlGetFsEntryCtime =
            NativeLibrary.LoadNativeFunction<al_get_fs_entry_ctime>(_nativeAllegroLibrary, "al_get_fs_entry_ctime");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate long al_get_fs_entry_mtime(IntPtr e);
        public static al_get_fs_entry_mtime AlGetFsEntryMtime =
            NativeLibrary.LoadNativeFunction<al_get_fs_entry_mtime>(_nativeAllegroLibrary, "al_get_fs_entry_mtime");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate long al_get_fs_entry_size(IntPtr e);
        public static al_get_fs_entry_size AlGetFsEntrySize =
            NativeLibrary.LoadNativeFunction<al_get_fs_entry_size>(_nativeAllegroLibrary, "al_get_fs_entry_size");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_fs_entry_exists(IntPtr e);
        public static al_fs_entry_exists AlFsEntryExists =
            NativeLibrary.LoadNativeFunction<al_fs_entry_exists>(_nativeAllegroLibrary, "al_fs_entry_exists");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_remove_fs_entry(IntPtr e);
        public static al_remove_fs_entry AlRemoveFsEntry =
            NativeLibrary.LoadNativeFunction<al_remove_fs_entry>(_nativeAllegroLibrary, "al_remove_fs_entry");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_filename_exists([MarshalAs(UnmanagedType.LPStr)] string path);
        public static al_filename_exists AlFilenameExists =
            NativeLibrary.LoadNativeFunction<al_filename_exists>(_nativeAllegroLibrary, "al_filename_exists");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_remove_filename([MarshalAs(UnmanagedType.LPStr)] string path);
        public static al_remove_filename AlRemoveFilename =
            NativeLibrary.LoadNativeFunction<al_remove_filename>(_nativeAllegroLibrary, "al_remove_filename");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_open_directory(IntPtr e);
        public static al_open_directory AlOpenDirectory =
            NativeLibrary.LoadNativeFunction<al_open_directory>(_nativeAllegroLibrary, "al_open_directory");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_read_directory(IntPtr e);
        public static al_read_directory AlReadDirectory =
            NativeLibrary.LoadNativeFunction<al_read_directory>(_nativeAllegroLibrary, "al_read_directory");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_close_directory(IntPtr e);
        public static al_close_directory AlCloseDirectory =
            NativeLibrary.LoadNativeFunction<al_close_directory>(_nativeAllegroLibrary, "al_close_directory");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_get_current_directory();
        public static al_get_current_directory AlGetCurrentDirectory =
            NativeLibrary.LoadNativeFunction<al_get_current_directory>(_nativeAllegroLibrary, "al_get_current_directory");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_change_directory([MarshalAs(UnmanagedType.LPStr)] string path);
        public static al_change_directory AlChangeDirectory =
            NativeLibrary.LoadNativeFunction<al_change_directory>(_nativeAllegroLibrary, "al_change_directory");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_make_directory([MarshalAs(UnmanagedType.LPStr)] string path);
        public static al_make_directory AlMakeDirectory =
            NativeLibrary.LoadNativeFunction<al_make_directory>(_nativeAllegroLibrary, "al_make_directory");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_open_fs_entry(IntPtr e, [MarshalAs(UnmanagedType.LPStr)] string mode);
        public static al_open_fs_entry AlOpenFsEntry =
            NativeLibrary.LoadNativeFunction<al_open_fs_entry>(_nativeAllegroLibrary, "al_open_fs_entry");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int al_for_each_fs_entry(IntPtr dir, AlConstants.ForEachFSEntryCallback callback, IntPtr extra);
        public static al_for_each_fs_entry AlForEachFsEntry =
            NativeLibrary.LoadNativeFunction<al_for_each_fs_entry>(_nativeAllegroLibrary, "al_for_each_fs_entry");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_set_fs_interface(IntPtr fs_interface);
        public static al_set_fs_interface AlSetFsInterface =
            NativeLibrary.LoadNativeFunction<al_set_fs_interface>(_nativeAllegroLibrary, "al_set_fs_interface");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_set_standard_fs_interface();
        public static al_set_standard_fs_interface AlSetStandardFsInterface =
            NativeLibrary.LoadNativeFunction<al_set_standard_fs_interface>(_nativeAllegroLibrary, "al_set_standard_fs_interface");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_get_fs_interface();
        public static al_get_fs_interface AlGetFsInterface =
            NativeLibrary.LoadNativeFunction<al_get_fs_interface>(_nativeAllegroLibrary, "al_get_fs_interface");
        #endregion

        #region Font addons
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_init_font_addon();
        public static al_init_font_addon AlInitFontAddon =
            NativeLibrary.LoadNativeFunction<al_init_font_addon>(_nativeAllegroLibrary, "al_init_font_addon");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_is_font_addon_initialized();
        public static al_is_font_addon_initialized AlIsFontAddonInitialized =
            NativeLibrary.LoadNativeFunction<al_is_font_addon_initialized>(_nativeAllegroLibrary, "al_is_font_addon_initialized");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_shutdown_font_addon();
        public static al_shutdown_font_addon AlShutdownFontAddon =
            NativeLibrary.LoadNativeFunction<al_shutdown_font_addon>(_nativeAllegroLibrary, "al_shutdown_font_addon");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_load_font([MarshalAs(UnmanagedType.LPStr)] string filename, int size, int flags);
        public static al_load_font AlLoadFont =
            NativeLibrary.LoadNativeFunction<al_load_font>(_nativeAllegroLibrary, "al_load_font");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_destroy_font(IntPtr f);
        public static al_destroy_font AlDestroyFont =
            NativeLibrary.LoadNativeFunction<al_destroy_font>(_nativeAllegroLibrary, "al_destroy_font");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_register_font_loader([MarshalAs(UnmanagedType.LPStr)] string extension, AlConstants.LoadFontDelegate load_font);
        public static al_register_font_loader AlRegisterFontLoader =
            NativeLibrary.LoadNativeFunction<al_register_font_loader>(_nativeAllegroLibrary, "al_register_font_loader");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int al_get_font_line_height(IntPtr f);
        public static al_get_font_line_height AlGetFontLineHeight =
            NativeLibrary.LoadNativeFunction<al_get_font_line_height>(_nativeAllegroLibrary, "al_get_font_line_height");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int al_get_font_ascent(IntPtr f);
        public static al_get_font_ascent AlGetFontAscent =
            NativeLibrary.LoadNativeFunction<al_get_font_ascent>(_nativeAllegroLibrary, "al_get_font_ascent");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int al_get_font_descent(IntPtr f);
        public static al_get_font_descent AlGetFontDescent =
            NativeLibrary.LoadNativeFunction<al_get_font_descent>(_nativeAllegroLibrary, "al_get_font_descent");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int al_get_text_width(IntPtr f, [MarshalAs(UnmanagedType.LPStr)] string str);
        public static al_get_text_width AlGetTextWidth =
            NativeLibrary.LoadNativeFunction<al_get_text_width>(_nativeAllegroLibrary, "al_get_text_width");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int al_get_ustr_width(IntPtr f, IntPtr ustr);
        public static al_get_ustr_width AlGetUstrWidth =
            NativeLibrary.LoadNativeFunction<al_get_ustr_width>(_nativeAllegroLibrary, "al_get_ustr_width");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_draw_text(IntPtr font, NativeAllegroColor color, float x, float y, int flags, [MarshalAs(UnmanagedType.LPStr)] string text);
        public static al_draw_text AlDrawText =
            NativeLibrary.LoadNativeFunction<al_draw_text>(_nativeAllegroLibrary, "al_draw_text");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_draw_ustr(IntPtr font, NativeAllegroColor color, float x, float y, int flags, IntPtr ustr);
        public static al_draw_ustr AlDrawUstr =
            NativeLibrary.LoadNativeFunction<al_draw_ustr>(_nativeAllegroLibrary, "al_draw_ustr");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_draw_justified_text(IntPtr font, NativeAllegroColor color, float x1, float x2, float y, float diff, int flags, [MarshalAs(UnmanagedType.LPStr)] string text);
        public static al_draw_justified_text AlDrawJustifiedText =
            NativeLibrary.LoadNativeFunction<al_draw_justified_text>(_nativeAllegroLibrary, "al_draw_justified_text");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_draw_justified_ustr(IntPtr font, NativeAllegroColor color, float x1, float x2, float y, float diff, int flags, IntPtr ustr);
        public static al_draw_justified_ustr AlDrawJustifiedUstr =
            NativeLibrary.LoadNativeFunction<al_draw_justified_ustr>(_nativeAllegroLibrary, "al_draw_justified_ustr");

        //[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        //public delegate void al_draw_textf(IntPtr font, NativeAllegroColor color, float x, float y, int flags, [MarshalAs(UnmanagedType.LPStr)] string format, __arglist);
        //public static al_draw_textf AlDrawTextf =
        //    NativeLibrary.LoadNativeFunction<al_draw_textf>(_nativeAllegroLibrary, "al_draw_textf");

        //[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        //public delegate void al_draw_justified_textf(IntPtr font, NativeAllegroColor color, float x1, float x2, float y, float diff, int flags, [MarshalAs(UnmanagedType.LPStr)] string format, __arglist);
        //public static al_draw_justified_textf AlDrawJustifiedTextf =
        //    NativeLibrary.LoadNativeFunction<al_draw_justified_textf>(_nativeAllegroLibrary, "al_draw_justified_textf");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_get_text_dimensions(IntPtr f, [MarshalAs(UnmanagedType.LPStr)] string text, ref int bbx, ref int bby, ref int bbw, ref int bbh);
        public static al_get_text_dimensions AlGetTextDimensions =
            NativeLibrary.LoadNativeFunction<al_get_text_dimensions>(_nativeAllegroLibrary, "al_get_text_dimensions");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_get_ustr_dimensions(IntPtr font, IntPtr ustr, ref int bbx, ref int bby, ref int bbw, ref int bbh);
        public static al_get_ustr_dimensions AlGetUstrDimensions =
            NativeLibrary.LoadNativeFunction<al_get_ustr_dimensions>(_nativeAllegroLibrary, "al_get_ustr_dimensions");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate uint al_get_allegro_font_version();
        public static al_get_allegro_font_version AlGetAllegroFontVersion =
            NativeLibrary.LoadNativeFunction<al_get_allegro_font_version>(_nativeAllegroLibrary, "al_get_allegro_font_version");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int al_get_font_ranges(IntPtr font, int rangesCount, ref int ranges);
        public static al_get_font_ranges AlGetFontRanges =
            NativeLibrary.LoadNativeFunction<al_get_font_ranges>(_nativeAllegroLibrary, "al_get_font_ranges");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_set_fallback_font(IntPtr font, IntPtr fallback);
        public static al_set_fallback_font AlSetFallbackFont =
            NativeLibrary.LoadNativeFunction<al_set_fallback_font>(_nativeAllegroLibrary, "al_set_fallback_font");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_get_fallback_font(IntPtr font);
        public static al_get_fallback_font AlGetFallbackFont =
            NativeLibrary.LoadNativeFunction<al_get_fallback_font>(_nativeAllegroLibrary, "al_get_fallback_font");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_draw_glyph(IntPtr f, NativeAllegroColor color, float x, float y, int codepoint);
        public static al_draw_glyph AlDrawGlyph =
            NativeLibrary.LoadNativeFunction<al_draw_glyph>(_nativeAllegroLibrary, "al_draw_glyph");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int al_get_glyph_width(IntPtr f, int codepoint);
        public static al_get_glyph_width AlGetGlyphWidth =
            NativeLibrary.LoadNativeFunction<al_get_glyph_width>(_nativeAllegroLibrary, "al_get_glyph_width");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_get_glyph_dimensions(IntPtr f, int codepoint, ref int bbx, ref int bby, ref int bbw, ref int bbh);
        public static al_get_glyph_dimensions AlGetGlyphDimensions =
            NativeLibrary.LoadNativeFunction<al_get_glyph_dimensions>(_nativeAllegroLibrary, "al_get_glyph_dimensions");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int al_get_glyph_advance(IntPtr f, int codepoint1, int codepoint2);
        public static al_get_glyph_advance AlGetGlyphAdvance =
            NativeLibrary.LoadNativeFunction<al_get_glyph_advance>(_nativeAllegroLibrary, "al_get_glyph_advance");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_draw_multiline_text(IntPtr font, NativeAllegroColor color, float x, float y, float max_width, float line_height, int flags, [MarshalAs(UnmanagedType.LPStr)] string text);
        public static al_draw_multiline_text AlDrawMultilineText =
            NativeLibrary.LoadNativeFunction<al_draw_multiline_text>(_nativeAllegroLibrary, "al_draw_multiline_text");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_draw_multiline_ustr(IntPtr font, NativeAllegroColor color, float x, float y, float max_width, float line_height, int flags, IntPtr ustr);
        public static al_draw_multiline_ustr AlDrawMultilineUstr =
            NativeLibrary.LoadNativeFunction<al_draw_multiline_ustr>(_nativeAllegroLibrary, "al_draw_multiline_ustr");

        //[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        //public delegate void al_draw_multiline_textf(IntPtr font, NativeAllegroColor color, float x, float y, float max_width, float line_height, int flags, [MarshalAs(UnmanagedType.LPStr)] string format, __arglist);
        //public static al_draw_multiline_textf AlDrawMultilineTextf =
        //    NativeLibrary.LoadNativeFunction<al_draw_multiline_textf>(_nativeAllegroLibrary, "al_draw_multiline_textf");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_do_multiline_text(IntPtr font, float max_width, [MarshalAs(UnmanagedType.LPStr)] string text, IntPtr cb, IntPtr extra);
        public static al_do_multiline_text AlDoMultilineText =
            NativeLibrary.LoadNativeFunction<al_do_multiline_text>(_nativeAllegroLibrary, "al_do_multiline_text");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_do_multiline_ustr(IntPtr font, float max_width, IntPtr ustr, IntPtr cb, IntPtr extra);
        public static al_do_multiline_ustr AlDoMultilineUstr =
            NativeLibrary.LoadNativeFunction<al_do_multiline_ustr>(_nativeAllegroLibrary, "al_do_multiline_ustr");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_grab_font_from_bitmap(IntPtr bmp, int ranges_n, int[] ranges);
        public static al_grab_font_from_bitmap AlGrabFontFromBitmap =
            NativeLibrary.LoadNativeFunction<al_grab_font_from_bitmap>(_nativeAllegroLibrary, "al_grab_font_from_bitmap");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_load_bitmap_font([MarshalAs(UnmanagedType.LPStr)] string fname);
        public static al_load_bitmap_font AlLoadBitmapFont =
            NativeLibrary.LoadNativeFunction<al_load_bitmap_font>(_nativeAllegroLibrary, "al_load_bitmap_font");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_load_bitmap_font_flags([MarshalAs(UnmanagedType.LPStr)] string fname, int flags);
        public static al_load_bitmap_font_flags AlLoadBitmapFontFlags =
            NativeLibrary.LoadNativeFunction<al_load_bitmap_font_flags>(_nativeAllegroLibrary, "al_load_bitmap_font_flags");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_create_builtin_font();
        public static al_create_builtin_font AlCreateBuiltinFont =
            NativeLibrary.LoadNativeFunction<al_create_builtin_font>(_nativeAllegroLibrary, "al_create_builtin_font");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_init_ttf_addon();
        public static al_init_ttf_addon AlInitTtfAddon =
            NativeLibrary.LoadNativeFunction<al_init_ttf_addon>(_nativeAllegroLibrary, "al_init_ttf_addon");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_is_ttf_addon_initialized();
        public static al_is_ttf_addon_initialized AlIsTtfAddonInitialized =
            NativeLibrary.LoadNativeFunction<al_is_ttf_addon_initialized>(_nativeAllegroLibrary, "al_is_ttf_addon_initialized");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_shutdown_ttf_addon();
        public static al_shutdown_ttf_addon AlShutdownTtfAddon =
            NativeLibrary.LoadNativeFunction<al_shutdown_ttf_addon>(_nativeAllegroLibrary, "al_shutdown_ttf_addon");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_load_ttf_font([MarshalAs(UnmanagedType.LPStr)] string filename, int size, int flags);
        public static al_load_ttf_font AlLoadTtfFont =
            NativeLibrary.LoadNativeFunction<al_load_ttf_font>(_nativeAllegroLibrary, "al_load_ttf_font");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_load_ttf_font_f(IntPtr file, [MarshalAs(UnmanagedType.LPStr)] string filename, int size, int flags);
        public static al_load_ttf_font_f AlLoadTtfFontF =
            NativeLibrary.LoadNativeFunction<al_load_ttf_font_f>(_nativeAllegroLibrary, "al_load_ttf_font_f");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_load_ttf_font_stretch([MarshalAs(UnmanagedType.LPStr)] string filename, int w, int h, int flags);
        public static al_load_ttf_font_stretch AlLoadTtfFontStretch =
            NativeLibrary.LoadNativeFunction<al_load_ttf_font_stretch>(_nativeAllegroLibrary, "al_load_ttf_font_stretch");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_load_ttf_font_stretch_f(IntPtr file, [MarshalAs(UnmanagedType.LPStr)] string filename, int w, int h, int flags);
        public static al_load_ttf_font_stretch_f AlLoadTtfFontStretchF =
            NativeLibrary.LoadNativeFunction<al_load_ttf_font_stretch_f>(_nativeAllegroLibrary, "al_load_ttf_font_stretch_f");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate uint al_get_allegro_ttf_version();
        public static al_get_allegro_ttf_version AlGetAllegroTtfVersion =
            NativeLibrary.LoadNativeFunction<al_get_allegro_ttf_version>(_nativeAllegroLibrary, "al_get_allegro_ttf_version");
        #endregion

        #region Fullscreen modes
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_get_display_mode(int index, ref NativeDisplayMode mode);
        public static al_get_display_mode AlGetDisplayMode =
            NativeLibrary.LoadNativeFunction<al_get_display_mode>(_nativeAllegroLibrary, "al_get_display_mode");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int al_get_num_display_modes();
        public static al_get_num_display_modes AlGetNumDisplayModes =
            NativeLibrary.LoadNativeFunction<al_get_num_display_modes>(_nativeAllegroLibrary, "al_get_num_display_modes");
        #endregion

        #region Graphics routines
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate NativeAllegroColor al_map_rgb(byte r, byte g, byte b);
        public static al_map_rgb AlMapRgb =
            NativeLibrary.LoadNativeFunction<al_map_rgb>(_nativeAllegroLibrary, "al_map_rgb");
            
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate NativeAllegroColor al_map_rgb_f(float r, float g, float b);
        public static al_map_rgb_f AlMapRgbF =
            NativeLibrary.LoadNativeFunction<al_map_rgb_f>(_nativeAllegroLibrary, "al_map_rgb_f");
            
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate NativeAllegroColor al_map_rgba(byte r, byte g, byte b, byte a);
        public static al_map_rgba AlMapRgba =
            NativeLibrary.LoadNativeFunction<al_map_rgba>(_nativeAllegroLibrary, "al_map_rgba");
            
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate NativeAllegroColor al_premul_rgba(byte r, byte g, byte b, byte a);
        public static al_premul_rgba AlPremulRgba =
            NativeLibrary.LoadNativeFunction<al_premul_rgba>(_nativeAllegroLibrary, "al_premul_rgba");
            
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate NativeAllegroColor al_map_rgba_f(float r, float g, float b, float a);
        public static al_map_rgba_f AlMapRgbaF =
            NativeLibrary.LoadNativeFunction<al_map_rgba_f>(_nativeAllegroLibrary, "al_map_rgba_f");
            
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate NativeAllegroColor al_premul_rgba_f(float r, float g, float b, float a);
        public static al_premul_rgba_f AlPremulRgbaF =
            NativeLibrary.LoadNativeFunction<al_premul_rgba_f>(_nativeAllegroLibrary, "al_premul_rgba_f");
            
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_unmap_rgb(NativeAllegroColor color, ref byte r, ref byte g, ref byte b);
        public static al_unmap_rgb AlUnmapRgb =
            NativeLibrary.LoadNativeFunction<al_unmap_rgb>(_nativeAllegroLibrary, "al_unmap_rgb");
            
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_unmap_rgb_f(NativeAllegroColor color, ref float r, ref float g, ref float b);
        public static al_unmap_rgb_f AlUnmapRgbF =
            NativeLibrary.LoadNativeFunction<al_unmap_rgb_f>(_nativeAllegroLibrary, "al_unmap_rgb_f");
            
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_unmap_rgba(NativeAllegroColor color, ref byte r, ref byte g, ref byte b, ref byte a);
        public static al_unmap_rgba AlUnmapRgba =
            NativeLibrary.LoadNativeFunction<al_unmap_rgba>(_nativeAllegroLibrary, "al_unmap_rgba");
            
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_unmap_rgba_f(NativeAllegroColor color, ref float r, ref float g, ref float b, ref float a);
        public static al_unmap_rgba_f AlUnmapRgbaF =
            NativeLibrary.LoadNativeFunction<al_unmap_rgba_f>(_nativeAllegroLibrary, "al_unmap_rgba_f");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int al_get_pixel_size(int format);
        public static al_get_pixel_size AlGetPixelSize =
            NativeLibrary.LoadNativeFunction<al_get_pixel_size>(_nativeAllegroLibrary, "al_get_pixel_size");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int al_get_pixel_format_bits(int format);
        public static al_get_pixel_format_bits AlGetPixelFormatBits =
            NativeLibrary.LoadNativeFunction<al_get_pixel_format_bits>(_nativeAllegroLibrary, "al_get_pixel_format_bits");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int al_get_pixel_block_size(int format);
        public static al_get_pixel_block_size AlGetPixelBlockSize =
            NativeLibrary.LoadNativeFunction<al_get_pixel_block_size>(_nativeAllegroLibrary, "al_get_pixel_block_size");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int al_get_pixel_block_width(int format);
        public static al_get_pixel_block_width AlGetPixelBlockWidth =
            NativeLibrary.LoadNativeFunction<al_get_pixel_block_width>(_nativeAllegroLibrary, "al_get_pixel_block_width");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int al_get_pixel_block_height(int format);
        public static al_get_pixel_block_height AlGetPixelBlockHeight =
            NativeLibrary.LoadNativeFunction<al_get_pixel_block_height>(_nativeAllegroLibrary, "al_get_pixel_block_height");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_lock_bitmap(IntPtr bitmap, int format, int flags);
        public static al_lock_bitmap AlLockBitmap =
            NativeLibrary.LoadNativeFunction<al_lock_bitmap>(_nativeAllegroLibrary, "al_lock_bitmap");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_lock_bitmap_region(IntPtr bitmap, int x, int y, int width, int height, int format, int flags);
        public static al_lock_bitmap_region AlLockBitmapRegion =
            NativeLibrary.LoadNativeFunction<al_lock_bitmap_region>(_nativeAllegroLibrary, "al_lock_bitmap_region");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_unlock_bitmap(IntPtr bitmap);
        public static al_unlock_bitmap AlUnlockBitmap =
            NativeLibrary.LoadNativeFunction<al_unlock_bitmap>(_nativeAllegroLibrary, "al_unlock_bitmap");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_lock_bitmap_blocked(IntPtr bitmap, int flags);
        public static al_lock_bitmap_blocked AlLockBitmapBlocked =
            NativeLibrary.LoadNativeFunction<al_lock_bitmap_blocked>(_nativeAllegroLibrary, "al_lock_bitmap_blocked");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_lock_bitmap_region_blocked(IntPtr bitmap, int x, int y, int width, int height, int flags);
        public static al_lock_bitmap_region_blocked AlLockBitmapRegionBlocked =
            NativeLibrary.LoadNativeFunction<al_lock_bitmap_region_blocked>(_nativeAllegroLibrary, "al_lock_bitmap_region_blocked");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_create_bitmap(int w, int h);
        public static al_create_bitmap AlCreateBitmap =
            NativeLibrary.LoadNativeFunction<al_create_bitmap>(_nativeAllegroLibrary, "al_create_bitmap");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_create_sub_bitmap(IntPtr parent, int x, int y, int w, int h);
        public static al_create_sub_bitmap AlCreateSubBitmap =
            NativeLibrary.LoadNativeFunction<al_create_sub_bitmap>(_nativeAllegroLibrary, "al_create_sub_bitmap");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_clone_bitmap(IntPtr bitmap);
        public static al_clone_bitmap AlCloneBitmap =
            NativeLibrary.LoadNativeFunction<al_clone_bitmap>(_nativeAllegroLibrary, "al_clone_bitmap");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_convert_bitmap(IntPtr bitmap);
        public static al_convert_bitmap AlConvertBitmap =
            NativeLibrary.LoadNativeFunction<al_convert_bitmap>(_nativeAllegroLibrary, "al_convert_bitmap");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_convert_memory_bitmaps();
        public static al_convert_memory_bitmaps AlConvertMemoryBitmaps =
            NativeLibrary.LoadNativeFunction<al_convert_memory_bitmaps>(_nativeAllegroLibrary, "al_convert_memory_bitmaps");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_destroy_bitmap(IntPtr bitmap);
        public static al_destroy_bitmap AlDestroyBitmap =
            NativeLibrary.LoadNativeFunction<al_destroy_bitmap>(_nativeAllegroLibrary, "al_destroy_bitmap");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int al_get_new_bitmap_flags();
        public static al_get_new_bitmap_flags AlGetNewBitmapFlags =
            NativeLibrary.LoadNativeFunction<al_get_new_bitmap_flags>(_nativeAllegroLibrary, "al_get_new_bitmap_flags");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int al_get_new_bitmap_format();
        public static al_get_new_bitmap_format AlGetNewBitmapFormat =
            NativeLibrary.LoadNativeFunction<al_get_new_bitmap_format>(_nativeAllegroLibrary, "al_get_new_bitmap_format");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_set_new_bitmap_flags(int flags);
        public static al_set_new_bitmap_flags AlSetNewBitmapFlags =
            NativeLibrary.LoadNativeFunction<al_set_new_bitmap_flags>(_nativeAllegroLibrary, "al_set_new_bitmap_flags");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_add_new_bitmap_flag(int flag);
        public static al_add_new_bitmap_flag AlAddNewBitmapFlag =
            NativeLibrary.LoadNativeFunction<al_add_new_bitmap_flag>(_nativeAllegroLibrary, "al_add_new_bitmap_flag");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_set_new_bitmap_format(int format);
        public static al_set_new_bitmap_format AlSetNewBitmapFormat =
            NativeLibrary.LoadNativeFunction<al_set_new_bitmap_format>(_nativeAllegroLibrary, "al_set_new_bitmap_format");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int al_get_bitmap_flags(IntPtr bitmap);
        public static al_get_bitmap_flags AlGetBitmapFlags =
            NativeLibrary.LoadNativeFunction<al_get_bitmap_flags>(_nativeAllegroLibrary, "al_get_bitmap_flags");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int al_get_bitmap_format(IntPtr bitmap);
        public static al_get_bitmap_format AlGetBitmapFormat =
            NativeLibrary.LoadNativeFunction<al_get_bitmap_format>(_nativeAllegroLibrary, "al_get_bitmap_format");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int al_get_bitmap_height(IntPtr bitmap);
        public static al_get_bitmap_height AlGetBitmapHeight =
            NativeLibrary.LoadNativeFunction<al_get_bitmap_height>(_nativeAllegroLibrary, "al_get_bitmap_height");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int al_get_bitmap_width(IntPtr bitmap);
        public static al_get_bitmap_width AlGetBitmapWidth =
            NativeLibrary.LoadNativeFunction<al_get_bitmap_width>(_nativeAllegroLibrary, "al_get_bitmap_width");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate NativeAllegroColor al_get_pixel(IntPtr bitmap, int x, int y);
        public static al_get_pixel AlGetPixel =
            NativeLibrary.LoadNativeFunction<al_get_pixel>(_nativeAllegroLibrary, "al_get_pixel");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_is_bitmap_locked(IntPtr bitmap);
        public static al_is_bitmap_locked AlIsBitmapLocked =
            NativeLibrary.LoadNativeFunction<al_is_bitmap_locked>(_nativeAllegroLibrary, "al_is_bitmap_locked");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_is_compatible_bitmap(IntPtr bitmap);
        public static al_is_compatible_bitmap AlIsCompatibleBitmap =
            NativeLibrary.LoadNativeFunction<al_is_compatible_bitmap>(_nativeAllegroLibrary, "al_is_compatible_bitmap");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_is_sub_bitmap(IntPtr bitmap);
        public static al_is_sub_bitmap AlIsSubBitmap =
            NativeLibrary.LoadNativeFunction<al_is_sub_bitmap>(_nativeAllegroLibrary, "al_is_sub_bitmap");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_get_parent_bitmap(IntPtr bitmap);
        public static al_get_parent_bitmap AlGetParentBitmap =
            NativeLibrary.LoadNativeFunction<al_get_parent_bitmap>(_nativeAllegroLibrary, "al_get_parent_bitmap");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int al_get_bitmap_x(IntPtr bitmap);
        public static al_get_bitmap_x AlGetBitmapX =
            NativeLibrary.LoadNativeFunction<al_get_bitmap_x>(_nativeAllegroLibrary, "al_get_bitmap_x");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int al_get_bitmap_y(IntPtr bitmap);
        public static al_get_bitmap_y AlGetBitmapY =
            NativeLibrary.LoadNativeFunction<al_get_bitmap_y>(_nativeAllegroLibrary, "al_get_bitmap_y");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_reparent_bitmap(IntPtr bitmap, IntPtr parent, int x, int y, int w, int h);
        public static al_reparent_bitmap AlReparentBitmap =
            NativeLibrary.LoadNativeFunction<al_reparent_bitmap>(_nativeAllegroLibrary, "al_reparent_bitmap");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_clear_to_color(NativeAllegroColor color);
        public static al_clear_to_color AlClearToColor =
            NativeLibrary.LoadNativeFunction<al_clear_to_color>(_nativeAllegroLibrary, "al_clear_to_color");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_clear_depth_buffer(float z);
        public static al_clear_depth_buffer AlClearDepthBuffer =
            NativeLibrary.LoadNativeFunction<al_clear_depth_buffer>(_nativeAllegroLibrary, "al_clear_depth_buffer");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_draw_bitmap(IntPtr bitmap, float dx, float dy, int flags);
        public static al_draw_bitmap AlDrawBitmap =
            NativeLibrary.LoadNativeFunction<al_draw_bitmap>(_nativeAllegroLibrary, "al_draw_bitmap");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_draw_tinted_bitmap(IntPtr bitmap, NativeAllegroColor tint, float dx, float dy, int flags);
        public static al_draw_tinted_bitmap AlDrawTintedBitmap =
            NativeLibrary.LoadNativeFunction<al_draw_tinted_bitmap>(_nativeAllegroLibrary, "al_draw_tinted_bitmap");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_draw_bitmap_region(IntPtr bitmap, float sx, float sy, float sw, float sh, float dx, float dy, int flags);
        public static al_draw_bitmap_region AlDrawBitmapRegion =
            NativeLibrary.LoadNativeFunction<al_draw_bitmap_region>(_nativeAllegroLibrary, "al_draw_bitmap_region");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_draw_tinted_bitmap_region(IntPtr bitmap, NativeAllegroColor tint, float sx, float sy, float sw, float sh, float dx, float dy, int flags);
        public static al_draw_tinted_bitmap_region AlDrawTintedBitmapRegion =
            NativeLibrary.LoadNativeFunction<al_draw_tinted_bitmap_region>(_nativeAllegroLibrary, "al_draw_tinted_bitmap_region");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_draw_pixel(float x, float y, NativeAllegroColor color);
        public static al_draw_pixel AlDrawPixel =
            NativeLibrary.LoadNativeFunction<al_draw_pixel>(_nativeAllegroLibrary, "al_draw_pixel");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_draw_rotated_bitmap(IntPtr bitmap, float cx, float cy, float dx, float dy, float angle, int flags);
        public static al_draw_rotated_bitmap AlDrawRotatedBitmap =
            NativeLibrary.LoadNativeFunction<al_draw_rotated_bitmap>(_nativeAllegroLibrary, "al_draw_rotated_bitmap");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_draw_tinted_rotated_bitmap(IntPtr bitmap, NativeAllegroColor tint, float cx, float cy, float dx, float dy, float angle, int flags);
        public static al_draw_tinted_rotated_bitmap AlDrawTintedRotatedBitmap =
            NativeLibrary.LoadNativeFunction<al_draw_tinted_rotated_bitmap>(_nativeAllegroLibrary, "al_draw_tinted_rotated_bitmap");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_draw_scaled_rotated_bitmap(IntPtr bitmap, float cx, float cy, float dx, float dy, float xscale, float yscale, float angle, int flags);
        public static al_draw_scaled_rotated_bitmap AlDrawScaledRotatedBitmap =
            NativeLibrary.LoadNativeFunction<al_draw_scaled_rotated_bitmap>(_nativeAllegroLibrary, "al_draw_scaled_rotated_bitmap");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_draw_tinted_scaled_rotated_bitmap(IntPtr bitmap, NativeAllegroColor tint, float cx, float cy, float dx, float dy, float xscale, float yscale, float angle, int flags);
        public static al_draw_tinted_scaled_rotated_bitmap AlDrawTintedScaledRotatedBitmap =
            NativeLibrary.LoadNativeFunction<al_draw_tinted_scaled_rotated_bitmap>(_nativeAllegroLibrary, "al_draw_tinted_scaled_rotated_bitmap");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_draw_tinted_scaled_rotated_bitmap_region(IntPtr bitmap, float sx, float sy, float sw, float sh, NativeAllegroColor tint, float cx, float cy, float dx, float dy, float xscale, float yscale, float angle, int flags);
        public static al_draw_tinted_scaled_rotated_bitmap_region AlDrawTintedScaledRotatedBitmapRegion =
            NativeLibrary.LoadNativeFunction<al_draw_tinted_scaled_rotated_bitmap_region>(_nativeAllegroLibrary, "al_draw_tinted_scaled_rotated_bitmap_region");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_draw_scaled_bitmap(IntPtr bitmap, float sx, float sy, float sw, float sh, float dx, float dy, float dw, float dh, int flags);
        public static al_draw_scaled_bitmap AlDrawScaledBitmap =
            NativeLibrary.LoadNativeFunction<al_draw_scaled_bitmap>(_nativeAllegroLibrary, "al_draw_scaled_bitmap");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_draw_tinted_scaled_bitmap(IntPtr bitmap, NativeAllegroColor tint, float sx, float sy, float sw, float sh, float dx, float dy, float dw, float dh, int flags);
        public static al_draw_tinted_scaled_bitmap AlDrawTintedScaledBitmap =
            NativeLibrary.LoadNativeFunction<al_draw_tinted_scaled_bitmap>(_nativeAllegroLibrary, "al_draw_tinted_scaled_bitmap");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_get_target_bitmap();
        public static al_get_target_bitmap AlGetTargetBitmap =
            NativeLibrary.LoadNativeFunction<al_get_target_bitmap>(_nativeAllegroLibrary, "al_get_target_bitmap");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_put_pixel(int x, int y, NativeAllegroColor color);
        public static al_put_pixel AlPutPixel =
            NativeLibrary.LoadNativeFunction<al_put_pixel>(_nativeAllegroLibrary, "al_put_pixel");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_put_blended_pixel(int x, int y, NativeAllegroColor color);
        public static al_put_blended_pixel AlPutBlendedPixel =
            NativeLibrary.LoadNativeFunction<al_put_blended_pixel>(_nativeAllegroLibrary, "al_put_blended_pixel");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_set_target_bitmap(IntPtr bitmap);
        public static al_set_target_bitmap AlSetTargetBitmap =
            NativeLibrary.LoadNativeFunction<al_set_target_bitmap>(_nativeAllegroLibrary, "al_set_target_bitmap");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_set_target_backbuffer(IntPtr display);
        public static al_set_target_backbuffer AlSetTargetBackbuffer =
            NativeLibrary.LoadNativeFunction<al_set_target_backbuffer>(_nativeAllegroLibrary, "al_set_target_backbuffer");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_get_current_display();
        public static al_get_current_display AlGetCurrentDisplay =
            NativeLibrary.LoadNativeFunction<al_get_current_display>(_nativeAllegroLibrary, "al_get_current_display");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_get_blender(ref int op, ref int src, ref int dst);
        public static al_get_blender AlGetBlender =
            NativeLibrary.LoadNativeFunction<al_get_blender>(_nativeAllegroLibrary, "al_get_blender");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_get_separate_blender(ref int op, ref int src, ref int dst, ref int alphaOp, ref int alphaSrc, ref int alphaDst);
        public static al_get_separate_blender AlGetSeparateBlender =
            NativeLibrary.LoadNativeFunction<al_get_separate_blender>(_nativeAllegroLibrary, "al_get_separate_blender");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate NativeAllegroColor al_get_blend_color();
        public static al_get_blend_color AlGetBlendColor =
            NativeLibrary.LoadNativeFunction<al_get_blend_color>(_nativeAllegroLibrary, "al_get_blend_color");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_set_blender(int op, int src, int dst);
        public static al_set_blender AlSetBlender =
            NativeLibrary.LoadNativeFunction<al_set_blender>(_nativeAllegroLibrary, "al_set_blender");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_set_separate_blender(int op, int src, int dst, int alphaOp, int alphaSrc, int alphaDst);
        public static al_set_separate_blender AlSetSeparateBlender =
            NativeLibrary.LoadNativeFunction<al_set_separate_blender>(_nativeAllegroLibrary, "al_set_separate_blender");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_set_blend_color(NativeAllegroColor color);
        public static al_set_blend_color AlSetBlendColor =
            NativeLibrary.LoadNativeFunction<al_set_blend_color>(_nativeAllegroLibrary, "al_set_blend_color");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_get_clipping_rectangle(ref int x, ref int y, ref int w, ref int h);
        public static al_get_clipping_rectangle AlGetClippingRectangle =
            NativeLibrary.LoadNativeFunction<al_get_clipping_rectangle>(_nativeAllegroLibrary, "al_get_clipping_rectangle");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_set_clipping_rectangle(int x, int y, int width, int height);
        public static al_set_clipping_rectangle AlSetClippingRectangle =
            NativeLibrary.LoadNativeFunction<al_set_clipping_rectangle>(_nativeAllegroLibrary, "al_set_clipping_rectangle");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_reset_clipping_rectangle();
        public static al_reset_clipping_rectangle AlResetClippingRectangle =
            NativeLibrary.LoadNativeFunction<al_reset_clipping_rectangle>(_nativeAllegroLibrary, "al_reset_clipping_rectangle");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_convert_mask_to_alpha(IntPtr bitmap, NativeAllegroColor maskColor);
        public static al_convert_mask_to_alpha AlConvertMaskToAlpha =
            NativeLibrary.LoadNativeFunction<al_convert_mask_to_alpha>(_nativeAllegroLibrary, "al_convert_mask_to_alpha");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_hold_bitmap_drawing(bool hold);
        public static al_hold_bitmap_drawing AlHoldBitmapDrawing =
            NativeLibrary.LoadNativeFunction<al_hold_bitmap_drawing>(_nativeAllegroLibrary, "al_hold_bitmap_drawing");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_is_bitmap_drawing_held();
        public static al_is_bitmap_drawing_held AlIsBitmapDrawingHeld =
            NativeLibrary.LoadNativeFunction<al_is_bitmap_drawing_held>(_nativeAllegroLibrary, "al_is_bitmap_drawing_held");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_register_bitmap_loader(IntPtr extension, IntPtr loader);
        public static al_register_bitmap_loader AlRegisterBitmapLoader =
            NativeLibrary.LoadNativeFunction<al_register_bitmap_loader>(_nativeAllegroLibrary, "al_register_bitmap_loader");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_register_bitmap_saver(IntPtr extension, IntPtr saver);
        public static al_register_bitmap_saver AlRegisterBitmapSaver =
            NativeLibrary.LoadNativeFunction<al_register_bitmap_saver>(_nativeAllegroLibrary, "al_register_bitmap_saver");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_register_bitmap_loader_f(IntPtr extension, IntPtr fsLoader);
        public static al_register_bitmap_loader_f AlRegisterBitmapLoaderF =
            NativeLibrary.LoadNativeFunction<al_register_bitmap_loader_f>(_nativeAllegroLibrary, "al_register_bitmap_loader_f");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_register_bitmap_saver_f(IntPtr extension, IntPtr fsSaver);
        public static al_register_bitmap_saver_f AlRegisterBitmapSaverF =
            NativeLibrary.LoadNativeFunction<al_register_bitmap_saver_f>(_nativeAllegroLibrary, "al_register_bitmap_saver_f");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_load_bitmap([MarshalAs(UnmanagedType.LPStr)] string filename);
        public static al_load_bitmap AlLoadBitmap =
            NativeLibrary.LoadNativeFunction<al_load_bitmap>(_nativeAllegroLibrary, "al_load_bitmap");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_load_bitmap_flags([MarshalAs(UnmanagedType.LPStr)] string filename, int flags);
        public static al_load_bitmap_flags AlLoadBitmapFlags =
            NativeLibrary.LoadNativeFunction<al_load_bitmap_flags>(_nativeAllegroLibrary, "al_load_bitmap_flags");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_load_bitmap_f(IntPtr fp, [MarshalAs(UnmanagedType.LPStr)] string ident);
        public static al_load_bitmap_f AlLoadBitmapF =
            NativeLibrary.LoadNativeFunction<al_load_bitmap_f>(_nativeAllegroLibrary, "al_load_bitmap_f");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_load_bitmap_flags_f(IntPtr fp, [MarshalAs(UnmanagedType.LPStr)] string ident, int flags);
        public static al_load_bitmap_flags_f AlLoadBitmapFlagsF =
            NativeLibrary.LoadNativeFunction<al_load_bitmap_flags_f>(_nativeAllegroLibrary, "al_load_bitmap_flags_f");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_save_bitmap([MarshalAs(UnmanagedType.LPStr)] string filename, IntPtr bitmap);
        public static al_save_bitmap AlSaveBitmap =
            NativeLibrary.LoadNativeFunction<al_save_bitmap>(_nativeAllegroLibrary, "al_save_bitmap");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_save_bitmap_f(IntPtr fp, [MarshalAs(UnmanagedType.LPStr)] string ident, IntPtr bitmap);
        public static al_save_bitmap_f AlSaveBitmapF =
            NativeLibrary.LoadNativeFunction<al_save_bitmap_f>(_nativeAllegroLibrary, "al_save_bitmap_f");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_register_bitmap_identifier([MarshalAs(UnmanagedType.LPStr)] string extension, IntPtr identifier);
        public static al_register_bitmap_identifier AlRegisterBitmapIdentifier =
            NativeLibrary.LoadNativeFunction<al_register_bitmap_identifier>(_nativeAllegroLibrary, "al_register_bitmap_identifier");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_identify_bitmap([MarshalAs(UnmanagedType.LPStr)] string filename);
        public static al_identify_bitmap AlIdentifyBitmap =
            NativeLibrary.LoadNativeFunction<al_identify_bitmap>(_nativeAllegroLibrary, "al_identify_bitmap");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_identify_bitmap_f(IntPtr fp);
        public static al_identify_bitmap_f AlIdentifyBitmapF =
            NativeLibrary.LoadNativeFunction<al_identify_bitmap_f>(_nativeAllegroLibrary, "al_identify_bitmap_f");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_set_render_state(int state, int value);
        public static al_set_render_state AlSetRenderState =
            NativeLibrary.LoadNativeFunction<al_set_render_state>(_nativeAllegroLibrary, "al_set_render_state");
        #endregion

        #region Image I/O addon
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_init_image_addon();
        public static al_init_image_addon AlInitImageAddon =
            NativeLibrary.LoadNativeFunction<al_init_image_addon>(_nativeAllegroLibrary, "al_init_image_addon");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_is_image_addon_initialized();
        public static al_is_image_addon_initialized AlIsImageAddonInitialized =
            NativeLibrary.LoadNativeFunction<al_is_image_addon_initialized>(_nativeAllegroLibrary, "al_is_image_addon_initialized");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_shutdown_image_addon();
        public static al_shutdown_image_addon AlShutdownImageAddon =
            NativeLibrary.LoadNativeFunction<al_shutdown_image_addon>(_nativeAllegroLibrary, "al_shutdown_image_addon");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate uint al_get_allegro_image_version();
        public static al_get_allegro_image_version AlGetAllegroImageVersion =
            NativeLibrary.LoadNativeFunction<al_get_allegro_image_version>(_nativeAllegroLibrary, "al_get_allegro_image_version");
        #endregion

        #region Joystick routines
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_install_joystick();
        public static al_install_joystick AlInstallJoystick =
            NativeLibrary.LoadNativeFunction<al_install_joystick>(_nativeAllegroLibrary, "al_install_joystick");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_uninstall_joystick();
        public static al_uninstall_joystick AlUninstallJoystick =
            NativeLibrary.LoadNativeFunction<al_uninstall_joystick>(_nativeAllegroLibrary, "al_uninstall_joystick");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_is_joystick_installed();
        public static al_is_joystick_installed AlIsJoystickInstalled =
            NativeLibrary.LoadNativeFunction<al_is_joystick_installed>(_nativeAllegroLibrary, "al_is_joystick_installed");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_reconfigure_joysticks();
        public static al_reconfigure_joysticks AlReconfigureJoysticks =
            NativeLibrary.LoadNativeFunction<al_reconfigure_joysticks>(_nativeAllegroLibrary, "al_reconfigure_joysticks");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int al_get_num_joysticks();
        public static al_get_num_joysticks AlGetNumJoysticks =
            NativeLibrary.LoadNativeFunction<al_get_num_joysticks>(_nativeAllegroLibrary, "al_get_num_joysticks");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_get_joystick(int num);
        public static al_get_joystick AlGetJoystick =
            NativeLibrary.LoadNativeFunction<al_get_joystick>(_nativeAllegroLibrary, "al_get_joystick");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_release_joystick(IntPtr joy);
        public static al_release_joystick AlReleaseJoystick =
            NativeLibrary.LoadNativeFunction<al_release_joystick>(_nativeAllegroLibrary, "al_release_joystick");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_get_joystick_active(IntPtr joy);
        public static al_get_joystick_active AlGetJoystickActive =
            NativeLibrary.LoadNativeFunction<al_get_joystick_active>(_nativeAllegroLibrary, "al_get_joystick_active");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_get_joystick_name(IntPtr joy);
        public static al_get_joystick_name AlGetJoystickName =
            NativeLibrary.LoadNativeFunction<al_get_joystick_name>(_nativeAllegroLibrary, "al_get_joystick_name");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_get_joystick_stick_name(IntPtr joy, int stick);
        public static al_get_joystick_stick_name AlGetJoystickStickName =
            NativeLibrary.LoadNativeFunction<al_get_joystick_stick_name>(_nativeAllegroLibrary, "al_get_joystick_stick_name");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_get_joystick_axis_name(IntPtr joy, int stick, int axis);
        public static al_get_joystick_axis_name AlGetJoystickAxisName =
            NativeLibrary.LoadNativeFunction<al_get_joystick_axis_name>(_nativeAllegroLibrary, "al_get_joystick_axis_name");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_get_joystick_button_name(IntPtr joy, int button);
        public static al_get_joystick_button_name AlGetJoystickButtonName =
            NativeLibrary.LoadNativeFunction<al_get_joystick_button_name>(_nativeAllegroLibrary, "al_get_joystick_button_name");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int al_get_joystick_stick_flags(IntPtr joy, int stick);
        public static al_get_joystick_stick_flags AlGetJoystickStickFlags =
            NativeLibrary.LoadNativeFunction<al_get_joystick_stick_flags>(_nativeAllegroLibrary, "al_get_joystick_stick_flags");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int al_get_joystick_num_sticks(IntPtr joy);
        public static al_get_joystick_num_sticks AlGetJoystickNumSticks =
            NativeLibrary.LoadNativeFunction<al_get_joystick_num_sticks>(_nativeAllegroLibrary, "al_get_joystick_num_sticks");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int al_get_joystick_num_axes(IntPtr joy, int stick);
        public static al_get_joystick_num_axes AlGetJoystickNumAxes =
            NativeLibrary.LoadNativeFunction<al_get_joystick_num_axes>(_nativeAllegroLibrary, "al_get_joystick_num_axes");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int al_get_joystick_num_buttons(IntPtr joy);
        public static al_get_joystick_num_buttons AlGetJoystickNumButtons =
            NativeLibrary.LoadNativeFunction<al_get_joystick_num_buttons>(_nativeAllegroLibrary, "al_get_joystick_num_buttons");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_get_joystick_state(IntPtr joy, ref NativeJoystickState retState);
        public static al_get_joystick_state AlGetJoystickState =
            NativeLibrary.LoadNativeFunction<al_get_joystick_state>(_nativeAllegroLibrary, "al_get_joystick_state");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_get_joystick_event_source();
        public static al_get_joystick_event_source AlGetJoystickEventSource =
            NativeLibrary.LoadNativeFunction<al_get_joystick_event_source>(_nativeAllegroLibrary, "al_get_joystick_event_source");
        #endregion

        #region Keyboard routines
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_install_keyboard();
        public static al_install_keyboard AlInstallKeyboard =
            NativeLibrary.LoadNativeFunction<al_install_keyboard>(_nativeAllegroLibrary, "al_install_keyboard");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_is_keyboard_installed();
        public static al_is_keyboard_installed AlIsKeyboardInstalled =
            NativeLibrary.LoadNativeFunction<al_is_keyboard_installed>(_nativeAllegroLibrary, "al_is_keyboard_installed");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_uninstall_keyboard();
        public static al_uninstall_keyboard AlUninstallKeyboard =
            NativeLibrary.LoadNativeFunction<al_uninstall_keyboard>(_nativeAllegroLibrary, "al_uninstall_keyboard");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_get_keyboard_state(ref NativeKeyboardState retState);
        public static al_get_keyboard_state AlGetKeyboardState =
            NativeLibrary.LoadNativeFunction<al_get_keyboard_state>(_nativeAllegroLibrary, "al_get_keyboard_state");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_clear_keyboard_state(IntPtr display);
        public static al_clear_keyboard_state AlClearKeyboardState =
            NativeLibrary.LoadNativeFunction<al_clear_keyboard_state>(_nativeAllegroLibrary, "al_clear_keyboard_state");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_key_down(ref NativeKeyboardState state, int keycode);
        public static al_key_down AlKeyDown =
            NativeLibrary.LoadNativeFunction<al_key_down>(_nativeAllegroLibrary, "al_key_down");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_keycode_to_name(int keycode);
        public static al_keycode_to_name AlKeycodeToName =
            NativeLibrary.LoadNativeFunction<al_keycode_to_name>(_nativeAllegroLibrary, "al_keycode_to_name");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_set_keyboard_leds(int leds);
        public static al_set_keyboard_leds AlSetKeyboardLeds =
            NativeLibrary.LoadNativeFunction<al_set_keyboard_leds>(_nativeAllegroLibrary, "al_set_keyboard_leds");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_get_keyboard_event_source();
        public static al_get_keyboard_event_source AlGetKeyboardEventSource =
            NativeLibrary.LoadNativeFunction<al_get_keyboard_event_source>(_nativeAllegroLibrary, "al_get_keyboard_event_source");
        #endregion

        #region Memory management routines
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_malloc_with_context(UIntPtr n, int line, [MarshalAs(UnmanagedType.LPStr)] string file, [MarshalAs(UnmanagedType.LPStr)] string func);
        public static al_malloc_with_context AlMallocWithContext =
            NativeLibrary.LoadNativeFunction<al_malloc_with_context>(_nativeAllegroLibrary, "al_malloc_with_context");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_free_with_context(IntPtr ptr, int line, [MarshalAs(UnmanagedType.LPStr)] string file, [MarshalAs(UnmanagedType.LPStr)] string func);
        public static al_free_with_context AlFreeWithContext =
            NativeLibrary.LoadNativeFunction<al_free_with_context>(_nativeAllegroLibrary, "al_free_with_context");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_realloc_with_context(IntPtr ptr, UIntPtr n, int line, [MarshalAs(UnmanagedType.LPStr)] string file, [MarshalAs(UnmanagedType.LPStr)] string func);
        public static al_realloc_with_context AlReallocWithContext =
            NativeLibrary.LoadNativeFunction<al_realloc_with_context>(_nativeAllegroLibrary, "al_realloc_with_context");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_calloc_with_context(UIntPtr count, UIntPtr n, int line, [MarshalAs(UnmanagedType.LPStr)] string file, [MarshalAs(UnmanagedType.LPStr)] string func);
        public static al_calloc_with_context AlCallocWithContext =
            NativeLibrary.LoadNativeFunction<al_calloc_with_context>(_nativeAllegroLibrary, "al_calloc_with_context");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_set_memory_interface(IntPtr memoryInterface);
        public static al_set_memory_interface AlSetMemoryInterface =
            NativeLibrary.LoadNativeFunction<al_set_memory_interface>(_nativeAllegroLibrary, "al_set_memory_interface");
        #endregion

        #region Monitor routines
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int al_get_new_display_adapter();
        public static al_get_new_display_adapter AlGetNewDisplayAdapter =
            NativeLibrary.LoadNativeFunction<al_get_new_display_adapter>(_nativeAllegroLibrary, "al_get_new_display_adapter");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_set_new_display_adapter(int adapter);
        public static al_set_new_display_adapter AlSetNewDIsplayAdapter =
            NativeLibrary.LoadNativeFunction<al_set_new_display_adapter>(_nativeAllegroLibrary, "al_set_new_display_adapter");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_get_monitor_info(int adapter, ref NativeMonitorInfo info);
        public static al_get_monitor_info AlGetMonitorInfo =
            NativeLibrary.LoadNativeFunction<al_get_monitor_info>(_nativeAllegroLibrary, "al_get_monitor_info");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int al_get_monitor_dpi(int adapter);
        public static al_get_monitor_dpi AlGetMonitorDpi =
            NativeLibrary.LoadNativeFunction<al_get_monitor_dpi>(_nativeAllegroLibrary, "al_get_monitor_dpi");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int al_get_num_video_adapters();
        public static al_get_num_video_adapters AlGetNumVideoAdapters =
            NativeLibrary.LoadNativeFunction<al_get_num_video_adapters>(_nativeAllegroLibrary, "al_get_num_video_adapters");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int al_get_monitor_refresh_rate(int adapter);
        public static al_get_monitor_refresh_rate AlGetMonitorRefreshRate =
            NativeLibrary.LoadNativeFunction<al_get_monitor_refresh_rate>(_nativeAllegroLibrary, "al_get_monitor_refresh_rate");
        #endregion

        #region Mouse routines
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_install_mouse();
        public static al_install_mouse AlInstallMouse =
            NativeLibrary.LoadNativeFunction<al_install_mouse>(_nativeAllegroLibrary, "al_install_mouse");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_is_mouse_installed();
        public static al_is_mouse_installed AlIsMouseInstalled =
            NativeLibrary.LoadNativeFunction<al_is_mouse_installed>(_nativeAllegroLibrary, "al_is_mouse_installed");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_uninstall_mouse();
        public static al_uninstall_mouse AlUninstallMouse =
            NativeLibrary.LoadNativeFunction<al_uninstall_mouse>(_nativeAllegroLibrary, "al_uninstall_mouse");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate uint al_get_mouse_num_axes();
        public static al_get_mouse_num_axes AlGetMouseNumAxes =
            NativeLibrary.LoadNativeFunction<al_get_mouse_num_axes>(_nativeAllegroLibrary, "al_get_mouse_num_axes");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate uint al_get_mouse_num_buttons();
        public static al_get_mouse_num_buttons AlGetMouseNumButtons =
            NativeLibrary.LoadNativeFunction<al_get_mouse_num_buttons>(_nativeAllegroLibrary, "al_get_mouse_num_buttons");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_get_mouse_state(ref NativeMouseState retState);
        public static al_get_mouse_state AlGetMouseState =
            NativeLibrary.LoadNativeFunction<al_get_mouse_state>(_nativeAllegroLibrary, "al_get_mouse_state");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int al_get_mouse_state_axis(ref NativeMouseState state, int axis);
        public static al_get_mouse_state_axis AlGetMouseStateAxis =
            NativeLibrary.LoadNativeFunction<al_get_mouse_state_axis>(_nativeAllegroLibrary, "al_get_mouse_state_axis");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_mouse_button_down(ref NativeMouseState state, int button);
        public static al_mouse_button_down AlMouseButtonDown =
            NativeLibrary.LoadNativeFunction<al_mouse_button_down>(_nativeAllegroLibrary, "al_mouse_button_down");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_set_mouse_xy(IntPtr display, int x, int y);
        public static al_set_mouse_xy AlSetMouseXy =
            NativeLibrary.LoadNativeFunction<al_set_mouse_xy>(_nativeAllegroLibrary, "al_set_mouse_xy");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_set_mouse_z(int z);
        public static al_set_mouse_z AlSetMouseZ =
            NativeLibrary.LoadNativeFunction<al_set_mouse_z>(_nativeAllegroLibrary, "al_set_mouse_z");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_set_mouse_w(int w);
        public static al_set_mouse_w AlSetMouseW =
            NativeLibrary.LoadNativeFunction<al_set_mouse_w>(_nativeAllegroLibrary, "al_set_mouse_w");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_set_mouse_axis(int which, int value);
        public static al_set_mouse_axis AlSetMouseAxis =
            NativeLibrary.LoadNativeFunction<al_set_mouse_axis>(_nativeAllegroLibrary, "al_set_mouse_axis");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_get_mouse_event_source();
        public static al_get_mouse_event_source AlGetMouseEventSource =
            NativeLibrary.LoadNativeFunction<al_get_mouse_event_source>(_nativeAllegroLibrary, "al_get_mouse_event_source");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_set_mouse_wheel_precision(int precision);
        public static al_set_mouse_wheel_precision AlSetMouseWheelPrecision =
            NativeLibrary.LoadNativeFunction<al_set_mouse_wheel_precision>(_nativeAllegroLibrary, "al_set_mouse_wheel_precision");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int al_get_mouse_wheel_precision();
        public static al_get_mouse_wheel_precision AlGetMouseWheelPrecision =
            NativeLibrary.LoadNativeFunction<al_get_mouse_wheel_precision>(_nativeAllegroLibrary, "al_get_mouse_wheel_precision");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_create_mouse_cursor(IntPtr bmp, int xFocus, int yFocus);
        public static al_create_mouse_cursor AlCreateMouseCursor =
            NativeLibrary.LoadNativeFunction<al_create_mouse_cursor>(_nativeAllegroLibrary, "al_create_mouse_cursor");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_destroy_mouse_cursor(IntPtr cursor);
        public static al_destroy_mouse_cursor AlDestroyMouseCursor =
            NativeLibrary.LoadNativeFunction<al_destroy_mouse_cursor>(_nativeAllegroLibrary, "al_destroy_mouse_cursor");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_set_mouse_cursor(IntPtr display, IntPtr cursor);
        public static al_set_mouse_cursor AlSetMouseCursor =
            NativeLibrary.LoadNativeFunction<al_set_mouse_cursor>(_nativeAllegroLibrary, "al_set_mouse_cursor");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_set_system_mouse_cursor(IntPtr display, int cursorId);
        public static al_set_system_mouse_cursor AlSetSystemMouseCursor =
            NativeLibrary.LoadNativeFunction<al_set_system_mouse_cursor>(_nativeAllegroLibrary, "al_set_system_mouse_cursor");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_get_mouse_cursor_position(ref int retX, ref int retY);
        public static al_get_mouse_cursor_position AlGetMouseCursorPosition =
            NativeLibrary.LoadNativeFunction<al_get_mouse_cursor_position>(_nativeAllegroLibrary, "al_get_mouse_cursor_position");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_hide_mouse_cursor(IntPtr display);
        public static al_hide_mouse_cursor AlHideMouseCursor =
            NativeLibrary.LoadNativeFunction<al_hide_mouse_cursor>(_nativeAllegroLibrary, "al_hide_mouse_cursor");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_show_mouse_cursor(IntPtr display);
        public static al_show_mouse_cursor AlShowMouseCursor =
            NativeLibrary.LoadNativeFunction<al_show_mouse_cursor>(_nativeAllegroLibrary, "al_show_mouse_cursor");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_grab_mouse(IntPtr display);
        public static al_grab_mouse AlGrabMouse =
            NativeLibrary.LoadNativeFunction<al_grab_mouse>(_nativeAllegroLibrary, "al_grab_mouse");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_ungrab_mouse();
        public static al_ungrab_mouse AlUngrabMouse =
            NativeLibrary.LoadNativeFunction<al_ungrab_mouse>(_nativeAllegroLibrary, "al_ungrab_mouse");
        #endregion

        #region Native dialogs support
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_init_native_dialog_addon();
        public static al_init_native_dialog_addon AlInitNativeDialogAddon =
            NativeLibrary.LoadNativeFunction<al_init_native_dialog_addon>(_nativeAllegroLibrary, "al_init_native_dialog_addon");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_is_native_dialog_addon_initialized();
        public static al_is_native_dialog_addon_initialized AlIsNativeDialogAddonInitialized =
            NativeLibrary.LoadNativeFunction<al_is_native_dialog_addon_initialized>(_nativeAllegroLibrary, "al_is_native_dialog_addon_initialized");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_shutdown_native_dialog_addon();
        public static al_shutdown_native_dialog_addon AlShutdownNativeDialogAddon =
            NativeLibrary.LoadNativeFunction<al_shutdown_native_dialog_addon>(_nativeAllegroLibrary, "al_shutdown_native_dialog_addon");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_create_native_file_dialog([MarshalAs(UnmanagedType.LPStr)] string initial_path, [MarshalAs(UnmanagedType.LPStr)] string title, [MarshalAs(UnmanagedType.LPStr)] string patterns, int mode);
        public static al_create_native_file_dialog AlCreateNativeFileDialog =
            NativeLibrary.LoadNativeFunction<al_create_native_file_dialog>(_nativeAllegroLibrary, "al_create_native_file_dialog");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_show_native_file_dialog(IntPtr display, IntPtr dialog);
        public static al_show_native_file_dialog AlShowNativeFileDialog =
            NativeLibrary.LoadNativeFunction<al_show_native_file_dialog>(_nativeAllegroLibrary, "al_show_native_file_dialog");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int al_get_native_file_dialog_count(IntPtr dialog);
        public static al_get_native_file_dialog_count AlGetNativeFileDialogCount =
            NativeLibrary.LoadNativeFunction<al_get_native_file_dialog_count>(_nativeAllegroLibrary, "al_get_native_file_dialog_count");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_get_native_file_dialog_path(IntPtr dialog, UIntPtr i);
        public static al_get_native_file_dialog_path AlGetNativeFileDialogPath =
            NativeLibrary.LoadNativeFunction<al_get_native_file_dialog_path>(_nativeAllegroLibrary, "al_get_native_file_dialog_path");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_destroy_native_file_dialog(IntPtr dialog);
        public static al_destroy_native_file_dialog AlDestroyNativeFileDialog =
            NativeLibrary.LoadNativeFunction<al_destroy_native_file_dialog>(_nativeAllegroLibrary, "al_destroy_native_file_dialog");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int al_show_native_message_box(IntPtr display, [MarshalAs(UnmanagedType.LPStr)] string title, [MarshalAs(UnmanagedType.LPStr)] string heading, [MarshalAs(UnmanagedType.LPStr)] string text, [MarshalAs(UnmanagedType.LPStr)] string buttons, int flags);
        public static al_show_native_message_box AlShowNativeMessageBox =
            NativeLibrary.LoadNativeFunction<al_show_native_message_box>(_nativeAllegroLibrary, "al_show_native_message_box");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_open_native_text_log([MarshalAs(UnmanagedType.LPStr)] string title, int flags);
        public static al_open_native_text_log AlOpenNativeTextLog =
            NativeLibrary.LoadNativeFunction<al_open_native_text_log>(_nativeAllegroLibrary, "al_open_native_text_log");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_close_native_text_log(IntPtr textlog);
        public static al_close_native_text_log AlCloseNativeTextLog =
            NativeLibrary.LoadNativeFunction<al_close_native_text_log>(_nativeAllegroLibrary, "al_close_native_text_log");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_append_native_text_log(IntPtr textlog, string format);
        public static al_append_native_text_log AlAppendNativeTextLog =
            NativeLibrary.LoadNativeFunction<al_append_native_text_log>(_nativeAllegroLibrary, "al_append_native_text_log");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_get_native_text_log_event_source(IntPtr textlog);
        public static al_get_native_text_log_event_source AlGetNativeTextLogEventSource =
            NativeLibrary.LoadNativeFunction<al_get_native_text_log_event_source>(_nativeAllegroLibrary, "al_get_native_text_log_event_source");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate uint al_get_allegro_native_dialog_version();
        public static al_get_allegro_native_dialog_version AlGetAllegroNativeDialogVersion =
            NativeLibrary.LoadNativeFunction<al_get_allegro_native_dialog_version>(_nativeAllegroLibrary, "al_get_allegro_native_dialog_version");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_create_menu();
        public static al_create_menu AlCreateMenu =
            NativeLibrary.LoadNativeFunction<al_create_menu>(_nativeAllegroLibrary, "al_create_menu");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_create_popup_menu();
        public static al_create_popup_menu AlCreatePopupMenu =
            NativeLibrary.LoadNativeFunction<al_create_popup_menu>(_nativeAllegroLibrary, "al_create_popup_menu");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_build_menu(IntPtr info);
        public static al_build_menu AlBuildMenu =
            NativeLibrary.LoadNativeFunction<al_build_menu>(_nativeAllegroLibrary, "al_build_menu");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int al_append_menu_item(IntPtr parent, [MarshalAs(UnmanagedType.LPStr)] string title, ushort id, int flags, IntPtr icon, IntPtr submenu);
        public static al_append_menu_item AlAppendMenuItem =
            NativeLibrary.LoadNativeFunction<al_append_menu_item>(_nativeAllegroLibrary, "al_append_menu_item");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int al_insert_menu_item(IntPtr parent, int pos, [MarshalAs(UnmanagedType.LPStr)] string title, ushort id, int flags, IntPtr icon, IntPtr submenu);
        public static al_insert_menu_item AlInsertMenuItem =
            NativeLibrary.LoadNativeFunction<al_insert_menu_item>(_nativeAllegroLibrary, "al_insert_menu_item");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_remove_menu_item(IntPtr menu, int pos);
        public static al_remove_menu_item AlRemoveMenuItem =
            NativeLibrary.LoadNativeFunction<al_remove_menu_item>(_nativeAllegroLibrary, "al_remove_menu_item");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_clone_menu(IntPtr menu);
        public static al_clone_menu AlCloneMenu =
            NativeLibrary.LoadNativeFunction<al_clone_menu>(_nativeAllegroLibrary, "al_clone_menu");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_clone_menu_for_popup(IntPtr menu);
        public static al_clone_menu_for_popup AlCloneMenuForPopup =
            NativeLibrary.LoadNativeFunction<al_clone_menu_for_popup>(_nativeAllegroLibrary, "al_clone_menu_for_popup");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_destroy_menu(IntPtr menu);
        public static al_destroy_menu AlDestroyMenu =
            NativeLibrary.LoadNativeFunction<al_destroy_menu>(_nativeAllegroLibrary, "al_destroy_menu");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_get_menu_item_caption(IntPtr menu, int pos);
        public static al_get_menu_item_caption AlGetMenuItemCaption =
            NativeLibrary.LoadNativeFunction<al_get_menu_item_caption>(_nativeAllegroLibrary, "al_get_menu_item_caption");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_set_menu_item_caption(IntPtr menu, int pos, [MarshalAs(UnmanagedType.LPStr)] string caption);
        public static al_set_menu_item_caption AlSetMenuItemCaption =
            NativeLibrary.LoadNativeFunction<al_set_menu_item_caption>(_nativeAllegroLibrary, "al_set_menu_item_caption");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int al_get_menu_item_flags(IntPtr menu, int pos);
        public static al_get_menu_item_flags AlGetMenuItemFlags =
            NativeLibrary.LoadNativeFunction<al_get_menu_item_flags>(_nativeAllegroLibrary, "al_get_menu_item_flags");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_set_menu_item_flags(IntPtr menu, int pos, int flags);
        public static al_set_menu_item_flags AlSetMenuItemFlags =
            NativeLibrary.LoadNativeFunction<al_set_menu_item_flags>(_nativeAllegroLibrary, "al_set_menu_item_flags");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_get_menu_item_icon(IntPtr menu, int pos);
        public static al_get_menu_item_icon AlGetMenuItemIcon =
            NativeLibrary.LoadNativeFunction<al_get_menu_item_icon>(_nativeAllegroLibrary, "al_get_menu_item_icon");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_set_menu_item_icon(IntPtr menu, int pos, IntPtr icon);
        public static al_set_menu_item_icon AlSetMenuItemIcon =
            NativeLibrary.LoadNativeFunction<al_set_menu_item_icon>(_nativeAllegroLibrary, "al_set_menu_item_icon");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_find_menu(IntPtr haystack, ushort id);
        public static al_find_menu AlFindMenu =
            NativeLibrary.LoadNativeFunction<al_find_menu>(_nativeAllegroLibrary, "al_find_menu");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_find_menu_item(IntPtr haystack, ushort id, ref IntPtr menu, ref int index);
        public static al_find_menu_item AlFindMenuItem =
            NativeLibrary.LoadNativeFunction<al_find_menu_item>(_nativeAllegroLibrary, "al_find_menu_item");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_get_default_menu_event_source();
        public static al_get_default_menu_event_source AlGetDefaultMenuEventSource =
            NativeLibrary.LoadNativeFunction<al_get_default_menu_event_source>(_nativeAllegroLibrary, "al_get_default_menu_event_source");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_enable_menu_event_source(IntPtr menu);
        public static al_enable_menu_event_source AlEnableMenuEventSource =
            NativeLibrary.LoadNativeFunction<al_enable_menu_event_source>(_nativeAllegroLibrary, "al_enable_menu_event_source");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_disable_menu_event_source(IntPtr menu);
        public static al_disable_menu_event_source AlDisableMenuEventSource =
            NativeLibrary.LoadNativeFunction<al_disable_menu_event_source>(_nativeAllegroLibrary, "al_disable_menu_event_source");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_get_display_menu(IntPtr display);
        public static al_get_display_menu AlGetDisplayMenu =
            NativeLibrary.LoadNativeFunction<al_get_display_menu>(_nativeAllegroLibrary, "al_get_display_menu");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_set_display_menu(IntPtr display, IntPtr menu);
        public static al_set_display_menu AlSetDisplayMenu =
            NativeLibrary.LoadNativeFunction<al_set_display_menu>(_nativeAllegroLibrary, "al_set_display_menu");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_popup_menu(IntPtr popup, IntPtr display);
        public static al_popup_menu AlPopupMenu =
            NativeLibrary.LoadNativeFunction<al_popup_menu>(_nativeAllegroLibrary, "al_popup_menu");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_remove_display_menu(IntPtr display);
        public static al_remove_display_menu AlRemoveDisplayMenu =
            NativeLibrary.LoadNativeFunction<al_remove_display_menu>(_nativeAllegroLibrary, "al_remove_display_menu");
        #endregion

        #region Path structures
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_create_path([MarshalAs(UnmanagedType.LPStr)] string str);
        public static al_create_path AlCreatePath =
            NativeLibrary.LoadNativeFunction<al_create_path>(_nativeAllegroLibrary, "al_create_path");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_create_path_for_directory([MarshalAs(UnmanagedType.LPStr)] string str);
        public static al_create_path_for_directory AlCreatePathForDirectory =
            NativeLibrary.LoadNativeFunction<al_create_path_for_directory>(_nativeAllegroLibrary, "al_create_path_for_directory");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_destroy_path(IntPtr path);
        public static al_destroy_path AlDestroyPath =
            NativeLibrary.LoadNativeFunction<al_destroy_path>(_nativeAllegroLibrary, "al_destroy_path");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_clone_path(IntPtr path);
        public static al_clone_path AlClonePath =
            NativeLibrary.LoadNativeFunction<al_clone_path>(_nativeAllegroLibrary, "al_clone_path");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_join_paths(IntPtr path, IntPtr tail);
        public static al_join_paths AlJoinPaths =
            NativeLibrary.LoadNativeFunction<al_join_paths>(_nativeAllegroLibrary, "al_join_paths");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_rebase_path(IntPtr head, IntPtr tail);
        public static al_rebase_path AlRebasePath =
            NativeLibrary.LoadNativeFunction<al_rebase_path>(_nativeAllegroLibrary, "al_rebase_path");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_get_path_drive(IntPtr path);
        public static al_get_path_drive AlGetPathDrive =
            NativeLibrary.LoadNativeFunction<al_get_path_drive>(_nativeAllegroLibrary, "al_get_path_drive");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int al_get_path_num_components(IntPtr path);
        public static al_get_path_num_components AlGetPathNumComponents =
            NativeLibrary.LoadNativeFunction<al_get_path_num_components>(_nativeAllegroLibrary, "al_get_path_num_components");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_get_path_component(IntPtr path, int i);
        public static al_get_path_component AlGetPathComponent =
            NativeLibrary.LoadNativeFunction<al_get_path_component>(_nativeAllegroLibrary, "al_get_path_component");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_get_path_tail(IntPtr path);
        public static al_get_path_tail AlGetPathTail =
            NativeLibrary.LoadNativeFunction<al_get_path_tail>(_nativeAllegroLibrary, "al_get_path_tail");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_get_path_filename(IntPtr path);
        public static al_get_path_filename AlGetPathFilename =
            NativeLibrary.LoadNativeFunction<al_get_path_filename>(_nativeAllegroLibrary, "al_get_path_filename");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_get_path_basename(IntPtr path);
        public static al_get_path_basename AlGetPathBasename =
            NativeLibrary.LoadNativeFunction<al_get_path_basename>(_nativeAllegroLibrary, "al_get_path_basename");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_get_path_extension(IntPtr path);
        public static al_get_path_extension AlGetPathExtension =
            NativeLibrary.LoadNativeFunction<al_get_path_extension>(_nativeAllegroLibrary, "al_get_path_extension");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_set_path_drive(IntPtr path, [MarshalAs(UnmanagedType.LPStr)] string drive);
        public static al_set_path_drive AlSetPathDrive =
            NativeLibrary.LoadNativeFunction<al_set_path_drive>(_nativeAllegroLibrary, "al_set_path_drive");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_append_path_component(IntPtr path, [MarshalAs(UnmanagedType.LPStr)] string s);
        public static al_append_path_component AlAppendPathComponent =
            NativeLibrary.LoadNativeFunction<al_append_path_component>(_nativeAllegroLibrary, "al_append_path_component");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_insert_path_component(IntPtr path, int i, [MarshalAs(UnmanagedType.LPStr)] string s);
        public static al_insert_path_component AlInsertPathComponent =
            NativeLibrary.LoadNativeFunction<al_insert_path_component>(_nativeAllegroLibrary, "al_insert_path_component");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_replace_path_component(IntPtr path, int i, [MarshalAs(UnmanagedType.LPStr)] string s);
        public static al_replace_path_component AlReplacePathComponent =
            NativeLibrary.LoadNativeFunction<al_replace_path_component>(_nativeAllegroLibrary, "al_replace_path_component");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_remove_path_component(IntPtr path, int i);
        public static al_remove_path_component AlRemovePathComponent =
            NativeLibrary.LoadNativeFunction<al_remove_path_component>(_nativeAllegroLibrary, "al_remove_path_component");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_drop_path_tail(IntPtr path);
        public static al_drop_path_tail AlDropPathTail =
            NativeLibrary.LoadNativeFunction<al_drop_path_tail>(_nativeAllegroLibrary, "al_drop_path_tail");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_set_path_filename(IntPtr path, [MarshalAs(UnmanagedType.LPStr)] string filename);
        public static al_set_path_filename AlSetPathFilename =
            NativeLibrary.LoadNativeFunction<al_set_path_filename>(_nativeAllegroLibrary, "al_set_path_filename");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_set_path_extension(IntPtr path, [MarshalAs(UnmanagedType.LPStr)] string extension);
        public static al_set_path_extension AlSetPathExtension =
            NativeLibrary.LoadNativeFunction<al_set_path_extension>(_nativeAllegroLibrary, "al_set_path_extension");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_path_cstr(IntPtr path, char delim);
        public static al_path_cstr AlPathCstr =
            NativeLibrary.LoadNativeFunction<al_path_cstr>(_nativeAllegroLibrary, "al_path_cstr");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_path_ustr(IntPtr path, char delim);
        public static al_path_ustr AlPathUstr =
            NativeLibrary.LoadNativeFunction<al_path_ustr>(_nativeAllegroLibrary, "al_path_ustr");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_make_path_canonical(IntPtr path);
        public static al_make_path_canonical AlMakePathCanonical =
            NativeLibrary.LoadNativeFunction<al_make_path_canonical>(_nativeAllegroLibrary, "al_make_path_canonical");
        #endregion

        #region PhysicsFS integration
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_set_physfs_file_interface();
        public static al_set_physfs_file_interface AlSetPhysfsFileInterface =
            NativeLibrary.LoadNativeFunction<al_set_physfs_file_interface>(_nativeAllegroLibrary, "al_set_physfs_file_interface");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate uint al_get_allegro_physfs_version();
        public static al_get_allegro_physfs_version AlGetAllegroPhysfsVersion =
            NativeLibrary.LoadNativeFunction<al_get_allegro_physfs_version>(_nativeAllegroLibrary, "al_get_allegro_physfs_version");
        #endregion

        #region Shader routines
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_create_shader(int platform);
        public static al_create_shader AlCreateShader =
            NativeLibrary.LoadNativeFunction<al_create_shader>(_nativeAllegroLibrary, "al_create_shader");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_attach_shader_source(IntPtr shader, int type, [MarshalAs(UnmanagedType.LPStr)] string source);
        public static al_attach_shader_source AlAttachShaderSource =
            NativeLibrary.LoadNativeFunction<al_attach_shader_source>(_nativeAllegroLibrary, "al_attach_shader_source");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_attach_shader_source_file(IntPtr shader, ShaderType type, [MarshalAs(UnmanagedType.LPStr)] string filename);
        public static al_attach_shader_source_file AlAttachShaderSourceFile =
            NativeLibrary.LoadNativeFunction<al_attach_shader_source_file>(_nativeAllegroLibrary, "al_attach_shader_source_file");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_build_shader(IntPtr shader);
        public static al_build_shader AlBuildShader =
            NativeLibrary.LoadNativeFunction<al_build_shader>(_nativeAllegroLibrary, "al_build_shader");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_get_shader_log(IntPtr shader);
        public static al_get_shader_log AlGetShaderLog =
            NativeLibrary.LoadNativeFunction<al_get_shader_log>(_nativeAllegroLibrary, "al_get_shader_log");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int al_get_shader_platform(IntPtr shader);
        public static al_get_shader_platform AlGetShaderPlatform =
            NativeLibrary.LoadNativeFunction<al_get_shader_platform>(_nativeAllegroLibrary, "al_get_shader_platform");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_use_shader(IntPtr shader);
        public static al_use_shader AlUseShader =
            NativeLibrary.LoadNativeFunction<al_use_shader>(_nativeAllegroLibrary, "al_use_shader");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_destroy_shader(IntPtr shader);
        public static al_destroy_shader AlDestroyShader =
            NativeLibrary.LoadNativeFunction<al_destroy_shader>(_nativeAllegroLibrary, "al_destroy_shader");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_set_shader_sampler([MarshalAs(UnmanagedType.LPStr)] string name, IntPtr bitmap, int unit);
        public static al_set_shader_sampler AlSetShaderSampler =
            NativeLibrary.LoadNativeFunction<al_set_shader_sampler>(_nativeAllegroLibrary, "al_set_shader_sampler");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_set_shader_matrix([MarshalAs(UnmanagedType.LPStr)] string name, ref NativeTransform matrix);
        public static al_set_shader_matrix AlSetShaderMatrix =
            NativeLibrary.LoadNativeFunction<al_set_shader_matrix>(_nativeAllegroLibrary, "al_set_shader_matrix");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_set_shader_int([MarshalAs(UnmanagedType.LPStr)] string name, int i);
        public static al_set_shader_int AlSetShaderInt =
            NativeLibrary.LoadNativeFunction<al_set_shader_int>(_nativeAllegroLibrary, "al_set_shader_int");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_set_shader_float([MarshalAs(UnmanagedType.LPStr)] string name, float f);
        public static al_set_shader_float AlSetShaderFloat =
            NativeLibrary.LoadNativeFunction<al_set_shader_float>(_nativeAllegroLibrary, "al_set_shader_float");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_set_shader_bool([MarshalAs(UnmanagedType.LPStr)] string name, bool b);
        public static al_set_shader_bool AlSetShaderBool =
            NativeLibrary.LoadNativeFunction<al_set_shader_bool>(_nativeAllegroLibrary, "al_set_shader_bool");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_set_shader_int_vector([MarshalAs(UnmanagedType.LPStr)] string name, int num_components, ref int i, int num_elems);
        public static al_set_shader_int_vector AlSetShaderIntVector =
            NativeLibrary.LoadNativeFunction<al_set_shader_int_vector>(_nativeAllegroLibrary, "al_set_shader_int_vector");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_set_shader_float_vector([MarshalAs(UnmanagedType.LPStr)] string name, int num_components, ref float f, int num_elems);
        public static al_set_shader_float_vector AlSetShaderFloatVector =
            NativeLibrary.LoadNativeFunction<al_set_shader_float_vector>(_nativeAllegroLibrary, "al_set_shader_float_vector");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_get_default_shader_source(int platform, int type);
        public static al_get_default_shader_source AlGetDefaultShaderSource =
            NativeLibrary.LoadNativeFunction<al_get_default_shader_source>(_nativeAllegroLibrary, "al_get_default_shader_source");
        #endregion

        #region State routines
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_restore_state(ref NativeState state);
        public static al_restore_state AlRestoreState =
            NativeLibrary.LoadNativeFunction<al_restore_state>(_nativeAllegroLibrary, "al_restore_state");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_store_state(ref NativeState state, int flags);
        public static al_store_state AlStoreState =
            NativeLibrary.LoadNativeFunction<al_store_state>(_nativeAllegroLibrary, "al_store_state");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int al_get_errno();
        public static al_get_errno AlGetErrno =
            NativeLibrary.LoadNativeFunction<al_get_errno>(_nativeAllegroLibrary, "al_get_errno");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_set_errno(int errnum);
        public static al_set_errno AlSetErrno =
            NativeLibrary.LoadNativeFunction<al_set_errno>(_nativeAllegroLibrary, "al_set_errno");
        #endregion

        #region System routines
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int al_get_allegro_version();
        public static al_get_allegro_version AlGetAllegroVersion =
            NativeLibrary.LoadNativeFunction<al_get_allegro_version>(_nativeAllegroLibrary, "al_get_allegro_version");
            
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_get_app_name();
        public static al_get_app_name AlGetAppName =
            NativeLibrary.LoadNativeFunction<al_get_app_name>(_nativeAllegroLibrary, "al_get_app_name");
            
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int al_get_cpu_count();
        public static al_get_cpu_count AlGetCpuCount =
            NativeLibrary.LoadNativeFunction<al_get_cpu_count>(_nativeAllegroLibrary, "al_get_cpu_count");
            
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_get_org_name();
        public static al_get_org_name AlGetOrgName =
            NativeLibrary.LoadNativeFunction<al_get_org_name>(_nativeAllegroLibrary, "al_get_org_name");
            
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int al_get_ram_size();
        public static al_get_ram_size AlGetRamSize =
            NativeLibrary.LoadNativeFunction<al_get_ram_size>(_nativeAllegroLibrary, "al_get_ram_size");
            
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_get_standard_path(int id);
        public static al_get_standard_path AlGetStandardPath =
            NativeLibrary.LoadNativeFunction<al_get_standard_path>(_nativeAllegroLibrary, "al_get_standard_path");
            
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_get_system_config();
        public static al_get_system_config AlGetSystemConfig =
            NativeLibrary.LoadNativeFunction<al_get_system_config>(_nativeAllegroLibrary, "al_get_system_config");
            
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int al_get_system_id();
        public static al_get_system_id AlGetSystemID =
            NativeLibrary.LoadNativeFunction<al_get_system_id>(_nativeAllegroLibrary, "al_get_system_id");
            
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_install_system(int version, IntPtr atExitPtr);
        public static al_install_system AlInstallSystem =
            NativeLibrary.LoadNativeFunction<al_install_system>(_nativeAllegroLibrary, "al_install_system");
            
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_is_system_installed();
        public static al_is_system_installed AlIsSystemInstalled =
            NativeLibrary.LoadNativeFunction<al_is_system_installed>(_nativeAllegroLibrary, "al_is_system_installed");
            
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_register_assert_handler(Delegates.AssertHandler assertHandler);
        public static al_register_assert_handler AlRegisterAssertHandler =
            NativeLibrary.LoadNativeFunction<al_register_assert_handler>(_nativeAllegroLibrary, "al_register_assert_handler");
            
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_register_trace_handler(Delegates.TraceHandler traceHandler);
        public static al_register_trace_handler AlRegisterTraceHandler =
            NativeLibrary.LoadNativeFunction<al_register_trace_handler>(_nativeAllegroLibrary, "al_register_trace_handler");
            
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_set_app_name([MarshalAs(UnmanagedType.LPStr)] string name);
        public static al_set_app_name AlSetAppName =
            NativeLibrary.LoadNativeFunction<al_set_app_name>(_nativeAllegroLibrary, "al_set_app_name");
            
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_set_exe_name([MarshalAs(UnmanagedType.LPStr)] string name);
        public static al_set_exe_name AlSetExeName =
            NativeLibrary.LoadNativeFunction<al_set_exe_name>(_nativeAllegroLibrary, "al_set_exe_name");
            
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_set_org_name([MarshalAs(UnmanagedType.LPStr)] string name);
        public static al_set_org_name AlSetOrgName =
            NativeLibrary.LoadNativeFunction<al_set_org_name>(_nativeAllegroLibrary, "al_set_org_name");
            
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_uninstall_system();
        public static al_uninstall_system AlUninstallSystem =
            NativeLibrary.LoadNativeFunction<al_uninstall_system>(_nativeAllegroLibrary, "al_uninstall_system");
        #endregion

        #region Thread routines
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_create_thread(AlConstants.ThreadProcessDelegate proc, IntPtr arg);
        public static al_create_thread AlCreateThread =
            NativeLibrary.LoadNativeFunction<al_create_thread>(_nativeAllegroLibrary, "al_create_thread");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_start_thread(IntPtr thread);
        public static al_start_thread AlStartThread =
            NativeLibrary.LoadNativeFunction<al_start_thread>(_nativeAllegroLibrary, "al_start_thread");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_join_thread(IntPtr thread, ref IntPtr ret_value);
        public static al_join_thread AlJoinThread =
            NativeLibrary.LoadNativeFunction<al_join_thread>(_nativeAllegroLibrary, "al_join_thread");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_set_thread_should_stop(IntPtr thread);
        public static al_set_thread_should_stop AlSetThreadShouldStop =
            NativeLibrary.LoadNativeFunction<al_set_thread_should_stop>(_nativeAllegroLibrary, "al_set_thread_should_stop");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_get_thread_should_stop(IntPtr thread);
        public static al_get_thread_should_stop AlGetThreadShouldStop =
            NativeLibrary.LoadNativeFunction<al_get_thread_should_stop>(_nativeAllegroLibrary, "al_get_thread_should_stop");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_destroy_thread(IntPtr thread);
        public static al_destroy_thread AlDestroyThread =
            NativeLibrary.LoadNativeFunction<al_destroy_thread>(_nativeAllegroLibrary, "al_destroy_thread");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_run_detached_thread(AlConstants.DetachedThreadProcessDelegate proc, IntPtr arg);
        public static al_run_detached_thread AlRunDetachedThread =
            NativeLibrary.LoadNativeFunction<al_run_detached_thread>(_nativeAllegroLibrary, "al_run_detached_thread");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_create_mutex();
        public static al_create_mutex AlCreateMutex =
            NativeLibrary.LoadNativeFunction<al_create_mutex>(_nativeAllegroLibrary, "al_create_mutex");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_create_mutex_recursive();
        public static al_create_mutex_recursive AlCreateMutexRecursive =
            NativeLibrary.LoadNativeFunction<al_create_mutex_recursive>(_nativeAllegroLibrary, "al_create_mutex_recursive");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_lock_mutex(IntPtr mutex);
        public static al_lock_mutex AlLockMutex =
            NativeLibrary.LoadNativeFunction<al_lock_mutex>(_nativeAllegroLibrary, "al_lock_mutex");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_unlock_mutex(IntPtr mutex);
        public static al_unlock_mutex AlUnlockMutex =
            NativeLibrary.LoadNativeFunction<al_unlock_mutex>(_nativeAllegroLibrary, "al_unlock_mutex");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_destroy_mutex(IntPtr mutex);
        public static al_destroy_mutex AlDestroyMutex =
            NativeLibrary.LoadNativeFunction<al_destroy_mutex>(_nativeAllegroLibrary, "al_destroy_mutex");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_create_cond();
        public static al_create_cond AlCreateCond =
            NativeLibrary.LoadNativeFunction<al_create_cond>(_nativeAllegroLibrary, "al_create_cond");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_destroy_cond(IntPtr cond);
        public static al_destroy_cond AlDestroyCond =
            NativeLibrary.LoadNativeFunction<al_destroy_cond>(_nativeAllegroLibrary, "al_destroy_cond");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_wait_cond(IntPtr cond, IntPtr mutex);
        public static al_wait_cond AlWaitCond =
            NativeLibrary.LoadNativeFunction<al_wait_cond>(_nativeAllegroLibrary, "al_wait_cond");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int al_wait_cond_until(IntPtr cond, IntPtr mutex, ref NativeAllegroTimeout timeout);
        public static al_wait_cond_until AlWaitCondUntil =
            NativeLibrary.LoadNativeFunction<al_wait_cond_until>(_nativeAllegroLibrary, "al_wait_cond_until");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_broadcast_cond(IntPtr cond);
        public static al_broadcast_cond AlBroadcastCond =
            NativeLibrary.LoadNativeFunction<al_broadcast_cond>(_nativeAllegroLibrary, "al_broadcast_cond");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_signal_cond(IntPtr cond);
        public static al_signal_cond AlSignalCond =
            NativeLibrary.LoadNativeFunction<al_signal_cond>(_nativeAllegroLibrary, "al_signal_cond");
        #endregion

        #region Time routines
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate double al_get_time();
        public static al_get_time AlGetTime =
            NativeLibrary.LoadNativeFunction<al_get_time>(_nativeAllegroLibrary, "al_get_time");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_init_timeout(ref NativeAllegroTimeout timeout, double seconds);
        public static al_init_timeout AlInitTimeout =
            NativeLibrary.LoadNativeFunction<al_init_timeout>(_nativeAllegroLibrary, "al_init_timeout");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_rest(double seconds);
        public static al_rest AlRest =
            NativeLibrary.LoadNativeFunction<al_rest>(_nativeAllegroLibrary, "al_rest");
        #endregion

        #region Timer routines
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_create_timer(double speedSecs);
        public static al_create_timer AlCreateTimer =
            NativeLibrary.LoadNativeFunction<al_create_timer>(_nativeAllegroLibrary, "al_create_timer");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_start_timer(IntPtr timer);
        public static al_start_timer AlStartTimer =
            NativeLibrary.LoadNativeFunction<al_start_timer>(_nativeAllegroLibrary, "al_start_timer");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_resume_timer(IntPtr timer);
        public static al_resume_timer AlResumeTimer =
            NativeLibrary.LoadNativeFunction<al_resume_timer>(_nativeAllegroLibrary, "al_resume_timer");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_stop_timer(IntPtr timer);
        public static al_stop_timer AlStopTimer =
            NativeLibrary.LoadNativeFunction<al_stop_timer>(_nativeAllegroLibrary, "al_stop_timer");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_get_timer_started(IntPtr timer);
        public static al_get_timer_started AlGetTimerStarted =
            NativeLibrary.LoadNativeFunction<al_get_timer_started>(_nativeAllegroLibrary, "al_get_timer_started");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_destroy_timer(IntPtr timer);
        public static al_destroy_timer AlDestroyTimer =
            NativeLibrary.LoadNativeFunction<al_destroy_timer>(_nativeAllegroLibrary, "al_destroy_timer");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate long al_get_timer_count(IntPtr timer);
        public static al_get_timer_count AlGetTimerCount =
            NativeLibrary.LoadNativeFunction<al_get_timer_count>(_nativeAllegroLibrary, "al_get_timer_count");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_set_timer_count(IntPtr timer, long newCount);
        public static al_set_timer_count AlSetTimerCount =
            NativeLibrary.LoadNativeFunction<al_set_timer_count>(_nativeAllegroLibrary, "al_set_timer_count");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_add_timer_count(IntPtr timer, long diff);
        public static al_add_timer_count AlAddTimerCount =
            NativeLibrary.LoadNativeFunction<al_add_timer_count>(_nativeAllegroLibrary, "al_add_timer_count");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate double al_get_timer_speed(IntPtr timer);
        public static al_get_timer_speed AlGetTimerSpeed =
            NativeLibrary.LoadNativeFunction<al_get_timer_speed>(_nativeAllegroLibrary, "al_get_timer_speed");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_set_timer_speed(IntPtr timer, double newSpeedSecs);
        public static al_set_timer_speed AlSetTimerSpeed =
            NativeLibrary.LoadNativeFunction<al_set_timer_speed>(_nativeAllegroLibrary, "al_set_timer_speed");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_get_timer_event_source(IntPtr timer);
        public static al_get_timer_event_source AlGetTimerEventSource =
            NativeLibrary.LoadNativeFunction<al_get_timer_event_source>(_nativeAllegroLibrary, "al_get_timer_event_source");
        #endregion

        #region Transformations routines
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_copy_transform(ref NativeTransform dest, ref NativeTransform src);
        public static al_copy_transform AlCopyTransform =
            NativeLibrary.LoadNativeFunction<al_copy_transform>(_nativeAllegroLibrary, "al_copy_transform");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_use_transform(ref NativeTransform trans);
        public static al_use_transform AlUseTransform =
            NativeLibrary.LoadNativeFunction<al_use_transform>(_nativeAllegroLibrary, "al_use_transform");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_get_current_transform();
        public static al_get_current_transform AlGetCurrentTransform =
            NativeLibrary.LoadNativeFunction<al_get_current_transform>(_nativeAllegroLibrary, "al_get_current_transform");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_use_projection_transform(ref NativeTransform trans);
        public static al_use_projection_transform AlUseProjectionTransform =
            NativeLibrary.LoadNativeFunction<al_use_projection_transform>(_nativeAllegroLibrary, "al_use_projection_transform");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_get_current_projection_transform();
        public static al_get_current_projection_transform AlGetCurrentProjectionTransform =
            NativeLibrary.LoadNativeFunction<al_get_current_projection_transform>(_nativeAllegroLibrary, "al_get_current_projection_transform");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_get_current_inverse_transform();
        public static al_get_current_inverse_transform AlGetCurrentInverseTransform =
            NativeLibrary.LoadNativeFunction<al_get_current_inverse_transform>(_nativeAllegroLibrary, "al_get_current_inverse_transform");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_invert_transform(ref NativeTransform trans);
        public static al_invert_transform AlInvertTransform =
            NativeLibrary.LoadNativeFunction<al_invert_transform>(_nativeAllegroLibrary, "al_invert_transform");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_transpose_transform(ref NativeTransform trans);
        public static al_transpose_transform AlTransposeTransform =
            NativeLibrary.LoadNativeFunction<al_transpose_transform>(_nativeAllegroLibrary, "al_transpose_transform");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int al_check_inverse(ref NativeTransform trans, float tol);
        public static al_check_inverse AlCheckInverse =
            NativeLibrary.LoadNativeFunction<al_check_inverse>(_nativeAllegroLibrary, "al_check_inverse");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_identity_transform(ref NativeTransform trans);
        public static al_identity_transform AlIdentityTransform =
            NativeLibrary.LoadNativeFunction<al_identity_transform>(_nativeAllegroLibrary, "al_identity_transform");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_build_transform(ref NativeTransform trans, float x, float y, float sx, float sy, float theta);
        public static al_build_transform AlBuildTransform =
            NativeLibrary.LoadNativeFunction<al_build_transform>(_nativeAllegroLibrary, "al_build_transform");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_build_camera_transform(ref NativeTransform trans, float position_x, float position_y, float position_z, float look_x, float look_y, float look_z, float up_x, float up_y, float up_z);
        public static al_build_camera_transform AlBuildCameraTransform =
            NativeLibrary.LoadNativeFunction<al_build_camera_transform>(_nativeAllegroLibrary, "al_build_camera_transform");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_translate_transform(ref NativeTransform trans, float x, float y);
        public static al_translate_transform AlTranslateTransform =
            NativeLibrary.LoadNativeFunction<al_translate_transform>(_nativeAllegroLibrary, "al_translate_transform");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_rotate_transform(ref NativeTransform trans, float theta);
        public static al_rotate_transform AlRotateTransform =
            NativeLibrary.LoadNativeFunction<al_rotate_transform>(_nativeAllegroLibrary, "al_rotate_transform");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_scale_transform(ref NativeTransform trans, float sx, float sy);
        public static al_scale_transform AlScaleTransform =
            NativeLibrary.LoadNativeFunction<al_scale_transform>(_nativeAllegroLibrary, "al_scale_transform");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_transform_coordinates(ref NativeTransform trans, ref float x, ref float y);
        public static al_transform_coordinates AlTransformCoordinates =
            NativeLibrary.LoadNativeFunction<al_transform_coordinates>(_nativeAllegroLibrary, "al_transform_coordinates");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_transform_coordinates_3d(ref NativeTransform trans, ref float x, ref float y, ref float z);
        public static al_transform_coordinates_3d AlTransformCoordinates3d =
            NativeLibrary.LoadNativeFunction<al_transform_coordinates_3d>(_nativeAllegroLibrary, "al_transform_coordinates_3d");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_transform_coordinates_4d(ref NativeTransform trans, ref float x, ref float y, ref float z, ref float w);
        public static al_transform_coordinates_4d AlTransformCoordinates4d =
            NativeLibrary.LoadNativeFunction<al_transform_coordinates_4d>(_nativeAllegroLibrary, "al_transform_coordinates_4d");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_transform_coordinates_3d_projective(ref NativeTransform trans, ref float x, ref float y, ref float z);
        public static al_transform_coordinates_3d_projective AlTransformCoordinates3dProjective =
            NativeLibrary.LoadNativeFunction<al_transform_coordinates_3d_projective>(_nativeAllegroLibrary, "al_transform_coordinates_3d_projective");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_compose_transform(ref NativeTransform trans, ref NativeTransform other);
        public static al_compose_transform AlComposeTransform =
            NativeLibrary.LoadNativeFunction<al_compose_transform>(_nativeAllegroLibrary, "al_compose_transform");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_orthographic_transform(ref NativeTransform trans, float left, float top, float n, float right, float bottom, float f);
        public static al_orthographic_transform AlOrthographicTransform =
            NativeLibrary.LoadNativeFunction<al_orthographic_transform>(_nativeAllegroLibrary, "al_orthographic_transform");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_perspective_transform(ref NativeTransform trans, float left, float top, float n, float right, float bottom, float f);
        public static al_perspective_transform AlPerspectiveTransform =
            NativeLibrary.LoadNativeFunction<al_perspective_transform>(_nativeAllegroLibrary, "al_perspective_transform");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_translate_transform_3d(ref NativeTransform trans, float x, float y, float z);
        public static al_translate_transform_3d AlTranslateTransform3d =
            NativeLibrary.LoadNativeFunction<al_translate_transform_3d>(_nativeAllegroLibrary, "al_translate_transform_3d");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_scale_transform_3d(ref NativeTransform trans, float sx, float sy, float sz);
        public static al_scale_transform_3d AlScaleTransform3d =
            NativeLibrary.LoadNativeFunction<al_scale_transform_3d>(_nativeAllegroLibrary, "al_scale_transform_3d");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_rotate_transform_3d(ref NativeTransform trans, float x, float y, float z, float angle);
        public static al_rotate_transform_3d AlRotateTransform3d =
            NativeLibrary.LoadNativeFunction<al_rotate_transform_3d>(_nativeAllegroLibrary, "al_rotate_transform_3d");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_horizontal_shear_transform(ref NativeTransform trans, float theta);
        public static al_horizontal_shear_transform AlHorizontalShearTransform =
            NativeLibrary.LoadNativeFunction<al_horizontal_shear_transform>(_nativeAllegroLibrary, "al_horizontal_shear_transform");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_vertical_shear_transform(ref NativeTransform trans, float theta);
        public static al_vertical_shear_transform AlVerticalShearTransform =
            NativeLibrary.LoadNativeFunction<al_vertical_shear_transform>(_nativeAllegroLibrary, "al_vertical_shear_transform");
        #endregion
    }
}
