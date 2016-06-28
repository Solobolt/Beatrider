using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {

    public AudioClip noteA;
    public AudioClip noteAsharp;
    public AudioClip noteB;
    public AudioClip noteC;
    public AudioClip noteCsharp;
    public AudioClip noteD;
    public AudioClip noteDsharp;
    public AudioClip noteE;
    public AudioClip noteF;
    public AudioClip noteFsharp;
    public AudioClip noteG;
    public AudioClip noteGsharp;

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

            case note.aSharp:
                audioSource.PlayOneShot(noteAsharp);
                break;

            case note.B:
                audioSource.PlayOneShot(noteB);
                break;

            case note.C:
                audioSource.PlayOneShot(noteC);
                break;

            case note.cSharp:
                audioSource.PlayOneShot(noteCsharp);
                break;

            case note.D:
                audioSource.PlayOneShot(noteD);
                break;

            case note.dSharp:
                audioSource.PlayOneShot(noteDsharp);
                break;

            case note.E:
                audioSource.PlayOneShot(noteE);
                break;

            case note.F:
                audioSource.PlayOneShot(noteF);
                break;

            case note.fSharp:
                audioSource.PlayOneShot(noteFsharp);
                break;

            case note.G:
                audioSource.PlayOneShot(noteG);
                break;

            case note.gSharp:
                audioSource.PlayOneShot(noteGsharp);
                break;

            default:
                break;
        }
    }
}
