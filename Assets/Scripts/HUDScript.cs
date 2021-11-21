using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class HUDScript : MonoBehaviour
{   
    public GameObject checkpointsCounter;
    public GameObject score;
    public GameObject ringTimer;
    public GameObject abilityTimer;
    public GameObject abilityReady;
    public GameObject expertMode;
    public GameObject timer;
    public GameObject mainCamera;
    // Start is called before the first frame update
    void Start()
    {   
        //gameobject holding checkpoint text
        checkpointsCounter = this.gameObject.transform.GetChild(0).gameObject;
        score = this.gameObject.transform.GetChild(1).gameObject;
        ringTimer= this.gameObject.transform.GetChild(2).gameObject;
        abilityTimer=this.gameObject.transform.GetChild(3).gameObject;
        abilityReady=this.gameObject.transform.GetChild(4).gameObject;
        expertMode=this.gameObject.transform.GetChild(5).gameObject;
        timer=this.gameObject.transform.GetChild(7).gameObject;

    }

    // Update is called once per frame
    void Update()
    {       
        //update checkpoint,score and timer accordingly
         checkpointsCounter.GetComponent<TMP_Text>().text="Checkpoint: "+GlobalVariables.checkpoints.ToString();
         score.GetComponent<TMP_Text>().text="Score: "+GlobalVariables.currScore.ToString();
         timer.GetComponent<TMP_Text>().text="Time: "+GlobalVariables.gameTimer.ToString();
        
        //only show ability timer if it started countdown
         if(GlobalVariables.abilityTimer<GlobalVariables.abilityTime){
            abilityTimer.GetComponent<TMP_Text>().text="Ability Time: "+GlobalVariables.abilityTimer.ToString();
         }else{
             abilityTimer.GetComponent<TMP_Text>().text="";
         }
        
        //show ability is ready to use or not
        //if cooldown timer is above threshold it is ready
         if( GlobalVariables.boughtPlayerAbility && GlobalVariables.cooldownTimer>=GlobalVariables.cooldownRunTime){
             abilityReady.GetComponent<TMP_Text>().text="Press F for ability";

             //if user is using ability show nothing or if user hasnt bought ability show nothing
         }else if(GlobalVariables.playerAbility || !GlobalVariables.boughtPlayerAbility){ 
                abilityReady.GetComponent<TMP_Text>().text="";
         }else{
             //else ability not ready and show user its not ready 
                abilityReady.GetComponent<TMP_Text>().text="Ability Not Ready";
         }
        

        //expert mode code

        if(GlobalVariables.expertMode){
            expertMode.GetComponent<TMP_Text>().text="Expert Mode \n Coins Left:  "+ (23 - GlobalVariables.coinsCollected).ToString();
        }
        
        //only display ring timer if player started it
         if(GlobalVariables.ringStarted){
             //check if time remaining is positive
             if(GlobalVariables.timeRemaining>0){
                  GlobalVariables.timeRemaining-=Time.deltaTime;
                ringTimer.GetComponent<TMP_Text>().text="Ring Timer: "+GlobalVariables.timeRemaining.ToString();
             }else{ 
                    //destroy all the rings since time ran out
                    GameObject[] rings = GameObject.FindGameObjectsWithTag("ring");
                    foreach(GameObject ring in rings)
                    GameObject.Destroy(ring);
                    //reset variables after
                    
                    //if in expert mode and player didnt get all coins restart level since impossible to win now
                    if(GlobalVariables.expertMode &&GlobalVariables.ringsLeft>0){
                        mainCamera.GetComponent<CameraScript>().restartLevel();
                    }
                    GlobalVariables.ringStarted=false;
                    GlobalVariables.timeRemaining=10.0f;
                    GlobalVariables.ringsLeft=3;
                    ringTimer.GetComponent<TMP_Text>().text="";
             }
            
             
         }else{
             //dont show ring timer if rings havent been started yet
             ringTimer.GetComponent<TMP_Text>().text="";
         }
    }
}
