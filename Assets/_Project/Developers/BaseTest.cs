using Coimbra.Services;
using Source;
using UnityEngine;
using UnityEngine.UI;
using USE.ScreenService;

namespace Developers
{
    public class BaseTest : MonoBehaviour
    {
        [SerializeField] private Button _nextScene;
        [SerializeField] private ScreenReference _sceneScreenReference;

        private IScreenService _screenService;

        private void Awake()
        {
            ServiceLocator.TryGet(out _screenService);
            _nextScene.onClick.AddListener(() =>
            {
                AsyncOperation x = _screenService.LoadSingleSceneAsync(_sceneScreenReference);
                x.completed += operation => Debug.Log($"Cena {_sceneScreenReference.SceneName} Carregada.");
            });
        }
    }
}
