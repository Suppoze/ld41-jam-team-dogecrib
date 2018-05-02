using System.Collections.Generic;
using Core.Extensions;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public InventoryUIListItem InventoryUiListItem;
    public bool HideByDefault;

    private List<GameObject> _children;

    private void Awake()
    {
        _children = new List<GameObject>();
        if (HideByDefault) Hide();
    }

    public void PopChild()
    {
        var listElement = _children.Pop();
        Destroy(listElement);
    }

    public void PushChild(Item inventoryItem)
    {
        var newInventoryItem = Instantiate(InventoryUiListItem, transform);
        newInventoryItem.Initialize(inventoryItem);
        _children.Push(newInventoryItem.gameObject);
    }

    public void RemoveExact(int childIndex)
    {
        var listElement = _children[childIndex];
        Destroy(listElement);
    }

    public void Show()
    {
        transform.parent.gameObject.SetActive(true);
    }

    public void Hide()
    {
        transform.parent.gameObject.SetActive(false);
    }
}
