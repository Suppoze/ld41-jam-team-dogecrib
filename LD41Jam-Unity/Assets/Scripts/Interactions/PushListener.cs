using UnityEngine;

public class PushListener : MonoBehaviour
{
    public delegate bool OnPushDelegate(Item inventoryStackElement);

    public OnPushDelegate OnPushReceived { get; set; }

    public bool Push(Item inventoryStackElement)
    {
        return OnPushReceived != null && OnPushReceived.Invoke(inventoryStackElement);
    }
}