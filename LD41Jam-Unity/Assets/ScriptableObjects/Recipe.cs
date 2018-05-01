using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Recipe", menuName = "Recipe")]
public class Recipe : ScriptableObject
{
    public List<ItemToCount> RequiredItems;
    public Item Output;

    [Serializable]
    public class ItemToCount
    {
        public Item Item;
        public int Count;
    }
}