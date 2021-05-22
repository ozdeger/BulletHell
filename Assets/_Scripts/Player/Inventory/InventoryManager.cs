using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

public class InventoryManager : AutoCleanupSingleton<InventoryManager>
{
    private List<ItemData> itemDatas = new List<ItemData>();


    public void PickedUpItem(ItemData itemData)
    {
        itemData.OnPickUp();

        itemDatas.Add(itemData);
    }
}
