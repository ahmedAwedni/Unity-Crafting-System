// 3. CraftingStationTrigger.cs
using UnityEngine;

public class CraftingStationTrigger : MonoBehaviour
{
    [Header("Station Setup")]
    [Tooltip("What type of crafting is allowed at this station?")]
    public CraftingCategory stationCategory = CraftingCategory.General;

    [Header("Crafting Setup")]
    public CraftingRecipe recipeToCraft;
    public CraftingManager craftingManager;

    public void AttemptCrafting()
    {
        if (craftingManager != null && recipeToCraft != null)
        {
            // Validate if the recipe matches the station's category
            if (recipeToCraft.category != stationCategory && stationCategory != CraftingCategory.General)
            {
                Debug.LogWarning($"Cannot craft {recipeToCraft.recipeName} here. This station requires {stationCategory} recipes.");
                return;
            }

            craftingManager.CraftItem(recipeToCraft);
        }
    }
}
