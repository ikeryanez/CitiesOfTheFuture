using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public Slider music;
    public Slider sfx;
    public AudioSource aud;
    private bool block = false;

    private void Awake()
    {
        music.value = ConfigManager.instance.musicVolum;
        sfx.value = ConfigManager.instance.SFXVolum;
        aud = GetComponent<AudioSource>();
        aud.volume = ConfigManager.instance.musicVolum;
    }
    private void Start()
    {
        block = true;
    }
    public void changeSlide()
    {
        if (block)
        {
            ConfigManager.instance.musicVolum = music.value;
            ConfigManager.instance.SFXVolum = sfx.value;
            aud.volume = ConfigManager.instance.musicVolum;
        }
    }
    public void quit()
    {
        Application.Quit();
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
}
