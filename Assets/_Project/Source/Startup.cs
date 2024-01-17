using Coimbra.Services;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Audio;
using USE.DataService;
using USE.ScreenService;
using USE.SoundService;

namespace Source
{
    public sealed class Initialize : MonoBehaviour
    {
        [Header("Menu screen")]
        [SerializeField] private ScreenReference _firstScreenRef;

        [FoldoutGroup("Save Data config")]
        [SerializeField] private string _fileName;
        [FoldoutGroup("Save Data config")]
        [SerializeField] private bool _useEncryption;

        [FoldoutGroup("Sound config")]
        [SerializeField] private SoundLibrary _library;
        [FoldoutGroup("Sound config")]
        [SerializeField] private AudioMixer _audioMixer;
        [FoldoutGroup("Sound config")]
        [SerializeField] private AudioMixerGroup _musicMixerGroup;
        [FoldoutGroup("Sound config")]
        [SerializeField] private AudioMixerGroup _sfxMixerGroup;
        [FoldoutGroup("Sound config")]
        [SerializeField] private AudioMixerGroup _uiSfxMixerGroup;

        private void Awake()
        {
            SpawnPersistingDataService();
            SpawnSoundService();
            SpawnScreenService();
        }

        private void SpawnPersistingDataService()
        {
            GameObject saveDataServiceObject = new GameObject(nameof(SaveDataService));
            DontDestroyOnLoad(saveDataServiceObject);
            SaveDataService saveDataService = saveDataServiceObject.AddComponent<SaveDataService>();
#if !UNITY_EDITOR
            _useEncryption = true;
#endif
            saveDataService.Initialize(_fileName, _useEncryption);
        }

        private void SpawnScreenService()
        {
            GameObject screenServiceObject = new GameObject(nameof(ScreenService));
            DontDestroyOnLoad(screenServiceObject);
            ScreenService screenService = screenServiceObject.AddComponent<ScreenService>();
            //screenService.Initialize();
            screenService.LoadSingleSceneAsync(_firstScreenRef);
        }

        private void SpawnSoundService()
        {
            GameObject soundServiceObject = new GameObject(nameof(SoundService));
            DontDestroyOnLoad(soundServiceObject);
            SoundService soundService = soundServiceObject.AddComponent<SoundService>();
            soundService.Initialize(_library, _audioMixer, _musicMixerGroup, _sfxMixerGroup, _uiSfxMixerGroup);
        }
    }
}
