using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalVariables
{   
    //keep track of which skin is selected
    public static bool skin1=true;

    //reset to 0 on full restart
    //keep same on soft restart
    public static int checkpoints=0; 

    //reset 0 on full restart
    //keep same on soft restart
    public static int currScore=0;

    //update after every complete game
    public static int savedScore=0; //balance used in shop

    //reset to 3 on full restart
    public static int ringsLeft=3;

    //reset to false on full restart
    public static bool ringStarted=false;
    //reset to 10.0f on full restart
    public static float timeRemaining=10.0f;

    //variable to keep track of magnet
    public static bool magnetLevelOne=false;

    public static bool magnetLevelTwo=true;



}
