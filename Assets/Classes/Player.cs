using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    int coins;
    int life;
    int exp;
    MinionManager minionManager;
    private void Awake()
    {
        minionManager = GetComponent<MinionManager>();
        minionManager.MinionParent = this.transform;
    }
    // MinionManager minionManager;
    void Start () {
		
	}
	
	public void SpawnMinion(AbstractMinion minion)
    {
        minionManager.SpawnSingleMinion(minion.gameObject, this.transform.position);
    }
}
