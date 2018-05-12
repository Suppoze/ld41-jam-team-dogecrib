using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InRangeListener))]
[RequireComponent(typeof(Inventory))]
public class StorageStation : Station
{
    public List<Item> DebugItems = new List<Item>();
    
    private InRangeListener _inRangeListener;
    private Inventory _inventory;
    private Color _originalColor;

    private void Awake()
    {
        _inRangeListener = GetComponent<InRangeListener>();
        _inventory = GetComponent<Inventory>();
    }

    private void Start()
    {
        _inventory.GetComponentInChildren<InventoryUI>().Hide();

        _inRangeListener.OnNotifyInRange = OnNotifyInRange;
        _inRangeListener.OnNotifyOutOfRange = OnNotifyOutOfRange;
        
        DebugItems.ForEach(item => _inventory.Push(item));
    }

    private void OnNotifyInRange(int playerIndex)
    {
        _inventory.Open();
    }

    private void OnNotifyOutOfRange(int playerIndex)
    {
        _inventory.Close();
    }
}