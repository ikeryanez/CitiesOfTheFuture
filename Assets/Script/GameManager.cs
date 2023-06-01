using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject[] buildings;
    public UIManager canvas;
    public int[] rockCost;
    public int[] woodCost;
    private int buildID = 0;
    public int rock = 0;
    public int wood = 0;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
            Destroy(this);

        DontDestroyOnLoad(this);
    }
    
    public void setBuildId(int _id)
    {
        buildID = _id;
    }
    public GameObject getBuilding()
    {
        return buildings[buildID];
    }
    public int getRockCost()
    {
        return rockCost[buildID];
    }
    public int getWoodCost()
    {
        return woodCost[buildID];
    }
}
