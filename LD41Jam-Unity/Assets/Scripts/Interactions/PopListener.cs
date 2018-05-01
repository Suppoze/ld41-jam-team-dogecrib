using UnityEngine;

public class PopListener : MonoBehaviour
{
    public delegate Item OnPopDelegate();

    public OnPopDelegate OnPopReceived { private get; set; }

    public Item Pop()
    {
        return OnPopReceived.Invoke();
    }

}