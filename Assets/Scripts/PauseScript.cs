using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{   
    public GameObject pauseMenu;
    public GameObject HUD;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if escape is pressed toggle between pause or not
        if (Input.GetKeyUp(KeyCode.Escape))
        {   Debug.Log("Pressed esc");
            togglePause();
        }
    }

    //method to toggle pausing of the game
    public void togglePause()
    {   
        Debug.Log("toggling the pause");
        //toggle between pausing and not
        if (Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
            //when unpausing show HUD and stop showing pause screen
            pauseMenu.SetActive(false);
            HUD.SetActive(true);
        }
        else
        {
            Time.timeScale = 0f;
            //when pausing hide HUD and show pause screen
            pauseMenu.SetActive(true);
             HUD.SetActive(false);
        }

    }
    
    //method to quit application
    public void Quit(){
        //quit the application
        Application.Quit();
    }


    //method to load menu
    public void Menu(){

        //load game scene when play is pressed
        Time.timeScale = 1f;
        GlobalVariables.gameTimer=0f;
        GlobalVariables.checkpoints=0;
        GlobalVariables.currScore=0;
        GlobalVariables.ringsLeft=3;
        GlobalVariables.ringStarted=false;
        GlobalVariables.timeRemaining=10.0f;
        GlobalVariables.abilityTimer=3f;
        GlobalVariables.cooldownTimer=GlobalVariables.cooldownTimer;
        GlobalVariables.coinsCollected=0;
        SceneManager.LoadScene("MainMenu");
    }


    //restart current scene
    public void Restart(){
        Time.timeScale = 1f;
         //when unpausing show HUD and stop showing pause screen
        pauseMenu.SetActive(false);
        HUD.SetActive(true);

        //reset level variables
        Time.timeScale=1f;
        GlobalVariables.gameTimer=0f;
        GlobalVariables.checkpoints=0;
        GlobalVariables.currScore=0;
        GlobalVariables.ringsLeft=3;
        GlobalVariables.ringStarted=false;
        GlobalVariables.timeRemaining=10.0f;
        GlobalVariables.abilityTimer=3f;
        GlobalVariables.cooldownTimer=GlobalVariables.cooldownTimer;
        GlobalVariables.coinsCollected=0;
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}
