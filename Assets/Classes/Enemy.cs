using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public Health health;
    public float spawnDelay = 4f;
	MinionManager minionManager;
    //string myEnemy = "Player";
	void Awake(){
        health.Life = 1000;
        minionManager = GetComponent<MinionManager>();
        //minionManager.myEnemy = myEnemy;
        minionManager.MinionParent = this.transform;
        //GameState.Instance();
	}

	// Use this for initialization
	void Start () {
        InvokeRepeating("Spawn", spawnDelay, spawnDelay);
	}

    void Spawn()
    {
        if (!GameState.Instance().Paused)
            minionManager.Spawn();
    }
	

}
