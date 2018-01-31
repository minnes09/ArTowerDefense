using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameState : MonoBehaviour {

    private bool paused = false;
    private bool isEnd = false;

    public bool Paused
    {
        get
        {
            return paused;
        }

        set
        {
            paused = value;
        }
    }

    //Singleton
    private static GameState gameState = null;


    protected void Awake()
    {
        if (gameState == null)
            gameState = this;
    }

    public static GameState Instance()
    {
        if(gameState == null)
        {
            Debug.Log("GameState is null");
            gameState = GameObject.FindObjectOfType<GameState>();
            if (gameState == null)
            {
                GameObject container = new GameObject("GameState");
                container.AddComponent<GameState>();
            }
                Debug.LogError("Singleton GameState instance has been not found.");
        }
        return gameState;
    }
    public void Pause()
    {
        if (!Paused)
        {
            Paused = true;
            Debug.Log("game paused");
        }
    }

    public void UnPause()
    {
        if (Paused && !isEnd)
        {
            Paused = false;
            Debug.Log("game Unpaused");
        }
    }

    public void SwitchState()
    {
        if (Paused) UnPause();
        else Pause();
    }

    public void End(string name)
    {
        Pause();
        this.isEnd = true;
        GameObject gameEnd = GameObject.Find("GameEnd");
        Text text = GameObject.Find("GameEnd").GetComponent<Text>();
        string winner;
        if (name == "Enemy")
        {
            winner = "Player";
        }
        else if (name == "Player")
        {
            winner = "Enemy";
        }
        else throw new System.Exception("The name of the looser is wrong");
        text.text = "GAME END: " + winner + " wins";
        gameEnd.SetActive(true);
        gameEnd.GetComponentInParent<Image>().enabled = true;
        Debug.Log("GAME END: " + name + " LOSE");
    }
}
