using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;
using USE.ScreenService;

namespace Source
{
    public class SettingsMenuController : BaseScreen
    {
        [SerializeField] private Button _closeButton;
        [FoldoutGroup("Settings UiOverlay Elements")]
        [SerializeField] private Slider _sliderMaster;
        [FoldoutGroup("Settings UiOverlay Elements")]
        [SerializeField] private Slider _sliderMusic;
        [FoldoutGroup("Settings UiOverlay Elements")]
        [SerializeField] private Slider _sliderSfx;
        [FoldoutGroup("Settings UiOverlay Elements")]
        [SerializeField] private Slider _sliderUiSfx;


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
            _sliderMusic.onValueChanged.AddListener(OnMusicVolumeChangeHandler);
            _sliderSfx.onValueChanged.AddListener(OnSfxVolumeChangeHandler);
            _sliderUiSfx.onValueChanged.AddListener(OnUiSfxVolumeChangeHandler);
        }

        private void OnMasterVolumeChangeHandler(float value)
        {
            SoundService.MasterVolume = value;
        }

        private void OnMusicVolumeChangeHandler(float value)
        {
            SoundService.MusicVolume = value;
        }

        private void OnSfxVolumeChangeHandler(float value)
        {
            SoundService.SfxVolume = value;
        }

        private void OnUiSfxVolumeChangeHandler(float value)
        {
            SoundService.UiSfxVolume = value;
        }

        private void CloseButtonClickHandler()
        {
            AsyncOperation openSceneOperationAsync = ScreenService.UnLoadSceneAsync(_thisScreenRef);
        }
    }
}
