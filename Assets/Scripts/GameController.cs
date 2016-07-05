using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
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
    private int noteCount = 0;
    public bool oneLine = false;

    [Range (10,1000)]
    public float tempo = 180.0f;
    private float timer = 0.0f;

    private float sceneChangeDelay = 3.0f;
    private float sceneChangeTimer = 0f;
    private bool isSceneChanging = false;

    TextAsset song;

    //Also delete this line when you have a script on a song selection screen, again, this was just for testing the 1 song.
    public TextAsset maryHadALittleLamb;
    public TextAsset[] songSheets;
    private int sheetNum = 0;
    public BackgroundColor bcColor;
    
	void Start () {
        //AFTER YOU HAVE CHOSEN A SONG IN THE 'SONG SELECTION SCENE', YOU WILL CALL:
        //song = whateverTheChosenSongWasFromTheSongSelectionMenu //make sure the songs are TextAssets so it matches the 'song' variable
        //ReadLevel.Instance.LoadInCSV(song);

        //Delete below when you ahve more tahn one CSV song, this was just for testing the 1.
        song = songSheets[0];
        ReadLevel.Instance.LoadInCSV(song);

        bcColor.changeColour(BackColor.Anxious);
    }

    //Restart song if the cord count stops
    void CheckSongCount()
    {
        if (noteCount > songNotes.Count -1)
        {
            noteCount = 0;
        }
    }

    //Plays the entire song
    void playSong()
    {

        if (tempo < 1800.0f)
        {
            float tempoConv = 1.0f / ((tempo / 60.0f) * 4.0f);

            if (timer >= tempoConv)
            {
                timer = 0;

                if (songNotes[noteCount] != note.none)
                {
                    //ends song and starts a new one
                    if (songNotes[noteCount] == note.end)
                    {
                        sheetNum++;
                        if (sheetNum >= songSheets.Length)
                        {
                            //END GAME SCREEN HERE
                            isSceneChanging = true;
                        }
                        else
                        {
                            //Sets up the next song
                            song = songSheets[sheetNum];
                            ReadLevel.Instance.LoadInCSV(song);

                            switch(sheetNum)
                            {
                                case 0:
                                    bcColor.changeColour(BackColor.Anxious);
                                    break;

                                case 1:
                                    bcColor.changeColour(BackColor.Calm);
                                    break;

                                case 2:
                                    bcColor.changeColour(BackColor.Happy);
                                    break;

                                case 3:
                                    bcColor.changeColour(BackColor.Depressed);
                                    break;

                                default:
                                    bcColor.changeColour(BackColor.Calm);
                                    break;
                            }
                        }
                        
                    }
                    else
                    {
                        //Spawns the desired note
                        GameObject newNote = Instantiate(notes) as GameObject;
                        newNote.transform.SetParent(canvas.transform, false);
                        newNote.GetComponent<Note>().myNote = songNotes[noteCount];

                        //Checks if the notes must all be spawned on the same lines or not
                        if (oneLine == false)
                        {
                            MoveNote(newNote);
                        }

                        //Destroys the note after 6 seconds, (To keep hierachy clean)
                        Destroy(newNote, 6);
                    }
                }
                noteCount++;
            }
            timer += Time.deltaTime;
        }
    }

    //Chechs for scenechange
    void CheckSceneChange()
    {
        if(isSceneChanging == true)
        {
            if(sceneChangeTimer >= sceneChangeDelay)
            {
                SceneManager.LoadScene("MainMenu");
            }
            sceneChangeTimer += Time.deltaTime;
        }
    }

	// Update is called once per frame
	void Update() {
        if(hasSong) {
            playSong();
            CheckSongCount();
        }
        CheckSceneChange();
	}

    //Moves the notes between 3 different lines
    void Moves3Lines(GameObject noteToMove)
    {
        switch (songNotes[noteCount])
        {
            case note.A:
            case note.aSharp:
            case note.B:
            case note.C:
                noteToMove.transform.SetParent(SpawnLocation[0].transform, false);
                break;

            case note.cSharp:
            case note.D:
            case note.dSharp:
            case note.E:
                noteToMove.transform.SetParent(SpawnLocation[1].transform, false);
                break;

            case note.F:
            case note.fSharp:
            case note.G:
            case note.gSharp:
                noteToMove.transform.SetParent(SpawnLocation[2].transform, false);
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
                Moves3Lines(noteToMove);
                break;
        }
    }
}
