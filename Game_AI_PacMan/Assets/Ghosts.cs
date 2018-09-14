using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ghosts : MonoBehaviour {
    private Vector2 ghostPosition;
    public Sprite UP;
    public Sprite DOWN;
    public Sprite RIGHT;
    public Sprite LEFT;

    public GameObject systemG;
    //public Transform[] waypoints;
    int i = 0;
    //public float speed = 0.3f;

	// Use this for initialization
	void Start () {
        ghostPosition = transform.position;
        ghostPosition += new Vector2(0, .25f);
        systemG = GameObject.Find("EventSystem");
    }

    // Update is called once per frame
    void Update () {
        //ghostPosition = transform.position;
        Debug.Log("Update");
        Debug.Log(ghostPosition);
        Debug.Log(transform.position.x+" "+transform.position.y);
        if (systemG.gameObject.GetComponent<Game>().getStart())
        {
            if (ghostPosition != new Vector2(transform.position.x, transform.position.y))
            {
                float decision = Random.Range(0.0f, 1.0f);
                Debug.Log(decision);
                if (decision < 0.25)
                {
                    //use art asset for looking up
                    gameObject.GetComponent<SpriteRenderer>().sprite = UP;
                    ghostPosition += new Vector2(0, 1);
                }
                else if (decision >= 0.25 && decision < 0.5)
                {
                    //use art asset for looking right
                    gameObject.GetComponent<SpriteRenderer>().sprite = RIGHT;
                    ghostPosition += new Vector2(1, 0);
                }
                else if (decision >= 0.5 && decision < 0.75)
                {
                    //use art asset for looking down
                    gameObject.GetComponent<SpriteRenderer>().sprite = DOWN;
                    ghostPosition += new Vector2(0, -1);
                }
                else
                {
                    //use art asset for looking left
                    gameObject.GetComponent<SpriteRenderer>().sprite = LEFT;
                    ghostPosition += new Vector2(-1, 0);
                }
            }
            transform.position = Vector2.MoveTowards(transform.position, ghostPosition, Time.deltaTime);
            if (i == 0)
            {
                ghostPosition += new Vector2(0, -.25f);
                i = -1;
            }
        }
    }

    /*private void FixedUpdate()
    {
        //Move towards next goal
        if (transform.position != waypoints[i].position)
        {
            Vector2 pos=Vector2.MoveTowards(transform.position,waypoints[i].position,speed);
            GetComponent <Rigidbody2D>().MovePosition(pos);
        }
        //Randomly select next goal
    }*/
}
