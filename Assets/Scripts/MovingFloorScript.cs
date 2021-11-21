using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingFloorScript : MonoBehaviour
{
    public bool playerHere;
    public float speed;

    public float movingSpeed;

    public float range;

    public float startingX;

    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        playerHere=false;
        startingX=this.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {   
        //calculate new x position using trig
        float nextXPosition= Mathf.Sin(Time.time*movingSpeed)* range + startingX;

        this.transform.position=new Vector3(nextXPosition,this.transform.position.y,this.transform.position.z);

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
             player=other.gameObject;
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
