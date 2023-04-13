using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogicVolume : MonoBehaviour
{
    public Slider slider;
    public float sliderValue;
    public Image imagenMute;


    // Start is called before the first frame update
    void Start()
    {
        slider.value = PlayerPrefs.GetFloat("volumenAudio", 0.5f);
        AudioListener.volume = slider.value;
        RevisarMute();
            
    }

    public void changeSlider(float valor)
    {
        sliderValue = valor;
        PlayerPrefs.SetFloat("volumenAudio", sliderValue);
        AudioListener.volume = sliderValue;
        RevisarMute();
    }

    public void RevisarMute()
    {
        if(sliderValue == 0){
            imagenMute.enabled = true;
        }else{
            imagenMute.enabled = false;
        }
    }


}
