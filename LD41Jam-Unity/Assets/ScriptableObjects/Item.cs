using UnityEngine;

public class Item : ScriptableObject
{
    public string Name;
    public Sprite Artwork;
    
    public Grade Grade { get; set; }

    public Item Copy()
    {
        var item = CreateInstance(GetType()) as Item;
        item.Name = Name;
        item.Artwork = Artwork;
        return item;
    }
}
