using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class InGameMenu : MonoBehaviour
{
    private bool previousState = false;
    [SerializeField] private GameObject menuScreen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool state = SteamVR_Actions._default.GrabGrip[SteamVR_Input_Sources.RightHand].state;
        if (state && !previousState)
        {
            if (menuScreen.activeInHierarchy)
                menuScreen.SetActive(false);
            else
                menuScreen.SetActive(true);
        }
        previousState = state;
    }
}
