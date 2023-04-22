using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TavernActionsManager : MonoBehaviour
{
    public void LoadScene(Object sceneToLoad)
    {
        SceneManager.LoadScene(sceneToLoad.name);
    }
}
