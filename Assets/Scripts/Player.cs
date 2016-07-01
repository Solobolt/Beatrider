using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public enum Control
{
    LeftRight,
    LaneShift
}

public class Player : MonoBehaviour {

    public ParticleSystem particals;

    private RectTransform myTransform;

    public float moveSpeed = 0.25f;
    public Control controlType = Control.LeftRight;

    private Vector3 targetPos = new Vector3(0, 0, 0);
    private Vector3 lastTarget = new Vector3(0, 0, 0);
    private float distnace;
    private float moveTime = 0.1f;
    private float direction = 1f;

    #region LocationValues
    private Vector3 pos1;
    private Vector3 pos2;
    private Vector3 pos3;
    #endregion

    #region LeftRightValues
    private Vector3[] LRarray = new Vector3[3];
    private int LRPos = 1;
    #endregion

    // Use this for initialization
    void Start () {
        myTransform = this.gameObject.GetComponent<RectTransform>();

        pos1 = new Vector3(-200, 0, myTransform.position.z);
        pos2 = new Vector3(0, 0, myTransform.position.z);
        pos3 = new Vector3(200, 0, myTransform.position.z);

        LRarray[0] = pos1;
        LRarray[1] = pos2;
        LRarray[2] = pos3;
	}
	
	// Update is called once per frame
	void Update () {
        switch(controlType)
        {

            case Control.LeftRight:
                LeftRightControls();
                MovePlayer();
                break;

            default:
                LeftRightControls();
                MovePlayer();
                break;
        }
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        FireParticals();
    }

    //Handles LeftRight Controls
    void LeftRightControls()
    {

        if (Input.GetKeyDown("left"))
        {
            LRPos --;
        }

        if (Input.GetKeyDown("right"))
        {
            LRPos ++;
        }

        if (LRPos >= (LRarray.Length))
        {
            LRPos -= LRarray.Length;
        }

        if(LRPos < 0)
        {
            LRPos += LRarray.Length;
        }

        targetPos = LRarray[LRPos];
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
            tempPos.x = targetPos.x;
        }

        if (direction == (-1) && tempPos.x < targetPos.x)
        {
            tempPos.x = targetPos.x;
        }

        myTransform.localPosition = tempPos;
        
    }

    //fires off partical system
    void FireParticals()
    {
        particals.Play();
    }
}
