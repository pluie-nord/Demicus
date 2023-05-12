using Demicus.Code.Extensions;
using UnityEngine;

namespace Demicus.Code.Infrastructure.Services.SaveLoadService
{
    public class SaveLoadService : ISaveLoadService
    {
        private const string PROGRESS_KEY = "PlayerProgress";

        private readonly IPersistentProgressService _progressService;

        public SaveLoadService(IPersistentProgressService progressService)
        {
            _progressService = progressService;
        }

        public void SaveProgress()
        {
            PlayerPrefs.SetString(PROGRESS_KEY, _progressService.Progress.ToJson());
        }

        public PlayerProgress LoadProgress()
        {
            return PlayerPrefs.GetString(PROGRESS_KEY, null)?.ToDeserialized<PlayerProgress>();
        }
    }
}