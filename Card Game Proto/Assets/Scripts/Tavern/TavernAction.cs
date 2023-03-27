using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TavernAction : MonoBehaviour
{
    [SerializeField] Object sceneToLoad;
    private TavernActionsManager tavernActionsManager;
    private void Start()
    {
        tavernActionsManager = FindObjectOfType<TavernActionsManager>();
    }
    private void OnMouseDown()
    {
        tavernActionsManager.LoadScene(sceneToLoad);
    }
}
