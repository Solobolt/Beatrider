using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ReadLevel : SingletonBehaviour<ReadLevel> {
    
    public string[] csvNotes;
    public List<note> parsedNotes = new List<note>();

    public void LoadInCSV(TextAsset musicCSV) {
        csvNotes = musicCSV.text.Split(","[0]);
        for(int i = 0; i < csvNotes.Length; ++i) {
            if(csvNotes[i] == "A") {
                parsedNotes.Add(note.A);
            } else if(csvNotes[i] == "B") {
                parsedNotes.Add(note.B);
            } else if(csvNotes[i] == "C") {
                parsedNotes.Add(note.C);
            } else if(csvNotes[i] == "D") {
                parsedNotes.Add(note.D);
            } else if(csvNotes[i] == "E") {
                parsedNotes.Add(note.E);
            } else if(csvNotes[i] == "F") {
                parsedNotes.Add(note.F);
            } else if(csvNotes[i] == "G") {
                parsedNotes.Add(note.G);
            } else if(csvNotes[i] == " ") {
                parsedNotes.Add(note.none);
            } else if(csvNotes[i] == "End") {
                parsedNotes.Add(note.end);
            }
        }

        GameController.Instance.songNotes = parsedNotes;
        GameController.Instance.hasSong = true;
    }
}
