using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TMP_Text rock;
    public TMP_Text wood;
    public Mensaje mensege;
    public GameObject canvas;
    void Start()
    {
        rock.text = GameManager.instance.rock.ToString();
        wood.text = GameManager.instance.wood.ToString();
        newMensege("HOLA");
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
}
