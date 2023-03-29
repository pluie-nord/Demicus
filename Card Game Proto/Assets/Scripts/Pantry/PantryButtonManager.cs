using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
