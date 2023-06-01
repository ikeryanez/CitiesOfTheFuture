using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Mensaje : MonoBehaviour
{
    public TMP_Text mense;
    public RectTransform rect;
    public void Start()
    {
        rect = GetComponent<RectTransform>();
        rect.offsetMax = new Vector2(0,0);
        rect.offsetMin = new Vector2(0,0);
        Destroy(this, 2);
    }
    public void newMensege(string _mense)
    {
        mense.text = _mense;
    }
}
