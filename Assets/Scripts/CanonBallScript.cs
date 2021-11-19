using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonBallScript : MonoBehaviour
{   
    public float lifeTime;
    public float elapsedTime;
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

        //self destruct canonballs after lifetime
        if(elapsedTime>=lifeTime){
            Destroy(this.gameObject);
        }
    }
}
