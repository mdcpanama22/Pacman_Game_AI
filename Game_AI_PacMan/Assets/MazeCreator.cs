using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MazeCreator : MonoBehaviour {

    public GameObject Corner;
    public GameObject Vertical;
    public GameObject Horizontal;
    public GameObject Empty;
    public GameObject Pellet;
    public GameObject SuperPellet;

    public GameObject Blinky;
    public GameObject Inky;
    public GameObject Pinky;
    public GameObject Clyde;

    private float startingX;
    private float startingY;

    private float X;
    private float TOLERANCE;

    private GameObject tmpObj;

    public GameObject MAZE;
	// Use this for initialization
	void Start () {
        //SETUP
        List<string[]> Maze = gameObject.GetComponent<Text_Handler>().ReadString();

        startingX = -7.00f;
        startingY = 8.50f;

        X = startingX;

        TOLERANCE = 0.48f;

        SetupBoard(Maze);

        /*
        GameObject tmpSpriteObj = GameObject.Instantiate(Corner, new Vector3(startingX, startingY, 0), Quaternion.identity);

        startingY -= TOLERANCE;
        tmpSpriteObj = GameObject.Instantiate(Vertical, new Vector3(startingX, startingY, 0), Quaternion.identity);
        */
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    //FOR NOW IT WILL ONLY DEAL WITH A BASIC BORDER
    public void SetupBoard(List<string[]> Maze)
    {
        GameObject temp;
        Debug.Log(Maze.Count);
        for(int i = 0; i < Maze.Count; i++)
        {
            for(int j = 0; j < Maze[i].Length; j++)
            {
                if(Maze[i][j].Contains("w"))
                {
                    //Check corners

                    //Right + Under this is the default layout of the corner piece
                    //if j == Maze[i].Length -1, means it's at the end of the row
                    //if i == Maze.Count -1, that means it's at the lowest row
                    if (j + 1 != Maze[i].Length && i + 1 != Maze.Count)
                    {
                        if (Maze[i][j + 1].Contains("w") && Maze[i + 1][j].Contains("w"))
                        {
                            //Corner.GetComponent<SpriteRenderer>().flipX = false;
                            //Corner.GetComponent<SpriteRenderer>().flipY = false;
                           temp = GameObject.Instantiate(Corner, new Vector3(X, startingY, 0), Quaternion.Euler(0, 0, 180));
                            temp.transform.parent = MAZE.transform;
                        }
                        
                    }
                    if (j - 1 != -1 && i - 1 != -1)
                    {
                        if (Maze[i][j - 1].Contains("w") && Maze[i - 1][j].Contains("w"))
                        {
                            
                            //Corner.GetComponent<SpriteRenderer>().flipX = true;
                            //Corner.GetComponent<SpriteRenderer>().flipY = true;
                            temp = GameObject.Instantiate(Corner, new Vector3(X, startingY, 0), Quaternion.Euler(0, 0, 0));
                            temp.transform.parent = MAZE.transform;
                        }
                    }
                    if (j + 1 != Maze[i].Length && i - 1 != -1)
                    {
                         if(Maze[i][j+1].Contains("w") && Maze[i - 1][j].Contains("w"))
                        {
                            //Corner.GetComponent<SpriteRenderer>().flipX = false;
                            //Corner.GetComponent<SpriteRenderer>().flipY = true;
                            temp = GameObject.Instantiate(Corner, new Vector3(X, startingY, 0), Quaternion.Euler(0, 0, -90));
                            temp.transform.parent = MAZE.transform;
                        }
                    }
                    if ( j - 1 != -1 && i + 1 != Maze.Count)
                    {
                        if(Maze[i][j-1].Contains("w") && Maze[i + 1][j].Contains("w"))
                        {
                            //Corner.GetComponent<SpriteRenderer>().flipX = true;
                            //Corner.GetComponent<SpriteRenderer>().flipY = false;
                            temp = GameObject.Instantiate(Corner, new Vector3(X, startingY, 0), Quaternion.Euler(0, 0, 90));
                            temp.transform.parent = MAZE.transform;
                        }
                    }

                    //HORIZONTAL AND VERTICAL

                    if(j - 1 != -1 && j + 1 != Maze[i].Length)
                    {
                        if(Maze[i][j-1].Contains("w") && Maze[i][j + 1].Contains("w"))
                        {
                            temp = GameObject.Instantiate(Horizontal, new Vector3(X, startingY, 0), Quaternion.identity);
                            temp.transform.parent = MAZE.transform;
                        }
                    }
                    if (i - 1 != -1 && i + 1 != Maze.Count)
                    {
                        if (Maze[i-1][j].Contains("w") && Maze[i+1][j].Contains("w"))
                        {
                           temp =  GameObject.Instantiate(Vertical, new Vector3(X, startingY, 0), Quaternion.identity);
                            temp.transform.parent = MAZE.transform;
                        }
                    }
                }
                else if (Maze[i][j].Contains("B"))
                {
                    GameObject.Instantiate(Empty, new Vector3(X, startingY, 0), Quaternion.identity);
                }
                else if (Maze[i][j].Contains("p"))
                {
                    GameObject.Instantiate(Pellet, new Vector3(X, startingY, 0), Quaternion.identity);
                }
                else if (Maze[i][j].Contains("Q"))
                {
                    GameObject.Instantiate(SuperPellet, new Vector3(X, startingY, 0), Quaternion.identity);
                }else if (Maze[i][j].Contains("b"))
                {
                    GameObject.Instantiate(Blinky, new Vector3(X, startingY, 0), Quaternion.identity);
                }
                else if (Maze[i][j].Contains("I"))
                {
                    GameObject.Instantiate(Inky, new Vector3(X, startingY, 0), Quaternion.identity);
                }
                else if (Maze[i][j].Contains("P"))
                {
                    GameObject.Instantiate(Pinky, new Vector3(X, startingY, 0), Quaternion.identity);
                }
                else if (Maze[i][j].Contains("C"))
                {
                    GameObject.Instantiate(Clyde, new Vector3(X, startingY, 0), Quaternion.identity);
                }
                else
                {
                    //BlackBox
                   // GameObject.Instantiate(Empty, new Vector3(X, startingY, 0), Quaternion.identity);
                }

                X += TOLERANCE;
            }
            startingY -= TOLERANCE;
            X = startingX;
        }
    }

}
