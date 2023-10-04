namespace USE.DataService
{
    [System.Serializable]
    public class GameData
    {
        //TODO: add settings proprieties
        public float MasterVolume { get; }
        public float MusicVolume { get; }
        public float SfxVolume { get; }
        public float UiSfxVolume { get; }

        public GameData()
        {
            MasterVolume = 1f;
            MusicVolume = 1f;
            SfxVolume = 1f;
            UiSfxVolume = 1f;
        }

        public GameData(float masterVolume, float musicVolume, float sfxVolume, float uiSfxVolume)
        {
            MasterVolume = masterVolume;
            MusicVolume = musicVolume;
            SfxVolume = sfxVolume;
            UiSfxVolume = uiSfxVolume;
        }
    }
}
