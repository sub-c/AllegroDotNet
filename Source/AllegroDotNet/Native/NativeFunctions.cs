﻿using SubC.AllegroDotNet.Models;
using System;
using System.Runtime.InteropServices;
using static SubC.AllegroDotNet.Native.NativeDelegates;

namespace SubC.AllegroDotNet.Native
{
  internal static class NativeFunctions
  {
    private static readonly IntPtr _allegroLibrary = NativeInterop.LoadAllegroLibrary();

    #region Audio codecs routines

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_init_acodec_addon();

    public static al_init_acodec_addon AlInitAcodecAddon =
        NativeInterop.LoadFunction<al_init_acodec_addon>(_allegroLibrary, nameof(al_init_acodec_addon));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_is_acodec_addon_initialized();

    public static al_is_acodec_addon_initialized AlIsAcodecAddonInitialized =
        NativeInterop.LoadFunction<al_is_acodec_addon_initialized>(_allegroLibrary, nameof(al_is_acodec_addon_initialized));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate uint al_get_allegro_acodec_version();

    public static al_get_allegro_acodec_version AlGetAllegroAcodecVersion =
        NativeInterop.LoadFunction<al_get_allegro_acodec_version>(_allegroLibrary, nameof(al_get_allegro_acodec_version));

    #endregion

    #region Audio routines

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_install_audio();

    public static al_install_audio AlInstallAudio =
        NativeInterop.LoadFunction<al_install_audio>(_allegroLibrary, nameof(al_install_audio));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_uninstall_audio();

    public static al_uninstall_audio AlUninstallAudio =
        NativeInterop.LoadFunction<al_uninstall_audio>(_allegroLibrary, nameof(al_uninstall_audio));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_is_audio_installed();

    public static al_is_audio_installed AlIsAudioInstalled =
        NativeInterop.LoadFunction<al_is_audio_installed>(_allegroLibrary, nameof(al_is_audio_installed));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_reserve_samples(int reserve_samples);

    public static al_reserve_samples AlReserveSamples =
        NativeInterop.LoadFunction<al_reserve_samples>(_allegroLibrary, nameof(al_reserve_samples));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate uint al_get_allegro_audio_version();

    public static al_get_allegro_audio_version AlGetAllegroAudioVersion =
        NativeInterop.LoadFunction<al_get_allegro_audio_version>(_allegroLibrary, nameof(al_get_allegro_audio_version));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate long al_get_audio_depth_size(int depth);

    public static al_get_audio_depth_size AlGetAudioDepthSize =
        NativeInterop.LoadFunction<al_get_audio_depth_size>(_allegroLibrary, nameof(al_get_audio_depth_size));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate long al_get_channel_count(int conf);

    public static al_get_channel_count AlGetChannelCount =
        NativeInterop.LoadFunction<al_get_channel_count>(_allegroLibrary, nameof(al_get_channel_count));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_fill_silence(IntPtr buf, uint samples, int depth, int chan_conf);

    public static al_fill_silence AlFillSilence =
        NativeInterop.LoadFunction<al_fill_silence>(_allegroLibrary, nameof(al_fill_silence));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_create_voice(uint freq, int depth, int chan_conf);

    public static al_create_voice AlCreateVoice =
        NativeInterop.LoadFunction<al_create_voice>(_allegroLibrary, nameof(al_create_voice));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_destroy_voice(IntPtr voice);

    public static al_destroy_voice AlDestroyVoice =
        NativeInterop.LoadFunction<al_destroy_voice>(_allegroLibrary, nameof(al_destroy_voice));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_detach_voice(IntPtr voice);

    public static al_detach_voice AlDetachVoice =
        NativeInterop.LoadFunction<al_detach_voice>(_allegroLibrary, nameof(al_detach_voice));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_attach_audio_stream_to_voice(IntPtr stream, IntPtr voice);

    public static al_attach_audio_stream_to_voice AlAttachAudioStreamToVoice =
        NativeInterop.LoadFunction<al_attach_audio_stream_to_voice>(_allegroLibrary, nameof(al_attach_audio_stream_to_voice));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_attach_mixer_to_voice(IntPtr mixer, IntPtr voice);

    public static al_attach_mixer_to_voice AlAttachMixerToVoice =
        NativeInterop.LoadFunction<al_attach_mixer_to_voice>(_allegroLibrary, nameof(al_attach_mixer_to_voice));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_attach_sample_instance_to_voice(IntPtr spl, IntPtr voice);

    public static al_attach_sample_instance_to_voice AlAttachSampleInstanceToVoice =
        NativeInterop.LoadFunction<al_attach_sample_instance_to_voice>(_allegroLibrary, nameof(al_attach_sample_instance_to_voice));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate uint al_get_voice_frequency(IntPtr voice);

    public static al_get_voice_frequency AlGetVoiceFrequency =
        NativeInterop.LoadFunction<al_get_voice_frequency>(_allegroLibrary, nameof(al_get_voice_frequency));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_voice_channels(IntPtr voice);

    public static al_get_voice_channels AlGetVoiceChannels =
        NativeInterop.LoadFunction<al_get_voice_channels>(_allegroLibrary, nameof(al_get_voice_channels));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_voice_depth(IntPtr voice);

    public static al_get_voice_depth AlGetVoiceDepth =
        NativeInterop.LoadFunction<al_get_voice_depth>(_allegroLibrary, nameof(al_get_voice_depth));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_get_voice_playing(IntPtr voice);

    public static al_get_voice_playing AlGetVoicePlaying =
        NativeInterop.LoadFunction<al_get_voice_playing>(_allegroLibrary, nameof(al_get_voice_playing));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_set_voice_playing(IntPtr voice, bool val);

    public static al_set_voice_playing AlSetVoicePlaying =
        NativeInterop.LoadFunction<al_set_voice_playing>(_allegroLibrary, nameof(al_set_voice_playing));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate uint al_get_voice_position(IntPtr voice);

    public static al_get_voice_position AlGetVoicePosition =
        NativeInterop.LoadFunction<al_get_voice_position>(_allegroLibrary, nameof(al_get_voice_position));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_set_voice_position(IntPtr voice, uint val);

    public static al_set_voice_position AlSetVoicePosition =
        NativeInterop.LoadFunction<al_set_voice_position>(_allegroLibrary, nameof(al_set_voice_position));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_create_sample(IntPtr buf, uint samples, uint freq, int depth, int chan_conf, bool free_buf);

    public static al_create_sample AlCreateSample =
        NativeInterop.LoadFunction<al_create_sample>(_allegroLibrary, nameof(al_create_sample));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_destroy_sample(IntPtr spl);

    public static al_destroy_sample AlDestroySample =
        NativeInterop.LoadFunction<al_destroy_sample>(_allegroLibrary, nameof(al_destroy_sample));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_play_sample(IntPtr spl, float gain, float pan, float speed, int loop, IntPtr ret_id);

    public static al_play_sample AlPlaySample =
        NativeInterop.LoadFunction<al_play_sample>(_allegroLibrary, nameof(al_play_sample));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_stop_sample(IntPtr spl_id);

    public static al_stop_sample AlStopSample =
        NativeInterop.LoadFunction<al_stop_sample>(_allegroLibrary, nameof(al_stop_sample));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_stop_samples();

    public static al_stop_samples AlStopSamples =
        NativeInterop.LoadFunction<al_stop_samples>(_allegroLibrary, nameof(al_stop_samples));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_sample_channels(IntPtr spl);

    public static al_get_sample_channels AlGetSampleChannels =
        NativeInterop.LoadFunction<al_get_sample_channels>(_allegroLibrary, nameof(al_get_sample_channels));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_sample_depth(IntPtr spl);

    public static al_get_sample_depth AlGetSampleDepth =
        NativeInterop.LoadFunction<al_get_sample_depth>(_allegroLibrary, nameof(al_get_sample_depth));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate uint al_get_sample_frequency(IntPtr spl);

    public static al_get_sample_frequency AlGetSampleFrequency =
        NativeInterop.LoadFunction<al_get_sample_frequency>(_allegroLibrary, nameof(al_get_sample_frequency));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate uint al_get_sample_length(IntPtr spl);

    public static al_get_sample_length AlGetSampleLength =
        NativeInterop.LoadFunction<al_get_sample_length>(_allegroLibrary, nameof(al_get_sample_length));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_sample_data(IntPtr spl);

    public static al_get_sample_data AlGetSampleData =
        NativeInterop.LoadFunction<al_get_sample_data>(_allegroLibrary, nameof(al_get_sample_data));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_create_sample_instance(IntPtr sample_data);

    public static al_create_sample_instance AlCreateSampleInstance =
        NativeInterop.LoadFunction<al_create_sample_instance>(_allegroLibrary, nameof(al_create_sample_instance));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_destroy_sample_instance(IntPtr spl);

    public static al_destroy_sample_instance AlDestroySampleInstance =
        NativeInterop.LoadFunction<al_destroy_sample_instance>(_allegroLibrary, nameof(al_destroy_sample_instance));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_play_sample_instance(IntPtr spl);

    public static al_play_sample_instance AlPlaySampleInstance =
        NativeInterop.LoadFunction<al_play_sample_instance>(_allegroLibrary, nameof(al_play_sample_instance));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_stop_sample_instance(IntPtr spl);

    public static al_stop_sample_instance AlStopSampleInstance =
        NativeInterop.LoadFunction<al_stop_sample_instance>(_allegroLibrary, nameof(al_stop_sample_instance));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_sample_instance_channels(IntPtr spl);

    public static al_get_sample_instance_channels AlGetSampleInstanceChannels =
        NativeInterop.LoadFunction<al_get_sample_instance_channels>(_allegroLibrary, nameof(al_get_sample_instance_channels));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_sample_instance_depth(IntPtr spl);

    public static al_get_sample_instance_depth AlGetSampleInstanceDepth =
        NativeInterop.LoadFunction<al_get_sample_instance_depth>(_allegroLibrary, nameof(al_get_sample_instance_depth));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate uint al_get_sample_instance_frequency(IntPtr spl);

    public static al_get_sample_instance_frequency AlGetSampleInstanceFrequency =
        NativeInterop.LoadFunction<al_get_sample_instance_frequency>(_allegroLibrary, nameof(al_get_sample_instance_frequency));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate uint al_get_sample_instance_length(IntPtr spl);

    public static al_get_sample_instance_length AlGetSampleInstanceLength =
        NativeInterop.LoadFunction<al_get_sample_instance_length>(_allegroLibrary, nameof(al_get_sample_instance_length));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_set_sample_instance_length(IntPtr spl, uint val);

    public static al_set_sample_instance_length AlSetSampleInstanceLength =
        NativeInterop.LoadFunction<al_set_sample_instance_length>(_allegroLibrary, nameof(al_set_sample_instance_length));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate uint al_get_sample_instance_position(IntPtr spl);

    public static al_get_sample_instance_position AlGetSampleInstancePosition =
        NativeInterop.LoadFunction<al_get_sample_instance_position>(_allegroLibrary, nameof(al_get_sample_instance_position));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_set_sample_instance_position(IntPtr spl, uint val);

    public static al_set_sample_instance_position AlSetSampleInstancePosition =
        NativeInterop.LoadFunction<al_set_sample_instance_position>(_allegroLibrary, nameof(al_set_sample_instance_position));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate float al_get_sample_instance_speed(IntPtr spl);

    public static al_get_sample_instance_speed AlGetSampleInstanceSpeed =
        NativeInterop.LoadFunction<al_get_sample_instance_speed>(_allegroLibrary, nameof(al_get_sample_instance_speed));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_set_sample_instance_speed(IntPtr spl, float val);

    public static al_set_sample_instance_speed AlSetSampleInstanceSpeed =
        NativeInterop.LoadFunction<al_set_sample_instance_speed>(_allegroLibrary, nameof(al_set_sample_instance_speed));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate float al_get_sample_instance_gain(IntPtr spl);

    public static al_get_sample_instance_gain AlGetSampleInstanceGain =
        NativeInterop.LoadFunction<al_get_sample_instance_gain>(_allegroLibrary, nameof(al_get_sample_instance_gain));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_set_sample_instance_gain(IntPtr spl, float val);

    public static al_set_sample_instance_gain AlSetSampleInstanceGain =
        NativeInterop.LoadFunction<al_set_sample_instance_gain>(_allegroLibrary, nameof(al_set_sample_instance_gain));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate float al_get_sample_instance_pan(IntPtr spl);

    public static al_get_sample_instance_pan AlGetSampleInstancePan =
        NativeInterop.LoadFunction<al_get_sample_instance_pan>(_allegroLibrary, nameof(al_get_sample_instance_pan));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_set_sample_instance_pan(IntPtr spl, float val);

    public static al_set_sample_instance_pan AlSetSampleInstancePan =
        NativeInterop.LoadFunction<al_set_sample_instance_pan>(_allegroLibrary, nameof(al_set_sample_instance_pan));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate float al_get_sample_instance_time(IntPtr spl);

    public static al_get_sample_instance_time AlGetSampleInstanceTime =
        NativeInterop.LoadFunction<al_get_sample_instance_time>(_allegroLibrary, nameof(al_get_sample_instance_time));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_sample_instance_playmode(IntPtr spl);

    public static al_get_sample_instance_playmode AlGetSampleInstancePlaymode =
        NativeInterop.LoadFunction<al_get_sample_instance_playmode>(_allegroLibrary, nameof(al_get_sample_instance_playmode));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_set_sample_instance_playmode(IntPtr spl, int val);

    public static al_set_sample_instance_playmode AlSetSampleInstancePlaymode =
        NativeInterop.LoadFunction<al_set_sample_instance_playmode>(_allegroLibrary, nameof(al_set_sample_instance_playmode));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_get_sample_instance_playing(IntPtr spl);

    public static al_get_sample_instance_playing AlGetSampleInstancePlaying =
        NativeInterop.LoadFunction<al_get_sample_instance_playing>(_allegroLibrary, nameof(al_get_sample_instance_playing));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_set_sample_instance_playing(IntPtr spl, bool val);

    public static al_set_sample_instance_playing AlSetSampleInstancePlaying =
        NativeInterop.LoadFunction<al_set_sample_instance_playing>(_allegroLibrary, nameof(al_set_sample_instance_playing));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_get_sample_instance_attached(IntPtr spl);

    public static al_get_sample_instance_attached AlGetSampleInstanceAttached =
        NativeInterop.LoadFunction<al_get_sample_instance_attached>(_allegroLibrary, nameof(al_get_sample_instance_attached));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_detach_sample_instance(IntPtr spl);

    public static al_detach_sample_instance AlDetachSampleInstance =
        NativeInterop.LoadFunction<al_detach_sample_instance>(_allegroLibrary, nameof(al_detach_sample_instance));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_sample(IntPtr spl);

    public static al_get_sample AlGetSample =
        NativeInterop.LoadFunction<al_get_sample>(_allegroLibrary, nameof(al_get_sample));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_set_sample(IntPtr spl, IntPtr data);

    public static al_set_sample AlSetSample =
        NativeInterop.LoadFunction<al_set_sample>(_allegroLibrary, nameof(al_set_sample));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_create_mixer(uint freq, int depth, int chan_conf);

    public static al_create_mixer AlCreateMixer =
        NativeInterop.LoadFunction<al_create_mixer>(_allegroLibrary, nameof(al_create_mixer));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_destroy_mixer(IntPtr mixer);

    public static al_destroy_mixer AlDestroyMixer =
        NativeInterop.LoadFunction<al_destroy_mixer>(_allegroLibrary, nameof(al_destroy_mixer));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_default_mixer();

    public static al_get_default_mixer AlGetDefaultMixer =
        NativeInterop.LoadFunction<al_get_default_mixer>(_allegroLibrary, nameof(al_get_default_mixer));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_set_default_mixer(IntPtr mixer);

    public static al_set_default_mixer AlSetDefaultMixer =
        NativeInterop.LoadFunction<al_set_default_mixer>(_allegroLibrary, nameof(al_set_default_mixer));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_restore_default_mixer();

    public static al_restore_default_mixer AlRestoreDefaultMixer =
        NativeInterop.LoadFunction<al_restore_default_mixer>(_allegroLibrary, nameof(al_restore_default_mixer));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_default_voice();

    public static al_get_default_voice AlGetDefaultVoice =
        NativeInterop.LoadFunction<al_get_default_voice>(_allegroLibrary, nameof(al_get_default_voice));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_set_default_voice(IntPtr voice);

    public static al_set_default_voice AlSetDefaultVoice =
        NativeInterop.LoadFunction<al_set_default_voice>(_allegroLibrary, nameof(al_set_default_voice));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_attach_mixer_to_mixer(IntPtr stream, IntPtr mixer);

    public static al_attach_mixer_to_mixer AlAttachMixerToMixer =
        NativeInterop.LoadFunction<al_attach_mixer_to_mixer>(_allegroLibrary, nameof(al_attach_mixer_to_mixer));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_attach_sample_instance_to_mixer(IntPtr spl, IntPtr mixer);

    public static al_attach_sample_instance_to_mixer AlAttachSampleInstanceToMixer =
        NativeInterop.LoadFunction<al_attach_sample_instance_to_mixer>(_allegroLibrary, nameof(al_attach_sample_instance_to_mixer));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_attach_audio_stream_to_mixer(IntPtr stream, IntPtr mixer);

    public static al_attach_audio_stream_to_mixer AlAttachAudioStreamToMixer =
        NativeInterop.LoadFunction<al_attach_audio_stream_to_mixer>(_allegroLibrary, nameof(al_attach_audio_stream_to_mixer));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate uint al_get_mixer_frequency(IntPtr mixer);

    public static al_get_mixer_frequency AlGetMixerFrequency =
        NativeInterop.LoadFunction<al_get_mixer_frequency>(_allegroLibrary, nameof(al_get_mixer_frequency));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_set_mixer_frequency(IntPtr mixer, uint val);

    public static al_set_mixer_frequency AlSetMixerFrequency =
        NativeInterop.LoadFunction<al_set_mixer_frequency>(_allegroLibrary, nameof(al_set_mixer_frequency));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_mixer_channels(IntPtr mixer);

    public static al_get_mixer_channels AlGetMixerChannels =
        NativeInterop.LoadFunction<al_get_mixer_channels>(_allegroLibrary, nameof(al_get_mixer_channels));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_mixer_depth(IntPtr mixer);

    public static al_get_mixer_depth AlGetMixerDepth =
        NativeInterop.LoadFunction<al_get_mixer_depth>(_allegroLibrary, nameof(al_get_mixer_depth));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate float al_get_mixer_gain(IntPtr mixer);

    public static al_get_mixer_gain AlGetMixerGain =
        NativeInterop.LoadFunction<al_get_mixer_gain>(_allegroLibrary, nameof(al_get_mixer_gain));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_set_mixer_gain(IntPtr mixer, float new_gain);

    public static al_set_mixer_gain AlSetMixerGain =
        NativeInterop.LoadFunction<al_set_mixer_gain>(_allegroLibrary, nameof(al_set_mixer_gain));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_mixer_quality(IntPtr mixer);

    public static al_get_mixer_quality AlGetMixerQuality =
        NativeInterop.LoadFunction<al_get_mixer_quality>(_allegroLibrary, nameof(al_get_mixer_quality));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_set_mixer_quality(IntPtr mixer, int new_quality);

    public static al_set_mixer_quality AlSetMixerQuality =
        NativeInterop.LoadFunction<al_set_mixer_quality>(_allegroLibrary, nameof(al_set_mixer_quality));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_get_mixer_playing(IntPtr mixer);

    public static al_get_mixer_playing AlGetMixerPlaying =
        NativeInterop.LoadFunction<al_get_mixer_playing>(_allegroLibrary, nameof(al_get_mixer_playing));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_set_mixer_playing(IntPtr mixer, bool val);

    public static al_set_mixer_playing AlSetMixerPlaying =
        NativeInterop.LoadFunction<al_set_mixer_playing>(_allegroLibrary, nameof(al_set_mixer_playing));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_get_mixer_attached(IntPtr mixer);

    public static al_get_mixer_attached AlGetMixerAttached =
        NativeInterop.LoadFunction<al_get_mixer_attached>(_allegroLibrary, nameof(al_get_mixer_attached));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_detach_mixer(IntPtr mixer);

    public static al_detach_mixer AlDetachMixer =
        NativeInterop.LoadFunction<al_detach_mixer>(_allegroLibrary, nameof(al_detach_mixer));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_set_mixer_postprocess_callback(IntPtr mixer, MixerPostprocessCallback pp_callback, IntPtr pp_callback_userdata);

    public static al_set_mixer_postprocess_callback AlSetMixerPostprocessCallback =
        NativeInterop.LoadFunction<al_set_mixer_postprocess_callback>(_allegroLibrary, nameof(al_set_mixer_postprocess_callback));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_create_audio_stream(long fragment_count, uint frag_samples, uint freq, int depth, int chan_conf);

    public static al_create_audio_stream AlCreateAudioStream =
        NativeInterop.LoadFunction<al_create_audio_stream>(_allegroLibrary, nameof(al_create_audio_stream));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_destroy_audio_stream(IntPtr stream);

    public static al_destroy_audio_stream AlDestroyAudioStream =
        NativeInterop.LoadFunction<al_destroy_audio_stream>(_allegroLibrary, nameof(al_destroy_audio_stream));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_audio_stream_event_source(IntPtr stream);

    public static al_get_audio_stream_event_source AlGetAudioStreamEventSource =
        NativeInterop.LoadFunction<al_get_audio_stream_event_source>(_allegroLibrary, nameof(al_get_audio_stream_event_source));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_drain_audio_stream(IntPtr stream);

    public static al_drain_audio_stream AlDrainAudioStream =
        NativeInterop.LoadFunction<al_drain_audio_stream>(_allegroLibrary, nameof(al_drain_audio_stream));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_rewind_audio_stream(IntPtr stream);

    public static al_rewind_audio_stream AlRewindAudioStream =
        NativeInterop.LoadFunction<al_rewind_audio_stream>(_allegroLibrary, nameof(al_rewind_audio_stream));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate uint al_get_audio_stream_frequency(IntPtr stream);

    public static al_get_audio_stream_frequency AlGetAudioStreamFrequency =
        NativeInterop.LoadFunction<al_get_audio_stream_frequency>(_allegroLibrary, nameof(al_get_audio_stream_frequency));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_audio_stream_channels(IntPtr stream);

    public static al_get_audio_stream_channels AlGetAudioStreamChannels =
        NativeInterop.LoadFunction<al_get_audio_stream_channels>(_allegroLibrary, nameof(al_get_audio_stream_channels));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_audio_stream_depth(IntPtr stream);

    public static al_get_audio_stream_depth AlGetAudioStreamDepth =
        NativeInterop.LoadFunction<al_get_audio_stream_depth>(_allegroLibrary, nameof(al_get_audio_stream_depth));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate uint al_get_audio_stream_length(IntPtr stream);

    public static al_get_audio_stream_length AlGetAudioStreamLength =
        NativeInterop.LoadFunction<al_get_audio_stream_length>(_allegroLibrary, nameof(al_get_audio_stream_length));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate float al_get_audio_stream_speed(IntPtr stream);

    public static al_get_audio_stream_speed AlGetAudioStreamSpeed =
        NativeInterop.LoadFunction<al_get_audio_stream_speed>(_allegroLibrary, nameof(al_get_audio_stream_speed));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_set_audio_stream_speed(IntPtr stream, float val);

    public static al_set_audio_stream_speed AlSetAudioStreamSpeed =
        NativeInterop.LoadFunction<al_set_audio_stream_speed>(_allegroLibrary, nameof(al_set_audio_stream_speed));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate float al_get_audio_stream_gain(IntPtr stream);

    public static al_get_audio_stream_gain AlGetAudioStreamGain =
        NativeInterop.LoadFunction<al_get_audio_stream_gain>(_allegroLibrary, nameof(al_get_audio_stream_gain));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_set_audio_stream_gain(IntPtr stream, float val);

    public static al_set_audio_stream_gain AlSetAudioStreamGain =
        NativeInterop.LoadFunction<al_set_audio_stream_gain>(_allegroLibrary, nameof(al_set_audio_stream_gain));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate float al_get_audio_stream_pan(IntPtr stream);

    public static al_get_audio_stream_pan AlGetAudioStreamPan =
        NativeInterop.LoadFunction<al_get_audio_stream_pan>(_allegroLibrary, nameof(al_get_audio_stream_pan));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_set_audio_stream_pan(IntPtr stream, float val);

    public static al_set_audio_stream_pan AlSetAudioStreamPan =
        NativeInterop.LoadFunction<al_set_audio_stream_pan>(_allegroLibrary, nameof(al_set_audio_stream_pan));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_get_audio_stream_playing(IntPtr stream);

    public static al_get_audio_stream_playing AlGetAudioStreamPlaying =
        NativeInterop.LoadFunction<al_get_audio_stream_playing>(_allegroLibrary, nameof(al_get_audio_stream_playing));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_set_audio_stream_playing(IntPtr stream, bool val);

    public static al_set_audio_stream_playing AlSetAudioStreamPlaying =
        NativeInterop.LoadFunction<al_set_audio_stream_playing>(_allegroLibrary, nameof(al_set_audio_stream_playing));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_audio_stream_playmode(IntPtr stream);

    public static al_get_audio_stream_playmode AlGetAudioStreamPlaymode =
        NativeInterop.LoadFunction<al_get_audio_stream_playmode>(_allegroLibrary, nameof(al_get_audio_stream_playmode));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_set_audio_stream_playmode(IntPtr stream, int val);

    public static al_set_audio_stream_playmode AlSetAudioStreamPlaymode =
        NativeInterop.LoadFunction<al_set_audio_stream_playmode>(_allegroLibrary, nameof(al_set_audio_stream_playmode));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_get_audio_stream_attached(IntPtr stream);

    public static al_get_audio_stream_attached AlGetAudioStreamAttached =
        NativeInterop.LoadFunction<al_get_audio_stream_attached>(_allegroLibrary, nameof(al_get_audio_stream_attached));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_detach_audio_stream(IntPtr stream);

    public static al_detach_audio_stream AlDetachAudioStream =
        NativeInterop.LoadFunction<al_detach_audio_stream>(_allegroLibrary, nameof(al_detach_audio_stream));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate ulong al_get_audio_stream_played_samples(IntPtr stream);

    public static al_get_audio_stream_played_samples AlGetAudioStreamPlayedSamples =
        NativeInterop.LoadFunction<al_get_audio_stream_played_samples>(_allegroLibrary, nameof(al_get_audio_stream_played_samples));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_audio_stream_fragment(IntPtr stream);

    public static al_get_audio_stream_fragment AlGetAudioStreamFragment =
        NativeInterop.LoadFunction<al_get_audio_stream_fragment>(_allegroLibrary, nameof(al_get_audio_stream_fragment));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_set_audio_stream_fragment(IntPtr stream, IntPtr val);

    public static al_set_audio_stream_fragment AlSetAudioStreamFragment =
        NativeInterop.LoadFunction<al_set_audio_stream_fragment>(_allegroLibrary, nameof(al_set_audio_stream_fragment));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate uint al_get_audio_stream_fragments(IntPtr stream);

    public static al_get_audio_stream_fragments AlGetAudioStreamFragments =
        NativeInterop.LoadFunction<al_get_audio_stream_fragments>(_allegroLibrary, nameof(al_get_audio_stream_fragments));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate uint al_get_available_audio_stream_fragments(IntPtr stream);

    public static al_get_available_audio_stream_fragments AlGetAvailableAudioStreamFragments =
        NativeInterop.LoadFunction<al_get_available_audio_stream_fragments>(_allegroLibrary, nameof(al_get_available_audio_stream_fragments));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_seek_audio_stream_secs(IntPtr stream, double time);

    public static al_seek_audio_stream_secs AlSeekAudioStreamSecs =
        NativeInterop.LoadFunction<al_seek_audio_stream_secs>(_allegroLibrary, nameof(al_seek_audio_stream_secs));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate double al_get_audio_stream_position_secs(IntPtr stream);

    public static al_get_audio_stream_position_secs AlGetAudioStreamPositionSecs =
        NativeInterop.LoadFunction<al_get_audio_stream_position_secs>(_allegroLibrary, nameof(al_get_audio_stream_position_secs));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate double al_get_audio_stream_length_secs(IntPtr stream);

    public static al_get_audio_stream_length_secs AlGetAudioStreamLengthSecs =
        NativeInterop.LoadFunction<al_get_audio_stream_length_secs>(_allegroLibrary, nameof(al_get_audio_stream_length_secs));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_set_audio_stream_loop_secs(IntPtr stream, double start, double end);

    public static al_set_audio_stream_loop_secs AlSetAudioStreamLoopSecs =
        NativeInterop.LoadFunction<al_set_audio_stream_loop_secs>(_allegroLibrary, nameof(al_set_audio_stream_loop_secs));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_register_sample_loader(IntPtr ext, RegisterSampleLoader loader);

    public static al_register_sample_loader AlRegisterSampleLoader =
        NativeInterop.LoadFunction<al_register_sample_loader>(_allegroLibrary, nameof(al_register_sample_loader));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_register_sample_loader_f(IntPtr ext, RegisterSampleLoaderF loader);

    public static al_register_sample_loader_f AlRegisterSampleLoaderF =
        NativeInterop.LoadFunction<al_register_sample_loader_f>(_allegroLibrary, nameof(al_register_sample_loader_f));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_register_sample_saver(IntPtr ext, RegisterSampleSaver saver);

    public static al_register_sample_saver AlRegisterSampleSaver =
        NativeInterop.LoadFunction<al_register_sample_saver>(_allegroLibrary, nameof(al_register_sample_saver));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_register_sample_saver_f(IntPtr ext, RegisterSampleSaverF saver);

    public static al_register_sample_saver_f AlRegisterSampleSaverF =
        NativeInterop.LoadFunction<al_register_sample_saver_f>(_allegroLibrary, nameof(al_register_sample_saver_f));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_register_audio_stream_loader(IntPtr ext, RegisterAudioStreamLoader stream_loader);

    public static al_register_audio_stream_loader AlRegisterAudioStreamLoader =
        NativeInterop.LoadFunction<al_register_audio_stream_loader>(_allegroLibrary, nameof(al_register_audio_stream_loader));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_register_audio_stream_loader_f(IntPtr ext, RegisterAudioStreamLoaderF stream_loader);

    public static al_register_audio_stream_loader_f AlRegisterAudioStreamLoaderF =
        NativeInterop.LoadFunction<al_register_audio_stream_loader_f>(_allegroLibrary, nameof(al_register_audio_stream_loader_f));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_load_sample(IntPtr filename);

    public static al_load_sample AlLoadSample =
        NativeInterop.LoadFunction<al_load_sample>(_allegroLibrary, nameof(al_load_sample));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_load_sample_f(IntPtr fp, IntPtr ident);

    public static al_load_sample_f AlLoadSampleF =
        NativeInterop.LoadFunction<al_load_sample_f>(_allegroLibrary, nameof(al_load_sample_f));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_load_audio_stream(IntPtr filename, long buffer_count, uint samples);

    public static al_load_audio_stream AlLoadAudioStream =
        NativeInterop.LoadFunction<al_load_audio_stream>(_allegroLibrary, nameof(al_load_audio_stream));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_load_audio_stream_f(IntPtr fp, IntPtr ident, long buffer_count, uint samples);

    public static al_load_audio_stream_f AlLoadAudioStreamF =
        NativeInterop.LoadFunction<al_load_audio_stream_f>(_allegroLibrary, nameof(al_load_audio_stream_f));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_save_sample(IntPtr filename, IntPtr spl);

    public static al_save_sample AlSaveSample =
        NativeInterop.LoadFunction<al_save_sample>(_allegroLibrary, nameof(al_save_sample));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_save_sample_f(IntPtr fp, IntPtr ident, IntPtr spl);

    public static al_save_sample_f AlSaveSampleF =
        NativeInterop.LoadFunction<al_save_sample_f>(_allegroLibrary, nameof(al_save_sample_f));

    // 5.2.8 only
    //[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    //[return: MarshalAs(UnmanagedType.U1)]
    //public delegate bool al_register_sample_identifier(IntPtr ext, RegisterSampleIdentifier identifier);

    //public static al_register_sample_identifier AlRegisterSampleIdentifier =
    //    NativeInterop.LoadFunction<al_register_sample_identifier>(_allegroLibrary, nameof(al_register_sample_identifier));

    // 5.2.8 only
    //[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    //public delegate IntPtr al_identify_sample(IntPtr filename);

    //public static al_identify_sample AlIdentifySample =
    //    NativeInterop.LoadFunction<al_identify_sample>(_allegroLibrary, nameof(al_identify_sample));

    // 5.2.8 only
    //[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    //public delegate IntPtr al_identify_sample_f(IntPtr filename);

    //public static al_identify_sample_f AlIdentifySampleF =
    //    NativeInterop.LoadFunction<al_identify_sample_f>(_allegroLibrary, nameof(al_identify_sample_f));

    // 5.2.8 only
    //[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    //public delegate int al_get_num_audio_output_devices();

    //public static al_get_num_audio_output_devices AlGetNumAudioOutputDevices =
    //    NativeInterop.LoadFunction<al_get_num_audio_output_devices>(_allegroLibrary, nameof(al_get_num_audio_output_devices));

    // 5.2.8 only
    //[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    //public delegate IntPtr al_get_audio_output_device(int index);

    //public static al_get_audio_output_device AlGetAudioOutputDevice =
    //    NativeInterop.LoadFunction<al_get_audio_output_device>(_allegroLibrary, nameof(al_get_audio_output_device));

    // 5.2.8 only
    //[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    //public delegate IntPtr al_get_audio_device_name(IntPtr device);

    //public static al_get_audio_device_name AlGetAudioDeviceName =
    //    NativeInterop.LoadFunction<al_get_audio_device_name>(_allegroLibrary, nameof(al_get_audio_device_name));

    #endregion

    #region Configuration routines

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_create_config();

    public static al_create_config AlCreateConfig =
        NativeInterop.LoadFunction<al_create_config>(_allegroLibrary, nameof(al_create_config));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_destroy_config(IntPtr config);

    public static al_destroy_config AlDestroyConfig =
        NativeInterop.LoadFunction<al_destroy_config>(_allegroLibrary, nameof(al_destroy_config));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_load_config_file(IntPtr filename);

    public static al_load_config_file AlLoadConfigFile =
        NativeInterop.LoadFunction<al_load_config_file>(_allegroLibrary, nameof(al_load_config_file));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_load_config_file_f(IntPtr file);

    public static al_load_config_file_f AlLoadConfigFileF =
        NativeInterop.LoadFunction<al_load_config_file_f>(_allegroLibrary, nameof(al_load_config_file_f));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_save_config_file(IntPtr filename, IntPtr config);

    public static al_save_config_file AlSaveConfigFile =
        NativeInterop.LoadFunction<al_save_config_file>(_allegroLibrary, nameof(al_save_config_file));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_save_config_file_f(IntPtr file, IntPtr config);

    public static al_save_config_file_f AlSaveConfigFileF =
        NativeInterop.LoadFunction<al_save_config_file_f>(_allegroLibrary, nameof(al_save_config_file_f));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_add_config_section(IntPtr config, IntPtr name);

    public static al_add_config_section AlAddConfigSection =
        NativeInterop.LoadFunction<al_add_config_section>(_allegroLibrary, nameof(al_add_config_section));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_remove_config_section(IntPtr config, IntPtr section);

    public static al_remove_config_section AlRemoveConfigSection =
        NativeInterop.LoadFunction<al_remove_config_section>(_allegroLibrary, nameof(al_remove_config_section));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_add_config_comment(IntPtr config, IntPtr section, IntPtr comment);

    public static al_add_config_comment AlAddConfigComment =
        NativeInterop.LoadFunction<al_add_config_comment>(_allegroLibrary, nameof(al_add_config_comment));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_config_value(IntPtr config, IntPtr section, IntPtr key);

    public static al_get_config_value AlGetConfigValue =
        NativeInterop.LoadFunction<al_get_config_value>(_allegroLibrary, nameof(al_get_config_value));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_set_config_value(IntPtr config, IntPtr section, IntPtr key, IntPtr value);

    public static al_set_config_value AlSetConfigValue =
        NativeInterop.LoadFunction<al_set_config_value>(_allegroLibrary, nameof(al_set_config_value));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_remove_config_key(IntPtr config, IntPtr section, IntPtr key);

    public static al_remove_config_key AlRemoveConfigKey =
        NativeInterop.LoadFunction<al_remove_config_key>(_allegroLibrary, nameof(al_remove_config_key));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_first_config_section(IntPtr config, ref IntPtr iterator);

    public static al_get_first_config_section AlGetFirstConfigSection =
        NativeInterop.LoadFunction<al_get_first_config_section>(_allegroLibrary, nameof(al_get_first_config_section));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_next_config_section(ref IntPtr iterator);

    public static al_get_next_config_section AlGetNextConfigSection =
        NativeInterop.LoadFunction<al_get_next_config_section>(_allegroLibrary, nameof(al_get_next_config_section));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_first_config_entry(IntPtr config, IntPtr section, ref IntPtr iterator);

    public static al_get_first_config_entry AlGetFirstConfigEntry =
        NativeInterop.LoadFunction<al_get_first_config_entry>(_allegroLibrary, nameof(al_get_first_config_entry));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_next_config_entry(ref IntPtr iterator);

    public static al_get_next_config_entry AlGetNextConfigEntry =
        NativeInterop.LoadFunction<al_get_next_config_entry>(_allegroLibrary, nameof(al_get_next_config_entry));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_merge_config(IntPtr cfg1, IntPtr cfg2);

    public static al_merge_config AlMergeConfig =
        NativeInterop.LoadFunction<al_merge_config>(_allegroLibrary, nameof(al_merge_config));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_merge_config_into(IntPtr master, IntPtr add);

    public static al_merge_config_into AlMergeConfigInto =
        NativeInterop.LoadFunction<al_merge_config_into>(_allegroLibrary, nameof(al_merge_config_into));

    #endregion Configuration routines

    #region Display routines

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_create_display(int w, int h);

    public static al_create_display AlCreateDisplay =
        NativeInterop.LoadFunction<al_create_display>(_allegroLibrary, nameof(al_create_display));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_destroy_display(IntPtr display);

    public static al_destroy_display AlDestroyDisplay =
        NativeInterop.LoadFunction<al_destroy_display>(_allegroLibrary, nameof(al_destroy_display));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_new_display_flags();

    public static al_get_new_display_flags AlGetNewDisplayFlags =
        NativeInterop.LoadFunction<al_get_new_display_flags>(_allegroLibrary, nameof(al_get_new_display_flags));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_set_new_display_flags(int flags);

    public static al_set_new_display_flags AlSetNewDisplayFlags =
        NativeInterop.LoadFunction<al_set_new_display_flags>(_allegroLibrary, nameof(al_set_new_display_flags));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_new_display_option(int option, ref int importance);

    public static al_get_new_display_option AlGetNewDisplayOption =
        NativeInterop.LoadFunction<al_get_new_display_option>(_allegroLibrary, nameof(al_get_new_display_option));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_set_new_display_option(int option, int value, int importance);

    public static al_set_new_display_option AlSetNewDisplayOption =
        NativeInterop.LoadFunction<al_set_new_display_option>(_allegroLibrary, nameof(al_set_new_display_option));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_reset_new_display_options();

    public static al_reset_new_display_options AlResetNewDisplayOptions =
        NativeInterop.LoadFunction<al_reset_new_display_options>(_allegroLibrary, nameof(al_reset_new_display_options));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_get_new_window_position(ref int x, ref int y);

    public static al_get_new_window_position AlGetNewWindowPosition =
        NativeInterop.LoadFunction<al_get_new_window_position>(_allegroLibrary, nameof(al_get_new_window_position));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_set_new_window_position(int x, int y);

    public static al_set_new_window_position AlSetNewWindowPosition =
        NativeInterop.LoadFunction<al_set_new_window_position>(_allegroLibrary, nameof(al_set_new_window_position));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_new_display_refresh_rate();

    public static al_get_new_display_refresh_rate AlGetNewDisplayRefreshRate =
        NativeInterop.LoadFunction<al_get_new_display_refresh_rate>(_allegroLibrary, nameof(al_get_new_display_refresh_rate));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_set_new_display_refresh_rate(int refresh_rate);

    public static al_set_new_display_refresh_rate AlSetNewDisplayRefreshRate =
        NativeInterop.LoadFunction<al_set_new_display_refresh_rate>(_allegroLibrary, nameof(al_set_new_display_refresh_rate));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_display_event_source(IntPtr display);

    public static al_get_display_event_source AlGetDisplayEventSource =
        NativeInterop.LoadFunction<al_get_display_event_source>(_allegroLibrary, nameof(al_get_display_event_source));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_backbuffer(IntPtr display);

    public static al_get_backbuffer AlGetBackbuffer =
        NativeInterop.LoadFunction<al_get_backbuffer>(_allegroLibrary, nameof(al_get_backbuffer));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_flip_display();

    public static al_flip_display AlFlipDisplay =
        NativeInterop.LoadFunction<al_flip_display>(_allegroLibrary, nameof(al_flip_display));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_update_display_region(int x, int y, int width, int height);

    public static al_update_display_region AlUpdateDisplayRegion =
        NativeInterop.LoadFunction<al_update_display_region>(_allegroLibrary, nameof(al_update_display_region));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_wait_for_vsync();

    public static al_wait_for_vsync AlWaitForVSync =
        NativeInterop.LoadFunction<al_wait_for_vsync>(_allegroLibrary, nameof(al_wait_for_vsync));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_display_width(IntPtr display);

    public static al_get_display_width AlGetDisplayWidth =
        NativeInterop.LoadFunction<al_get_display_width>(_allegroLibrary, nameof(al_get_display_width));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_display_height(IntPtr display);

    public static al_get_display_height AlGetDisplayHeight =
        NativeInterop.LoadFunction<al_get_display_height>(_allegroLibrary, nameof(al_get_display_height));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_resize_display(IntPtr display, int width, int height);

    public static al_resize_display AlResizeDisplay =
        NativeInterop.LoadFunction<al_resize_display>(_allegroLibrary, nameof(al_resize_display));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_acknowledge_resize(IntPtr display);

    public static al_acknowledge_resize AlAcknowledgeResize =
        NativeInterop.LoadFunction<al_acknowledge_resize>(_allegroLibrary, nameof(al_acknowledge_resize));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_get_window_position(IntPtr display, ref int x, ref int y);

    public static al_get_window_position AlGetWindowPosition =
        NativeInterop.LoadFunction<al_get_window_position>(_allegroLibrary, nameof(al_get_window_position));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_set_window_position(IntPtr display, int x, int y);

    public static al_set_window_position AlSetWindowPosition =
        NativeInterop.LoadFunction<al_set_window_position>(_allegroLibrary, nameof(al_set_window_position));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_get_window_constraints(IntPtr display, ref int min_w, ref int min_h, ref int max_w, ref int max_h);

    public static al_get_window_constraints AlGetWindowConstraints =
        NativeInterop.LoadFunction<al_get_window_constraints>(_allegroLibrary, nameof(al_get_window_constraints));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_set_window_constraints(IntPtr display, int min_w, int min_h, int max_w, int max_h);

    public static al_set_window_constraints AlSetWindowConstraints =
        NativeInterop.LoadFunction<al_set_window_constraints>(_allegroLibrary, nameof(al_set_window_constraints));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate bool al_apply_window_constraints(IntPtr display, [MarshalAs(UnmanagedType.U1)] bool onoff);

    public static al_apply_window_constraints AlApplyWindowConstraints =
        NativeInterop.LoadFunction<al_apply_window_constraints>(_allegroLibrary, nameof(al_apply_window_constraints));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_display_flags(IntPtr display);

    public static al_get_display_flags AlGetDisplayFlags =
        NativeInterop.LoadFunction<al_get_display_flags>(_allegroLibrary, nameof(al_get_display_flags));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_set_display_flag(IntPtr display, int flag, [MarshalAs(UnmanagedType.U1)] bool onoff);

    public static al_set_display_flag AlSetDisplayFlag =
        NativeInterop.LoadFunction<al_set_display_flag>(_allegroLibrary, nameof(al_set_display_flag));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_display_option(IntPtr display, int option);

    public static al_get_display_option AlGetDisplayOption =
        NativeInterop.LoadFunction<al_get_display_option>(_allegroLibrary, nameof(al_get_display_option));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_set_display_option(IntPtr display, int option, int value);

    public static al_set_display_option AlSetDisplayOption =
        NativeInterop.LoadFunction<al_set_display_option>(_allegroLibrary, nameof(al_set_display_option));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_display_format(IntPtr display);

    public static al_get_display_format AlGetDisplayFormat =
        NativeInterop.LoadFunction<al_get_display_format>(_allegroLibrary, nameof(al_get_display_format));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_display_orientation(IntPtr display);

    public static al_get_display_orientation AlGetDisplayOrientation =
        NativeInterop.LoadFunction<al_get_display_orientation>(_allegroLibrary, nameof(al_get_display_orientation));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_display_refresh_rate(IntPtr display);

    public static al_get_display_refresh_rate AlGetDisplayRefreshRate =
        NativeInterop.LoadFunction<al_get_display_refresh_rate>(_allegroLibrary, nameof(al_get_display_refresh_rate));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_set_window_title(IntPtr display, IntPtr title);

    public static al_set_window_title AlSetWindowTitle =
        NativeInterop.LoadFunction<al_set_window_title>(_allegroLibrary, nameof(al_set_window_title));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_set_new_window_title(IntPtr title);

    public static al_set_new_window_title AlSetNewWindowTitle =
        NativeInterop.LoadFunction<al_set_new_window_title>(_allegroLibrary, nameof(al_set_new_window_title));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_new_window_title();

    public static al_get_new_window_title AlGetNewWindowTitle =
        NativeInterop.LoadFunction<al_get_new_window_title>(_allegroLibrary, nameof(al_get_new_window_title));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_set_display_icon(IntPtr display, IntPtr icon);

    public static al_set_display_icon AlSetDisplayIcon =
        NativeInterop.LoadFunction<al_set_display_icon>(_allegroLibrary, nameof(al_set_display_icon));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_set_display_icons(IntPtr display, int num_icons, ref IntPtr[] icon);

    public static al_set_display_icons AlSetDisplayIcons =
        NativeInterop.LoadFunction<al_set_display_icons>(_allegroLibrary, nameof(al_set_display_icons));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_acknowledge_drawing_halt(IntPtr display);

    public static al_acknowledge_drawing_halt AlAcknowledgeDrawingHalt =
        NativeInterop.LoadFunction<al_acknowledge_drawing_halt>(_allegroLibrary, nameof(al_acknowledge_drawing_halt));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_acknowledge_drawing_resume(IntPtr display);

    public static al_acknowledge_drawing_resume AlAcknowledgeDrawingResume =
        NativeInterop.LoadFunction<al_acknowledge_drawing_resume>(_allegroLibrary, nameof(al_acknowledge_drawing_resume));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_inhibit_screensaver([MarshalAs(UnmanagedType.U1)] bool inhibit);

    public static al_inhibit_screensaver AlInhibitScreensaver =
        NativeInterop.LoadFunction<al_inhibit_screensaver>(_allegroLibrary, nameof(al_inhibit_screensaver));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_clipboard_text(IntPtr display);

    public static al_get_clipboard_text AlGetClipboardText =
        NativeInterop.LoadFunction<al_get_clipboard_text>(_allegroLibrary, nameof(al_get_clipboard_text));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_set_clipboard_text(IntPtr display, IntPtr text);

    public static al_set_clipboard_text AlSetClipboardText =
        NativeInterop.LoadFunction<al_set_clipboard_text>(_allegroLibrary, nameof(al_set_clipboard_text));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_clipboard_has_text(IntPtr display);

    public static al_clipboard_has_text AlClipboardHasText =
        NativeInterop.LoadFunction<al_clipboard_has_text>(_allegroLibrary, nameof(al_clipboard_has_text));

    #endregion Display routines

    #region Event routines

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_create_event_queue();

    public static al_create_event_queue AlCreateEventQueue =
        NativeInterop.LoadFunction<al_create_event_queue>(_allegroLibrary, nameof(al_create_event_queue));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_destroy_event_queue(IntPtr queue);

    public static al_destroy_event_queue AlDestroyEventQueue =
        NativeInterop.LoadFunction<al_destroy_event_queue>(_allegroLibrary, nameof(al_destroy_event_queue));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_register_event_source(IntPtr queue, IntPtr source);

    public static al_register_event_source AlRegisterEventSource =
        NativeInterop.LoadFunction<al_register_event_source>(_allegroLibrary, nameof(al_register_event_source));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_unregister_event_source(IntPtr queue, IntPtr source);

    public static al_unregister_event_source AlUnregisterEventSource =
        NativeInterop.LoadFunction<al_unregister_event_source>(_allegroLibrary, nameof(al_unregister_event_source));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_is_event_source_registered(IntPtr queue, IntPtr source);

    public static al_is_event_source_registered AlIsEventSourceRegistered =
        NativeInterop.LoadFunction<al_is_event_source_registered>(_allegroLibrary, nameof(al_is_event_source_registered));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_pause_event_queue(IntPtr queue, [MarshalAs(UnmanagedType.U1)] bool pause);

    public static al_pause_event_queue AlPauseEventQueue =
        NativeInterop.LoadFunction<al_pause_event_queue>(_allegroLibrary, nameof(al_pause_event_queue));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_is_event_queue_paused(IntPtr queue);

    public static al_is_event_queue_paused AlIsEventQueuePaused =
        NativeInterop.LoadFunction<al_is_event_queue_paused>(_allegroLibrary, nameof(al_is_event_queue_paused));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_is_event_queue_empty(IntPtr queue);

    public static al_is_event_queue_empty AlIsEventQueueEmpty =
        NativeInterop.LoadFunction<al_is_event_queue_empty>(_allegroLibrary, nameof(al_is_event_queue_empty));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_get_next_event(IntPtr queue, ref AllegroEvent.NativeAllegroEvent ret_event);

    public static al_get_next_event AlGetNextEvent =
        NativeInterop.LoadFunction<al_get_next_event>(_allegroLibrary, nameof(al_get_next_event));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_peek_next_event(IntPtr queue, ref AllegroEvent.NativeAllegroEvent ret_event);

    public static al_peek_next_event AlPeekNextEvent =
        NativeInterop.LoadFunction<al_peek_next_event>(_allegroLibrary, nameof(al_peek_next_event));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_drop_next_event(IntPtr queue);

    public static al_drop_next_event AlDropNextEvent =
        NativeInterop.LoadFunction<al_drop_next_event>(_allegroLibrary, nameof(al_drop_next_event));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_flush_event_queue(IntPtr queue);

    public static al_flush_event_queue AlFlushEventQueue =
        NativeInterop.LoadFunction<al_flush_event_queue>(_allegroLibrary, nameof(al_flush_event_queue));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_wait_for_event(IntPtr queue, ref AllegroEvent.NativeAllegroEvent ret_event);

    public static al_wait_for_event AlWaitForEvent =
        NativeInterop.LoadFunction<al_wait_for_event>(_allegroLibrary, nameof(al_wait_for_event));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_wait_for_event_timed(IntPtr queue, ref AllegroEvent.NativeAllegroEvent ret_event, float secs);

    public static al_wait_for_event_timed AlWaitForEventTimed =
        NativeInterop.LoadFunction<al_wait_for_event_timed>(_allegroLibrary, nameof(al_wait_for_event_timed));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_wait_for_event_until(
        IntPtr queue,
        ref AllegroEvent.NativeAllegroEvent ret_event,
        ref AllegroTimeout.NativeAllegroTimeout timeout);

    public static al_wait_for_event_until AlWaitForEventUntil =
        NativeInterop.LoadFunction<al_wait_for_event_until>(_allegroLibrary, nameof(al_wait_for_event_until));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_init_user_event_source(IntPtr source);

    public static al_init_user_event_source AlInitUserEventSource =
        NativeInterop.LoadFunction<al_init_user_event_source>(_allegroLibrary, nameof(al_init_user_event_source));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_destroy_user_event_source(IntPtr source);

    public static al_destroy_user_event_source AlDestroyUserEventSource =
        NativeInterop.LoadFunction<al_destroy_user_event_source>(_allegroLibrary, nameof(al_destroy_user_event_source));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_emit_user_event(
        IntPtr source,
        ref AllegroEvent.NativeAllegroEvent alEvent,
        UserEventDelegate? userEventHandler);

    public static al_emit_user_event AlEmitUserEvent =
        NativeInterop.LoadFunction<al_emit_user_event>(_allegroLibrary, nameof(al_emit_user_event));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_unref_user_event(ref AllegroEvent.NativeAllegroUserEvent userEvent);

    public static al_unref_user_event AlUnrefUserEvent =
        NativeInterop.LoadFunction<al_unref_user_event>(_allegroLibrary, nameof(al_unref_user_event));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_event_source_data(IntPtr source);

    public static al_get_event_source_data AlGetEventSourceData =
        NativeInterop.LoadFunction<al_get_event_source_data>(_allegroLibrary, nameof(al_get_event_source_data));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_set_event_source_data(IntPtr source, IntPtr data);

    public static al_set_event_source_data AlSetEventSourceData =
        NativeInterop.LoadFunction<al_set_event_source_data>(_allegroLibrary, nameof(al_set_event_source_data));

    #endregion Event routines

    #region File system routines

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_create_fs_entry(IntPtr path);

    public static al_create_fs_entry AlCreateFsEntry =
        NativeInterop.LoadFunction<al_create_fs_entry>(_allegroLibrary, nameof(al_create_fs_entry));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_destroy_fs_entry(IntPtr fh);

    public static al_destroy_fs_entry AlDestroyFsEntry =
        NativeInterop.LoadFunction<al_destroy_fs_entry>(_allegroLibrary, nameof(al_destroy_fs_entry));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_fs_entry_name(IntPtr e);

    public static al_get_fs_entry_name AlGetFsEntryName =
        NativeInterop.LoadFunction<al_get_fs_entry_name>(_allegroLibrary, nameof(al_get_fs_entry_name));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_update_fs_entry(IntPtr e);

    public static al_update_fs_entry AlUpdateFsEntry =
        NativeInterop.LoadFunction<al_update_fs_entry>(_allegroLibrary, nameof(al_update_fs_entry));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate uint al_get_fs_entry_mode(IntPtr e);

    public static al_get_fs_entry_mode AlGetFsEntryMode =
        NativeInterop.LoadFunction<al_get_fs_entry_mode>(_allegroLibrary, nameof(al_get_fs_entry_mode));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate ulong al_get_fs_entry_atime(IntPtr e);

    public static al_get_fs_entry_atime AlGetFsEntryATime =
        NativeInterop.LoadFunction<al_get_fs_entry_atime>(_allegroLibrary, nameof(al_get_fs_entry_atime));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate ulong al_get_fs_entry_ctime(IntPtr e);

    public static al_get_fs_entry_ctime AlGetFsEntryCTime =
        NativeInterop.LoadFunction<al_get_fs_entry_ctime>(_allegroLibrary, nameof(al_get_fs_entry_ctime));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate ulong al_get_fs_entry_mtime(IntPtr e);

    public static al_get_fs_entry_mtime AlGetFsEntryMTime =
        NativeInterop.LoadFunction<al_get_fs_entry_mtime>(_allegroLibrary, nameof(al_get_fs_entry_mtime));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate long al_get_fs_entry_size(IntPtr e);

    public static al_get_fs_entry_size AlGetFsEntrySize =
        NativeInterop.LoadFunction<al_get_fs_entry_size>(_allegroLibrary, nameof(al_get_fs_entry_size));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_fs_entry_exists(IntPtr e);

    public static al_fs_entry_exists AlFsEntryExists =
        NativeInterop.LoadFunction<al_fs_entry_exists>(_allegroLibrary, nameof(al_fs_entry_exists));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_remove_fs_entry(IntPtr e);

    public static al_remove_fs_entry AlRemoveFsEntry =
        NativeInterop.LoadFunction<al_remove_fs_entry>(_allegroLibrary, nameof(al_remove_fs_entry));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_filename_exists(IntPtr path);

    public static al_filename_exists AlFilenameExists =
        NativeInterop.LoadFunction<al_filename_exists>(_allegroLibrary, nameof(al_filename_exists));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_remove_filename(IntPtr path);

    public static al_remove_filename AlRemoveFilename =
        NativeInterop.LoadFunction<al_remove_filename>(_allegroLibrary, nameof(al_remove_filename));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_open_directory(IntPtr e);

    public static al_open_directory AlOpenDirectory =
        NativeInterop.LoadFunction<al_open_directory>(_allegroLibrary, nameof(al_open_directory));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_read_directory(IntPtr e);

    public static al_read_directory AlReadDirectory =
        NativeInterop.LoadFunction<al_read_directory>(_allegroLibrary, nameof(al_read_directory));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_close_directory(IntPtr e);

    public static al_close_directory AlCloseDirectory =
        NativeInterop.LoadFunction<al_close_directory>(_allegroLibrary, nameof(al_close_directory));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_current_directory();

    public static al_get_current_directory AlGetCurrentDirectory =
        NativeInterop.LoadFunction<al_get_current_directory>(_allegroLibrary, nameof(al_get_current_directory));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_change_directory(IntPtr path);

    public static al_change_directory AlChangeDirectory =
        NativeInterop.LoadFunction<al_change_directory>(_allegroLibrary, nameof(al_change_directory));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_make_directory(IntPtr path);

    public static al_make_directory AlMakeDirectory =
        NativeInterop.LoadFunction<al_make_directory>(_allegroLibrary, nameof(al_make_directory));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_open_fs_entry(IntPtr e, IntPtr mode);

    public static al_open_fs_entry AlOpenFsEntry =
        NativeInterop.LoadFunction<al_open_fs_entry>(_allegroLibrary, nameof(al_open_fs_entry));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_for_each_fs_entry(IntPtr dir, ForEachFsEntry callback, IntPtr extra);

    public static al_for_each_fs_entry AlForEachFsEntry =
        NativeInterop.LoadFunction<al_for_each_fs_entry>(_allegroLibrary, nameof(al_for_each_fs_entry));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_set_fs_interface(IntPtr fs_interface);

    public static al_set_fs_interface AlSetFsInterface =
        NativeInterop.LoadFunction<al_set_fs_interface>(_allegroLibrary, nameof(al_set_fs_interface));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_set_standard_fs_interface();

    public static al_set_standard_fs_interface AlSetStandardFsInterface =
        NativeInterop.LoadFunction<al_set_standard_fs_interface>(_allegroLibrary, nameof(al_set_standard_fs_interface));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_fs_interface();

    public static al_get_fs_interface AlGetFsInterface =
        NativeInterop.LoadFunction<al_get_fs_interface>(_allegroLibrary, nameof(al_get_fs_interface));

    #endregion File system routines

    #region Fullscreen routines

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_display_mode(int index, ref AllegroDisplayMode.NativeDisplayMode mode);

    public static al_get_display_mode AlGetDisplayMode =
        NativeInterop.LoadFunction<al_get_display_mode>(_allegroLibrary, nameof(al_get_display_mode));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_num_display_modes();

    public static al_get_num_display_modes AlGetNumDisplayModes =
        NativeInterop.LoadFunction<al_get_num_display_modes>(_allegroLibrary, nameof(al_get_num_display_modes));

    #endregion Fullscreen routines

    #region Graphics routines

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate AllegroColor al_map_rgb(byte r, byte g, byte b);

    public static al_map_rgb AlMapRgb =
        NativeInterop.LoadFunction<al_map_rgb>(_allegroLibrary, nameof(al_map_rgb));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate AllegroColor al_map_rgb_f(float r, float g, float b);

    public static al_map_rgb_f AlMapRgbF =
        NativeInterop.LoadFunction<al_map_rgb_f>(_allegroLibrary, nameof(al_map_rgb_f));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate AllegroColor al_map_rgba(byte r, byte g, byte b, byte a);

    public static al_map_rgba AlMapRgba =
        NativeInterop.LoadFunction<al_map_rgba>(_allegroLibrary, nameof(al_map_rgba));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate AllegroColor al_premul_rgba(byte r, byte g, byte b, byte a);

    public static al_premul_rgba AlPremulRgba =
        NativeInterop.LoadFunction<al_premul_rgba>(_allegroLibrary, nameof(al_premul_rgba));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate AllegroColor al_map_rgba_f(float r, float g, float b, float a);

    public static al_map_rgba_f AlMapRgbaF =
        NativeInterop.LoadFunction<al_map_rgba_f>(_allegroLibrary, nameof(al_map_rgba_f));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate AllegroColor al_premul_rgba_f(float r, float g, float b, float a);

    public static al_premul_rgba_f AlPremulRgbaF =
        NativeInterop.LoadFunction<al_premul_rgba_f>(_allegroLibrary, nameof(al_premul_rgba_f));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_unmap_rgb(ref byte r, ref byte g, ref byte b);

    public static al_unmap_rgb AlUnmapRgb =
        NativeInterop.LoadFunction<al_unmap_rgb>(_allegroLibrary, nameof(al_unmap_rgb));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_unmap_rgb_f(ref float r, ref float g, ref float b);

    public static al_unmap_rgb_f AlUnmapRgbF =
        NativeInterop.LoadFunction<al_unmap_rgb_f>(_allegroLibrary, nameof(al_unmap_rgb_f));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_unmap_rgba(ref byte r, ref byte g, ref byte b, ref byte a);

    public static al_unmap_rgba AlUnmapRgba =
        NativeInterop.LoadFunction<al_unmap_rgba>(_allegroLibrary, nameof(al_unmap_rgba));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_unmap_rgba_f(ref float r, ref float g, ref float b, ref float a);

    public static al_unmap_rgba_f AlUnmapRgbaF =
        NativeInterop.LoadFunction<al_unmap_rgba_f>(_allegroLibrary, nameof(al_unmap_rgba_f));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_pixel_size(int format);

    public static al_get_pixel_size AlGetPixelSize =
        NativeInterop.LoadFunction<al_get_pixel_size>(_allegroLibrary, nameof(al_get_pixel_size));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_pixel_format_bits(int format);

    public static al_get_pixel_format_bits AlGetPixelFormatBits =
        NativeInterop.LoadFunction<al_get_pixel_format_bits>(_allegroLibrary, nameof(al_get_pixel_format_bits));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_pixel_block_size(int format);

    public static al_get_pixel_block_size AlGetPixelBlockSize =
        NativeInterop.LoadFunction<al_get_pixel_block_size>(_allegroLibrary, nameof(al_get_pixel_block_size));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_pixel_block_width(int format);

    public static al_get_pixel_block_width AlGetPixelBlockWidth =
        NativeInterop.LoadFunction<al_get_pixel_block_width>(_allegroLibrary, nameof(al_get_pixel_block_width));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_pixel_block_height(int format);

    public static al_get_pixel_block_height AlGetPixelBlockHeight =
        NativeInterop.LoadFunction<al_get_pixel_block_height>(_allegroLibrary, nameof(al_get_pixel_block_height));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_lock_bitmap(IntPtr bitmap, int format, int flags);

    public static al_lock_bitmap AlLockBitmap =
        NativeInterop.LoadFunction<al_lock_bitmap>(_allegroLibrary, nameof(al_lock_bitmap));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_lock_bitmap_region(IntPtr bitmap, int x, int y, int width, int height, int format, int flags);

    public static al_lock_bitmap_region AlLockBitmapRegion =
        NativeInterop.LoadFunction<al_lock_bitmap_region>(_allegroLibrary, nameof(al_lock_bitmap_region));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_unlock_bitmap(IntPtr bitmap);

    public static al_unlock_bitmap AlUnlockBitmap =
        NativeInterop.LoadFunction<al_unlock_bitmap>(_allegroLibrary, nameof(al_unlock_bitmap));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_lock_bitmap_blocked(IntPtr bitmap, int flags);

    public static al_lock_bitmap_blocked AlLockBitmapBlocked =
        NativeInterop.LoadFunction<al_lock_bitmap_blocked>(_allegroLibrary, nameof(al_lock_bitmap_blocked));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_lock_bitmap_region_blocked(IntPtr bitmap, int x_block, int y_block, int width_block, int height_block, int flags);

    public static al_lock_bitmap_region_blocked AlLockBitmapRegionBlocked =
        NativeInterop.LoadFunction<al_lock_bitmap_region_blocked>(_allegroLibrary, nameof(al_lock_bitmap_region_blocked));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_create_bitmap(int w, int h);

    public static al_create_bitmap AlCreateBitmap =
        NativeInterop.LoadFunction<al_create_bitmap>(_allegroLibrary, nameof(al_create_bitmap));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_create_sub_bitmap(IntPtr parent, int x, int y, int w, int h);

    public static al_create_sub_bitmap AlCreateSubBitmap =
        NativeInterop.LoadFunction<al_create_sub_bitmap>(_allegroLibrary, nameof(al_create_sub_bitmap));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_clone_bitmap(IntPtr parent);

    public static al_clone_bitmap AlCloneBitmap =
        NativeInterop.LoadFunction<al_clone_bitmap>(_allegroLibrary, nameof(al_clone_bitmap));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_convert_bitmap(IntPtr parent);

    public static al_convert_bitmap AlConvertBitmap =
        NativeInterop.LoadFunction<al_convert_bitmap>(_allegroLibrary, nameof(al_convert_bitmap));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_convert_memory_bitmaps();

    public static al_convert_memory_bitmaps AlConvertMemoryBitmaps =
        NativeInterop.LoadFunction<al_convert_memory_bitmaps>(_allegroLibrary, nameof(al_convert_memory_bitmaps));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_destroy_bitmap(IntPtr bitmap);

    public static al_destroy_bitmap AlDestroyBitmap =
        NativeInterop.LoadFunction<al_destroy_bitmap>(_allegroLibrary, nameof(al_destroy_bitmap));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_new_bitmap_flags();

    public static al_get_new_bitmap_flags AlGetNewBitmapFlags =
        NativeInterop.LoadFunction<al_get_new_bitmap_flags>(_allegroLibrary, nameof(al_get_new_bitmap_flags));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_new_bitmap_format();

    public static al_get_new_bitmap_format AlGetNewBitmapFormat =
        NativeInterop.LoadFunction<al_get_new_bitmap_format>(_allegroLibrary, nameof(al_get_new_bitmap_format));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_set_new_bitmap_flags(int flags);

    public static al_set_new_bitmap_flags AlSetNewBitmapFlags =
        NativeInterop.LoadFunction<al_set_new_bitmap_flags>(_allegroLibrary, nameof(al_set_new_bitmap_flags));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_add_new_bitmap_flag(int flag);

    public static al_add_new_bitmap_flag AlAddNewBitmapFlag =
        NativeInterop.LoadFunction<al_add_new_bitmap_flag>(_allegroLibrary, nameof(al_add_new_bitmap_flag));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_set_new_bitmap_format(int flag);

    public static al_set_new_bitmap_format AlSetNewBitmapFormat =
        NativeInterop.LoadFunction<al_set_new_bitmap_format>(_allegroLibrary, nameof(al_set_new_bitmap_format));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_bitmap_flags(IntPtr bitmap);

    public static al_get_bitmap_flags AlGetBitmapFlags =
        NativeInterop.LoadFunction<al_get_bitmap_flags>(_allegroLibrary, nameof(al_get_bitmap_flags));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_bitmap_format(IntPtr bitmap);

    public static al_get_bitmap_format AlGetBitmapFormat =
        NativeInterop.LoadFunction<al_get_bitmap_format>(_allegroLibrary, nameof(al_get_bitmap_format));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_bitmap_height(IntPtr bitmap);

    public static al_get_bitmap_height AlGetBitmapHeight =
        NativeInterop.LoadFunction<al_get_bitmap_height>(_allegroLibrary, nameof(al_get_bitmap_height));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_bitmap_width(IntPtr bitmap);

    public static al_get_bitmap_width AlGetBitmapWidth =
        NativeInterop.LoadFunction<al_get_bitmap_width>(_allegroLibrary, nameof(al_get_bitmap_width));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate AllegroColor al_get_pixel(IntPtr bitmap, int x, int y);

    public static al_get_pixel AlGetPixel =
        NativeInterop.LoadFunction<al_get_pixel>(_allegroLibrary, nameof(al_get_pixel));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_is_bitmap_locked(IntPtr bitmap);

    public static al_is_bitmap_locked AlIsBitmapLocked =
        NativeInterop.LoadFunction<al_is_bitmap_locked>(_allegroLibrary, nameof(al_is_bitmap_locked));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_is_compatible_bitmap(IntPtr bitmap);

    public static al_is_compatible_bitmap AlIsCompatibleBitmap =
        NativeInterop.LoadFunction<al_is_compatible_bitmap>(_allegroLibrary, nameof(al_is_compatible_bitmap));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_is_sub_bitmap(IntPtr bitmap);

    public static al_is_sub_bitmap AlIsSubBitmap =
        NativeInterop.LoadFunction<al_is_sub_bitmap>(_allegroLibrary, nameof(al_is_sub_bitmap));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_parent_bitmap(IntPtr bitmap);

    public static al_get_parent_bitmap AlGetParentBitmap =
        NativeInterop.LoadFunction<al_get_parent_bitmap>(_allegroLibrary, nameof(al_get_parent_bitmap));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_bitmap_x(IntPtr bitmap);

    public static al_get_bitmap_x AlGetBitmapX =
        NativeInterop.LoadFunction<al_get_bitmap_x>(_allegroLibrary, nameof(al_get_bitmap_x));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_bitmap_y(IntPtr bitmap);

    public static al_get_bitmap_y AlGetBitmapY =
        NativeInterop.LoadFunction<al_get_bitmap_y>(_allegroLibrary, nameof(al_get_bitmap_y));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_reparent_bitmap(IntPtr bitmap, IntPtr parent, int x, int y, int w, int h);

    public static al_reparent_bitmap AlReparentBitmap =
        NativeInterop.LoadFunction<al_reparent_bitmap>(_allegroLibrary, nameof(al_reparent_bitmap));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_clear_to_color(AllegroColor color);

    public static al_clear_to_color AlClearToColor =
        NativeInterop.LoadFunction<al_clear_to_color>(_allegroLibrary, nameof(al_clear_to_color));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_clear_depth_buffer(float z);

    public static al_clear_depth_buffer AlClearDepthBuffer =
        NativeInterop.LoadFunction<al_clear_depth_buffer>(_allegroLibrary, nameof(al_clear_depth_buffer));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_draw_bitmap(IntPtr bitmap, float dx, float dy, int flags);

    public static al_draw_bitmap AlDrawBitmap =
        NativeInterop.LoadFunction<al_draw_bitmap>(_allegroLibrary, nameof(al_draw_bitmap));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_draw_tinted_bitmap(IntPtr bitmap, AllegroColor tint, float dx, float dy, int flags);

    public static al_draw_tinted_bitmap AlDrawTintedBitmap =
        NativeInterop.LoadFunction<al_draw_tinted_bitmap>(_allegroLibrary, nameof(al_draw_tinted_bitmap));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_draw_bitmap_region(IntPtr bitmap, float sx, float sy, float sw, float sh, float dx, float dy, int flags);

    public static al_draw_bitmap_region AlDrawBitmapRegion =
        NativeInterop.LoadFunction<al_draw_bitmap_region>(_allegroLibrary, nameof(al_draw_bitmap_region));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_draw_tinted_bitmap_region(IntPtr bitmap, AllegroColor tint, float sx, float sy, float sw, float sh, float dx, float dy, int flags);

    public static al_draw_tinted_bitmap_region AlDrawTintedBitmapRegion =
        NativeInterop.LoadFunction<al_draw_tinted_bitmap_region>(_allegroLibrary, nameof(al_draw_tinted_bitmap_region));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_draw_pixel(float x, float y, AllegroColor color);

    public static al_draw_pixel AlDrawPixel =
        NativeInterop.LoadFunction<al_draw_pixel>(_allegroLibrary, nameof(al_draw_pixel));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_draw_rotated_bitmap(IntPtr bitmap, float cx, float cy, float dx, float dy, float angle, int flags);

    public static al_draw_rotated_bitmap AlDrawRotatedBitmap =
        NativeInterop.LoadFunction<al_draw_rotated_bitmap>(_allegroLibrary, nameof(al_draw_rotated_bitmap));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_draw_tinted_rotated_bitmap(IntPtr bitmap, AllegroColor tint, float cx, float cy, float dx, float dy, float angle, int flags);

    public static al_draw_tinted_rotated_bitmap AlDrawTintedRotatedBitmap =
        NativeInterop.LoadFunction<al_draw_tinted_rotated_bitmap>(_allegroLibrary, nameof(al_draw_tinted_rotated_bitmap));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_draw_scaled_rotated_bitmap(IntPtr bitmap, float cx, float cy, float dx, float dy, float xscale, float yscale, float angle, int flags);

    public static al_draw_scaled_rotated_bitmap AlDrawScaledRotatedBitmap =
        NativeInterop.LoadFunction<al_draw_scaled_rotated_bitmap>(_allegroLibrary, nameof(al_draw_scaled_rotated_bitmap));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_draw_tinted_scaled_rotated_bitmap(IntPtr bitmap, AllegroColor tint, float cx, float cy, float dx, float dy, float xscale, float yscale, float angle, int flags);

    public static al_draw_tinted_scaled_rotated_bitmap AlDrawTintedScaledRotatedBitmap =
        NativeInterop.LoadFunction<al_draw_tinted_scaled_rotated_bitmap>(_allegroLibrary, nameof(al_draw_tinted_scaled_rotated_bitmap));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_draw_tinted_scaled_rotated_bitmap_region(IntPtr bitmap, float sx, float sy, float sw, float sh, AllegroColor tint, float cx, float cy, float dx, float dy, float xscale, float yscale, float angle, int flags);

    public static al_draw_tinted_scaled_rotated_bitmap_region AlDrawTintedScaledRotatedBitmapRegion =
        NativeInterop.LoadFunction<al_draw_tinted_scaled_rotated_bitmap_region>(_allegroLibrary, nameof(al_draw_tinted_scaled_rotated_bitmap_region));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_draw_scaled_bitmap(IntPtr bitmap, float sx, float sy, float sw, float sh, float dx, float dy, float dw, float dh, int flags);

    public static al_draw_scaled_bitmap AlDrawScaledBitmap =
        NativeInterop.LoadFunction<al_draw_scaled_bitmap>(_allegroLibrary, nameof(al_draw_scaled_bitmap));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_draw_tinted_scaled_bitmap(IntPtr bitmap, AllegroColor tint, float sx, float sy, float sw, float sh, float dx, float dy, float dw, float dh, int flags);

    public static al_draw_tinted_scaled_bitmap AlDrawTintedScaledBitmap =
        NativeInterop.LoadFunction<al_draw_tinted_scaled_bitmap>(_allegroLibrary, nameof(al_draw_tinted_scaled_bitmap));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_target_bitmap();

    public static al_get_target_bitmap AlGetTargetBitmap =
        NativeInterop.LoadFunction<al_get_target_bitmap>(_allegroLibrary, nameof(al_get_target_bitmap));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_put_pixel(int x, int y, AllegroColor color);

    public static al_put_pixel AlPutPixel =
        NativeInterop.LoadFunction<al_put_pixel>(_allegroLibrary, nameof(al_put_pixel));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_put_blended_pixel(int x, int y, AllegroColor color);

    public static al_put_blended_pixel AlPutBlendedPixel =
        NativeInterop.LoadFunction<al_put_blended_pixel>(_allegroLibrary, nameof(al_put_blended_pixel));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_set_target_bitmap(IntPtr bitmap);

    public static al_set_target_bitmap AlSetTargetBitmap =
        NativeInterop.LoadFunction<al_set_target_bitmap>(_allegroLibrary, nameof(al_set_target_bitmap));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_set_target_backbuffer(IntPtr display);

    public static al_set_target_backbuffer AlSetTargetBackbuffer =
        NativeInterop.LoadFunction<al_set_target_backbuffer>(_allegroLibrary, nameof(al_set_target_backbuffer));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_current_display();

    public static al_get_current_display AlGetCurrentDisplay =
        NativeInterop.LoadFunction<al_get_current_display>(_allegroLibrary, nameof(al_get_current_display));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_get_blender(ref int op, ref int src, ref int dst);

    public static al_get_blender AlGetBlender =
        NativeInterop.LoadFunction<al_get_blender>(_allegroLibrary, nameof(al_get_blender));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_get_separate_blender(ref int op, ref int src, ref int dst, ref int alpha_op, ref int alpha_src, ref int alpha_dst);

    public static al_get_separate_blender AlGetSeparateBlender =
        NativeInterop.LoadFunction<al_get_separate_blender>(_allegroLibrary, nameof(al_get_separate_blender));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate AllegroColor al_get_blend_color();

    public static al_get_blend_color AlGetBlendColor =
        NativeInterop.LoadFunction<al_get_blend_color>(_allegroLibrary, nameof(al_get_blend_color));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_set_blender(int op, int src, int dst);

    public static al_set_blender AlSetBlender =
        NativeInterop.LoadFunction<al_set_blender>(_allegroLibrary, nameof(al_set_blender));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_set_separate_blender(int op, int src, int dst, int alpha_op, int alpha_src, int alpha_dst);

    public static al_set_separate_blender AlSetSeparateBlender =
        NativeInterop.LoadFunction<al_set_separate_blender>(_allegroLibrary, nameof(al_set_separate_blender));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_set_blend_color(AllegroColor color);

    public static al_set_blend_color AlSetBlendColor =
        NativeInterop.LoadFunction<al_set_blend_color>(_allegroLibrary, nameof(al_set_blend_color));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_get_clipping_rectangle(ref int x, ref int y, ref int w, ref int h);

    public static al_get_clipping_rectangle AlGetClippingRectangle =
        NativeInterop.LoadFunction<al_get_clipping_rectangle>(_allegroLibrary, nameof(al_get_clipping_rectangle));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_set_clipping_rectangle(int x, int y, int width, int height);

    public static al_set_clipping_rectangle AlSetClippingRectangle =
        NativeInterop.LoadFunction<al_set_clipping_rectangle>(_allegroLibrary, nameof(al_set_clipping_rectangle));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_reset_clipping_rectangle();

    public static al_reset_clipping_rectangle AlResetClippingRectangle =
        NativeInterop.LoadFunction<al_reset_clipping_rectangle>(_allegroLibrary, nameof(al_reset_clipping_rectangle));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_convert_mask_to_alpha(IntPtr bitmap, AllegroColor mask_color);

    public static al_convert_mask_to_alpha AlConvertMaskToAlpha =
        NativeInterop.LoadFunction<al_convert_mask_to_alpha>(_allegroLibrary, nameof(al_convert_mask_to_alpha));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_hold_bitmap_drawing([MarshalAs(UnmanagedType.U1)] bool hold);

    public static al_hold_bitmap_drawing AlHoldBitmapDrawing =
        NativeInterop.LoadFunction<al_hold_bitmap_drawing>(_allegroLibrary, nameof(al_hold_bitmap_drawing));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_is_bitmap_drawing_held();

    public static al_is_bitmap_drawing_held AlIsBitmapDrawingHeld =
        NativeInterop.LoadFunction<al_is_bitmap_drawing_held>(_allegroLibrary, nameof(al_is_bitmap_drawing_held));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_register_bitmap_loader(IntPtr extension, RegisterBitmapLoader loader);

    public static al_register_bitmap_loader AlRegisterBitmapLoader =
        NativeInterop.LoadFunction<al_register_bitmap_loader>(_allegroLibrary, nameof(al_register_bitmap_loader));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_register_bitmap_saver(IntPtr extension, RegisterBitmapSaver saver);

    public static al_register_bitmap_saver AlRegisterBitmapSaver =
        NativeInterop.LoadFunction<al_register_bitmap_saver>(_allegroLibrary, nameof(al_register_bitmap_saver));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_register_bitmap_loader_f(IntPtr extension, RegisterBitmapLoaderF fs_loader);

    public static al_register_bitmap_loader_f AlRegisterBitmapLoaderF =
        NativeInterop.LoadFunction<al_register_bitmap_loader_f>(_allegroLibrary, nameof(al_register_bitmap_loader_f));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_register_bitmap_saver_f(IntPtr extension, RegisterBitmapSaverF fs_saver);

    public static al_register_bitmap_saver_f AlRegisterBitmapSaverF =
        NativeInterop.LoadFunction<al_register_bitmap_saver_f>(_allegroLibrary, nameof(al_register_bitmap_saver_f));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_load_bitmap(IntPtr filename);

    public static al_load_bitmap AlLoadBitmap =
        NativeInterop.LoadFunction<al_load_bitmap>(_allegroLibrary, nameof(al_load_bitmap));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_load_bitmap_flags(IntPtr filename, int flags);

    public static al_load_bitmap_flags AlLoadBitmapFlags =
        NativeInterop.LoadFunction<al_load_bitmap_flags>(_allegroLibrary, nameof(al_load_bitmap_flags));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_load_bitmap_f(IntPtr fp, IntPtr ident);

    public static al_load_bitmap_f AlLoadBitmapF =
        NativeInterop.LoadFunction<al_load_bitmap_f>(_allegroLibrary, nameof(al_load_bitmap_f));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_load_bitmap_flags_f(IntPtr fp, IntPtr ident, int flags);

    public static al_load_bitmap_flags_f AlLoadBitmapFlagsF =
        NativeInterop.LoadFunction<al_load_bitmap_flags_f>(_allegroLibrary, nameof(al_load_bitmap_flags_f));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_save_bitmap(IntPtr filename, IntPtr bitmap);

    public static al_save_bitmap AlSaveBitmap =
        NativeInterop.LoadFunction<al_save_bitmap>(_allegroLibrary, nameof(al_save_bitmap));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_save_bitmap_f(IntPtr fp, IntPtr ident, IntPtr bitmap);

    public static al_save_bitmap_f AlSaveBitmapF =
        NativeInterop.LoadFunction<al_save_bitmap_f>(_allegroLibrary, nameof(al_save_bitmap_f));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_register_bitmap_identifier(IntPtr extension, RegisterBitmapIdentifier identifier);

    public static al_register_bitmap_identifier AlRegisterBitmapIdentifier =
        NativeInterop.LoadFunction<al_register_bitmap_identifier>(_allegroLibrary, nameof(al_register_bitmap_identifier));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_identify_bitmap(IntPtr filename);

    public static al_identify_bitmap AlIdentifyBitmap =
        NativeInterop.LoadFunction<al_identify_bitmap>(_allegroLibrary, nameof(al_identify_bitmap));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_identify_bitmap_f(IntPtr fp);

    public static al_identify_bitmap_f AlIdentifyBitmapF =
        NativeInterop.LoadFunction<al_identify_bitmap_f>(_allegroLibrary, nameof(al_identify_bitmap_f));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_set_render_state(int state, int value);

    public static al_set_render_state AlSetRenderState =
        NativeInterop.LoadFunction<al_set_render_state>(_allegroLibrary, nameof(al_set_render_state));

    #endregion Graphics routines

    #region Image IO routines

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_init_image_addon();

    public static al_init_image_addon AlInitImageAddon =
        NativeInterop.LoadFunction<al_init_image_addon>(_allegroLibrary, nameof(al_init_image_addon));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_is_image_addon_initialized();

    public static al_is_image_addon_initialized AlIsImageAddonInitialized =
        NativeInterop.LoadFunction<al_is_image_addon_initialized>(_allegroLibrary, nameof(al_is_image_addon_initialized));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_shutdown_image_addon();

    public static al_shutdown_image_addon AlShutdownImageAddon =
        NativeInterop.LoadFunction<al_shutdown_image_addon>(_allegroLibrary, nameof(al_shutdown_image_addon));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate uint al_get_allegro_image_version();

    public static al_get_allegro_image_version AlGetAllegroImageVersion =
        NativeInterop.LoadFunction<al_get_allegro_image_version>(_allegroLibrary, nameof(al_get_allegro_image_version));

    #endregion

    #region Joystick routines

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_install_joystick();

    public static al_install_joystick AlInstallJoystick =
        NativeInterop.LoadFunction<al_install_joystick>(_allegroLibrary, nameof(al_install_joystick));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_uninstall_joystick();

    public static al_uninstall_joystick AlUninstallJoystick =
        NativeInterop.LoadFunction<al_uninstall_joystick>(_allegroLibrary, nameof(al_uninstall_joystick));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_is_joystick_installed();

    public static al_is_joystick_installed AlIsJoystickInstalled =
        NativeInterop.LoadFunction<al_is_joystick_installed>(_allegroLibrary, nameof(al_is_joystick_installed));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_reconfigure_joysticks();

    public static al_reconfigure_joysticks AlReconfigureJoysticks =
        NativeInterop.LoadFunction<al_reconfigure_joysticks>(_allegroLibrary, nameof(al_reconfigure_joysticks));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_num_joysticks();

    public static al_get_num_joysticks AlGetNumJoysticks =
        NativeInterop.LoadFunction<al_get_num_joysticks>(_allegroLibrary, nameof(al_get_num_joysticks));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_joystick(int num);

    public static al_get_joystick AlGetJoystick =
        NativeInterop.LoadFunction<al_get_joystick>(_allegroLibrary, nameof(al_get_joystick));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_release_joystick(IntPtr joy);

    public static al_release_joystick AlReleaseJoystick =
        NativeInterop.LoadFunction<al_release_joystick>(_allegroLibrary, nameof(al_release_joystick));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_get_joystick_active(IntPtr joy);

    public static al_get_joystick_active AlGetJoystickActive =
        NativeInterop.LoadFunction<al_get_joystick_active>(_allegroLibrary, nameof(al_get_joystick_active));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_joystick_name(IntPtr joy);

    public static al_get_joystick_name AlGetJoystickName =
        NativeInterop.LoadFunction<al_get_joystick_name>(_allegroLibrary, nameof(al_get_joystick_name));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_joystick_stick_name(IntPtr joy, int stick);

    public static al_get_joystick_stick_name AlGetJoystickStickName =
        NativeInterop.LoadFunction<al_get_joystick_stick_name>(_allegroLibrary, nameof(al_get_joystick_stick_name));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_joystick_axis_name(IntPtr joy, int stick, int axis);

    public static al_get_joystick_axis_name AlGetJoystickAxisName =
        NativeInterop.LoadFunction<al_get_joystick_axis_name>(_allegroLibrary, nameof(al_get_joystick_axis_name));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_joystick_button_name(IntPtr joy, int button);

    public static al_get_joystick_button_name AlGetJoystickButtonName =
        NativeInterop.LoadFunction<al_get_joystick_button_name>(_allegroLibrary, nameof(al_get_joystick_button_name));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_joystick_stick_flags(IntPtr joy, int stick);

    public static al_get_joystick_stick_flags AlGetJoystickStickFlags =
        NativeInterop.LoadFunction<al_get_joystick_stick_flags>(_allegroLibrary, nameof(al_get_joystick_stick_flags));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_joystick_num_sticks(IntPtr joy);

    public static al_get_joystick_num_sticks AlGetJoystickNumSticks =
        NativeInterop.LoadFunction<al_get_joystick_num_sticks>(_allegroLibrary, nameof(al_get_joystick_num_sticks));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_joystick_num_axes(IntPtr joy, int stick);

    public static al_get_joystick_num_axes AlGetJoystickNumAxes =
        NativeInterop.LoadFunction<al_get_joystick_num_axes>(_allegroLibrary, nameof(al_get_joystick_num_axes));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_joystick_num_buttons(IntPtr joy);

    public static al_get_joystick_num_buttons AlGetJoystickNumButtons =
        NativeInterop.LoadFunction<al_get_joystick_num_buttons>(_allegroLibrary, nameof(al_get_joystick_num_buttons));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_get_joystick_state(IntPtr joy, ref AllegroJoystickState.NativeJoystickState ret_state);

    public static al_get_joystick_state AlGetJoystickState =
        NativeInterop.LoadFunction<al_get_joystick_state>(_allegroLibrary, nameof(al_get_joystick_state));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_joystick_event_source();

    public static al_get_joystick_event_source AlGetJoystickEventSource =
        NativeInterop.LoadFunction<al_get_joystick_event_source>(_allegroLibrary, nameof(al_get_joystick_event_source));

    #endregion Joystick routines

    #region Keyboard routines

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_install_keyboard();

    public static al_install_keyboard AlInstallKeyboard =
        NativeInterop.LoadFunction<al_install_keyboard>(_allegroLibrary, nameof(al_install_keyboard));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_is_keyboard_installed();

    public static al_is_keyboard_installed AlIsKeyboardInstalled =
        NativeInterop.LoadFunction<al_is_keyboard_installed>(_allegroLibrary, nameof(al_is_keyboard_installed));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_uninstall_keyboard();

    public static al_uninstall_keyboard AlUninstallKeyboard =
        NativeInterop.LoadFunction<al_uninstall_keyboard>(_allegroLibrary, nameof(al_uninstall_keyboard));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_get_keyboard_state(ref AllegroKeyboardState.NativeKeyboardState ret_state);

    public static al_get_keyboard_state AlGetKeyboardState =
        NativeInterop.LoadFunction<al_get_keyboard_state>(_allegroLibrary, nameof(al_get_keyboard_state));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_key_down(ref AllegroKeyboardState.NativeKeyboardState state, int keycode);

    public static al_key_down AlKeyDown =
        NativeInterop.LoadFunction<al_key_down>(_allegroLibrary, nameof(al_key_down));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_keycode_to_name(int keycode);

    public static al_keycode_to_name AlKeycodeToName =
        NativeInterop.LoadFunction<al_keycode_to_name>(_allegroLibrary, nameof(al_keycode_to_name));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_set_keyboard_leds(int leds);

    public static al_set_keyboard_leds AlSetKeyboardLeds =
        NativeInterop.LoadFunction<al_set_keyboard_leds>(_allegroLibrary, nameof(al_set_keyboard_leds));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_keyboard_event_source();

    public static al_get_keyboard_event_source AlGetKeyboardEventSource =
        NativeInterop.LoadFunction<al_get_keyboard_event_source>(_allegroLibrary, nameof(al_get_keyboard_event_source));

    #endregion Keyboard routines

    #region Memory routines

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_malloc_with_context(UIntPtr n, int line, IntPtr file, IntPtr func);

    public static al_malloc_with_context AlMallocWithContext =
        NativeInterop.LoadFunction<al_malloc_with_context>(_allegroLibrary, nameof(al_malloc_with_context));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_free_with_context(IntPtr ptr, int line, IntPtr file, IntPtr func);

    public static al_free_with_context AlFreeWithContext =
        NativeInterop.LoadFunction<al_free_with_context>(_allegroLibrary, nameof(al_free_with_context));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_realloc_with_context(IntPtr ptr, UIntPtr n, int line, IntPtr file, IntPtr func);

    public static al_realloc_with_context AlReallocWithContext =
        NativeInterop.LoadFunction<al_realloc_with_context>(_allegroLibrary, nameof(al_realloc_with_context));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_calloc_with_context(UIntPtr count, UIntPtr n, int line, IntPtr file, IntPtr func);

    public static al_calloc_with_context AlCallocWithContext =
        NativeInterop.LoadFunction<al_calloc_with_context>(_allegroLibrary, nameof(al_calloc_with_context));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_set_memory_interface(ref AllegroMemoryInterface.NativeMemoryInterface memory_interface);

    public static al_set_memory_interface AlSetMemoryInterface =
        NativeInterop.LoadFunction<al_set_memory_interface>(_allegroLibrary, nameof(al_set_memory_interface));

    #endregion Memory routines

    #region Monitor routines

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_new_display_adapter();

    public static al_get_new_display_adapter AlGetNewDisplayAdapter =
        NativeInterop.LoadFunction<al_get_new_display_adapter>(_allegroLibrary, nameof(al_get_new_display_adapter));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_set_new_display_adapter(int adapter);

    public static al_set_new_display_adapter AlSetNewDisplayAdapter =
        NativeInterop.LoadFunction<al_set_new_display_adapter>(_allegroLibrary, nameof(al_set_new_display_adapter));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_get_monitor_info(int adapter, ref AllegroMonitorInfo.NativeMonitorInfo info);

    public static al_get_monitor_info AlGetMonitorInfo =
        NativeInterop.LoadFunction<al_get_monitor_info>(_allegroLibrary, nameof(al_get_monitor_info));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_monitor_dpi(int adapter);

    public static al_get_monitor_dpi AlGetMonitorDpi =
        NativeInterop.LoadFunction<al_get_monitor_dpi>(_allegroLibrary, nameof(al_get_monitor_dpi));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_num_video_adapters();

    public static al_get_num_video_adapters AlGetNumVideoAdapters =
        NativeInterop.LoadFunction<al_get_num_video_adapters>(_allegroLibrary, nameof(al_get_num_video_adapters));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_monitor_refresh_rate(int adapter);

    public static al_get_monitor_refresh_rate AlGetMonitorRefreshRate =
        NativeInterop.LoadFunction<al_get_monitor_refresh_rate>(_allegroLibrary, nameof(al_get_monitor_refresh_rate));

    #endregion Monitor routines

    #region Mouse routines

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_install_mouse();

    public static al_install_mouse AlInstallMouse =
        NativeInterop.LoadFunction<al_install_mouse>(_allegroLibrary, nameof(al_install_mouse));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_is_mouse_installed();

    public static al_is_mouse_installed AlIsMouseInstalled =
        NativeInterop.LoadFunction<al_is_mouse_installed>(_allegroLibrary, nameof(al_is_mouse_installed));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_uninstall_mouse();

    public static al_uninstall_mouse AlUninstallMouse =
        NativeInterop.LoadFunction<al_uninstall_mouse>(_allegroLibrary, nameof(al_uninstall_mouse));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate uint al_get_mouse_num_axes();

    public static al_get_mouse_num_axes AlGetMouseNumAxes =
        NativeInterop.LoadFunction<al_get_mouse_num_axes>(_allegroLibrary, nameof(al_get_mouse_num_axes));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate uint al_get_mouse_num_buttons();

    public static al_get_mouse_num_buttons AlGetMouseNumButtons =
        NativeInterop.LoadFunction<al_get_mouse_num_buttons>(_allegroLibrary, nameof(al_get_mouse_num_buttons));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_get_mouse_state(ref AllegroMouseState.NativeMouseState ret_state);

    public static al_get_mouse_state AlGetMouseState =
        NativeInterop.LoadFunction<al_get_mouse_state>(_allegroLibrary, nameof(al_get_mouse_state));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_mouse_state_axis(ref AllegroMouseState.NativeMouseState ret_state, int axis);

    public static al_get_mouse_state_axis AlGetMouseStateAxis =
        NativeInterop.LoadFunction<al_get_mouse_state_axis>(_allegroLibrary, nameof(al_get_mouse_state_axis));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_mouse_button_down(ref AllegroMouseState.NativeMouseState ret_state, int button);

    public static al_mouse_button_down AlMouseButtonDown =
        NativeInterop.LoadFunction<al_mouse_button_down>(_allegroLibrary, nameof(al_mouse_button_down));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_set_mouse_xy(IntPtr display, int x, int y);

    public static al_set_mouse_xy AlSetMouseXY =
        NativeInterop.LoadFunction<al_set_mouse_xy>(_allegroLibrary, nameof(al_set_mouse_xy));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_set_mouse_z(int z);

    public static al_set_mouse_z AlSetMouseZ =
        NativeInterop.LoadFunction<al_set_mouse_z>(_allegroLibrary, nameof(al_set_mouse_z));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_set_mouse_w(int w);

    public static al_set_mouse_w AlSetMouseW =
        NativeInterop.LoadFunction<al_set_mouse_w>(_allegroLibrary, nameof(al_set_mouse_w));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_set_mouse_axis(int which, int value);

    public static al_set_mouse_axis AlSetMouseAxis =
        NativeInterop.LoadFunction<al_set_mouse_axis>(_allegroLibrary, nameof(al_set_mouse_axis));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_mouse_event_source();

    public static al_get_mouse_event_source AlGetMouseEventSource =
        NativeInterop.LoadFunction<al_get_mouse_event_source>(_allegroLibrary, nameof(al_get_mouse_event_source));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_set_mouse_wheel_precision(int precision);

    public static al_set_mouse_wheel_precision AlSetMouseWheelPrecision =
        NativeInterop.LoadFunction<al_set_mouse_wheel_precision>(_allegroLibrary, nameof(al_set_mouse_wheel_precision));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_mouse_wheel_precision();

    public static al_get_mouse_wheel_precision AlGetMouseWheelPrecision =
        NativeInterop.LoadFunction<al_get_mouse_wheel_precision>(_allegroLibrary, nameof(al_get_mouse_wheel_precision));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_create_mouse_cursor(IntPtr bmp, int x_focus, int y_focus);

    public static al_create_mouse_cursor AlCreateMouseCursor =
        NativeInterop.LoadFunction<al_create_mouse_cursor>(_allegroLibrary, nameof(al_create_mouse_cursor));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_destroy_mouse_cursor(IntPtr cursor);

    public static al_destroy_mouse_cursor AlDestroyMouseCursor =
        NativeInterop.LoadFunction<al_destroy_mouse_cursor>(_allegroLibrary, nameof(al_destroy_mouse_cursor));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_set_mouse_cursor(IntPtr display, IntPtr cursor);

    public static al_set_mouse_cursor AlSetMouseCursor =
        NativeInterop.LoadFunction<al_set_mouse_cursor>(_allegroLibrary, nameof(al_set_mouse_cursor));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_set_system_mouse_cursor(IntPtr display, int cursor_id);

    public static al_set_system_mouse_cursor AlSetSystemMouseCursor =
        NativeInterop.LoadFunction<al_set_system_mouse_cursor>(_allegroLibrary, nameof(al_set_system_mouse_cursor));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_get_mouse_cursor_position(ref int ret_x, ref int ret_y);

    public static al_get_mouse_cursor_position AlGetMouseCursorPosition =
        NativeInterop.LoadFunction<al_get_mouse_cursor_position>(_allegroLibrary, nameof(al_get_mouse_cursor_position));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_hide_mouse_cursor(IntPtr display);

    public static al_hide_mouse_cursor AlHideMouseCursor =
        NativeInterop.LoadFunction<al_hide_mouse_cursor>(_allegroLibrary, nameof(al_hide_mouse_cursor));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_show_mouse_cursor(IntPtr display);

    public static al_show_mouse_cursor AlShowMouseCursor =
        NativeInterop.LoadFunction<al_show_mouse_cursor>(_allegroLibrary, nameof(al_show_mouse_cursor));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_grab_mouse(IntPtr display);

    public static al_grab_mouse AlGrabMouse =
        NativeInterop.LoadFunction<al_grab_mouse>(_allegroLibrary, nameof(al_grab_mouse));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_ungrab_mouse();

    public static al_ungrab_mouse AlUngrabMouse =
        NativeInterop.LoadFunction<al_ungrab_mouse>(_allegroLibrary, nameof(al_ungrab_mouse));

    #endregion Mouse routines

    #region Native dialog routines

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_init_native_dialog_addon();

    public static al_init_native_dialog_addon AlInitNativeDialogAddon =
        NativeInterop.LoadFunction<al_init_native_dialog_addon>(_allegroLibrary, nameof(al_init_native_dialog_addon));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_is_native_dialog_addon_initialized();

    public static al_is_native_dialog_addon_initialized AlIsNativeDialogAddonInitialized =
        NativeInterop.LoadFunction<al_is_native_dialog_addon_initialized>(_allegroLibrary, nameof(al_is_native_dialog_addon_initialized));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_shutdown_native_dialog_addon();

    public static al_shutdown_native_dialog_addon AlShutdownNativeDialogAddon =
        NativeInterop.LoadFunction<al_shutdown_native_dialog_addon>(_allegroLibrary, nameof(al_shutdown_native_dialog_addon));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_create_native_file_dialog(IntPtr initial_path, IntPtr title, IntPtr patterns, int mode);

    public static al_create_native_file_dialog AlCreateNativeFileDialog =
        NativeInterop.LoadFunction<al_create_native_file_dialog>(_allegroLibrary, nameof(al_create_native_file_dialog));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_show_native_file_dialog(IntPtr display, IntPtr dialog);

    public static al_show_native_file_dialog AlShowNativeFileDialog =
        NativeInterop.LoadFunction<al_show_native_file_dialog>(_allegroLibrary, nameof(al_show_native_file_dialog));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_native_file_dialog_count(IntPtr dialog);

    public static al_get_native_file_dialog_count AlGetNativeFileDialogCount =
        NativeInterop.LoadFunction<al_get_native_file_dialog_count>(_allegroLibrary, nameof(al_get_native_file_dialog_count));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_native_file_dialog_path(IntPtr dialog, ulong i);

    public static al_get_native_file_dialog_path AlGetNativeFileDialogPath =
        NativeInterop.LoadFunction<al_get_native_file_dialog_path>(_allegroLibrary, nameof(al_get_native_file_dialog_path));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_destroy_native_file_dialog(IntPtr dialog);

    public static al_destroy_native_file_dialog AlDestroyNativeFileDialog =
        NativeInterop.LoadFunction<al_destroy_native_file_dialog>(_allegroLibrary, nameof(al_destroy_native_file_dialog));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_show_native_message_box(IntPtr display, IntPtr title, IntPtr heading, IntPtr text, IntPtr buttons, int flags);

    public static al_show_native_message_box AlShowNativeMessageBox =
        NativeInterop.LoadFunction<al_show_native_message_box>(_allegroLibrary, nameof(al_show_native_message_box));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_open_native_text_log(IntPtr title, int flags);

    public static al_open_native_text_log AlOpenNativeTextLog =
        NativeInterop.LoadFunction<al_open_native_text_log>(_allegroLibrary, nameof(al_open_native_text_log));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_close_native_text_log(IntPtr textlog);

    public static al_close_native_text_log AlCloseNativeTextLog =
        NativeInterop.LoadFunction<al_close_native_text_log>(_allegroLibrary, nameof(al_close_native_text_log));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_append_native_text_log(IntPtr textlog, IntPtr format);

    public static al_append_native_text_log AlAppendNativeTextLog =
        NativeInterop.LoadFunction<al_append_native_text_log>(_allegroLibrary, nameof(al_append_native_text_log));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_native_text_log_event_source(IntPtr textlog);

    public static al_get_native_text_log_event_source AlGetNativeTextLogEventSource =
        NativeInterop.LoadFunction<al_get_native_text_log_event_source>(_allegroLibrary, nameof(al_get_native_text_log_event_source));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate uint al_get_allegro_native_dialog_version();

    public static al_get_allegro_native_dialog_version AlGetAllegroNativeDialogVersion =
        NativeInterop.LoadFunction<al_get_allegro_native_dialog_version>(_allegroLibrary, nameof(al_get_allegro_native_dialog_version));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_create_menu();

    public static al_create_menu AlCreateMenu =
        NativeInterop.LoadFunction<al_create_menu>(_allegroLibrary, nameof(al_create_menu));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_create_popup_menu();

    public static al_create_popup_menu AlCreatePopupMenu =
        NativeInterop.LoadFunction<al_create_popup_menu>(_allegroLibrary, nameof(al_create_popup_menu));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_build_menu(IntPtr info);

    public static al_build_menu AlBuildMenu =
        NativeInterop.LoadFunction<al_build_menu>(_allegroLibrary, nameof(al_build_menu));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_append_menu_item(IntPtr parent, IntPtr title, ushort id, int flags, IntPtr icon, IntPtr submenu);

    public static al_append_menu_item AlAppendMenuItem =
        NativeInterop.LoadFunction<al_append_menu_item>(_allegroLibrary, nameof(al_append_menu_item));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_insert_menu_item(IntPtr parent, int pos, IntPtr title, ushort id, int flags, IntPtr icon, IntPtr submenu);

    public static al_insert_menu_item AlInsertMenuItem =
        NativeInterop.LoadFunction<al_insert_menu_item>(_allegroLibrary, nameof(al_insert_menu_item));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_remove_menu_item(IntPtr menu, int pos);

    public static al_remove_menu_item AlRemoveMenuItem =
        NativeInterop.LoadFunction<al_remove_menu_item>(_allegroLibrary, nameof(al_remove_menu_item));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_clone_menu(IntPtr menu);

    public static al_clone_menu AlCloneMenu =
        NativeInterop.LoadFunction<al_clone_menu>(_allegroLibrary, nameof(al_clone_menu));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_clone_menu_for_popup(IntPtr menu);

    public static al_clone_menu_for_popup AlCloneMenuForPopup =
        NativeInterop.LoadFunction<al_clone_menu_for_popup>(_allegroLibrary, nameof(al_clone_menu_for_popup));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_destroy_menu(IntPtr menu);

    public static al_destroy_menu AlDestroyMenu =
        NativeInterop.LoadFunction<al_destroy_menu>(_allegroLibrary, nameof(al_destroy_menu));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_menu_item_caption(IntPtr menu, int pos);

    public static al_get_menu_item_caption AlGetMenuItemCaption =
        NativeInterop.LoadFunction<al_get_menu_item_caption>(_allegroLibrary, nameof(al_get_menu_item_caption));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_set_menu_item_caption(IntPtr menu, int pos, IntPtr caption);

    public static al_set_menu_item_caption AlSetMenuItemCaption =
        NativeInterop.LoadFunction<al_set_menu_item_caption>(_allegroLibrary, nameof(al_set_menu_item_caption));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_menu_item_flags(IntPtr menu, int pos);

    public static al_get_menu_item_flags AlGetMenuItemFlags =
        NativeInterop.LoadFunction<al_get_menu_item_flags>(_allegroLibrary, nameof(al_get_menu_item_flags));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_set_menu_item_flags(IntPtr menu, int pos, int flags);

    public static al_set_menu_item_flags AlSetMenuItemFlags =
        NativeInterop.LoadFunction<al_set_menu_item_flags>(_allegroLibrary, nameof(al_set_menu_item_flags));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_menu_item_icon(IntPtr menu, int pos);

    public static al_get_menu_item_icon AlGetMenuItemIcon =
        NativeInterop.LoadFunction<al_get_menu_item_icon>(_allegroLibrary, nameof(al_get_menu_item_icon));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_set_menu_item_icon(IntPtr menu, int pos, IntPtr icon);

    public static al_set_menu_item_icon AlSetMenuItemIcon =
        NativeInterop.LoadFunction<al_set_menu_item_icon>(_allegroLibrary, nameof(al_set_menu_item_icon));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_find_menu(IntPtr haystack, ushort id);

    public static al_find_menu AlFindMenu =
        NativeInterop.LoadFunction<al_find_menu>(_allegroLibrary, nameof(al_find_menu));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_find_menu_item(IntPtr haystack, ushort id, ref IntPtr menu, ref int index);

    public static al_find_menu_item AlFindMenuItem =
        NativeInterop.LoadFunction<al_find_menu_item>(_allegroLibrary, nameof(al_find_menu_item));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_default_menu_event_source();

    public static al_get_default_menu_event_source AlGetDefaultMenuEventSource =
        NativeInterop.LoadFunction<al_get_default_menu_event_source>(_allegroLibrary, nameof(al_get_default_menu_event_source));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_enable_menu_event_source(IntPtr menu);

    public static al_enable_menu_event_source AlEnableMenuEventSource =
        NativeInterop.LoadFunction<al_enable_menu_event_source>(_allegroLibrary, nameof(al_enable_menu_event_source));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_disable_menu_event_source(IntPtr menu);

    public static al_disable_menu_event_source AlDisableMenuEventSource =
        NativeInterop.LoadFunction<al_disable_menu_event_source>(_allegroLibrary, nameof(al_disable_menu_event_source));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_display_menu(IntPtr display);

    public static al_get_display_menu AlGetDisplayMenu =
        NativeInterop.LoadFunction<al_get_display_menu>(_allegroLibrary, nameof(al_get_display_menu));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_set_display_menu(IntPtr display, IntPtr menu);

    public static al_set_display_menu AlSetDisplayMenu =
        NativeInterop.LoadFunction<al_set_display_menu>(_allegroLibrary, nameof(al_set_display_menu));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_popup_menu(IntPtr popup, IntPtr display);

    public static al_popup_menu AlPopupMenu =
        NativeInterop.LoadFunction<al_popup_menu>(_allegroLibrary, nameof(al_popup_menu));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_remove_display_menu(IntPtr display);

    public static al_remove_display_menu AlRemoveDisplayMenu =
        NativeInterop.LoadFunction<al_remove_display_menu>(_allegroLibrary, nameof(al_remove_display_menu));

    #endregion Native dialog routines

    #region Path routines

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_create_path(IntPtr str);

    public static al_create_path AlCreatePath =
        NativeInterop.LoadFunction<al_create_path>(_allegroLibrary, nameof(al_create_path));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_create_path_for_directory(IntPtr str);

    public static al_create_path_for_directory AlCreatePathForDirectory =
        NativeInterop.LoadFunction<al_create_path_for_directory>(_allegroLibrary, nameof(al_create_path_for_directory));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_destroy_path(IntPtr path);

    public static al_destroy_path AlDestroyPath =
        NativeInterop.LoadFunction<al_destroy_path>(_allegroLibrary, nameof(al_destroy_path));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_clone_path(IntPtr path);

    public static al_clone_path AlClonePath =
        NativeInterop.LoadFunction<al_clone_path>(_allegroLibrary, nameof(al_clone_path));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_join_paths(IntPtr path, IntPtr tail);

    public static al_join_paths AlJoinPaths =
        NativeInterop.LoadFunction<al_join_paths>(_allegroLibrary, nameof(al_join_paths));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_rebase_path(IntPtr head, IntPtr tail);

    public static al_rebase_path AlRebasePath =
        NativeInterop.LoadFunction<al_rebase_path>(_allegroLibrary, nameof(al_rebase_path));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_path_drive(IntPtr path);

    public static al_get_path_drive AlGetPathDrive =
        NativeInterop.LoadFunction<al_get_path_drive>(_allegroLibrary, nameof(al_get_path_drive));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_path_num_components(IntPtr path);

    public static al_get_path_num_components AlGetPathNumComponents =
        NativeInterop.LoadFunction<al_get_path_num_components>(_allegroLibrary, nameof(al_get_path_num_components));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_path_component(IntPtr path, int i);

    public static al_get_path_component AlGetPathComponent =
        NativeInterop.LoadFunction<al_get_path_component>(_allegroLibrary, nameof(al_get_path_component));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_path_tail(IntPtr path);

    public static al_get_path_tail AlGetPathTail =
        NativeInterop.LoadFunction<al_get_path_tail>(_allegroLibrary, nameof(al_get_path_tail));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_path_filename(IntPtr path);

    public static al_get_path_filename AlGetPathFilename =
        NativeInterop.LoadFunction<al_get_path_filename>(_allegroLibrary, nameof(al_get_path_filename));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_path_basename(IntPtr path);

    public static al_get_path_basename AlGetPathBasename =
        NativeInterop.LoadFunction<al_get_path_basename>(_allegroLibrary, nameof(al_get_path_basename));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_path_extension(IntPtr path);

    public static al_get_path_extension AlGetPathExtension =
        NativeInterop.LoadFunction<al_get_path_extension>(_allegroLibrary, nameof(al_get_path_extension));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_set_path_drive(IntPtr path, IntPtr drive);

    public static al_set_path_drive AlSetPathDrive =
        NativeInterop.LoadFunction<al_set_path_drive>(_allegroLibrary, nameof(al_set_path_drive));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_append_path_component(IntPtr path, IntPtr s);

    public static al_append_path_component AlAppendPathComponent =
        NativeInterop.LoadFunction<al_append_path_component>(_allegroLibrary, nameof(al_append_path_component));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_insert_path_component(IntPtr path, int i, IntPtr s);

    public static al_insert_path_component AlInsertPathComponent =
        NativeInterop.LoadFunction<al_insert_path_component>(_allegroLibrary, nameof(al_insert_path_component));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_replace_path_component(IntPtr path, int i, IntPtr s);

    public static al_replace_path_component AlReplacePathComponent =
        NativeInterop.LoadFunction<al_replace_path_component>(_allegroLibrary, nameof(al_replace_path_component));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_remove_path_component(IntPtr path, int i);

    public static al_remove_path_component AlRemovePathComponent =
        NativeInterop.LoadFunction<al_remove_path_component>(_allegroLibrary, nameof(al_remove_path_component));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_drop_path_tail(IntPtr path);

    public static al_drop_path_tail AlDropPathTail =
        NativeInterop.LoadFunction<al_drop_path_tail>(_allegroLibrary, nameof(al_drop_path_tail));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_set_path_filename(IntPtr path, IntPtr filename);

    public static al_set_path_filename AlSetPathFilename =
        NativeInterop.LoadFunction<al_set_path_filename>(_allegroLibrary, nameof(al_set_path_filename));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_set_path_extension(IntPtr path, IntPtr extension);

    public static al_set_path_extension AlSetPathExtension =
        NativeInterop.LoadFunction<al_set_path_extension>(_allegroLibrary, nameof(al_set_path_extension));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_path_cstr(IntPtr path, char delim);

    public static al_path_cstr AlPathCstr =
        NativeInterop.LoadFunction<al_path_cstr>(_allegroLibrary, nameof(al_path_cstr));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_path_ustr(IntPtr path, char delim);

    public static al_path_ustr AlPathUstr =
        NativeInterop.LoadFunction<al_path_ustr>(_allegroLibrary, nameof(al_path_ustr));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_make_path_canonical(IntPtr path);

    public static al_make_path_canonical AlMakePathCanonical =
        NativeInterop.LoadFunction<al_make_path_canonical>(_allegroLibrary, nameof(al_make_path_canonical));

    #endregion Path routines

    #region State routines

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_restore_state(ref AllegroState.NativeAllegroState state);

    public static al_restore_state AlRestoreState =
        NativeInterop.LoadFunction<al_restore_state>(_allegroLibrary, nameof(al_restore_state));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_store_state(ref AllegroState.NativeAllegroState state, int flags);

    public static al_store_state AlStoreState =
        NativeInterop.LoadFunction<al_store_state>(_allegroLibrary, nameof(al_store_state));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_errno();

    public static al_get_errno AlGetErrno =
        NativeInterop.LoadFunction<al_get_errno>(_allegroLibrary, nameof(al_get_errno));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_set_errno(int errnum);

    public static al_set_errno AlSetErrno =
        NativeInterop.LoadFunction<al_set_errno>(_allegroLibrary, nameof(al_set_errno));

    #endregion State routines

    #region System routines

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_install_system(int version, AtExitDelegate? atExit);

    public static al_install_system AlInstallSystem =
        NativeInterop.LoadFunction<al_install_system>(_allegroLibrary, nameof(al_install_system));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_uninstall_system();

    public static al_uninstall_system AlUninstallSystem =
        NativeInterop.LoadFunction<al_uninstall_system>(_allegroLibrary, nameof(al_uninstall_system));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_is_system_installed();

    public static al_is_system_installed AlIsSystemInstalled =
        NativeInterop.LoadFunction<al_is_system_installed>(_allegroLibrary, nameof(al_is_system_installed));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate uint al_get_allegro_version();

    public static al_get_allegro_version AlGetAllegroVersion =
        NativeInterop.LoadFunction<al_get_allegro_version>(_allegroLibrary, nameof(al_get_allegro_version));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_standard_path(int id);

    public static al_get_standard_path AlGetStandardPath =
        NativeInterop.LoadFunction<al_get_standard_path>(_allegroLibrary, nameof(al_get_standard_path));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_set_exe_name(IntPtr path);

    public static al_set_exe_name AlSetExeName =
        NativeInterop.LoadFunction<al_set_exe_name>(_allegroLibrary, nameof(al_get_standard_path));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_set_app_name(IntPtr path);

    public static al_set_app_name AlSetAppName =
        NativeInterop.LoadFunction<al_set_app_name>(_allegroLibrary, nameof(al_set_app_name));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_set_org_name(IntPtr path);

    public static al_set_org_name AlSetOrgName =
        NativeInterop.LoadFunction<al_set_org_name>(_allegroLibrary, nameof(al_set_org_name));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_app_name();

    public static al_get_app_name AlGetAppName =
        NativeInterop.LoadFunction<al_get_app_name>(_allegroLibrary, nameof(al_get_app_name));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_org_name();

    public static al_get_org_name AlGetOrgName =
        NativeInterop.LoadFunction<al_get_org_name>(_allegroLibrary, nameof(al_get_org_name));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_system_config();

    public static al_get_system_config AlGetSystemConfig =
        NativeInterop.LoadFunction<al_get_system_config>(_allegroLibrary, nameof(al_get_system_config));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_system_id();

    public static al_get_system_id AlGetSystemID =
        NativeInterop.LoadFunction<al_get_system_id>(_allegroLibrary, nameof(al_get_system_id));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_register_assert_handler(RegisterAssertHandler handler);

    public static al_register_assert_handler AlRegisterAssertHandler =
        NativeInterop.LoadFunction<al_register_assert_handler>(_allegroLibrary, nameof(al_register_assert_handler));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_register_trace_handler(RegisterTraceHandler handler);

    public static al_register_trace_handler AlRegisterTraceHandler =
        NativeInterop.LoadFunction<al_register_trace_handler>(_allegroLibrary, nameof(al_register_trace_handler));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_cpu_count();

    public static al_get_cpu_count AlGetCpuCount =
        NativeInterop.LoadFunction<al_get_cpu_count>(_allegroLibrary, nameof(al_get_cpu_count));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_ram_size();

    public static al_get_ram_size AlGetRamSize =
        NativeInterop.LoadFunction<al_get_ram_size>(_allegroLibrary, nameof(al_get_ram_size));

    #endregion System routines

    #region Thread routines

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_create_thread(ThreadProcess proc, IntPtr arg);

    public static al_create_thread AlCreateThread =
        NativeInterop.LoadFunction<al_create_thread>(_allegroLibrary, nameof(al_create_thread));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_start_thread(IntPtr thread);

    public static al_start_thread AlStartThread =
        NativeInterop.LoadFunction<al_start_thread>(_allegroLibrary, nameof(al_start_thread));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_join_thread(IntPtr thread, ref IntPtr ret_value);

    public static al_join_thread AlJoinThread =
        NativeInterop.LoadFunction<al_join_thread>(_allegroLibrary, nameof(al_join_thread));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_set_thread_should_stop(IntPtr thread);

    public static al_set_thread_should_stop AlSetThreadShouldStop =
        NativeInterop.LoadFunction<al_set_thread_should_stop>(_allegroLibrary, nameof(al_set_thread_should_stop));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_get_thread_should_stop(IntPtr thread);

    public static al_get_thread_should_stop AlGetThreadShouldStop =
        NativeInterop.LoadFunction<al_get_thread_should_stop>(_allegroLibrary, nameof(al_get_thread_should_stop));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_destroy_thread(IntPtr thread);

    public static al_destroy_thread AlDestroyThread =
        NativeInterop.LoadFunction<al_destroy_thread>(_allegroLibrary, nameof(al_destroy_thread));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_run_detached_thread(DetachedThreadProcess proc, IntPtr arg);

    public static al_run_detached_thread AlRunDetachedThread =
        NativeInterop.LoadFunction<al_run_detached_thread>(_allegroLibrary, nameof(al_run_detached_thread));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_create_mutex();

    public static al_create_mutex AlCreateMutex =
        NativeInterop.LoadFunction<al_create_mutex>(_allegroLibrary, nameof(al_create_mutex));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_create_mutex_recursive();

    public static al_create_mutex_recursive AlCreateMutexRecursive =
        NativeInterop.LoadFunction<al_create_mutex_recursive>(_allegroLibrary, nameof(al_create_mutex_recursive));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_lock_mutex(IntPtr mutex);

    public static al_lock_mutex AlLockMutex =
        NativeInterop.LoadFunction<al_lock_mutex>(_allegroLibrary, nameof(al_lock_mutex));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_unlock_mutex(IntPtr mutex);

    public static al_unlock_mutex AlUnlockMutex =
        NativeInterop.LoadFunction<al_unlock_mutex>(_allegroLibrary, nameof(al_unlock_mutex));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_destroy_mutex(IntPtr mutex);

    public static al_destroy_mutex AlDestroyMutex =
        NativeInterop.LoadFunction<al_destroy_mutex>(_allegroLibrary, nameof(al_destroy_mutex));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_create_cond();

    public static al_create_cond AlCreateCond =
        NativeInterop.LoadFunction<al_create_cond>(_allegroLibrary, nameof(al_create_cond));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_destroy_cond(IntPtr cond);

    public static al_destroy_cond AlDestroyCond =
        NativeInterop.LoadFunction<al_destroy_cond>(_allegroLibrary, nameof(al_destroy_cond));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_wait_cond(IntPtr cond, IntPtr mutex);

    public static al_wait_cond AlWaitCond =
        NativeInterop.LoadFunction<al_wait_cond>(_allegroLibrary, nameof(al_wait_cond));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_wait_cond_until(IntPtr cond, IntPtr mutex, ref AllegroTimeout.NativeAllegroTimeout timeout);

    public static al_wait_cond_until AlWaitCondUntil =
        NativeInterop.LoadFunction<al_wait_cond_until>(_allegroLibrary, nameof(al_wait_cond_until));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_broadcast_cond(IntPtr cond);

    public static al_broadcast_cond AlBroadcastCond =
        NativeInterop.LoadFunction<al_broadcast_cond>(_allegroLibrary, nameof(al_broadcast_cond));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_signal_cond(IntPtr cond);

    public static al_signal_cond AlSignalCond =
        NativeInterop.LoadFunction<al_signal_cond>(_allegroLibrary, nameof(al_signal_cond));

    #endregion Thread routines

    #region Time routines

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate double al_get_time();

    public static al_get_time AlGetTime =
        NativeInterop.LoadFunction<al_get_time>(_allegroLibrary, nameof(al_get_time));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_init_timeout(ref AllegroTimeout.NativeAllegroTimeout timeout, double seconds);

    public static al_init_timeout AlInitTimeout =
        NativeInterop.LoadFunction<al_init_timeout>(_allegroLibrary, nameof(al_init_timeout));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_rest(double seconds);

    public static al_rest AlRest =
        NativeInterop.LoadFunction<al_rest>(_allegroLibrary, nameof(al_rest));

    #endregion Time routines

    #region Timer routines

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_create_timer(double speed_secs);

    public static al_create_timer ALCreateTimer =
        NativeInterop.LoadFunction<al_create_timer>(_allegroLibrary, nameof(al_create_timer));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_start_timer(IntPtr timer);

    public static al_start_timer AlStartTimer =
        NativeInterop.LoadFunction<al_start_timer>(_allegroLibrary, nameof(al_start_timer));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_resume_timer(IntPtr timer);

    public static al_resume_timer AlResumeTimer =
        NativeInterop.LoadFunction<al_resume_timer>(_allegroLibrary, nameof(al_resume_timer));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_stop_timer(IntPtr timer);

    public static al_stop_timer AlStopTimer =
        NativeInterop.LoadFunction<al_stop_timer>(_allegroLibrary, nameof(al_stop_timer));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_get_timer_started(IntPtr timer);

    public static al_get_timer_started AlGetTimerStarted =
        NativeInterop.LoadFunction<al_get_timer_started>(_allegroLibrary, nameof(al_get_timer_started));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_destroy_timer(IntPtr timer);

    public static al_destroy_timer AlDestroyTimer =
        NativeInterop.LoadFunction<al_destroy_timer>(_allegroLibrary, nameof(al_destroy_timer));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate ulong al_get_timer_count(IntPtr timer);

    public static al_get_timer_count AlGetTimerCount =
        NativeInterop.LoadFunction<al_get_timer_count>(_allegroLibrary, nameof(al_get_timer_count));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_set_timer_count(IntPtr timer, ulong new_count);

    public static al_set_timer_count AlSetTimerCount =
        NativeInterop.LoadFunction<al_set_timer_count>(_allegroLibrary, nameof(al_set_timer_count));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_add_timer_count(IntPtr timer, ulong diff);

    public static al_add_timer_count AlAddTimerCount =
        NativeInterop.LoadFunction<al_add_timer_count>(_allegroLibrary, nameof(al_add_timer_count));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate double al_get_timer_speed(IntPtr timer);

    public static al_get_timer_speed AlGetTimerSpeed =
        NativeInterop.LoadFunction<al_get_timer_speed>(_allegroLibrary, nameof(al_get_timer_speed));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_set_timer_speed(IntPtr timer, double new_speed_secs);

    public static al_set_timer_speed AlSetTimerSpeed =
        NativeInterop.LoadFunction<al_set_timer_speed>(_allegroLibrary, nameof(al_set_timer_speed));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_timer_event_source(IntPtr timer);

    public static al_get_timer_event_source AlGetTimerEventSource =
        NativeInterop.LoadFunction<al_get_timer_event_source>(_allegroLibrary, nameof(al_get_timer_event_source));

    #endregion Timer routines

    #region Transform routines

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_copy_transform(ref AllegroTransform.NativeAllegroTransform dest, ref AllegroTransform.NativeAllegroTransform src);

    public static al_copy_transform AlCopyTransform =
        NativeInterop.LoadFunction<al_copy_transform>(_allegroLibrary, nameof(al_copy_transform));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_use_transform(ref AllegroTransform.NativeAllegroTransform trans);

    public static al_use_transform AlUseTransform =
        NativeInterop.LoadFunction<al_use_transform>(_allegroLibrary, nameof(al_use_transform));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_current_transform();

    public static al_get_current_transform AlGetCurrentTransform =
        NativeInterop.LoadFunction<al_get_current_transform>(_allegroLibrary, nameof(al_get_current_transform));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_use_projection_transform(ref AllegroTransform.NativeAllegroTransform trans);

    public static al_use_projection_transform AlUseProjectionTransform =
        NativeInterop.LoadFunction<al_use_projection_transform>(_allegroLibrary, nameof(al_use_projection_transform));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_current_projection_transform();

    public static al_get_current_projection_transform AlGetCurrentProjectionTransform =
        NativeInterop.LoadFunction<al_get_current_projection_transform>(_allegroLibrary, nameof(al_get_current_projection_transform));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_current_inverse_transform();

    public static al_get_current_inverse_transform AlGetCurrentInverseTransform =
        NativeInterop.LoadFunction<al_get_current_inverse_transform>(_allegroLibrary, nameof(al_get_current_inverse_transform));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_invert_transform(ref AllegroTransform.NativeAllegroTransform trans);

    public static al_invert_transform AlInvertTransform =
        NativeInterop.LoadFunction<al_invert_transform>(_allegroLibrary, nameof(al_invert_transform));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_transpose_transform(ref AllegroTransform.NativeAllegroTransform trans);

    public static al_transpose_transform AlTransposeTransform =
        NativeInterop.LoadFunction<al_transpose_transform>(_allegroLibrary, nameof(al_transpose_transform));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_check_inverse(ref AllegroTransform.NativeAllegroTransform trans, float tol);

    public static al_check_inverse AlCheckInverse =
        NativeInterop.LoadFunction<al_check_inverse>(_allegroLibrary, nameof(al_check_inverse));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_identity_transform(ref AllegroTransform.NativeAllegroTransform trans);

    public static al_identity_transform AlIdentityTransform =
        NativeInterop.LoadFunction<al_identity_transform>(_allegroLibrary, nameof(al_identity_transform));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_build_transform(ref AllegroTransform.NativeAllegroTransform trans, float x, float y, float sx, float sy, float theta);

    public static al_build_transform AlBuildTransform =
        NativeInterop.LoadFunction<al_build_transform>(_allegroLibrary, nameof(al_build_transform));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_build_camera_transform(
        ref AllegroTransform.NativeAllegroTransform trans,
        float position_x,
        float position_y,
        float position_z,
        float look_x,
        float look_y,
        float look_z,
        float up_x,
        float up_y,
        float up_z);

    public static al_build_camera_transform AlBuildCameraTransform =
        NativeInterop.LoadFunction<al_build_camera_transform>(_allegroLibrary, nameof(al_build_camera_transform));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_translate_transform(ref AllegroTransform.NativeAllegroTransform trans, float x, float y);

    public static al_translate_transform AlTranslateTransform =
        NativeInterop.LoadFunction<al_translate_transform>(_allegroLibrary, nameof(al_translate_transform));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_rotate_transform(ref AllegroTransform.NativeAllegroTransform trans, float theta);

    public static al_rotate_transform AlRotateTransform =
        NativeInterop.LoadFunction<al_rotate_transform>(_allegroLibrary, nameof(al_rotate_transform));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_scale_transform(ref AllegroTransform.NativeAllegroTransform trans, float sx, float sy);

    public static al_scale_transform AlScaleTransform =
        NativeInterop.LoadFunction<al_scale_transform>(_allegroLibrary, nameof(al_scale_transform));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_transform_coordinates(ref AllegroTransform.NativeAllegroTransform trans, ref float x, ref float y);

    public static al_transform_coordinates AlTransformCoordinates =
        NativeInterop.LoadFunction<al_transform_coordinates>(_allegroLibrary, nameof(al_transform_coordinates));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_transform_coordinates_3d(ref AllegroTransform.NativeAllegroTransform trans, ref float x, ref float y, ref float z);

    public static al_transform_coordinates_3d AlTransformCoordinates3D =
        NativeInterop.LoadFunction<al_transform_coordinates_3d>(_allegroLibrary, nameof(al_transform_coordinates_3d));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_transform_coordinates_4d(ref AllegroTransform.NativeAllegroTransform trans, ref float x, ref float y, ref float z, ref float w);

    public static al_transform_coordinates_4d AlTransformCoordinates4D =
        NativeInterop.LoadFunction<al_transform_coordinates_4d>(_allegroLibrary, nameof(al_transform_coordinates_4d));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_transform_coordinates_3d_projective(ref AllegroTransform.NativeAllegroTransform trans, ref float x, ref float y, ref float z);

    public static al_transform_coordinates_3d_projective AlTransformCoordinates3DProjective =
        NativeInterop.LoadFunction<al_transform_coordinates_3d_projective>(_allegroLibrary, nameof(al_transform_coordinates_3d_projective));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_compose_transform(ref AllegroTransform.NativeAllegroTransform trans, ref AllegroTransform.NativeAllegroTransform other);

    public static al_compose_transform AlComposeTransform =
        NativeInterop.LoadFunction<al_compose_transform>(_allegroLibrary, nameof(al_compose_transform));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_orthographic_transform(
        ref AllegroTransform.NativeAllegroTransform trans,
        float left,
        float top,
        float n,
        float right,
        float bottom,
        float f);

    public static al_orthographic_transform AlOrthographicTransform =
        NativeInterop.LoadFunction<al_orthographic_transform>(_allegroLibrary, nameof(al_orthographic_transform));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_perspective_transform(
        ref AllegroTransform.NativeAllegroTransform trans,
        float left,
        float top,
        float n,
        float right,
        float bottom,
        float f);

    public static al_perspective_transform AlPerspectiveTransform =
        NativeInterop.LoadFunction<al_perspective_transform>(_allegroLibrary, nameof(al_perspective_transform));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_translate_transform_3d(ref AllegroTransform.NativeAllegroTransform trans, float x, float y, float z);

    public static al_translate_transform_3d AlTranslateTransform3D =
        NativeInterop.LoadFunction<al_translate_transform_3d>(_allegroLibrary, nameof(al_translate_transform_3d));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_scale_transform_3d(ref AllegroTransform.NativeAllegroTransform trans, float sx, float sy, float sz);

    public static al_scale_transform_3d AlScaleTransform3D =
        NativeInterop.LoadFunction<al_scale_transform_3d>(_allegroLibrary, nameof(al_scale_transform_3d));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_rotate_transform_3d(ref AllegroTransform.NativeAllegroTransform trans, float x, float y, float z, float angle);

    public static al_rotate_transform_3d AlRotateTransform3D =
        NativeInterop.LoadFunction<al_rotate_transform_3d>(_allegroLibrary, nameof(al_rotate_transform_3d));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_horizontal_shear_transform(ref AllegroTransform.NativeAllegroTransform trans, float theta);

    public static al_horizontal_shear_transform AlHorizontalShearTransform =
        NativeInterop.LoadFunction<al_horizontal_shear_transform>(_allegroLibrary, nameof(al_horizontal_shear_transform));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_vertical_shear_transform(ref AllegroTransform.NativeAllegroTransform trans, float theta);

    public static al_vertical_shear_transform AlVerticalShearTransform =
        NativeInterop.LoadFunction<al_vertical_shear_transform>(_allegroLibrary, nameof(al_vertical_shear_transform));

    #endregion Transform routines
  }
}