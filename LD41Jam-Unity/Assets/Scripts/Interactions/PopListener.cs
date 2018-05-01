using Assets.Core.Common;
using UnityEngine;

public class PopListener : MonoBehaviour
{
    public delegate ITransferable OnPopDelegate();

    public OnPopDelegate OnPopReceived { get; set; }

    public ITransferable Pop()
    {
        return OnPopReceived.Invoke();
    }

}