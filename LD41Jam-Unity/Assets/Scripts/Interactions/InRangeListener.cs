using UnityEngine;

public class InRangeListener : MonoBehaviour
{
    private readonly bool[] _playersInRange = {false, false};

    public Color[] PlayerColors = new Color[2];

    public delegate void NotifyInRangeDelegate(int playerIndex);
    public delegate void NotifyOutOfRangeDelegate(int playerIndex);

    public NotifyInRangeDelegate OnNotifyInRange { get; set; }
    public NotifyOutOfRangeDelegate OnNotifyOutOfRange { get; set; }

    public void NotifyInRange(int playerIndex)
    {
        if (_playersInRange[playerIndex - 1]) return;
        _playersInRange[playerIndex - 1] = true;
        OnNotifyInRange?.Invoke(playerIndex);
    }

    public void NotifyOutOfRange(int playerIndex)
    {
        _playersInRange[playerIndex - 1] = false;
        OnNotifyOutOfRange?.Invoke(playerIndex);
    }

}