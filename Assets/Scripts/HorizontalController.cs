using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HorizontalController : MonoBehaviour
{
    public GameObject hotbarPanel;
    public GameObject slotPrefab;
    public int slotCount = 10; //1-0 on the keyboard

    private ItemDictionary itemDictionary;

    private Key[] hotbarKeys;


    private void Awake()
    {

        itemDictionary = FindObjectOfType<ItemDictionary>();

        // Hotbar keys based on slot count
        hotbarKeys = new Key[slotCount];
        for(int i = 0; i < slotCount; i++)
        {
            hotbarKeys[i]=i<9?(Key)((int)Key.Digit1+i) : Key.Digit0;
        }
    }
    // Update is called once per frame
    void Update()
    {
        // Check for key presses
        for (int i = 0; i < slotCount; i++)
        {
            if (Keyboard.current[hotbarKeys[i]].wasPressedThisFrame)
            {
                UseItemInSlot(i);
            }
        }
    }
    void UseItemInSlot(int index)
    {
        Slot slot = hotbarPanel.transform.GetChild(index).GetComponent<Slot>();
        if(slot.currentItem != null)
        {
            Item item = slot.currentItem.GetComponent<Item>();
            item.UseItem();
        }
    }
    public List<InventorySaveData> GetHotbarItems()
    {
        List<InventorySaveData> hotbar = new List<InventorySaveData>();
        foreach(Transform slotTranform in hotbarPanel.transform)
        {
            Slot slot = slotTranform.GetComponent<Slot>();
            if(slot.currentItem != null)
            {
                Item item = slot.currentItem.GetComponent<Item>();
                hotbar.Add(new InventorySaveData { itemID = item. ID, slotIndex = slotTranform.GetSiblingIndex() });
            }
        }
        return hotbar;
    }

    public void SetHotbarItems(List<InventorySaveData> inventorySaveData)
    {
        //Clear hotbar panel - avoid duplicates
        foreach(Transform child in hotbarPanel.transform)
        {
            Destroy(child.gameObject);
        }
        //Create new slots
        for(int i = 0; i < slotCount; i++)
        {
            Instantiate(slotPrefab, hotbarPanel.transform);
        }
        //Populate slots with saved items
        foreach(InventorySaveData data in inventorySaveData)
        {
            if(data.slotIndex < slotCount)
            {
                Slot slot = hotbarPanel.transform.GetChild(data.slotIndex).GetComponent<Slot>();
                GameObject itemPrefab = itemDictionary.GetItemPrefab(data.itemID);
                if(itemPrefab != null)
                {
                    GameObject item = Instantiate(itemPrefab, slot.transform);
                    item.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
                    slot.currentItem = item;
                }
            }
        }
    }
}

