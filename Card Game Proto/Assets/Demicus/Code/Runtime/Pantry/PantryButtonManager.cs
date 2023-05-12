using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Demicus.Code.Infrastructure.StateMachine;
using Zenject;
using Demicus.Code.Infrastructure.StateMachine.States;
using Demicus.Code.Infrastructure.Data;

public class PantryButtonManager : MonoBehaviour
{
    private RecipeBook recipeBook;
    [SerializeField] private List<Button> buttonsOfRBook;
    private InventorySystem inventorySys;
    private IGameStateMachine _gameStateMachine;

    [Inject]
    private void Constructor(IGameStateMachine gameStateMachine)
    {
        _gameStateMachine = gameStateMachine;
    }

    private void Start()
    {
        recipeBook = GetComponent<RecipeBook>();
        inventorySys = FindObjectOfType<InventorySystem>();
        buttonsOfRBook[0].interactable = false;
        buttonsOfRBook[1].interactable = true;
    }

    public void NextPage()
    {
        if (recipeBook.currentPage < recipeBook.recipies.Count)
        {
            recipeBook.UpdateUI(recipeBook.recipies[recipeBook.currentPage]);
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
        ItemToSell newItem = ScriptableObject.CreateInstance<ItemToSell>();
        newItem.id = recipeBook.currentRecipe.id;
        newItem.m_name = recipeBook.currentRecipe.m_name;
        newItem.img = recipeBook.currentRecipe.img;
        newItem.description = recipeBook.currentRecipe.description;
        newItem.cost = recipeBook.currentRecipe.cost;
        inventorySys.AddToSell(newItem);
    }

    public void ExitPantry()
    {
        _gameStateMachine.Enter<LoadLevelState, SceneID>(SceneID.Hub);
    }
}
