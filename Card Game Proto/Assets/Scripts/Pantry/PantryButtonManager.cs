using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PantryButtonManager : MonoBehaviour
{
    private RecipeBook recipeBook;
    private void Start()
    {
        recipeBook = GetComponent<RecipeBook>();
    }
    public void NextPage()
    {
        if (recipeBook.currentPage < recipeBook.recipies.Count)
        {
            recipeBook.UpdateUI( recipeBook.recipies[recipeBook.currentPage]);
        }
    }

    public void LastPage()
    {
        if (recipeBook.currentPage > 1)
        {
            recipeBook.UpdateUI( recipeBook.recipies[recipeBook.currentPage-2]);
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
