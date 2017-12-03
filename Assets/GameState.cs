using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour {

    private bool paused = true;

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


    protected GameState()    {}

    public static GameState Instance()
    {
        if(gameState == null)
        {
            gameState = new GameState();
        }
        return gameState;
    }
    public void Pause()
    {
        if (!Paused)
        {
            Paused = true;
        }
    }

    public void UnPause()
    {
        if (Paused)
        {
            Paused = false;
        }
    }
}
