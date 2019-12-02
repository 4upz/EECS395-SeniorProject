using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotatesky : MonoBehaviour
{
    public float speed = 5f;

    void Start()
    {
        
    }

    
    void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * speed);
    }
}
