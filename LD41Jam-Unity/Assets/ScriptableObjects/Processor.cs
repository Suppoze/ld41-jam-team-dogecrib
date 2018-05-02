using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "Processor", menuName = "Interactable/Processor")]
public class Processor : ScriptableObject
{
    public List<Recipe> Recipes;

    public Recipe FindProcessableRecipe(IEnumerable<Item> items)
    {
        foreach (var recipe in Recipes)
        {
            return FindMatchingRecipeWithInventoryContent(items, recipe);
        }
        
        return null;
    }

    public void Process(Inventory inventory, Recipe recipeToCraft)
    {
        RemoveRecipeFromInventory(inventory, recipeToCraft);
        AddNewItemToInventory(inventory, recipeToCraft);
    }

    private static Recipe FindMatchingRecipeWithInventoryContent(IEnumerable<Item> items, Recipe recipe)
    {
        var invItemsCopy = new LinkedList<Item>(items);
        foreach (var requiredItem in recipe.RequiredItems)
        {
            if (ItemNotFoundInCollection(invItemsCopy, requiredItem)) return null;
        }

        return recipe;
    }

    private static bool ItemNotFoundInCollection(ICollection<Item> invItemsCopy, Item requiredItem)
    {
        var foundItem = invItemsCopy.FirstOrDefault(invItem =>
            requiredItem.Name.Equals(invItem.Name));

        if (foundItem == null) return true;
        
        invItemsCopy.Remove(foundItem);
        return false;
    }

    private static void RemoveRecipeFromInventory(Inventory inventory, Recipe recipeToCraft)
    {
        var invItemsCopy = new List<Item>(inventory.Contents);
        RemoveRecipeItemsFromCollection(invItemsCopy, recipeToCraft);
        
        inventory.CreateMatchingListWith(invItemsCopy);
    }

    private static void RemoveRecipeItemsFromCollection(ICollection<Item> invItemsCopy, Recipe recipeToCraft)
    {
        foreach (var requiredItem in recipeToCraft.RequiredItems)
        {
            var foundItem = invItemsCopy.FirstOrDefault(invItem =>
                requiredItem.Name.Equals(invItem.Name));
            invItemsCopy.Remove(foundItem);
        }
    }

    private static void AddNewItemToInventory(Inventory inventory, Recipe recipeToCraft)
    {
        inventory.Push(recipeToCraft.Output.Copy());
    }
}