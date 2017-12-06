using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour {

    private bool paused = false;

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
        if (Paused)
        {
            Paused = false;
            Debug.Log("game Unpaused");
        }
    }
}
