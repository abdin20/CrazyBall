using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonBallScript : MonoBehaviour
{   
    public float lifeTime;
    public float elapsedTime;
    public Collider canonCollider;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {   
        elapsedTime=0f;
        canonCollider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {   
        //get player gameobject
         player=GameObject.FindWithTag("Player");
        //update elapsed time
        elapsedTime+=Time.deltaTime;

        float playerDistance=Vector3.Distance(this.transform.position,player.transform.position);
        Debug.Log(playerDistance);

        //if within distance of player destroy itself if ability is active
        if(playerDistance<=2f && GlobalVariables.playerAbility){
            Destroy(this.gameObject);
        }
        //self destruct canonballs after lifetime
        if(elapsedTime>=lifeTime){
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {   

    }
}
