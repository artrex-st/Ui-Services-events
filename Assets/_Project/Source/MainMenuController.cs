using Cysharp.Threading.Tasks;
using System;
using UnityEngine;
using UnityEngine.UI;
using USE.ScreenService;

namespace Source
{
    public sealed class MainMenuController : BaseScreen
    {
        [SerializeField] private Button _PlayButton;
        [SerializeField] private Button _settingsButton;
        [SerializeField] private Button _exitGameButton;
        [SerializeField] private Button _loadingButton;
        [Header("Screen Reference")]
        [SerializeField] private ScreenReference _gameScreenRef;
        [SerializeField] private ScreenReference _settingsScreenRef;
        [SerializeField] private ScreenReference _loadingScreenRef;

        private void OnEnable()
        {
            Initialize();
        }

        private void OnDisable()
        {
            Dispose();
        }

        private new void Initialize()
        {
            base.Initialize();
            _PlayButton.onClick.AddListener(PlayButtonClickHandler);
            _settingsButton.onClick.AddListener(SettingsButtonClickHandler);
            _exitGameButton.onClick.AddListener(ExitGameButtonClickHandler);
            _loadingButton.onClick.AddListener(LoadingButtonClickHandler);

            SoundService.PlayMusic(SoundService.SoundLibrary.MainMenuMusic);
        }

        private void LoadingButtonClickHandler()
        {
            ScreenService.LoadAdditiveSceneAsync(_loadingScreenRef);
        }

        private void PlayButtonClickHandler()
        {
            AsyncOperation openSceneOperationAsync = ScreenService.LoadSingleSceneAsync(_gameScreenRef);
            openSceneOperationAsync.completed += async operation =>
            {
                await UniTask.Delay(TimeSpan.FromSeconds(3));
                AsyncOperation backSceneAsync = ScreenService.LoadSingleSceneAsync(_thisScreenRef);
            };
        }

        private void SettingsButtonClickHandler()
        {
            AsyncOperation openSceneOperationAsync = ScreenService.LoadAdditiveSceneAsync(_settingsScreenRef);
        }

        private void ExitGameButtonClickHandler()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }
}
