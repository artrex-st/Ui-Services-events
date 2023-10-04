using Coimbra.Services;

namespace USE.SoundService
{
    public interface ISoundService : IService
    {
        public void Initialize(SoundLibrary library) { }

        public float MasterVolume { get; set; }
        public float MusicVolume { get; set; }
        public float SfxVolume { get; set; }
        public float UiSfxVolume { get; set; }
    }
}
