using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleManager : MonoBehaviour
{

    public Puzzle[] puzzles = new Puzzle[3];        // The list of puzzles to be assigned to the player
    public Puzzle activePuzzle;                     // The currently active puzzle
    public Text riddleDisplay;                            // The text element that will display the puzzle riddle in the world space

    // Start is called before the first frame update
    void Start()
    {
        InitPuzzles();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Initializes the puzzles with the given riddles and designated game objects
    void InitPuzzles(){
        Puzzle PuzzleOne = new Puzzle();
        PuzzleOne.riddle = "Your sister always thinks she's a superhero. Find her favorite toy.";
        GameObject goalObject = GameObject.Find("GoalObject3");
        PuzzleOne.goalObject = new Puzzle.PuzzleObject(goalObject, goalObject.GetComponent<AudioSource>());
        /* TODO Fill these in **/
        // Initialize DistractorOne
        // Initialize DistractorTwo
        // Initialize other potential audio clips
        // Make the first puzzle the active puzzle;
        activePuzzle = PuzzleOne;   

        /** TODO Repeat for the other two riddles **/
    }

    // Enables the puzzle system and displays the first riddle
    public void enablePuzzles(){
        riddleDisplay.gameObject.SetActive(true);
        riddleDisplay.text = $"Object #1:\n{activePuzzle.riddle}";
    }
}
