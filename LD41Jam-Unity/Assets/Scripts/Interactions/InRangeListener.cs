using cakeslice;
using UnityEngine;

public class InRangeListener : MonoBehaviour
{
    private readonly bool[] _playersInRange = {false, false};
    
    private Outline _outline;

    public delegate void NotifyInRangeDelegate(int playerIndex);
    public delegate void NotifyOutOfRangeDelegate(int playerIndex);

    public NotifyInRangeDelegate OnNotifyInRange { private get; set; }
    public NotifyOutOfRangeDelegate OnNotifyOutOfRange { private get; set; }

    private void Awake()
    {
        _outline = GetComponent<Outline>();
    }

    public void NotifyInRange(int playerIndex)
    {
        if (_playersInRange[playerIndex]) return;
        _playersInRange[playerIndex] = true;
        
        EnableOutline(playerIndex);
        
        OnNotifyInRange?.Invoke(playerIndex);
    }

    public void NotifyOutOfRange(int playerIndex)
    {
        _playersInRange[playerIndex] = false;
        
        DisableOutline();
        
        OnNotifyOutOfRange?.Invoke(playerIndex);
    }

    private void DisableOutline()
    {
        if (_outline == null) return;
        _outline.enabled = false;
    }

    private void EnableOutline(int playerIndex)
    {
        if (_outline == null) return;
        _outline.color = playerIndex;
        _outline.enabled = true;
    }
}