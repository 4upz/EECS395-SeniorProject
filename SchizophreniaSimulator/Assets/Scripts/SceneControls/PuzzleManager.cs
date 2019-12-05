using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleManager : MonoBehaviour
{
    public Puzzle[] puzzles = new Puzzle[3];                // The list of puzzles to be assigned to the player
    public int activePuzzleIndex = 0;                       // The index of the currently active puzzle
    public Text riddleDisplay;                              // The text element that will display the puzzle riddle in the world space  
    public GameObject door;                                 // The door of the room
    public bool puzzlesEnabled = false;                     // Whether the tutorial is clear and the puzzles have been enabled
    private BoxCollider doorCollider;                       // The collider of the room door
    private GameObject currentGoalObject;                   // The goal of the current riddle
    private GoalInteractable currentGoalInteraction;        // The script tracking the interaction of the current goal object
    private bool puzzlesCompleted;                          // Whether all of the puzzles have been completed 
    private AudioSource audioSource;                        // The audio source attached that will be used for visual displacement

    // Start is called before the first frame update
    void Start()
    {
        InitPuzzles();
        doorCollider = door.GetComponent<BoxCollider>();
        puzzlesCompleted = false;
    }

    // Initializes the puzzles with the given riddles and designated game objects
    void InitPuzzles(){
        // GameObjects and riddle to be used for the corresponding puzzle
        GameObject goalObject;
        GameObject distractorOne;
        GameObject distractorTwo;
        string riddle;

        /** Create the first riddle **/
        riddle = "Your sister always thinks she's a princess but looks weird for one. Find her favorite toy.";
        goalObject = GameObject.Find("GoalObject1");
        // Initialize DistractorOne
        distractorOne = GameObject.Find("toy16");
        // Initialize DistractorTwo
        distractorTwo = GameObject.Find("toy3");
        // Initialize other potential audio clips (currently none)
        // Save the data into the Puzzle array
        puzzles[0] = new Puzzle(riddle, goalObject, distractorOne, distractorTwo);

        /** Create the second riddle **/
        riddle = "Your brother tends to keep one eye out for this toy, but still lost it. Find his favorite toy.";
        goalObject = GameObject.Find("GoalObject2");
        // Initialize DistractorOne
        distractorOne = GameObject.Find("toy10");
        // Initialize DistractorTwo
        distractorTwo = GameObject.Find("toy7");
        // Initialize other potential audio clips (currently none)
        // Save the data into the Puzzle array
        puzzles[1] = new Puzzle(riddle, goalObject, distractorOne, distractorTwo);

        /** Create the third riddle **/
        riddle = "You can't forget your own toy! It tends to bounce around a lot so you better try to find it.";
        goalObject = GameObject.Find("GoalObject3");
        // Initialize DistractorOne
        distractorOne = GameObject.Find("BlankBall");
        // Initialize DistractorTwo
        distractorTwo = GameObject.Find("toy5");
        // Initialize other potential audio clips (currently none)
        // Save the data into the Puzzle array
        puzzles[2] = new Puzzle(riddle, goalObject, distractorOne, distractorTwo);  
    }

    // Enable the given object as the currently interactable goal object
    void setGoalInteractable(GameObject targetObject){
        // currentGoalInteraction = currentGoalObject.AddComponent(typeof(GoalInteractable)) as GoalInteractable;
        currentGoalInteraction = currentGoalObject.GetComponent<GoalInteractable>();
        currentGoalInteraction.enabled = true;
        currentGoalInteraction.InitGoalInteraction(this, doorCollider);
        print($"Assigning: {targetObject.name}");

    }

    // Enables the puzzle system and displays the first riddle
    public void enablePuzzles(){
        puzzlesEnabled = true;
        riddleDisplay.gameObject.SetActive(true);
        riddleDisplay.text =  $"Object #{activePuzzleIndex+1}:\n{puzzles[activePuzzleIndex].riddle}";
        currentGoalObject = puzzles[activePuzzleIndex].goalObject;
        setGoalInteractable(currentGoalObject);
    }

    public void nextPuzzle(){
        // If not already on the last object, assign the next puzzle to solve
        if (activePuzzleIndex < puzzles.Length-1){
            currentGoalObject.SetActive(false);
            activePuzzleIndex++;
            currentGoalObject = puzzles[activePuzzleIndex].goalObject;
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

    public GameObject getCurrentGoalObject(){
        return currentGoalObject;
    }
}
