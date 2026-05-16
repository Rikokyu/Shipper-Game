using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveController : MonoBehaviour
{
    private string saveLocation;
    private InventoryController inventoryController;
    private HorizontalController hotbarController;
    private ShopNPC[] shops;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InitializeComponents();
        LoadGame();
    }

    private void InitializeComponents()
    {
        // saveLocation = Path.Combine(Application.persistentDataPath, "saveData. json");
        saveLocation = Application.dataPath + "/testData.json";
        inventoryController = FindObjectOfType<InventoryController>();
        hotbarController = FindObjectOfType<HorizontalController>();
        shops = FindObjectsOfType<ShopNPC>();
    }
    
    public void SaveGame()
    {
        SaveData saveData = new SaveData
        {
            playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position,
            bikePosition = GameObject.FindGameObjectWithTag("Bike").transform.position,
            inventorySaveData = inventoryController.GetInventoryItems(),
            hotbarSaveData = hotbarController.GetHotbarItems(),
            questProgressData = QuestController.Instance.activateQuests,
            handinQuestIDs = QuestController.Instance.handinQuestIDs,
            playerGold = CurrencyController.Instance.GetGold(),
            shopStates = GetShopStates()
        };
        File.WriteAllText(saveLocation, JsonUtility.ToJson(saveData));
    }

    private List<ShopInstanceData> GetShopStates()
    {
        List<ShopInstanceData> shopStates = new List<ShopInstanceData>();
        foreach(var shop in shops)
        {
            ShopInstanceData shopData = new ShopInstanceData
            {
                shopID = shop.shopID,
                stock = new List<ShopItemData>()

            };

        foreach(var stockItem in shop.GetCurrentStock())
        {
            shopData.stock.Add(new ShopItemData
            {
                itemID = stockItem.itemID,
                quantity = stockItem.quantity
            });
        }
        shopStates.Add(shopData);
        }
        return shopStates;
    }

    public void LoadGame()
    {
        if (File.Exists(saveLocation))
        {
            SaveData saveData = JsonUtility.FromJson<SaveData>(File.ReadAllText(saveLocation));
            GameObject.FindGameObjectWithTag("Player").transform.position = saveData.playerPosition;
            GameObject.FindGameObjectWithTag("Bike").transform.position = saveData.bikePosition;

            inventoryController.SetInventoryItems(saveData.inventorySaveData);
            hotbarController.SetHotbarItems(saveData.hotbarSaveData);
            
            LoadShopStates(saveData.shopStates);
            CurrencyController.Instance.SetGold(saveData.playerGold);

            QuestController.Instance.LoadQuestProgress(saveData.questProgressData);
            QuestController.Instance.handinQuestIDs = saveData.handinQuestIDs;
        }
        else
        {
            SaveGame();
        }
    }

    private void LoadShopStates(List<ShopInstanceData> shopStates)
    {
        if (shopStates == null) return;

        foreach(var shop in shops)
        {
            ShopInstanceData shopData = shopStates.FirstOrDefault(s => s.shopID == shop.shopID);

            if(shopData != null)
            {
                List<ShopNPC.ShopStockItem> loadedStock = new List<ShopNPC.ShopStockItem>();

                foreach (var itemData in shopData.stock)
                {
                    loadedStock.Add(new ShopNPC.ShopStockItem
                    {
                        itemID = itemData.itemID,
                        quantity = itemData.quantity
                    });
                }
            shop.SetStock(loadedStock);
            }
        }
    }
}
