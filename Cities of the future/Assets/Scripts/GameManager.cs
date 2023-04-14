using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [Header("Level Builder")]

    public GameObject tilePrefab;

    public int levelWidth;
    public int levelLength;
    public Transform tilesHolder;
    public float tileSize = 1;
    public float tileEndHeight = 1;

    [Header("Resources")]
    
    public GameObject woodPrefab;
    public GameObject rockPrefab;

    [Range(0, 1)] public float obstacleChance = 0.3f;

    public int xBounds = 3;
    public int zBounds = 3;
    
    private void Start()
    {
        CreateLevel();
    }

    public void CreateLevel()
    {
        for (int i = 0; i < levelWidth; i++)
        {
            for (int j = 0; j < levelLength; j++)
            {
                TileObject spawnedTile = SpawnTile(i*tileSize, j*tileSize);
                if (i<xBounds || j<zBounds || j>= (levelLength-zBounds) || i>= (levelWidth-xBounds) ) 
                {
                    spawnedTile.data.StarterTileValue(false);
                }

                if (spawnedTile.data.CanSpawnObstacle)
                {
                    bool spawnObstacle = Random.value <= obstacleChance;
                    if (spawnObstacle)
                    {
                        spawnedTile.data.setOccupied(Tile.ObstacleType.Resource);
                        SpawnObstacle(spawnedTile.transform.position.x, spawnedTile.transform.position.z );
                        //Spawn obstacle
                        //Debug.Log("Spawned obstacle on " + spawnedTile.gameObject.name);

                        //spawnedTile.gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
                    }
                }
            }
        }
    }

    TileObject SpawnTile(float x, float z)
    {
        GameObject tile = Instantiate(tilePrefab);
        
        tile.transform.position = new Vector3(x, 0, z);
        tile.transform.SetParent(tilesHolder);

        tile.name = "Tile " + x + "-" + z;
            
        return tile.GetComponent<TileObject>();
    }

    public void SpawnObstacle(float x, float z)
    {
        bool isWood = Random.value <= 0.5f;
        GameObject spawnedObstacle = null;

        if(isWood)
        {
            spawnedObstacle = Instantiate(woodPrefab);
        

        }
        else
        {
            spawnedObstacle = Instantiate(rockPrefab);

        }
        spawnedObstacle.transform.position = new Vector3(x, tileEndHeight, z);
    }
}
