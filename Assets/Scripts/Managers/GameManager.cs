using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private int coins = 0;
    public Action<int> coinsUpdated;

    private void Awake()
    {
        instance = this;
    }

    public void AddCoins(int addedCoins)
    {
        coins += addedCoins;
        coinsUpdated.Invoke(coins);
    }

    public void RemoveCoins(int removedCoins)
    {
        coins -= removedCoins;
        coinsUpdated.Invoke(coins);
    }
}
