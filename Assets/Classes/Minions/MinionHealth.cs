using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class MinionHealth : MonoBehaviour
{
    private bool isSinking;
    private float sinkSpeed = 2f;

    [Header("Unity Health Bar")]
    public Image healthBar;

    public float startLife;
    public float minionLife;
   
    public float MinionLife
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

    void Start()
    {
        minionLife = startLife;
    }
    public void UpdateHealth(int damage)
    {
        MinionLife -= damage;
        Debug.Log(transform.name + " health: " + MinionLife);
        healthBar.fillAmount = minionLife / startLife;
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
