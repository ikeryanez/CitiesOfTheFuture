using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject mensege;
    void Start()
    {

    }
    public void newSpawn()
    {
        GameObject newMens = Instantiate(mensege, transform.position, transform.rotation) as GameObject;
        newMens.transform.SetParent(GameObject.FindGameObjectWithTag("spawn").transform, false);
        newMens.transform.position = new Vector3(newMens.transform.position.x / 2, newMens.transform.position.y / 4f, 0);
        Destroy(newMens, 1);
    }
}
