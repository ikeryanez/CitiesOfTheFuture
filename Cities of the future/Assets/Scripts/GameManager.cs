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

    [Space(8)]
    public TileObject[,] tileGrid = new TileObject[0,0];

    [Header("Resources")]
    [Space(8)]
    
    public GameObject woodPrefab;
    public GameObject rockPrefab;
    public Transform resourcesHolder;

    [Range(0, 1)] public float obstacleChance = 0.3f;

    public int xBounds = 3;
    public int zBounds = 3;

    [Space(8)]

    public BuildingObject buildingToPlace;
    public static GameManager Instance;

    private void Awake()
    {
        Instance = this;
    }
    
    private void Start()
    {
        CreateLevel();
         
    }

    public void CreateLevel()
    {
        List<TileObject> visualGrid = new List<TileObject>();



        for (int x = 0; x < levelWidth; x++)
        {
            for (int z = 0; z < levelLength; z++)
            {
                TileObject spawnedTile = SpawnTile(x*tileSize, z*tileSize);
                spawnedTile.x = x;
                spawnedTile.z = z;



                if (x<xBounds || z<zBounds || z>= (levelLength-zBounds) || x>= (levelWidth-xBounds) ) 
                {
                    spawnedTile.data.StarterTileValue(false);
                }

                if (spawnedTile.data.CanSpawnObstacle)
                {
                    bool spawnObstacle = Random.value <= obstacleChance;
                    if (spawnObstacle)
                    {
                        spawnedTile.data.setOccupied(Tile.ObstacleType.Resource);

                        ObstacleObject tmpObstacle = SpawnObstacle(spawnedTile.transform.position.x, spawnedTile.transform.position.z );
                        tmpObstacle.SetTileReference(spawnedTile);


                
                        //Spawn obstacle
                        //Debug.Log("Spawned obstacle on " + spawnedTile.gameObject.name);

                        //spawnedTile.gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
                    }
                }
                visualGrid.Add(spawnedTile);
            }
        }

        CreateGrid(visualGrid);
    }

    TileObject SpawnTile(float x, float z)
    {
        GameObject tile = Instantiate(tilePrefab);
        
        tile.transform.position = new Vector3(x, 0, z);
        tile.transform.SetParent(tilesHolder);

        tile.name = "Tile " + x + "-" + z;
            
        return tile.GetComponent<TileObject>();
    }

    ObstacleObject SpawnObstacle(float x, float z)
    {
        bool isWood = Random.value <= 0.5f;
        GameObject spawnedObstacle = null;

        if(isWood)
        {
            spawnedObstacle = Instantiate(woodPrefab);
            spawnedObstacle.name = "Wood" + x + "-" + z;
        

        }
        else
        {
            spawnedObstacle = Instantiate(rockPrefab);
            spawnedObstacle.name = "Stone" + x + "-" + z;

        }
        spawnedObstacle.transform.position = new Vector3(x, tileEndHeight, z);
        spawnedObstacle.transform.SetParent(resourcesHolder);

        return spawnedObstacle.GetComponent<ObstacleObject>();
        
    }

    public void CreateGrid(List<TileObject> refVisualGrid)
    {
        tileGrid = new TileObject[levelWidth, levelLength];

        for(int x=0; x<levelWidth;x++)
        {
            for(int z=0; z<levelLength;z++)
            {
                tileGrid[x,z] = refVisualGrid.Find(v => v.x == x && v.z == z);
                //Debug.Log(tileGrid[x,z].gameObject.name);
            }
            

        }

       

    }
    public void SpawnBuilding(BuildingObject building, List<TileObject> tiles)
    {
        GameObject spawnedBuilding = Instantiate(building.gameObject);
        float sumX = 0;
        float sumZ = 0;

       
        for(int i = 0; i < tiles.Count ; i++){
            sumX += tiles[i].x;
            sumZ += tiles[i].z;

            tiles[i].data.setOccupied(Tile.ObstacleType.Building);
            Debug.Log("placed building in" + tiles[i].x + "-" + tiles[i].z);
            
        }
        Vector3 position = new Vector3((sumX/tiles.Count), tileEndHeight + building.data.yPadding, (sumZ/tiles.Count));

        spawnedBuilding.transform.position = position;
    }
}
