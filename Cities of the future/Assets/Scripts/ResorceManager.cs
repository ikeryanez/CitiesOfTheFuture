using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResorceManager : MonoBehaviour
{
    [Header("Resources")]
    [Space(8)] 
    
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

    public bool AddWood(int woodToAdd)
    {
        if((wood + woodToAdd) <= maxWood)
        {
        wood += woodToAdd;
        UIManager.Instance.UpdateWoodUI(wood, maxWood);

        return true;

        }
        else
        {
            return false;
        }
        
    }
    
    public bool AddStone(int stoneToAdd)
    {
        if((stone + stoneToAdd) <= maxStone)
        {
            stone += stoneToAdd;
            UIManager.Instance.UpdateStoneUI(stone, maxStone);
            return true;
        }
        else{
            return false;
        }
        
    }
    
    public bool AddStandardCurrency(int standardCurrencyToAdd)
    {
        if((standardCurrency + standardCurrencyToAdd) <= maxSc)
        {
            standardCurrency += standardCurrencyToAdd;
            UIManager.Instance.UpdateStandardCUI(standardCurrency, maxSc);
            return true;
        }
        else{
            return false;
        }
        
    }
    
    public bool AddPremiumCurrency(int premiumCurrencyToAdd)
    {
        if((premiumCurrency + premiumCurrencyToAdd) <= maxPc)
        {
            premiumCurrency += premiumCurrencyToAdd;
            UIManager.Instance.UpdatePremiumCUI(premiumCurrency, maxPc);
            return true;
        }
        else{
            return false;
        }
        
    }
    
    void PrintCurrentResources()
    {
        Debug.Log("wood" + wood);
        Debug.Log("stone" + stone);
        Debug.Log("standard" + standardCurrency);
        Debug.Log("premium" + premiumCurrency);

    }


}
