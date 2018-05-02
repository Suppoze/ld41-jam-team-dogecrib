using System.Collections.Generic;
using Core.Extensions;
using UnityEngine;

public class Inventory<T> : MonoBehaviour where T : Item
{
    public GameObject InventoryCanvas;
    public int Capacity = 5;

    private InventoryUI _inventoryUi;

    public List<T> Contents { get; private set; }

    private void Awake()
    {
        Contents = new List<T>();
    }

    private void Start()
    {
        var inventoryCanvas = Instantiate(InventoryCanvas, transform);
        _inventoryUi = inventoryCanvas.GetComponentInChildren<InventoryUI>();
    }

    public void Open()
    {
        _inventoryUi.Show();
    }

    public void Close()
    {
        _inventoryUi.Hide();
    }

    public T Pop()
    {
        _inventoryUi.PopChild();
        var popped = Contents.Pop();
        return popped;
    }

    public void Push(T element)
    {
        _inventoryUi.PushChild(element);
        Contents.Push(element);
    }

    public void CreateMatchingListWith(List<Item> invItemsCopy)
    {
        var contentsIndex = 0;
        while (contentsIndex < Contents.Count)
        {
            if (contentsIndex == invItemsCopy.Count
                || Contents[contentsIndex].Name != invItemsCopy[contentsIndex].Name)
            {
                RemoveExact(contentsIndex);
                continue;
            }

            contentsIndex++;
        }
    }

    private void RemoveExact(int contentsIndex)
    {
        Contents.RemoveAt(contentsIndex);
        _inventoryUi.RemoveExact(contentsIndex);
    }

    public int AvailableSpace => Capacity - Contents.Count;
    public bool IsEmpty => Contents.Count == 0;
    public bool IsFull => AvailableSpace == 0;
}

public class Inventory : Inventory<Item>
{
}