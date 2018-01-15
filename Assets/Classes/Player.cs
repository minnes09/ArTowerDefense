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
        if(!GameState.Instance().Paused)
            minionManager.SpawnSingleMinion(minion.gameObject, this.transform.position);
    }
}
