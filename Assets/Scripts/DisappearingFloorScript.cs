using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearingFloorScript : MonoBehaviour
{
    public bool playerHere;
    public bool playerTouched;
    public float speed;

    public float lifeTime;
    public float elapsedTime;

    // Start is called before the first frame update
    void Start()
    {
        playerHere=false;
        playerTouched=false;
        elapsedTime=0f;
    }

    // Update is called once per frame
    void Update()
    {    
        //check if player has touched the floor
        if(playerTouched){
            
            //once player has touched floor once we start counting time
            elapsedTime+=Time.deltaTime;

            //check to see if floor was here for longer than lifespan since player got on 
            if(elapsedTime>=lifeTime){
            Destroy(this.gameObject);
         }
        }
      

        //if the player is here on the floor and we are unpaused
        if(playerHere && Time.timeScale==1f){

        //get input for both directions
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");


        //check for horizontal input, approximate 0
        bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0f);
        bool hasVerticalInput = !Mathf.Approximately(vertical, 0f);

        if(!hasHorizontalInput) horizontal=0f;
        if(!hasVerticalInput) vertical=0f;

        //rotate vector
        var rotateVector = new Vector3(vertical, 0.0f, -horizontal);

        //rotate the floor accordingly
        this.transform.Rotate(rotateVector * speed * Time.deltaTime); 

     

        }
    }

    //method to check if player is here on collision
    private void OnCollisionEnter(Collision other) {
        //check if player is here
         if(other.gameObject.tag=="Player"){
             this.playerHere=true;
             this.playerTouched=true;    
         }
    }


    public void OnCollisionExit(Collision other)
    {
        //check if player left current floor
         if(other.gameObject.tag=="Player"){
             this.playerHere=false;    
         }
    }
}
