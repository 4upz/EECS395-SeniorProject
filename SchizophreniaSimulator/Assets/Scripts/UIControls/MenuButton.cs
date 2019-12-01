using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    // Loads a given scene within the game
   public void LoadScene(string sceneName){
       SceneManager.LoadScene(sceneName);
   }

    // Exits to the main menu of the game
    public void ExitToMainMenu(){
        SceneManager.LoadScene("MainMenu");
    }

   // Exits the entire application
   public void ExitGame(){
       Application.Quit();
   }
}
