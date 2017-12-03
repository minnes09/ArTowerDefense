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
                var instantiatedWar = Instantiate(warrior, this.spawnPos.position, this.spawnPos.rotation);
                instantiatedWar.GetComponent<MinionMovement>().myEnemy = myEnemy;
                //SpawnSingleMinion(warrior, newSpawnPos);
            }
            else
            {
                var instantiatedMage = Instantiate(mage, this.spawnPos.position, this.spawnPos.rotation);
                instantiatedMage.GetComponent<MinionMovement>().myEnemy = myEnemy;
            }
        }
	}

    public void SpawnSingleMinion(GameObject minion, Vector3 spawnPos)
    {
        if (!GameState.Instance().Paused)
        {
            Instantiate(minion, spawnPos, this.spawnPos.rotation);
            minion.GetComponent<MinionMovement>().myEnemy = myEnemy;
        }
    }
}
