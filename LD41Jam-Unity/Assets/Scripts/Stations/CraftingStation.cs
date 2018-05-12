using UnityEngine;

[RequireComponent(typeof(Inventory))]
[RequireComponent(typeof(InRangeListener))]
[RequireComponent(typeof(UseListener))]
public class CraftingStation : Station
{
    public Processor Processor;

    private Inventory _inventory;
    private InRangeListener _inRangeListener;
    private UseListener _useListener;

    private void Awake()
    {
        _inventory = GetComponent<Inventory>();
        _inRangeListener = GetComponent<InRangeListener>();
        _useListener = GetComponent<UseListener>();
    }

    private void Start()
    {
        _inRangeListener.OnNotifyInRange = playerIndex => _inventory.Open();
        _inRangeListener.OnNotifyOutOfRange = playerIndex => _inventory.Close();
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

    private bool BeginProcessing()
    {
        if (!FindRecipe()) return false; // TODO duplicate check

        Process();
        return true;
    }
}