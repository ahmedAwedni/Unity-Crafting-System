// 1. CraftingRecipe.cs
using System.Collections.Generic;
using UnityEngine;

// Define your categories here
public enum CraftingCategory
{
    General,
    Blacksmithing,
    Alchemy,
    Cooking,
    Engineering
}

// A small struct to group an item and the amount required
[System.Serializable]
public struct CraftingIngredient
{
    public ItemData item;
    public int amount;
}

[CreateAssetMenu(fileName = "NewRecipe", menuName = "Crafting System/Recipe")]
public class CraftingRecipe : ScriptableObject
{
    [Header("Recipe Info")]
    public string recipeName;
    [TextArea] public string description;
    
    [Tooltip("What type of crafting station is required to make this?")]
    public CraftingCategory category = CraftingCategory.General;

    [Header("Requirements")]
    public List<CraftingIngredient> ingredients;

    [Header("Result")]
    public ItemData resultItem;
    public int resultAmount = 1;
}
