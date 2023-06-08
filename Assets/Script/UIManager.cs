using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public TMP_Text rock;
    public TMP_Text wood;
    public Mensaje mensege;
    public GameObject canvas;
    public Button bot;
    public Sprite city;
    public Sprite forest;
    public AudioSource aud;
    void Start()
    {
        rock.text = GameManager.instance.rock.ToString();
        wood.text = GameManager.instance.wood.ToString();
        newMensege("HOLA");
        aud.volume = ConfigManager.instance.musicVolum;
    }

    // Update is called once per frame
    void Update()
    {
        rock.text = GameManager.instance.rock.ToString();
        wood.text = GameManager.instance.wood.ToString();
    }
    public void newMensege(string mensaje)
    {
        //var temp = Instantiate(mensege).transform.parent = canvas.transform;
    }
    public void changeCity()
    {
        GameManager.instance.city = !GameManager.instance.city;
        if (GameManager.instance.city)
        {
            bot.image.sprite = city;
        }
        else
            bot.image.sprite = forest;
    }
}
