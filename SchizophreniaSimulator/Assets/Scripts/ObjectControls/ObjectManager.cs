using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Adds symptom-based functionality to an object in the scene
public class ObjectManager : MonoBehaviour
{
    private GameObject targetObject; // The hazard tyo be modified
    public Transform[] spawnPoints; // Array of spawn transformations to be moved to
    public PuzzleManager puzzleManager;    // The current puzzle manager of this scene
    public float transformDelay;            // The delayed time before this object is moved

    private bool objectMovementTriggered;   // Boolean trigger for randomized object movement
    private bool hasBeenTranslated;         // Whether this object has been moved

    //Upon Start of Scene
    void Start(){
        // Variable just for clarification of referenced object
        targetObject = gameObject;
        hasBeenTranslated = false;
    }

    //Upon every frame
    void Update(){
        if (objectMovementTriggered && !hasBeenTranslated){
            MoveObjectToRandomLocation();
        }
        
        if (puzzleManager.puzzles[puzzleManager.activePuzzleIndex].goalObject == gameObject && !hasBeenTranslated){
            IEnumerator trigger = SetTriggerAfterTime(3.0f);                                   // This will trigger the Object transformation
            StartCoroutine(trigger);
        }
    }

   // Move the item to a new random location (probably a terrible name)
   private void MoveObjectToRandomLocation(){
        hasBeenTranslated = true;
       //Find a random index between zero and one less than the number of spawn points
       int spawnPointIndex = Random.Range(0, spawnPoints.Length);
       Transform newTransform = spawnPoints[spawnPointIndex];
       // Move the object's transform to the selected one from the array
       targetObject.transform.localPosition = newTransform.position;
       targetObject.transform.localRotation = newTransform.rotation;
       objectMovementTriggered = false;
   }

    // Alternative function that allows the object movement to be triggered after a certain amount of seconds
   public IEnumerator SetTriggerAfterTime(float waitTime){
        yield return new WaitForSeconds(waitTime);
       objectMovementTriggered = true;
   }

    // Enables the trigger for object movement
   public void setTrigger(){
       objectMovementTriggered = true;
   }
}
