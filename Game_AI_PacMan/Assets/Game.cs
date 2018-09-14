using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {

    private bool STARTED;
	// Use this for initialization
	void Start () {
        STARTED = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void SetStart()
    {
        STARTED = true;
    }
    public void RestartStart()
    {
        STARTED = false;
    }

    public bool getStart()
    {
        return STARTED;
    }
}
