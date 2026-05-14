using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyController : MonoBehaviour
{
    public static CurrencyController Instance;

    [SerializeField] private int startingGold = 100; //Starting gold for new game
    private int playerGold = 100;
    public event Action<int> OnGoldChanged;
    
    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(gameObject);
        else
        {
            Instance = this;
            playerGold = startingGold;
        }
    }

    
    public int GetGold() => playerGold;
    
    public bool SpendGold(int amount)
    {
        if (playerGold >= amount)
        {
            playerGold -= amount;
            OnGoldChanged ?. Invoke(playerGold);
            return true; //spent gold
        }
        return false; //not enough gold
    }
    public void AddGold(int amount)
    {
        playerGold += amount;
        OnGoldChanged?.Invoke(playerGold);
    }

    public void SetGold(int amount)
    {
        playerGold = amount;
        OnGoldChanged?.Invoke(playerGold);
    }
}
