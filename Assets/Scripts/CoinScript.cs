using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{    
    //variable to set rotatespeed
    public int rotateSpeed;

    public int score;

    public GameObject camera;

    
    public GameObject player;

    public float distanceFromPlayer;

    private Vector3 coinVector;

    private Vector3 playerVector;

    // Start is called before the first frame update
    void Start()
    {   
    }

    // Update is called once per frame
    void Update()
    {   
        player=GameObject.FindWithTag("Player");
        //rotate coin every second
        this.transform.Rotate(0,rotateSpeed,0);

        //get coin and player vectors but we dont care about y cuz were only calculating x,y distance
        coinVector= this.transform.position;
        playerVector=player.transform.position;
        playerVector.y=coinVector.y;

        //get distance
       distanceFromPlayer= Vector3.Distance(coinVector,playerVector);

        //if magnet Level one is enabled and within range move towards player
        if(GlobalVariables.magnetLevelOne && distanceFromPlayer<=2.5f){
            this.transform.position=Vector3.Lerp(coinVector,player.transform.position,2.0f*Time.deltaTime);
        }

        //if magnet Level Two is enabled and within range move towards player
        if(GlobalVariables.magnetLevelTwo && distanceFromPlayer<=3.5f){
            this.transform.position=Vector3.Lerp(coinVector,player.transform.position,2.0f*Time.deltaTime);
        }
        
    }

    //method to check if player is here on collision
    private void OnTriggerEnter(Collider other) {
        //check if player is colliding
         if(other.gameObject.tag=="Player"){

             //play sound effect with camera script
             //sound effect depends on what type of coin it is
             if(gameObject.tag=="bundleCoins"){
                 camera.GetComponent<CameraScript>().playbundleCoinSound();
             }else{
                 camera.GetComponent<CameraScript>().playNormalCoinSound();
             }
             

             //increase score by 1
            GlobalVariables.currScore+=score;
            GlobalVariables.coinsCollected+=1;
            //  //destroy coin
             Destroy (this.gameObject);
         }
    }

    
}
