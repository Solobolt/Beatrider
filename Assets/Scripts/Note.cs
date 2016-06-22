using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Note : MonoBehaviour {

    private RectTransform myTransform;
    private AudioManager audioManager;

    public note myNote = note.none;
    public float speed = 50.0f;

	// Use this for initialization
	void Start () {
        myTransform = this.gameObject.GetComponent<RectTransform>();
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 tempPos = myTransform.localPosition;
        tempPos.y -= speed * Time.deltaTime;
        myTransform.localPosition = tempPos;
	}

    void OnCollisionEnter2D()
    {
        audioManager.PlayNote(myNote);
        Destroy(this.gameObject);
    }
}
