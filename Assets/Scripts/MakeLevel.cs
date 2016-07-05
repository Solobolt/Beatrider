using UnityEngine;
using System.Collections;

public class MakeLevel : MonoBehaviour {

    public float noInputTimer;
    public bool isEnd;
    public string levelName;
    public float timing;
    public note[] notes;
    public int endOfNotesArray;

	void Start () {
        noInputTimer = 0.0f;
        isEnd = false;
        levelName = "MaryHadALittleLamb";
        endOfNotesArray = 0;
    }

    void Update() {
        timing = 1.0f / (GameController.Instance.tempo / 60.0f * 4.0f);

        if(!isEnd) {
            /*if(!Input.anyKey) {
                //No key is pressed, count how many seconds to wait for next input.
                noInputTimer += Time.deltaTime;

                if(noInputTimer % (timing * 2) > 0.9f) {
                    Debug.Log("A second has been waited on.");
                }
                Debug.Log(noInputTimer % (timing * 2));

            } else*/ if(Input.GetKeyDown(KeyCode.Return)) {
                //The end has been specified, will add a final WaitForSeconds and then end the game.
                notes.SetValue(note.end, endOfNotesArray);
                noInputTimer = 0.0f;
                isEnd = true;

            } else if(Input.anyKey){
                //save noInputTimer time to File (it will add a WaitForSeconds for the amount of noInputTimer). May not need to check if noInputTimer is above 0 though...
                noInputTimer = 0.0f;


                if(Input.GetKeyDown(KeyCode.Space)) {
                    notes.SetValue(note.none, endOfNotesArray);
                    ++endOfNotesArray;
                }


                if(Input.GetKeyDown(KeyCode.A)) {
                    notes.SetValue(note.A, endOfNotesArray);
                    ++endOfNotesArray;
                }

                if(Input.GetKeyDown(KeyCode.B)) {
                    notes.SetValue(note.B, endOfNotesArray);
                    ++endOfNotesArray;
                }

                if(Input.GetKeyDown(KeyCode.C)) {
                    notes.SetValue(note.C, endOfNotesArray);
                    ++endOfNotesArray;
                }

                if(Input.GetKeyDown(KeyCode.D)) {
                    notes.SetValue(note.D, endOfNotesArray);
                    ++endOfNotesArray;
                }

                if(Input.GetKeyDown(KeyCode.E)) {
                    notes.SetValue(note.E, endOfNotesArray);
                    ++endOfNotesArray;
                }

                if(Input.GetKeyDown(KeyCode.F)) {
                    notes.SetValue(note.F, endOfNotesArray);
                    ++endOfNotesArray;
                }

                if(Input.GetKeyDown(KeyCode.G)) {
                    notes.SetValue(note.G, endOfNotesArray);
                    ++endOfNotesArray;
                }
            }                
        }
    }



    /*void AddToFile(string note, float durationOfWait, bool isNoteKeyPressed, bool isEnd) {

        if(note == "blank") {
            //time of blank in WaitForSeconds

        } else if(note == "end") {


        } else { //It is an actual note

        }
    }*/
}
