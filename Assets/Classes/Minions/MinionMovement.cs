using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class MinionMovement : MonoBehaviour {
    public string myEnemy;
    Transform enemy;
    NavMeshAgent nav;               // Reference to the nav mesh agent.

    private void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
    }
    // Use this for initialization
    void Start () {
        enemy = GameObject.FindGameObjectWithTag(myEnemy).transform;
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
            }
            else
            {
                // ... disable the nav mesh agent.
                nav.enabled = false;
            }
        }
        else
        {
            if(!nav.isStopped)  nav.isStopped = true;
        }
    }
}
