using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AbstractMinion : MonoBehaviour {
    private string myEnemy;
    Transform enemy;
    protected int minionValue = 70;

    public string MyEnemy
    {
        get
        {
            return myEnemy;
        }

        set
        {
            myEnemy = value;
        }
    }

    public int MinionValue
    {
        get
        {
            return minionValue;
        }

        set
        {
            minionValue = value;
        }
    }

    private void Awake()
    {
       
    }
    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        
    }
}
