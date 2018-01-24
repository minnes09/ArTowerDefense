using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class MinionAttack : MonoBehaviour, ISubject
{
    public float timeBetweenAttacks = 0.5f;
    public int attackDamage = 10;
    public string myEnemy;

    //Animator anim;
    Health masterHealth;
    Health enemyHealth;

    bool enemyInRange;
    bool minionInRange;
   
    List<GameObject> minionsInRange;
    MinionHealth currentEnemyHealth;

    List<IObserver> observers = new List<IObserver>();
    float timer;

    //events
    public delegate void GainCoins(int coins);
    public event GainCoins OnMinionKilled;

    void Start()
    {
        minionsInRange = new List<GameObject>();
        //set the master and enemy objects
        if (myEnemy == "Player")
        {
            masterHealth = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Health>();
            enemyHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
        }
        else if(myEnemy == "Enemy")
        {
            masterHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
            enemyHealth = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Health>();
        }
        else throw new System.Exception("Master and enemy are set in a wrong way");
        // anim = GetComponent<Animator>();
        observers.Add(GetComponent<MinionMovement>());
        minionInRange = false;
        enemyInRange = false;
    }

    void OnTriggerEnter(Collider other)
    {
        //check if a minion is in range
        if (other.gameObject == GameObject.FindGameObjectWithTag("Minion" + myEnemy))
        {
            minionsInRange.Add(other.gameObject);
            if (!minionInRange)
            {
                minionInRange = true;
                Notify(true);
            }
        }
        //check if the enemy is in range
        else if (other.gameObject == GameObject.FindGameObjectWithTag(myEnemy))
        {
            enemyInRange = true;
            Notify(true);
            //Debug.Log(myEnemy + " in range");
        }


    }


    void OnTriggerExit(Collider other)
    {
        //reduce the number of minions in range and updates the trigger for the attack
        if (other.gameObject == GameObject.FindGameObjectWithTag("Minion" + myEnemy))
        {
            minionsInRange.Remove(other.gameObject);
            if (minionsInRange.Count == 0)
            {
                minionInRange = false;
                Notify(false);
            }
        }
        //check if the enemy is in range
        else if (other.gameObject == GameObject.FindGameObjectWithTag(myEnemy))
        {
            enemyInRange = false;
            Notify(false);
            //Debug.Log(myEnemy + " not in range anymore");
        }

    }


    void Update()
    {
        if (!GameState.Instance().Paused)
        {
            timer += Time.deltaTime;

            if (timer >= timeBetweenAttacks && minionInRange)
            {
                AttackMinion();
            }
            else if (timer >= timeBetweenAttacks && enemyInRange)
            {
                AttackEnemy();
            }

            /*if (playerHealth.currentHealth <= 0)
            {
                anim.SetTrigger("PlayerDead");
            }*/
        }
    }

    private void AttackMinion()
    {
        timer = 0f;
        if (minionInRange && minionsInRange.Count > 0 && minionsInRange[0] != null)
        {
            if (currentEnemyHealth == null)
            {
                currentEnemyHealth = minionsInRange[0].GetComponent<MinionHealth>();
            }
            else
            {
                currentEnemyHealth.UpdateHealth(attackDamage);
                if (currentEnemyHealth.MinionLife <= 0)
                {
                    if(OnMinionKilled != null)
                    {
                        OnMinionKilled(minionsInRange[0].GetComponent<AbstractMinion>().MinionValue);
                    }
                    currentEnemyHealth = null;
                    minionsInRange.RemoveAt(0);
                    
                }
            }
        }
    }


    void AttackEnemy()
    {
        timer = 0f;
        if (enemyHealth.Life > 0) //fix to check any enemy
        {
            enemyHealth.UpdateHealth(attackDamage);
            //Debug.Log(myEnemy + "health: " + enemyHealth.Life);
        }
    }

    //ISubject implementation
    public void AddObserver(IObserver obs)
    {
        observers.Add(obs);
    }

    public void RemoveObserver(IObserver obs)
    {
        observers.Remove(obs);
    }

    public void Notify(bool stopMoving)
    {
        /*foreach(IObserver obs in observers)
        {
            obs.Notify(stopMoving);
        }*/
        for(int i = 0; i < observers.Count; i++)
        {
            observers[i].Notify(stopMoving);
        }
    }
}
