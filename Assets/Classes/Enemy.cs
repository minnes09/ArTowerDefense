using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public int life = 100;
    public float spawnDelay = 4f;
	MinionManager minionManager;
    string myEnemy = "Player";
	void Awake(){
        minionManager = GetComponent<MinionManager>();
        minionManager.myEnemy = myEnemy;
        GameState.Instance();
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
