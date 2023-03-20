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
                SpawnTile(i*tileSize, j*tileSize);
            }
        }
    }

    TileObject SpawnTile(float x, float z)
    {
        GameObject tile = Instantiate(tilePrefab);
        tile.transform.position = new Vector3(x, 0, z);
        tile.transform.SetParent(tilesHolder);
        return tile.GetComponent<TileObject>();
    }
}
