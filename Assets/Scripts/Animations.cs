using UnityEngine;
using System.Collections;

public class Animations : MonoBehaviour {
    public Vector3 startSize = new Vector3(0, 0, 0);
    public Vector3 endSize = new Vector3(0, 0, 0);
    private bool isPlaying = false;

    private float amount = 0.2f;
    private GameObject AniThing;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (isPlaying == true)
        {
            Vector3 tempSize = AniThing.GetComponent<RectTransform>().rect.size;
            //Move to target size
            tempSize.x += (tempSize.x - endSize.x) * amount * Time.deltaTime;
            tempSize.y += (tempSize.y - endSize.y) * amount * Time.deltaTime;
            tempSize.z += (tempSize.z - endSize.z) * amount * Time.deltaTime;

            // AniThing.GetComponent<RectTransform>().rect. = tempSize;
            //End of loop
            isPlaying = false;
        }
        else
        {
            //if not the right size move to the right size

        }
	}

    //Handles code for squashing animation
    void PlaySquash(GameObject thing)
    {
        startSize = thing.GetComponent<RectTransform>().rect.size;
        AniThing = thing;
        isPlaying = true;
    }
}
