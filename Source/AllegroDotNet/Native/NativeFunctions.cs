using SubC.AllegroDotNet.Models;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using static SubC.AllegroDotNet.Models.AllegroTouchInputState;
using static SubC.AllegroDotNet.Models.AllegroVertexElement;
using static SubC.AllegroDotNet.Native.NativeDelegates;

namespace SubC.AllegroDotNet.Native;

internal static class NativeFunctions
{
  public static IntPtr AllegroLibrary { get; set; } = IntPtr.Zero;

  #region Audio codecs routines

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_init_acodec_addon();

  public static al_init_acodec_addon AlInitAcodecAddon = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_is_acodec_addon_initialized();

  public static al_is_acodec_addon_initialized AlIsAcodecAddonInitialized = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate uint al_get_allegro_acodec_version();

  public static al_get_allegro_acodec_version AlGetAllegroAcodecVersion = null!;

  #endregion

  #region Audio routines

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_install_audio();

  public static al_install_audio AlInstallAudio = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_uninstall_audio();

  public static al_uninstall_audio AlUninstallAudio = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_is_audio_installed();

  public static al_is_audio_installed AlIsAudioInstalled = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_reserve_samples(int reserve_samples);

  public static al_reserve_samples AlReserveSamples = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate uint al_get_allegro_audio_version();

  public static al_get_allegro_audio_version AlGetAllegroAudioVersion = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate long al_get_audio_depth_size(int depth);

  public static al_get_audio_depth_size AlGetAudioDepthSize = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate long al_get_channel_count(int conf);

  public static al_get_channel_count AlGetChannelCount = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_fill_silence(IntPtr buf, uint samples, int depth, int chan_conf);

  public static al_fill_silence AlFillSilence = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_create_voice(uint freq, int depth, int chan_conf);

  public static al_create_voice AlCreateVoice = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_destroy_voice(IntPtr voice);

  public static al_destroy_voice AlDestroyVoice = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_detach_voice(IntPtr voice);

  public static al_detach_voice AlDetachVoice = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_attach_audio_stream_to_voice(IntPtr stream, IntPtr voice);

  public static al_attach_audio_stream_to_voice AlAttachAudioStreamToVoice = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_attach_mixer_to_voice(IntPtr mixer, IntPtr voice);

  public static al_attach_mixer_to_voice AlAttachMixerToVoice = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_attach_sample_instance_to_voice(IntPtr spl, IntPtr voice);

  public static al_attach_sample_instance_to_voice AlAttachSampleInstanceToVoice = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate uint al_get_voice_frequency(IntPtr voice);

  public static al_get_voice_frequency AlGetVoiceFrequency = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate int al_get_voice_channels(IntPtr voice);

  public static al_get_voice_channels AlGetVoiceChannels = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate int al_get_voice_depth(IntPtr voice);

  public static al_get_voice_depth AlGetVoiceDepth = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_get_voice_playing(IntPtr voice);

  public static al_get_voice_playing AlGetVoicePlaying = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_set_voice_playing(IntPtr voice, [MarshalAs(UnmanagedType.U1)] bool val);

  public static al_set_voice_playing AlSetVoicePlaying = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate uint al_get_voice_position(IntPtr voice);

  public static al_get_voice_position AlGetVoicePosition = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_set_voice_position(IntPtr voice, uint val);

  public static al_set_voice_position AlSetVoicePosition = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_create_sample(IntPtr buf, uint samples, uint freq, int depth, int chan_conf, [MarshalAs(UnmanagedType.U1)] bool free_buf);

  public static al_create_sample AlCreateSample = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_destroy_sample(IntPtr spl);

  public static al_destroy_sample AlDestroySample = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_play_sample(IntPtr spl, float gain, float pan, float speed, int loop, IntPtr ret_id);

  public static al_play_sample AlPlaySample = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_stop_sample(IntPtr spl_id);

  public static al_stop_sample AlStopSample = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_stop_samples();

  public static al_stop_samples AlStopSamples = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate int al_get_sample_channels(IntPtr spl);

  public static al_get_sample_channels AlGetSampleChannels = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate int al_get_sample_depth(IntPtr spl);

  public static al_get_sample_depth AlGetSampleDepth = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate uint al_get_sample_frequency(IntPtr spl);

  public static al_get_sample_frequency AlGetSampleFrequency = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate uint al_get_sample_length(IntPtr spl);

  public static al_get_sample_length AlGetSampleLength = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_get_sample_data(IntPtr spl);

  public static al_get_sample_data AlGetSampleData = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_create_sample_instance(IntPtr sample_data);

  public static al_create_sample_instance AlCreateSampleInstance = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_destroy_sample_instance(IntPtr spl);

  public static al_destroy_sample_instance AlDestroySampleInstance = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_play_sample_instance(IntPtr spl);

  public static al_play_sample_instance AlPlaySampleInstance = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_stop_sample_instance(IntPtr spl);

  public static al_stop_sample_instance AlStopSampleInstance = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate int al_get_sample_instance_channels(IntPtr spl);

  public static al_get_sample_instance_channels AlGetSampleInstanceChannels = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate int al_get_sample_instance_depth(IntPtr spl);

  public static al_get_sample_instance_depth AlGetSampleInstanceDepth = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate uint al_get_sample_instance_frequency(IntPtr spl);

  public static al_get_sample_instance_frequency AlGetSampleInstanceFrequency = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate uint al_get_sample_instance_length(IntPtr spl);

  public static al_get_sample_instance_length AlGetSampleInstanceLength = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_set_sample_instance_length(IntPtr spl, uint val);

  public static al_set_sample_instance_length AlSetSampleInstanceLength = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate uint al_get_sample_instance_position(IntPtr spl);

  public static al_get_sample_instance_position AlGetSampleInstancePosition = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_set_sample_instance_position(IntPtr spl, uint val);

  public static al_set_sample_instance_position AlSetSampleInstancePosition = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate float al_get_sample_instance_speed(IntPtr spl);

  public static al_get_sample_instance_speed AlGetSampleInstanceSpeed = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_set_sample_instance_speed(IntPtr spl, float val);

  public static al_set_sample_instance_speed AlSetSampleInstanceSpeed = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate float al_get_sample_instance_gain(IntPtr spl);

  public static al_get_sample_instance_gain AlGetSampleInstanceGain = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_set_sample_instance_gain(IntPtr spl, float val);

  public static al_set_sample_instance_gain AlSetSampleInstanceGain = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate float al_get_sample_instance_pan(IntPtr spl);

  public static al_get_sample_instance_pan AlGetSampleInstancePan = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_set_sample_instance_pan(IntPtr spl, float val);

  public static al_set_sample_instance_pan AlSetSampleInstancePan = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate float al_get_sample_instance_time(IntPtr spl);

  public static al_get_sample_instance_time AlGetSampleInstanceTime = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate int al_get_sample_instance_playmode(IntPtr spl);

  public static al_get_sample_instance_playmode AlGetSampleInstancePlaymode = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_set_sample_instance_playmode(IntPtr spl, int val);

  public static al_set_sample_instance_playmode AlSetSampleInstancePlaymode = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_get_sample_instance_playing(IntPtr spl);

  public static al_get_sample_instance_playing AlGetSampleInstancePlaying = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_set_sample_instance_playing(IntPtr spl, [MarshalAs(UnmanagedType.U1)] bool val);

  public static al_set_sample_instance_playing AlSetSampleInstancePlaying = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_get_sample_instance_attached(IntPtr spl);

  public static al_get_sample_instance_attached AlGetSampleInstanceAttached = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_detach_sample_instance(IntPtr spl);

  public static al_detach_sample_instance AlDetachSampleInstance = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_get_sample(IntPtr spl);

  public static al_get_sample AlGetSample = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_set_sample(IntPtr spl, IntPtr data);

  public static al_set_sample AlSetSample = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_create_mixer(uint freq, int depth, int chan_conf);

  public static al_create_mixer AlCreateMixer = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_destroy_mixer(IntPtr mixer);

  public static al_destroy_mixer AlDestroyMixer = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_get_default_mixer();

  public static al_get_default_mixer AlGetDefaultMixer = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_set_default_mixer(IntPtr mixer);

  public static al_set_default_mixer AlSetDefaultMixer = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_restore_default_mixer();

  public static al_restore_default_mixer AlRestoreDefaultMixer = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_get_default_voice();

  public static al_get_default_voice AlGetDefaultVoice = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_set_default_voice(IntPtr voice);

  public static al_set_default_voice AlSetDefaultVoice = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_attach_mixer_to_mixer(IntPtr stream, IntPtr mixer);

  public static al_attach_mixer_to_mixer AlAttachMixerToMixer = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_attach_sample_instance_to_mixer(IntPtr spl, IntPtr mixer);

  public static al_attach_sample_instance_to_mixer AlAttachSampleInstanceToMixer = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_attach_audio_stream_to_mixer(IntPtr stream, IntPtr mixer);

  public static al_attach_audio_stream_to_mixer AlAttachAudioStreamToMixer = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate uint al_get_mixer_frequency(IntPtr mixer);

  public static al_get_mixer_frequency AlGetMixerFrequency = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_set_mixer_frequency(IntPtr mixer, uint val);

  public static al_set_mixer_frequency AlSetMixerFrequency = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate int al_get_mixer_channels(IntPtr mixer);

  public static al_get_mixer_channels AlGetMixerChannels = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate int al_get_mixer_depth(IntPtr mixer);

  public static al_get_mixer_depth AlGetMixerDepth = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate float al_get_mixer_gain(IntPtr mixer);

  public static al_get_mixer_gain AlGetMixerGain = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_set_mixer_gain(IntPtr mixer, float new_gain);

  public static al_set_mixer_gain AlSetMixerGain = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate int al_get_mixer_quality(IntPtr mixer);

  public static al_get_mixer_quality AlGetMixerQuality = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_set_mixer_quality(IntPtr mixer, int new_quality);

  public static al_set_mixer_quality AlSetMixerQuality = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_get_mixer_playing(IntPtr mixer);

  public static al_get_mixer_playing AlGetMixerPlaying = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_set_mixer_playing(IntPtr mixer, [MarshalAs(UnmanagedType.U1)] bool val);

  public static al_set_mixer_playing AlSetMixerPlaying = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_get_mixer_attached(IntPtr mixer);

  public static al_get_mixer_attached AlGetMixerAttached = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_detach_mixer(IntPtr mixer);

  public static al_detach_mixer AlDetachMixer = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_set_mixer_postprocess_callback(IntPtr mixer, MixerPostprocessCallback pp_callback, IntPtr pp_callback_userdata);

  public static al_set_mixer_postprocess_callback AlSetMixerPostprocessCallback = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_create_audio_stream(long fragment_count, uint frag_samples, uint freq, int depth, int chan_conf);

  public static al_create_audio_stream AlCreateAudioStream = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_destroy_audio_stream(IntPtr stream);

  public static al_destroy_audio_stream AlDestroyAudioStream = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_get_audio_stream_event_source(IntPtr stream);

  public static al_get_audio_stream_event_source AlGetAudioStreamEventSource = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_drain_audio_stream(IntPtr stream);

  public static al_drain_audio_stream AlDrainAudioStream = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_rewind_audio_stream(IntPtr stream);

  public static al_rewind_audio_stream AlRewindAudioStream = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate uint al_get_audio_stream_frequency(IntPtr stream);

  public static al_get_audio_stream_frequency AlGetAudioStreamFrequency = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate int al_get_audio_stream_channels(IntPtr stream);

  public static al_get_audio_stream_channels AlGetAudioStreamChannels = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate int al_get_audio_stream_depth(IntPtr stream);

  public static al_get_audio_stream_depth AlGetAudioStreamDepth = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate uint al_get_audio_stream_length(IntPtr stream);

  public static al_get_audio_stream_length AlGetAudioStreamLength = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate float al_get_audio_stream_speed(IntPtr stream);

  public static al_get_audio_stream_speed AlGetAudioStreamSpeed = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_set_audio_stream_speed(IntPtr stream, float val);

  public static al_set_audio_stream_speed AlSetAudioStreamSpeed = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate float al_get_audio_stream_gain(IntPtr stream);

  public static al_get_audio_stream_gain AlGetAudioStreamGain = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_set_audio_stream_gain(IntPtr stream, float val);

  public static al_set_audio_stream_gain AlSetAudioStreamGain = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate float al_get_audio_stream_pan(IntPtr stream);

  public static al_get_audio_stream_pan AlGetAudioStreamPan = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_set_audio_stream_pan(IntPtr stream, float val);

  public static al_set_audio_stream_pan AlSetAudioStreamPan = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_get_audio_stream_playing(IntPtr stream);

  public static al_get_audio_stream_playing AlGetAudioStreamPlaying = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_set_audio_stream_playing(IntPtr stream, [MarshalAs(UnmanagedType.U1)] bool val);

  public static al_set_audio_stream_playing AlSetAudioStreamPlaying = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate int al_get_audio_stream_playmode(IntPtr stream);

  public static al_get_audio_stream_playmode AlGetAudioStreamPlaymode = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_set_audio_stream_playmode(IntPtr stream, int val);

  public static al_set_audio_stream_playmode AlSetAudioStreamPlaymode = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_get_audio_stream_attached(IntPtr stream);

  public static al_get_audio_stream_attached AlGetAudioStreamAttached = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_detach_audio_stream(IntPtr stream);

  public static al_detach_audio_stream AlDetachAudioStream = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate ulong al_get_audio_stream_played_samples(IntPtr stream);

  public static al_get_audio_stream_played_samples AlGetAudioStreamPlayedSamples = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_get_audio_stream_fragment(IntPtr stream);

  public static al_get_audio_stream_fragment AlGetAudioStreamFragment = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_set_audio_stream_fragment(IntPtr stream, IntPtr val);

  public static al_set_audio_stream_fragment AlSetAudioStreamFragment = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate uint al_get_audio_stream_fragments(IntPtr stream);

  public static al_get_audio_stream_fragments AlGetAudioStreamFragments = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate uint al_get_available_audio_stream_fragments(IntPtr stream);

  public static al_get_available_audio_stream_fragments AlGetAvailableAudioStreamFragments = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_seek_audio_stream_secs(IntPtr stream, double time);

  public static al_seek_audio_stream_secs AlSeekAudioStreamSecs = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate double al_get_audio_stream_position_secs(IntPtr stream);

  public static al_get_audio_stream_position_secs AlGetAudioStreamPositionSecs = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate double al_get_audio_stream_length_secs(IntPtr stream);

  public static al_get_audio_stream_length_secs AlGetAudioStreamLengthSecs = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_set_audio_stream_loop_secs(IntPtr stream, double start, double end);

  public static al_set_audio_stream_loop_secs AlSetAudioStreamLoopSecs = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_register_sample_loader(IntPtr ext, RegisterSampleLoader loader);

  public static al_register_sample_loader AlRegisterSampleLoader = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_register_sample_loader_f(IntPtr ext, RegisterSampleLoaderF loader);

  public static al_register_sample_loader_f AlRegisterSampleLoaderF = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_register_sample_saver(IntPtr ext, RegisterSampleSaver saver);

  public static al_register_sample_saver AlRegisterSampleSaver = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_register_sample_saver_f(IntPtr ext, RegisterSampleSaverF saver);

  public static al_register_sample_saver_f AlRegisterSampleSaverF = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_register_audio_stream_loader(IntPtr ext, RegisterAudioStreamLoader stream_loader);

  public static al_register_audio_stream_loader AlRegisterAudioStreamLoader = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_register_audio_stream_loader_f(IntPtr ext, RegisterAudioStreamLoaderF stream_loader);

  public static al_register_audio_stream_loader_f AlRegisterAudioStreamLoaderF = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_load_sample(IntPtr filename);

  public static al_load_sample AlLoadSample = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_load_sample_f(IntPtr fp, IntPtr ident);

  public static al_load_sample_f AlLoadSampleF = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_load_audio_stream(IntPtr filename, long buffer_count, uint samples);

  public static al_load_audio_stream AlLoadAudioStream = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_load_audio_stream_f(IntPtr fp, IntPtr ident, long buffer_count, uint samples);

  public static al_load_audio_stream_f AlLoadAudioStreamF = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_save_sample(IntPtr filename, IntPtr spl);

  public static al_save_sample AlSaveSample = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_save_sample_f(IntPtr fp, IntPtr ident, IntPtr spl);

  public static al_save_sample_f AlSaveSampleF = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_register_sample_identifier(IntPtr ext, RegisterSampleIdentifier identifier);

  public static al_register_sample_identifier AlRegisterSampleIdentifier = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_identify_sample(IntPtr filename);

  public static al_identify_sample AlIdentifySample = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_identify_sample_f(IntPtr fp);

  public static al_identify_sample_f AlIdentifySampleF = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate int al_get_num_audio_output_devices();

  public static al_get_num_audio_output_devices AlGetNumAudioOutputDevices = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_get_audio_output_device(int index);

  public static al_get_audio_output_device AlGetAudioOutputDevice = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_get_audio_device_name(IntPtr device);

  public static al_get_audio_device_name AlGetAudioDeviceName = null!;

  #endregion

  #region Configuration routines

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_create_config();

  public static al_create_config AlCreateConfig = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_destroy_config(IntPtr config);

  public static al_destroy_config AlDestroyConfig = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_load_config_file(IntPtr filename);

  public static al_load_config_file AlLoadConfigFile = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_load_config_file_f(IntPtr file);

  public static al_load_config_file_f AlLoadConfigFileF = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_save_config_file(IntPtr filename, IntPtr config);

  public static al_save_config_file AlSaveConfigFile = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_save_config_file_f(IntPtr file, IntPtr config);

  public static al_save_config_file_f AlSaveConfigFileF = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_add_config_section(IntPtr config, IntPtr name);

  public static al_add_config_section AlAddConfigSection = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_remove_config_section(IntPtr config, IntPtr section);

  public static al_remove_config_section AlRemoveConfigSection = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_add_config_comment(IntPtr config, IntPtr section, IntPtr comment);

  public static al_add_config_comment AlAddConfigComment = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_get_config_value(IntPtr config, IntPtr section, IntPtr key);

  public static al_get_config_value AlGetConfigValue = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_set_config_value(IntPtr config, IntPtr section, IntPtr key, IntPtr value);

  public static al_set_config_value AlSetConfigValue = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_remove_config_key(IntPtr config, IntPtr section, IntPtr key);

  public static al_remove_config_key AlRemoveConfigKey = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_get_first_config_section(IntPtr config, ref IntPtr iterator);

  public static al_get_first_config_section AlGetFirstConfigSection = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_get_next_config_section(ref IntPtr iterator);

  public static al_get_next_config_section AlGetNextConfigSection = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_get_first_config_entry(IntPtr config, IntPtr section, ref IntPtr iterator);

  public static al_get_first_config_entry AlGetFirstConfigEntry = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_get_next_config_entry(ref IntPtr iterator);

  public static al_get_next_config_entry AlGetNextConfigEntry = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_merge_config(IntPtr cfg1, IntPtr cfg2);

  public static al_merge_config AlMergeConfig = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_merge_config_into(IntPtr master, IntPtr add);

  public static al_merge_config_into AlMergeConfigInto = null!;

  #endregion Configuration routines

  #region Display routines

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_create_display(int w, int h);

  public static al_create_display AlCreateDisplay = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_destroy_display(IntPtr display);

  public static al_destroy_display AlDestroyDisplay = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate int al_get_new_display_flags();

  public static al_get_new_display_flags AlGetNewDisplayFlags = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_set_new_display_flags(int flags);

  public static al_set_new_display_flags AlSetNewDisplayFlags = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate int al_get_new_display_option(int option, ref int importance);

  public static al_get_new_display_option AlGetNewDisplayOption = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_set_new_display_option(int option, int value, int importance);

  public static al_set_new_display_option AlSetNewDisplayOption = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_reset_new_display_options();

  public static al_reset_new_display_options AlResetNewDisplayOptions = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_get_new_window_position(ref int x, ref int y);

  public static al_get_new_window_position AlGetNewWindowPosition = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_set_new_window_position(int x, int y);

  public static al_set_new_window_position AlSetNewWindowPosition = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate int al_get_new_display_refresh_rate();

  public static al_get_new_display_refresh_rate AlGetNewDisplayRefreshRate = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_set_new_display_refresh_rate(int refresh_rate);

  public static al_set_new_display_refresh_rate AlSetNewDisplayRefreshRate = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_get_display_event_source(IntPtr display);

  public static al_get_display_event_source AlGetDisplayEventSource = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_get_backbuffer(IntPtr display);

  public static al_get_backbuffer AlGetBackbuffer = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_flip_display();

  public static al_flip_display AlFlipDisplay = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_update_display_region(int x, int y, int width, int height);

  public static al_update_display_region AlUpdateDisplayRegion = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_wait_for_vsync();

  public static al_wait_for_vsync AlWaitForVSync = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate int al_get_display_width(IntPtr display);

  public static al_get_display_width AlGetDisplayWidth = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate int al_get_display_height(IntPtr display);

  public static al_get_display_height AlGetDisplayHeight = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_resize_display(IntPtr display, int width, int height);

  public static al_resize_display AlResizeDisplay = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_acknowledge_resize(IntPtr display);

  public static al_acknowledge_resize AlAcknowledgeResize = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_get_window_position(IntPtr display, ref int x, ref int y);

  public static al_get_window_position AlGetWindowPosition = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_set_window_position(IntPtr display, int x, int y);

  public static al_set_window_position AlSetWindowPosition = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_get_window_constraints(IntPtr display, ref int min_w, ref int min_h, ref int max_w, ref int max_h);

  public static al_get_window_constraints AlGetWindowConstraints = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_set_window_constraints(IntPtr display, int min_w, int min_h, int max_w, int max_h);

  public static al_set_window_constraints AlSetWindowConstraints = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate bool al_apply_window_constraints(IntPtr display, [MarshalAs(UnmanagedType.U1)] bool onoff);

  public static al_apply_window_constraints AlApplyWindowConstraints = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate int al_get_display_flags(IntPtr display);

  public static al_get_display_flags AlGetDisplayFlags = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_set_display_flag(IntPtr display, int flag, [MarshalAs(UnmanagedType.U1)] bool onoff);

  public static al_set_display_flag AlSetDisplayFlag = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate int al_get_display_option(IntPtr display, int option);

  public static al_get_display_option AlGetDisplayOption = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_set_display_option(IntPtr display, int option, int value);

  public static al_set_display_option AlSetDisplayOption = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate int al_get_display_format(IntPtr display);

  public static al_get_display_format AlGetDisplayFormat = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate int al_get_display_orientation(IntPtr display);

  public static al_get_display_orientation AlGetDisplayOrientation = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate int al_get_display_refresh_rate(IntPtr display);

  public static al_get_display_refresh_rate AlGetDisplayRefreshRate = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_set_window_title(IntPtr display, IntPtr title);

  public static al_set_window_title AlSetWindowTitle = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_set_new_window_title(IntPtr title);

  public static al_set_new_window_title AlSetNewWindowTitle = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_get_new_window_title();

  public static al_get_new_window_title AlGetNewWindowTitle = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_set_display_icon(IntPtr display, IntPtr icon);

  public static al_set_display_icon AlSetDisplayIcon = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_set_display_icons(IntPtr display, int num_icons, ref IntPtr[] icon);

  public static al_set_display_icons AlSetDisplayIcons = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_acknowledge_drawing_halt(IntPtr display);

  public static al_acknowledge_drawing_halt AlAcknowledgeDrawingHalt = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_acknowledge_drawing_resume(IntPtr display);

  public static al_acknowledge_drawing_resume AlAcknowledgeDrawingResume = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_inhibit_screensaver([MarshalAs(UnmanagedType.U1)] bool inhibit);

  public static al_inhibit_screensaver AlInhibitScreensaver = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_get_clipboard_text(IntPtr display);

  public static al_get_clipboard_text AlGetClipboardText = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_set_clipboard_text(IntPtr display, IntPtr text);

  public static al_set_clipboard_text AlSetClipboardText = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_clipboard_has_text(IntPtr display);

  public static al_clipboard_has_text AlClipboardHasText = null!;

  #endregion Display routines

  #region Event routines

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_create_event_queue();

  public static al_create_event_queue AlCreateEventQueue = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_destroy_event_queue(IntPtr queue);

  public static al_destroy_event_queue AlDestroyEventQueue = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_register_event_source(IntPtr queue, IntPtr source);

  public static al_register_event_source AlRegisterEventSource = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_unregister_event_source(IntPtr queue, IntPtr source);

  public static al_unregister_event_source AlUnregisterEventSource = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_is_event_source_registered(IntPtr queue, IntPtr source);

  public static al_is_event_source_registered AlIsEventSourceRegistered = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_pause_event_queue(IntPtr queue, [MarshalAs(UnmanagedType.U1)] bool pause);

  public static al_pause_event_queue AlPauseEventQueue = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_is_event_queue_paused(IntPtr queue);

  public static al_is_event_queue_paused AlIsEventQueuePaused = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_is_event_queue_empty(IntPtr queue);

  public static al_is_event_queue_empty AlIsEventQueueEmpty = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_get_next_event(IntPtr queue, ref AllegroEvent.NativeAllegroEvent ret_event);

  public static al_get_next_event AlGetNextEvent = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_peek_next_event(IntPtr queue, ref AllegroEvent.NativeAllegroEvent ret_event);

  public static al_peek_next_event AlPeekNextEvent = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_drop_next_event(IntPtr queue);

  public static al_drop_next_event AlDropNextEvent = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_flush_event_queue(IntPtr queue);

  public static al_flush_event_queue AlFlushEventQueue = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_wait_for_event(IntPtr queue, ref AllegroEvent.NativeAllegroEvent ret_event);

  public static al_wait_for_event AlWaitForEvent = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_wait_for_event_timed(IntPtr queue, ref AllegroEvent.NativeAllegroEvent ret_event, float secs);

  public static al_wait_for_event_timed AlWaitForEventTimed = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_wait_for_event_until(
      IntPtr queue,
      ref AllegroEvent.NativeAllegroEvent ret_event,
      ref AllegroTimeout.NativeAllegroTimeout timeout);

  public static al_wait_for_event_until AlWaitForEventUntil = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_init_user_event_source(IntPtr source);

  public static al_init_user_event_source AlInitUserEventSource = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_destroy_user_event_source(IntPtr source);

  public static al_destroy_user_event_source AlDestroyUserEventSource = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_emit_user_event(
      IntPtr source,
      ref AllegroEvent.NativeAllegroEvent alEvent,
      UserEventDelegate? userEventHandler);

  public static al_emit_user_event AlEmitUserEvent = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_unref_user_event(ref AllegroEvent.NativeAllegroUserEvent userEvent);

  public static al_unref_user_event AlUnrefUserEvent = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_get_event_source_data(IntPtr source);

  public static al_get_event_source_data AlGetEventSourceData = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_set_event_source_data(IntPtr source, IntPtr data);

  public static al_set_event_source_data AlSetEventSourceData = null!;

  #endregion Event routines

  #region File IO routines

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_fopen(IntPtr path, IntPtr mode);

  public static al_fopen AlFOpen = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_fopen_interface(ref AllegroFileInterface.NativeAllegroFileInterface drv, IntPtr path, IntPtr mode);

  public static al_fopen_interface AlFOpenInterface = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_fopen_slice(IntPtr fp, long initial_size, IntPtr mode);

  public static al_fopen_slice AlFOpenSlice = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_fclose(IntPtr f);

  public static al_fclose AlFClose = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate long al_fread(IntPtr f, IntPtr ptr, long size);

  public static al_fread AlFRead = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate long al_fwrite(IntPtr f, IntPtr ptr, long size);

  public static al_fwrite AlFWrite = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_fflush(IntPtr f);

  public static al_fflush AlFFlush = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate long al_ftell(IntPtr f);

  public static al_ftell AlFTell = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_fseek(IntPtr f, long offset, int whence);

  public static al_fseek AlFSeek = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_feof(IntPtr f);

  public static al_feof AlFEof = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate int al_ferror(IntPtr f);

  public static al_ferror AlFError = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_ferrmsg(IntPtr f);

  public static al_ferrmsg AlFErrMsg = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_fclearerr(IntPtr f);

  public static al_fclearerr AlFClearErr = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate int al_fungetc(IntPtr f, int c);

  public static al_fungetc AlFUngetC = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate long al_fsize(IntPtr f);

  public static al_fsize AlFSize = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate int al_fgetc(IntPtr f);

  public static al_fgetc AlFGetC = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate int al_fputc(IntPtr f, int c);

  public static al_fputc AlFPutC = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate int al_fprintf(IntPtr f, IntPtr format);

  public static al_fprintf AlFPrintF = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate short al_fread16le(IntPtr f);

  public static al_fread16le AlFRead16le = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate short al_fread16be(IntPtr f);

  public static al_fread16be AlFRead16be = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate long al_fwrite16le(IntPtr f, short w);

  public static al_fwrite16le AlFWrite16le = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate long al_fwrite16be(IntPtr f, short w);

  public static al_fwrite16be AlFWrite16be = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate int al_fread32le(IntPtr f);

  public static al_fread32le AlFRead32le = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate int al_fread32be(IntPtr f);

  public static al_fread32be AlFRead32be = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate long al_fwrite32le(IntPtr f, int l);

  public static al_fwrite32le AlFWrite32le = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate long al_fwrite32be(IntPtr f, int l);

  public static al_fwrite32be AlFWrite32be = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_fgets(IntPtr f, IntPtr buf, long max);

  public static al_fgets AlFGetS = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_fget_ustr(IntPtr f);

  public static al_fget_ustr AlFGetUstr = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate int al_fputs(IntPtr f, IntPtr p);

  public static al_fputs AlFPutS = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_fopen_fd(int fd, IntPtr mode);

  public static al_fopen_fd AlFOpenFd = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_make_temp_file(IntPtr template, ref IntPtr ret_path);

  public static al_make_temp_file AlMakeTempFile = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_set_new_file_interface(ref AllegroFileInterface.NativeAllegroFileInterface file_interface);

  public static al_set_new_file_interface AlSetNewFileInterface = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_set_standard_file_interface();

  public static al_set_standard_file_interface AlSetStandardFileInterface = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_get_new_file_interface();

  public static al_get_new_file_interface AlGetNewFileInterface = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_create_file_handle(ref AllegroFileInterface.NativeAllegroFileInterface drv, IntPtr userdata);

  public static al_create_file_handle AlCreateFileHandle = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_get_file_userdata(IntPtr drv);

  public static al_get_file_userdata AlGetFileUserdata = null!;

  #endregion

  #region File system routines

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_create_fs_entry(IntPtr path);

  public static al_create_fs_entry AlCreateFsEntry = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_destroy_fs_entry(IntPtr fh);

  public static al_destroy_fs_entry AlDestroyFsEntry = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_get_fs_entry_name(IntPtr e);

  public static al_get_fs_entry_name AlGetFsEntryName = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_update_fs_entry(IntPtr e);

  public static al_update_fs_entry AlUpdateFsEntry = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate uint al_get_fs_entry_mode(IntPtr e);

  public static al_get_fs_entry_mode AlGetFsEntryMode = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate ulong al_get_fs_entry_atime(IntPtr e);

  public static al_get_fs_entry_atime AlGetFsEntryATime = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate ulong al_get_fs_entry_ctime(IntPtr e);

  public static al_get_fs_entry_ctime AlGetFsEntryCTime = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate ulong al_get_fs_entry_mtime(IntPtr e);

  public static al_get_fs_entry_mtime AlGetFsEntryMTime = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate long al_get_fs_entry_size(IntPtr e);

  public static al_get_fs_entry_size AlGetFsEntrySize = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_fs_entry_exists(IntPtr e);

  public static al_fs_entry_exists AlFsEntryExists = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_remove_fs_entry(IntPtr e);

  public static al_remove_fs_entry AlRemoveFsEntry = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_filename_exists(IntPtr path);

  public static al_filename_exists AlFilenameExists = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_remove_filename(IntPtr path);

  public static al_remove_filename AlRemoveFilename = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_open_directory(IntPtr e);

  public static al_open_directory AlOpenDirectory = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_read_directory(IntPtr e);

  public static al_read_directory AlReadDirectory = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_close_directory(IntPtr e);

  public static al_close_directory AlCloseDirectory = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_get_current_directory();

  public static al_get_current_directory AlGetCurrentDirectory = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_change_directory(IntPtr path);

  public static al_change_directory AlChangeDirectory = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_make_directory(IntPtr path);

  public static al_make_directory AlMakeDirectory = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_open_fs_entry(IntPtr e, IntPtr mode);

  public static al_open_fs_entry AlOpenFsEntry = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_for_each_fs_entry(IntPtr dir, ForEachFsEntry callback, IntPtr extra);

  public static al_for_each_fs_entry AlForEachFsEntry = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_set_fs_interface(IntPtr fs_interface);

  public static al_set_fs_interface AlSetFsInterface = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_set_standard_fs_interface();

  public static al_set_standard_fs_interface AlSetStandardFsInterface = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_get_fs_interface();

  public static al_get_fs_interface AlGetFsInterface = null!;

  #endregion File system routines

  #region Font routines

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_init_font_addon();

  public static al_init_font_addon AlInitFontAddon = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_is_font_addon_initialized();

  public static al_is_font_addon_initialized AlIsFontAddonInitialized = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_shutdown_font_addon();

  public static al_shutdown_font_addon AlShutdownFontAddon = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_load_font(IntPtr filename, int size, int flags);

  public static al_load_font AlLoadFont = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_destroy_font(IntPtr f);

  public static al_destroy_font AlDestroyFont = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_register_font_loader(IntPtr extension, RegisterFontLoader load_font);

  public static al_register_font_loader AlRegisterFontLoader = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate int al_get_font_line_height(IntPtr f);

  public static al_get_font_line_height AlGetFontLineHeight = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate int al_get_font_ascent(IntPtr f);

  public static al_get_font_ascent AlGetFontAscent = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate int al_get_font_descent(IntPtr f);

  public static al_get_font_descent AlGetFontDescent = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate int al_get_text_width(IntPtr f, IntPtr str);

  public static al_get_text_width AlGetTextWidth = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate int al_get_ustr_width(IntPtr f, IntPtr ustr);

  public static al_get_ustr_width AlGetUstrWidth = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_draw_text(IntPtr font, AllegroColor color, float x, float y, int flags, IntPtr text);

  public static al_draw_text AlDrawText = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_draw_ustr(IntPtr font, AllegroColor color, float x, float y, int flags, IntPtr ustr);

  public static al_draw_ustr AlDrawUstr = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_draw_justified_text(IntPtr font, AllegroColor color, float x1, float x2, float y, float diff, int flags, IntPtr text);

  public static al_draw_justified_text AlDrawJustifiedText = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_draw_justified_ustr(IntPtr font, AllegroColor color, float x1, float x2, float y, float diff, int flags, IntPtr ustr);

  public static al_draw_justified_ustr AlDrawJustifiedUstr = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_get_text_dimensions(IntPtr f, IntPtr text, ref int bbx, ref int bby, ref int bbw, ref int bbh);

  public static al_get_text_dimensions AlGetTextDimensions = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_get_ustr_dimensions(IntPtr f, IntPtr ustr, ref int bbx, ref int bby, ref int bbw, ref int bbh);

  public static al_get_ustr_dimensions AlGetUstrDimensions = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate uint al_get_allegro_font_version();

  public static al_get_allegro_font_version AlGetAllegroFontVersion = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate int al_get_font_ranges(IntPtr f, int ranges_count, ref int[] ranges);

  public static al_get_font_ranges AlGetFontRanges = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_set_fallback_font(IntPtr font, IntPtr fallback);

  public static al_set_fallback_font AlSetFallbackFont = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_get_fallback_font(IntPtr font);

  public static al_get_fallback_font AlGetFallbackFont = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_draw_glyph(IntPtr f, AllegroColor color, float x, float y, int codepoint);

  public static al_draw_glyph AlDrawGlyph = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate int al_get_glyph_width(IntPtr f, int codepoint);

  public static al_get_glyph_width AlGetGlyphWidth = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_get_glyph_dimensions(IntPtr f, int codepoint, ref int bbx, ref int bby, ref int bbw, ref int bbh);

  public static al_get_glyph_dimensions AlGetGlyphDimensions = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate int al_get_glyph_advance(IntPtr f, int codepoint1, int codepoint2);

  public static al_get_glyph_advance AlGetGlyphAdvance = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_draw_multiline_text(IntPtr font, AllegroColor color, float x, float y, float max_width, float line_height, int flags, IntPtr text);

  public static al_draw_multiline_text AlDrawMultilineText = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_draw_multiline_ustr(IntPtr font, AllegroColor color, float x, float y, float max_width, float line_height, int flags, IntPtr ustr);

  public static al_draw_multiline_ustr AlDrawMultilineUstr = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_do_multiline_text(IntPtr font, float max_width, IntPtr text, DoMultilineText cb, IntPtr extra);

  public static al_do_multiline_text AlDoMultilineText = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_do_multiline_ustr(IntPtr font, float max_width, IntPtr ustr, DoMultilineUstr cb, IntPtr extra);

  public static al_do_multiline_ustr AlDoMultilineUstr = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_grab_font_from_bitmap(IntPtr bmp, int ranges_n, int[] ranges);

  public static al_grab_font_from_bitmap AlGrabFontFromBitmap = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_load_bitmap_font(IntPtr fname);

  public static al_load_bitmap_font AlLoadBitmapFont = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_load_bitmap_font_flags(IntPtr fname, int flags);

  public static al_load_bitmap_font_flags AlLoadBitmapFontFlags = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_create_builtin_font();

  public static al_create_builtin_font AlCreateBuiltinFont = null!;

  #endregion

  #region Fullscreen routines

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_get_display_mode(int index, ref AllegroDisplayMode.NativeDisplayMode mode);

  public static al_get_display_mode AlGetDisplayMode = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate int al_get_num_display_modes();

  public static al_get_num_display_modes AlGetNumDisplayModes = null!;

  #endregion Fullscreen routines

  #region Graphics routines

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate AllegroColor al_map_rgb(byte r, byte g, byte b);

  public static al_map_rgb AlMapRgb = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate AllegroColor al_map_rgb_f(float r, float g, float b);

  public static al_map_rgb_f AlMapRgbF = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate AllegroColor al_map_rgba(byte r, byte g, byte b, byte a);

  public static al_map_rgba AlMapRgba = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate AllegroColor al_premul_rgba(byte r, byte g, byte b, byte a);

  public static al_premul_rgba AlPremulRgba = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate AllegroColor al_map_rgba_f(float r, float g, float b, float a);

  public static al_map_rgba_f AlMapRgbaF = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate AllegroColor al_premul_rgba_f(float r, float g, float b, float a);

  public static al_premul_rgba_f AlPremulRgbaF = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_unmap_rgb(ref byte r, ref byte g, ref byte b);

  public static al_unmap_rgb AlUnmapRgb = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_unmap_rgb_f(ref float r, ref float g, ref float b);

  public static al_unmap_rgb_f AlUnmapRgbF = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_unmap_rgba(ref byte r, ref byte g, ref byte b, ref byte a);

  public static al_unmap_rgba AlUnmapRgba = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_unmap_rgba_f(ref float r, ref float g, ref float b, ref float a);

  public static al_unmap_rgba_f AlUnmapRgbaF = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate int al_get_pixel_size(int format);

  public static al_get_pixel_size AlGetPixelSize = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate int al_get_pixel_format_bits(int format);

  public static al_get_pixel_format_bits AlGetPixelFormatBits = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate int al_get_pixel_block_size(int format);

  public static al_get_pixel_block_size AlGetPixelBlockSize = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate int al_get_pixel_block_width(int format);

  public static al_get_pixel_block_width AlGetPixelBlockWidth = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate int al_get_pixel_block_height(int format);

  public static al_get_pixel_block_height AlGetPixelBlockHeight = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_lock_bitmap(IntPtr bitmap, int format, int flags);

  public static al_lock_bitmap AlLockBitmap = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_lock_bitmap_region(IntPtr bitmap, int x, int y, int width, int height, int format, int flags);

  public static al_lock_bitmap_region AlLockBitmapRegion = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_unlock_bitmap(IntPtr bitmap);

  public static al_unlock_bitmap AlUnlockBitmap = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_lock_bitmap_blocked(IntPtr bitmap, int flags);

  public static al_lock_bitmap_blocked AlLockBitmapBlocked = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_lock_bitmap_region_blocked(IntPtr bitmap, int x_block, int y_block, int width_block, int height_block, int flags);

  public static al_lock_bitmap_region_blocked AlLockBitmapRegionBlocked = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_create_bitmap(int w, int h);

  public static al_create_bitmap AlCreateBitmap = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_create_sub_bitmap(IntPtr parent, int x, int y, int w, int h);

  public static al_create_sub_bitmap AlCreateSubBitmap = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_clone_bitmap(IntPtr parent);

  public static al_clone_bitmap AlCloneBitmap = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_convert_bitmap(IntPtr parent);

  public static al_convert_bitmap AlConvertBitmap = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_convert_memory_bitmaps();

  public static al_convert_memory_bitmaps AlConvertMemoryBitmaps = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_destroy_bitmap(IntPtr bitmap);

  public static al_destroy_bitmap AlDestroyBitmap = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate int al_get_new_bitmap_flags();

  public static al_get_new_bitmap_flags AlGetNewBitmapFlags = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate int al_get_new_bitmap_format();

  public static al_get_new_bitmap_format AlGetNewBitmapFormat = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_set_new_bitmap_flags(int flags);

  public static al_set_new_bitmap_flags AlSetNewBitmapFlags = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_add_new_bitmap_flag(int flag);

  public static al_add_new_bitmap_flag AlAddNewBitmapFlag = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_set_new_bitmap_format(int flag);

  public static al_set_new_bitmap_format AlSetNewBitmapFormat = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate int al_get_bitmap_flags(IntPtr bitmap);

  public static al_get_bitmap_flags AlGetBitmapFlags = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate int al_get_bitmap_format(IntPtr bitmap);

  public static al_get_bitmap_format AlGetBitmapFormat = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate int al_get_bitmap_height(IntPtr bitmap);

  public static al_get_bitmap_height AlGetBitmapHeight = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate int al_get_bitmap_width(IntPtr bitmap);

  public static al_get_bitmap_width AlGetBitmapWidth = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate AllegroColor al_get_pixel(IntPtr bitmap, int x, int y);

  public static al_get_pixel AlGetPixel = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_is_bitmap_locked(IntPtr bitmap);

  public static al_is_bitmap_locked AlIsBitmapLocked = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_is_compatible_bitmap(IntPtr bitmap);

  public static al_is_compatible_bitmap AlIsCompatibleBitmap = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_is_sub_bitmap(IntPtr bitmap);

  public static al_is_sub_bitmap AlIsSubBitmap = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_get_parent_bitmap(IntPtr bitmap);

  public static al_get_parent_bitmap AlGetParentBitmap = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate int al_get_bitmap_x(IntPtr bitmap);

  public static al_get_bitmap_x AlGetBitmapX = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate int al_get_bitmap_y(IntPtr bitmap);

  public static al_get_bitmap_y AlGetBitmapY = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_reparent_bitmap(IntPtr bitmap, IntPtr parent, int x, int y, int w, int h);

  public static al_reparent_bitmap AlReparentBitmap = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_clear_to_color(AllegroColor color);

  public static al_clear_to_color AlClearToColor = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_clear_depth_buffer(float z);

  public static al_clear_depth_buffer AlClearDepthBuffer = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_draw_bitmap(IntPtr bitmap, float dx, float dy, int flags);

  public static al_draw_bitmap AlDrawBitmap = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_draw_tinted_bitmap(IntPtr bitmap, AllegroColor tint, float dx, float dy, int flags);

  public static al_draw_tinted_bitmap AlDrawTintedBitmap = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_draw_bitmap_region(IntPtr bitmap, float sx, float sy, float sw, float sh, float dx, float dy, int flags);

  public static al_draw_bitmap_region AlDrawBitmapRegion = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_draw_tinted_bitmap_region(IntPtr bitmap, AllegroColor tint, float sx, float sy, float sw, float sh, float dx, float dy, int flags);

  public static al_draw_tinted_bitmap_region AlDrawTintedBitmapRegion = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_draw_pixel(float x, float y, AllegroColor color);

  public static al_draw_pixel AlDrawPixel = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_draw_rotated_bitmap(IntPtr bitmap, float cx, float cy, float dx, float dy, float angle, int flags);

  public static al_draw_rotated_bitmap AlDrawRotatedBitmap = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_draw_tinted_rotated_bitmap(IntPtr bitmap, AllegroColor tint, float cx, float cy, float dx, float dy, float angle, int flags);

  public static al_draw_tinted_rotated_bitmap AlDrawTintedRotatedBitmap = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_draw_scaled_rotated_bitmap(IntPtr bitmap, float cx, float cy, float dx, float dy, float xscale, float yscale, float angle, int flags);

  public static al_draw_scaled_rotated_bitmap AlDrawScaledRotatedBitmap = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_draw_tinted_scaled_rotated_bitmap(IntPtr bitmap, AllegroColor tint, float cx, float cy, float dx, float dy, float xscale, float yscale, float angle, int flags);

  public static al_draw_tinted_scaled_rotated_bitmap AlDrawTintedScaledRotatedBitmap = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_draw_tinted_scaled_rotated_bitmap_region(IntPtr bitmap, float sx, float sy, float sw, float sh, AllegroColor tint, float cx, float cy, float dx, float dy, float xscale, float yscale, float angle, int flags);

  public static al_draw_tinted_scaled_rotated_bitmap_region AlDrawTintedScaledRotatedBitmapRegion = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_draw_scaled_bitmap(IntPtr bitmap, float sx, float sy, float sw, float sh, float dx, float dy, float dw, float dh, int flags);

  public static al_draw_scaled_bitmap AlDrawScaledBitmap = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_draw_tinted_scaled_bitmap(IntPtr bitmap, AllegroColor tint, float sx, float sy, float sw, float sh, float dx, float dy, float dw, float dh, int flags);

  public static al_draw_tinted_scaled_bitmap AlDrawTintedScaledBitmap = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_get_target_bitmap();

  public static al_get_target_bitmap AlGetTargetBitmap = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_put_pixel(int x, int y, AllegroColor color);

  public static al_put_pixel AlPutPixel = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_put_blended_pixel(int x, int y, AllegroColor color);

  public static al_put_blended_pixel AlPutBlendedPixel = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_set_target_bitmap(IntPtr bitmap);

  public static al_set_target_bitmap AlSetTargetBitmap = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_set_target_backbuffer(IntPtr display);

  public static al_set_target_backbuffer AlSetTargetBackbuffer = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_get_current_display();

  public static al_get_current_display AlGetCurrentDisplay = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_get_blender(ref int op, ref int src, ref int dst);

  public static al_get_blender AlGetBlender = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_get_separate_blender(ref int op, ref int src, ref int dst, ref int alpha_op, ref int alpha_src, ref int alpha_dst);

  public static al_get_separate_blender AlGetSeparateBlender = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate AllegroColor al_get_blend_color();

  public static al_get_blend_color AlGetBlendColor = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_set_blender(int op, int src, int dst);

  public static al_set_blender AlSetBlender = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_set_separate_blender(int op, int src, int dst, int alpha_op, int alpha_src, int alpha_dst);

  public static al_set_separate_blender AlSetSeparateBlender = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_set_blend_color(AllegroColor color);

  public static al_set_blend_color AlSetBlendColor = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_get_clipping_rectangle(ref int x, ref int y, ref int w, ref int h);

  public static al_get_clipping_rectangle AlGetClippingRectangle = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_set_clipping_rectangle(int x, int y, int width, int height);

  public static al_set_clipping_rectangle AlSetClippingRectangle = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_reset_clipping_rectangle();

  public static al_reset_clipping_rectangle AlResetClippingRectangle = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_convert_mask_to_alpha(IntPtr bitmap, AllegroColor mask_color);

  public static al_convert_mask_to_alpha AlConvertMaskToAlpha = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_hold_bitmap_drawing([MarshalAs(UnmanagedType.U1)] bool hold);

  public static al_hold_bitmap_drawing AlHoldBitmapDrawing = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_is_bitmap_drawing_held();

  public static al_is_bitmap_drawing_held AlIsBitmapDrawingHeld = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_register_bitmap_loader(IntPtr extension, RegisterBitmapLoader loader);

  public static al_register_bitmap_loader AlRegisterBitmapLoader = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_register_bitmap_saver(IntPtr extension, RegisterBitmapSaver saver);

  public static al_register_bitmap_saver AlRegisterBitmapSaver = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_register_bitmap_loader_f(IntPtr extension, RegisterBitmapLoaderF fs_loader);

  public static al_register_bitmap_loader_f AlRegisterBitmapLoaderF = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_register_bitmap_saver_f(IntPtr extension, RegisterBitmapSaverF fs_saver);

  public static al_register_bitmap_saver_f AlRegisterBitmapSaverF = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_load_bitmap(IntPtr filename);

  public static al_load_bitmap AlLoadBitmap = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_load_bitmap_flags(IntPtr filename, int flags);

  public static al_load_bitmap_flags AlLoadBitmapFlags = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_load_bitmap_f(IntPtr fp, IntPtr ident);

  public static al_load_bitmap_f AlLoadBitmapF = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_load_bitmap_flags_f(IntPtr fp, IntPtr ident, int flags);

  public static al_load_bitmap_flags_f AlLoadBitmapFlagsF = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_save_bitmap(IntPtr filename, IntPtr bitmap);

  public static al_save_bitmap AlSaveBitmap = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_save_bitmap_f(IntPtr fp, IntPtr ident, IntPtr bitmap);

  public static al_save_bitmap_f AlSaveBitmapF = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_register_bitmap_identifier(IntPtr extension, RegisterBitmapIdentifier identifier);

  public static al_register_bitmap_identifier AlRegisterBitmapIdentifier = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_identify_bitmap(IntPtr filename);

  public static al_identify_bitmap AlIdentifyBitmap = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_identify_bitmap_f(IntPtr fp);

  public static al_identify_bitmap_f AlIdentifyBitmapF = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_set_render_state(int state, int value);

  public static al_set_render_state AlSetRenderState = null!;

  #endregion Graphics routines

  #region Image IO routines

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_init_image_addon();

  public static al_init_image_addon AlInitImageAddon = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_is_image_addon_initialized();

  public static al_is_image_addon_initialized AlIsImageAddonInitialized = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_shutdown_image_addon();

  public static al_shutdown_image_addon AlShutdownImageAddon = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate uint al_get_allegro_image_version();

  public static al_get_allegro_image_version AlGetAllegroImageVersion = null!;

  #endregion

  #region Joystick routines

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_install_joystick();

  public static al_install_joystick AlInstallJoystick = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_uninstall_joystick();

  public static al_uninstall_joystick AlUninstallJoystick = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_is_joystick_installed();

  public static al_is_joystick_installed AlIsJoystickInstalled = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_reconfigure_joysticks();

  public static al_reconfigure_joysticks AlReconfigureJoysticks = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate int al_get_num_joysticks();

  public static al_get_num_joysticks AlGetNumJoysticks = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_get_joystick(int num);

  public static al_get_joystick AlGetJoystick = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_release_joystick(IntPtr joy);

  public static al_release_joystick AlReleaseJoystick = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_get_joystick_active(IntPtr joy);

  public static al_get_joystick_active AlGetJoystickActive = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_get_joystick_name(IntPtr joy);

  public static al_get_joystick_name AlGetJoystickName = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_get_joystick_stick_name(IntPtr joy, int stick);

  public static al_get_joystick_stick_name AlGetJoystickStickName = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_get_joystick_axis_name(IntPtr joy, int stick, int axis);

  public static al_get_joystick_axis_name AlGetJoystickAxisName = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_get_joystick_button_name(IntPtr joy, int button);

  public static al_get_joystick_button_name AlGetJoystickButtonName = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate int al_get_joystick_stick_flags(IntPtr joy, int stick);

  public static al_get_joystick_stick_flags AlGetJoystickStickFlags = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate int al_get_joystick_num_sticks(IntPtr joy);

  public static al_get_joystick_num_sticks AlGetJoystickNumSticks = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate int al_get_joystick_num_axes(IntPtr joy, int stick);

  public static al_get_joystick_num_axes AlGetJoystickNumAxes = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate int al_get_joystick_num_buttons(IntPtr joy);

  public static al_get_joystick_num_buttons AlGetJoystickNumButtons = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_get_joystick_state(IntPtr joy, ref AllegroJoystickState.NativeJoystickState ret_state);

  public static al_get_joystick_state AlGetJoystickState = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_get_joystick_event_source();

  public static al_get_joystick_event_source AlGetJoystickEventSource = null!;

  #endregion Joystick routines

  #region Keyboard routines

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_install_keyboard();

  public static al_install_keyboard AlInstallKeyboard = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_is_keyboard_installed();

  public static al_is_keyboard_installed AlIsKeyboardInstalled = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_uninstall_keyboard();

  public static al_uninstall_keyboard AlUninstallKeyboard = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_get_keyboard_state(ref AllegroKeyboardState.NativeKeyboardState ret_state);

  public static al_get_keyboard_state AlGetKeyboardState = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_key_down(ref AllegroKeyboardState.NativeKeyboardState state, int keycode);

  public static al_key_down AlKeyDown = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_keycode_to_name(int keycode);

  public static al_keycode_to_name AlKeycodeToName = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_set_keyboard_leds(int leds);

  public static al_set_keyboard_leds AlSetKeyboardLeds = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_get_keyboard_event_source();

  public static al_get_keyboard_event_source AlGetKeyboardEventSource = null!;

  #endregion Keyboard routines

  #region Memfile routines

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_open_memfile(IntPtr mem, long size, IntPtr mode);

  public static al_open_memfile AlOpenMemfile = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate uint al_get_allegro_memfile_version();

  public static al_get_allegro_memfile_version AlGetAllegroMemfileVersion = null!;

  #endregion

  #region Memory routines

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_malloc_with_context(UIntPtr n, int line, IntPtr file, IntPtr func);

  public static al_malloc_with_context AlMallocWithContext = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_free_with_context(IntPtr ptr, int line, IntPtr file, IntPtr func);

  public static al_free_with_context AlFreeWithContext = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_realloc_with_context(IntPtr ptr, UIntPtr n, int line, IntPtr file, IntPtr func);

  public static al_realloc_with_context AlReallocWithContext = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_calloc_with_context(UIntPtr count, UIntPtr n, int line, IntPtr file, IntPtr func);

  public static al_calloc_with_context AlCallocWithContext = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_set_memory_interface(ref AllegroMemoryInterface.NativeMemoryInterface memory_interface);

  public static al_set_memory_interface AlSetMemoryInterface = null!;

  #endregion Memory routines

  #region Monitor routines

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate int al_get_new_display_adapter();

  public static al_get_new_display_adapter AlGetNewDisplayAdapter = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_set_new_display_adapter(int adapter);

  public static al_set_new_display_adapter AlSetNewDisplayAdapter = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_get_monitor_info(int adapter, ref AllegroMonitorInfo.NativeMonitorInfo info);

  public static al_get_monitor_info AlGetMonitorInfo = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate int al_get_monitor_dpi(int adapter);

  public static al_get_monitor_dpi AlGetMonitorDpi = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate int al_get_num_video_adapters();

  public static al_get_num_video_adapters AlGetNumVideoAdapters = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate int al_get_monitor_refresh_rate(int adapter);

  public static al_get_monitor_refresh_rate AlGetMonitorRefreshRate = null!;

  #endregion Monitor routines

  #region Mouse routines

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_install_mouse();

  public static al_install_mouse AlInstallMouse = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_is_mouse_installed();

  public static al_is_mouse_installed AlIsMouseInstalled = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_uninstall_mouse();

  public static al_uninstall_mouse AlUninstallMouse = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate uint al_get_mouse_num_axes();

  public static al_get_mouse_num_axes AlGetMouseNumAxes = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate uint al_get_mouse_num_buttons();

  public static al_get_mouse_num_buttons AlGetMouseNumButtons = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_get_mouse_state(ref AllegroMouseState.NativeMouseState ret_state);

  public static al_get_mouse_state AlGetMouseState = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate int al_get_mouse_state_axis(ref AllegroMouseState.NativeMouseState ret_state, int axis);

  public static al_get_mouse_state_axis AlGetMouseStateAxis = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_mouse_button_down(ref AllegroMouseState.NativeMouseState ret_state, int button);

  public static al_mouse_button_down AlMouseButtonDown = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_set_mouse_xy(IntPtr display, int x, int y);

  public static al_set_mouse_xy AlSetMouseXY = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_set_mouse_z(int z);

  public static al_set_mouse_z AlSetMouseZ = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_set_mouse_w(int w);

  public static al_set_mouse_w AlSetMouseW = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_set_mouse_axis(int which, int value);

  public static al_set_mouse_axis AlSetMouseAxis = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_get_mouse_event_source();

  public static al_get_mouse_event_source AlGetMouseEventSource = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_set_mouse_wheel_precision(int precision);

  public static al_set_mouse_wheel_precision AlSetMouseWheelPrecision = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate int al_get_mouse_wheel_precision();

  public static al_get_mouse_wheel_precision AlGetMouseWheelPrecision = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_create_mouse_cursor(IntPtr bmp, int x_focus, int y_focus);

  public static al_create_mouse_cursor AlCreateMouseCursor = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_destroy_mouse_cursor(IntPtr cursor);

  public static al_destroy_mouse_cursor AlDestroyMouseCursor = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_set_mouse_cursor(IntPtr display, IntPtr cursor);

  public static al_set_mouse_cursor AlSetMouseCursor = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_set_system_mouse_cursor(IntPtr display, int cursor_id);

  public static al_set_system_mouse_cursor AlSetSystemMouseCursor = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_get_mouse_cursor_position(ref int ret_x, ref int ret_y);

  public static al_get_mouse_cursor_position AlGetMouseCursorPosition = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_hide_mouse_cursor(IntPtr display);

  public static al_hide_mouse_cursor AlHideMouseCursor = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_show_mouse_cursor(IntPtr display);

  public static al_show_mouse_cursor AlShowMouseCursor = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_grab_mouse(IntPtr display);

  public static al_grab_mouse AlGrabMouse = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_ungrab_mouse();

  public static al_ungrab_mouse AlUngrabMouse = null!;

  #endregion Mouse routines

  #region Native dialog routines

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_init_native_dialog_addon();

  public static al_init_native_dialog_addon AlInitNativeDialogAddon = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_is_native_dialog_addon_initialized();

  public static al_is_native_dialog_addon_initialized AlIsNativeDialogAddonInitialized = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_shutdown_native_dialog_addon();

  public static al_shutdown_native_dialog_addon AlShutdownNativeDialogAddon = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_create_native_file_dialog(IntPtr initial_path, IntPtr title, IntPtr patterns, int mode);

  public static al_create_native_file_dialog AlCreateNativeFileDialog = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_show_native_file_dialog(IntPtr display, IntPtr dialog);

  public static al_show_native_file_dialog AlShowNativeFileDialog = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate int al_get_native_file_dialog_count(IntPtr dialog);

  public static al_get_native_file_dialog_count AlGetNativeFileDialogCount = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_get_native_file_dialog_path(IntPtr dialog, ulong i);

  public static al_get_native_file_dialog_path AlGetNativeFileDialogPath = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_destroy_native_file_dialog(IntPtr dialog);

  public static al_destroy_native_file_dialog AlDestroyNativeFileDialog = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate int al_show_native_message_box(IntPtr display, IntPtr title, IntPtr heading, IntPtr text, IntPtr buttons, int flags);

  public static al_show_native_message_box AlShowNativeMessageBox = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_open_native_text_log(IntPtr title, int flags);

  public static al_open_native_text_log AlOpenNativeTextLog = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_close_native_text_log(IntPtr textlog);

  public static al_close_native_text_log AlCloseNativeTextLog = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_append_native_text_log(IntPtr textlog, IntPtr format);

  public static al_append_native_text_log AlAppendNativeTextLog = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_get_native_text_log_event_source(IntPtr textlog);

  public static al_get_native_text_log_event_source AlGetNativeTextLogEventSource = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate uint al_get_allegro_native_dialog_version();

  public static al_get_allegro_native_dialog_version AlGetAllegroNativeDialogVersion = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_create_menu();

  public static al_create_menu AlCreateMenu = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_create_popup_menu();

  public static al_create_popup_menu AlCreatePopupMenu = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_build_menu(IntPtr info);

  public static al_build_menu AlBuildMenu = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate int al_append_menu_item(IntPtr parent, IntPtr title, ushort id, int flags, IntPtr icon, IntPtr submenu);

  public static al_append_menu_item AlAppendMenuItem = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate int al_insert_menu_item(IntPtr parent, int pos, IntPtr title, ushort id, int flags, IntPtr icon, IntPtr submenu);

  public static al_insert_menu_item AlInsertMenuItem = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_remove_menu_item(IntPtr menu, int pos);

  public static al_remove_menu_item AlRemoveMenuItem = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_clone_menu(IntPtr menu);

  public static al_clone_menu AlCloneMenu = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_clone_menu_for_popup(IntPtr menu);

  public static al_clone_menu_for_popup AlCloneMenuForPopup = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_destroy_menu(IntPtr menu);

  public static al_destroy_menu AlDestroyMenu = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_get_menu_item_caption(IntPtr menu, int pos);

  public static al_get_menu_item_caption AlGetMenuItemCaption = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_set_menu_item_caption(IntPtr menu, int pos, IntPtr caption);

  public static al_set_menu_item_caption AlSetMenuItemCaption = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate int al_get_menu_item_flags(IntPtr menu, int pos);

  public static al_get_menu_item_flags AlGetMenuItemFlags = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_set_menu_item_flags(IntPtr menu, int pos, int flags);

  public static al_set_menu_item_flags AlSetMenuItemFlags = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_get_menu_item_icon(IntPtr menu, int pos);

  public static al_get_menu_item_icon AlGetMenuItemIcon = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_set_menu_item_icon(IntPtr menu, int pos, IntPtr icon);

  public static al_set_menu_item_icon AlSetMenuItemIcon = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_find_menu(IntPtr haystack, ushort id);

  public static al_find_menu AlFindMenu = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_find_menu_item(IntPtr haystack, ushort id, ref IntPtr menu, ref int index);

  public static al_find_menu_item AlFindMenuItem = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_get_default_menu_event_source();

  public static al_get_default_menu_event_source AlGetDefaultMenuEventSource = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_enable_menu_event_source(IntPtr menu);

  public static al_enable_menu_event_source AlEnableMenuEventSource = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_disable_menu_event_source(IntPtr menu);

  public static al_disable_menu_event_source AlDisableMenuEventSource = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_get_display_menu(IntPtr display);

  public static al_get_display_menu AlGetDisplayMenu = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_set_display_menu(IntPtr display, IntPtr menu);

  public static al_set_display_menu AlSetDisplayMenu = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_popup_menu(IntPtr popup, IntPtr display);

  public static al_popup_menu AlPopupMenu = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_remove_display_menu(IntPtr display);

  public static al_remove_display_menu AlRemoveDisplayMenu = null!;

  #endregion Native dialog routines

  #region Path routines

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_create_path(IntPtr str);

  public static al_create_path AlCreatePath = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_create_path_for_directory(IntPtr str);

  public static al_create_path_for_directory AlCreatePathForDirectory = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_destroy_path(IntPtr path);

  public static al_destroy_path AlDestroyPath = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_clone_path(IntPtr path);

  public static al_clone_path AlClonePath = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_join_paths(IntPtr path, IntPtr tail);

  public static al_join_paths AlJoinPaths = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_rebase_path(IntPtr head, IntPtr tail);

  public static al_rebase_path AlRebasePath = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_get_path_drive(IntPtr path);

  public static al_get_path_drive AlGetPathDrive = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate int al_get_path_num_components(IntPtr path);

  public static al_get_path_num_components AlGetPathNumComponents = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_get_path_component(IntPtr path, int i);

  public static al_get_path_component AlGetPathComponent = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_get_path_tail(IntPtr path);

  public static al_get_path_tail AlGetPathTail = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_get_path_filename(IntPtr path);

  public static al_get_path_filename AlGetPathFilename = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_get_path_basename(IntPtr path);

  public static al_get_path_basename AlGetPathBasename = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_get_path_extension(IntPtr path);

  public static al_get_path_extension AlGetPathExtension = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_set_path_drive(IntPtr path, IntPtr drive);

  public static al_set_path_drive AlSetPathDrive = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_append_path_component(IntPtr path, IntPtr s);

  public static al_append_path_component AlAppendPathComponent = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_insert_path_component(IntPtr path, int i, IntPtr s);

  public static al_insert_path_component AlInsertPathComponent = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_replace_path_component(IntPtr path, int i, IntPtr s);

  public static al_replace_path_component AlReplacePathComponent = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_remove_path_component(IntPtr path, int i);

  public static al_remove_path_component AlRemovePathComponent = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_drop_path_tail(IntPtr path);

  public static al_drop_path_tail AlDropPathTail = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_set_path_filename(IntPtr path, IntPtr filename);

  public static al_set_path_filename AlSetPathFilename = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_set_path_extension(IntPtr path, IntPtr extension);

  public static al_set_path_extension AlSetPathExtension = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_path_cstr(IntPtr path, char delim);

  public static al_path_cstr AlPathCstr = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_path_ustr(IntPtr path, char delim);

  public static al_path_ustr AlPathUstr = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_make_path_canonical(IntPtr path);

  public static al_make_path_canonical AlMakePathCanonical = null!;

  #endregion Path routines

  #region Physfs routines

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_set_physfs_file_interface();

  public static al_set_physfs_file_interface AlSetPhysfsFileInterface = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate uint al_get_allegro_physfs_version();

  public static al_get_allegro_physfs_version AlGetAllegroPhysfsVersion = null!;

  #endregion

  #region Platform-specific routines

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_get_win_window_handle(IntPtr display);

  public static al_get_win_window_handle? AlGetWinWindowHandle = null!;

  #endregion

  #region Primitives routines

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate uint al_get_allegro_primitives_version();

  public static al_get_allegro_primitives_version AlGetAllegroPrimitivesVersion = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_init_primitives_addon();

  public static al_init_primitives_addon AlInitPrimitivesAddon = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_is_primitives_addon_initialized();

  public static al_is_primitives_addon_initialized AlIsPrimitivesAddonInitialized = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_shutdown_primitives_addon();

  public static al_shutdown_primitives_addon AlShutdownPrimitivesAddon = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_draw_line(float x1, float y1, float x2, float y2, AllegroColor color, float thickness);

  public static al_draw_line AlDrawLine = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_draw_triangle(float x1, float y1, float x2, float y2, float x3, float y3, AllegroColor color, float thickness);

  public static al_draw_triangle AlDrawTriangle = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_draw_filled_triangle(float x1, float y1, float x2, float y2, float x3, float y3, AllegroColor color);

  public static al_draw_filled_triangle AlDrawFilledTriangle = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_draw_rectangle(float x1, float y1, float x2, float y2, AllegroColor color, float thickness);

  public static al_draw_rectangle AlDrawRectangle = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_draw_filled_rectangle(float x1, float y1, float x2, float y2, AllegroColor color);

  public static al_draw_filled_rectangle AlDrawFilledRectangle = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_draw_rounded_rectangle(float x1, float y1, float x2, float y2, float rx, float ry, AllegroColor color, float thickness);

  public static al_draw_rounded_rectangle AlDrawRoundedRectangle = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_draw_filled_rounded_rectangle(float x1, float y1, float x2, float y2, float rx, float ry, AllegroColor color);

  public static al_draw_filled_rounded_rectangle AlDrawFilledRoundedRectangle = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_calculate_arc(ref float[] dest, int stride, float cx, float cy, float rx, float ry, float start_theta, float delta_theta, float thickness, int num_points);

  public static al_calculate_arc AlCalculateArc = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_draw_pieslice(float cx, float cy, float r, float start_theta, float delta_theta, AllegroColor color, float thickness);

  public static al_draw_pieslice AlDrawPieslice = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_draw_filled_pieslice(float cx, float cy, float r, float start_theta, float delta_theta, AllegroColor color);

  public static al_draw_filled_pieslice AlDrawFilledPieslice = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_draw_ellipse(float cx, float cy, float rx, float ry, AllegroColor color, float thickness);

  public static al_draw_ellipse AlDrawEllipse = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_draw_filled_ellipse(float cx, float cy, float rx, float ry, AllegroColor color);

  public static al_draw_filled_ellipse AlDrawFilledEllipse = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_draw_circle(float cx, float cy, float r, AllegroColor color, float thickness);

  public static al_draw_circle AlDrawCircle = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_draw_filled_circle(float cx, float cy, float r, AllegroColor color);

  public static al_draw_filled_circle AlDrawFilledCircle = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_draw_arc(float cx, float cy, float r, float start_theta, float delta_theta, AllegroColor color, float thickness);

  public static al_draw_arc AlDrawArc = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_draw_elliptical_arc(float cx, float cy, float rx, float ry, float start_theta, float delta_theta, AllegroColor color, float thickness);

  public static al_draw_elliptical_arc AlDrawEllipticalArc = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_calculate_spline(ref float[] dest, int stride, float[] points, float thickness, int num_segments);

  public static al_calculate_spline AlCalculateSpline = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_draw_spline(float[] points, AllegroColor color, float thickness);

  public static al_draw_spline AlDrawSpline = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_calculate_ribbon(ref float[] dest, int dest_stride, ref float[] points, int points_stride, float thickness, int num_segments);

  public static al_calculate_ribbon AlCalculateRibbon = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_draw_ribbon(ref float[] points, int points_stride, AllegroColor color, float thickness, int num_segments);

  public static al_draw_ribbon AlDrawRibbon = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate int al_draw_prim(
    [MarshalAs(UnmanagedType.LPArray)] AllegroVertex[] vtxs,
    IntPtr decl,
    IntPtr texture,
    int start,
    int end,
    int type);

  public static al_draw_prim AlDrawPrim = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate int al_draw_indexed_prim(
    [MarshalAs(UnmanagedType.LPArray)] AllegroVertex[] vtxs,
    IntPtr decl,
    IntPtr texture,
    [MarshalAs(UnmanagedType.LPArray)] int[] indices,
    int num_vtx,
    int type);

  public static al_draw_indexed_prim AlDrawIndexedPrim = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate int al_draw_vertex_buffer(IntPtr vertex_buffer, IntPtr texture, int start, int end, int type);

  public static al_draw_vertex_buffer AlDrawVertexBuffer = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate int al_draw_indexed_buffer(IntPtr vertex_buffer, IntPtr texture, IntPtr index_buffer, int start, int end, int type);

  public static al_draw_indexed_buffer AlDrawIndexedBuffer = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate int al_draw_soft_triangle(IntPtr v1, IntPtr v2, IntPtr v3, UIntPtr state, IntPtr init, IntPtr first, IntPtr step, IntPtr draw);

  public static al_draw_soft_triangle AlDrawSoftTriangle = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate int al_draw_soft_line(IntPtr v1, IntPtr v2, UIntPtr state, IntPtr first, IntPtr step, IntPtr draw);

  public static al_draw_soft_line AlDrawSoftLine = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_create_vertex_decl(NativeAllegroVertexElement[] elements, int stride);

  public static al_create_vertex_decl AlCreateVertexDecl = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_destroy_vertex_decl(IntPtr decl);

  public static al_destroy_vertex_decl AlDestroyVertexDecl = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_create_vertex_buffer(IntPtr decl, IntPtr initial_data, int num_vertices, int flags);

  public static al_create_vertex_buffer AlCreateVertexBuffer = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_destroy_vertex_buffer(IntPtr buffer);

  public static al_destroy_vertex_buffer AlDestroyVertexBuffer = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_lock_vertex_buffer(IntPtr buffer, int offset, int length, int flags);

  public static al_lock_vertex_buffer AlLockVertexBuffer = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_unlock_vertex_buffer(IntPtr buffer);

  public static al_unlock_vertex_buffer AlUnlockVertexBuffer = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate int al_get_vertex_buffer_size(IntPtr buffer);

  public static al_get_vertex_buffer_size AlGetVertexBufferSize = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_create_index_buffer(int index_size, IntPtr initial_data, int num_indices, int flags);

  public static al_create_index_buffer AlCreateIndexBuffer = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_destroy_index_buffer(IntPtr buffer);

  public static al_destroy_index_buffer AlDestroyIndexBuffer = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_lock_index_buffer(IntPtr buffer, int offset, int length, int flags);

  public static al_lock_index_buffer AlLockIndexBuffer = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_unlock_index_buffer(IntPtr buffer);

  public static al_unlock_index_buffer AlUnlockIndexBuffer = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate int al_get_index_buffer_size(IntPtr buffer);

  public static al_get_index_buffer_size AlGetIndexBufferSize = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_draw_polyline(IntPtr vertices, int vertex_stride, int vertex_count, int join_style, int cap_style, AllegroColor color, float thickness, float miter_limit);

  public static al_draw_polyline AlDrawPolyline = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_draw_polygon(IntPtr vertices, int vertex_count, int join_style, AllegroColor color, float thickness, float miter_limit);

  public static al_draw_polygon AlDrawPolygon = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_draw_filled_polygon(IntPtr vertices, int vertex_count, AllegroColor color);

  public static al_draw_filled_polygon AlDrawFilledPolygon = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_draw_filled_polygon_with_holes(IntPtr vertices, IntPtr vertexCounts, AllegroColor color);

  public static al_draw_filled_polygon_with_holes AlDrawFilledPolygonWithHoles = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_triangulate_polygon(IntPtr vertices, long vertex_stride, IntPtr vertex_counts, EmitTriangle emit_triangle, IntPtr userdata);

  public static al_triangulate_polygon AlTriangulatePolygon = null!;

  #endregion

  #region State routines

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_restore_state(ref AllegroState.NativeAllegroState state);

  public static al_restore_state AlRestoreState = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_store_state(ref AllegroState.NativeAllegroState state, int flags);

  public static al_store_state AlStoreState = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate int al_get_errno();

  public static al_get_errno AlGetErrno = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_set_errno(int errnum);

  public static al_set_errno AlSetErrno = null!;

  #endregion State routines

  #region System routines

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_install_system(int version, AtExitDelegate? atExit);

  public static al_install_system AlInstallSystem = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_uninstall_system();

  public static al_uninstall_system AlUninstallSystem = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_is_system_installed();

  public static al_is_system_installed AlIsSystemInstalled = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate uint al_get_allegro_version();

  public static al_get_allegro_version AlGetAllegroVersion = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_get_standard_path(int id);

  public static al_get_standard_path AlGetStandardPath = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_set_exe_name(IntPtr path);

  public static al_set_exe_name AlSetExeName = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_set_app_name(IntPtr path);

  public static al_set_app_name AlSetAppName = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_set_org_name(IntPtr path);

  public static al_set_org_name AlSetOrgName = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_get_app_name();

  public static al_get_app_name AlGetAppName = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_get_org_name();

  public static al_get_org_name AlGetOrgName = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_get_system_config();

  public static al_get_system_config AlGetSystemConfig = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate int al_get_system_id();

  public static al_get_system_id AlGetSystemID = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_register_assert_handler(RegisterAssertHandler handler);

  public static al_register_assert_handler AlRegisterAssertHandler = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_register_trace_handler(RegisterTraceHandler handler);

  public static al_register_trace_handler AlRegisterTraceHandler = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate int al_get_cpu_count();

  public static al_get_cpu_count AlGetCpuCount = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate int al_get_ram_size();

  public static al_get_ram_size AlGetRamSize = null!;

  #endregion System routines

  #region Thread routines

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_create_thread(ThreadProcess proc, IntPtr arg);

  public static al_create_thread AlCreateThread = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_start_thread(IntPtr thread);

  public static al_start_thread AlStartThread = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_join_thread(IntPtr thread, ref IntPtr ret_value);

  public static al_join_thread AlJoinThread = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_set_thread_should_stop(IntPtr thread);

  public static al_set_thread_should_stop AlSetThreadShouldStop = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_get_thread_should_stop(IntPtr thread);

  public static al_get_thread_should_stop AlGetThreadShouldStop = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_destroy_thread(IntPtr thread);

  public static al_destroy_thread AlDestroyThread = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_run_detached_thread(DetachedThreadProcess proc, IntPtr arg);

  public static al_run_detached_thread AlRunDetachedThread = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_create_mutex();

  public static al_create_mutex AlCreateMutex = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_create_mutex_recursive();

  public static al_create_mutex_recursive AlCreateMutexRecursive = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_lock_mutex(IntPtr mutex);

  public static al_lock_mutex AlLockMutex = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_unlock_mutex(IntPtr mutex);

  public static al_unlock_mutex AlUnlockMutex = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_destroy_mutex(IntPtr mutex);

  public static al_destroy_mutex AlDestroyMutex = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_create_cond();

  public static al_create_cond AlCreateCond = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_destroy_cond(IntPtr cond);

  public static al_destroy_cond AlDestroyCond = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_wait_cond(IntPtr cond, IntPtr mutex);

  public static al_wait_cond AlWaitCond = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate int al_wait_cond_until(IntPtr cond, IntPtr mutex, ref AllegroTimeout.NativeAllegroTimeout timeout);

  public static al_wait_cond_until AlWaitCondUntil = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_broadcast_cond(IntPtr cond);

  public static al_broadcast_cond AlBroadcastCond = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_signal_cond(IntPtr cond);

  public static al_signal_cond AlSignalCond = null!;

  #endregion Thread routines

  #region Time routines

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate double al_get_time();

  public static al_get_time AlGetTime = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_init_timeout(ref AllegroTimeout.NativeAllegroTimeout timeout, double seconds);

  public static al_init_timeout AlInitTimeout = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_rest(double seconds);

  public static al_rest AlRest = null!;

  #endregion Time routines

  #region Touch routines

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_install_touch_input();

  public static al_install_touch_input AlInstallTouchInput = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_uninstall_touch_input();

  public static al_uninstall_touch_input AlUninstallTouchInput = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_is_touch_input_installed();

  public static al_is_touch_input_installed AlIsTouchInputInstalled = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_get_touch_input_state(ref NativeAllegroTouchInputState ret_state);

  public static al_get_touch_input_state AlGetTouchInputState = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_get_touch_input_event_source();

  public static al_get_touch_input_event_source AlGetTouchInputEventSource = null!;

  #endregion

  #region Timer routines

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_create_timer(double speed_secs);

  public static al_create_timer ALCreateTimer = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_start_timer(IntPtr timer);

  public static al_start_timer AlStartTimer = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_resume_timer(IntPtr timer);

  public static al_resume_timer AlResumeTimer = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_stop_timer(IntPtr timer);

  public static al_stop_timer AlStopTimer = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_get_timer_started(IntPtr timer);

  public static al_get_timer_started AlGetTimerStarted = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_destroy_timer(IntPtr timer);

  public static al_destroy_timer AlDestroyTimer = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate ulong al_get_timer_count(IntPtr timer);

  public static al_get_timer_count AlGetTimerCount = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_set_timer_count(IntPtr timer, ulong new_count);

  public static al_set_timer_count AlSetTimerCount = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_add_timer_count(IntPtr timer, ulong diff);

  public static al_add_timer_count AlAddTimerCount = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate double al_get_timer_speed(IntPtr timer);

  public static al_get_timer_speed AlGetTimerSpeed = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_set_timer_speed(IntPtr timer, double new_speed_secs);

  public static al_set_timer_speed AlSetTimerSpeed = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_get_timer_event_source(IntPtr timer);

  public static al_get_timer_event_source AlGetTimerEventSource = null!;

  #endregion Timer routines

  #region Transform routines

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_copy_transform(ref AllegroTransform.NativeAllegroTransform dest, ref AllegroTransform.NativeAllegroTransform src);

  public static al_copy_transform AlCopyTransform = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_use_transform(ref AllegroTransform.NativeAllegroTransform trans);

  public static al_use_transform AlUseTransform = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_get_current_transform();

  public static al_get_current_transform AlGetCurrentTransform = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_use_projection_transform(ref AllegroTransform.NativeAllegroTransform trans);

  public static al_use_projection_transform AlUseProjectionTransform = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_get_current_projection_transform();

  public static al_get_current_projection_transform AlGetCurrentProjectionTransform = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_get_current_inverse_transform();

  public static al_get_current_inverse_transform AlGetCurrentInverseTransform = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_invert_transform(ref AllegroTransform.NativeAllegroTransform trans);

  public static al_invert_transform AlInvertTransform = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_transpose_transform(ref AllegroTransform.NativeAllegroTransform trans);

  public static al_transpose_transform AlTransposeTransform = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate int al_check_inverse(ref AllegroTransform.NativeAllegroTransform trans, float tol);

  public static al_check_inverse AlCheckInverse = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_identity_transform(ref AllegroTransform.NativeAllegroTransform trans);

  public static al_identity_transform AlIdentityTransform = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_build_transform(ref AllegroTransform.NativeAllegroTransform trans, float x, float y, float sx, float sy, float theta);

  public static al_build_transform AlBuildTransform = null!;

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

  public static al_build_camera_transform AlBuildCameraTransform = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_translate_transform(ref AllegroTransform.NativeAllegroTransform trans, float x, float y);

  public static al_translate_transform AlTranslateTransform = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_rotate_transform(ref AllegroTransform.NativeAllegroTransform trans, float theta);

  public static al_rotate_transform AlRotateTransform = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_scale_transform(ref AllegroTransform.NativeAllegroTransform trans, float sx, float sy);

  public static al_scale_transform AlScaleTransform = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_transform_coordinates(ref AllegroTransform.NativeAllegroTransform trans, ref float x, ref float y);

  public static al_transform_coordinates AlTransformCoordinates = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_transform_coordinates_3d(ref AllegroTransform.NativeAllegroTransform trans, ref float x, ref float y, ref float z);

  public static al_transform_coordinates_3d AlTransformCoordinates3D = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_transform_coordinates_4d(ref AllegroTransform.NativeAllegroTransform trans, ref float x, ref float y, ref float z, ref float w);

  public static al_transform_coordinates_4d AlTransformCoordinates4D = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_transform_coordinates_3d_projective(ref AllegroTransform.NativeAllegroTransform trans, ref float x, ref float y, ref float z);

  public static al_transform_coordinates_3d_projective AlTransformCoordinates3DProjective = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_compose_transform(ref AllegroTransform.NativeAllegroTransform trans, ref AllegroTransform.NativeAllegroTransform other);

  public static al_compose_transform AlComposeTransform = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_orthographic_transform(
      ref AllegroTransform.NativeAllegroTransform trans,
      float left,
      float top,
      float n,
      float right,
      float bottom,
      float f);

  public static al_orthographic_transform AlOrthographicTransform = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_perspective_transform(
      ref AllegroTransform.NativeAllegroTransform trans,
      float left,
      float top,
      float n,
      float right,
      float bottom,
      float f);

  public static al_perspective_transform AlPerspectiveTransform = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_translate_transform_3d(ref AllegroTransform.NativeAllegroTransform trans, float x, float y, float z);

  public static al_translate_transform_3d AlTranslateTransform3D = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_scale_transform_3d(ref AllegroTransform.NativeAllegroTransform trans, float sx, float sy, float sz);

  public static al_scale_transform_3d AlScaleTransform3D = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_rotate_transform_3d(ref AllegroTransform.NativeAllegroTransform trans, float x, float y, float z, float angle);

  public static al_rotate_transform_3d AlRotateTransform3D = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_horizontal_shear_transform(ref AllegroTransform.NativeAllegroTransform trans, float theta);

  public static al_horizontal_shear_transform AlHorizontalShearTransform = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_vertical_shear_transform(ref AllegroTransform.NativeAllegroTransform trans, float theta);

  public static al_vertical_shear_transform AlVerticalShearTransform = null!;

  #endregion Transform routines

  #region TTF routines

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_init_ttf_addon();

  public static al_init_ttf_addon AlInitTtfAddon = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_is_ttf_addon_initialized();

  public static al_is_ttf_addon_initialized AlIsTtfAddonInitialized = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_shutdown_ttf_addon();

  public static al_shutdown_ttf_addon AlShutdownTtfAddon = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_load_ttf_font(IntPtr filename, int size, int flags);

  public static al_load_ttf_font AlLoadTtfFont = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_load_ttf_font_f(IntPtr file, IntPtr filename, int size, int flags);

  public static al_load_ttf_font_f AlLoadTtfFontF = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_load_ttf_font_stretch(IntPtr filename, int w, int h, int flags);

  public static al_load_ttf_font_stretch AlLoadTtfFontStretch = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_load_ttf_font_stretch_f(IntPtr file, IntPtr filename, int w, int h, int flags);

  public static al_load_ttf_font_stretch_f AlLoadTtfFontStretchF = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate uint al_get_allegro_ttf_version();

  public static al_get_allegro_ttf_version AlGetAllegroTtfVersion = null!;

  #endregion

  #region UTF-8 routines

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_ustr_new(IntPtr s);

  public static al_ustr_new AlUstrNew = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_ustr_new_from_buffer(IntPtr s, long size);

  public static al_ustr_new_from_buffer AlUstrNewFromBuffer = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_ustr_free(IntPtr us);

  public static al_ustr_free AlUstrFree = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_cstr(IntPtr us);

  public static al_cstr AlCstr = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void al_ustr_to_buffer(IntPtr us, IntPtr buffer, int size);

  public static al_ustr_to_buffer AlUstrToBuffer = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_cstr_dup(IntPtr us);

  public static al_cstr_dup AlCstrDup = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_ustr_dup(IntPtr us);

  public static al_ustr_dup AlUstrDup = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_ustr_dup_substr(IntPtr us, int start_pos, int end_pos);

  public static al_ustr_dup_substr AlUstrDupSubstr = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_ustr_empty_string();

  public static al_ustr_empty_string AlUstrEmptyString = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_ref_cstr(ref AllegroUstrInfo.NativeAllegroUstrInfo info, IntPtr s);

  public static al_ref_cstr AlRefCstr = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_ref_buffer(ref AllegroUstrInfo.NativeAllegroUstrInfo info, IntPtr s, long size);

  public static al_ref_buffer AlRefBuffer = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_ref_ustr(ref AllegroUstrInfo.NativeAllegroUstrInfo info, IntPtr us, int start_pos, int end_pos);

  public static al_ref_ustr AlRefUstr = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate long al_ustr_size(IntPtr us);

  public static al_ustr_size AlUstrSize = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate long al_ustr_length(IntPtr us);

  public static al_ustr_length AlUstrLength = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate int al_ustr_offset(IntPtr us, int index);

  public static al_ustr_offset AlUstrOffset = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_ustr_next(IntPtr us, ref int pos);

  public static al_ustr_next AlUstrNext = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_ustr_prev(IntPtr us, ref int pos);

  public static al_ustr_prev AlUstrPrev = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate int al_ustr_get(IntPtr ub, int pos);

  public static al_ustr_get AlUstrGet = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate int al_ustr_get_next(IntPtr ub, ref int pos);

  public static al_ustr_get_next AlUstrGetNext = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate int al_ustr_prev_get(IntPtr ub, ref int pos);

  public static al_ustr_prev_get AlUstrPrevGet = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_ustr_insert(IntPtr us1, int pos, IntPtr us2);

  public static al_ustr_insert AlUstrInsert = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_ustr_insert_cstr(IntPtr us, int pos, IntPtr s);

  public static al_ustr_insert_cstr AlUstrInsertCstr = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate long al_ustr_insert_chr(IntPtr us, int pos, int c);

  public static al_ustr_insert_chr AlUstrInsertChr = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_ustr_append(IntPtr us1, IntPtr us2);

  public static al_ustr_append AlUstrAppend = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_ustr_append_cstr(IntPtr us, IntPtr s);

  public static al_ustr_append_cstr AlUstrAppendCstr = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate long al_ustr_append_chr(IntPtr us, int c);

  public static al_ustr_append_chr AlUstrAppendChr = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_ustr_remove_chr(IntPtr us, int pos);

  public static al_ustr_remove_chr AlUstrRemoveChr = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_ustr_remove_range(IntPtr us, int start_pos, int end_pos);

  public static al_ustr_remove_range AlUstrRemoveRange = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_ustr_truncate(IntPtr us, int start_pos);

  public static al_ustr_truncate AlUstrTruncate = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_ustr_ltrim_ws(IntPtr us);

  public static al_ustr_ltrim_ws AlUstrLtrimWs = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_ustr_rtrim_ws(IntPtr us);

  public static al_ustr_rtrim_ws AlUstrRtrimWs = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_ustr_trim_ws(IntPtr us);

  public static al_ustr_trim_ws AlUstrTrimWs = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_ustr_assign(IntPtr us1, IntPtr us2);

  public static al_ustr_assign AlUstrAssign = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_ustr_assign_substr(IntPtr us1, IntPtr us2, int start_pos, int end_pos);

  public static al_ustr_assign_substr AlUstrAssignSubstr = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_ustr_assign_cstr(IntPtr us1, IntPtr s);

  public static al_ustr_assign_cstr AlUstrAssignCstr = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate long al_ustr_set_chr(IntPtr us, int start_pos, int c);

  public static al_ustr_set_chr AlUstrSetChr = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_ustr_replace_range(IntPtr us1, int start_pos1, int end_pos1, IntPtr us2);

  public static al_ustr_replace_range AlUstrReplaceRange = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate int al_ustr_find_chr(IntPtr us, int start_pos1, int c);

  public static al_ustr_find_chr AlUstrFindChr = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate int al_ustr_rfind_chr(IntPtr us, int end_pos, int c);

  public static al_ustr_rfind_chr AlUstrRFindChr = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate int al_ustr_find_set(IntPtr us, int start_pos, IntPtr accept);

  public static al_ustr_find_set AlUstrFindSet = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate int al_ustr_find_set_cstr(IntPtr us, int start_pos, IntPtr accept);

  public static al_ustr_find_set_cstr AlUstrFindSetCstr = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate int al_ustr_find_cset(IntPtr us, int start_pos, IntPtr reject);

  public static al_ustr_find_cset AlUstrFindCset = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate int al_ustr_find_cset_cstr(IntPtr us, int start_pos, IntPtr reject);

  public static al_ustr_find_cset_cstr AlUstrFindCsetCstr = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate int al_ustr_find_str(IntPtr haystack, int start_pos, IntPtr needle);

  public static al_ustr_find_str AlUstrFindStr = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate int al_ustr_find_cstr(IntPtr haystack, int start_pos, IntPtr needle);

  public static al_ustr_find_cstr AlUstrFindCstr = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate int al_ustr_rfind_str(IntPtr haystack, int end_pos, IntPtr needle);

  public static al_ustr_rfind_str AlUstrRfindStr = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate int al_ustr_rfind_cstr(IntPtr haystack, int end_pos, IntPtr needle);

  public static al_ustr_rfind_cstr AlUstrRfindCstr = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_ustr_find_replace(IntPtr us, int start_pos, IntPtr find, IntPtr replace);

  public static al_ustr_find_replace AlUstrFindReplace = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_ustr_find_replace_cstr(IntPtr us, int start_pos, IntPtr find, IntPtr replace);

  public static al_ustr_find_replace_cstr AlUstrFindReplaceCstr = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_ustr_equal(IntPtr us1, IntPtr us2);

  public static al_ustr_equal AlUstrEqual = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate int al_ustr_compare(IntPtr us1, IntPtr us2);

  public static al_ustr_compare AlUstrCompare = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate int al_ustr_ncompare(IntPtr us1, IntPtr us2, int n);

  public static al_ustr_ncompare AlUstrNcompare = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_ustr_has_prefix(IntPtr us1, IntPtr us2);

  public static al_ustr_has_prefix AlUstrHasPrefix = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_ustr_has_prefix_cstr(IntPtr us1, IntPtr us2);

  public static al_ustr_has_prefix_cstr AlUstrHasPrefixCstr = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_ustr_has_suffix(IntPtr us1, IntPtr us2);

  public static al_ustr_has_suffix AlUstrHasSuffix = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: MarshalAs(UnmanagedType.U1)]
  public delegate bool al_ustr_has_suffix_cstr(IntPtr us1, IntPtr s2);

  public static al_ustr_has_suffix_cstr AlUstrHasSuffixCstr = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr al_ustr_new_from_utf16(IntPtr s);

  public static al_ustr_new_from_utf16 AlUstrNewFromUtf16 = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate long al_ustr_size_utf16(IntPtr us);

  public static al_ustr_size_utf16 AlUstrSizeUtf16 = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate long al_ustr_encode_utf16(IntPtr us, IntPtr s, long n);

  public static al_ustr_encode_utf16 AlUstrEncodeUtf16 = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate long al_utf8_width(int c);

  public static al_utf8_width AlUtf8Width = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate long al_utf8_encode(IntPtr s, int c);

  public static al_utf8_encode AlUtf8Encode = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate long al_utf16_width(int c);

  public static al_utf16_width AlUtf16Width = null!;

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate long al_utf16_encode(IntPtr s, int c);

  public static al_utf16_encode AlUtf16Encode = null!;

  #endregion
}
