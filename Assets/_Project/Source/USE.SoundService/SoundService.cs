using Coimbra;
using UnityEngine;
using UnityEngine.Audio;

namespace USE.SoundService
{
    public class SoundService : Actor, ISoundService
    {

        public SoundLibrary Library { get; private set; }
        private const string _masterVolume = "Master";
        private const string _musicVolume = "Music";
        private const string _sfxVolume = "Sfx";
        private const string _uiSfxVolume = "UiSfx";

        private const float _minimumVolumeDb = -25;
        private const float _maximumVolumeDb = 0;
        private const float _defaultSliderDbValue = 0.85f;
        private const float _mutedDbValue = -80f;

        private AudioMixer _mixerAudio;
        private AudioSource _musicOutput;
        private AudioSource _sfxOutput;
        private AudioSource _uiSfxOutput;

        public void Initialize(SoundLibrary library, AudioMixer mixerAudio, AudioMixerGroup musicGroup, AudioMixerGroup sfxGroup, AudioMixerGroup uiSfxGroup)
        {
            Library = library;
            _mixerAudio = mixerAudio;
            _musicOutput = gameObject.AddComponent<AudioSource>();
            _sfxOutput = gameObject.AddComponent<AudioSource>();
            _uiSfxOutput = gameObject.AddComponent<AudioSource>();
            _musicOutput.outputAudioMixerGroup = musicGroup;
            _sfxOutput.outputAudioMixerGroup = sfxGroup;
            _uiSfxOutput.outputAudioMixerGroup = uiSfxGroup;
            PlayMusic(Library.MainMenuMusic);
        }

        public float MasterVolume
        {
            get => GetMixerVolumeParameter(_masterVolume);
            set => SetMixerVolumeParameter(_masterVolume, value);
        }

        public float MusicVolume
        {
            get => GetMixerVolumeParameter(_musicVolume);
            set => SetMixerVolumeParameter(_musicVolume, value);
        }

        public float SfxVolume
        {
            get => GetMixerVolumeParameter(_sfxVolume);
            set => SetMixerVolumeParameter(_sfxVolume, value);
        }

        public float UiSfxVolume
        {
            get => GetMixerVolumeParameter(_uiSfxVolume);
            set => SetMixerVolumeParameter(_uiSfxVolume, value);
        }

        public void PlayMusic(AudioClip clip)
        {
            if (clip == _musicOutput.clip)
            {
                return;
            }

            _musicOutput.loop = true;
            _musicOutput.clip = clip;
            _musicOutput.Play();
        }

        private void SetMixerVolumeParameter(string key, float volumePercent)
        {
            float volume = Mathf.Lerp(_minimumVolumeDb, _maximumVolumeDb, volumePercent);
            volume = volume <= _minimumVolumeDb ? _mutedDbValue : volume;
            _mixerAudio.SetFloat(key, volume);
        }

        private float GetMixerVolumeParameter(string key)
        {
            if (_mixerAudio.GetFloat(key, out float value))
            {
                return Mathf.InverseLerp(_minimumVolumeDb,_maximumVolumeDb,value);
            }

            return _defaultSliderDbValue;
        }
    }
}
