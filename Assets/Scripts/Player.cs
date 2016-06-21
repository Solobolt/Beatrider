using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player : MonoBehaviour {

    private RectTransform myTransform;

    public float moveSpeed = 10.0f;

    private float posLarge = 0.0f;
    private float posSmall = 0.0f;

    public float largeDist = 300.0f;
    public float smallDist = 50.0f;

	// Use this for initialization
	void Start () {
        myTransform = this.gameObject.GetComponent<RectTransform>();
	}
	
	// Update is called once per frame
	void Update () {
        Controll();
        MovePlayer();
	}

    //MOves the player
    void MovePlayer()
    {
        Vector3 tempPos = myTransform.localPosition;


        myTransform.localPosition = new Vector3(0, ((posLarge * largeDist) + (posSmall * smallDist)), 0 );
    }

    //Handles player inputs
    void Controll()
    {
        //Key down
        if(Input.GetKeyDown("q")|| Input.GetKeyDown("up"))
        {
            posLarge++;
        }

        if (Input.GetKeyDown("w") || Input.GetKeyDown("down"))
        {
            posLarge--;
        }


        if (Input.GetKeyDown("o") || Input.GetKeyDown("left"))
        {
            posSmall++;
        }

        if (Input.GetKeyDown("p") || Input.GetKeyDown("right"))
        {
            posSmall--;
        }

        //Key up
        if (Input.GetKeyUp("q") || Input.GetKeyUp("up"))
        {
            posLarge--;
        }

        if (Input.GetKeyUp("w") || Input.GetKeyUp("down"))
        {
            posLarge++;
        }


        if (Input.GetKeyUp("o") || Input.GetKeyUp("left"))
        {
            posSmall--;
        }

        if (Input.GetKeyUp("p") || Input.GetKeyUp("right"))
        {
            posSmall++;
        }
    }
}
