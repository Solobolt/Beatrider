using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {

    public AudioClip noteA;
    public AudioClip noteB;
    public AudioClip noteC;
    public AudioClip noteD;
    public AudioClip noteE;
    public AudioClip noteF;
    public AudioClip noteG;

    private AudioSource audioSource;

    // Use this for initialization
    void Start () {
        audioSource = this.gameObject.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //Plays specified note
    public void PlayNote(note noteToBePlayed)
    {
        switch(noteToBePlayed)
        {
            case note.A:
                audioSource.PlayOneShot(noteA);
                break;

            case note.B:
                audioSource.PlayOneShot(noteB);
                break;

            case note.C:
                audioSource.PlayOneShot(noteC);
                break;

            case note.D:
                audioSource.PlayOneShot(noteD);
                break;

            case note.E:
                audioSource.PlayOneShot(noteE);
                break;

            case note.F:
                audioSource.PlayOneShot(noteF);
                break;

            case note.G:
                audioSource.PlayOneShot(noteG);
                break;

            default:
                break;
        }
    }
}
