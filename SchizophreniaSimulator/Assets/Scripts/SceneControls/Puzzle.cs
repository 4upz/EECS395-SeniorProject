using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

// An object that represents a puzzle for the player to solve
public class Puzzle
{
    public string riddle;                  // The associated riddle for this puzzle 
    public GameObject goalObject;        // The goal object needed to solve this puzzle
    public GameObject distractorOne;     // A distractor for this object
    public GameObject distractorTwo;     // Another distractor for this object

    AudioSource[] otherVoiceClips;       // An array of other voiceclips to use if the incorrect object is picked up

    // Default constructor for a Puzzle
    public Puzzle(string riddle, GameObject goalObject, GameObject distractorOne, GameObject distractorTwo){
        this.riddle = riddle;
        this.goalObject = goalObject;
        this.distractorOne = distractorOne;
        this.distractorTwo = distractorTwo;
    }

    // Optional empty constructor for a Puzzle
    public Puzzle(){
        riddle = "";
        otherVoiceClips = new AudioSource[0];
    }
}
