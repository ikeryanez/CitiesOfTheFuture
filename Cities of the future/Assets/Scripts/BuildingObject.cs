using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingObject : MonoBehaviour
{
    public Building data;

    [Header("Resource Generation")]
    [Space(8)]

    public float resource = 0;
    public float resourceLimit = 100;
    public float generationSpeed = 5;

    Coroutine buildingBehaviour;

   

    private void Start()
    {
        if(data.resourceType == Building.ResourceType.Standard || data.resourceType==Building.ResourceType.Premium){
            buildingBehaviour = StartCoroutine(CreateResource());

        }
        if(data.resourceType == Building.ResourceType.Storage){
            IncreaseMaxStorage();

        }

    }

    private void OnMouseDown()
    {
        if(data.resourceType == Building.ResourceType.Storage){
            return;
        }
        switch(data.resourceType)
        {
            case Building.ResourceType.Standard:
                ResorceManager.Instance.AddStandardCurrency((int)resource);
                break;
            case Building.ResourceType.Premium:
                ResorceManager.Instance.AddPremiumCurrency((int)resource);
                break;
        }
        EmptyResource();

    }

    void EmptyResource()
    {
        resource = 0;
    }
    void IncreaseMaxStorage()
    {
        switch(data.storageType)
        {
            case Building.StorageType.Wood:
                ResorceManager.Instance.IncreaseMaxWood((int)resource);
                break;
            case Building.StorageType.Stone:
                ResorceManager.Instance.IncreaseMaxStone((int)resource);
                break;

        }
    }

    IEnumerator CreateResource()
    {
        while(true)
            {
                if(resource<resourceLimit)
                {
                    resource += generationSpeed * Time.deltaTime;
                }
                else{
                    resource = resourceLimit;
                }

            }
            yield return null;
                  
    }
}
