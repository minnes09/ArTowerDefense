using UnityEngine;
using System.Collections;

public class MinionAttack : MonoBehaviour
{
    public float timeBetweenAttacks = 0.5f;
    public int attackDamage = 10;
    public string myEnemy;

    //Animator anim;
    GameObject master;
    GameObject enemy;

    bool enemyInRange;
    bool minionInRange;

    float timer;

    void Awake()
    {
        //set the master and enemy objects
        if (myEnemy == "Player")
        {
            master = GameObject.FindGameObjectWithTag("Player");
            enemy = GameObject.FindGameObjectWithTag("Enemy");
        }
        else if(myEnemy == "Enemy")
        {
            enemy = GameObject.FindGameObjectWithTag("Player");
            master = GameObject.FindGameObjectWithTag("Enemy");
        }
        else throw new System.Exception("Master and enemy are set in a wrong way");
       // anim = GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == enemy)
        {
            enemyInRange = true;
        }
    }


    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == enemy)
        {
            enemyInRange = false;
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
        if (enemy.GetComponent<Player>().life > 0) //fix to check any enemy
        {
            enemy.GetComponent<Player>().life -= attackDamage;
        }
    }
}
