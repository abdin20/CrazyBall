using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{   
    public GameObject player1;
    public GameObject player2;
    public GameObject mainPlayer;

    public Rigidbody playerRigidbody;
    public Animator playerAnimator;

    public int maxVelocity;

    // Start is called before the first frame update
    void Start()
    {   
        //get the player model that is active 
        if(GlobalVariables.skin1==true){
            mainPlayer=player1;
        }else{
            mainPlayer=player2;
        }

        //get components
        playerAnimator = mainPlayer.transform.GetChild(0).gameObject.GetComponent<Animator>();
        playerRigidbody = mainPlayer.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerRigidbody.velocity.magnitude>=0.01){
            playerAnimator.SetBool("isRunning", true);
        }else{
             playerAnimator.SetBool("isRunning", false);
        }
        
        //cap velocity so player isnt too hard to control
        if(playerRigidbody.velocity.sqrMagnitude > maxVelocity){
            playerRigidbody.velocity *= 0.99f;
        }
    }
}
