using Demicus.Code.Infrastructure.StaticData;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace Demicus.Code.Editor
{
    public class MenuItemTools : EditorWindow
    {
        private const string PROGRESS_KEY = "PlayerProgress";

        [MenuItem("Shortcuts/Open Bootstrap Scene", false, 1)]
        public static void OpenBootstrapScene()
        {
            EditorSceneManager.OpenScene("Assets/Scenes/MainScenes/BootstrapScene.unity", OpenSceneMode.Single);
        }

        [MenuItem("Shortcuts/Open Menu Scene", false, 1)]
        public static void OpenMenuScene()
        {
            EditorSceneManager.OpenScene("Assets/Scenes/MainScenes/MainMenuScene.unity", OpenSceneMode.Single);
        }

        [MenuItem("Shortcuts/Open GamePlay Scene", false, 1)]
        public static void OpenGamePlayScene()
        {
            EditorSceneManager.OpenScene("Assets/Scenes/MainScenes/GamePlayScene.unity", OpenSceneMode.Single);
        }

        [MenuItem("Shortcuts/Open GameStaticData")]
        public static void OpenGameStaticData()
        {
            GameStaticData staticData = Resources.Load<GameStaticData>("GameStaticData");

            Selection.activeObject = staticData;

            EditorGUIUtility.PingObject(staticData);
        }
    }
}