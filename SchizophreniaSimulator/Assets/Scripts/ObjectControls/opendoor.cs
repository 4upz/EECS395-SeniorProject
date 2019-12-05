using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class opendoor : MonoBehaviour
{
    private bool rotate = false;
    public int whichdoor;
    private GameObject playerObj;
    private float timer = 0.0f;
    private AudioSource audioSource;

    void Start()
    {
        playerObj = GameObject.Find("Player");
        audioSource = GetComponent<AudioSource>();
        if (!audioSource.isPlaying){
            audioSource.panStereo = 1;
            audioSource.Play();
        }
    }

    void Update()
    {
        if (audioSource.time == 3){
            audioSource.panStereo = -1;
        }

        float rotation = 30 * Time.deltaTime;
        float loc = playerObj.transform.position.z;
        // Debug.Log(loc);
        if (loc < 4)
        {

            timer += Time.deltaTime;
            if (timer < 4)
            {
                rotate = true;
            }
            else {
                rotate = false;
            }
        }

        if (rotate) {
            if (whichdoor == 0)
            {
                transform.RotateAround(new Vector3(-2.1f, 0.0f, 0.0f), Vector3.down, rotation);
            }
            if (whichdoor == 1)
            {
                transform.RotateAround(new Vector3(-4.9f, 0.0f, 0.0f), Vector3.up, rotation);
            }
        }

        
    }
}
