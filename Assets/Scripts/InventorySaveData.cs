using System. Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class InventorySaveData
{
    public int itemID;
    public int slotIndex; 
    public List<InventorySaveData> inventorySaveData;
    public int quantity = 1;
}