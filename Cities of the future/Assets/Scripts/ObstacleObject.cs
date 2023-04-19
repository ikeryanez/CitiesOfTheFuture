using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleObject : MonoBehaviour
{
    public TileObject refTile;
    public ObstacleType obstacleType;
    public int resourceAmount = 10;

    


    private void OnMouseDown()
    {
        Debug.Log("Clicked on " + gameObject.name);

        bool usedResource = false;

        switch(obstacleType)
        {
            case ObstacleType.Wood:
                
                usedResource = ResorceManager.Instance.AddWood(resourceAmount);
                break;

            case ObstacleType.Rock:
                
                usedResource = ResorceManager.Instance.AddStone(resourceAmount);
                break;
            

        }
        if(usedResource){
            refTile.data.cleanTile();
            Destroy(gameObject);
        }
        else{
            Debug.Log("could not destroy");
        }

        
    }
    public void SetTileReference(TileObject obj)
    {
        refTile = obj;

    }
    

    public enum ObstacleType
    {
        Wood,
        Rock
    }
}
