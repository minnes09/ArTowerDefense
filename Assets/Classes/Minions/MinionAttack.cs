using UnityEngine;
using System.Collections;

public class MinionAttack : MonoBehaviour
{
    public float timeBetweenAttacks = 0.5f;
    public int attackDamage = 10;
    public string myEnemy;

    Animator anim;
    GameObject master;
    GameObject enemy;
    bool playerInRange;
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
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
