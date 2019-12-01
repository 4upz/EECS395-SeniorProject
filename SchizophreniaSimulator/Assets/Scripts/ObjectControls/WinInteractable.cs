using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class WinInteractable : MonoBehaviour
{
    //[SerializeField] private GameObject goalPoint;
    [SerializeField] private GameObject[] goalObjects;
    private Vector3 goalPos;
    private Vector3[] objectPos;
    int goalCount = 0;
    int goalMax;

    // Start is called before the first frame update
    void Start()
    {
        goalMax = goalObjects.Length;
        for(int i = 0; i < goalMax; i++)
        {
            objectPos[i] = goalObjects[i].transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (goalCount == goalMax)
        {
            GoalReached();
            goalCount++;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        print("Collide");
        for (int i = 0; i < goalMax; i++) {
            if (other.gameObject.name == goalObjects[i].name)
            {
                print("Goal");
                goalCount++;
                Destroy(goalObjects[i]);
            }
        }
    }

    private void GoalReached()
    {
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 3, this.transform.position.z);
    }
}
