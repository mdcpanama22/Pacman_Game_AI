using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghosts : MonoBehaviour {
    private Vector2 ghostPosition;

	// Use this for initialization
	void Start () {
        ghostPosition = transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        //ghostPosition = transform.position;
        /*Debug.Log("Update");
        Debug.Log(ghostPosition);
        Debug.Log(transform.position.x+" "+transform.position.y);
        if (ghostPosition==new Vector2(transform.position.x,transform.position.y))
        {
            float decision = Random.Range(0.0f, 1.0f);
            Debug.Log(decision);
            if (decision < 0.25)
            {
                //use art asset for looking up
                ghostPosition += new Vector2(0, 1);
            }
            else if (decision >= 0.25 && decision < 0.5)
            {
                //use art asset for looking right
                ghostPosition += new Vector2(1, 0);
            }
            else if (decision >= 0.5 && decision < 0.75)
            {
                //use art asset for looking down
                ghostPosition += new Vector2(0, -1);
            }
            else
            {
                //use art asset for looking left
                ghostPosition += new Vector2(-1, 0);
            }
        }    
        transform.position = Vector2.MoveTowards(transform.position, ghostPosition, Time.deltaTime);*/
        Vector2 pos = transform.position;
        Debug.Log("Above");
        Debug.Log(Physics2D.Linecast(pos, pos - new Vector2(transform.position.x, transform.position.y + 0.3f)));
        Debug.Log("Below");
        Debug.Log(Physics2D.Linecast(pos, pos - new Vector2(transform.position.x, transform.position.y - 0.3f)));
        float decision = Random.Range(0.0f, 1.0f);
        if (decision < 0.25)
        {
            //use art asset for looking up
            /*
            if()
            {

            }*/
            ghostPosition += new Vector2(0, 1);
        }
        else if (decision >= 0.25 && decision < 0.5)
        {
            //use art asset for looking right
            ghostPosition += new Vector2(1, 0);
        }
        else if (decision >= 0.5 && decision < 0.75)
        {
            //use art asset for looking down
            ghostPosition += new Vector2(0, -1);
        }
        else
        {
            //use art asset for looking left
            ghostPosition += new Vector2(-1, 0);
        }
    }
}
