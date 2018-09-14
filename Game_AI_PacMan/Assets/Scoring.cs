using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Scoring : MonoBehaviour {
    private int currentScore;
    private int highScore;
    public GameObject plyaer;

	// Use this for initialization
	void Start () {
        highScore = int.Parse(System.IO.File.ReadAllText("Assets/HighScore.txt"));
        currentScore = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (currentScore > highScore)
        {
            highScore = currentScore;
            File.WriteAllText("Assets/HighScore.txt", highScore.ToString());
        }
        //if collide with pellet incriment score
	}

    public int getHighScore()
    {
        return highScore;
    }

    public int getCurrentScore()
    {
        return currentScore;
    }
}
