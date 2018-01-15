using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnableMinionEventTrigger : MonoBehaviour {
    public int moneyToSpawn;
    Button button;
	// Use this for initialization
	void Start () {
        button = GetComponent<Button>();
        CoinsManager.OnCoinChanged += ButtonInteractability;
    }

    private void ButtonInteractability(int coins)
    {
        if (coins >= moneyToSpawn)
        {
            button.interactable = true;
        }
        else button.interactable = false;
    }


    // Update is called once per frame
    void Update () {
		
	}
}
