using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class HUDScript : MonoBehaviour
{   
    public GameObject checkpointsCounter;
    // Start is called before the first frame update
    void Start()
    {   
        //gameobject holding checkpoint text
        checkpointsCounter = this.gameObject.transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
         checkpointsCounter.GetComponent<TMP_Text>().text="Checkpoint: "+GlobalVariables.checkpoints.ToString();
    }
}
