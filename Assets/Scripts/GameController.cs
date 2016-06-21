using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public enum note
{
    none,A,B,C,D,E,F,G
}

public class GameController : MonoBehaviour {

    public Transform[] SpawnLocation;

    public note[] song;

    public GameObject notes;
    public GameObject canvas;
    private int songCount = 0;
    public bool oneLine = false;

    [Range (10,1000)]
    public float tempo = 180.0f;
    private float timer = 0.0f;
	// Use this for initialization
	void Start () {

	}

    //Restart song if the cord count stops
    void CheckSongCount()
    {
        if (songCount > song.Length -1)
        {
            songCount = 0;
        }
    }

    //Plays the entire song
    void playSong()
    {

        if (tempo < 1800.0f)
        {
            float tempoConv = 1.0f / (tempo / 60.0f * 4.0f);

            if (timer >= tempoConv)
            {
                timer = 0;

                if (song[songCount] != note.none)
                {
                    GameObject _Note = Instantiate(notes) as GameObject;
                    _Note.transform.SetParent(canvas.transform, false);
                    _Note.GetComponent<Note>().myNote = song[songCount];
                    if (oneLine == false)
                    {
                        MoveNote(_Note);
                    }
                    Destroy(_Note, 6);
                }
                songCount++;
            }
            timer += Time.deltaTime;
        }
    }

	// Update is called once per frame
	void Update () {
        playSong();
        CheckSongCount();
	}

    //Sends the not to its starting Location
    void MoveNote(GameObject noteToMove)
    {
        switch(song[songCount])
        {
            case note.A:
                noteToMove.transform.position = SpawnLocation[0].transform.position;
                break;

            case note.B:
                noteToMove.transform.position = SpawnLocation[1].transform.position;
                break;

            case note.C:
                noteToMove.transform.position = SpawnLocation[2].transform.position;
                break;

            case note.D:
                noteToMove.transform.position = SpawnLocation[3].transform.position;
                break;

            case note.E:
                noteToMove.transform.position = SpawnLocation[4].transform.position;
                break;

            case note.F:
                noteToMove.transform.position = SpawnLocation[5].transform.position;
                break;

            case note.G:
                noteToMove.transform.position = SpawnLocation[6].transform.position;
                break;

            default:
                break;
        }
    }
}
