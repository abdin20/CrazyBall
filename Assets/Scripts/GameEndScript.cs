using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class GameEndScript : MonoBehaviour
{   
    public GameObject parentPlayerObject;
    public GameObject mainCamera;
    public GameObject gameEndScreen;
    public GameObject cantWinText;
    public Texture gameWinImage;
    public bool isPlayerWin;
    public float elapsedTime;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {   
        isPlayerWin=false;
        elapsedTime=0f;
    }

    // Update is called once per frame
    void Update()
    {    player=GameObject.FindWithTag("Player");
        //if player won wait 5 seconds then return to main menu
        if(isPlayerWin){
            elapsedTime+=Time.deltaTime;
             if(elapsedTime>=5f){
                gameEndScreen.SetActive(false);
                elapsedTime=0f;
                //reset level variables
                GlobalVariables.gameTimer=0f;
                GlobalVariables.checkpoints=0;
                GlobalVariables.currScore=0;
                GlobalVariables.ringsLeft=3;
                GlobalVariables.ringStarted=false;
                GlobalVariables.timeRemaining=10.0f;
                GlobalVariables.abilityTimer=GlobalVariables.abilityTime;
                GlobalVariables.cooldownTimer=GlobalVariables.cooldownTimer;
                GlobalVariables.coinsCollected=0;
                SceneManager.LoadScene("MainMenu");
            }           
        }
    }

    //method to check if player is here on collision
    private void OnTriggerEnter(Collider other) {
        //check if player is colliding and if so check if in export mode, if in export mode all coins must be collected
         if( (other.gameObject.tag=="Player" &&!GlobalVariables.expertMode && !isPlayerWin) || (other.gameObject.tag=="Player" && !isPlayerWin &&GlobalVariables.expertMode &&GlobalVariables.coinsCollected==23)    ){
             isPlayerWin=true;

            //show win screen and play sound effect
            Time.timeScale = 1f;
            
            //reset player position so it doesnt die while in end screen LOL
            player.transform.position=new Vector3(100,1000,100);
            parentPlayerObject.GetComponent<AudioSource>().Stop();
            mainCamera.GetComponent<CameraScript>().playWinSound();
            gameEndScreen.SetActive(true);
            RawImage rawImageComponent= gameEndScreen.GetComponent<RawImage>();
            rawImageComponent.texture=gameWinImage;

             //increase total balance of user by game ending score
             //if game won in expert mode return twice as much coins
             if(GlobalVariables.expertMode){
                GlobalVariables.savedScore+=2*GlobalVariables.currScore;
             }else{
                 GlobalVariables.savedScore+=GlobalVariables.currScore;
             }           
         }else if(other.gameObject.tag=="Player" && !isPlayerWin &&GlobalVariables.expertMode &&GlobalVariables.coinsCollected!=23) {
             cantWinText.GetComponent<TMP_Text>().text="Need all coins to win!";
         }

    }

}
