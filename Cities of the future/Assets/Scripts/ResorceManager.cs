using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResorceManager : MonoBehaviour
{
    [Header("Resources")] 
    
    public int maxWood;
    public int maxStone;
    public int maxPc;
    public int maxSc;
    
    public int wood = 0;
    public int stone = 0;
    public int premiumCurrency = 0;
    public int standardCurrency = 0;

    public static ResorceManager Instance;

    public bool debugBool = false;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if(debugBool)
        {
            PrintCurrentResources();
            debugBool = false;

        }
    }

    public void AddWood(int woodToAdd)
    {
        wood += woodToAdd;
    }
    
    public void AddStone(int stoneToAdd)
    {
        stone += stoneToAdd;
    }
    
    public void AddStandardCurrency(int standardCurrencyToAdd)
    {
        standardCurrency += standardCurrencyToAdd;
    }
    
    public void AddPremiumCurrency(int premiumCurrencyToAdd)
    {
        premiumCurrency += premiumCurrencyToAdd;
    }
    void PrintCurrentResources()
    {
        Debug.Log("wood" + wood);
        Debug.Log("stone" + stone);
        Debug.Log("standard" + standardCurrency);
        Debug.Log("premium" + premiumCurrency);

    }


}
