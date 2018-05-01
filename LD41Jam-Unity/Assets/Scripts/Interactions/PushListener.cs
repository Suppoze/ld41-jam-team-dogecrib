using Assets.Core.Common;
using UnityEngine;

public class PushListener : MonoBehaviour
{
    public delegate bool OnPushDelegate(ITransferable inventoryStackElement);

    public OnPushDelegate OnPushReceived { get; set; }

    public bool Push(ITransferable inventoryStackElement)
    {
        return OnPushReceived != null && OnPushReceived.Invoke(inventoryStackElement);
    }

}
