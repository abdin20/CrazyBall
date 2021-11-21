using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CameraScript : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public GameObject mainPlayer;
    public GameObject parentPlayerObject;
    public Vector3 playerDistance;

    //audio data and files
    public AudioSource audioData;
    public AudioClip normalRingSound;
    public AudioClip bundleCoinSound;
    public AudioClip timedRingSound;
    public AudioClip collectAllTimedRingSound;
    public AudioClip checkpointSound;
    public AudioClip loseSound;
    public AudioClip winSound;

    //gameobjects to keep track of where checkpoint is
    public GameObject checkpointOneEmpty;
    public GameObject checkpointTwoEmpty;

    public GameObject checkpointOneFloor;
    public GameObject checkpointTwoFloor;
    public GameObject otherDisappearingFloor;

    //game ending canvas variables
    public GameObject gameEndScreen;
    public Texture gameEndImage;
    public Texture gameWinImage;

    public bool isPlayerDead;
    private float timeDead;


    //ability variables
    // Start is called before the first frame update
    void Start()
    {   //turn off game end screen
        gameEndScreen.SetActive(false);
        //set game variables
        isPlayerDead=false;
        timeDead=0f;
        GlobalVariables.cooldownTimer=GlobalVariables.cooldownRunTime;

        audioData = GetComponent<AudioSource>();
        //figure out which player skin is active
        if(GlobalVariables.skin1==true){
            player1.SetActive(false);
            player2.SetActive(true);
            mainPlayer=player2;
        }else{
            player1.SetActive(true);
            player2.SetActive(false);
            mainPlayer=player1;
        }   
            //get offset of camera
          playerDistance=(this.transform.position-mainPlayer.transform.position);
    }

    // Update is called once per frame
    void Update()
    {   
        //update camera position
        this.transform.position=mainPlayer.transform.position+playerDistance;
        
        GlobalVariables.gameTimer+=Time.deltaTime;

        //ability controls

        //check how much time has passed since last ability press
        GlobalVariables.cooldownTimer+=Time.deltaTime;
        //check if player pressed F and enough time passed to use ability
        if (Input.GetKeyDown(KeyCode.F) && GlobalVariables.boughtPlayerAbility &&GlobalVariables.cooldownTimer>=GlobalVariables.cooldownRunTime){
            GlobalVariables.cooldownTimer=0f;
            //enable player ability
            GlobalVariables.playerAbility=true;
        }

        //if player ability time is active
        if(GlobalVariables.playerAbility){
            //decrease timer of ability
            GlobalVariables.abilityTimer-=Time.deltaTime;
            
            //once timer reaches 0 disable ability
            if( GlobalVariables.abilityTimer<=0f){
                GlobalVariables.playerAbility=false;
                GlobalVariables.abilityTimer=10f;
            }
        }


        //check for player death
        if(mainPlayer.transform.position.y<-4.5f &&!isPlayerDead){
            isPlayerDead=true;
            //show death screen
            //activate game end screen and show game over image
            parentPlayerObject.GetComponent<AudioSource>().Stop();
            audioData.PlayOneShot(loseSound);
            
            gameEndScreen.SetActive(true);
            RawImage rawImageComponent= gameEndScreen.GetComponent<RawImage>();
            rawImageComponent.texture=gameEndImage;
        }
        
        //keep track of how much time passed since player died if they did die
        if(isPlayerDead){
            timeDead+=Time.deltaTime;
            //if 5 seconds passed then reset level
            if(timeDead>=5f){
                gameEndScreen.SetActive(false);
                timeDead=0f;
                //reset level once death screen has been shown for enough time
                parentPlayerObject.GetComponent<AudioSource>().Play(0);
                resetLevel();
            }
        }
    }

    //methods for each sound effect in game
    public void playNormalCoinSound(){
        audioData.PlayOneShot(normalRingSound);
    }
    public void playbundleCoinSound(){
        audioData.PlayOneShot(bundleCoinSound);
    }
    public void playTimedCoinSound(){
        audioData.PlayOneShot(timedRingSound);
    }
    public void playCompleteTimedRingSound(){
        audioData.PlayOneShot(collectAllTimedRingSound);
    }
    public void playCheckpointSound(){
        audioData.PlayOneShot(checkpointSound);
    }
    public void playWinSound(){
        audioData.PlayOneShot(winSound);
    }

    //method to restart level fully
    public void restartLevel(){

        //reset level variables
        GlobalVariables.gameTimer=0f;
        GlobalVariables.checkpoints=0;
        GlobalVariables.currScore=0;
        GlobalVariables.ringsLeft=3;
        GlobalVariables.ringStarted=false;
        GlobalVariables.timeRemaining=10.0f;
        GlobalVariables.abilityTimer=3f;
        GlobalVariables.cooldownTimer=GlobalVariables.cooldownTimer;
        GlobalVariables.coinsCollected=0;
        
        //reload scene
        Application.LoadLevel (Application.loadedLevel);
    }


    //reset level, need to determing if we are fully restarting or loading a checkpoint
    private void resetLevel(){

            //reset the disappearing floors
            checkpointTwoFloor.GetComponent<DisappearingFloorScript>().resetFloor();
            otherDisappearingFloor.GetComponent<DisappearingFloorScript>().resetFloor();
            //no checkpoints reached just restart the level
            if(GlobalVariables.checkpoints==0){
                restartLevel();

                //if player reached checkpoint 1 send back
            }else if(GlobalVariables.checkpoints==1){

                //lose 10 score for using checkpoint only if player has enough points to lose    
                if(GlobalVariables.currScore>=10){
                    GlobalVariables.currScore-=10;
                } 
                //make sure the floor isnt at a bad angle on spawn
                checkpointOneFloor.transform.rotation=(Quaternion.identity);
                //reset player position to checkpoint
                mainPlayer.transform.position=checkpointOneEmpty.transform.position;
                isPlayerDead=false;
            }else if(GlobalVariables.checkpoints==2){

                //lose 10 score for using checkpoint only if player has enough points to lose    
                if(GlobalVariables.currScore>=10){
                    GlobalVariables.currScore-=10;
                } 
                //reset player position to checkpoint
                mainPlayer.transform.position=checkpointTwoEmpty.transform.position;
                isPlayerDead=false;
            }
    }
}
