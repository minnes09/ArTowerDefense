using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayController : MonoBehaviour {

	
    public Button SpawnMage;
    public Button SpawnWarrior;

    public GameObject MagePrefab;
    public GameObject WarriorPrefab;
    //public GameObject CoinsManager;
    
    // Use this for initialization
    void Start()
    {

    }

    public void LinkUI(Player player)
    {
        SpawnMage.onClick.AddListener(() => player.SpawnMinion(MagePrefab.GetComponent<MageMinion>()));
        SpawnWarrior.onClick.AddListener(() => player.SpawnMinion(WarriorPrefab.GetComponent<WarriorMinion>()));
    }
}
