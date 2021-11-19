using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingFloorScript : MonoBehaviour
{
    public bool playerHere;
    public float speed;

    public float movingSpeed;

    public float range;

    public float startingY;
    // Start is called before the first frame update
    void Start()
    {
        playerHere=false;
        startingY=this.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {   
        //calculate new y position using trig
        float nextYPosition= Mathf.Sin(Time.time*movingSpeed)* range + startingY;

        this.transform.position=new Vector3(this.transform.position.x,nextYPosition,this.transform.position.z);

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
