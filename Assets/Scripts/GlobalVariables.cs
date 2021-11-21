using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalVariables
{    
    
    //keep track of which skin is selected
    public static bool skin1=false;
    public static bool boughtSkin1=false;

    //reset to 0 on full restart
    //keep same on soft restart
    public static int checkpoints=0; 

    //reset 0 on full restart
    //keep same on soft restart
    public static int currScore=0;

    //game timer variable
    public static float gameTimer=0f;

    //update after every complete game
    public static int savedScore=9999; //balance used in shop

    //reset to 3 on full restart
    public static int ringsLeft=3;

    //reset to false on full restart
    public static bool ringStarted=false;
    //reset to 10.0f on full restart
    public static float timeRemaining=10.0f;

    //variable to keep track of magnet and ability
    public static bool boughtMagnetOne=false;
    public static bool magnetLevelOne=false;
    public static bool boughtMagnetTwo=false;
    public static bool magnetLevelTwo=false;
    public static bool boughtPlayerAbility=false;
    public static bool playerAbility=false;

    //reset always
    public static float abilityTimer=3f;
    //reset always
    public static float cooldownTimer=10f;
    //reset always
    public static float cooldownRunTime=10f;

    public static bool expertMode=false;
    //number of coins in game
    public static float coinsCollected=0;



}
