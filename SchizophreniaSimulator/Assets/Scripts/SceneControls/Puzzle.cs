using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

// An object that represents a puzzle for the player to solve
public class Puzzle
{
    // An object structure that is part of this puzzle
    public struct PuzzleObject{
        public GameObject targetObject;    // The target game object
        public AudioSource voiceAudio;       // The associated audio clip with this object

        public PuzzleObject(GameObject targetObject, AudioSource voiceAudio){
            this.targetObject = targetObject;
            this.voiceAudio = voiceAudio;
        }
    }   

    public string riddle;                  // The associated riddle for this puzzle 
    public PuzzleObject goalObject;        // The goal object needed to solve this puzzle
    public PuzzleObject distractorOne;     // A distractor for this object
    public PuzzleObject distractorTwo;     // Another distractor for this object

    AudioSource[] otherVoiceClips;           // An array of other voiceclips to use if the incorrect object is picked up

    // Default constructor for a Puzzle
    public Puzzle(string riddle, PuzzleObject goalObject, PuzzleObject distractorOne, PuzzleObject distractorTwo){
        this.riddle = riddle;
        this.goalObject = goalObject;
        this.distractorOne = distractorOne;
        this.distractorTwo = distractorTwo;
    }

    // Optional empty constructor for a Puzzle
    public Puzzle(){
        riddle = "";
        goalObject = new PuzzleObject();
        distractorOne = new PuzzleObject();
        distractorTwo = new PuzzleObject();
        otherVoiceClips = new AudioSource[0];
    }
}
