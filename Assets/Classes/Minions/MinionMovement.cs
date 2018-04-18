using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class MinionMovement : MonoBehaviour, IObserver {
    public string myEnemy;
    Transform enemy;
    NavMeshAgent nav;               // Reference to the nav mesh agent.
    public Transform warpPos;
    private float maxDistance = 0.05f;
    MinionAttack minionAttack;
    //Animator anim;

    bool cantMove;
    private void Awake()
    {
        //anim = GetComponent<Animator>();
    }
    // Use this for initialization
    void Start () {
        nav = GetComponent<NavMeshAgent>();
        enemy = GameObject.FindGameObjectWithTag(myEnemy).transform;
        nav.Warp(warpPos.position);
        minionAttack = GetComponent<MinionAttack>();
        cantMove = false;
    }
	
	// Update is called once per frame TOFIX
	void Update () {
        if (nav.enabled)
        {
            if (!GameState.Instance().Paused && !this.cantMove)
            {
                //GameUnpaused
                if (nav.isStopped) nav.isStopped = false;
                //minion arrived
                if (Vector3.Distance(this.transform.position, enemy.position) > maxDistance) // create a range filter to block in the range of the attack
                {
                    // ... set the destination of the nav mesh agent to the player.
                    if (nav.destination != enemy.position) nav.SetDestination(enemy.position);
                    //set animation move
                    //anim.SetTrigger(5);
                }
                else
                {
                    nav.isStopped = true;
                }
            }
            else
            {
                if (!nav.isStopped) nav.isStopped = true;
            }
        }
    }

    public void Notify(bool stopMoving)
    {
        //check if changing the state
        if (cantMove != stopMoving)
        {
            cantMove = stopMoving;
            if (nav.enabled)
            {
                if (cantMove) StopMovement();
                else ResumeMovement();
            }
        }
    }
    void StopMovement()
    {
        nav.speed = 0;
        nav.isStopped = true;
    }
    void ResumeMovement()
    {
        nav.speed = 8;
        nav.isStopped = false;
    }
}
