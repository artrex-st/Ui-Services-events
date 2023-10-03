using System;
using UnityEngine;
using UnityEngine.UI;
using USE.ScreenService;

namespace Source
{
    public sealed class MainMenuController : BaseScreen
    {
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
            _settingsButton.onClick.AddListener(SettingsButtonClickHandler);
        }

        private void SettingsButtonClickHandler()
        {
            AsyncOperation openSceneOperationAsync = ScreenService.LoadAdditiveSceneAsync(_settingsScreenRef);
        }
    }
}
