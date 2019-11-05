using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraswitch : MonoBehaviour
{

    private float timer = 0.0f;

    public GameObject cam1;
    public GameObject cam2;
    public GameObject cam3;

    private GameObject playerObj;
    private float loc;

    // Start is called before the first frame update
    void Start()
    {
        playerObj = GameObject.Find("Player");


    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;


        if (timer > 4 && timer < 4.05)
        {

            cam1.SetActive(false);
            cam2.SetActive(true);
        }
        if (timer > 4.05 && timer < 4.3)
        {
            cam1.SetActive(true);
            cam2.SetActive(false);
        }
        if (timer > 4.3 && timer < 4.4)
        {
            cam1.SetActive(false);
            cam2.SetActive(true);
        }
        if (timer > 4.4 && timer < 4.6)
        {
            cam1.SetActive(true);
            cam2.SetActive(false);
        }
        if (timer > 4.6 && timer < 4.7)
        {
            cam1.SetActive(false);
            cam2.SetActive(true);
        }
        if (timer > 4.7 && timer < 4.9)
        {
            cam1.SetActive(true);
            cam2.SetActive(false);
        }

        loc = playerObj.transform.position.z;
        Debug.Log(loc);
        if (loc < 2) {
            cam3.SetActive(true);
            cam1.SetActive(false);
        }
    }
}
