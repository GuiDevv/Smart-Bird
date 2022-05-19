using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreMoc
{
    public int calculatePlayerPoints(IPointCounter pointCounter)
    {
        return pointCounter.pipeCount * pointCounter.gamemode;
    }
}

public interface IPointCounter
{
    public int pipeCount { get; set; }
    public int gamemode { get; set; }
}
