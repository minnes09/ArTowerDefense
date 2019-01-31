using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventTriggeredTextDelegate : MonoBehaviour {

    public Text text;
	
    // Use this for initialization
	void Start () {
        CoinsManager.OnCoinChanged += UpdateCoinsValue;
    }
	
    public void LinkCoinsTest(CoinsManager cMan)
    {
        int coins = FindObjectOfType<CoinsManager>().Coins;
        text.text = "Coins: " + coins.ToString();
    }
	void UpdateCoinsValue (int coins) {
        text.text = "Coins: " + coins.ToString();
	}

    private void OnDestroy()
    {
        CoinsManager.OnCoinChanged -= UpdateCoinsValue;
    }
}
