using System.Collections.Generic;
using UnityEngine;

public class Inventory<T> : MonoBehaviour where T : Item
{
    public GameObject InventoryCanvas;
    public int Capacity = 5;

    private InventoryUI _inventoryUi;
    
    public Stack<T> InventoryStack { get; private set; }

    private void Awake()
    {
        InventoryStack = new Stack<T>(Capacity);
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
        _inventoryUi?.PopChild();
        var element = InventoryStack.Pop();
        return element;
    }

    public void Push(T element)
    {
        _inventoryUi?.PushChild(element);
        InventoryStack.Push(element);
    }

    public int AvailableSpace => Capacity - InventoryStack.Count;
    public bool IsEmpty => InventoryStack.Count == 0;
    public bool IsFull => AvailableSpace == 0;
}
 
public class Inventory : Inventory<Item> { }

