using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "Processor", menuName = "Interactable/Processor")]
public class Processor : ScriptableObject
{
    public List<Recipe> Recipes;
    public int Capacity;

    public bool CanProcess(IEnumerable<Item> items)
    {
        var invItemToCountList = items.GroupBy(it => it)
            .Select(grouping => new Recipe.ItemToCount {Item = grouping.Key, Count = grouping.Count()})
            .ToList();
        return Recipes.Exists(recipe =>
            recipe.RequiredItems.Exists(itemToCount =>
                ListContainsMatch(invItemToCountList, itemToCount)));
    }

    private static bool ListContainsMatch(List<Recipe.ItemToCount> invItemToCount, Recipe.ItemToCount itemToCount) =>
        invItemToCount.Exists(invItemCount => ItemToCountsMatch(invItemCount, itemToCount));

    private static bool ItemToCountsMatch(Recipe.ItemToCount invItemToCount, Recipe.ItemToCount itemToCount) =>
        invItemToCount.Item == itemToCount.Item && invItemToCount.Count == itemToCount.Count;
}