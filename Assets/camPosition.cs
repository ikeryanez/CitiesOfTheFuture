using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camPosition : MonoBehaviour
{
    public GameObject cam1;
    public GameObject cam2;
    void Update()
    {
        if (GameManager.instance.city)
        {
            this.transform.position = cam1.transform.position;
        }
        else
            this.transform.position = cam2.transform.position;
    }
}
