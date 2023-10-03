using Coimbra;
using Source;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace USE.ScreenService
{
    public class ScreenService : Actor, IScreenService
    {
        public AsyncOperation LoadSingleSceneAsync(ScreenReference sceneReference)
        {
            AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneReference.SceneName, LoadSceneMode.Single);
            return asyncOperation;
        }

        public AsyncOperation LoadAdditiveSceneAsync(ScreenReference sceneReference)
        {
            AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneReference.SceneName, LoadSceneMode.Additive);
            return asyncOperation;
        }

        public AsyncOperation UnLoadSceneAsync(ScreenReference sceneReference)
        {
            AsyncOperation asyncOperation = SceneManager.UnloadSceneAsync(sceneReference.SceneName);
            return asyncOperation;
        }
    }
}
