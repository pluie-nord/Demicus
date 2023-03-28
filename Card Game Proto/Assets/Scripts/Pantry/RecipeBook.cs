using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RecipeBook : MonoBehaviour
{
    //настраиваемый список рецептов, ссылка на изображение в рецепте, ссылка на название рецепта, ссылка на описание
    [SerializeField] List<Recipe> recipies;
    [SerializeField] private Image imgR;
    [SerializeField] private TextMeshProUGUI nameR;
    [SerializeField] private TextMeshProUGUI descriptionR;

    private void Start()
    {
       UpdateUI(recipies[0]);
    }

    private void UpdateUI(Recipe recipeToSet)
    {
        imgR.sprite = recipeToSet.img;
        nameR.text = recipeToSet.m_name;
        descriptionR.text = "";
        foreach(InventoryItemData ingr in recipeToSet.ingredients)
        {
            descriptionR.text += ingr.displayName + "\r\n";
        }
    }
}
