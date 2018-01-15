using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class CoinsManager : MonoBehaviour
{
    private int coins = 200;

    public int Coins
    {
        get
        {
            return coins;
        }

        set
        {
            coins = value;
        }
    }


    //coins change event
    public delegate void CoinChangedEvent(int coins);
    public static event CoinChangedEvent OnCoinChanged;
    // Use this for initialization
    void Start()
    {
        
    }

    public void AddCoins(int newCoins)
    {
        Coins += newCoins;
        if (OnCoinChanged != null) OnCoinChanged(Coins);
    }

    public void RemoveCoins(int lessCoins)
    {
        Coins -= lessCoins;
        if (OnCoinChanged != null) OnCoinChanged(Coins);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnDestroy()
    {
        List<GameObject> minions = GetComponent<MinionManager>().GetMinionsList();
        foreach(GameObject minion in minions)
        {
            minion.GetComponent<MinionAttack>().OnMinionKilled -= AddCoins;
        }
    }

    internal void RegisterMinion(GameObject minion)
    {
        minion.GetComponent<MinionAttack>().OnMinionKilled += AddCoins;
    }
}
