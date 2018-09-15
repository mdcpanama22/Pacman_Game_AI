using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text.RegularExpressions;
using System;

public class Game : MonoBehaviour {

    private bool STARTED;
    private GameObject systemG;
    private GameObject Lives;
    public GameObject GM;
    public GameObject LIVES;
    private GameObject Canvas;

    private GameObject _GM;
	// Use this for initialization
	void Start () {
        systemG = GameObject.Find("GameManager");
        STARTED = false;
        Canvas = GameObject.Find("Canvas");
        _GM = GameObject.Find("GameManager");

	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void SetStart()
    {
        STARTED = true;
       GM.SetActive(false);
      Lives =  GameObject.Instantiate(LIVES);
      Lives.transform.parent = Canvas.transform;


    }
    IEnumerator WAIT()
    {
        yield return new WaitForSeconds(10);
    }
    public void CheckHighScore(string HighScore)
    {
        string High = _GM.gameObject.GetComponent<Text_Handler>().HIGHSCORE.text;
        string[] mHigh = Regex.Split(High, "\n");

        string tempHigh = "";
        for(int i = 0; i < mHigh.Length; i++)
        {
            if (!mHigh[i].Contains("0"))
            {
                tempHigh += mHigh[i];
            }
        }
        int rHigh = 0;
        try
        {
            rHigh = System.Convert.ToInt32(tempHigh);
        }
        catch (FormatException)
        {

        }
        catch (OverflowException)
        {

        }
        tempHigh = "";
        string[] mCurrent = Regex.Split(HighScore, "\n");
        for (int i = 0; i < mCurrent.Length; i++)
        {
            if (!mCurrent[i].Contains("0"))
            {
                tempHigh += mCurrent[i];
            }
        }
        int rLow = 0;
        try
        {
            rLow = System.Convert.ToInt32(tempHigh);
        }
        catch (FormatException)
        {

        }
        catch (OverflowException)
        {

        }

        High = "";
        if(rLow > rHigh)
        {
            string tempScore = rLow.ToString();
            int zeros = 6 - tempScore.Length;
            string realScore = "";
            for (int i = 0; i < zeros; i++)
            {
                realScore += "0\n";
            }
            for (int i = 0; i < tempScore.Length; i++)
            {
                realScore += tempScore[i] + "\n";
            }
            File.WriteAllText("Assets/HighScore.txt", realScore);
        }

    }
    public void GAMEOVER(string HighScore)
    {
        GM.SetActive(true);
        STARTED = false;
        StartCoroutine(WAIT());
        CheckHighScore(HighScore);
        Application.LoadLevel(Application.loadedLevel);
    }
    public void RestartStart(GameObject that, string highScore, int score)
    {
        systemG.GetComponent<MazeCreator>().RespawnPacman(score);
        Destroy(that.gameObject);
        if (Lives.transform.childCount == 0)
        {
            GAMEOVER(highScore);
            Destroy(Lives);
        }
        else
        {
            Destroy(Lives.transform.GetChild(0).gameObject);
        }

    }

    public bool getStart()
    {
        return STARTED;
    }

}
