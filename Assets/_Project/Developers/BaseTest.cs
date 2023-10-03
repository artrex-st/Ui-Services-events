using Source;
using UnityEngine;
using UnityEngine.UI;
using USE.ScreenService;

namespace Developers
{
    public class BaseTest : BaseScreen
    {
        [SerializeField] private Button _nextScene;
        [Header("Screen Reference")]
        [SerializeField] private ScreenReference _sceneScreenRef;

        private void Awake()
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

            _nextScene.onClick.AddListener(() =>
            {
                AsyncOperation x = ScreenService.LoadSingleSceneAsync(_sceneScreenRef);
                x.completed += operation => Debug.Log($"Cena <color=yellow>{_thisScreenRef.SceneName}</color>, carregou a cena <color=blue>{_sceneScreenRef.SceneName}</color>.");
            });
        }

        private new void Dispose()
        {
            base.Dispose();
        }
    }
}
