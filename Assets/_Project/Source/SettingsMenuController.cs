using System;
using UnityEngine;
using UnityEngine.UI;
using USE.ScreenService;

namespace Source
{
    public class SettingsMenuController : BaseScreen
    {
        [SerializeField] private Button _closeButton;
        [Header("Settings UiOverlay Elements")]
        [SerializeField] private Slider _sliderMaster;
        // [SerializeField] private Slider _sliderMusic;
        // [SerializeField] private Slider _sliderSFX;


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
            _closeButton.onClick.AddListener(CloseButtonClickHandler);
            _sliderMaster.onValueChanged.AddListener(OnMasterVolumeChangeHandler);
        }

        private void OnMasterVolumeChangeHandler(float value)
        {
            Debug.Log($"Value Of slider: <color=green>{value}</color>");
            SoundService.MasterVolume = value;
        }

        private void CloseButtonClickHandler()
        {
            AsyncOperation openSceneOperationAsync = ScreenService.UnLoadSceneAsync(_thisScreenRef);
        }
    }
}
