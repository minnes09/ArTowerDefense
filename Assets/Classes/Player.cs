using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public Health health;
    CoinsManager coinsManager;
    MinionManager minionManager;
    private void Awake()
    {
        health = GetComponent<Health>();
        health.Life = 1000;
        minionManager = GetComponent<MinionManager>();
        minionManager.MinionParent = this.transform;
        coinsManager = GetComponent<CoinsManager>();
    }
    // MinionManager minionManager;
    void Start () {
		
	}
	
	public void SpawnMinion(AbstractMinion minion)
    {
        if (!GameState.Instance().Paused)
        {
            if (coinsManager.Coins >= minion.MinionValue)
            {
                minionManager.SpawnSingleMinion(minion.gameObject, this.transform.position);
                //register minion for the coins
                coinsManager.RegisterMinion(minionManager.LastMinionSpawned());
                coinsManager.RemoveCoins(minionManager.LastMinionSpawned().GetComponent<AbstractMinion>().MinionValue);
            }
            else
            {
                Debug.Log("<color= blue> You don't have enough money! </color>");
            }
        }
    }
}
