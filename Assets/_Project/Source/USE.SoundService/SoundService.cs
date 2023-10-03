using Coimbra;
using UnityEngine;
using UnityEngine.Audio;

namespace USE.SoundService
{
    public class SoundService : Actor, ISoundService
    {
        public SoundLibrary Library { get; private set; }
        private AudioSource _musicOutput;
        private AudioSource _sfxOutput;

        public void Initialize(SoundLibrary library, AudioMixerGroup musicMixerGroup, AudioMixerGroup sfxMixerGroup)
        {
            Library = library;
            _musicOutput = gameObject.AddComponent<AudioSource>();
            _sfxOutput = gameObject.AddComponent<AudioSource>();
            _musicOutput.outputAudioMixerGroup = musicMixerGroup;
            _sfxOutput.outputAudioMixerGroup = sfxMixerGroup;
        }
    }
}
