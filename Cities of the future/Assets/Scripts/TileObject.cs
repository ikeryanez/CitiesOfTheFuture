using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileObject : MonoBehaviour
{
    public Tile data;

    [Header("World Tile Data")]
    [Space(8)]

    public int x = 0;
    public int z = 0;

    private void OnMouseDown()
    {
        
        Debug.Log("Clicked on" + gameObject.name);

        if(!data.IsOccupied)
        {
            if(GameManager.Instance.buildingToPlace != null)
            {
                List<TileObject> iteratedTiles = new List<TileObject>();
                

                bool canPlaceBuildingHere = true;

                try
                {
                    for(int i = x; i < x+GameManager.Instance.buildingToPlace.data.width; i++)
                {
                    

                    if(canPlaceBuildingHere)
                    {
                        for(int j = z; j < z+GameManager.Instance.buildingToPlace.data.length; j++)
                        {
                            
                            iteratedTiles.Add(GameManager.Instance.tileGrid[x, z]);
                            if(GameManager.Instance.tileGrid[x,z].data.IsOccupied)
                            {
                                canPlaceBuildingHere = false;
                                break;
                            }

                        }
                                       

                    }
                    else
                    {
                        break;
                    }
                }

                }
                catch(System.IndexOutOfRangeException)
                {
                    Debug.Log("There were no tiles");
                    return;

                }


                
                if(canPlaceBuildingHere)
                {
                    GameManager.Instance.SpawnBuilding(GameManager.Instance.buildingToPlace, iteratedTiles);
                }
                else
                {
                    Debug.Log("Could not place building)");
                }             
            }         
        
            
        }
        else
        {
            Debug.Log("Building to place is null");
        }
        
    }
}
