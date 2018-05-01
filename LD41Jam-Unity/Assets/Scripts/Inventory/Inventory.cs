using System.Collections.Generic;
using Assets.Core.Common;
using UnityEngine;

public class Inventory<T> : MonoBehaviour where T : ITransferable
{
    public GameObject InventoryCanvas;
    public int Capacity = 5;

    private Stack<T> _inventoryStack;
    private InventoryUI _inventoryUi;

    private void Awake()
    {
        _inventoryStack = new Stack<T>(Capacity);
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
        var element = _inventoryStack.Pop();
        return element;
    }

    public void Push(T element)
    {
        _inventoryUi?.PushChild(element);
        _inventoryStack.Push(element);
    }

    public int AvailableSpace => Capacity - _inventoryStack.Count;
    public bool IsEmpty => _inventoryStack.Count == 0;
    public bool IsFull => AvailableSpace == 0;
}
 
public class Inventory : Inventory<ITransferable> { }

