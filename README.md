# Unity Crafting System

A seamless, data-driven Crafting System for Unity. Built as a direct extension to the **ScriptableObject Inventory System**, this framework allows designers to easily create complex crafting recipes without writing a single line of code.

---

## ✨ Features

* **ScriptableObject Recipes:** Define required ingredients and resulting items entirely in the Unity Editor.
* **Direct Inventory Integration:** Hooks directly into the "InventoryManager" to read available stacks and safely consume items.
* **Multi-Ingredient Support:** Require as many different items (and quantities) as you want for a single recipe.
* **Event-Driven UI:** Broadcasts C# Actions ("OnItemCrafted", "OnCraftingFailed") so your UI can display success animations or error messages dynamically.

---

## 🧠 Design Notes

Crafting systems can quickly become a tangled mess of "if/else" statements checking for specific item names. 

By utilizing the "CraftingRecipe" ScriptableObject, we treat recipes purely as data. The "CraftingManager" acts as the referee: it loops through the required "CraftingIngredient" list, queries the "InventoryManager" to ensure the math checks out, and then processes the transaction. This keeps everything decoupled, highly performant, and completely bug-free regarding lost items.

---

## 📂 Included Scripts

* "CraftingRecipe.cs" - The ScriptableObject blueprint that defines the list of ingredients ("ItemData") needed, and what "ItemData" is produced.
* "CraftingManager.cs" - The core logic script that validates the player's inventory and processes the item exchanges.
* "CraftingStationTrigger.cs" - A helper component to attach to Anvils, Workbenches, or UI buttons to trigger a specific recipe creation.

---

## 🧩 How To Use

1. **Prerequisite:** Ensure you have the "InventoryManager" and "ItemData" scripts from the Unity Inventory System template installed in your project.
2. **Create a Recipe:** Right-click in your Project window: "Create > Crafting System > Recipe". 
3. **Assign Items:** Add your required ingredients (e.g., 2x Wood, 1x Iron) and set your result item (e.g., 1x Iron Sword).
4. **Setup the Manager:** Attach the "CraftingManager.cs" script to a GameObject in your scene and drag your "InventoryManager" component into its reference slot.
5. **Craft via Code:** Call the craft method from any script or UI Button event:
"""csharp
craftingManager.CraftItem(myRecipeAsset);
"""
6. **Check Craftability:** If you want to gray-out UI buttons for items the player can't afford, simply check:
"""csharp
bool canAfford = craftingManager.CanCraft(myRecipeAsset);
"""

---

## 🚀 Possible Extensions

* **Crafting Categories:** Add an Enum to "CraftingRecipe" for categories (Blacksmithing, Alchemy, Cooking) to filter what recipes show up at different stations.
* **Crafting Timers:** Instead of instantly granting the item, use a Coroutine in the "CraftingManager" to wait X seconds (with a progress bar event) before adding the result.
* **Experience Yield:** Add an "xpRewarded" integer to the Recipe data to grant the player crafting experience upon success.

---

## 🛠 Unity Version

Tested in Unity6+ (should work without any problems in newer versions)

---

## 📜 License

MIT
