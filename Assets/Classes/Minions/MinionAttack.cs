using UnityEngine;
using System.Collections;

public class MinionAttack : MonoBehaviour
{
    public float timeBetweenAttacks = 0.5f;
    public int attackDamage = 10;
    public string myEnemy;

    //Animator anim;
    Health masterHealth;
    Health enemyHealth;

    bool enemyInRange;
    bool minionInRange;

    float timer;

    void Awake()
    {
        //set the master and enemy objects
        if (myEnemy == "Player")
        {
            masterHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
            enemyHealth = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Health>();
        }
        else if(myEnemy == "Enemy")
        {
            enemyHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
            masterHealth = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Health>();
        }
        else throw new System.Exception("Master and enemy are set in a wrong way");
       // anim = GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == GameObject.FindGameObjectWithTag(myEnemy))
        {
            enemyInRange = true;
            Debug.Log("Minion in range");
        }
    }


    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == GameObject.FindGameObjectWithTag(myEnemy))
        {
            enemyInRange = false;
            Debug.Log("Minion not in range anymore");
        }
    }


    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= timeBetweenAttacks && enemyInRange)
        {
            Attack();
        }

        /*if (playerHealth.currentHealth <= 0)
        {
            anim.SetTrigger("PlayerDead");
        }*/
    }


    void Attack()
    {
        timer = 0f;
        if (enemyHealth.Life > 0) //fix to check any enemy
        {
            enemyHealth.Life -= attackDamage;
        }
    }
}
