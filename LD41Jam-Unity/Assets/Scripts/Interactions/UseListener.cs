using UnityEngine;

public class UseListener : MonoBehaviour
{
    public delegate bool OnUseDelegate();

    public OnUseDelegate OnUse { get; set; }

    public bool Use()
    {
        return OnUse.Invoke();
    }

}