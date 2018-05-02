using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Inventory))]
[RequireComponent(typeof(InRangeListener))]
[RequireComponent(typeof(PushListener))]
[RequireComponent(typeof(PopListener))]
[RequireComponent(typeof(UseListener))]
public class CraftingStation : Station
{
    /*public Processor Processor;

    private Inventory _inventory;
    private InRangeListener _inRangeListener;
    private PushListener _pushListener;
    private PopListener _popListener;
    private UseListener _useListener;

    private bool _processing;

    private void Awake()
    {
        _inventory = GetComponent<Inventory>();
        _inRangeListener = GetComponent<InRangeListener>();
        _pushListener = GetComponent<PushListener>();
        _popListener = GetComponent<PopListener>();
        _useListener = GetComponent <UseListener>();
    }

    private void Start()
    {
        _pushListener.OnPushReceived = PutDown;
        _popListener.OnPopReceived = PickUp;
        _useListener.OnUse = BeginProcessing;
    }

    private bool CanProcess()
    {
        return Processor.CanProcess(_inventory.InventoryStack);
    }

    private Item Process()
    {
        if (!CanProcess()) return null;

        return Processor.Process(_inventory.InventoryStack);
    }

    private bool PutDown(Item item)
    {
        Debug.Log("Put down element");
        if (_inventory.IsFull) return false;
        
        _inventory.Push(item);
        
        return true;
    }

    private Item PickUp()
    {
        Debug.Log("Pick up element");
        if (_inventory.IsEmpty) return null;

        if (_processing) StopCoroutine(ProcessMaterial());
        
        return _inventory.Pop();
    }

    private bool BeginProcessing()
    {
        if (!CanProcess()) return false;
        
        StartCoroutine(ProcessMaterial());
        return true;
    }

    IEnumerator ProcessMaterial()
    {
        _processing = true;
        yield return new WaitForSeconds(3f);
        ITransferable element = _inventory.Pop();
        UnityEngine.Material material = element as UnityEngine.Material;
        UnityEngine.Material processedMaterial = Process(material);
        _inventory.Push(processedMaterial);
    }*/
}