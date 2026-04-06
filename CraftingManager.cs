// 2. CraftingManager.cs
using System;
using UnityEngine;

public class CraftingManager : MonoBehaviour
{
    public static event Action<CraftingRecipe> OnItemCrafted;
    public static event Action<CraftingRecipe> OnCraftingFailed;

    [Header("System References")]
    [Tooltip("Link your existing InventoryManager here.")]
    public InventoryManager inventoryManager;

    // Checks if the player has all required ingredients in their inventory
    public bool CanCraft(CraftingRecipe recipe)
    {
        if (inventoryManager == null)
        {
            Debug.LogError("CraftingManager is missing a reference to the InventoryManager!");
            return false;
        }

        foreach (var ingredient in recipe.ingredients)
        {
            int totalPossessed = 0;
            
            // Tally up how many of this item the player has across all stacks
            foreach (var slot in inventoryManager.inventory)
            {
                if (slot.data == ingredient.item)
                {
                    totalPossessed += slot.stackSize;
                }
            }

            // If we have less than required, we can't craft
            if (totalPossessed < ingredient.amount)
            {
                return false; 
            }
        }
        return true;
    }

    public void CraftItem(CraftingRecipe recipe)
    {
        if (CanCraft(recipe))
        {
            // 1. Consume Ingredients
            foreach (var ingredient in recipe.ingredients)
            {
                // Remove the exact amount needed (looping since InventoryManager removes 1 per call)
                for (int i = 0; i < ingredient.amount; i++)
                {
                    inventoryManager.RemoveItem(ingredient.item);
                }
            }

            // 2. Grant Resulting Item
            for (int i = 0; i < recipe.resultAmount; i++)
            {
                inventoryManager.AddItem(recipe.resultItem);
            }

            Debug.Log($"Successfully crafted {recipe.resultAmount}x {recipe.resultItem.itemName}!");
            OnItemCrafted?.Invoke(recipe);
        }
        else
        {
            Debug.LogWarning($"Missing ingredients to craft: {recipe.recipeName}");
            OnCraftingFailed?.Invoke(recipe);
        }
    }
}
