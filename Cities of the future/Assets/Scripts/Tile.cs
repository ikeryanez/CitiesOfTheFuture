using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Tile
{
    public Building buildingRef;
    public ObstacleType obstacleType;
    bool isStarterTile = true;
    
    public enum ObstacleType
    {
        None,
        Resource,
        Building
    }

    public void setOccupied(ObstacleType t)
    {
        obstacleType = t;

    }

    public void setOccupied(ObstacleType t, Building b)
    {
        obstacleType = t;

        buildingRef = b;

    }

    public void cleanTile()
    {
        obstacleType = ObstacleType.None;

    }

    public void StarterTileValue(bool value)
    {
        isStarterTile = value;
    }

    public bool IsOccupied
    {
        get
        {
            return obstacleType != ObstacleType.None;
        }
    }

    public bool CanSpawnObstacle
    {
        get
        {
            return !isStarterTile;
        }
    }
}
