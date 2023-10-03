using Coimbra.Services;
using Source;
using UnityEngine;

namespace USE.ScreenService
{
    public interface IScreenService : IService
    {
        public AsyncOperation LoadSingleSceneAsync(ScreenReference sceneReference);
        public AsyncOperation LoadAdditiveSceneAsync(ScreenReference sceneReference);
        public AsyncOperation UnLoadSceneAsync(ScreenReference sceneReference);
    }
}
