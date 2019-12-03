using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR.Extras;

public class IntroductionMessage : MonoBehaviour
{

    [SerializeField] private GameObject[] introText;        // Array of text to be shown for the simulation intro
    [SerializeField] private GameObject playerTeleporting; // The player's ability to move
    [SerializeField] private GameObject playerLaser;
    [SerializeField] private PuzzleManager puzzleManager;

    private Button continueButton;      // The button to navigate the introduction messages

    private int activeTextIndex;    // Index of the active slide in introSlides

    // Start is called before the first frame update
    void Awake()
    {
        // Grab the button component of the continue button
        continueButton = gameObject.GetComponentInChildren<Button>();
        // Add a listener to the continue button that calls the given function when clicked
        continueButton.onClick.AddListener(ToggleIntroText);

        // Disable player movement during introduction
        playerTeleporting.SetActive(false);

        // Set the active index to the first slide
        activeTextIndex = 0;
    }

    // Toggles through the slides of intro messages and disables them after the last one
    public void ToggleIntroText(){
        introText[activeTextIndex].SetActive(false);  //Disable the currently active slide
        // If the current slide is the last slide, then disable the continue button
        if (activeTextIndex == introText.Length-1){
            continueButton.gameObject.SetActive(false);
            playerTeleporting.SetActive(true);
            playerLaser.GetComponent<SteamVR_LaserPointer>().active = false;
            //playerLaser.GetComponent<SteamVR_LaserPointer>().enabled = false;
            puzzleManager.enablePuzzles();
        }
        // Else, set the next slide active and increment the active index
        else {
            introText[++activeTextIndex].SetActive(true);
        }
        Debug.Log(activeTextIndex);
    }
}
