using SubC.AllegroDotNet.Models;
using System;
using System.Runtime.InteropServices;
using static SubC.AllegroDotNet.Native.NativeDelegates;

namespace SubC.AllegroDotNet.Native
{
  internal static class NativeFunctions
  {
    public static IntPtr AllegroLibrary { get; } = NativeInterop.LoadAllegroLibrary();

    #region Audio codecs routines

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_init_acodec_addon();

    public static al_init_acodec_addon AlInitAcodecAddon =
        NativeInterop.LoadFunction<al_init_acodec_addon>(AllegroLibrary, nameof(al_init_acodec_addon));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_is_acodec_addon_initialized();

    public static al_is_acodec_addon_initialized AlIsAcodecAddonInitialized =
        NativeInterop.LoadFunction<al_is_acodec_addon_initialized>(AllegroLibrary, nameof(al_is_acodec_addon_initialized));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate uint al_get_allegro_acodec_version();

    public static al_get_allegro_acodec_version AlGetAllegroAcodecVersion =
        NativeInterop.LoadFunction<al_get_allegro_acodec_version>(AllegroLibrary, nameof(al_get_allegro_acodec_version));

    #endregion

    #region Audio routines

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_install_audio();

    public static al_install_audio AlInstallAudio =
        NativeInterop.LoadFunction<al_install_audio>(AllegroLibrary, nameof(al_install_audio));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_uninstall_audio();

    public static al_uninstall_audio AlUninstallAudio =
        NativeInterop.LoadFunction<al_uninstall_audio>(AllegroLibrary, nameof(al_uninstall_audio));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_is_audio_installed();

    public static al_is_audio_installed AlIsAudioInstalled =
        NativeInterop.LoadFunction<al_is_audio_installed>(AllegroLibrary, nameof(al_is_audio_installed));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_reserve_samples(int reserve_samples);

    public static al_reserve_samples AlReserveSamples =
        NativeInterop.LoadFunction<al_reserve_samples>(AllegroLibrary, nameof(al_reserve_samples));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate uint al_get_allegro_audio_version();

    public static al_get_allegro_audio_version AlGetAllegroAudioVersion =
        NativeInterop.LoadFunction<al_get_allegro_audio_version>(AllegroLibrary, nameof(al_get_allegro_audio_version));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate long al_get_audio_depth_size(int depth);

    public static al_get_audio_depth_size AlGetAudioDepthSize =
        NativeInterop.LoadFunction<al_get_audio_depth_size>(AllegroLibrary, nameof(al_get_audio_depth_size));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate long al_get_channel_count(int conf);

    public static al_get_channel_count AlGetChannelCount =
        NativeInterop.LoadFunction<al_get_channel_count>(AllegroLibrary, nameof(al_get_channel_count));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_fill_silence(IntPtr buf, uint samples, int depth, int chan_conf);

    public static al_fill_silence AlFillSilence =
        NativeInterop.LoadFunction<al_fill_silence>(AllegroLibrary, nameof(al_fill_silence));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_create_voice(uint freq, int depth, int chan_conf);

    public static al_create_voice AlCreateVoice =
        NativeInterop.LoadFunction<al_create_voice>(AllegroLibrary, nameof(al_create_voice));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_destroy_voice(IntPtr voice);

    public static al_destroy_voice AlDestroyVoice =
        NativeInterop.LoadFunction<al_destroy_voice>(AllegroLibrary, nameof(al_destroy_voice));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_detach_voice(IntPtr voice);

    public static al_detach_voice AlDetachVoice =
        NativeInterop.LoadFunction<al_detach_voice>(AllegroLibrary, nameof(al_detach_voice));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_attach_audio_stream_to_voice(IntPtr stream, IntPtr voice);

    public static al_attach_audio_stream_to_voice AlAttachAudioStreamToVoice =
        NativeInterop.LoadFunction<al_attach_audio_stream_to_voice>(AllegroLibrary, nameof(al_attach_audio_stream_to_voice));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_attach_mixer_to_voice(IntPtr mixer, IntPtr voice);

    public static al_attach_mixer_to_voice AlAttachMixerToVoice =
        NativeInterop.LoadFunction<al_attach_mixer_to_voice>(AllegroLibrary, nameof(al_attach_mixer_to_voice));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_attach_sample_instance_to_voice(IntPtr spl, IntPtr voice);

    public static al_attach_sample_instance_to_voice AlAttachSampleInstanceToVoice =
        NativeInterop.LoadFunction<al_attach_sample_instance_to_voice>(AllegroLibrary, nameof(al_attach_sample_instance_to_voice));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate uint al_get_voice_frequency(IntPtr voice);

    public static al_get_voice_frequency AlGetVoiceFrequency =
        NativeInterop.LoadFunction<al_get_voice_frequency>(AllegroLibrary, nameof(al_get_voice_frequency));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_voice_channels(IntPtr voice);

    public static al_get_voice_channels AlGetVoiceChannels =
        NativeInterop.LoadFunction<al_get_voice_channels>(AllegroLibrary, nameof(al_get_voice_channels));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_voice_depth(IntPtr voice);

    public static al_get_voice_depth AlGetVoiceDepth =
        NativeInterop.LoadFunction<al_get_voice_depth>(AllegroLibrary, nameof(al_get_voice_depth));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_get_voice_playing(IntPtr voice);

    public static al_get_voice_playing AlGetVoicePlaying =
        NativeInterop.LoadFunction<al_get_voice_playing>(AllegroLibrary, nameof(al_get_voice_playing));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_set_voice_playing(IntPtr voice, [MarshalAs(UnmanagedType.U1)] bool val);

    public static al_set_voice_playing AlSetVoicePlaying =
        NativeInterop.LoadFunction<al_set_voice_playing>(AllegroLibrary, nameof(al_set_voice_playing));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate uint al_get_voice_position(IntPtr voice);

    public static al_get_voice_position AlGetVoicePosition =
        NativeInterop.LoadFunction<al_get_voice_position>(AllegroLibrary, nameof(al_get_voice_position));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_set_voice_position(IntPtr voice, uint val);

    public static al_set_voice_position AlSetVoicePosition =
        NativeInterop.LoadFunction<al_set_voice_position>(AllegroLibrary, nameof(al_set_voice_position));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_create_sample(IntPtr buf, uint samples, uint freq, int depth, int chan_conf, [MarshalAs(UnmanagedType.U1)] bool free_buf);

    public static al_create_sample AlCreateSample =
        NativeInterop.LoadFunction<al_create_sample>(AllegroLibrary, nameof(al_create_sample));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_destroy_sample(IntPtr spl);

    public static al_destroy_sample AlDestroySample =
        NativeInterop.LoadFunction<al_destroy_sample>(AllegroLibrary, nameof(al_destroy_sample));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_play_sample(IntPtr spl, float gain, float pan, float speed, int loop, IntPtr ret_id);

    public static al_play_sample AlPlaySample =
        NativeInterop.LoadFunction<al_play_sample>(AllegroLibrary, nameof(al_play_sample));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_stop_sample(IntPtr spl_id);

    public static al_stop_sample AlStopSample =
        NativeInterop.LoadFunction<al_stop_sample>(AllegroLibrary, nameof(al_stop_sample));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_stop_samples();

    public static al_stop_samples AlStopSamples =
        NativeInterop.LoadFunction<al_stop_samples>(AllegroLibrary, nameof(al_stop_samples));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_sample_channels(IntPtr spl);

    public static al_get_sample_channels AlGetSampleChannels =
        NativeInterop.LoadFunction<al_get_sample_channels>(AllegroLibrary, nameof(al_get_sample_channels));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_sample_depth(IntPtr spl);

    public static al_get_sample_depth AlGetSampleDepth =
        NativeInterop.LoadFunction<al_get_sample_depth>(AllegroLibrary, nameof(al_get_sample_depth));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate uint al_get_sample_frequency(IntPtr spl);

    public static al_get_sample_frequency AlGetSampleFrequency =
        NativeInterop.LoadFunction<al_get_sample_frequency>(AllegroLibrary, nameof(al_get_sample_frequency));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate uint al_get_sample_length(IntPtr spl);

    public static al_get_sample_length AlGetSampleLength =
        NativeInterop.LoadFunction<al_get_sample_length>(AllegroLibrary, nameof(al_get_sample_length));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_sample_data(IntPtr spl);

    public static al_get_sample_data AlGetSampleData =
        NativeInterop.LoadFunction<al_get_sample_data>(AllegroLibrary, nameof(al_get_sample_data));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_create_sample_instance(IntPtr sample_data);

    public static al_create_sample_instance AlCreateSampleInstance =
        NativeInterop.LoadFunction<al_create_sample_instance>(AllegroLibrary, nameof(al_create_sample_instance));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_destroy_sample_instance(IntPtr spl);

    public static al_destroy_sample_instance AlDestroySampleInstance =
        NativeInterop.LoadFunction<al_destroy_sample_instance>(AllegroLibrary, nameof(al_destroy_sample_instance));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_play_sample_instance(IntPtr spl);

    public static al_play_sample_instance AlPlaySampleInstance =
        NativeInterop.LoadFunction<al_play_sample_instance>(AllegroLibrary, nameof(al_play_sample_instance));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_stop_sample_instance(IntPtr spl);

    public static al_stop_sample_instance AlStopSampleInstance =
        NativeInterop.LoadFunction<al_stop_sample_instance>(AllegroLibrary, nameof(al_stop_sample_instance));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_sample_instance_channels(IntPtr spl);

    public static al_get_sample_instance_channels AlGetSampleInstanceChannels =
        NativeInterop.LoadFunction<al_get_sample_instance_channels>(AllegroLibrary, nameof(al_get_sample_instance_channels));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_sample_instance_depth(IntPtr spl);

    public static al_get_sample_instance_depth AlGetSampleInstanceDepth =
        NativeInterop.LoadFunction<al_get_sample_instance_depth>(AllegroLibrary, nameof(al_get_sample_instance_depth));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate uint al_get_sample_instance_frequency(IntPtr spl);

    public static al_get_sample_instance_frequency AlGetSampleInstanceFrequency =
        NativeInterop.LoadFunction<al_get_sample_instance_frequency>(AllegroLibrary, nameof(al_get_sample_instance_frequency));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate uint al_get_sample_instance_length(IntPtr spl);

    public static al_get_sample_instance_length AlGetSampleInstanceLength =
        NativeInterop.LoadFunction<al_get_sample_instance_length>(AllegroLibrary, nameof(al_get_sample_instance_length));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_set_sample_instance_length(IntPtr spl, uint val);

    public static al_set_sample_instance_length AlSetSampleInstanceLength =
        NativeInterop.LoadFunction<al_set_sample_instance_length>(AllegroLibrary, nameof(al_set_sample_instance_length));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate uint al_get_sample_instance_position(IntPtr spl);

    public static al_get_sample_instance_position AlGetSampleInstancePosition =
        NativeInterop.LoadFunction<al_get_sample_instance_position>(AllegroLibrary, nameof(al_get_sample_instance_position));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_set_sample_instance_position(IntPtr spl, uint val);

    public static al_set_sample_instance_position AlSetSampleInstancePosition =
        NativeInterop.LoadFunction<al_set_sample_instance_position>(AllegroLibrary, nameof(al_set_sample_instance_position));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate float al_get_sample_instance_speed(IntPtr spl);

    public static al_get_sample_instance_speed AlGetSampleInstanceSpeed =
        NativeInterop.LoadFunction<al_get_sample_instance_speed>(AllegroLibrary, nameof(al_get_sample_instance_speed));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_set_sample_instance_speed(IntPtr spl, float val);

    public static al_set_sample_instance_speed AlSetSampleInstanceSpeed =
        NativeInterop.LoadFunction<al_set_sample_instance_speed>(AllegroLibrary, nameof(al_set_sample_instance_speed));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate float al_get_sample_instance_gain(IntPtr spl);

    public static al_get_sample_instance_gain AlGetSampleInstanceGain =
        NativeInterop.LoadFunction<al_get_sample_instance_gain>(AllegroLibrary, nameof(al_get_sample_instance_gain));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_set_sample_instance_gain(IntPtr spl, float val);

    public static al_set_sample_instance_gain AlSetSampleInstanceGain =
        NativeInterop.LoadFunction<al_set_sample_instance_gain>(AllegroLibrary, nameof(al_set_sample_instance_gain));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate float al_get_sample_instance_pan(IntPtr spl);

    public static al_get_sample_instance_pan AlGetSampleInstancePan =
        NativeInterop.LoadFunction<al_get_sample_instance_pan>(AllegroLibrary, nameof(al_get_sample_instance_pan));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_set_sample_instance_pan(IntPtr spl, float val);

    public static al_set_sample_instance_pan AlSetSampleInstancePan =
        NativeInterop.LoadFunction<al_set_sample_instance_pan>(AllegroLibrary, nameof(al_set_sample_instance_pan));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate float al_get_sample_instance_time(IntPtr spl);

    public static al_get_sample_instance_time AlGetSampleInstanceTime =
        NativeInterop.LoadFunction<al_get_sample_instance_time>(AllegroLibrary, nameof(al_get_sample_instance_time));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_sample_instance_playmode(IntPtr spl);

    public static al_get_sample_instance_playmode AlGetSampleInstancePlaymode =
        NativeInterop.LoadFunction<al_get_sample_instance_playmode>(AllegroLibrary, nameof(al_get_sample_instance_playmode));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_set_sample_instance_playmode(IntPtr spl, int val);

    public static al_set_sample_instance_playmode AlSetSampleInstancePlaymode =
        NativeInterop.LoadFunction<al_set_sample_instance_playmode>(AllegroLibrary, nameof(al_set_sample_instance_playmode));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_get_sample_instance_playing(IntPtr spl);

    public static al_get_sample_instance_playing AlGetSampleInstancePlaying =
        NativeInterop.LoadFunction<al_get_sample_instance_playing>(AllegroLibrary, nameof(al_get_sample_instance_playing));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_set_sample_instance_playing(IntPtr spl, [MarshalAs(UnmanagedType.U1)] bool val);

    public static al_set_sample_instance_playing AlSetSampleInstancePlaying =
        NativeInterop.LoadFunction<al_set_sample_instance_playing>(AllegroLibrary, nameof(al_set_sample_instance_playing));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_get_sample_instance_attached(IntPtr spl);

    public static al_get_sample_instance_attached AlGetSampleInstanceAttached =
        NativeInterop.LoadFunction<al_get_sample_instance_attached>(AllegroLibrary, nameof(al_get_sample_instance_attached));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_detach_sample_instance(IntPtr spl);

    public static al_detach_sample_instance AlDetachSampleInstance =
        NativeInterop.LoadFunction<al_detach_sample_instance>(AllegroLibrary, nameof(al_detach_sample_instance));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_sample(IntPtr spl);

    public static al_get_sample AlGetSample =
        NativeInterop.LoadFunction<al_get_sample>(AllegroLibrary, nameof(al_get_sample));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_set_sample(IntPtr spl, IntPtr data);

    public static al_set_sample AlSetSample =
        NativeInterop.LoadFunction<al_set_sample>(AllegroLibrary, nameof(al_set_sample));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_create_mixer(uint freq, int depth, int chan_conf);

    public static al_create_mixer AlCreateMixer =
        NativeInterop.LoadFunction<al_create_mixer>(AllegroLibrary, nameof(al_create_mixer));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_destroy_mixer(IntPtr mixer);

    public static al_destroy_mixer AlDestroyMixer =
        NativeInterop.LoadFunction<al_destroy_mixer>(AllegroLibrary, nameof(al_destroy_mixer));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_default_mixer();

    public static al_get_default_mixer AlGetDefaultMixer =
        NativeInterop.LoadFunction<al_get_default_mixer>(AllegroLibrary, nameof(al_get_default_mixer));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_set_default_mixer(IntPtr mixer);

    public static al_set_default_mixer AlSetDefaultMixer =
        NativeInterop.LoadFunction<al_set_default_mixer>(AllegroLibrary, nameof(al_set_default_mixer));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_restore_default_mixer();

    public static al_restore_default_mixer AlRestoreDefaultMixer =
        NativeInterop.LoadFunction<al_restore_default_mixer>(AllegroLibrary, nameof(al_restore_default_mixer));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_default_voice();

    public static al_get_default_voice AlGetDefaultVoice =
        NativeInterop.LoadFunction<al_get_default_voice>(AllegroLibrary, nameof(al_get_default_voice));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_set_default_voice(IntPtr voice);

    public static al_set_default_voice AlSetDefaultVoice =
        NativeInterop.LoadFunction<al_set_default_voice>(AllegroLibrary, nameof(al_set_default_voice));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_attach_mixer_to_mixer(IntPtr stream, IntPtr mixer);

    public static al_attach_mixer_to_mixer AlAttachMixerToMixer =
        NativeInterop.LoadFunction<al_attach_mixer_to_mixer>(AllegroLibrary, nameof(al_attach_mixer_to_mixer));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_attach_sample_instance_to_mixer(IntPtr spl, IntPtr mixer);

    public static al_attach_sample_instance_to_mixer AlAttachSampleInstanceToMixer =
        NativeInterop.LoadFunction<al_attach_sample_instance_to_mixer>(AllegroLibrary, nameof(al_attach_sample_instance_to_mixer));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_attach_audio_stream_to_mixer(IntPtr stream, IntPtr mixer);

    public static al_attach_audio_stream_to_mixer AlAttachAudioStreamToMixer =
        NativeInterop.LoadFunction<al_attach_audio_stream_to_mixer>(AllegroLibrary, nameof(al_attach_audio_stream_to_mixer));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate uint al_get_mixer_frequency(IntPtr mixer);

    public static al_get_mixer_frequency AlGetMixerFrequency =
        NativeInterop.LoadFunction<al_get_mixer_frequency>(AllegroLibrary, nameof(al_get_mixer_frequency));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_set_mixer_frequency(IntPtr mixer, uint val);

    public static al_set_mixer_frequency AlSetMixerFrequency =
        NativeInterop.LoadFunction<al_set_mixer_frequency>(AllegroLibrary, nameof(al_set_mixer_frequency));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_mixer_channels(IntPtr mixer);

    public static al_get_mixer_channels AlGetMixerChannels =
        NativeInterop.LoadFunction<al_get_mixer_channels>(AllegroLibrary, nameof(al_get_mixer_channels));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_mixer_depth(IntPtr mixer);

    public static al_get_mixer_depth AlGetMixerDepth =
        NativeInterop.LoadFunction<al_get_mixer_depth>(AllegroLibrary, nameof(al_get_mixer_depth));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate float al_get_mixer_gain(IntPtr mixer);

    public static al_get_mixer_gain AlGetMixerGain =
        NativeInterop.LoadFunction<al_get_mixer_gain>(AllegroLibrary, nameof(al_get_mixer_gain));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_set_mixer_gain(IntPtr mixer, float new_gain);

    public static al_set_mixer_gain AlSetMixerGain =
        NativeInterop.LoadFunction<al_set_mixer_gain>(AllegroLibrary, nameof(al_set_mixer_gain));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_mixer_quality(IntPtr mixer);

    public static al_get_mixer_quality AlGetMixerQuality =
        NativeInterop.LoadFunction<al_get_mixer_quality>(AllegroLibrary, nameof(al_get_mixer_quality));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_set_mixer_quality(IntPtr mixer, int new_quality);

    public static al_set_mixer_quality AlSetMixerQuality =
        NativeInterop.LoadFunction<al_set_mixer_quality>(AllegroLibrary, nameof(al_set_mixer_quality));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_get_mixer_playing(IntPtr mixer);

    public static al_get_mixer_playing AlGetMixerPlaying =
        NativeInterop.LoadFunction<al_get_mixer_playing>(AllegroLibrary, nameof(al_get_mixer_playing));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_set_mixer_playing(IntPtr mixer, [MarshalAs(UnmanagedType.U1)] bool val);

    public static al_set_mixer_playing AlSetMixerPlaying =
        NativeInterop.LoadFunction<al_set_mixer_playing>(AllegroLibrary, nameof(al_set_mixer_playing));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_get_mixer_attached(IntPtr mixer);

    public static al_get_mixer_attached AlGetMixerAttached =
        NativeInterop.LoadFunction<al_get_mixer_attached>(AllegroLibrary, nameof(al_get_mixer_attached));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_detach_mixer(IntPtr mixer);

    public static al_detach_mixer AlDetachMixer =
        NativeInterop.LoadFunction<al_detach_mixer>(AllegroLibrary, nameof(al_detach_mixer));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_set_mixer_postprocess_callback(IntPtr mixer, MixerPostprocessCallback pp_callback, IntPtr pp_callback_userdata);

    public static al_set_mixer_postprocess_callback AlSetMixerPostprocessCallback =
        NativeInterop.LoadFunction<al_set_mixer_postprocess_callback>(AllegroLibrary, nameof(al_set_mixer_postprocess_callback));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_create_audio_stream(long fragment_count, uint frag_samples, uint freq, int depth, int chan_conf);

    public static al_create_audio_stream AlCreateAudioStream =
        NativeInterop.LoadFunction<al_create_audio_stream>(AllegroLibrary, nameof(al_create_audio_stream));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_destroy_audio_stream(IntPtr stream);

    public static al_destroy_audio_stream AlDestroyAudioStream =
        NativeInterop.LoadFunction<al_destroy_audio_stream>(AllegroLibrary, nameof(al_destroy_audio_stream));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_audio_stream_event_source(IntPtr stream);

    public static al_get_audio_stream_event_source AlGetAudioStreamEventSource =
        NativeInterop.LoadFunction<al_get_audio_stream_event_source>(AllegroLibrary, nameof(al_get_audio_stream_event_source));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_drain_audio_stream(IntPtr stream);

    public static al_drain_audio_stream AlDrainAudioStream =
        NativeInterop.LoadFunction<al_drain_audio_stream>(AllegroLibrary, nameof(al_drain_audio_stream));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_rewind_audio_stream(IntPtr stream);

    public static al_rewind_audio_stream AlRewindAudioStream =
        NativeInterop.LoadFunction<al_rewind_audio_stream>(AllegroLibrary, nameof(al_rewind_audio_stream));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate uint al_get_audio_stream_frequency(IntPtr stream);

    public static al_get_audio_stream_frequency AlGetAudioStreamFrequency =
        NativeInterop.LoadFunction<al_get_audio_stream_frequency>(AllegroLibrary, nameof(al_get_audio_stream_frequency));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_audio_stream_channels(IntPtr stream);

    public static al_get_audio_stream_channels AlGetAudioStreamChannels =
        NativeInterop.LoadFunction<al_get_audio_stream_channels>(AllegroLibrary, nameof(al_get_audio_stream_channels));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_audio_stream_depth(IntPtr stream);

    public static al_get_audio_stream_depth AlGetAudioStreamDepth =
        NativeInterop.LoadFunction<al_get_audio_stream_depth>(AllegroLibrary, nameof(al_get_audio_stream_depth));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate uint al_get_audio_stream_length(IntPtr stream);

    public static al_get_audio_stream_length AlGetAudioStreamLength =
        NativeInterop.LoadFunction<al_get_audio_stream_length>(AllegroLibrary, nameof(al_get_audio_stream_length));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate float al_get_audio_stream_speed(IntPtr stream);

    public static al_get_audio_stream_speed AlGetAudioStreamSpeed =
        NativeInterop.LoadFunction<al_get_audio_stream_speed>(AllegroLibrary, nameof(al_get_audio_stream_speed));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_set_audio_stream_speed(IntPtr stream, float val);

    public static al_set_audio_stream_speed AlSetAudioStreamSpeed =
        NativeInterop.LoadFunction<al_set_audio_stream_speed>(AllegroLibrary, nameof(al_set_audio_stream_speed));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate float al_get_audio_stream_gain(IntPtr stream);

    public static al_get_audio_stream_gain AlGetAudioStreamGain =
        NativeInterop.LoadFunction<al_get_audio_stream_gain>(AllegroLibrary, nameof(al_get_audio_stream_gain));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_set_audio_stream_gain(IntPtr stream, float val);

    public static al_set_audio_stream_gain AlSetAudioStreamGain =
        NativeInterop.LoadFunction<al_set_audio_stream_gain>(AllegroLibrary, nameof(al_set_audio_stream_gain));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate float al_get_audio_stream_pan(IntPtr stream);

    public static al_get_audio_stream_pan AlGetAudioStreamPan =
        NativeInterop.LoadFunction<al_get_audio_stream_pan>(AllegroLibrary, nameof(al_get_audio_stream_pan));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_set_audio_stream_pan(IntPtr stream, float val);

    public static al_set_audio_stream_pan AlSetAudioStreamPan =
        NativeInterop.LoadFunction<al_set_audio_stream_pan>(AllegroLibrary, nameof(al_set_audio_stream_pan));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_get_audio_stream_playing(IntPtr stream);

    public static al_get_audio_stream_playing AlGetAudioStreamPlaying =
        NativeInterop.LoadFunction<al_get_audio_stream_playing>(AllegroLibrary, nameof(al_get_audio_stream_playing));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_set_audio_stream_playing(IntPtr stream, [MarshalAs(UnmanagedType.U1)] bool val);

    public static al_set_audio_stream_playing AlSetAudioStreamPlaying =
        NativeInterop.LoadFunction<al_set_audio_stream_playing>(AllegroLibrary, nameof(al_set_audio_stream_playing));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_audio_stream_playmode(IntPtr stream);

    public static al_get_audio_stream_playmode AlGetAudioStreamPlaymode =
        NativeInterop.LoadFunction<al_get_audio_stream_playmode>(AllegroLibrary, nameof(al_get_audio_stream_playmode));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_set_audio_stream_playmode(IntPtr stream, int val);

    public static al_set_audio_stream_playmode AlSetAudioStreamPlaymode =
        NativeInterop.LoadFunction<al_set_audio_stream_playmode>(AllegroLibrary, nameof(al_set_audio_stream_playmode));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_get_audio_stream_attached(IntPtr stream);

    public static al_get_audio_stream_attached AlGetAudioStreamAttached =
        NativeInterop.LoadFunction<al_get_audio_stream_attached>(AllegroLibrary, nameof(al_get_audio_stream_attached));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_detach_audio_stream(IntPtr stream);

    public static al_detach_audio_stream AlDetachAudioStream =
        NativeInterop.LoadFunction<al_detach_audio_stream>(AllegroLibrary, nameof(al_detach_audio_stream));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate ulong al_get_audio_stream_played_samples(IntPtr stream);

    public static al_get_audio_stream_played_samples AlGetAudioStreamPlayedSamples =
        NativeInterop.LoadFunction<al_get_audio_stream_played_samples>(AllegroLibrary, nameof(al_get_audio_stream_played_samples));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_audio_stream_fragment(IntPtr stream);

    public static al_get_audio_stream_fragment AlGetAudioStreamFragment =
        NativeInterop.LoadFunction<al_get_audio_stream_fragment>(AllegroLibrary, nameof(al_get_audio_stream_fragment));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_set_audio_stream_fragment(IntPtr stream, IntPtr val);

    public static al_set_audio_stream_fragment AlSetAudioStreamFragment =
        NativeInterop.LoadFunction<al_set_audio_stream_fragment>(AllegroLibrary, nameof(al_set_audio_stream_fragment));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate uint al_get_audio_stream_fragments(IntPtr stream);

    public static al_get_audio_stream_fragments AlGetAudioStreamFragments =
        NativeInterop.LoadFunction<al_get_audio_stream_fragments>(AllegroLibrary, nameof(al_get_audio_stream_fragments));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate uint al_get_available_audio_stream_fragments(IntPtr stream);

    public static al_get_available_audio_stream_fragments AlGetAvailableAudioStreamFragments =
        NativeInterop.LoadFunction<al_get_available_audio_stream_fragments>(AllegroLibrary, nameof(al_get_available_audio_stream_fragments));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_seek_audio_stream_secs(IntPtr stream, double time);

    public static al_seek_audio_stream_secs AlSeekAudioStreamSecs =
        NativeInterop.LoadFunction<al_seek_audio_stream_secs>(AllegroLibrary, nameof(al_seek_audio_stream_secs));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate double al_get_audio_stream_position_secs(IntPtr stream);

    public static al_get_audio_stream_position_secs AlGetAudioStreamPositionSecs =
        NativeInterop.LoadFunction<al_get_audio_stream_position_secs>(AllegroLibrary, nameof(al_get_audio_stream_position_secs));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate double al_get_audio_stream_length_secs(IntPtr stream);

    public static al_get_audio_stream_length_secs AlGetAudioStreamLengthSecs =
        NativeInterop.LoadFunction<al_get_audio_stream_length_secs>(AllegroLibrary, nameof(al_get_audio_stream_length_secs));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_set_audio_stream_loop_secs(IntPtr stream, double start, double end);

    public static al_set_audio_stream_loop_secs AlSetAudioStreamLoopSecs =
        NativeInterop.LoadFunction<al_set_audio_stream_loop_secs>(AllegroLibrary, nameof(al_set_audio_stream_loop_secs));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_register_sample_loader(IntPtr ext, RegisterSampleLoader loader);

    public static al_register_sample_loader AlRegisterSampleLoader =
        NativeInterop.LoadFunction<al_register_sample_loader>(AllegroLibrary, nameof(al_register_sample_loader));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_register_sample_loader_f(IntPtr ext, RegisterSampleLoaderF loader);

    public static al_register_sample_loader_f AlRegisterSampleLoaderF =
        NativeInterop.LoadFunction<al_register_sample_loader_f>(AllegroLibrary, nameof(al_register_sample_loader_f));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_register_sample_saver(IntPtr ext, RegisterSampleSaver saver);

    public static al_register_sample_saver AlRegisterSampleSaver =
        NativeInterop.LoadFunction<al_register_sample_saver>(AllegroLibrary, nameof(al_register_sample_saver));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_register_sample_saver_f(IntPtr ext, RegisterSampleSaverF saver);

    public static al_register_sample_saver_f AlRegisterSampleSaverF =
        NativeInterop.LoadFunction<al_register_sample_saver_f>(AllegroLibrary, nameof(al_register_sample_saver_f));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_register_audio_stream_loader(IntPtr ext, RegisterAudioStreamLoader stream_loader);

    public static al_register_audio_stream_loader AlRegisterAudioStreamLoader =
        NativeInterop.LoadFunction<al_register_audio_stream_loader>(AllegroLibrary, nameof(al_register_audio_stream_loader));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_register_audio_stream_loader_f(IntPtr ext, RegisterAudioStreamLoaderF stream_loader);

    public static al_register_audio_stream_loader_f AlRegisterAudioStreamLoaderF =
        NativeInterop.LoadFunction<al_register_audio_stream_loader_f>(AllegroLibrary, nameof(al_register_audio_stream_loader_f));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_load_sample(IntPtr filename);

    public static al_load_sample AlLoadSample =
        NativeInterop.LoadFunction<al_load_sample>(AllegroLibrary, nameof(al_load_sample));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_load_sample_f(IntPtr fp, IntPtr ident);

    public static al_load_sample_f AlLoadSampleF =
        NativeInterop.LoadFunction<al_load_sample_f>(AllegroLibrary, nameof(al_load_sample_f));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_load_audio_stream(IntPtr filename, long buffer_count, uint samples);

    public static al_load_audio_stream AlLoadAudioStream =
        NativeInterop.LoadFunction<al_load_audio_stream>(AllegroLibrary, nameof(al_load_audio_stream));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_load_audio_stream_f(IntPtr fp, IntPtr ident, long buffer_count, uint samples);

    public static al_load_audio_stream_f AlLoadAudioStreamF =
        NativeInterop.LoadFunction<al_load_audio_stream_f>(AllegroLibrary, nameof(al_load_audio_stream_f));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_save_sample(IntPtr filename, IntPtr spl);

    public static al_save_sample AlSaveSample =
        NativeInterop.LoadFunction<al_save_sample>(AllegroLibrary, nameof(al_save_sample));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_save_sample_f(IntPtr fp, IntPtr ident, IntPtr spl);

    public static al_save_sample_f AlSaveSampleF =
        NativeInterop.LoadFunction<al_save_sample_f>(AllegroLibrary, nameof(al_save_sample_f));

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
        NativeInterop.LoadFunction<al_create_config>(AllegroLibrary, nameof(al_create_config));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_destroy_config(IntPtr config);

    public static al_destroy_config AlDestroyConfig =
        NativeInterop.LoadFunction<al_destroy_config>(AllegroLibrary, nameof(al_destroy_config));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_load_config_file(IntPtr filename);

    public static al_load_config_file AlLoadConfigFile =
        NativeInterop.LoadFunction<al_load_config_file>(AllegroLibrary, nameof(al_load_config_file));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_load_config_file_f(IntPtr file);

    public static al_load_config_file_f AlLoadConfigFileF =
        NativeInterop.LoadFunction<al_load_config_file_f>(AllegroLibrary, nameof(al_load_config_file_f));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_save_config_file(IntPtr filename, IntPtr config);

    public static al_save_config_file AlSaveConfigFile =
        NativeInterop.LoadFunction<al_save_config_file>(AllegroLibrary, nameof(al_save_config_file));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_save_config_file_f(IntPtr file, IntPtr config);

    public static al_save_config_file_f AlSaveConfigFileF =
        NativeInterop.LoadFunction<al_save_config_file_f>(AllegroLibrary, nameof(al_save_config_file_f));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_add_config_section(IntPtr config, IntPtr name);

    public static al_add_config_section AlAddConfigSection =
        NativeInterop.LoadFunction<al_add_config_section>(AllegroLibrary, nameof(al_add_config_section));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_remove_config_section(IntPtr config, IntPtr section);

    public static al_remove_config_section AlRemoveConfigSection =
        NativeInterop.LoadFunction<al_remove_config_section>(AllegroLibrary, nameof(al_remove_config_section));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_add_config_comment(IntPtr config, IntPtr section, IntPtr comment);

    public static al_add_config_comment AlAddConfigComment =
        NativeInterop.LoadFunction<al_add_config_comment>(AllegroLibrary, nameof(al_add_config_comment));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_config_value(IntPtr config, IntPtr section, IntPtr key);

    public static al_get_config_value AlGetConfigValue =
        NativeInterop.LoadFunction<al_get_config_value>(AllegroLibrary, nameof(al_get_config_value));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_set_config_value(IntPtr config, IntPtr section, IntPtr key, IntPtr value);

    public static al_set_config_value AlSetConfigValue =
        NativeInterop.LoadFunction<al_set_config_value>(AllegroLibrary, nameof(al_set_config_value));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_remove_config_key(IntPtr config, IntPtr section, IntPtr key);

    public static al_remove_config_key AlRemoveConfigKey =
        NativeInterop.LoadFunction<al_remove_config_key>(AllegroLibrary, nameof(al_remove_config_key));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_first_config_section(IntPtr config, ref IntPtr iterator);

    public static al_get_first_config_section AlGetFirstConfigSection =
        NativeInterop.LoadFunction<al_get_first_config_section>(AllegroLibrary, nameof(al_get_first_config_section));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_next_config_section(ref IntPtr iterator);

    public static al_get_next_config_section AlGetNextConfigSection =
        NativeInterop.LoadFunction<al_get_next_config_section>(AllegroLibrary, nameof(al_get_next_config_section));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_first_config_entry(IntPtr config, IntPtr section, ref IntPtr iterator);

    public static al_get_first_config_entry AlGetFirstConfigEntry =
        NativeInterop.LoadFunction<al_get_first_config_entry>(AllegroLibrary, nameof(al_get_first_config_entry));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_next_config_entry(ref IntPtr iterator);

    public static al_get_next_config_entry AlGetNextConfigEntry =
        NativeInterop.LoadFunction<al_get_next_config_entry>(AllegroLibrary, nameof(al_get_next_config_entry));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_merge_config(IntPtr cfg1, IntPtr cfg2);

    public static al_merge_config AlMergeConfig =
        NativeInterop.LoadFunction<al_merge_config>(AllegroLibrary, nameof(al_merge_config));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_merge_config_into(IntPtr master, IntPtr add);

    public static al_merge_config_into AlMergeConfigInto =
        NativeInterop.LoadFunction<al_merge_config_into>(AllegroLibrary, nameof(al_merge_config_into));

    #endregion Configuration routines

    #region Display routines

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_create_display(int w, int h);

    public static al_create_display AlCreateDisplay =
        NativeInterop.LoadFunction<al_create_display>(AllegroLibrary, nameof(al_create_display));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_destroy_display(IntPtr display);

    public static al_destroy_display AlDestroyDisplay =
        NativeInterop.LoadFunction<al_destroy_display>(AllegroLibrary, nameof(al_destroy_display));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_new_display_flags();

    public static al_get_new_display_flags AlGetNewDisplayFlags =
        NativeInterop.LoadFunction<al_get_new_display_flags>(AllegroLibrary, nameof(al_get_new_display_flags));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_set_new_display_flags(int flags);

    public static al_set_new_display_flags AlSetNewDisplayFlags =
        NativeInterop.LoadFunction<al_set_new_display_flags>(AllegroLibrary, nameof(al_set_new_display_flags));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_new_display_option(int option, ref int importance);

    public static al_get_new_display_option AlGetNewDisplayOption =
        NativeInterop.LoadFunction<al_get_new_display_option>(AllegroLibrary, nameof(al_get_new_display_option));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_set_new_display_option(int option, int value, int importance);

    public static al_set_new_display_option AlSetNewDisplayOption =
        NativeInterop.LoadFunction<al_set_new_display_option>(AllegroLibrary, nameof(al_set_new_display_option));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_reset_new_display_options();

    public static al_reset_new_display_options AlResetNewDisplayOptions =
        NativeInterop.LoadFunction<al_reset_new_display_options>(AllegroLibrary, nameof(al_reset_new_display_options));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_get_new_window_position(ref int x, ref int y);

    public static al_get_new_window_position AlGetNewWindowPosition =
        NativeInterop.LoadFunction<al_get_new_window_position>(AllegroLibrary, nameof(al_get_new_window_position));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_set_new_window_position(int x, int y);

    public static al_set_new_window_position AlSetNewWindowPosition =
        NativeInterop.LoadFunction<al_set_new_window_position>(AllegroLibrary, nameof(al_set_new_window_position));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_new_display_refresh_rate();

    public static al_get_new_display_refresh_rate AlGetNewDisplayRefreshRate =
        NativeInterop.LoadFunction<al_get_new_display_refresh_rate>(AllegroLibrary, nameof(al_get_new_display_refresh_rate));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_set_new_display_refresh_rate(int refresh_rate);

    public static al_set_new_display_refresh_rate AlSetNewDisplayRefreshRate =
        NativeInterop.LoadFunction<al_set_new_display_refresh_rate>(AllegroLibrary, nameof(al_set_new_display_refresh_rate));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_display_event_source(IntPtr display);

    public static al_get_display_event_source AlGetDisplayEventSource =
        NativeInterop.LoadFunction<al_get_display_event_source>(AllegroLibrary, nameof(al_get_display_event_source));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_backbuffer(IntPtr display);

    public static al_get_backbuffer AlGetBackbuffer =
        NativeInterop.LoadFunction<al_get_backbuffer>(AllegroLibrary, nameof(al_get_backbuffer));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_flip_display();

    public static al_flip_display AlFlipDisplay =
        NativeInterop.LoadFunction<al_flip_display>(AllegroLibrary, nameof(al_flip_display));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_update_display_region(int x, int y, int width, int height);

    public static al_update_display_region AlUpdateDisplayRegion =
        NativeInterop.LoadFunction<al_update_display_region>(AllegroLibrary, nameof(al_update_display_region));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_wait_for_vsync();

    public static al_wait_for_vsync AlWaitForVSync =
        NativeInterop.LoadFunction<al_wait_for_vsync>(AllegroLibrary, nameof(al_wait_for_vsync));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_display_width(IntPtr display);

    public static al_get_display_width AlGetDisplayWidth =
        NativeInterop.LoadFunction<al_get_display_width>(AllegroLibrary, nameof(al_get_display_width));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_display_height(IntPtr display);

    public static al_get_display_height AlGetDisplayHeight =
        NativeInterop.LoadFunction<al_get_display_height>(AllegroLibrary, nameof(al_get_display_height));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_resize_display(IntPtr display, int width, int height);

    public static al_resize_display AlResizeDisplay =
        NativeInterop.LoadFunction<al_resize_display>(AllegroLibrary, nameof(al_resize_display));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_acknowledge_resize(IntPtr display);

    public static al_acknowledge_resize AlAcknowledgeResize =
        NativeInterop.LoadFunction<al_acknowledge_resize>(AllegroLibrary, nameof(al_acknowledge_resize));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_get_window_position(IntPtr display, ref int x, ref int y);

    public static al_get_window_position AlGetWindowPosition =
        NativeInterop.LoadFunction<al_get_window_position>(AllegroLibrary, nameof(al_get_window_position));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_set_window_position(IntPtr display, int x, int y);

    public static al_set_window_position AlSetWindowPosition =
        NativeInterop.LoadFunction<al_set_window_position>(AllegroLibrary, nameof(al_set_window_position));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_get_window_constraints(IntPtr display, ref int min_w, ref int min_h, ref int max_w, ref int max_h);

    public static al_get_window_constraints AlGetWindowConstraints =
        NativeInterop.LoadFunction<al_get_window_constraints>(AllegroLibrary, nameof(al_get_window_constraints));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_set_window_constraints(IntPtr display, int min_w, int min_h, int max_w, int max_h);

    public static al_set_window_constraints AlSetWindowConstraints =
        NativeInterop.LoadFunction<al_set_window_constraints>(AllegroLibrary, nameof(al_set_window_constraints));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate bool al_apply_window_constraints(IntPtr display, [MarshalAs(UnmanagedType.U1)] bool onoff);

    public static al_apply_window_constraints AlApplyWindowConstraints =
        NativeInterop.LoadFunction<al_apply_window_constraints>(AllegroLibrary, nameof(al_apply_window_constraints));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_display_flags(IntPtr display);

    public static al_get_display_flags AlGetDisplayFlags =
        NativeInterop.LoadFunction<al_get_display_flags>(AllegroLibrary, nameof(al_get_display_flags));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_set_display_flag(IntPtr display, int flag, [MarshalAs(UnmanagedType.U1)] bool onoff);

    public static al_set_display_flag AlSetDisplayFlag =
        NativeInterop.LoadFunction<al_set_display_flag>(AllegroLibrary, nameof(al_set_display_flag));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_display_option(IntPtr display, int option);

    public static al_get_display_option AlGetDisplayOption =
        NativeInterop.LoadFunction<al_get_display_option>(AllegroLibrary, nameof(al_get_display_option));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_set_display_option(IntPtr display, int option, int value);

    public static al_set_display_option AlSetDisplayOption =
        NativeInterop.LoadFunction<al_set_display_option>(AllegroLibrary, nameof(al_set_display_option));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_display_format(IntPtr display);

    public static al_get_display_format AlGetDisplayFormat =
        NativeInterop.LoadFunction<al_get_display_format>(AllegroLibrary, nameof(al_get_display_format));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_display_orientation(IntPtr display);

    public static al_get_display_orientation AlGetDisplayOrientation =
        NativeInterop.LoadFunction<al_get_display_orientation>(AllegroLibrary, nameof(al_get_display_orientation));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_display_refresh_rate(IntPtr display);

    public static al_get_display_refresh_rate AlGetDisplayRefreshRate =
        NativeInterop.LoadFunction<al_get_display_refresh_rate>(AllegroLibrary, nameof(al_get_display_refresh_rate));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_set_window_title(IntPtr display, IntPtr title);

    public static al_set_window_title AlSetWindowTitle =
        NativeInterop.LoadFunction<al_set_window_title>(AllegroLibrary, nameof(al_set_window_title));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_set_new_window_title(IntPtr title);

    public static al_set_new_window_title AlSetNewWindowTitle =
        NativeInterop.LoadFunction<al_set_new_window_title>(AllegroLibrary, nameof(al_set_new_window_title));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_new_window_title();

    public static al_get_new_window_title AlGetNewWindowTitle =
        NativeInterop.LoadFunction<al_get_new_window_title>(AllegroLibrary, nameof(al_get_new_window_title));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_set_display_icon(IntPtr display, IntPtr icon);

    public static al_set_display_icon AlSetDisplayIcon =
        NativeInterop.LoadFunction<al_set_display_icon>(AllegroLibrary, nameof(al_set_display_icon));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_set_display_icons(IntPtr display, int num_icons, ref IntPtr[] icon);

    public static al_set_display_icons AlSetDisplayIcons =
        NativeInterop.LoadFunction<al_set_display_icons>(AllegroLibrary, nameof(al_set_display_icons));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_acknowledge_drawing_halt(IntPtr display);

    public static al_acknowledge_drawing_halt AlAcknowledgeDrawingHalt =
        NativeInterop.LoadFunction<al_acknowledge_drawing_halt>(AllegroLibrary, nameof(al_acknowledge_drawing_halt));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_acknowledge_drawing_resume(IntPtr display);

    public static al_acknowledge_drawing_resume AlAcknowledgeDrawingResume =
        NativeInterop.LoadFunction<al_acknowledge_drawing_resume>(AllegroLibrary, nameof(al_acknowledge_drawing_resume));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_inhibit_screensaver([MarshalAs(UnmanagedType.U1)] bool inhibit);

    public static al_inhibit_screensaver AlInhibitScreensaver =
        NativeInterop.LoadFunction<al_inhibit_screensaver>(AllegroLibrary, nameof(al_inhibit_screensaver));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_clipboard_text(IntPtr display);

    public static al_get_clipboard_text AlGetClipboardText =
        NativeInterop.LoadFunction<al_get_clipboard_text>(AllegroLibrary, nameof(al_get_clipboard_text));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_set_clipboard_text(IntPtr display, IntPtr text);

    public static al_set_clipboard_text AlSetClipboardText =
        NativeInterop.LoadFunction<al_set_clipboard_text>(AllegroLibrary, nameof(al_set_clipboard_text));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_clipboard_has_text(IntPtr display);

    public static al_clipboard_has_text AlClipboardHasText =
        NativeInterop.LoadFunction<al_clipboard_has_text>(AllegroLibrary, nameof(al_clipboard_has_text));

    #endregion Display routines

    #region Event routines

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_create_event_queue();

    public static al_create_event_queue AlCreateEventQueue =
        NativeInterop.LoadFunction<al_create_event_queue>(AllegroLibrary, nameof(al_create_event_queue));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_destroy_event_queue(IntPtr queue);

    public static al_destroy_event_queue AlDestroyEventQueue =
        NativeInterop.LoadFunction<al_destroy_event_queue>(AllegroLibrary, nameof(al_destroy_event_queue));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_register_event_source(IntPtr queue, IntPtr source);

    public static al_register_event_source AlRegisterEventSource =
        NativeInterop.LoadFunction<al_register_event_source>(AllegroLibrary, nameof(al_register_event_source));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_unregister_event_source(IntPtr queue, IntPtr source);

    public static al_unregister_event_source AlUnregisterEventSource =
        NativeInterop.LoadFunction<al_unregister_event_source>(AllegroLibrary, nameof(al_unregister_event_source));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_is_event_source_registered(IntPtr queue, IntPtr source);

    public static al_is_event_source_registered AlIsEventSourceRegistered =
        NativeInterop.LoadFunction<al_is_event_source_registered>(AllegroLibrary, nameof(al_is_event_source_registered));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_pause_event_queue(IntPtr queue, [MarshalAs(UnmanagedType.U1)] bool pause);

    public static al_pause_event_queue AlPauseEventQueue =
        NativeInterop.LoadFunction<al_pause_event_queue>(AllegroLibrary, nameof(al_pause_event_queue));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_is_event_queue_paused(IntPtr queue);

    public static al_is_event_queue_paused AlIsEventQueuePaused =
        NativeInterop.LoadFunction<al_is_event_queue_paused>(AllegroLibrary, nameof(al_is_event_queue_paused));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_is_event_queue_empty(IntPtr queue);

    public static al_is_event_queue_empty AlIsEventQueueEmpty =
        NativeInterop.LoadFunction<al_is_event_queue_empty>(AllegroLibrary, nameof(al_is_event_queue_empty));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_get_next_event(IntPtr queue, ref AllegroEvent.NativeAllegroEvent ret_event);

    public static al_get_next_event AlGetNextEvent =
        NativeInterop.LoadFunction<al_get_next_event>(AllegroLibrary, nameof(al_get_next_event));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_peek_next_event(IntPtr queue, ref AllegroEvent.NativeAllegroEvent ret_event);

    public static al_peek_next_event AlPeekNextEvent =
        NativeInterop.LoadFunction<al_peek_next_event>(AllegroLibrary, nameof(al_peek_next_event));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_drop_next_event(IntPtr queue);

    public static al_drop_next_event AlDropNextEvent =
        NativeInterop.LoadFunction<al_drop_next_event>(AllegroLibrary, nameof(al_drop_next_event));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_flush_event_queue(IntPtr queue);

    public static al_flush_event_queue AlFlushEventQueue =
        NativeInterop.LoadFunction<al_flush_event_queue>(AllegroLibrary, nameof(al_flush_event_queue));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_wait_for_event(IntPtr queue, ref AllegroEvent.NativeAllegroEvent ret_event);

    public static al_wait_for_event AlWaitForEvent =
        NativeInterop.LoadFunction<al_wait_for_event>(AllegroLibrary, nameof(al_wait_for_event));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_wait_for_event_timed(IntPtr queue, ref AllegroEvent.NativeAllegroEvent ret_event, float secs);

    public static al_wait_for_event_timed AlWaitForEventTimed =
        NativeInterop.LoadFunction<al_wait_for_event_timed>(AllegroLibrary, nameof(al_wait_for_event_timed));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_wait_for_event_until(
        IntPtr queue,
        ref AllegroEvent.NativeAllegroEvent ret_event,
        ref AllegroTimeout.NativeAllegroTimeout timeout);

    public static al_wait_for_event_until AlWaitForEventUntil =
        NativeInterop.LoadFunction<al_wait_for_event_until>(AllegroLibrary, nameof(al_wait_for_event_until));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_init_user_event_source(IntPtr source);

    public static al_init_user_event_source AlInitUserEventSource =
        NativeInterop.LoadFunction<al_init_user_event_source>(AllegroLibrary, nameof(al_init_user_event_source));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_destroy_user_event_source(IntPtr source);

    public static al_destroy_user_event_source AlDestroyUserEventSource =
        NativeInterop.LoadFunction<al_destroy_user_event_source>(AllegroLibrary, nameof(al_destroy_user_event_source));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_emit_user_event(
        IntPtr source,
        ref AllegroEvent.NativeAllegroEvent alEvent,
        UserEventDelegate? userEventHandler);

    public static al_emit_user_event AlEmitUserEvent =
        NativeInterop.LoadFunction<al_emit_user_event>(AllegroLibrary, nameof(al_emit_user_event));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_unref_user_event(ref AllegroEvent.NativeAllegroUserEvent userEvent);

    public static al_unref_user_event AlUnrefUserEvent =
        NativeInterop.LoadFunction<al_unref_user_event>(AllegroLibrary, nameof(al_unref_user_event));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_event_source_data(IntPtr source);

    public static al_get_event_source_data AlGetEventSourceData =
        NativeInterop.LoadFunction<al_get_event_source_data>(AllegroLibrary, nameof(al_get_event_source_data));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_set_event_source_data(IntPtr source, IntPtr data);

    public static al_set_event_source_data AlSetEventSourceData =
        NativeInterop.LoadFunction<al_set_event_source_data>(AllegroLibrary, nameof(al_set_event_source_data));

    #endregion Event routines

    #region File IO routines

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_fclose(IntPtr f);

    public static al_fclose AlFClose = NativeInterop.LoadFunction<al_fclose>(AllegroLibrary);

    #endregion

    #region File system routines

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_create_fs_entry(IntPtr path);

    public static al_create_fs_entry AlCreateFsEntry =
        NativeInterop.LoadFunction<al_create_fs_entry>(AllegroLibrary, nameof(al_create_fs_entry));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_destroy_fs_entry(IntPtr fh);

    public static al_destroy_fs_entry AlDestroyFsEntry =
        NativeInterop.LoadFunction<al_destroy_fs_entry>(AllegroLibrary, nameof(al_destroy_fs_entry));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_fs_entry_name(IntPtr e);

    public static al_get_fs_entry_name AlGetFsEntryName =
        NativeInterop.LoadFunction<al_get_fs_entry_name>(AllegroLibrary, nameof(al_get_fs_entry_name));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_update_fs_entry(IntPtr e);

    public static al_update_fs_entry AlUpdateFsEntry =
        NativeInterop.LoadFunction<al_update_fs_entry>(AllegroLibrary, nameof(al_update_fs_entry));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate uint al_get_fs_entry_mode(IntPtr e);

    public static al_get_fs_entry_mode AlGetFsEntryMode =
        NativeInterop.LoadFunction<al_get_fs_entry_mode>(AllegroLibrary, nameof(al_get_fs_entry_mode));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate ulong al_get_fs_entry_atime(IntPtr e);

    public static al_get_fs_entry_atime AlGetFsEntryATime =
        NativeInterop.LoadFunction<al_get_fs_entry_atime>(AllegroLibrary, nameof(al_get_fs_entry_atime));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate ulong al_get_fs_entry_ctime(IntPtr e);

    public static al_get_fs_entry_ctime AlGetFsEntryCTime =
        NativeInterop.LoadFunction<al_get_fs_entry_ctime>(AllegroLibrary, nameof(al_get_fs_entry_ctime));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate ulong al_get_fs_entry_mtime(IntPtr e);

    public static al_get_fs_entry_mtime AlGetFsEntryMTime =
        NativeInterop.LoadFunction<al_get_fs_entry_mtime>(AllegroLibrary, nameof(al_get_fs_entry_mtime));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate long al_get_fs_entry_size(IntPtr e);

    public static al_get_fs_entry_size AlGetFsEntrySize =
        NativeInterop.LoadFunction<al_get_fs_entry_size>(AllegroLibrary, nameof(al_get_fs_entry_size));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_fs_entry_exists(IntPtr e);

    public static al_fs_entry_exists AlFsEntryExists =
        NativeInterop.LoadFunction<al_fs_entry_exists>(AllegroLibrary, nameof(al_fs_entry_exists));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_remove_fs_entry(IntPtr e);

    public static al_remove_fs_entry AlRemoveFsEntry =
        NativeInterop.LoadFunction<al_remove_fs_entry>(AllegroLibrary, nameof(al_remove_fs_entry));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_filename_exists(IntPtr path);

    public static al_filename_exists AlFilenameExists =
        NativeInterop.LoadFunction<al_filename_exists>(AllegroLibrary, nameof(al_filename_exists));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_remove_filename(IntPtr path);

    public static al_remove_filename AlRemoveFilename =
        NativeInterop.LoadFunction<al_remove_filename>(AllegroLibrary, nameof(al_remove_filename));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_open_directory(IntPtr e);

    public static al_open_directory AlOpenDirectory =
        NativeInterop.LoadFunction<al_open_directory>(AllegroLibrary, nameof(al_open_directory));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_read_directory(IntPtr e);

    public static al_read_directory AlReadDirectory =
        NativeInterop.LoadFunction<al_read_directory>(AllegroLibrary, nameof(al_read_directory));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_close_directory(IntPtr e);

    public static al_close_directory AlCloseDirectory =
        NativeInterop.LoadFunction<al_close_directory>(AllegroLibrary, nameof(al_close_directory));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_current_directory();

    public static al_get_current_directory AlGetCurrentDirectory =
        NativeInterop.LoadFunction<al_get_current_directory>(AllegroLibrary, nameof(al_get_current_directory));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_change_directory(IntPtr path);

    public static al_change_directory AlChangeDirectory =
        NativeInterop.LoadFunction<al_change_directory>(AllegroLibrary, nameof(al_change_directory));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_make_directory(IntPtr path);

    public static al_make_directory AlMakeDirectory =
        NativeInterop.LoadFunction<al_make_directory>(AllegroLibrary, nameof(al_make_directory));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_open_fs_entry(IntPtr e, IntPtr mode);

    public static al_open_fs_entry AlOpenFsEntry =
        NativeInterop.LoadFunction<al_open_fs_entry>(AllegroLibrary, nameof(al_open_fs_entry));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_for_each_fs_entry(IntPtr dir, ForEachFsEntry callback, IntPtr extra);

    public static al_for_each_fs_entry AlForEachFsEntry =
        NativeInterop.LoadFunction<al_for_each_fs_entry>(AllegroLibrary, nameof(al_for_each_fs_entry));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_set_fs_interface(IntPtr fs_interface);

    public static al_set_fs_interface AlSetFsInterface =
        NativeInterop.LoadFunction<al_set_fs_interface>(AllegroLibrary, nameof(al_set_fs_interface));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_set_standard_fs_interface();

    public static al_set_standard_fs_interface AlSetStandardFsInterface =
        NativeInterop.LoadFunction<al_set_standard_fs_interface>(AllegroLibrary, nameof(al_set_standard_fs_interface));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_fs_interface();

    public static al_get_fs_interface AlGetFsInterface =
        NativeInterop.LoadFunction<al_get_fs_interface>(AllegroLibrary, nameof(al_get_fs_interface));

    #endregion File system routines

    #region Font routines

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_init_font_addon();

    public static al_init_font_addon AlInitFontAddon =
      NativeInterop.LoadFunction<al_init_font_addon>(AllegroLibrary, nameof(al_init_font_addon));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_is_font_addon_initialized();

    public static al_is_font_addon_initialized AlIsFontAddonInitialized =
      NativeInterop.LoadFunction<al_is_font_addon_initialized>(AllegroLibrary, nameof(al_is_font_addon_initialized));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_shutdown_font_addon();

    public static al_shutdown_font_addon AlShutdownFontAddon =
        NativeInterop.LoadFunction<al_shutdown_font_addon>(AllegroLibrary, nameof(al_shutdown_font_addon));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_load_font(IntPtr filename, int size, int flags);

    public static al_load_font AlLoadFont =
        NativeInterop.LoadFunction<al_load_font>(AllegroLibrary, nameof(al_load_font));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_destroy_font(IntPtr f);

    public static al_destroy_font AlDestroyFont =
        NativeInterop.LoadFunction<al_destroy_font>(AllegroLibrary, nameof(al_destroy_font));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_register_font_loader(IntPtr extension, RegisterFontLoader load_font);

    public static al_register_font_loader AlRegisterFontLoader =
        NativeInterop.LoadFunction<al_register_font_loader>(AllegroLibrary, nameof(al_register_font_loader));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_font_line_height(IntPtr f);

    public static al_get_font_line_height AlGetFontLineHeight =
        NativeInterop.LoadFunction<al_get_font_line_height>(AllegroLibrary, nameof(al_get_font_line_height));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_font_ascent(IntPtr f);

    public static al_get_font_ascent AlGetFontAscent =
        NativeInterop.LoadFunction<al_get_font_ascent>(AllegroLibrary, nameof(al_get_font_ascent));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_font_descent(IntPtr f);

    public static al_get_font_descent AlGetFontDescent =
        NativeInterop.LoadFunction<al_get_font_descent>(AllegroLibrary, nameof(al_get_font_descent));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_text_width(IntPtr f, IntPtr str);

    public static al_get_text_width AlGetTextWidth =
        NativeInterop.LoadFunction<al_get_text_width>(AllegroLibrary, nameof(al_get_text_width));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_ustr_width(IntPtr f, IntPtr ustr);

    public static al_get_ustr_width AlGetUstrWidth =
        NativeInterop.LoadFunction<al_get_ustr_width>(AllegroLibrary, nameof(al_get_ustr_width));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_draw_text(IntPtr font, AllegroColor color, float x, float y, int flags, IntPtr text);

    public static al_draw_text AlDrawText =
        NativeInterop.LoadFunction<al_draw_text>(AllegroLibrary, nameof(al_draw_text));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_draw_ustr(IntPtr font, AllegroColor color, float x, float y, int flags, IntPtr ustr);

    public static al_draw_ustr AlDrawUstr =
        NativeInterop.LoadFunction<al_draw_ustr>(AllegroLibrary, nameof(al_draw_ustr));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_draw_justified_text(IntPtr font, AllegroColor color, float x1, float x2, float y, float diff, int flags, IntPtr text);

    public static al_draw_justified_text AlDrawJustifiedText =
        NativeInterop.LoadFunction<al_draw_justified_text>(AllegroLibrary, nameof(al_draw_justified_text));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_draw_justified_ustr(IntPtr font, AllegroColor color, float x1, float x2, float y, float diff, int flags, IntPtr ustr);

    public static al_draw_justified_ustr AlDrawJustifiedUstr =
        NativeInterop.LoadFunction<al_draw_justified_ustr>(AllegroLibrary, nameof(al_draw_justified_ustr));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_get_text_dimensions(IntPtr f, IntPtr text, ref int bbx, ref int bby, ref int bbw, ref int bbh);

    public static al_get_text_dimensions AlGetTextDimensions =
        NativeInterop.LoadFunction<al_get_text_dimensions>(AllegroLibrary, nameof(al_get_text_dimensions));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_get_ustr_dimensions(IntPtr f, IntPtr ustr, ref int bbx, ref int bby, ref int bbw, ref int bbh);

    public static al_get_ustr_dimensions AlGetUstrDimensions =
        NativeInterop.LoadFunction<al_get_ustr_dimensions>(AllegroLibrary, nameof(al_get_ustr_dimensions));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate uint al_get_allegro_font_version();

    public static al_get_allegro_font_version AlGetAllegroFontVersion =
        NativeInterop.LoadFunction<al_get_allegro_font_version>(AllegroLibrary, nameof(al_get_allegro_font_version));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_font_ranges(IntPtr f, int ranges_count, ref int[] ranges);

    public static al_get_font_ranges AlGetFontRanges =
        NativeInterop.LoadFunction<al_get_font_ranges>(AllegroLibrary, nameof(al_get_font_ranges));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_set_fallback_font(IntPtr font, IntPtr fallback);

    public static al_set_fallback_font AlSetFallbackFont =
        NativeInterop.LoadFunction<al_set_fallback_font>(AllegroLibrary, nameof(al_set_fallback_font));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_fallback_font(IntPtr font);

    public static al_get_fallback_font AlGetFallbackFont =
        NativeInterop.LoadFunction<al_get_fallback_font>(AllegroLibrary, nameof(al_get_fallback_font));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_draw_glyph(IntPtr f, AllegroColor color, float x, float y, int codepoint);

    public static al_draw_glyph AlDrawGlyph =
        NativeInterop.LoadFunction<al_draw_glyph>(AllegroLibrary, nameof(al_draw_glyph));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_glyph_width(IntPtr f, int codepoint);

    public static al_get_glyph_width AlGetGlyphWidth =
        NativeInterop.LoadFunction<al_get_glyph_width>(AllegroLibrary, nameof(al_get_glyph_width));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_get_glyph_dimensions(IntPtr f, int codepoint, ref int bbx, ref int bby, ref int bbw, ref int bbh);

    public static al_get_glyph_dimensions AlGetGlyphDimensions =
        NativeInterop.LoadFunction<al_get_glyph_dimensions>(AllegroLibrary, nameof(al_get_glyph_dimensions));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_glyph_advance(IntPtr f, int codepoint1, int codepoint2);

    public static al_get_glyph_advance AlGetGlyphAdvance =
        NativeInterop.LoadFunction<al_get_glyph_advance>(AllegroLibrary, nameof(al_get_glyph_advance));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_draw_multiline_text(IntPtr font, AllegroColor color, float x, float y, float max_width, float line_height, int flags, IntPtr text);

    public static al_draw_multiline_text AlDrawMultilineText =
        NativeInterop.LoadFunction<al_draw_multiline_text>(AllegroLibrary, nameof(al_draw_multiline_text));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_draw_multiline_ustr(IntPtr font, AllegroColor color, float x, float y, float max_width, float line_height, int flags, IntPtr ustr);

    public static al_draw_multiline_ustr AlDrawMultilineUstr =
        NativeInterop.LoadFunction<al_draw_multiline_ustr>(AllegroLibrary, nameof(al_draw_multiline_ustr));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_do_multiline_text(IntPtr font, float max_width, IntPtr text, DoMultilineText cb, IntPtr extra);

    public static al_do_multiline_text AlDoMultilineText =
        NativeInterop.LoadFunction<al_do_multiline_text>(AllegroLibrary, nameof(al_do_multiline_text));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_do_multiline_ustr(IntPtr font, float max_width, IntPtr ustr, DoMultilineUstr cb, IntPtr extra);

    public static al_do_multiline_ustr AlDoMultilineUstr =
        NativeInterop.LoadFunction<al_do_multiline_ustr>(AllegroLibrary, nameof(al_do_multiline_ustr));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_grab_font_from_bitmap(IntPtr bmp, int ranges_n, int[] ranges);

    public static al_grab_font_from_bitmap AlGrabFontFromBitmap =
        NativeInterop.LoadFunction<al_grab_font_from_bitmap>(AllegroLibrary, nameof(al_grab_font_from_bitmap));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_load_bitmap_font(IntPtr fname);

    public static al_load_bitmap_font AlLoadBitmapFont =
        NativeInterop.LoadFunction<al_load_bitmap_font>(AllegroLibrary, nameof(al_load_bitmap_font));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_load_bitmap_font_flags(IntPtr fname, int flags);

    public static al_load_bitmap_font_flags AlLoadBitmapFontFlags =
        NativeInterop.LoadFunction<al_load_bitmap_font_flags>(AllegroLibrary, nameof(al_load_bitmap_font_flags));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_create_builtin_font();

    public static al_create_builtin_font AlCreateBuiltinFont =
        NativeInterop.LoadFunction<al_create_builtin_font>(AllegroLibrary, nameof(al_create_builtin_font));

    #endregion

    #region Fullscreen routines

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_display_mode(int index, ref AllegroDisplayMode.NativeDisplayMode mode);

    public static al_get_display_mode AlGetDisplayMode =
        NativeInterop.LoadFunction<al_get_display_mode>(AllegroLibrary, nameof(al_get_display_mode));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_num_display_modes();

    public static al_get_num_display_modes AlGetNumDisplayModes =
        NativeInterop.LoadFunction<al_get_num_display_modes>(AllegroLibrary, nameof(al_get_num_display_modes));

    #endregion Fullscreen routines

    #region Graphics routines

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate AllegroColor al_map_rgb(byte r, byte g, byte b);

    public static al_map_rgb AlMapRgb =
        NativeInterop.LoadFunction<al_map_rgb>(AllegroLibrary, nameof(al_map_rgb));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate AllegroColor al_map_rgb_f(float r, float g, float b);

    public static al_map_rgb_f AlMapRgbF =
        NativeInterop.LoadFunction<al_map_rgb_f>(AllegroLibrary, nameof(al_map_rgb_f));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate AllegroColor al_map_rgba(byte r, byte g, byte b, byte a);

    public static al_map_rgba AlMapRgba =
        NativeInterop.LoadFunction<al_map_rgba>(AllegroLibrary, nameof(al_map_rgba));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate AllegroColor al_premul_rgba(byte r, byte g, byte b, byte a);

    public static al_premul_rgba AlPremulRgba =
        NativeInterop.LoadFunction<al_premul_rgba>(AllegroLibrary, nameof(al_premul_rgba));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate AllegroColor al_map_rgba_f(float r, float g, float b, float a);

    public static al_map_rgba_f AlMapRgbaF =
        NativeInterop.LoadFunction<al_map_rgba_f>(AllegroLibrary, nameof(al_map_rgba_f));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate AllegroColor al_premul_rgba_f(float r, float g, float b, float a);

    public static al_premul_rgba_f AlPremulRgbaF =
        NativeInterop.LoadFunction<al_premul_rgba_f>(AllegroLibrary, nameof(al_premul_rgba_f));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_unmap_rgb(ref byte r, ref byte g, ref byte b);

    public static al_unmap_rgb AlUnmapRgb =
        NativeInterop.LoadFunction<al_unmap_rgb>(AllegroLibrary, nameof(al_unmap_rgb));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_unmap_rgb_f(ref float r, ref float g, ref float b);

    public static al_unmap_rgb_f AlUnmapRgbF =
        NativeInterop.LoadFunction<al_unmap_rgb_f>(AllegroLibrary, nameof(al_unmap_rgb_f));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_unmap_rgba(ref byte r, ref byte g, ref byte b, ref byte a);

    public static al_unmap_rgba AlUnmapRgba =
        NativeInterop.LoadFunction<al_unmap_rgba>(AllegroLibrary, nameof(al_unmap_rgba));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_unmap_rgba_f(ref float r, ref float g, ref float b, ref float a);

    public static al_unmap_rgba_f AlUnmapRgbaF =
        NativeInterop.LoadFunction<al_unmap_rgba_f>(AllegroLibrary, nameof(al_unmap_rgba_f));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_pixel_size(int format);

    public static al_get_pixel_size AlGetPixelSize =
        NativeInterop.LoadFunction<al_get_pixel_size>(AllegroLibrary, nameof(al_get_pixel_size));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_pixel_format_bits(int format);

    public static al_get_pixel_format_bits AlGetPixelFormatBits =
        NativeInterop.LoadFunction<al_get_pixel_format_bits>(AllegroLibrary, nameof(al_get_pixel_format_bits));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_pixel_block_size(int format);

    public static al_get_pixel_block_size AlGetPixelBlockSize =
        NativeInterop.LoadFunction<al_get_pixel_block_size>(AllegroLibrary, nameof(al_get_pixel_block_size));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_pixel_block_width(int format);

    public static al_get_pixel_block_width AlGetPixelBlockWidth =
        NativeInterop.LoadFunction<al_get_pixel_block_width>(AllegroLibrary, nameof(al_get_pixel_block_width));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_pixel_block_height(int format);

    public static al_get_pixel_block_height AlGetPixelBlockHeight =
        NativeInterop.LoadFunction<al_get_pixel_block_height>(AllegroLibrary, nameof(al_get_pixel_block_height));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_lock_bitmap(IntPtr bitmap, int format, int flags);

    public static al_lock_bitmap AlLockBitmap =
        NativeInterop.LoadFunction<al_lock_bitmap>(AllegroLibrary, nameof(al_lock_bitmap));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_lock_bitmap_region(IntPtr bitmap, int x, int y, int width, int height, int format, int flags);

    public static al_lock_bitmap_region AlLockBitmapRegion =
        NativeInterop.LoadFunction<al_lock_bitmap_region>(AllegroLibrary, nameof(al_lock_bitmap_region));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_unlock_bitmap(IntPtr bitmap);

    public static al_unlock_bitmap AlUnlockBitmap =
        NativeInterop.LoadFunction<al_unlock_bitmap>(AllegroLibrary, nameof(al_unlock_bitmap));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_lock_bitmap_blocked(IntPtr bitmap, int flags);

    public static al_lock_bitmap_blocked AlLockBitmapBlocked =
        NativeInterop.LoadFunction<al_lock_bitmap_blocked>(AllegroLibrary, nameof(al_lock_bitmap_blocked));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_lock_bitmap_region_blocked(IntPtr bitmap, int x_block, int y_block, int width_block, int height_block, int flags);

    public static al_lock_bitmap_region_blocked AlLockBitmapRegionBlocked =
        NativeInterop.LoadFunction<al_lock_bitmap_region_blocked>(AllegroLibrary, nameof(al_lock_bitmap_region_blocked));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_create_bitmap(int w, int h);

    public static al_create_bitmap AlCreateBitmap =
        NativeInterop.LoadFunction<al_create_bitmap>(AllegroLibrary, nameof(al_create_bitmap));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_create_sub_bitmap(IntPtr parent, int x, int y, int w, int h);

    public static al_create_sub_bitmap AlCreateSubBitmap =
        NativeInterop.LoadFunction<al_create_sub_bitmap>(AllegroLibrary, nameof(al_create_sub_bitmap));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_clone_bitmap(IntPtr parent);

    public static al_clone_bitmap AlCloneBitmap =
        NativeInterop.LoadFunction<al_clone_bitmap>(AllegroLibrary, nameof(al_clone_bitmap));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_convert_bitmap(IntPtr parent);

    public static al_convert_bitmap AlConvertBitmap =
        NativeInterop.LoadFunction<al_convert_bitmap>(AllegroLibrary, nameof(al_convert_bitmap));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_convert_memory_bitmaps();

    public static al_convert_memory_bitmaps AlConvertMemoryBitmaps =
        NativeInterop.LoadFunction<al_convert_memory_bitmaps>(AllegroLibrary, nameof(al_convert_memory_bitmaps));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_destroy_bitmap(IntPtr bitmap);

    public static al_destroy_bitmap AlDestroyBitmap =
        NativeInterop.LoadFunction<al_destroy_bitmap>(AllegroLibrary, nameof(al_destroy_bitmap));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_new_bitmap_flags();

    public static al_get_new_bitmap_flags AlGetNewBitmapFlags =
        NativeInterop.LoadFunction<al_get_new_bitmap_flags>(AllegroLibrary, nameof(al_get_new_bitmap_flags));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_new_bitmap_format();

    public static al_get_new_bitmap_format AlGetNewBitmapFormat =
        NativeInterop.LoadFunction<al_get_new_bitmap_format>(AllegroLibrary, nameof(al_get_new_bitmap_format));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_set_new_bitmap_flags(int flags);

    public static al_set_new_bitmap_flags AlSetNewBitmapFlags =
        NativeInterop.LoadFunction<al_set_new_bitmap_flags>(AllegroLibrary, nameof(al_set_new_bitmap_flags));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_add_new_bitmap_flag(int flag);

    public static al_add_new_bitmap_flag AlAddNewBitmapFlag =
        NativeInterop.LoadFunction<al_add_new_bitmap_flag>(AllegroLibrary, nameof(al_add_new_bitmap_flag));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_set_new_bitmap_format(int flag);

    public static al_set_new_bitmap_format AlSetNewBitmapFormat =
        NativeInterop.LoadFunction<al_set_new_bitmap_format>(AllegroLibrary, nameof(al_set_new_bitmap_format));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_bitmap_flags(IntPtr bitmap);

    public static al_get_bitmap_flags AlGetBitmapFlags =
        NativeInterop.LoadFunction<al_get_bitmap_flags>(AllegroLibrary, nameof(al_get_bitmap_flags));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_bitmap_format(IntPtr bitmap);

    public static al_get_bitmap_format AlGetBitmapFormat =
        NativeInterop.LoadFunction<al_get_bitmap_format>(AllegroLibrary, nameof(al_get_bitmap_format));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_bitmap_height(IntPtr bitmap);

    public static al_get_bitmap_height AlGetBitmapHeight =
        NativeInterop.LoadFunction<al_get_bitmap_height>(AllegroLibrary, nameof(al_get_bitmap_height));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_bitmap_width(IntPtr bitmap);

    public static al_get_bitmap_width AlGetBitmapWidth =
        NativeInterop.LoadFunction<al_get_bitmap_width>(AllegroLibrary, nameof(al_get_bitmap_width));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate AllegroColor al_get_pixel(IntPtr bitmap, int x, int y);

    public static al_get_pixel AlGetPixel =
        NativeInterop.LoadFunction<al_get_pixel>(AllegroLibrary, nameof(al_get_pixel));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_is_bitmap_locked(IntPtr bitmap);

    public static al_is_bitmap_locked AlIsBitmapLocked =
        NativeInterop.LoadFunction<al_is_bitmap_locked>(AllegroLibrary, nameof(al_is_bitmap_locked));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_is_compatible_bitmap(IntPtr bitmap);

    public static al_is_compatible_bitmap AlIsCompatibleBitmap =
        NativeInterop.LoadFunction<al_is_compatible_bitmap>(AllegroLibrary, nameof(al_is_compatible_bitmap));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_is_sub_bitmap(IntPtr bitmap);

    public static al_is_sub_bitmap AlIsSubBitmap =
        NativeInterop.LoadFunction<al_is_sub_bitmap>(AllegroLibrary, nameof(al_is_sub_bitmap));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_parent_bitmap(IntPtr bitmap);

    public static al_get_parent_bitmap AlGetParentBitmap =
        NativeInterop.LoadFunction<al_get_parent_bitmap>(AllegroLibrary, nameof(al_get_parent_bitmap));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_bitmap_x(IntPtr bitmap);

    public static al_get_bitmap_x AlGetBitmapX =
        NativeInterop.LoadFunction<al_get_bitmap_x>(AllegroLibrary, nameof(al_get_bitmap_x));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_bitmap_y(IntPtr bitmap);

    public static al_get_bitmap_y AlGetBitmapY =
        NativeInterop.LoadFunction<al_get_bitmap_y>(AllegroLibrary, nameof(al_get_bitmap_y));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_reparent_bitmap(IntPtr bitmap, IntPtr parent, int x, int y, int w, int h);

    public static al_reparent_bitmap AlReparentBitmap =
        NativeInterop.LoadFunction<al_reparent_bitmap>(AllegroLibrary, nameof(al_reparent_bitmap));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_clear_to_color(AllegroColor color);

    public static al_clear_to_color AlClearToColor =
        NativeInterop.LoadFunction<al_clear_to_color>(AllegroLibrary, nameof(al_clear_to_color));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_clear_depth_buffer(float z);

    public static al_clear_depth_buffer AlClearDepthBuffer =
        NativeInterop.LoadFunction<al_clear_depth_buffer>(AllegroLibrary, nameof(al_clear_depth_buffer));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_draw_bitmap(IntPtr bitmap, float dx, float dy, int flags);

    public static al_draw_bitmap AlDrawBitmap =
        NativeInterop.LoadFunction<al_draw_bitmap>(AllegroLibrary, nameof(al_draw_bitmap));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_draw_tinted_bitmap(IntPtr bitmap, AllegroColor tint, float dx, float dy, int flags);

    public static al_draw_tinted_bitmap AlDrawTintedBitmap =
        NativeInterop.LoadFunction<al_draw_tinted_bitmap>(AllegroLibrary, nameof(al_draw_tinted_bitmap));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_draw_bitmap_region(IntPtr bitmap, float sx, float sy, float sw, float sh, float dx, float dy, int flags);

    public static al_draw_bitmap_region AlDrawBitmapRegion =
        NativeInterop.LoadFunction<al_draw_bitmap_region>(AllegroLibrary, nameof(al_draw_bitmap_region));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_draw_tinted_bitmap_region(IntPtr bitmap, AllegroColor tint, float sx, float sy, float sw, float sh, float dx, float dy, int flags);

    public static al_draw_tinted_bitmap_region AlDrawTintedBitmapRegion =
        NativeInterop.LoadFunction<al_draw_tinted_bitmap_region>(AllegroLibrary, nameof(al_draw_tinted_bitmap_region));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_draw_pixel(float x, float y, AllegroColor color);

    public static al_draw_pixel AlDrawPixel =
        NativeInterop.LoadFunction<al_draw_pixel>(AllegroLibrary, nameof(al_draw_pixel));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_draw_rotated_bitmap(IntPtr bitmap, float cx, float cy, float dx, float dy, float angle, int flags);

    public static al_draw_rotated_bitmap AlDrawRotatedBitmap =
        NativeInterop.LoadFunction<al_draw_rotated_bitmap>(AllegroLibrary, nameof(al_draw_rotated_bitmap));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_draw_tinted_rotated_bitmap(IntPtr bitmap, AllegroColor tint, float cx, float cy, float dx, float dy, float angle, int flags);

    public static al_draw_tinted_rotated_bitmap AlDrawTintedRotatedBitmap =
        NativeInterop.LoadFunction<al_draw_tinted_rotated_bitmap>(AllegroLibrary, nameof(al_draw_tinted_rotated_bitmap));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_draw_scaled_rotated_bitmap(IntPtr bitmap, float cx, float cy, float dx, float dy, float xscale, float yscale, float angle, int flags);

    public static al_draw_scaled_rotated_bitmap AlDrawScaledRotatedBitmap =
        NativeInterop.LoadFunction<al_draw_scaled_rotated_bitmap>(AllegroLibrary, nameof(al_draw_scaled_rotated_bitmap));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_draw_tinted_scaled_rotated_bitmap(IntPtr bitmap, AllegroColor tint, float cx, float cy, float dx, float dy, float xscale, float yscale, float angle, int flags);

    public static al_draw_tinted_scaled_rotated_bitmap AlDrawTintedScaledRotatedBitmap =
        NativeInterop.LoadFunction<al_draw_tinted_scaled_rotated_bitmap>(AllegroLibrary, nameof(al_draw_tinted_scaled_rotated_bitmap));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_draw_tinted_scaled_rotated_bitmap_region(IntPtr bitmap, float sx, float sy, float sw, float sh, AllegroColor tint, float cx, float cy, float dx, float dy, float xscale, float yscale, float angle, int flags);

    public static al_draw_tinted_scaled_rotated_bitmap_region AlDrawTintedScaledRotatedBitmapRegion =
        NativeInterop.LoadFunction<al_draw_tinted_scaled_rotated_bitmap_region>(AllegroLibrary, nameof(al_draw_tinted_scaled_rotated_bitmap_region));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_draw_scaled_bitmap(IntPtr bitmap, float sx, float sy, float sw, float sh, float dx, float dy, float dw, float dh, int flags);

    public static al_draw_scaled_bitmap AlDrawScaledBitmap =
        NativeInterop.LoadFunction<al_draw_scaled_bitmap>(AllegroLibrary, nameof(al_draw_scaled_bitmap));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_draw_tinted_scaled_bitmap(IntPtr bitmap, AllegroColor tint, float sx, float sy, float sw, float sh, float dx, float dy, float dw, float dh, int flags);

    public static al_draw_tinted_scaled_bitmap AlDrawTintedScaledBitmap =
        NativeInterop.LoadFunction<al_draw_tinted_scaled_bitmap>(AllegroLibrary, nameof(al_draw_tinted_scaled_bitmap));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_target_bitmap();

    public static al_get_target_bitmap AlGetTargetBitmap =
        NativeInterop.LoadFunction<al_get_target_bitmap>(AllegroLibrary, nameof(al_get_target_bitmap));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_put_pixel(int x, int y, AllegroColor color);

    public static al_put_pixel AlPutPixel =
        NativeInterop.LoadFunction<al_put_pixel>(AllegroLibrary, nameof(al_put_pixel));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_put_blended_pixel(int x, int y, AllegroColor color);

    public static al_put_blended_pixel AlPutBlendedPixel =
        NativeInterop.LoadFunction<al_put_blended_pixel>(AllegroLibrary, nameof(al_put_blended_pixel));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_set_target_bitmap(IntPtr bitmap);

    public static al_set_target_bitmap AlSetTargetBitmap =
        NativeInterop.LoadFunction<al_set_target_bitmap>(AllegroLibrary, nameof(al_set_target_bitmap));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_set_target_backbuffer(IntPtr display);

    public static al_set_target_backbuffer AlSetTargetBackbuffer =
        NativeInterop.LoadFunction<al_set_target_backbuffer>(AllegroLibrary, nameof(al_set_target_backbuffer));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_current_display();

    public static al_get_current_display AlGetCurrentDisplay =
        NativeInterop.LoadFunction<al_get_current_display>(AllegroLibrary, nameof(al_get_current_display));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_get_blender(ref int op, ref int src, ref int dst);

    public static al_get_blender AlGetBlender =
        NativeInterop.LoadFunction<al_get_blender>(AllegroLibrary, nameof(al_get_blender));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_get_separate_blender(ref int op, ref int src, ref int dst, ref int alpha_op, ref int alpha_src, ref int alpha_dst);

    public static al_get_separate_blender AlGetSeparateBlender =
        NativeInterop.LoadFunction<al_get_separate_blender>(AllegroLibrary, nameof(al_get_separate_blender));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate AllegroColor al_get_blend_color();

    public static al_get_blend_color AlGetBlendColor =
        NativeInterop.LoadFunction<al_get_blend_color>(AllegroLibrary, nameof(al_get_blend_color));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_set_blender(int op, int src, int dst);

    public static al_set_blender AlSetBlender =
        NativeInterop.LoadFunction<al_set_blender>(AllegroLibrary, nameof(al_set_blender));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_set_separate_blender(int op, int src, int dst, int alpha_op, int alpha_src, int alpha_dst);

    public static al_set_separate_blender AlSetSeparateBlender =
        NativeInterop.LoadFunction<al_set_separate_blender>(AllegroLibrary, nameof(al_set_separate_blender));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_set_blend_color(AllegroColor color);

    public static al_set_blend_color AlSetBlendColor =
        NativeInterop.LoadFunction<al_set_blend_color>(AllegroLibrary, nameof(al_set_blend_color));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_get_clipping_rectangle(ref int x, ref int y, ref int w, ref int h);

    public static al_get_clipping_rectangle AlGetClippingRectangle =
        NativeInterop.LoadFunction<al_get_clipping_rectangle>(AllegroLibrary, nameof(al_get_clipping_rectangle));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_set_clipping_rectangle(int x, int y, int width, int height);

    public static al_set_clipping_rectangle AlSetClippingRectangle =
        NativeInterop.LoadFunction<al_set_clipping_rectangle>(AllegroLibrary, nameof(al_set_clipping_rectangle));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_reset_clipping_rectangle();

    public static al_reset_clipping_rectangle AlResetClippingRectangle =
        NativeInterop.LoadFunction<al_reset_clipping_rectangle>(AllegroLibrary, nameof(al_reset_clipping_rectangle));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_convert_mask_to_alpha(IntPtr bitmap, AllegroColor mask_color);

    public static al_convert_mask_to_alpha AlConvertMaskToAlpha =
        NativeInterop.LoadFunction<al_convert_mask_to_alpha>(AllegroLibrary, nameof(al_convert_mask_to_alpha));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_hold_bitmap_drawing([MarshalAs(UnmanagedType.U1)] bool hold);

    public static al_hold_bitmap_drawing AlHoldBitmapDrawing =
        NativeInterop.LoadFunction<al_hold_bitmap_drawing>(AllegroLibrary, nameof(al_hold_bitmap_drawing));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_is_bitmap_drawing_held();

    public static al_is_bitmap_drawing_held AlIsBitmapDrawingHeld =
        NativeInterop.LoadFunction<al_is_bitmap_drawing_held>(AllegroLibrary, nameof(al_is_bitmap_drawing_held));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_register_bitmap_loader(IntPtr extension, RegisterBitmapLoader loader);

    public static al_register_bitmap_loader AlRegisterBitmapLoader =
        NativeInterop.LoadFunction<al_register_bitmap_loader>(AllegroLibrary, nameof(al_register_bitmap_loader));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_register_bitmap_saver(IntPtr extension, RegisterBitmapSaver saver);

    public static al_register_bitmap_saver AlRegisterBitmapSaver =
        NativeInterop.LoadFunction<al_register_bitmap_saver>(AllegroLibrary, nameof(al_register_bitmap_saver));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_register_bitmap_loader_f(IntPtr extension, RegisterBitmapLoaderF fs_loader);

    public static al_register_bitmap_loader_f AlRegisterBitmapLoaderF =
        NativeInterop.LoadFunction<al_register_bitmap_loader_f>(AllegroLibrary, nameof(al_register_bitmap_loader_f));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_register_bitmap_saver_f(IntPtr extension, RegisterBitmapSaverF fs_saver);

    public static al_register_bitmap_saver_f AlRegisterBitmapSaverF =
        NativeInterop.LoadFunction<al_register_bitmap_saver_f>(AllegroLibrary, nameof(al_register_bitmap_saver_f));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_load_bitmap(IntPtr filename);

    public static al_load_bitmap AlLoadBitmap =
        NativeInterop.LoadFunction<al_load_bitmap>(AllegroLibrary, nameof(al_load_bitmap));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_load_bitmap_flags(IntPtr filename, int flags);

    public static al_load_bitmap_flags AlLoadBitmapFlags =
        NativeInterop.LoadFunction<al_load_bitmap_flags>(AllegroLibrary, nameof(al_load_bitmap_flags));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_load_bitmap_f(IntPtr fp, IntPtr ident);

    public static al_load_bitmap_f AlLoadBitmapF =
        NativeInterop.LoadFunction<al_load_bitmap_f>(AllegroLibrary, nameof(al_load_bitmap_f));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_load_bitmap_flags_f(IntPtr fp, IntPtr ident, int flags);

    public static al_load_bitmap_flags_f AlLoadBitmapFlagsF =
        NativeInterop.LoadFunction<al_load_bitmap_flags_f>(AllegroLibrary, nameof(al_load_bitmap_flags_f));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_save_bitmap(IntPtr filename, IntPtr bitmap);

    public static al_save_bitmap AlSaveBitmap =
        NativeInterop.LoadFunction<al_save_bitmap>(AllegroLibrary, nameof(al_save_bitmap));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_save_bitmap_f(IntPtr fp, IntPtr ident, IntPtr bitmap);

    public static al_save_bitmap_f AlSaveBitmapF =
        NativeInterop.LoadFunction<al_save_bitmap_f>(AllegroLibrary, nameof(al_save_bitmap_f));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_register_bitmap_identifier(IntPtr extension, RegisterBitmapIdentifier identifier);

    public static al_register_bitmap_identifier AlRegisterBitmapIdentifier =
        NativeInterop.LoadFunction<al_register_bitmap_identifier>(AllegroLibrary, nameof(al_register_bitmap_identifier));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_identify_bitmap(IntPtr filename);

    public static al_identify_bitmap AlIdentifyBitmap =
        NativeInterop.LoadFunction<al_identify_bitmap>(AllegroLibrary, nameof(al_identify_bitmap));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_identify_bitmap_f(IntPtr fp);

    public static al_identify_bitmap_f AlIdentifyBitmapF =
        NativeInterop.LoadFunction<al_identify_bitmap_f>(AllegroLibrary, nameof(al_identify_bitmap_f));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_set_render_state(int state, int value);

    public static al_set_render_state AlSetRenderState =
        NativeInterop.LoadFunction<al_set_render_state>(AllegroLibrary, nameof(al_set_render_state));

    #endregion Graphics routines

    #region Image IO routines

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_init_image_addon();

    public static al_init_image_addon AlInitImageAddon =
        NativeInterop.LoadFunction<al_init_image_addon>(AllegroLibrary, nameof(al_init_image_addon));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_is_image_addon_initialized();

    public static al_is_image_addon_initialized AlIsImageAddonInitialized =
        NativeInterop.LoadFunction<al_is_image_addon_initialized>(AllegroLibrary, nameof(al_is_image_addon_initialized));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_shutdown_image_addon();

    public static al_shutdown_image_addon AlShutdownImageAddon =
        NativeInterop.LoadFunction<al_shutdown_image_addon>(AllegroLibrary, nameof(al_shutdown_image_addon));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate uint al_get_allegro_image_version();

    public static al_get_allegro_image_version AlGetAllegroImageVersion =
        NativeInterop.LoadFunction<al_get_allegro_image_version>(AllegroLibrary, nameof(al_get_allegro_image_version));

    #endregion

    #region Joystick routines

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_install_joystick();

    public static al_install_joystick AlInstallJoystick =
        NativeInterop.LoadFunction<al_install_joystick>(AllegroLibrary, nameof(al_install_joystick));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_uninstall_joystick();

    public static al_uninstall_joystick AlUninstallJoystick =
        NativeInterop.LoadFunction<al_uninstall_joystick>(AllegroLibrary, nameof(al_uninstall_joystick));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_is_joystick_installed();

    public static al_is_joystick_installed AlIsJoystickInstalled =
        NativeInterop.LoadFunction<al_is_joystick_installed>(AllegroLibrary, nameof(al_is_joystick_installed));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_reconfigure_joysticks();

    public static al_reconfigure_joysticks AlReconfigureJoysticks =
        NativeInterop.LoadFunction<al_reconfigure_joysticks>(AllegroLibrary, nameof(al_reconfigure_joysticks));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_num_joysticks();

    public static al_get_num_joysticks AlGetNumJoysticks =
        NativeInterop.LoadFunction<al_get_num_joysticks>(AllegroLibrary, nameof(al_get_num_joysticks));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_joystick(int num);

    public static al_get_joystick AlGetJoystick =
        NativeInterop.LoadFunction<al_get_joystick>(AllegroLibrary, nameof(al_get_joystick));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_release_joystick(IntPtr joy);

    public static al_release_joystick AlReleaseJoystick =
        NativeInterop.LoadFunction<al_release_joystick>(AllegroLibrary, nameof(al_release_joystick));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_get_joystick_active(IntPtr joy);

    public static al_get_joystick_active AlGetJoystickActive =
        NativeInterop.LoadFunction<al_get_joystick_active>(AllegroLibrary, nameof(al_get_joystick_active));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_joystick_name(IntPtr joy);

    public static al_get_joystick_name AlGetJoystickName =
        NativeInterop.LoadFunction<al_get_joystick_name>(AllegroLibrary, nameof(al_get_joystick_name));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_joystick_stick_name(IntPtr joy, int stick);

    public static al_get_joystick_stick_name AlGetJoystickStickName =
        NativeInterop.LoadFunction<al_get_joystick_stick_name>(AllegroLibrary, nameof(al_get_joystick_stick_name));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_joystick_axis_name(IntPtr joy, int stick, int axis);

    public static al_get_joystick_axis_name AlGetJoystickAxisName =
        NativeInterop.LoadFunction<al_get_joystick_axis_name>(AllegroLibrary, nameof(al_get_joystick_axis_name));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_joystick_button_name(IntPtr joy, int button);

    public static al_get_joystick_button_name AlGetJoystickButtonName =
        NativeInterop.LoadFunction<al_get_joystick_button_name>(AllegroLibrary, nameof(al_get_joystick_button_name));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_joystick_stick_flags(IntPtr joy, int stick);

    public static al_get_joystick_stick_flags AlGetJoystickStickFlags =
        NativeInterop.LoadFunction<al_get_joystick_stick_flags>(AllegroLibrary, nameof(al_get_joystick_stick_flags));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_joystick_num_sticks(IntPtr joy);

    public static al_get_joystick_num_sticks AlGetJoystickNumSticks =
        NativeInterop.LoadFunction<al_get_joystick_num_sticks>(AllegroLibrary, nameof(al_get_joystick_num_sticks));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_joystick_num_axes(IntPtr joy, int stick);

    public static al_get_joystick_num_axes AlGetJoystickNumAxes =
        NativeInterop.LoadFunction<al_get_joystick_num_axes>(AllegroLibrary, nameof(al_get_joystick_num_axes));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_joystick_num_buttons(IntPtr joy);

    public static al_get_joystick_num_buttons AlGetJoystickNumButtons =
        NativeInterop.LoadFunction<al_get_joystick_num_buttons>(AllegroLibrary, nameof(al_get_joystick_num_buttons));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_get_joystick_state(IntPtr joy, ref AllegroJoystickState.NativeJoystickState ret_state);

    public static al_get_joystick_state AlGetJoystickState =
        NativeInterop.LoadFunction<al_get_joystick_state>(AllegroLibrary, nameof(al_get_joystick_state));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_joystick_event_source();

    public static al_get_joystick_event_source AlGetJoystickEventSource =
        NativeInterop.LoadFunction<al_get_joystick_event_source>(AllegroLibrary, nameof(al_get_joystick_event_source));

    #endregion Joystick routines

    #region Keyboard routines

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_install_keyboard();

    public static al_install_keyboard AlInstallKeyboard =
        NativeInterop.LoadFunction<al_install_keyboard>(AllegroLibrary, nameof(al_install_keyboard));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_is_keyboard_installed();

    public static al_is_keyboard_installed AlIsKeyboardInstalled =
        NativeInterop.LoadFunction<al_is_keyboard_installed>(AllegroLibrary, nameof(al_is_keyboard_installed));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_uninstall_keyboard();

    public static al_uninstall_keyboard AlUninstallKeyboard =
        NativeInterop.LoadFunction<al_uninstall_keyboard>(AllegroLibrary, nameof(al_uninstall_keyboard));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_get_keyboard_state(ref AllegroKeyboardState.NativeKeyboardState ret_state);

    public static al_get_keyboard_state AlGetKeyboardState =
        NativeInterop.LoadFunction<al_get_keyboard_state>(AllegroLibrary, nameof(al_get_keyboard_state));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_key_down(ref AllegroKeyboardState.NativeKeyboardState state, int keycode);

    public static al_key_down AlKeyDown =
        NativeInterop.LoadFunction<al_key_down>(AllegroLibrary, nameof(al_key_down));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_keycode_to_name(int keycode);

    public static al_keycode_to_name AlKeycodeToName =
        NativeInterop.LoadFunction<al_keycode_to_name>(AllegroLibrary, nameof(al_keycode_to_name));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_set_keyboard_leds(int leds);

    public static al_set_keyboard_leds AlSetKeyboardLeds =
        NativeInterop.LoadFunction<al_set_keyboard_leds>(AllegroLibrary, nameof(al_set_keyboard_leds));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_keyboard_event_source();

    public static al_get_keyboard_event_source AlGetKeyboardEventSource =
        NativeInterop.LoadFunction<al_get_keyboard_event_source>(AllegroLibrary, nameof(al_get_keyboard_event_source));

    #endregion Keyboard routines

    #region Memfile routines

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_open_memfile(IntPtr mem, long size, IntPtr mode);

    public static al_open_memfile AlOpenMemfile = NativeInterop.LoadFunction<al_open_memfile>(AllegroLibrary);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate uint al_get_allegro_memfile_version();

    public static al_get_allegro_memfile_version AlGetAllegroMemfileVersion = NativeInterop.LoadFunction<al_get_allegro_memfile_version>(AllegroLibrary);

    #endregion

    #region Memory routines

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_malloc_with_context(UIntPtr n, int line, IntPtr file, IntPtr func);

    public static al_malloc_with_context AlMallocWithContext =
        NativeInterop.LoadFunction<al_malloc_with_context>(AllegroLibrary, nameof(al_malloc_with_context));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_free_with_context(IntPtr ptr, int line, IntPtr file, IntPtr func);

    public static al_free_with_context AlFreeWithContext =
        NativeInterop.LoadFunction<al_free_with_context>(AllegroLibrary, nameof(al_free_with_context));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_realloc_with_context(IntPtr ptr, UIntPtr n, int line, IntPtr file, IntPtr func);

    public static al_realloc_with_context AlReallocWithContext =
        NativeInterop.LoadFunction<al_realloc_with_context>(AllegroLibrary, nameof(al_realloc_with_context));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_calloc_with_context(UIntPtr count, UIntPtr n, int line, IntPtr file, IntPtr func);

    public static al_calloc_with_context AlCallocWithContext =
        NativeInterop.LoadFunction<al_calloc_with_context>(AllegroLibrary, nameof(al_calloc_with_context));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_set_memory_interface(ref AllegroMemoryInterface.NativeMemoryInterface memory_interface);

    public static al_set_memory_interface AlSetMemoryInterface =
        NativeInterop.LoadFunction<al_set_memory_interface>(AllegroLibrary, nameof(al_set_memory_interface));

    #endregion Memory routines

    #region Monitor routines

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_new_display_adapter();

    public static al_get_new_display_adapter AlGetNewDisplayAdapter =
        NativeInterop.LoadFunction<al_get_new_display_adapter>(AllegroLibrary, nameof(al_get_new_display_adapter));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_set_new_display_adapter(int adapter);

    public static al_set_new_display_adapter AlSetNewDisplayAdapter =
        NativeInterop.LoadFunction<al_set_new_display_adapter>(AllegroLibrary, nameof(al_set_new_display_adapter));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_get_monitor_info(int adapter, ref AllegroMonitorInfo.NativeMonitorInfo info);

    public static al_get_monitor_info AlGetMonitorInfo =
        NativeInterop.LoadFunction<al_get_monitor_info>(AllegroLibrary, nameof(al_get_monitor_info));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_monitor_dpi(int adapter);

    public static al_get_monitor_dpi AlGetMonitorDpi =
        NativeInterop.LoadFunction<al_get_monitor_dpi>(AllegroLibrary, nameof(al_get_monitor_dpi));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_num_video_adapters();

    public static al_get_num_video_adapters AlGetNumVideoAdapters =
        NativeInterop.LoadFunction<al_get_num_video_adapters>(AllegroLibrary, nameof(al_get_num_video_adapters));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_monitor_refresh_rate(int adapter);

    public static al_get_monitor_refresh_rate AlGetMonitorRefreshRate =
        NativeInterop.LoadFunction<al_get_monitor_refresh_rate>(AllegroLibrary, nameof(al_get_monitor_refresh_rate));

    #endregion Monitor routines

    #region Mouse routines

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_install_mouse();

    public static al_install_mouse AlInstallMouse =
        NativeInterop.LoadFunction<al_install_mouse>(AllegroLibrary, nameof(al_install_mouse));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_is_mouse_installed();

    public static al_is_mouse_installed AlIsMouseInstalled =
        NativeInterop.LoadFunction<al_is_mouse_installed>(AllegroLibrary, nameof(al_is_mouse_installed));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_uninstall_mouse();

    public static al_uninstall_mouse AlUninstallMouse =
        NativeInterop.LoadFunction<al_uninstall_mouse>(AllegroLibrary, nameof(al_uninstall_mouse));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate uint al_get_mouse_num_axes();

    public static al_get_mouse_num_axes AlGetMouseNumAxes =
        NativeInterop.LoadFunction<al_get_mouse_num_axes>(AllegroLibrary, nameof(al_get_mouse_num_axes));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate uint al_get_mouse_num_buttons();

    public static al_get_mouse_num_buttons AlGetMouseNumButtons =
        NativeInterop.LoadFunction<al_get_mouse_num_buttons>(AllegroLibrary, nameof(al_get_mouse_num_buttons));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_get_mouse_state(ref AllegroMouseState.NativeMouseState ret_state);

    public static al_get_mouse_state AlGetMouseState =
        NativeInterop.LoadFunction<al_get_mouse_state>(AllegroLibrary, nameof(al_get_mouse_state));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_mouse_state_axis(ref AllegroMouseState.NativeMouseState ret_state, int axis);

    public static al_get_mouse_state_axis AlGetMouseStateAxis =
        NativeInterop.LoadFunction<al_get_mouse_state_axis>(AllegroLibrary, nameof(al_get_mouse_state_axis));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_mouse_button_down(ref AllegroMouseState.NativeMouseState ret_state, int button);

    public static al_mouse_button_down AlMouseButtonDown =
        NativeInterop.LoadFunction<al_mouse_button_down>(AllegroLibrary, nameof(al_mouse_button_down));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_set_mouse_xy(IntPtr display, int x, int y);

    public static al_set_mouse_xy AlSetMouseXY =
        NativeInterop.LoadFunction<al_set_mouse_xy>(AllegroLibrary, nameof(al_set_mouse_xy));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_set_mouse_z(int z);

    public static al_set_mouse_z AlSetMouseZ =
        NativeInterop.LoadFunction<al_set_mouse_z>(AllegroLibrary, nameof(al_set_mouse_z));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_set_mouse_w(int w);

    public static al_set_mouse_w AlSetMouseW =
        NativeInterop.LoadFunction<al_set_mouse_w>(AllegroLibrary, nameof(al_set_mouse_w));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_set_mouse_axis(int which, int value);

    public static al_set_mouse_axis AlSetMouseAxis =
        NativeInterop.LoadFunction<al_set_mouse_axis>(AllegroLibrary, nameof(al_set_mouse_axis));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_mouse_event_source();

    public static al_get_mouse_event_source AlGetMouseEventSource =
        NativeInterop.LoadFunction<al_get_mouse_event_source>(AllegroLibrary, nameof(al_get_mouse_event_source));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_set_mouse_wheel_precision(int precision);

    public static al_set_mouse_wheel_precision AlSetMouseWheelPrecision =
        NativeInterop.LoadFunction<al_set_mouse_wheel_precision>(AllegroLibrary, nameof(al_set_mouse_wheel_precision));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_mouse_wheel_precision();

    public static al_get_mouse_wheel_precision AlGetMouseWheelPrecision =
        NativeInterop.LoadFunction<al_get_mouse_wheel_precision>(AllegroLibrary, nameof(al_get_mouse_wheel_precision));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_create_mouse_cursor(IntPtr bmp, int x_focus, int y_focus);

    public static al_create_mouse_cursor AlCreateMouseCursor =
        NativeInterop.LoadFunction<al_create_mouse_cursor>(AllegroLibrary, nameof(al_create_mouse_cursor));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_destroy_mouse_cursor(IntPtr cursor);

    public static al_destroy_mouse_cursor AlDestroyMouseCursor =
        NativeInterop.LoadFunction<al_destroy_mouse_cursor>(AllegroLibrary, nameof(al_destroy_mouse_cursor));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_set_mouse_cursor(IntPtr display, IntPtr cursor);

    public static al_set_mouse_cursor AlSetMouseCursor =
        NativeInterop.LoadFunction<al_set_mouse_cursor>(AllegroLibrary, nameof(al_set_mouse_cursor));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_set_system_mouse_cursor(IntPtr display, int cursor_id);

    public static al_set_system_mouse_cursor AlSetSystemMouseCursor =
        NativeInterop.LoadFunction<al_set_system_mouse_cursor>(AllegroLibrary, nameof(al_set_system_mouse_cursor));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_get_mouse_cursor_position(ref int ret_x, ref int ret_y);

    public static al_get_mouse_cursor_position AlGetMouseCursorPosition =
        NativeInterop.LoadFunction<al_get_mouse_cursor_position>(AllegroLibrary, nameof(al_get_mouse_cursor_position));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_hide_mouse_cursor(IntPtr display);

    public static al_hide_mouse_cursor AlHideMouseCursor =
        NativeInterop.LoadFunction<al_hide_mouse_cursor>(AllegroLibrary, nameof(al_hide_mouse_cursor));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_show_mouse_cursor(IntPtr display);

    public static al_show_mouse_cursor AlShowMouseCursor =
        NativeInterop.LoadFunction<al_show_mouse_cursor>(AllegroLibrary, nameof(al_show_mouse_cursor));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_grab_mouse(IntPtr display);

    public static al_grab_mouse AlGrabMouse =
        NativeInterop.LoadFunction<al_grab_mouse>(AllegroLibrary, nameof(al_grab_mouse));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_ungrab_mouse();

    public static al_ungrab_mouse AlUngrabMouse =
        NativeInterop.LoadFunction<al_ungrab_mouse>(AllegroLibrary, nameof(al_ungrab_mouse));

    #endregion Mouse routines

    #region Native dialog routines

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_init_native_dialog_addon();

    public static al_init_native_dialog_addon AlInitNativeDialogAddon =
        NativeInterop.LoadFunction<al_init_native_dialog_addon>(AllegroLibrary, nameof(al_init_native_dialog_addon));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_is_native_dialog_addon_initialized();

    public static al_is_native_dialog_addon_initialized AlIsNativeDialogAddonInitialized =
        NativeInterop.LoadFunction<al_is_native_dialog_addon_initialized>(AllegroLibrary, nameof(al_is_native_dialog_addon_initialized));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_shutdown_native_dialog_addon();

    public static al_shutdown_native_dialog_addon AlShutdownNativeDialogAddon =
        NativeInterop.LoadFunction<al_shutdown_native_dialog_addon>(AllegroLibrary, nameof(al_shutdown_native_dialog_addon));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_create_native_file_dialog(IntPtr initial_path, IntPtr title, IntPtr patterns, int mode);

    public static al_create_native_file_dialog AlCreateNativeFileDialog =
        NativeInterop.LoadFunction<al_create_native_file_dialog>(AllegroLibrary, nameof(al_create_native_file_dialog));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_show_native_file_dialog(IntPtr display, IntPtr dialog);

    public static al_show_native_file_dialog AlShowNativeFileDialog =
        NativeInterop.LoadFunction<al_show_native_file_dialog>(AllegroLibrary, nameof(al_show_native_file_dialog));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_native_file_dialog_count(IntPtr dialog);

    public static al_get_native_file_dialog_count AlGetNativeFileDialogCount =
        NativeInterop.LoadFunction<al_get_native_file_dialog_count>(AllegroLibrary, nameof(al_get_native_file_dialog_count));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_native_file_dialog_path(IntPtr dialog, ulong i);

    public static al_get_native_file_dialog_path AlGetNativeFileDialogPath =
        NativeInterop.LoadFunction<al_get_native_file_dialog_path>(AllegroLibrary, nameof(al_get_native_file_dialog_path));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_destroy_native_file_dialog(IntPtr dialog);

    public static al_destroy_native_file_dialog AlDestroyNativeFileDialog =
        NativeInterop.LoadFunction<al_destroy_native_file_dialog>(AllegroLibrary, nameof(al_destroy_native_file_dialog));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_show_native_message_box(IntPtr display, IntPtr title, IntPtr heading, IntPtr text, IntPtr buttons, int flags);

    public static al_show_native_message_box AlShowNativeMessageBox =
        NativeInterop.LoadFunction<al_show_native_message_box>(AllegroLibrary, nameof(al_show_native_message_box));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_open_native_text_log(IntPtr title, int flags);

    public static al_open_native_text_log AlOpenNativeTextLog =
        NativeInterop.LoadFunction<al_open_native_text_log>(AllegroLibrary, nameof(al_open_native_text_log));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_close_native_text_log(IntPtr textlog);

    public static al_close_native_text_log AlCloseNativeTextLog =
        NativeInterop.LoadFunction<al_close_native_text_log>(AllegroLibrary, nameof(al_close_native_text_log));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_append_native_text_log(IntPtr textlog, IntPtr format);

    public static al_append_native_text_log AlAppendNativeTextLog =
        NativeInterop.LoadFunction<al_append_native_text_log>(AllegroLibrary, nameof(al_append_native_text_log));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_native_text_log_event_source(IntPtr textlog);

    public static al_get_native_text_log_event_source AlGetNativeTextLogEventSource =
        NativeInterop.LoadFunction<al_get_native_text_log_event_source>(AllegroLibrary, nameof(al_get_native_text_log_event_source));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate uint al_get_allegro_native_dialog_version();

    public static al_get_allegro_native_dialog_version AlGetAllegroNativeDialogVersion =
        NativeInterop.LoadFunction<al_get_allegro_native_dialog_version>(AllegroLibrary, nameof(al_get_allegro_native_dialog_version));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_create_menu();

    public static al_create_menu AlCreateMenu =
        NativeInterop.LoadFunction<al_create_menu>(AllegroLibrary, nameof(al_create_menu));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_create_popup_menu();

    public static al_create_popup_menu AlCreatePopupMenu =
        NativeInterop.LoadFunction<al_create_popup_menu>(AllegroLibrary, nameof(al_create_popup_menu));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_build_menu(IntPtr info);

    public static al_build_menu AlBuildMenu =
        NativeInterop.LoadFunction<al_build_menu>(AllegroLibrary, nameof(al_build_menu));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_append_menu_item(IntPtr parent, IntPtr title, ushort id, int flags, IntPtr icon, IntPtr submenu);

    public static al_append_menu_item AlAppendMenuItem =
        NativeInterop.LoadFunction<al_append_menu_item>(AllegroLibrary, nameof(al_append_menu_item));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_insert_menu_item(IntPtr parent, int pos, IntPtr title, ushort id, int flags, IntPtr icon, IntPtr submenu);

    public static al_insert_menu_item AlInsertMenuItem =
        NativeInterop.LoadFunction<al_insert_menu_item>(AllegroLibrary, nameof(al_insert_menu_item));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_remove_menu_item(IntPtr menu, int pos);

    public static al_remove_menu_item AlRemoveMenuItem =
        NativeInterop.LoadFunction<al_remove_menu_item>(AllegroLibrary, nameof(al_remove_menu_item));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_clone_menu(IntPtr menu);

    public static al_clone_menu AlCloneMenu =
        NativeInterop.LoadFunction<al_clone_menu>(AllegroLibrary, nameof(al_clone_menu));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_clone_menu_for_popup(IntPtr menu);

    public static al_clone_menu_for_popup AlCloneMenuForPopup =
        NativeInterop.LoadFunction<al_clone_menu_for_popup>(AllegroLibrary, nameof(al_clone_menu_for_popup));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_destroy_menu(IntPtr menu);

    public static al_destroy_menu AlDestroyMenu =
        NativeInterop.LoadFunction<al_destroy_menu>(AllegroLibrary, nameof(al_destroy_menu));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_menu_item_caption(IntPtr menu, int pos);

    public static al_get_menu_item_caption AlGetMenuItemCaption =
        NativeInterop.LoadFunction<al_get_menu_item_caption>(AllegroLibrary, nameof(al_get_menu_item_caption));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_set_menu_item_caption(IntPtr menu, int pos, IntPtr caption);

    public static al_set_menu_item_caption AlSetMenuItemCaption =
        NativeInterop.LoadFunction<al_set_menu_item_caption>(AllegroLibrary, nameof(al_set_menu_item_caption));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_menu_item_flags(IntPtr menu, int pos);

    public static al_get_menu_item_flags AlGetMenuItemFlags =
        NativeInterop.LoadFunction<al_get_menu_item_flags>(AllegroLibrary, nameof(al_get_menu_item_flags));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_set_menu_item_flags(IntPtr menu, int pos, int flags);

    public static al_set_menu_item_flags AlSetMenuItemFlags =
        NativeInterop.LoadFunction<al_set_menu_item_flags>(AllegroLibrary, nameof(al_set_menu_item_flags));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_menu_item_icon(IntPtr menu, int pos);

    public static al_get_menu_item_icon AlGetMenuItemIcon =
        NativeInterop.LoadFunction<al_get_menu_item_icon>(AllegroLibrary, nameof(al_get_menu_item_icon));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_set_menu_item_icon(IntPtr menu, int pos, IntPtr icon);

    public static al_set_menu_item_icon AlSetMenuItemIcon =
        NativeInterop.LoadFunction<al_set_menu_item_icon>(AllegroLibrary, nameof(al_set_menu_item_icon));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_find_menu(IntPtr haystack, ushort id);

    public static al_find_menu AlFindMenu =
        NativeInterop.LoadFunction<al_find_menu>(AllegroLibrary, nameof(al_find_menu));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_find_menu_item(IntPtr haystack, ushort id, ref IntPtr menu, ref int index);

    public static al_find_menu_item AlFindMenuItem =
        NativeInterop.LoadFunction<al_find_menu_item>(AllegroLibrary, nameof(al_find_menu_item));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_default_menu_event_source();

    public static al_get_default_menu_event_source AlGetDefaultMenuEventSource =
        NativeInterop.LoadFunction<al_get_default_menu_event_source>(AllegroLibrary, nameof(al_get_default_menu_event_source));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_enable_menu_event_source(IntPtr menu);

    public static al_enable_menu_event_source AlEnableMenuEventSource =
        NativeInterop.LoadFunction<al_enable_menu_event_source>(AllegroLibrary, nameof(al_enable_menu_event_source));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_disable_menu_event_source(IntPtr menu);

    public static al_disable_menu_event_source AlDisableMenuEventSource =
        NativeInterop.LoadFunction<al_disable_menu_event_source>(AllegroLibrary, nameof(al_disable_menu_event_source));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_display_menu(IntPtr display);

    public static al_get_display_menu AlGetDisplayMenu =
        NativeInterop.LoadFunction<al_get_display_menu>(AllegroLibrary, nameof(al_get_display_menu));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_set_display_menu(IntPtr display, IntPtr menu);

    public static al_set_display_menu AlSetDisplayMenu =
        NativeInterop.LoadFunction<al_set_display_menu>(AllegroLibrary, nameof(al_set_display_menu));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_popup_menu(IntPtr popup, IntPtr display);

    public static al_popup_menu AlPopupMenu =
        NativeInterop.LoadFunction<al_popup_menu>(AllegroLibrary, nameof(al_popup_menu));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_remove_display_menu(IntPtr display);

    public static al_remove_display_menu AlRemoveDisplayMenu =
        NativeInterop.LoadFunction<al_remove_display_menu>(AllegroLibrary, nameof(al_remove_display_menu));

    #endregion Native dialog routines

    #region Path routines

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_create_path(IntPtr str);

    public static al_create_path AlCreatePath =
        NativeInterop.LoadFunction<al_create_path>(AllegroLibrary, nameof(al_create_path));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_create_path_for_directory(IntPtr str);

    public static al_create_path_for_directory AlCreatePathForDirectory =
        NativeInterop.LoadFunction<al_create_path_for_directory>(AllegroLibrary, nameof(al_create_path_for_directory));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_destroy_path(IntPtr path);

    public static al_destroy_path AlDestroyPath =
        NativeInterop.LoadFunction<al_destroy_path>(AllegroLibrary, nameof(al_destroy_path));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_clone_path(IntPtr path);

    public static al_clone_path AlClonePath =
        NativeInterop.LoadFunction<al_clone_path>(AllegroLibrary, nameof(al_clone_path));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_join_paths(IntPtr path, IntPtr tail);

    public static al_join_paths AlJoinPaths =
        NativeInterop.LoadFunction<al_join_paths>(AllegroLibrary, nameof(al_join_paths));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_rebase_path(IntPtr head, IntPtr tail);

    public static al_rebase_path AlRebasePath =
        NativeInterop.LoadFunction<al_rebase_path>(AllegroLibrary, nameof(al_rebase_path));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_path_drive(IntPtr path);

    public static al_get_path_drive AlGetPathDrive =
        NativeInterop.LoadFunction<al_get_path_drive>(AllegroLibrary, nameof(al_get_path_drive));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_path_num_components(IntPtr path);

    public static al_get_path_num_components AlGetPathNumComponents =
        NativeInterop.LoadFunction<al_get_path_num_components>(AllegroLibrary, nameof(al_get_path_num_components));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_path_component(IntPtr path, int i);

    public static al_get_path_component AlGetPathComponent =
        NativeInterop.LoadFunction<al_get_path_component>(AllegroLibrary, nameof(al_get_path_component));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_path_tail(IntPtr path);

    public static al_get_path_tail AlGetPathTail =
        NativeInterop.LoadFunction<al_get_path_tail>(AllegroLibrary, nameof(al_get_path_tail));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_path_filename(IntPtr path);

    public static al_get_path_filename AlGetPathFilename =
        NativeInterop.LoadFunction<al_get_path_filename>(AllegroLibrary, nameof(al_get_path_filename));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_path_basename(IntPtr path);

    public static al_get_path_basename AlGetPathBasename =
        NativeInterop.LoadFunction<al_get_path_basename>(AllegroLibrary, nameof(al_get_path_basename));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_path_extension(IntPtr path);

    public static al_get_path_extension AlGetPathExtension =
        NativeInterop.LoadFunction<al_get_path_extension>(AllegroLibrary, nameof(al_get_path_extension));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_set_path_drive(IntPtr path, IntPtr drive);

    public static al_set_path_drive AlSetPathDrive =
        NativeInterop.LoadFunction<al_set_path_drive>(AllegroLibrary, nameof(al_set_path_drive));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_append_path_component(IntPtr path, IntPtr s);

    public static al_append_path_component AlAppendPathComponent =
        NativeInterop.LoadFunction<al_append_path_component>(AllegroLibrary, nameof(al_append_path_component));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_insert_path_component(IntPtr path, int i, IntPtr s);

    public static al_insert_path_component AlInsertPathComponent =
        NativeInterop.LoadFunction<al_insert_path_component>(AllegroLibrary, nameof(al_insert_path_component));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_replace_path_component(IntPtr path, int i, IntPtr s);

    public static al_replace_path_component AlReplacePathComponent =
        NativeInterop.LoadFunction<al_replace_path_component>(AllegroLibrary, nameof(al_replace_path_component));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_remove_path_component(IntPtr path, int i);

    public static al_remove_path_component AlRemovePathComponent =
        NativeInterop.LoadFunction<al_remove_path_component>(AllegroLibrary, nameof(al_remove_path_component));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_drop_path_tail(IntPtr path);

    public static al_drop_path_tail AlDropPathTail =
        NativeInterop.LoadFunction<al_drop_path_tail>(AllegroLibrary, nameof(al_drop_path_tail));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_set_path_filename(IntPtr path, IntPtr filename);

    public static al_set_path_filename AlSetPathFilename =
        NativeInterop.LoadFunction<al_set_path_filename>(AllegroLibrary, nameof(al_set_path_filename));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_set_path_extension(IntPtr path, IntPtr extension);

    public static al_set_path_extension AlSetPathExtension =
        NativeInterop.LoadFunction<al_set_path_extension>(AllegroLibrary, nameof(al_set_path_extension));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_path_cstr(IntPtr path, char delim);

    public static al_path_cstr AlPathCstr =
        NativeInterop.LoadFunction<al_path_cstr>(AllegroLibrary, nameof(al_path_cstr));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_path_ustr(IntPtr path, char delim);

    public static al_path_ustr AlPathUstr =
        NativeInterop.LoadFunction<al_path_ustr>(AllegroLibrary, nameof(al_path_ustr));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_make_path_canonical(IntPtr path);

    public static al_make_path_canonical AlMakePathCanonical =
        NativeInterop.LoadFunction<al_make_path_canonical>(AllegroLibrary, nameof(al_make_path_canonical));

    #endregion Path routines

    #region Physfs routines

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_set_physfs_file_interface();

    public static al_set_physfs_file_interface AlSetPhysfsFileInterface =
        NativeInterop.LoadFunction<al_set_physfs_file_interface>(AllegroLibrary, nameof(al_set_physfs_file_interface));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate uint al_get_allegro_physfs_version();

    public static al_get_allegro_physfs_version AlGetAllegroPhysfsVersion =
        NativeInterop.LoadFunction<al_get_allegro_physfs_version>(AllegroLibrary, nameof(al_get_allegro_physfs_version));

    #endregion

    #region Platform-specific routines

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_win_window_handle(IntPtr display);

    public static al_get_win_window_handle? AlGetWinWindowHandle = null;

    #endregion

    #region State routines

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_restore_state(ref AllegroState.NativeAllegroState state);

    public static al_restore_state AlRestoreState =
        NativeInterop.LoadFunction<al_restore_state>(AllegroLibrary, nameof(al_restore_state));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_store_state(ref AllegroState.NativeAllegroState state, int flags);

    public static al_store_state AlStoreState =
        NativeInterop.LoadFunction<al_store_state>(AllegroLibrary, nameof(al_store_state));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_errno();

    public static al_get_errno AlGetErrno =
        NativeInterop.LoadFunction<al_get_errno>(AllegroLibrary, nameof(al_get_errno));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_set_errno(int errnum);

    public static al_set_errno AlSetErrno =
        NativeInterop.LoadFunction<al_set_errno>(AllegroLibrary, nameof(al_set_errno));

    #endregion State routines

    #region System routines

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_install_system(int version, AtExitDelegate? atExit);

    public static al_install_system AlInstallSystem =
        NativeInterop.LoadFunction<al_install_system>(AllegroLibrary, nameof(al_install_system));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_uninstall_system();

    public static al_uninstall_system AlUninstallSystem =
        NativeInterop.LoadFunction<al_uninstall_system>(AllegroLibrary, nameof(al_uninstall_system));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_is_system_installed();

    public static al_is_system_installed AlIsSystemInstalled =
        NativeInterop.LoadFunction<al_is_system_installed>(AllegroLibrary, nameof(al_is_system_installed));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate uint al_get_allegro_version();

    public static al_get_allegro_version AlGetAllegroVersion =
        NativeInterop.LoadFunction<al_get_allegro_version>(AllegroLibrary, nameof(al_get_allegro_version));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_standard_path(int id);

    public static al_get_standard_path AlGetStandardPath =
        NativeInterop.LoadFunction<al_get_standard_path>(AllegroLibrary, nameof(al_get_standard_path));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_set_exe_name(IntPtr path);

    public static al_set_exe_name AlSetExeName =
        NativeInterop.LoadFunction<al_set_exe_name>(AllegroLibrary, nameof(al_get_standard_path));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_set_app_name(IntPtr path);

    public static al_set_app_name AlSetAppName =
        NativeInterop.LoadFunction<al_set_app_name>(AllegroLibrary, nameof(al_set_app_name));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_set_org_name(IntPtr path);

    public static al_set_org_name AlSetOrgName =
        NativeInterop.LoadFunction<al_set_org_name>(AllegroLibrary, nameof(al_set_org_name));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_app_name();

    public static al_get_app_name AlGetAppName =
        NativeInterop.LoadFunction<al_get_app_name>(AllegroLibrary, nameof(al_get_app_name));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_org_name();

    public static al_get_org_name AlGetOrgName =
        NativeInterop.LoadFunction<al_get_org_name>(AllegroLibrary, nameof(al_get_org_name));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_system_config();

    public static al_get_system_config AlGetSystemConfig =
        NativeInterop.LoadFunction<al_get_system_config>(AllegroLibrary, nameof(al_get_system_config));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_system_id();

    public static al_get_system_id AlGetSystemID =
        NativeInterop.LoadFunction<al_get_system_id>(AllegroLibrary, nameof(al_get_system_id));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_register_assert_handler(RegisterAssertHandler handler);

    public static al_register_assert_handler AlRegisterAssertHandler =
        NativeInterop.LoadFunction<al_register_assert_handler>(AllegroLibrary, nameof(al_register_assert_handler));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_register_trace_handler(RegisterTraceHandler handler);

    public static al_register_trace_handler AlRegisterTraceHandler =
        NativeInterop.LoadFunction<al_register_trace_handler>(AllegroLibrary, nameof(al_register_trace_handler));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_cpu_count();

    public static al_get_cpu_count AlGetCpuCount =
        NativeInterop.LoadFunction<al_get_cpu_count>(AllegroLibrary, nameof(al_get_cpu_count));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_ram_size();

    public static al_get_ram_size AlGetRamSize =
        NativeInterop.LoadFunction<al_get_ram_size>(AllegroLibrary, nameof(al_get_ram_size));

    #endregion System routines

    #region Thread routines

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_create_thread(ThreadProcess proc, IntPtr arg);

    public static al_create_thread AlCreateThread =
        NativeInterop.LoadFunction<al_create_thread>(AllegroLibrary, nameof(al_create_thread));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_start_thread(IntPtr thread);

    public static al_start_thread AlStartThread =
        NativeInterop.LoadFunction<al_start_thread>(AllegroLibrary, nameof(al_start_thread));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_join_thread(IntPtr thread, ref IntPtr ret_value);

    public static al_join_thread AlJoinThread =
        NativeInterop.LoadFunction<al_join_thread>(AllegroLibrary, nameof(al_join_thread));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_set_thread_should_stop(IntPtr thread);

    public static al_set_thread_should_stop AlSetThreadShouldStop =
        NativeInterop.LoadFunction<al_set_thread_should_stop>(AllegroLibrary, nameof(al_set_thread_should_stop));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_get_thread_should_stop(IntPtr thread);

    public static al_get_thread_should_stop AlGetThreadShouldStop =
        NativeInterop.LoadFunction<al_get_thread_should_stop>(AllegroLibrary, nameof(al_get_thread_should_stop));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_destroy_thread(IntPtr thread);

    public static al_destroy_thread AlDestroyThread =
        NativeInterop.LoadFunction<al_destroy_thread>(AllegroLibrary, nameof(al_destroy_thread));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_run_detached_thread(DetachedThreadProcess proc, IntPtr arg);

    public static al_run_detached_thread AlRunDetachedThread =
        NativeInterop.LoadFunction<al_run_detached_thread>(AllegroLibrary, nameof(al_run_detached_thread));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_create_mutex();

    public static al_create_mutex AlCreateMutex =
        NativeInterop.LoadFunction<al_create_mutex>(AllegroLibrary, nameof(al_create_mutex));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_create_mutex_recursive();

    public static al_create_mutex_recursive AlCreateMutexRecursive =
        NativeInterop.LoadFunction<al_create_mutex_recursive>(AllegroLibrary, nameof(al_create_mutex_recursive));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_lock_mutex(IntPtr mutex);

    public static al_lock_mutex AlLockMutex =
        NativeInterop.LoadFunction<al_lock_mutex>(AllegroLibrary, nameof(al_lock_mutex));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_unlock_mutex(IntPtr mutex);

    public static al_unlock_mutex AlUnlockMutex =
        NativeInterop.LoadFunction<al_unlock_mutex>(AllegroLibrary, nameof(al_unlock_mutex));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_destroy_mutex(IntPtr mutex);

    public static al_destroy_mutex AlDestroyMutex =
        NativeInterop.LoadFunction<al_destroy_mutex>(AllegroLibrary, nameof(al_destroy_mutex));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_create_cond();

    public static al_create_cond AlCreateCond =
        NativeInterop.LoadFunction<al_create_cond>(AllegroLibrary, nameof(al_create_cond));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_destroy_cond(IntPtr cond);

    public static al_destroy_cond AlDestroyCond =
        NativeInterop.LoadFunction<al_destroy_cond>(AllegroLibrary, nameof(al_destroy_cond));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_wait_cond(IntPtr cond, IntPtr mutex);

    public static al_wait_cond AlWaitCond =
        NativeInterop.LoadFunction<al_wait_cond>(AllegroLibrary, nameof(al_wait_cond));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_wait_cond_until(IntPtr cond, IntPtr mutex, ref AllegroTimeout.NativeAllegroTimeout timeout);

    public static al_wait_cond_until AlWaitCondUntil =
        NativeInterop.LoadFunction<al_wait_cond_until>(AllegroLibrary, nameof(al_wait_cond_until));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_broadcast_cond(IntPtr cond);

    public static al_broadcast_cond AlBroadcastCond =
        NativeInterop.LoadFunction<al_broadcast_cond>(AllegroLibrary, nameof(al_broadcast_cond));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_signal_cond(IntPtr cond);

    public static al_signal_cond AlSignalCond =
        NativeInterop.LoadFunction<al_signal_cond>(AllegroLibrary, nameof(al_signal_cond));

    #endregion Thread routines

    #region Time routines

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate double al_get_time();

    public static al_get_time AlGetTime =
        NativeInterop.LoadFunction<al_get_time>(AllegroLibrary, nameof(al_get_time));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_init_timeout(ref AllegroTimeout.NativeAllegroTimeout timeout, double seconds);

    public static al_init_timeout AlInitTimeout =
        NativeInterop.LoadFunction<al_init_timeout>(AllegroLibrary, nameof(al_init_timeout));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_rest(double seconds);

    public static al_rest AlRest =
        NativeInterop.LoadFunction<al_rest>(AllegroLibrary, nameof(al_rest));

    #endregion Time routines

    #region Timer routines

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_create_timer(double speed_secs);

    public static al_create_timer ALCreateTimer =
        NativeInterop.LoadFunction<al_create_timer>(AllegroLibrary, nameof(al_create_timer));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_start_timer(IntPtr timer);

    public static al_start_timer AlStartTimer =
        NativeInterop.LoadFunction<al_start_timer>(AllegroLibrary, nameof(al_start_timer));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_resume_timer(IntPtr timer);

    public static al_resume_timer AlResumeTimer =
        NativeInterop.LoadFunction<al_resume_timer>(AllegroLibrary, nameof(al_resume_timer));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_stop_timer(IntPtr timer);

    public static al_stop_timer AlStopTimer =
        NativeInterop.LoadFunction<al_stop_timer>(AllegroLibrary, nameof(al_stop_timer));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_get_timer_started(IntPtr timer);

    public static al_get_timer_started AlGetTimerStarted =
        NativeInterop.LoadFunction<al_get_timer_started>(AllegroLibrary, nameof(al_get_timer_started));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_destroy_timer(IntPtr timer);

    public static al_destroy_timer AlDestroyTimer =
        NativeInterop.LoadFunction<al_destroy_timer>(AllegroLibrary, nameof(al_destroy_timer));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate ulong al_get_timer_count(IntPtr timer);

    public static al_get_timer_count AlGetTimerCount =
        NativeInterop.LoadFunction<al_get_timer_count>(AllegroLibrary, nameof(al_get_timer_count));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_set_timer_count(IntPtr timer, ulong new_count);

    public static al_set_timer_count AlSetTimerCount =
        NativeInterop.LoadFunction<al_set_timer_count>(AllegroLibrary, nameof(al_set_timer_count));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_add_timer_count(IntPtr timer, ulong diff);

    public static al_add_timer_count AlAddTimerCount =
        NativeInterop.LoadFunction<al_add_timer_count>(AllegroLibrary, nameof(al_add_timer_count));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate double al_get_timer_speed(IntPtr timer);

    public static al_get_timer_speed AlGetTimerSpeed =
        NativeInterop.LoadFunction<al_get_timer_speed>(AllegroLibrary, nameof(al_get_timer_speed));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_set_timer_speed(IntPtr timer, double new_speed_secs);

    public static al_set_timer_speed AlSetTimerSpeed =
        NativeInterop.LoadFunction<al_set_timer_speed>(AllegroLibrary, nameof(al_set_timer_speed));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_timer_event_source(IntPtr timer);

    public static al_get_timer_event_source AlGetTimerEventSource =
        NativeInterop.LoadFunction<al_get_timer_event_source>(AllegroLibrary, nameof(al_get_timer_event_source));

    #endregion Timer routines

    #region Transform routines

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_copy_transform(ref AllegroTransform.NativeAllegroTransform dest, ref AllegroTransform.NativeAllegroTransform src);

    public static al_copy_transform AlCopyTransform =
        NativeInterop.LoadFunction<al_copy_transform>(AllegroLibrary, nameof(al_copy_transform));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_use_transform(ref AllegroTransform.NativeAllegroTransform trans);

    public static al_use_transform AlUseTransform =
        NativeInterop.LoadFunction<al_use_transform>(AllegroLibrary, nameof(al_use_transform));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_current_transform();

    public static al_get_current_transform AlGetCurrentTransform =
        NativeInterop.LoadFunction<al_get_current_transform>(AllegroLibrary, nameof(al_get_current_transform));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_use_projection_transform(ref AllegroTransform.NativeAllegroTransform trans);

    public static al_use_projection_transform AlUseProjectionTransform =
        NativeInterop.LoadFunction<al_use_projection_transform>(AllegroLibrary, nameof(al_use_projection_transform));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_current_projection_transform();

    public static al_get_current_projection_transform AlGetCurrentProjectionTransform =
        NativeInterop.LoadFunction<al_get_current_projection_transform>(AllegroLibrary, nameof(al_get_current_projection_transform));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_current_inverse_transform();

    public static al_get_current_inverse_transform AlGetCurrentInverseTransform =
        NativeInterop.LoadFunction<al_get_current_inverse_transform>(AllegroLibrary, nameof(al_get_current_inverse_transform));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_invert_transform(ref AllegroTransform.NativeAllegroTransform trans);

    public static al_invert_transform AlInvertTransform =
        NativeInterop.LoadFunction<al_invert_transform>(AllegroLibrary, nameof(al_invert_transform));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_transpose_transform(ref AllegroTransform.NativeAllegroTransform trans);

    public static al_transpose_transform AlTransposeTransform =
        NativeInterop.LoadFunction<al_transpose_transform>(AllegroLibrary, nameof(al_transpose_transform));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_check_inverse(ref AllegroTransform.NativeAllegroTransform trans, float tol);

    public static al_check_inverse AlCheckInverse =
        NativeInterop.LoadFunction<al_check_inverse>(AllegroLibrary, nameof(al_check_inverse));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_identity_transform(ref AllegroTransform.NativeAllegroTransform trans);

    public static al_identity_transform AlIdentityTransform =
        NativeInterop.LoadFunction<al_identity_transform>(AllegroLibrary, nameof(al_identity_transform));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_build_transform(ref AllegroTransform.NativeAllegroTransform trans, float x, float y, float sx, float sy, float theta);

    public static al_build_transform AlBuildTransform =
        NativeInterop.LoadFunction<al_build_transform>(AllegroLibrary, nameof(al_build_transform));

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
        NativeInterop.LoadFunction<al_build_camera_transform>(AllegroLibrary, nameof(al_build_camera_transform));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_translate_transform(ref AllegroTransform.NativeAllegroTransform trans, float x, float y);

    public static al_translate_transform AlTranslateTransform =
        NativeInterop.LoadFunction<al_translate_transform>(AllegroLibrary, nameof(al_translate_transform));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_rotate_transform(ref AllegroTransform.NativeAllegroTransform trans, float theta);

    public static al_rotate_transform AlRotateTransform =
        NativeInterop.LoadFunction<al_rotate_transform>(AllegroLibrary, nameof(al_rotate_transform));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_scale_transform(ref AllegroTransform.NativeAllegroTransform trans, float sx, float sy);

    public static al_scale_transform AlScaleTransform =
        NativeInterop.LoadFunction<al_scale_transform>(AllegroLibrary, nameof(al_scale_transform));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_transform_coordinates(ref AllegroTransform.NativeAllegroTransform trans, ref float x, ref float y);

    public static al_transform_coordinates AlTransformCoordinates =
        NativeInterop.LoadFunction<al_transform_coordinates>(AllegroLibrary, nameof(al_transform_coordinates));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_transform_coordinates_3d(ref AllegroTransform.NativeAllegroTransform trans, ref float x, ref float y, ref float z);

    public static al_transform_coordinates_3d AlTransformCoordinates3D =
        NativeInterop.LoadFunction<al_transform_coordinates_3d>(AllegroLibrary, nameof(al_transform_coordinates_3d));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_transform_coordinates_4d(ref AllegroTransform.NativeAllegroTransform trans, ref float x, ref float y, ref float z, ref float w);

    public static al_transform_coordinates_4d AlTransformCoordinates4D =
        NativeInterop.LoadFunction<al_transform_coordinates_4d>(AllegroLibrary, nameof(al_transform_coordinates_4d));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_transform_coordinates_3d_projective(ref AllegroTransform.NativeAllegroTransform trans, ref float x, ref float y, ref float z);

    public static al_transform_coordinates_3d_projective AlTransformCoordinates3DProjective =
        NativeInterop.LoadFunction<al_transform_coordinates_3d_projective>(AllegroLibrary, nameof(al_transform_coordinates_3d_projective));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_compose_transform(ref AllegroTransform.NativeAllegroTransform trans, ref AllegroTransform.NativeAllegroTransform other);

    public static al_compose_transform AlComposeTransform =
        NativeInterop.LoadFunction<al_compose_transform>(AllegroLibrary, nameof(al_compose_transform));

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
        NativeInterop.LoadFunction<al_orthographic_transform>(AllegroLibrary, nameof(al_orthographic_transform));

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
        NativeInterop.LoadFunction<al_perspective_transform>(AllegroLibrary, nameof(al_perspective_transform));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_translate_transform_3d(ref AllegroTransform.NativeAllegroTransform trans, float x, float y, float z);

    public static al_translate_transform_3d AlTranslateTransform3D =
        NativeInterop.LoadFunction<al_translate_transform_3d>(AllegroLibrary, nameof(al_translate_transform_3d));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_scale_transform_3d(ref AllegroTransform.NativeAllegroTransform trans, float sx, float sy, float sz);

    public static al_scale_transform_3d AlScaleTransform3D =
        NativeInterop.LoadFunction<al_scale_transform_3d>(AllegroLibrary, nameof(al_scale_transform_3d));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_rotate_transform_3d(ref AllegroTransform.NativeAllegroTransform trans, float x, float y, float z, float angle);

    public static al_rotate_transform_3d AlRotateTransform3D =
        NativeInterop.LoadFunction<al_rotate_transform_3d>(AllegroLibrary, nameof(al_rotate_transform_3d));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_horizontal_shear_transform(ref AllegroTransform.NativeAllegroTransform trans, float theta);

    public static al_horizontal_shear_transform AlHorizontalShearTransform =
        NativeInterop.LoadFunction<al_horizontal_shear_transform>(AllegroLibrary, nameof(al_horizontal_shear_transform));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_vertical_shear_transform(ref AllegroTransform.NativeAllegroTransform trans, float theta);

    public static al_vertical_shear_transform AlVerticalShearTransform =
        NativeInterop.LoadFunction<al_vertical_shear_transform>(AllegroLibrary, nameof(al_vertical_shear_transform));

    #endregion Transform routines

    #region TTF routines

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_init_ttf_addon();

    public static al_init_ttf_addon AlInitTtfAddon =
        NativeInterop.LoadFunction<al_init_ttf_addon>(AllegroLibrary, nameof(al_init_ttf_addon));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_is_ttf_addon_initialized();

    public static al_is_ttf_addon_initialized AlIsTtfAddonInitialized =
        NativeInterop.LoadFunction<al_is_ttf_addon_initialized>(AllegroLibrary, nameof(al_is_ttf_addon_initialized));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_shutdown_ttf_addon();

    public static al_shutdown_ttf_addon AlShutdownTtfAddon =
        NativeInterop.LoadFunction<al_shutdown_ttf_addon>(AllegroLibrary, nameof(al_shutdown_ttf_addon));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_load_ttf_font(IntPtr filename, int size, int flags);

    public static al_load_ttf_font AlLoadTtfFont =
        NativeInterop.LoadFunction<al_load_ttf_font>(AllegroLibrary, nameof(al_load_ttf_font));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_load_ttf_font_f(IntPtr file, IntPtr filename, int size, int flags);

    public static al_load_ttf_font_f AlLoadTtfFontF =
        NativeInterop.LoadFunction<al_load_ttf_font_f>(AllegroLibrary, nameof(al_load_ttf_font_f));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_load_ttf_font_stretch(IntPtr filename, int w, int h, int flags);

    public static al_load_ttf_font_stretch AlLoadTtfFontStretch =
        NativeInterop.LoadFunction<al_load_ttf_font_stretch>(AllegroLibrary, nameof(al_load_ttf_font_stretch));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_load_ttf_font_stretch_f(IntPtr file, IntPtr filename, int w, int h, int flags);

    public static al_load_ttf_font_stretch_f AlLoadTtfFontStretchF =
        NativeInterop.LoadFunction<al_load_ttf_font_stretch_f>(AllegroLibrary, nameof(al_load_ttf_font_stretch_f));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate uint al_get_allegro_ttf_version();

    public static al_get_allegro_ttf_version AlGetAllegroTtfVersion =
        NativeInterop.LoadFunction<al_get_allegro_ttf_version>(AllegroLibrary, nameof(al_get_allegro_ttf_version));

    #endregion

    #region UTF-8 routines

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_ustr_new(IntPtr s);

    public static al_ustr_new AlUstrNew =
        NativeInterop.LoadFunction<al_ustr_new>(AllegroLibrary, nameof(al_ustr_new));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_ustr_new_from_buffer(IntPtr s, long size);

    public static al_ustr_new_from_buffer AlUstrNewFromBuffer =
        NativeInterop.LoadFunction<al_ustr_new_from_buffer>(AllegroLibrary, nameof(al_ustr_new_from_buffer));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_ustr_free(IntPtr us);

    public static al_ustr_free AlUstrFree =
        NativeInterop.LoadFunction<al_ustr_free>(AllegroLibrary, nameof(al_ustr_free));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_cstr(IntPtr us);

    public static al_cstr AlCstr =
        NativeInterop.LoadFunction<al_cstr>(AllegroLibrary, nameof(al_cstr));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_ustr_to_buffer(IntPtr us, IntPtr buffer, int size);

    public static al_ustr_to_buffer AlUstrToBuffer =
        NativeInterop.LoadFunction<al_ustr_to_buffer>(AllegroLibrary, nameof(al_ustr_to_buffer));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_cstr_dup(IntPtr us);

    public static al_cstr_dup AlCstrDup =
        NativeInterop.LoadFunction<al_cstr_dup>(AllegroLibrary, nameof(al_cstr_dup));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_ustr_dup(IntPtr us);

    public static al_ustr_dup AlUstrDup =
        NativeInterop.LoadFunction<al_ustr_dup>(AllegroLibrary, nameof(al_ustr_dup));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_ustr_dup_substr(IntPtr us, int start_pos, int end_pos);

    public static al_ustr_dup_substr AlUstrDupSubstr =
        NativeInterop.LoadFunction<al_ustr_dup_substr>(AllegroLibrary, nameof(al_ustr_dup_substr));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_ustr_empty_string();

    public static al_ustr_empty_string AlUstrEmptyString =
        NativeInterop.LoadFunction<al_ustr_empty_string>(AllegroLibrary, nameof(al_ustr_empty_string));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_ref_cstr(ref AllegroUstrInfo.NativeAllegroUstrInfo info, IntPtr s);

    public static al_ref_cstr AlRefCstr =
        NativeInterop.LoadFunction<al_ref_cstr>(AllegroLibrary, nameof(al_ref_cstr));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_ref_buffer(ref AllegroUstrInfo.NativeAllegroUstrInfo info, IntPtr s, long size);

    public static al_ref_buffer AlRefBuffer =
        NativeInterop.LoadFunction<al_ref_buffer>(AllegroLibrary, nameof(al_ref_buffer));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_ref_ustr(ref AllegroUstrInfo.NativeAllegroUstrInfo info, IntPtr us, int start_pos, int end_pos);

    public static al_ref_ustr AlRefUstr =
        NativeInterop.LoadFunction<al_ref_ustr>(AllegroLibrary, nameof(al_ref_ustr));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate long al_ustr_size(IntPtr us);

    public static al_ustr_size AlUstrSize =
        NativeInterop.LoadFunction<al_ustr_size>(AllegroLibrary, nameof(al_ustr_size));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate long al_ustr_length(IntPtr us);

    public static al_ustr_length AlUstrLength =
        NativeInterop.LoadFunction<al_ustr_length>(AllegroLibrary, nameof(al_ustr_length));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_ustr_offset(IntPtr us, int index);

    public static al_ustr_offset AlUstrOffset =
        NativeInterop.LoadFunction<al_ustr_offset>(AllegroLibrary, nameof(al_ustr_offset));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_ustr_next(IntPtr us, ref int pos);

    public static al_ustr_next AlUstrNext =
        NativeInterop.LoadFunction<al_ustr_next>(AllegroLibrary, nameof(al_ustr_next));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_ustr_prev(IntPtr us, ref int pos);

    public static al_ustr_prev AlUstrPrev =
        NativeInterop.LoadFunction<al_ustr_prev>(AllegroLibrary, nameof(al_ustr_prev));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_ustr_get(IntPtr ub, int pos);

    public static al_ustr_get AlUstrGet =
        NativeInterop.LoadFunction<al_ustr_get>(AllegroLibrary, nameof(al_ustr_get));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_ustr_get_next(IntPtr ub, ref int pos);

    public static al_ustr_get_next AlUstrGetNext =
        NativeInterop.LoadFunction<al_ustr_get_next>(AllegroLibrary, nameof(al_ustr_get_next));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_ustr_prev_get(IntPtr ub, ref int pos);

    public static al_ustr_prev_get AlUstrPrevGet =
        NativeInterop.LoadFunction<al_ustr_prev_get>(AllegroLibrary, nameof(al_ustr_prev_get));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_ustr_insert(IntPtr us1, int pos, IntPtr us2);

    public static al_ustr_insert AlUstrInsert =
        NativeInterop.LoadFunction<al_ustr_insert>(AllegroLibrary, nameof(al_ustr_insert));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_ustr_insert_cstr(IntPtr us, int pos, IntPtr s);

    public static al_ustr_insert_cstr AlUstrInsertCstr =
        NativeInterop.LoadFunction<al_ustr_insert_cstr>(AllegroLibrary, nameof(al_ustr_insert_cstr));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate long al_ustr_insert_chr(IntPtr us, int pos, int c);

    public static al_ustr_insert_chr AlUstrInsertChr =
        NativeInterop.LoadFunction<al_ustr_insert_chr>(AllegroLibrary, nameof(al_ustr_insert_chr));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_ustr_append(IntPtr us1, IntPtr us2);

    public static al_ustr_append AlUstrAppend =
        NativeInterop.LoadFunction<al_ustr_append>(AllegroLibrary, nameof(al_ustr_append));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_ustr_append_cstr(IntPtr us, IntPtr s);

    public static al_ustr_append_cstr AlUstrAppendCstr =
        NativeInterop.LoadFunction<al_ustr_append_cstr>(AllegroLibrary, nameof(al_ustr_append_cstr));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate long al_ustr_append_chr(IntPtr us, int c);

    public static al_ustr_append_chr AlUstrAppendChr =
        NativeInterop.LoadFunction<al_ustr_append_chr>(AllegroLibrary, nameof(al_ustr_append_chr));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_ustr_remove_chr(IntPtr us, int pos);

    public static al_ustr_remove_chr AlUstrRemoveChr =
        NativeInterop.LoadFunction<al_ustr_remove_chr>(AllegroLibrary, nameof(al_ustr_remove_chr));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_ustr_remove_range(IntPtr us, int start_pos, int end_pos);

    public static al_ustr_remove_range AlUstrRemoveRange =
        NativeInterop.LoadFunction<al_ustr_remove_range>(AllegroLibrary, nameof(al_ustr_remove_range));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_ustr_truncate(IntPtr us, int start_pos);

    public static al_ustr_truncate AlUstrTruncate =
        NativeInterop.LoadFunction<al_ustr_truncate>(AllegroLibrary, nameof(al_ustr_truncate));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_ustr_ltrim_ws(IntPtr us);

    public static al_ustr_ltrim_ws AlUstrLtrimWs =
        NativeInterop.LoadFunction<al_ustr_ltrim_ws>(AllegroLibrary, nameof(al_ustr_ltrim_ws));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_ustr_rtrim_ws(IntPtr us);

    public static al_ustr_rtrim_ws AlUstrRtrimWs =
        NativeInterop.LoadFunction<al_ustr_rtrim_ws>(AllegroLibrary, nameof(al_ustr_rtrim_ws));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_ustr_trim_ws(IntPtr us);

    public static al_ustr_trim_ws AlUstrTrimWs =
        NativeInterop.LoadFunction<al_ustr_trim_ws>(AllegroLibrary, nameof(al_ustr_trim_ws));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_ustr_assign(IntPtr us1, IntPtr us2);

    public static al_ustr_assign AlUstrAssign =
        NativeInterop.LoadFunction<al_ustr_assign>(AllegroLibrary, nameof(al_ustr_assign));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_ustr_assign_substr(IntPtr us1, IntPtr us2, int start_pos, int end_pos);

    public static al_ustr_assign_substr AlUstrAssignSubstr =
        NativeInterop.LoadFunction<al_ustr_assign_substr>(AllegroLibrary, nameof(al_ustr_assign_substr));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_ustr_assign_cstr(IntPtr us1, IntPtr s);

    public static al_ustr_assign_cstr AlUstrAssignCstr =
        NativeInterop.LoadFunction<al_ustr_assign_cstr>(AllegroLibrary, nameof(al_ustr_assign_cstr));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate long al_ustr_set_chr(IntPtr us, int start_pos, int c);

    public static al_ustr_set_chr AlUstrSetChr =
        NativeInterop.LoadFunction<al_ustr_set_chr>(AllegroLibrary, nameof(al_ustr_set_chr));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_ustr_replace_range(IntPtr us1, int start_pos1, int end_pos1, IntPtr us2);

    public static al_ustr_replace_range AlUstrReplaceRange =
        NativeInterop.LoadFunction<al_ustr_replace_range>(AllegroLibrary, nameof(al_ustr_replace_range));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_ustr_find_chr(IntPtr us, int start_pos1, int c);

    public static al_ustr_find_chr AlUstrFindChr =
        NativeInterop.LoadFunction<al_ustr_find_chr>(AllegroLibrary, nameof(al_ustr_find_chr));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_ustr_rfind_chr(IntPtr us, int end_pos, int c);

    public static al_ustr_rfind_chr AlUstrRFindChr =
        NativeInterop.LoadFunction<al_ustr_rfind_chr>(AllegroLibrary, nameof(al_ustr_rfind_chr));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_ustr_find_set(IntPtr us, int start_pos, IntPtr accept);

    public static al_ustr_find_set AlUstrFindSet =
        NativeInterop.LoadFunction<al_ustr_find_set>(AllegroLibrary, nameof(al_ustr_find_set));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_ustr_find_set_cstr(IntPtr us, int start_pos, IntPtr accept);

    public static al_ustr_find_set_cstr AlUstrFindSetCstr =
        NativeInterop.LoadFunction<al_ustr_find_set_cstr>(AllegroLibrary, nameof(al_ustr_find_set_cstr));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_ustr_find_cset(IntPtr us, int start_pos, IntPtr reject);

    public static al_ustr_find_cset AlUstrFindCset =
        NativeInterop.LoadFunction<al_ustr_find_cset>(AllegroLibrary, nameof(al_ustr_find_cset));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_ustr_find_cset_cstr(IntPtr us, int start_pos, IntPtr reject);

    public static al_ustr_find_cset_cstr AlUstrFindCsetCstr =
        NativeInterop.LoadFunction<al_ustr_find_cset_cstr>(AllegroLibrary, nameof(al_ustr_find_cset_cstr));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_ustr_find_str(IntPtr haystack, int start_pos, IntPtr needle);

    public static al_ustr_find_str AlUstrFindStr =
        NativeInterop.LoadFunction<al_ustr_find_str>(AllegroLibrary, nameof(al_ustr_find_str));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_ustr_find_cstr(IntPtr haystack, int start_pos, IntPtr needle);

    public static al_ustr_find_cstr AlUstrFindCstr =
        NativeInterop.LoadFunction<al_ustr_find_cstr>(AllegroLibrary, nameof(al_ustr_find_cstr));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_ustr_rfind_str(IntPtr haystack, int end_pos, IntPtr needle);

    public static al_ustr_rfind_str AlUstrRfindStr =
        NativeInterop.LoadFunction<al_ustr_rfind_str>(AllegroLibrary, nameof(al_ustr_rfind_str));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_ustr_rfind_cstr(IntPtr haystack, int end_pos, IntPtr needle);

    public static al_ustr_rfind_cstr AlUstrRfindCstr =
        NativeInterop.LoadFunction<al_ustr_rfind_cstr>(AllegroLibrary, nameof(al_ustr_rfind_cstr));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_ustr_find_replace(IntPtr us, int start_pos, IntPtr find, IntPtr replace);

    public static al_ustr_find_replace AlUstrFindReplace =
        NativeInterop.LoadFunction<al_ustr_find_replace>(AllegroLibrary, nameof(al_ustr_find_replace));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_ustr_find_replace_cstr(IntPtr us, int start_pos, IntPtr find, IntPtr replace);

    public static al_ustr_find_replace_cstr AlUstrFindReplaceCstr =
        NativeInterop.LoadFunction<al_ustr_find_replace_cstr>(AllegroLibrary, nameof(al_ustr_find_replace_cstr));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_ustr_equal(IntPtr us1, IntPtr us2);

    public static al_ustr_equal AlUstrEqual =
        NativeInterop.LoadFunction<al_ustr_equal>(AllegroLibrary, nameof(al_ustr_equal));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_ustr_compare(IntPtr us1, IntPtr us2);

    public static al_ustr_compare AlUstrCompare =
        NativeInterop.LoadFunction<al_ustr_compare>(AllegroLibrary, nameof(al_ustr_compare));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_ustr_ncompare(IntPtr us1, IntPtr us2, int n);

    public static al_ustr_ncompare AlUstrNcompare =
        NativeInterop.LoadFunction<al_ustr_ncompare>(AllegroLibrary, nameof(al_ustr_ncompare));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_ustr_has_prefix(IntPtr us1, IntPtr us2);

    public static al_ustr_has_prefix AlUstrHasPrefix =
        NativeInterop.LoadFunction<al_ustr_has_prefix>(AllegroLibrary, nameof(al_ustr_has_prefix));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_ustr_has_prefix_cstr(IntPtr us1, IntPtr us2);

    public static al_ustr_has_prefix_cstr AlUstrHasPrefixCstr =
        NativeInterop.LoadFunction<al_ustr_has_prefix_cstr>(AllegroLibrary, nameof(al_ustr_has_prefix_cstr));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_ustr_has_suffix(IntPtr us1, IntPtr us2);

    public static al_ustr_has_suffix AlUstrHasSuffix =
        NativeInterop.LoadFunction<al_ustr_has_suffix>(AllegroLibrary, nameof(al_ustr_has_suffix));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.U1)]
    public delegate bool al_ustr_has_suffix_cstr(IntPtr us1, IntPtr s2);

    public static al_ustr_has_suffix_cstr AlUstrHasSuffixCstr =
        NativeInterop.LoadFunction<al_ustr_has_suffix_cstr>(AllegroLibrary, nameof(al_ustr_has_suffix_cstr));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_ustr_new_from_utf16(IntPtr s);

    public static al_ustr_new_from_utf16 AlUstrNewFromUtf16 =
        NativeInterop.LoadFunction<al_ustr_new_from_utf16>(AllegroLibrary, nameof(al_ustr_new_from_utf16));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate long al_ustr_size_utf16(IntPtr us);

    public static al_ustr_size_utf16 AlUstrSizeUtf16 =
        NativeInterop.LoadFunction<al_ustr_size_utf16>(AllegroLibrary, nameof(al_ustr_size_utf16));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate long al_ustr_encode_utf16(IntPtr us, ref ushort s, long n);

    public static al_ustr_encode_utf16 AlUstrEncodeUtf16 =
        NativeInterop.LoadFunction<al_ustr_encode_utf16>(AllegroLibrary, nameof(al_ustr_encode_utf16));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate long al_utf8_width(int c);

    public static al_utf8_width AlUtf8Width =
        NativeInterop.LoadFunction<al_utf8_width>(AllegroLibrary, nameof(al_utf8_width));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate long al_utf8_encode(IntPtr s, int c);

    public static al_utf8_encode AlUtf8Encode =
        NativeInterop.LoadFunction<al_utf8_encode>(AllegroLibrary, nameof(al_utf8_encode));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate long al_utf16_width(int c);

    public static al_utf16_width AlUtf16Width =
        NativeInterop.LoadFunction<al_utf16_width>(AllegroLibrary, nameof(al_utf16_width));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate long al_utf16_encode(IntPtr s, int c);

    public static al_utf16_encode AlUtf16Encode =
        NativeInterop.LoadFunction<al_utf16_encode>(AllegroLibrary, nameof(al_utf16_encode));

    #endregion
  }
}