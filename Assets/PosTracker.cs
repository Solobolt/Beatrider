using UnityEngine;
using System.Collections;

public class PosTracker : MonoBehaviour {

	public Transform otherPos;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position = otherPos.position;
	}
}
