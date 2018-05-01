using UnityEngine;

[RequireComponent(typeof(InRangeListener))]
[RequireComponent(typeof(PushListener))]
[RequireComponent(typeof(PopListener))]
[RequireComponent(typeof(Inventory))]
public class Storage : MonoBehaviour
{
    private InRangeListener _inRangeListener;
    private PushListener _pushListener;
    private PopListener _popListener;
    private SpriteRenderer _spriteRenderer;
    private Inventory _inventory;

    private Color _originalColor;

    private void Awake()
    {
        _inRangeListener = GetComponent<InRangeListener>();
        _pushListener = GetComponent<PushListener>();
        _popListener = GetComponent<PopListener>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _inventory = GetComponent<Inventory>();
        _originalColor = _spriteRenderer.color;
    }

    private void Start()
    {
        _inventory.GetComponentInChildren<InventoryUI>().Hide();

        // TODO debug only
        _inventory.Push(new Wood(Grade.NORMAL));
        _inventory.Push(new Silk(Grade.NORMAL));
        _inventory.Push(new Wool(Grade.NORMAL));
        _inventory.Push(new Copper(Grade.NORMAL));

        _pushListener.OnPushReceived = item =>
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
        };

        _popListener.OnPopReceived = () => _inventory.Pop();

        _inRangeListener.OnNotifyInRange = playerIndex =>
        {
            _inventory.Open();
            _spriteRenderer.color = _inRangeListener.PlayerColors[playerIndex - 1];
        };

        _inRangeListener.OnNotifyOutOfRange = playerIndex =>
        {
            _inventory.Close();
            _spriteRenderer.color = _originalColor;
        };
    }
}