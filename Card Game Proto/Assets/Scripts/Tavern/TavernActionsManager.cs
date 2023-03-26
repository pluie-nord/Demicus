using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TavernActionsManager : MonoBehaviour
{
    public void StartCardGame()
    {
        SceneManager.LoadScene(0);
    }

    private void Start()
    {
        CollisionEvents.OnCollision += TavernInteractions;
    }

    private void TavernInteractions(ICollision collision)
    {
        print("Подключенное на слушание событие затригеррилось");
        switch(collision.ID)
        {
            case "001":
                StartCardGame();
                break;
        }
    }

}
