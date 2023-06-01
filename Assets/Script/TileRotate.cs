using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileRotate : MonoBehaviour
{
    private bool work = false;
    public float startRotateY = 30;
    public float ajustY = 0;
    void Start()
    {
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + ajustY, this.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            if (work)
            {
                Debug.Log("MuroRota");
                startRotateY += 30;
                if (startRotateY >= 360)
                    startRotateY -= 360;
                Quaternion rot = Quaternion.Euler(0, startRotateY, 0);
                this.transform.rotation = rot;
            }
        }
    }
    private void OnMouseEnter()
    {
        work = true;
        Debug.Log("MuroEntra");
    }
    private void OnMouseExit()
    {
        work = false;
        Debug.Log("MuroSale");
    }
}
