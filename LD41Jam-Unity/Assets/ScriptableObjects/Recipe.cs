using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Recipe", menuName = "Recipe")]
public class Recipe : ScriptableObject
{
    public List<Item> RequiredItems;
    public Item Output;
}