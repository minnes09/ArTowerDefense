using UnityEngine;
using System.Collections;
using System;

public class MinionHealth : MonoBehaviour
{
    private bool isSinking;
    private float sinkSpeed = 2f;

    public int minionLife;
    public int MinionLife
    {
        get
        {
            return minionLife;
        }

        set
        {
            minionLife = value;
        }
    }

    public void UpdateHealth(int damage)
    {
        MinionLife -= damage;
        Debug.Log(transform.name + " health: " + MinionLife);
        if (MinionLife <= 0)
            Death();
    }

    void Update()
    {
        if (isSinking)
        {
            transform.Translate(-Vector3.up * sinkSpeed * Time.deltaTime);
        }
    }

    void Death()
    {
        GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
        isSinking = true;
        Destroy(gameObject, 2f);
    }

}
