using UnityEngine;

[RequireComponent(typeof(Inventory))]
[RequireComponent(typeof(InRangeListener))]
[RequireComponent(typeof(PushListener))]
[RequireComponent(typeof(PopListener))]
[RequireComponent(typeof(UseListener))]
public class CraftingStation : Station
{
    public Processor Processor;

    private Inventory _inventory;
    private InRangeListener _inRangeListener;
    private PushListener _pushListener;
    private PopListener _popListener;
    private UseListener _useListener;

    private void Awake()
    {
        _inventory = GetComponent<Inventory>();
        _inRangeListener = GetComponent<InRangeListener>();
        _pushListener = GetComponent<PushListener>();
        _popListener = GetComponent<PopListener>();
        _useListener = GetComponent<UseListener>();
    }

    private void Start()
    {
        _inRangeListener.OnNotifyInRange = playerIndex => _inventory.Open();
        _inRangeListener.OnNotifyOutOfRange = playerIndex => _inventory.Close();
        _pushListener.OnPushReceived = PutDown;
        _popListener.OnPopReceived = PickUp;
        _useListener.OnUse = BeginProcessing;
    }

    private Recipe FindRecipe()
    {
        return Processor.FindProcessableRecipe(_inventory.Contents);
    }

    private void Process()
    {
        var recipeToCraft = FindRecipe(); // TODO duplicate check
        if (recipeToCraft == null) return;

        Processor.Process(_inventory, recipeToCraft);
    }

    private bool PutDown(Item item)
    {
        if (_inventory.IsFull) return false;

        _inventory.Push(item);

        return true;
    }

    private Item PickUp()
    {
        return _inventory.Pop(); // If empty, error is thrown.
    }

    private bool BeginProcessing()
    {
        if (!FindRecipe()) return false; // TODO duplicate check

        Process();
        return true;
    }
}