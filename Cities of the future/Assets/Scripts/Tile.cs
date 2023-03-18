using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Tile
{
    public Building buildingRef;
    public bool occupied;
    public ObstacleType obstacleType;
    
    public enum ObstacleType
    {
        None,
        Resource,
        Building
    }

    public void setOccupied(ObstacleType t)
    {
        occupied = true;
        obstacleType = t;

    }

    public void setOccupied(ObstacleType t, Building b)
    {
        occupied = true;
        obstacleType = t;

        buildingRef = b;

    }

    public void cleanTile()
    {
        obstacleType = ObstacleType.None;
        occupied = false;

    }

}
