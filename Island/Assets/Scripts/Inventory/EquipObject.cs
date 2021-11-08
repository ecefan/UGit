using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment Object", menuName = "Inventory System/Items/Equipment")]
public class EquipObject : ItemObject
{

    private void Awake()
    {
        itemType = ItemType.Equipment;  
    }
}
