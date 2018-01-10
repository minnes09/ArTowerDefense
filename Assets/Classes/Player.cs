using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    int coins;
    public int life = 1000;
    int exp;
    MinionManager minionManager;
    private void Awake()
    {
        minionManager = GetComponent<MinionManager>();
        minionManager.spawnPos = this.transform;
        minionManager.MinionParent = this.transform;
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
