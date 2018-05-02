using UnityEngine;

[RequireComponent(typeof(InRangeListener))]
[RequireComponent(typeof(PushListener))]
[RequireComponent(typeof(PopListener))]
[RequireComponent(typeof(Inventory))]
public class StorageStation : Station
{    
    private InRangeListener _inRangeListener;
    private PushListener _pushListener;
    private PopListener _popListener;
    private Inventory _inventory;
    private Color _originalColor;

    private void Awake()
    {
        _inRangeListener = GetComponent<InRangeListener>();
        _pushListener = GetComponent<PushListener>();
        _popListener = GetComponent<PopListener>();
        _inventory = GetComponent<Inventory>();
    }

    private void Start()
    {
        _inventory.GetComponentInChildren<InventoryUI>().Hide();

        _pushListener.OnPushReceived = OnPushReceived;
        _popListener.OnPopReceived = OnPopReceived;
        _inRangeListener.OnNotifyInRange = OnNotifyInRange;
        _inRangeListener.OnNotifyOutOfRange = OnNotifyOutOfRange;
    }

    private bool OnPushReceived(Item item)
    {
        try
        {
            _inventory.Push(item);
            return true;
        }
        catch
        {
            return false;
        }

    }

    private Item OnPopReceived() => _inventory.Pop();

    private void OnNotifyInRange(int playerIndex)
    {
        _inventory.Open();
    }

    private void OnNotifyOutOfRange(int playerIndex)
    {
        _inventory.Close();
    }
}