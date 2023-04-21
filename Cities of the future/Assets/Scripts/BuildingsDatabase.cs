using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingsDatabase : MonoBehaviour
{
    public List<Building> buildingsDatabase = new List<Building>();

    public static BuildingsDatabase Instance;

    private void Awake()
    {
        Instance = this;
    }

}
