using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    private bool built = false;
    private bool work = false;
    private bool notMoney = false;
    private float timeChange = 0.0f;
    private Color color1;
    void Start()
    {
        ColorUtility.TryParseHtmlString("#13760C", out color1);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (!built)
            {
                if (work)
                {
                    if (GameManager.instance.getRockCost() <= GameManager.instance.rock && GameManager.instance.getWoodCost() <= GameManager.instance.wood)
                    {
                        GameManager.instance.wood -= GameManager.instance.getWoodCost();
                        GameManager.instance.rock -= GameManager.instance.getRockCost();
                        Quaternion rot = Quaternion.Euler(0, 30, 0);
                        GameObject temp = Instantiate(GameManager.instance.getBuilding(), this.transform.position, rot);
                        Vector3 position = new Vector3(this.transform.position.x, this.transform.position.y + (temp.GetComponent<Collider>().bounds.size.y / 2), this.transform.position.z);
                        temp.transform.position = position;
                        built = true;
                        Debug.Log("New Build");
                        GameManager.instance.playAudio(true);
                        GameManager.instance.spawnMS();
                    }
                    else
                    {
                        gameObject.GetComponent<Renderer>().material.color = new Color(0.78f, 0, 0, 1);
                        notMoney = true;
                        timeChange = 0.0f;
                        GameManager.instance.playAudio(false);
                    }
                }
            }
        }
        if (notMoney)
        {
            timeChange += Time.deltaTime;
            if(timeChange >= 0.2f)
            {
                gameObject.GetComponent<Renderer>().material.color = color1;
                notMoney = false;
            }
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
