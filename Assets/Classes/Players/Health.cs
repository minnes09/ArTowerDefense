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


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
