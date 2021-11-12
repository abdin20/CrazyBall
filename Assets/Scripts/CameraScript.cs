using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public GameObject mainPlayer;
    public Vector3 playerDistance;
    // Start is called before the first frame update
    void Start()
    {      
        //figure out which player skin is active
        if(GlobalVariables.skin1==true){
            player1.SetActive(true);
            player2.SetActive(false);
            mainPlayer=player1;
        }else{
            player1.SetActive(false);
            player2.SetActive(true);
            mainPlayer=player2;
        }   
            //get offset of camera
          playerDistance=(this.transform.position-mainPlayer.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position=mainPlayer.transform.position+playerDistance;
    }
}
