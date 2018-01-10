using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class MinionMovement : MonoBehaviour {
    public string myEnemy;
    Transform enemy;
    NavMeshAgent nav;               // Reference to the nav mesh agent.
    public Transform warpPos;
    Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    // Use this for initialization
    void Start () {
        nav = GetComponent<NavMeshAgent>();
        enemy = GameObject.FindGameObjectWithTag(myEnemy).transform;
        nav.Warp(warpPos.position);
    }
	
	// Update is called once per frame TOFIX
	void Update () {
        if (!GameState.Instance().Paused)
        {
            if (nav.isStopped) nav.isStopped = false;
            if (this.transform.position != enemy.position )
            {
                // ... set the destination of the nav mesh agent to the player.
                if(nav.destination != enemy.position)   nav.SetDestination(enemy.position);
                //set animation move
                anim.SetTrigger(5);
            }
            else
            {
                // ... disable the nav mesh agent.
                nav.enabled = false;
                //set animation idle
                anim.SetTrigger(0);
            }
        }
        else
        {
            if(!nav.isStopped)  nav.isStopped = true;
        }
    }
}
