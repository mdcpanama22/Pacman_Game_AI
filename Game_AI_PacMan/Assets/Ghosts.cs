using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Ghosts : MonoBehaviour
{
    private Vector2 ghostPosition;
    private Vector3 ghostfacing;

    public float distance;

    public Sprite UP;
    public Sprite DOWN;
    public Sprite RIGHT;
    public Sprite LEFT;

    public GameObject systemG;

    private int layer_mask_wall;
    private Ray ray;
    private RaycastHit hit;

    //public Transform[] waypoints;
    int i = 0;
    //public float speed = 0.3f;

    // Use this for initialization
    void Start()
    {
        ghostPosition = transform.position;
        ghostPosition += new Vector2(0, .25f);
        systemG = GameObject.Find("EventSystem");
        layer_mask_wall = LayerMask.GetMask("wall");
    }
    // Update is called once per frame
    void Update()
    {
        //ghostPosition = transform.position;
        //   Debug.Log("Update");
        //   Debug.Log(ghostPosition);
        //   Debug.Log(transform.position.x+" "+transform.position.y);
        if (systemG.gameObject.GetComponent<Game>().getStart())
        {


            transform.position = Vector2.MoveTowards(transform.position, ghostPosition, Time.deltaTime);
            if (gameObject.GetComponent<SpriteRenderer>().sprite == UP)
                ghostPosition += new Vector2(0, 1);
            else if (gameObject.GetComponent<SpriteRenderer>().sprite == RIGHT)
                ghostPosition += new Vector2(1, 0);
            else if (gameObject.GetComponent<SpriteRenderer>().sprite == DOWN)
                ghostPosition += new Vector2(0, -1);
            else if (gameObject.GetComponent<SpriteRenderer>().sprite == LEFT)
                ghostPosition += new Vector2(-1, 0);
           /* RaycastHit2D hit = Physics2D.Raycast(transform.position, ghostfacing, distance, layer_mask_wall);
                if(hit.collider != null)
                    ChooseDirection();
             */     
            if (i == 0)
            {
                ghostPosition += new Vector2(0, -.25f);
                i = -1;
            }
        }
    }
    IEnumerator ChooseDirection()
    {
            System.Random rand = new System.Random();
            Sprite tempSprite = gameObject.GetComponent<SpriteRenderer>().sprite;

            while (tempSprite == gameObject.GetComponent<SpriteRenderer>().sprite)
            {
                double decision = rand.NextDouble() * 1;
                //Debug.Log(decision);
                if (decision < 0.25f)
                {
                    //use art asset for looking up
                    gameObject.GetComponent<SpriteRenderer>().sprite = UP;
                   // ghostfacing = transform.up;
                    ghostPosition += new Vector2(0, 1);
                }
                else if (decision >= 0.25f && decision < 0.5f)
                {
                    //use art asset for looking right
                    gameObject.GetComponent<SpriteRenderer>().sprite = RIGHT;
                  //  ghostfacing = transform.right;
                    ghostPosition += new Vector2(1, 0);
                }
                else if (decision >= 0.5f && decision < 0.75f)
                {
                    //use art asset for looking down
                    gameObject.GetComponent<SpriteRenderer>().sprite = DOWN;
                   // ghostfacing = Vector2.down;
                    ghostPosition += new Vector2(0, -1);
                }
                else
                {
                    //use art asset for looking left
                    gameObject.GetComponent<SpriteRenderer>().sprite = LEFT;
                  //  ghostfacing = Vector2.left;
                    ghostPosition += new Vector2(-1, 0);
                }
            }
        yield return null;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
            ghostPosition *= -1;
        else if (collision.gameObject.tag == "Wall")
        {
            ghostPosition *= -1;
            StartCoroutine(ChooseDirection());
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

/*using System.Collections;
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
}*/
