using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class HUDScript : MonoBehaviour
{   
    public GameObject checkpointsCounter;
    public GameObject score;
    public GameObject ringTimer;
    // Start is called before the first frame update
    void Start()
    {   
        //gameobject holding checkpoint text
        checkpointsCounter = this.gameObject.transform.GetChild(0).gameObject;
        score = this.gameObject.transform.GetChild(1).gameObject;
        ringTimer= this.gameObject.transform.GetChild(2).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
         checkpointsCounter.GetComponent<TMP_Text>().text="Checkpoint: "+GlobalVariables.checkpoints.ToString();
         score.GetComponent<TMP_Text>().text="Score: "+GlobalVariables.currScore.ToString();
        
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
