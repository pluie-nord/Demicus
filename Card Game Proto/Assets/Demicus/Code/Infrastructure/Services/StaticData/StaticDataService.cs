using System.Collections.Generic;
using Demicus.Code.Infrastructure.Data;
using Demicus.Code.Infrastructure.Services.AssetProvider;
using Demicus.Code.Infrastructure.StaticData;
using UnityEngine.SceneManagement;

namespace Demicus.Code.Infrastructure.Services.StaticData
{
    /// <summary>
    /// Provide static data (balance or other GD parameters) for services and other entities
    /// </summary>
    public class StaticDataService : IStaticDataService
    {
        private readonly IAssetProvider _assetProvider;
        private readonly Dictionary<WindowID, WindowConfig> _windows = new();

        public StaticDataService(IAssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
        }

        public GameStaticData Data { get; private set; }
        
        public SceneID? LastCompleteLevel { get; private set; }

        public void Load()
        {
            _assetProvider.Load();
            Data = _assetProvider.GetGameStaticData();
            LoadWindows();
        }

        public void SetLastCompleteLevel(SceneID? currentScene)
        {
            LastCompleteLevel = currentScene;
        }

        public WindowConfig GetWindow(WindowID id)
        {
            return _windows.TryGetValue(id, out var windowConfig) ? windowConfig : null;
        }


        private void LoadWindows()
        {
            foreach (var window in Data.Windows)
                _windows.Add(window.ID, window);
        }
    }
}