using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour
{
    public int life = 1000;

    public int Life
    {
        get
        {
            return life;
        }

        set
        {
            life = value;
        }
    }
    
    public void UpdateHealth(int damage)
    {
        Life -= damage;
        Debug.Log(transform.name + " health: " + life);
        if (Life <= 0)
            GameState.Instance().End(transform.name);
    }
}
