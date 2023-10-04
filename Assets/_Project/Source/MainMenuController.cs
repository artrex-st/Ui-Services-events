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
        [Header("Screen Reference")]
        [SerializeField] private ScreenReference _settingsScreenRef;

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
        }

        private void PlayButtonClickHandler()
        {
// #if UNITY_EDITOR
//             UnityEditor.EditorApplication.isPlaying = false;
// #else
//             Application.Quit();
// #endif
        }

        private void SettingsButtonClickHandler()
        {
            AsyncOperation openSceneOperationAsync = ScreenService.LoadAdditiveSceneAsync(_settingsScreenRef);
        }
    }
}
