// 3. CraftingStationTrigger.cs
using UnityEngine;

public class CraftingStationTrigger : MonoBehaviour
{
    [Header("Crafting Setup")]
    public CraftingRecipe recipeToCraft;
    public CraftingManager craftingManager;

    public void AttemptCrafting()
    {
        if (craftingManager != null && recipeToCraft != null)
        {
            craftingManager.CraftItem(recipeToCraft);
        }
    }
}
