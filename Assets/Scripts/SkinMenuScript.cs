using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SkinMenuScript : MonoBehaviour
{   
    public GameObject buttonOneText;
    public GameObject buttonTwoText;
    public GameObject balanceText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {    
        //show balance 
        balanceText.GetComponent<TMP_Text>().text="Balance: " + GlobalVariables.savedScore.ToString();
        
        //change button1 text based on which skin is selected
        if(!GlobalVariables.skin1){
            buttonOneText.GetComponent<TMP_Text>().text="Already Selected";
        }else{
            buttonOneText.GetComponent<TMP_Text>().text="Select Skin";
        }

        //if skin1 isnt bought and score isnt enough 
        if(GlobalVariables.savedScore<50 && !GlobalVariables.boughtSkin1){
            buttonTwoText.GetComponent<TMP_Text>().text="Need 50 coins to buy";
        }
        //if skin1 isnt bought and score is enough
        if(GlobalVariables.savedScore>=50 && !GlobalVariables.boughtSkin1){
            buttonTwoText.GetComponent<TMP_Text>().text="Buy Skin for 50";
        }

        //if skin is bought and skin isnt enabled
        if(GlobalVariables.boughtSkin1 && !GlobalVariables.skin1){
             buttonTwoText.GetComponent<TMP_Text>().text="Select Skin";
        }else if(GlobalVariables.boughtSkin1 && GlobalVariables.skin1){
             buttonTwoText.GetComponent<TMP_Text>().text="Already Selected";
        }
    }

    //method for pressing first button
    public void pressButtonOne(){
        if(GlobalVariables.skin1){
            GlobalVariables.skin1=false;
        }
    }

    //method for pressing second button
    public void pressButtonTwo(){

        //if enough money to buy and not bought before
        if(GlobalVariables.savedScore>=50 && !GlobalVariables.boughtSkin1){
            GlobalVariables.boughtSkin1=true;
            GlobalVariables.skin1=true;
            GlobalVariables.savedScore-=50; //update balance 
        }
        
        //if already bought and not selected
        if(GlobalVariables.boughtSkin1 && !GlobalVariables.skin1){
            GlobalVariables.skin1=true;
        }
    }
}
