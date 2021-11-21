using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UpgradeMenuScript : MonoBehaviour
{   
    public GameObject magnetOneText;
    public GameObject magnetTwoText;
    public GameObject abilityText;
    public GameObject balanceText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        //update balance
         balanceText.GetComponent<TMP_Text>().text="Balance: " + GlobalVariables.savedScore.ToString();

        //check if player can buy level 1
         if(!GlobalVariables.boughtMagnetOne && GlobalVariables.savedScore<100){
            magnetOneText.GetComponent<TMP_Text>().text="100 coins for level 1 ";
         }else if(!GlobalVariables.boughtMagnetOne && GlobalVariables.savedScore>=100){
             magnetOneText.GetComponent<TMP_Text>().text="Buy Level 1 ";
         }
        
        //check if player can buy level 2 only if level 1 was bought already
         if(GlobalVariables.boughtMagnetOne && !GlobalVariables.boughtMagnetTwo && GlobalVariables.savedScore<500){
              magnetTwoText.GetComponent<TMP_Text>().text="500 coins for level 2";
         }else if(GlobalVariables.boughtMagnetOne && !GlobalVariables.boughtMagnetTwo && GlobalVariables.savedScore>=500){
             magnetTwoText.GetComponent<TMP_Text>().text="Buy Level 2 ";
         }

        //if magnetone is already enabled then its unlocked
         if(GlobalVariables.magnetLevelOne || GlobalVariables.magnetLevelTwo){
             magnetOneText.GetComponent<TMP_Text>().text="Unlocked level 1";
         }
         //if magnettwo is already enabled then its unlocked
         if(GlobalVariables.magnetLevelTwo){
             magnetTwoText.GetComponent<TMP_Text>().text="Unlocked level 2";
         }

                //check if player can buy destroy ability
         if(!GlobalVariables.boughtPlayerAbility && GlobalVariables.savedScore<250){
            abilityText.GetComponent<TMP_Text>().text="250 coins for destroy ability ";
         }else if(!GlobalVariables.boughtPlayerAbility && GlobalVariables.savedScore>=250){
             abilityText.GetComponent<TMP_Text>().text="Buy destroy ability ";
         }

        //if unlocked show on button
         if(GlobalVariables.boughtPlayerAbility){
             abilityText.GetComponent<TMP_Text>().text="Unlocked destroy ability ";
         }
         
    }

    public void magnetLevelOneButton(){

        //unlock magnet ability only if enough balance
        if(!GlobalVariables.boughtMagnetOne && GlobalVariables.savedScore>=100){
            GlobalVariables.boughtMagnetOne=true;
            GlobalVariables.magnetLevelOne=true;
            GlobalVariables.savedScore-=100;
        }
    }

    public void magnetLevelTwoButton(){
        //unlock magnet ability only if enough balance and already unlocked magnet 1
        if(GlobalVariables.boughtMagnetOne && !GlobalVariables.boughtMagnetTwo && GlobalVariables.savedScore>=500){
            GlobalVariables.boughtMagnetTwo=true;
            GlobalVariables.magnetLevelTwo=true;
            GlobalVariables.magnetLevelOne=false;
            GlobalVariables.savedScore-=500;
        }
    }

    public void destroyAbilityButton(){
        //unlock magnet ability only if enough balance
        if(!GlobalVariables.boughtPlayerAbility && GlobalVariables.savedScore>=250){
            GlobalVariables.boughtPlayerAbility=true;
            GlobalVariables.savedScore-=250;
        }
    }    
}
