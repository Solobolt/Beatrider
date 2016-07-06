using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Tutorial : MonoBehaviour {

    public GameObject leftBtn;
    public GameObject rightBtn;
    public Image backGround;
    public GameObject gameControllerObject;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	

        //make player hit tutorial notes in each lane first, then play the game
        if (Input.GetKeyDown(KeyCode.LeftArrow)) { leftBtn.SetActive(false); }
        if (Input.GetKeyDown(KeyCode.RightArrow)) { rightBtn.SetActive(false); }



        if (leftBtn.gameObject.activeInHierarchy == false && rightBtn.gameObject.activeInHierarchy == false)
        {
            gameControllerObject.GetComponent<GameController>().canPlay = true;
            this.gameObject.SetActive(false);
        }

	}
}
