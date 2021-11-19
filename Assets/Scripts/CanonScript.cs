using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonScript : MonoBehaviour
{   
    public GameObject shootingPosition;

    //prefab that will be shot
    public GameObject bullet;
    public float shootingInterval;
    public float elapsedTime;

    public float thurstForce;
    // Start is called before the first frame update
    void Start()
    {
        elapsedTime=0f;
    }

    // Update is called once per frame
    void Update()
    {   
        //update elapsed time
        elapsedTime+=Time.deltaTime;
        //if past shooting interval canon must shoot
        if(elapsedTime>=shootingInterval){
            // Instantiate a bullet
            GameObject bulletTest= Instantiate(bullet, shootingPosition.transform.position, Quaternion.identity);
            bulletTest.transform.Rotate(0,-90,0);
            //add force to move bullet
            Rigidbody bulletRigidBody = bulletTest.GetComponent<Rigidbody>();
            bulletRigidBody.AddForce(transform.forward*thurstForce);

            //reset time after making bullet
            elapsedTime=0f;
        }
    }
}
