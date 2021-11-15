using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{    
    //variable to set rotatespeed
    public int rotateSpeed;

    public int score;

    public AudioSource audioData;
    // Start is called before the first frame update
    void Start()
    {   
        //get audio source component
        audioData = GetComponent<AudioSource>();
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
             //play sound effect
             audioData.Play(0);

             //increase score by 1
             GlobalVariables.currScore+=score;  
            //  //destroy coin
             Destroy (this.gameObject,audioData.clip.length);
         }
    }

    
}
