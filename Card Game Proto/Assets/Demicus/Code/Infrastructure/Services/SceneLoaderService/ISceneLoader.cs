using System;
using Demicus.Code.Infrastructure.Data;

namespace Demicus.Code.Infrastructure.Services.SceneLoaderService
{
    public interface ISceneLoader
    {
        void LoadScene(string sceneName, Action onLoaded = null);
        void LoadScene(SceneID sceneID, Action onLoaded = null);
    }
}