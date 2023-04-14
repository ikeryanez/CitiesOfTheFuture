using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleObject : MonoBehaviour
{

    public ObstacleType obstacleType;
    public int resourceAmount = 10;


    private void OnMouseDown()
    {
        Debug.Log("Clicked on " + gameObject.name);
        switch(obstacleType)
        {
            case ObstacleType.Wood:
                ResorceManager.Instance.AddWood(resourceAmount);
                break;

            case ObstacleType.Rock:
                ResorceManager.Instance.AddStone(resourceAmount);
                break;
            

        }
    }

    public enum ObstacleType
    {
        Wood,
        Rock
    }
}
