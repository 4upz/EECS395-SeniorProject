using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleManager : MonoBehaviour
{
    public Puzzle[] puzzles = new Puzzle[3];                // The list of puzzles to be assigned to the player
    public int activePuzzleIndex = 0;                       // The currently active puzzle
    public Text riddleDisplay;                              // The text element that will display the puzzle riddle in the world space  
    public GameObject door;                                 // The door of the room
    private BoxCollider doorCollider;                       // The collider of the room door
    private GameObject currentGoalObject;                   // The goal of the current riddle
    private GoalInteractable currentGoalInteraction;        // The script tracking the interaction of the current goal object
    private bool puzzlesCompleted;                          // Whether all of the puzzles have been completed 

    // Start is called before the first frame update
    void Start()
    {
        InitPuzzles();
        doorCollider = door.GetComponent<BoxCollider>();
        puzzlesCompleted = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Initializes the puzzles with the given riddles and designated game objects
    void InitPuzzles(){
        // GameObjects to be used for each puzzle
        GameObject goalObject;
        GameObject distractorOne;
        GameObject distractorTwo;

        /** Create the first riddle **/
        Puzzle puzzleOne = new Puzzle();
        puzzleOne.riddle = "Your sister always thinks she's a superhero. Find her favorite toy.";
        goalObject = GameObject.Find("GoalObject1");
        puzzleOne.goalObject = new Puzzle.PuzzleObject(goalObject, goalObject.GetComponent<AudioSource>());
        // Initialize DistractorOne
        distractorOne = GameObject.Find("toy16");
        puzzleOne.distractorOne = new Puzzle.PuzzleObject(distractorOne, goalObject.GetComponent<AudioSource>());
        // Initialize DistractorTwo
        distractorTwo = GameObject.Find("toy3");
        puzzleOne.distractorTwo = new Puzzle.PuzzleObject(distractorTwo, goalObject.GetComponent<AudioSource>());
        // Initialize other potential audio clips (currently none)
        // Make the first puzzle the active puzzle;  

        /** Create the second riddle **/
        Puzzle puzzleTwo = new Puzzle();
        puzzleTwo.riddle = "Your brother tends to keep one eye out for this toy, but still lost it. Find his favorite toy.";
        goalObject = GameObject.Find("GoalObject2");
        puzzleTwo.goalObject = new Puzzle.PuzzleObject(goalObject, goalObject.GetComponent<AudioSource>());
        // Initialize DistractorOne
        distractorOne = GameObject.Find("toy10");
        puzzleTwo.distractorOne = new Puzzle.PuzzleObject(distractorOne, goalObject.GetComponent<AudioSource>());
        // Initialize DistractorTwo
        distractorTwo = GameObject.Find("toy7");
        puzzleTwo.distractorTwo = new Puzzle.PuzzleObject(distractorTwo, goalObject.GetComponent<AudioSource>());
        // Initialize other potential audio clips (currently none)

        /** Create the third riddle **/
        Puzzle puzzleThree = new Puzzle();
        puzzleThree.riddle = "You can't forget your own toy! It tends to bounce around a lot so you better try to find it.";
        goalObject = GameObject.Find("GoalObject3");
        puzzleThree.goalObject = new Puzzle.PuzzleObject(goalObject, goalObject.GetComponent<AudioSource>());
        // Initialize DistractorOne
        distractorOne = GameObject.Find("BlankBall");
        puzzleThree.distractorOne = new Puzzle.PuzzleObject(distractorOne, goalObject.GetComponent<AudioSource>());
        // Initialize DistractorTwo
        distractorTwo = GameObject.Find("toy5");
        puzzleThree.distractorTwo = new Puzzle.PuzzleObject(distractorTwo, goalObject.GetComponent<AudioSource>());
        // Initialize other potential audio clips (currently none)  

        // Add the puzzles to the array
        puzzles[0] = puzzleOne;
        puzzles[1] = puzzleTwo;
        puzzles[2] = puzzleThree;
    }

    void setGoalInteractable(GameObject targetObject){
        currentGoalInteraction = currentGoalObject.AddComponent(typeof(GoalInteractable)) as GoalInteractable;
        currentGoalInteraction.InitGoalInteraction(this, doorCollider);
        print($"Assigning: {targetObject.name}");

    }

    // Enables the puzzle system and displays the first riddle
    public void enablePuzzles(){
        riddleDisplay.gameObject.SetActive(true);
        riddleDisplay.text =  $"Object #{activePuzzleIndex+1}:\n{puzzles[activePuzzleIndex].riddle}";
        currentGoalObject = puzzles[activePuzzleIndex].goalObject.targetObject;
        setGoalInteractable(currentGoalObject);
    }

    public void nextPuzzle(){
        // If not already on the last object, assign the next puzzle to solve
        if (activePuzzleIndex < puzzles.Length-1){
            currentGoalObject.SetActive(false);
            activePuzzleIndex++;
            currentGoalObject = puzzles[activePuzzleIndex].goalObject.targetObject;
            setGoalInteractable(currentGoalObject);
            riddleDisplay.text = $"Object #{activePuzzleIndex+1}:\n{puzzles[activePuzzleIndex].riddle}";
        }
        else {
            puzzlesCompleted = true;
            riddleDisplay.text = "Congrats! You found everything!";
            door.GetComponent<opendoor>().enabled = true;
            print("Congratulations! You finished!");
        }
    }
}
