using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RecipeBook : MonoBehaviour
{
    //настраиваемый список рецептов, ссылка на изображение в рецепте, ссылка на название рецепта, ссылка на описание
    [SerializeField] public List<Recipe> recipies;
    [SerializeField] private Image imgR;
    [SerializeField] private TextMeshProUGUI nameR;
    [SerializeField] private TextMeshProUGUI descriptionR;
    [SerializeField] private List<Button> buttons;

    public int currentPage;
    public Recipe currentRecipe;

    private void Start()
    {
       UpdateUI(recipies[0]);
    }
   
    public void UpdateUI(Recipe recipeToSet)
    {
        imgR.sprite = recipeToSet.img;
        nameR.text = recipeToSet.m_name;
        descriptionR.text = "";
        foreach(InventoryItemData ingr in recipeToSet.ingredients)
        {
            descriptionR.text += ingr.displayName + "\r\n";
        }
        currentPage = recipies.IndexOf(recipeToSet) + 1;
        currentRecipe = recipeToSet;
        foreach(var b in buttons)
        {
            b.interactable = CheckIngredientsRecipe();
        }
    }

    private bool CheckIngredientsRecipe()
    {
        bool allIngridients = true;
        foreach(InventoryItemData ingr in currentRecipe.ingredients)
        {
            if (!FindObjectOfType<InventorySystem>().m_itemDictionary.TryGetValue(ingr, out InventoryItem value))
            {
                allIngridients = false;
            }
        }
        return allIngridients;
    }




    /*void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            print(CheckIngredients());
        }
    }*/
}
