using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text.RegularExpressions;

public class Text_Handler : MonoBehaviour {
    public TextAsset MAZE;
    public TextAsset HIGHSCORE;
    // Use this for initialization
    void Start() {
    } 

    // Update is called once per frame
    void Update() {

    }

    static void WriteString()
    {

    }

    public List<string[]> ReadString()
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


        return Maze;
    }
}
