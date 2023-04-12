using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TavernBoardManager : MonoBehaviour
{
    [SerializeField] private GameObject MenuManager;
    [SerializeField] private GameObject Board;
    public void OpenMenuManager()
    {
        MenuManager.SetActive(true);
        Board.SetActive(false);
    }

    public void CloseMenuManager() 
    {
        MenuManager.SetActive(false);
        Board.SetActive(true);
    }

    public void OpenFloorplanManager()
    {

    }

}
