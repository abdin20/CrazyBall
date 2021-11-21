using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonBallScript : MonoBehaviour
{   
    public float lifeTime;
    public float elapsedTime;
    public Collider canonCollider;
    // Start is called before the first frame update
    void Start()
    {   
        elapsedTime=0f;
        canonCollider = GetComponent<Collider>();
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

    void OnCollisionEnter(Collision collision)
    {   
        //on collision with player, destroy only if ability is active
        if(collision.gameObject.tag=="Player" && GlobalVariables.playerAbility){
            Destroy(this.gameObject);
        }
    }
}
