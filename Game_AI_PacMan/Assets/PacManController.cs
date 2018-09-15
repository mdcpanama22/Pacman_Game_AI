using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PacManController : MonoBehaviour {
	float speed;
	Vector3 newpos;
	Vector3 cast;
	//Vector3 curpos;
	//Vector3 target;
	Vector3 velocity;

    public Text score;
    public int _rScore;

    public GameObject YUMMY;
    private GameObject systemG;
    private GameObject Game_Score;
	// Use this for initialization
	void Start () {
		speed = 2f;
		newpos = new Vector3(0,0,0);
        systemG = GameObject.Find("EventSystem");
        Game_Score = GameObject.Find("Game_Score").transform.Find("Score").gameObject;


	}
	
	// Update is called once per frame
	void Update () {
        /*if (transform.position == target) {
			curpos = transform.position;
		}*/
        //MonoBehaviour.print (curpos);
        //MonoBehaviour.print (target);
        //MonoBehaviour.print (newpos);
        if (systemG.gameObject.GetComponent<Game>().getStart())
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                //newpos = new Vector3(0,.48f,0);
                cast = new Vector3(0, .241f, 0);
                if (Physics2D.Linecast(transform.position + cast, cast + transform.position + new Vector3(0, .01f, 0)).collider == GetComponent<Collider2D>())
                {
                    velocity = new Vector3(0, 0, 0);
                    //	MonoBehaviour.print ("4HEll");
                }
                else
                {
                    velocity = new Vector3(0, 3, 0);
                }
                transform.rotation = Quaternion.Euler(0, 0, 90);
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                //newpos = new Vector3(0,-.48f,0);
                cast = new Vector3(0, -.241f, 0);
                if (Physics2D.Linecast(transform.position + cast, cast + transform.position + new Vector3(0, -.01f, 0)).collider == GetComponent<Collider2D>())
                {
                    velocity = new Vector3(0, 0, 0);
                    //	MonoBehaviour.print ("3HEll");
                }
                else
                {
                    velocity = new Vector3(0, -3, 0);
                }
                transform.rotation = Quaternion.Euler(0, 0, 270);
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                //newpos = new Vector3(-.48f,0,0);
                cast = new Vector3(-.241f, 0, 0);
                if (Physics2D.Linecast(transform.position + cast, cast + transform.position + new Vector3(-.01f, 0, 0)).collider == GetComponent<Collider2D>())
                {
                    velocity = new Vector3(0, 0, 0);
                    //	MonoBehaviour.print ("2HEll");
                }
                else
                {
                    velocity = new Vector3(-3, 0, 0);
                }
                transform.rotation = Quaternion.Euler(0, 0, 180);
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                //newpos = new Vector3(.48f, 0,0);
                cast = new Vector3(.241f, 0, 0);
                if (Physics2D.Linecast(transform.position + cast, cast + transform.position + new Vector3(.01f, 0, 0)).collider == GetComponent<Collider2D>())
                {
                    velocity = new Vector3(0, 0, 0);
                    //	MonoBehaviour.print ("1HEll");
                }
                else
                {
                    velocity = new Vector3(3, 0, 0);
                }
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            transform.position = transform.position + (velocity * Time.deltaTime);
            RaycastHit2D hit = Physics2D.Linecast(transform.position, cast + transform.position);
            if (hit.collider == GetComponent<Collider2D>() && hit.collider.gameObject.tag == "wall")
            {
                //MonoBehaviour.print ("HEll");
                velocity = new Vector3(0, 0, 0);
            }
            //MonoBehaviour.print (velocity);
        }
	}
    void setScore()
    {
        string tempScore = _rScore.ToString();
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
        Game_Score.GetComponent<Text>().text = realScore;
    }
	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "Pellet") {

            _rScore++;
            setScore();
            Destroy(col.gameObject);
		}
        if(col.gameObject.tag == "Enemy")
        {
            systemG.GetComponent<Game>().RestartStart(this.gameObject, Game_Score.GetComponent<Text>().text, _rScore);
        }
	}

		//	velocity = new Vector3(0,0);
}
