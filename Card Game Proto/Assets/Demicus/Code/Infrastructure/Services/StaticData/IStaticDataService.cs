using Demicus.Code.Infrastructure.Data;
using Demicus.Code.Infrastructure.StaticData;

namespace Demicus.Code.Infrastructure.Services.StaticData
{
    public interface IStaticDataService
    {
        GameStaticData Data { get; }
        SceneID?  LastCompleteLevel { get; }
        void Load();
        void SetLastCompleteLevel(SceneID? currentScene);
        WindowConfig GetWindow(WindowID id);
    }
}