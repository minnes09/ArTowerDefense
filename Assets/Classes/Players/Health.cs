using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Health : MonoBehaviour
{
   
    public float startLife = 1000;
    public float life;
    [Header("Unity Health Bar") ]
    public Image healthBar;

    public void Start()
    {
        life = startLife;
    }

    public float Life
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
        healthBar.fillAmount = Life / startLife;

        if (Life <= 0)
            GameState.Instance().End(transform.name);
    }
}
