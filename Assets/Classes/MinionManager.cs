using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionManager : MonoBehaviour
{

	public GameObject warrior; //the warrior prefab to be spawned
	public GameObject mage; //the mage prefab to be spawned
	List<GameObject> minions = new List<GameObject>();
	public Transform spawnPos;
    public string myEnemy;

    public Transform MinionParent { get; set; }

    private void Awake()
    {
    }
    // Use this for initialization
    void Start () {
	}
    
    public void Spawn()
	{
        if (!GameState.Instance().Paused)
        {
            int rndMinion = Random.Range(0, 2);
            // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
            if (rndMinion == 0)
            {
                GameObject instantiatedWar = Instantiate(warrior, this.spawnPos.position, this.spawnPos.rotation);
                SetupMinion(instantiatedWar);
            }
            else
            {
                GameObject instantiatedMage = Instantiate(mage, this.spawnPos.position, this.spawnPos.rotation);
                SetupMinion(instantiatedMage);
            }
        }
	}

    private void SetupMinion(GameObject minion)
    {
        minions.Add(minion);
        minion.GetComponent<MinionMovement>().myEnemy = myEnemy;
        minion.GetComponent<MinionMovement>().warpPos = spawnPos;
        minion.GetComponent<MinionAttack>().myEnemy = myEnemy;
        minion.tag = "Minion" + transform.tag;
        minion.transform.parent = MinionParent;
    }

    public void SpawnSingleMinion(GameObject minion, Vector3 spawnPos)
    {
        if (!GameState.Instance().Paused)
        {
            GameObject instantiatedMinion = Instantiate(minion, spawnPos, this.spawnPos.rotation);
            SetupMinion(instantiatedMinion);
        }
    }
}
