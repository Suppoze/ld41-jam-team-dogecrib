using System;
using Assets.Core.Orders;
using TMPro;
using UnityEngine;

public class OrderCardUI : MonoBehaviour
{
    public TextMeshProUGUI Text;
    public TextMeshProUGUI RemainingTime;

    private bool _timeChangedFlag;
    private long _remainingMillis;

    public void Initialize(Order newOrder)
    {
        Text.text = newOrder.Item.Name;
        newOrder.OnRemainingMillisUpdated = ListenForMillisUpdate;
    }

    void Update()
    {
        UpdateMillis();
    }

    private void UpdateMillis()
    {
        if (!_timeChangedFlag) return;

        var timeSpan = TimeSpan.FromMilliseconds(_remainingMillis);
        RemainingTime.text = timeSpan.ToString();
        _timeChangedFlag = false;
    }

    private void ListenForMillisUpdate(long remainingMillis)
    {
        _remainingMillis = remainingMillis;
        _timeChangedFlag = true;
    }
}
