using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Adds symptom-based functionality to an object in the scene
public class ObjectManager : MonoBehaviour
{
    public Transform[] spawnPoints;         // Array of spawn transformations to be moved to
    public PuzzleManager puzzleManager;     // The current puzzle manager of this scene
    public float transformDelay;            // The delayed time before this object is moved

    private GameObject targetObject;        // The object to be modified
    private bool objectMovementTriggered;   // Boolean trigger for randomized object movement
    private bool hasBeenTranslated;         // Whether this object has been moved
    private AudioSource audioSource;        // The audio source component attached to this object
    private AudioClip lastClip;           // The previous clip attached to the audio source
    [SerializeField] private AudioClip displacementClip;    // The special voice clip that plays when this object is moved


    //Upon Start of Scene
    void Start(){
        // Variable just for clarification of referenced object
        targetObject = gameObject;
        hasBeenTranslated = false;
        audioSource = GetComponent<AudioSource>();
        lastClip = audioSource.clip;
    }

    //Upon every frame
    void Update(){
        if (objectMovementTriggered && !hasBeenTranslated){
            MoveObjectToRandomLocation();
        }
        
        if (puzzleManager.getCurrentGoalObject() == gameObject && !hasBeenTranslated && puzzleManager.puzzlesEnabled){
            IEnumerator trigger = SetTriggerAfterTime(3.0f);    // This will trigger the Object transformation
            StartCoroutine(trigger);
        }
    }

   // Move the item to a new random location (probably a terrible name)
   private void MoveObjectToRandomLocation(){
       // Swap the audio clips and play the displacement one
       lastClip = audioSource.clip;
       if (audioSource.isPlaying) {audioSource.Stop();}
       audioSource.clip = displacementClip;
       audioSource.Play();
       StartCoroutine(changeClipAfterSeconds(6.0f));
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

   public IEnumerator changeClipAfterSeconds(float seconds){
       yield return new WaitForSeconds(seconds);
       audioSource.clip = lastClip;
   }

    // Enables the trigger for object movement
   public void setTrigger(){
       objectMovementTriggered = true;
   }
}
