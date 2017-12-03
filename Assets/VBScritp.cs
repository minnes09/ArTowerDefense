using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class VBScritp : MonoBehaviour, IVirtualButtonEventHandler {

    public GameObject vButtonObject;
    public ParticleSystem mana;
    ParticleSystem myMana;


    // Use this for initialization
    void Start () {
        vButtonObject = GameObject.Find("VirtualButton");
        vButtonObject.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
        myMana = GetComponentInChildren<ParticleSystem>();
        
	}
    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        Debug.Log("Button down");
        ToggleMana();
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        Debug.Log("Button up");
        ToggleMana();
    }
    public void ToggleMana()
    {
        if (myMana.isPlaying) myMana.Stop();
        else myMana.Play();
    }
}
