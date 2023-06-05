using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Props : MonoBehaviour
{
    private bool work = false;
    public bool wood = false;
    public bool rock = false;
    public int cant;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && work)
        {
            if (wood)
            {
                GameManager.instance.wood += cant;
            }
            if (rock)
            {
                GameManager.instance.rock += cant;
            }
            Destroy(this.gameObject);
        }
    }
    private void OnMouseEnter()
    {
        work = true;
    }
    private void OnMouseExit()
    {
        work = false;
    }
}
