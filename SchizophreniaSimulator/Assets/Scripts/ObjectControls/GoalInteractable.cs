using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class GoalInteractable : MonoBehaviour
{
    private BoxCollider destinationCollider;    // The collider of the destination object for this goal
    private PuzzleManager puzzleManager;        // The manager of the puzzle system
    private Throwable throwInteraction;         // The throw interaction script on this object
    public bool isNotBeingHeld;                 // Whether this object is being held

    void Start(){
        throwInteraction = gameObject.GetComponent<Throwable>();
    }

    void Update()
    {
        isNotBeingHeld = !throwInteraction.attached;
    }

    // Reacts to being taken within distance of the door
    private void OnTriggerStay(Collider other)
    {
        if (other == destinationCollider && isNotBeingHeld)
        {
            print("Reached goal with correct object");
            // GameObject.Destroy(gameObject);
            // Trigger success audio clip
            puzzleManager.nextPuzzle();
            print($"Disabling: {gameObject.name}");
            this.enabled = false;
            //this.gameObject.SetActive(false);
        }
    }

    private void hasReached()
    {
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 3, this.transform.position.z);
    }

    // Initializes this interaction script by assigning the destination collider and the associated Puzzle Manager
    public void InitGoalInteraction(PuzzleManager puzzleManager, BoxCollider destinationCollider){
        this.puzzleManager = puzzleManager;
        this.destinationCollider = destinationCollider;
    }
}
