using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public enum note
{
    none,
    A,
    aSharp,
    B,
    C,
    cSharp,
    D,
    dSharp,
    E,
    F,
    fSharp,
    G,
    gSharp,
    end
}

public enum NumLines
{
    Lines7,
    Lines3
}

public class GameController : SingletonBehaviour<GameController> {

    public Transform[] SpawnLocation;

    public List<note> songNotes = new List<note>();
    public bool hasSong = false;

    public NumLines numLines = NumLines.Lines3;

    public GameObject notes;
    public GameObject canvas;
    private int songCount = 0;
    public bool oneLine = false;

    [Range (10,1000)]
    public float tempo = 180.0f;
    private float timer = 0.0f;

    TextAsset song;

    //Also delete this line when you have a script on a song selection screen, again, this was just for testing the 1 song.
    public TextAsset maryHadALittleLamb;

	void Start () {
        //AFTER YOU HAVE CHOSEN A SONG IN THE 'SONG SELECTION SCENE', YOU WILL CALL:
        //song = whateverTheChosenSongWasFromTheSongSelectionMenu //make sure the songs are TextAssets so it matches the 'song' variable
        //ReadLevel.Instance.LoadInCSV(song);

        //Delete below when you ahve more tahn one CSV song, this was just for testing the 1.
        song = maryHadALittleLamb;
        ReadLevel.Instance.LoadInCSV(maryHadALittleLamb);
	}

    //Restart song if the cord count stops
    void CheckSongCount()
    {
        if (songCount > songNotes.Count -1)
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

                if (songNotes[songCount] != note.none)
                {
                    GameObject _Note = Instantiate(notes) as GameObject;
                    _Note.transform.SetParent(canvas.transform, false);
                    _Note.GetComponent<Note>().myNote = songNotes[songCount];
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
	void Update() {
        if(hasSong) {
            playSong();
            CheckSongCount();
        }
	}

    //Moves the notes between 7 different lines
    void Moves7Lines(GameObject noteToMove)
    {
        switch (songNotes[songCount])
        {
            case note.A:
                noteToMove.transform.position = SpawnLocation[0].transform.position;
                break;

            case note.aSharp:
                noteToMove.transform.position = SpawnLocation[0].transform.position;
                break;

            case note.B:
                noteToMove.transform.position = SpawnLocation[1].transform.position;
                break;

            case note.C:
                noteToMove.transform.position = SpawnLocation[2].transform.position;
                break;

            case note.cSharp:
                noteToMove.transform.position = SpawnLocation[2].transform.position;
                break;

            case note.D:
                noteToMove.transform.position = SpawnLocation[3].transform.position;
                break;

            case note.dSharp:
                noteToMove.transform.position = SpawnLocation[3].transform.position;
                break;

            case note.E:
                noteToMove.transform.position = SpawnLocation[4].transform.position;
                break;

            case note.F:
                noteToMove.transform.position = SpawnLocation[5].transform.position;
                break;

            case note.fSharp:
                noteToMove.transform.position = SpawnLocation[5].transform.position;
                break;

            case note.G:
                noteToMove.transform.position = SpawnLocation[6].transform.position;
                break;

            case note.gSharp:
                noteToMove.transform.position = SpawnLocation[6].transform.position;
                break;

            default:
                break;
        }
    }

    //Moves the notes between 3 different lines
    void Moves3Lines(GameObject noteToMove)
    {
        switch (songNotes[songCount])
        {
            case note.A:
                noteToMove.transform.position = SpawnLocation[0].transform.position;
                break;

            case note.aSharp:
                noteToMove.transform.position = SpawnLocation[0].transform.position;
                break;

            case note.B:
                noteToMove.transform.position = SpawnLocation[0].transform.position;
                break;

            case note.C:
                noteToMove.transform.position = SpawnLocation[0].transform.position;
                break;

            case note.cSharp:
                noteToMove.transform.position = SpawnLocation[3].transform.position;
                break;

            case note.D:
                noteToMove.transform.position = SpawnLocation[3].transform.position;
                break;

            case note.dSharp:
                noteToMove.transform.position = SpawnLocation[3].transform.position;
                break;

            case note.E:
                noteToMove.transform.position = SpawnLocation[3].transform.position;
                break;

            case note.F:
                noteToMove.transform.position = SpawnLocation[6].transform.position;
                break;

            case note.fSharp:
                noteToMove.transform.position = SpawnLocation[6].transform.position;
                break;

            case note.G:
                noteToMove.transform.position = SpawnLocation[6].transform.position;
                break;

            case note.gSharp:
                noteToMove.transform.position = SpawnLocation[6].transform.position;
                break;

            default:
                break;
        }
    }

    //Sends the not to its starting Location
    void MoveNote(GameObject noteToMove)
    {
        switch(numLines)
        {
            case NumLines.Lines3:
                Moves3Lines(noteToMove);
                break;

            default:
                Moves7Lines(noteToMove);
                break;
        }
    }
}
