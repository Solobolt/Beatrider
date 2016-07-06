using UnityEngine;
using System.Collections;

public class DeathBox : MonoBehaviour {

    //if greater than X player loses
    public int playerLossCondition;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


        if (playerLossCondition >= 10)
        {
            Application.Quit();
        }
	}

    void OnCollisionEnter2D (Collision2D other)
    {
        Debug.Log("hit a thing named:" + other.gameObject.name);
        playerLossCondition += 1;
    }
}
