using TMPro;
using UnityEngine;

public class InventoryUIListItem : MonoBehaviour
{
    public TextMeshProUGUI Text;

    public void Initialize(Item inventoryItem)
    {
        Text.text = inventoryItem.Name;
    }

}
