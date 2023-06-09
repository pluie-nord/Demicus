using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TavernBoardManager : MonoBehaviour
{
    [SerializeField] private GameObject MenuManager;
    [SerializeField] private GameObject Board;
    [SerializeField] private GameObject BulletinBoard;
    [SerializeField] private GameObject TavernInteractables;
    [SerializeField] private GameObject Floorplan;
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
        Floorplan.SetActive(true);
        Board.SetActive(false);
    }

    public void CloseFloorplanManager()
    {
        Floorplan.SetActive(false);
        Board.SetActive(true);
    }

    public void OpenBoard()
    {
        BulletinBoard.SetActive(true);
        TavernInteractables.SetActive(false);
    }

    public void CloseBoard()
    {
        BulletinBoard.SetActive(false);
        TavernInteractables.SetActive(true);
    }

}
