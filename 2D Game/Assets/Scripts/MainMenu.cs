using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public int levelToLoad;

    //Load specific Level
    public void LoadLevel(){
        SceneManager.LoadScene(levelToLoad);
    }
    //Exits out of the game
    public void LevelExit(){
        Application.Quit();
    }
}
