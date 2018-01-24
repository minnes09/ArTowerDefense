using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorMinion : AbstractMinion {
    private int minionValue = 50;
    public override int MinionValue
    {
        get
        {
            return minionValue;
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
