using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public InventoryUIListItem InventoryUiListItem;
    public bool HideByDefault;

    private Stack<GameObject> _children;

    private void Awake()
    {
        _children = new Stack<GameObject>();
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

    public void Show()
    {
        transform.parent.gameObject.SetActive(true);
    }

    public void Hide()
    {
        transform.parent.gameObject.SetActive(false);
    }

}
