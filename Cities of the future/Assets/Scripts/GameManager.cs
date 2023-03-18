using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Builder")]
    [Space(8)]

    public GameObject tilePreFab;

    public int levelWidth;
    public int levelLength;

    private void Start()
    {
        CreateLevel();
    }

    public void CreateLevel()
    {
        for(int x = 0, x < levelWidth, x++)
        {
            for(int z = 0, z < levelLength, z++)
            {
                SpawnTile(x, z);

            }

        }

    }
    TileObject SpawnTile(float xPos, float zPos)
    {
        GameObject tmpTile = Instantiate(tilePreFab);

        tmpTile.transform.position = new Vector3(xPos, 0, zPos);

        return tmpTile.GetComponent<TileObject>();
    }
}
