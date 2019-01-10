using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public int levelToLoad;
    public int instToLoad;
    public int menueToLoad;
    public int creditsToLoad;

    //Load specific Level
    public void LoadLevel(){
        SceneManager.LoadScene(levelToLoad);
    }
    public void LoadInstructions(){
        SceneManager.LoadScene(instToLoad);
    }
    public void LoadMenu(){
        SceneManager.LoadScene(menueToLoad);
    }
    public void LoadCredits()
    {
        SceneManager.LoadScene(creditsToLoad);
    }
    //Exits out of the game
    public void LevelExit(){
        Application.Quit();
        Debug.Log("application quit");
    }
}
