using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCalculator 
{

    public int CalculateScore(int mode, int wallsPassed)
    {
        return mode * wallsPassed;
    }
}
