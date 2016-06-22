using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player : MonoBehaviour {

    private RectTransform myTransform;

    public float moveSpeed = 0.5f;

    private Vector3 targetPos = new Vector3(0, 0, 0);
    private Vector3 lastTarget = new Vector3(0, 0, 0);
    private float distnace;
    private float moveTime = 0.1f;
    private float direction = 1f;

    private Vector3 posL3 = new Vector3(-250, 0, 0);
    private Vector3 posL2 = new Vector3(-200, 0, 0);
    private Vector3 posL1 = new Vector3(-150, 0, 0);
    private Vector3 posL = new Vector3(-50, 0, 0);
    private Vector3 pos0 = new Vector3(0, 0, 0);
    private Vector3 posR = new Vector3(50, 0, 0);
    private Vector3 posR1 = new Vector3(150, 0, 0);
    private Vector3 posR2 = new Vector3(200, 0, 0);
    private Vector3 posR3 = new Vector3(250, 0, 0);

	// Use this for initialization
	void Start () {
        myTransform = this.gameObject.GetComponent<RectTransform>();
	}
	
	// Update is called once per frame
	void Update () {
        Controls();
        MovePlayer();
	}


    //Handles Piano Style Controls
    void Controls()
    {
        if(Input.GetKeyDown("a"))
        {
            targetPos = posL3;
        }

        if (Input.GetKeyDown("s"))
        {
            targetPos = posL2;
        }

        if (Input.GetKeyDown("d"))
        {
            targetPos = posL1;
        }

        if (Input.GetKeyDown("f"))
        {
            targetPos = posL;
        }

        if (Input.GetKeyDown("g"))
        {
            targetPos = pos0;
        }

        if (Input.GetKeyDown("h"))
        {
            targetPos = posR;
        }

        if (Input.GetKeyDown("j"))
        {
            targetPos = posR1;
        }

        if (Input.GetKeyDown("k"))
        {
            targetPos = posR2;
        }

        if (Input.GetKeyDown("l"))
        {
            targetPos = posR3;
        }
    }

    //moves the player to the desired loaction
    void MovePlayer()
    {
        //Grabs current Position
        Vector3 tempPos = myTransform.localPosition;

        if(targetPos != lastTarget)
        {
            Vector3 holdPos = tempPos;

            distnace = Vector3.Distance(targetPos,holdPos);
            if(targetPos.x > tempPos.x)
            {
                direction = 1;
            }
            else
            {
                direction = -1;
            }

            lastTarget = targetPos;
        }

        float step = (distnace / moveTime) * direction;

        tempPos.x += (step * Time.deltaTime);

        if(direction == 1 && tempPos.x > targetPos.x)
        {
            tempPos = targetPos;
        }

        if (direction == (-1) && tempPos.x < targetPos.x)
        {
            tempPos = targetPos;
        }

        myTransform.localPosition = tempPos;
        
    }
}
