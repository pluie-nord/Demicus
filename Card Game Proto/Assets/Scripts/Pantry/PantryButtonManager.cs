using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PantryButtonManager : MonoBehaviour
{
    private RecipeBook recipeBook;
    [SerializeField] private List<Button> buttonsOfRBook;

    private void Start()
    {
        recipeBook = GetComponent<RecipeBook>();
        buttonsOfRBook[0].interactable = false;
        buttonsOfRBook[1].interactable = true;
    }

    public void NextPage()
    {
        if (recipeBook.currentPage < recipeBook.recipies.Count)
        {
            recipeBook.UpdateUI( recipeBook.recipies[recipeBook.currentPage]);
            buttonsOfRBook[1].interactable = buttonsOfRBook[0].interactable = true;
        }

        if (recipeBook.currentPage == recipeBook.recipies.Count)
        {
            buttonsOfRBook[1].interactable = false;
            buttonsOfRBook[0].interactable = true;
        }
    }

    public void LastPage()
    {
        if (recipeBook.currentPage > 1)
        {
            recipeBook.UpdateUI(recipeBook.recipies[recipeBook.currentPage-2]);
            buttonsOfRBook[0].interactable = buttonsOfRBook[1].interactable = true;
        }
        if (recipeBook.currentPage == 1)
        {
            buttonsOfRBook[0].interactable = false;
            buttonsOfRBook[1].interactable = true;
        }
    }

    public void StartCooking()
    {
        Debug.Log("готовится");
    }

    public void ExitPantry()
    {
        SceneManager.LoadScene(1);
    }
}
