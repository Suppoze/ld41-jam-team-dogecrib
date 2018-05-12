using UnityEngine;

public class InRangeListener : MonoBehaviour
{
    private readonly bool[] _playersInRange = {false, false};

    public delegate void NotifyInRangeDelegate(int playerIndex);
    public delegate void NotifyOutOfRangeDelegate(int playerIndex);

    public NotifyInRangeDelegate OnNotifyInRange { private get; set; }
    public NotifyOutOfRangeDelegate OnNotifyOutOfRange { private get; set; }

    private void Awake()
    {
    }

    public void NotifyInRange(int playerIndex)
    {
        if (_playersInRange[playerIndex]) return;
        _playersInRange[playerIndex] = true;
        
        OnNotifyInRange?.Invoke(playerIndex);
    }

    public void NotifyOutOfRange(int playerIndex)
    {
        _playersInRange[playerIndex] = false;
        
        OnNotifyOutOfRange?.Invoke(playerIndex);
    }

}