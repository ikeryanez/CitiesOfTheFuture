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
    public bool city = true;
    public AudioSource aud;
    public AudioClip BuildSound;
    public AudioClip failedBuild;
    public Spawn spawn;
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
    public void Start()
    {
        aud.volume = ConfigManager.instance.SFXVolum;
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
    public void playAudio(bool build)
    {
        if (build)
        {
            aud.clip = BuildSound;
            aud.Play();
        }
        else
        {
            aud.clip = failedBuild;
            aud.Play();
        }
    }
    public void spawnMS()
    {
        spawn.newSpawn();
    }
}
