using UnityEngine;
using UnityEngine.UI;
using USE.ScreenService;

namespace Source
{
    public class SettingsMenuController : BaseScreen
    {
        [SerializeField] private Button _closeButton;

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
        }

        private void CloseButtonClickHandler()
        {
            AsyncOperation openSceneOperationAsync = ScreenService.UnLoadSceneAsync(_thisScreenRef);
        }
    }
}
