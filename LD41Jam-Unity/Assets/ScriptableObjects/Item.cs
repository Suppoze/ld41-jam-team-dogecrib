using UnityEngine;

public class Item : ScriptableObject
{
    public string Name;
    public Sprite Artwork;
    
    public Grade Grade { get; set; }
}
