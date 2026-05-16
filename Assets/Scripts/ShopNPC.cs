using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopNPC : MonoBehaviour, IInteractable
{
    public string shopID = "shop_01";
    public string shopkeeperName = "Merchant";

    public List<ShopStockItem> defaultShopStock = new();
    private List<ShopStockItem> currentShopStock = new();

    private bool isInitialized = false;

    [System.Serializable]

    public class ShopStockItem
    {
        public int itemID;
        public int quantity;
    }
    void Start()
    {
        InitializeShop();
    }

    private void InitializeShop()
    {
        if (isInitialized) return;

        //Default stock (overwritten by save system if save exists)
        currentShopStock = new List<ShopStockItem>();
        foreach (var item in defaultShopStock)
        {
            currentShopStock.Add(new ShopStockItem
            {
                itemID = item.itemID,
                quantity = item.quantity
                
            });
        }
        isInitialized = true;
    }
    public bool CanInteract()
    {
        return true;
    }
    public void Interact()
    {
        if (ShopController.Instance == null) return;

        if (ShopController. Instance.shopPanel.activeSelf)
        {
            ShopController.Instance.CloseShop();
        }
        else
        {
            ShopController.Instance.OpenShop(this);
        }
    }
    public List<ShopStockItem> GetCurrentStock()
    {
        return currentShopStock;
    }
//Used when loading save

    public void SetStock(List<ShopStockItem> stock)
    {
        currentShopStock = stock;
    }


    public void AddToStock(int itemID, int quantity)
    {
        ShopStockItem existing = currentShopStock.Find(s =>s.itemID == itemID);
        if (existing != null)   
        {
            existing.quantity += quantity;
        }
        else
        {
            currentShopStock.Add(new ShopStockItem { itemID = itemID, quantity = quantity });
        }
    }
    public bool RemoveFromShopStock(int itemID, int quantity)
    {
        ShopStockItem existing = currentShopStock.Find(s => s.itemID == itemID);
        if (existing != null && existing.quantity >= quantity)
        {
            existing.quantity -= quantity;
            return true;
        }
        return false;
    }
}
