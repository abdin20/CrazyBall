using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedRingScript : MonoBehaviour
{   
    //variable to set rotatespeed
    public int rotateSpeed;

    public int score;

    public GameObject camera;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
         //rotate coin every second
        this.transform.Rotate(0,rotateSpeed,0);
    }


    //method to check if player is here on collision
    private void OnTriggerEnter(Collider other) {
        //check if player is colliding
         if(other.gameObject.tag=="Player"){
            
            //check to see if this is first ring collected
             if(!GlobalVariables.ringStarted){
                 GlobalVariables.ringStarted=true;
             }

            //play sound with camera
            camera.GetComponent<CameraScript>().playTimedCoinSound();

             //increase score by 1
             GlobalVariables.currScore+=score;  

             //decrease rings left by 1
             GlobalVariables.ringsLeft-=1;

             if(GlobalVariables.ringsLeft==0){

                 //give bonus of 100 points for getting every red ring
                 GlobalVariables.currScore+=100; 

                    //reset all variables since last ring collected
                    GlobalVariables.timeRemaining=10.0f;
                    GlobalVariables.ringStarted=false;
                    GlobalVariables.ringsLeft=3;
                    //play sound with camera
                   camera.GetComponent<CameraScript>().playCompleteTimedRingSound();

             }
            //  //destroy coin
             Destroy (this.gameObject);


         }
    }
}
