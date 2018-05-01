using Assets.Core.Common;
using TMPro;
using UnityEngine;

public class InventoryUIListItem : MonoBehaviour
{
    public TextMeshProUGUI Text;

    public void Initialize(ITransferable inventoryItem)
    {
        Text.text = inventoryItem.Name;
    }

}
