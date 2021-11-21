using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointScript : MonoBehaviour
{    
    public int checkpointNumber;

    public GameObject mainCamera;
    // Start is called before the first frame update
    void Start()
    {   

    }

    // Update is called once per frame
    void Update()
    {   

    }

        //method to check if player is here on collision
    private void OnTriggerEnter(Collider other) {
        //check if player is colliding
         if(other.gameObject.tag=="Player"){

             //play sound effect with camera script
            mainCamera.GetComponent<CameraScript>().playCheckpointSound();
             //increase checkpoint counter by 1
             GlobalVariables.checkpoints=checkpointNumber;  
             Destroy(this.gameObject);
         }
    }
}
