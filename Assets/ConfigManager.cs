using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigManager : MonoBehaviour
{
    public static ConfigManager instance;

    public float musicVolum = 1.0f;
    public float SFXVolum = 1.0f;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
            Destroy(this.gameObject);

        DontDestroyOnLoad(this);
    }
}
