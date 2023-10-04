using Coimbra.Services;
using UnityEngine;

namespace USE.SoundService
{
    public interface ISoundService : IService
    {
        public SoundLibrary SoundLibrary { get; }
        public float MasterVolume { get; set; }
        public float MusicVolume { get; set; }
        public float SfxVolume { get; set; }
        public float UiSfxVolume { get; set; }

        public void Initialize(SoundLibrary library) { }
        public void PlayUiSfx(AudioClip clip);
    }
}
