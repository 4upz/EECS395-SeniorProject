using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Adds symptom-based functionality to an object in the scene
public class ObjectManager : MonoBehaviour
{
    private GameObject targetObject; // The hazard tyo be modified
    public Transform[] spawnPoints; // Array of spawn transformations to be moved to

    private bool objectMovementTriggered; // Boolean trigger for randomized object movement

    //Upon object awake
    void Awake(){
        // Variable just for clarification of referenced object
        targetObject = gameObject;
    }

    //Upon every frame
    void Update(){
        if (objectMovementTriggered){
            MoveObjectToRandomLocation();
        }
    }

   // Move the item to a new random location (probably a terrible name)
   private void MoveObjectToRandomLocation(){
       //Find a random index between zero and one less than the number of spawn points
       int spawnPointIndex = Random.Range(0, spawnPoints.Length);
       Transform newTransform = spawnPoints[spawnPointIndex];
       // Move the object's transform to the selected one from the array
       targetObject.transform.position = newTransform.position;
       targetObject.transform.rotation = newTransform.rotation;
       objectMovementTriggered = false;
   }

    // Alternative function that allows the object movement to be triggered after a certain amount of seconds
   public IEnumerator SetTriggerAfterTime(float seconds){
       yield return new WaitForSeconds(seconds);
       objectMovementTriggered = true;
   }

    // Enables the trigger for object movement
   public void setTrigger(){
       objectMovementTriggered = true;
   }
}
