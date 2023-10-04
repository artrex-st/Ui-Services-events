using Coimbra.Services;
using UnityEngine;
using UnityEngine.Audio;
using USE.ScreenService;
using USE.SoundService;

namespace Source
{
    public class Initialize : MonoBehaviour
    {
        [Header("Menu screen")]
        [SerializeField] private ScreenReference _firstScreenRef;
        [Header("Sound config")]
        [SerializeField] private SoundLibrary _library;
        [SerializeField] private AudioMixer _audioMixer;
        [SerializeField] private AudioMixerGroup _musicMixerGroup;
        [SerializeField] private AudioMixerGroup _sfxMixerGroup;
        [SerializeField] private AudioMixerGroup _uiSfxMixerGroup;

        private IScreenService _screenService;

        private void Awake()
        {
            SpawnScreenService();
            SpawnSoundService();
            ServiceLocator.TryGet(out _screenService);
            _screenService.LoadSingleSceneAsync(_firstScreenRef);
        }

        private void SpawnScreenService()
        {
            GameObject screenServiceObject = new GameObject(nameof(ScreenService));
            DontDestroyOnLoad(screenServiceObject);
            ScreenService screenService = screenServiceObject.AddComponent<ScreenService>();
            //screenService.Initialize();
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
