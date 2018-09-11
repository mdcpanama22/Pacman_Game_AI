using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text.RegularExpressions;

public class Text_Handler : MonoBehaviour {
    public TextAsset MAZE;
    // Use this for initialization
    void Start() {
        ReadString();
    } 

    // Update is called once per frame
    void Update() {

    }

    static void WriteString()
    {

    }

    public void ReadString()
    {
        string maze = MAZE.text;
        string[] mLines = Regex.Split(maze, "\n");

        List<string[]> Maze = new List<string[]>();

        for(int i = 0; i < mLines.Length; i++)
        {
            string line = mLines[i];
            string[] character = Regex.Split(line, " ");

            Maze.Add(character);
        }

        string LINE = "";
        for(int i = 0; i < Maze.Count; i++)
        {
            foreach(string x in Maze[i])
            {
                LINE += x;
            }
            Debug.Log(LINE + "\n");
            LINE = "";

        }
    }
}
