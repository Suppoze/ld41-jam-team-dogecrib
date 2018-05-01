using System.Collections;
using Assets.Core.Common;
using UnityEngine;
using UnityEngine.Assertions;

public class Assembler : MonoBehaviour {

    private MaterialInventory _materialInventory;
    private InRangeListener _inRangeListener;
    private PushListener _pushListener;
    private PopListener _popListener;
    private UseListener _useListener;

    private Equipment _assembledEquipment;
    private bool _assembling;

    private void Awake()
    {
        _materialInventory = GetComponent<MaterialInventory>();
        _inRangeListener = GetComponent<InRangeListener>();
        _pushListener = GetComponent<PushListener>();
        _popListener = GetComponent<PopListener>();
        _useListener = GetComponent<UseListener>();

        Assert.IsNotNull(_materialInventory);
        Assert.IsNotNull(_inRangeListener);
        Assert.IsNotNull(_pushListener);
        Assert.IsNotNull(_popListener);
        Assert.IsNotNull(_useListener);
    }

    private void Start()
    {
        _pushListener.OnPushReceived = item => PutDown(item);
        _popListener.OnPopReceived = () => PickUp();
        _useListener.OnUse = () => Assemble();
    }

    public bool PutDown(ITransferable element)
    {
        if (_assembledEquipment != null) return false;
        if (_materialInventory.IsFull) return false;
        if (_assembling) return false;
        if (!(element is Material)) return false;
        
        _materialInventory.Push(element as Material);
        return true;
    }

    public ITransferable PickUp()
    {
        if (_assembledEquipment != null)
        {
            Equipment equipment = _assembledEquipment;
            _assembledEquipment = null;
            return equipment as ITransferable;
        }

        if (_materialInventory.IsEmpty) return null;
        else
        {
            if (_assembling) StopCoroutine("AssembleRecipe");
            return _materialInventory.Pop();
        }
    }

    public bool Assemble()
    {
        return true;
    }

    IEnumerator AssembleRecipe()
    {
        _assembling = true;
        yield return new WaitForSeconds(10f);
        _assembling = false;
    }

}
