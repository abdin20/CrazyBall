using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayButtonScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //method to load scene 1
    public void playLevelOne(){
        GlobalVariables.expertMode=false;
        SceneManager.LoadScene("LevelOne");
    }
    //method to load expert mode
    public void playExpertLevelOne(){
        GlobalVariables.expertMode=true;
        SceneManager.LoadScene("LevelOne");
    }
    
    //method to add coins for debugging
    public void addCoins(){
        GlobalVariables.savedScore+=1000;
    }
}
