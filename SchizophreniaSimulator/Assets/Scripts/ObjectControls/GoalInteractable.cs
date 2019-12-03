using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class GoalInteractable : MonoBehaviour
{
    private BoxCollider destinationCollider;    // The collider of the destination object for this goal
    private PuzzleManager puzzleManager;        // The manager of the puzzle system

    // Reacts to being taken within distance of the door
    void OnTriggerEnter(Collider other)
    {
        if (other == destinationCollider){
            print("Reached goal with correct object");
            // GameObject.Destroy(gameObject);
            // Trigger success audio clip
            puzzleManager.nextPuzzle();
            print($"Destroying: {gameObject.name}");
            GameObject.Destroy(gameObject);
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
