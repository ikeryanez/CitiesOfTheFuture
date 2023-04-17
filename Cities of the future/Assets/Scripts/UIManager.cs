using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [Header("References")]
    [Space(8)]
    public StandardUIReference woodUI;
    public StandardUIReference stoneUI;
    public StandardUIReference standardCUI;
    public StandardUIReference premiumCUI;

    public static UIManager Instance;

    private void Awake()
    {
        Instance = this;

    }
private void Start()
{
    UpdateAll();
}

    public void UpdateWoodUI(int currentAmount, int maxAmount)
    {
        woodUI.currentUI.text = currentAmount.ToString();
        woodUI.maxUI.text = "MAX: " + maxAmount.ToString();

        woodUI.slider.value = currentAmount;
        woodUI.slider.maxValue = maxAmount;

    }
    public void UpdateStoneUI(int currentAmount, int maxAmount)
    {
        stoneUI.currentUI.text = currentAmount.ToString();
        stoneUI.maxUI.text = "MAX: " + maxAmount.ToString();

        stoneUI.slider.value = currentAmount;
        stoneUI.slider.maxValue = maxAmount;

    }
    public void UpdateStandardCUI(int currentAmount, int maxAmount)
    {
        standardCUI.currentUI.text = currentAmount.ToString();
        standardCUI.maxUI.text = "MAX: " + maxAmount.ToString();

        standardCUI.slider.value = currentAmount;
        standardCUI.slider.maxValue = maxAmount;

    }
    public void UpdatePremiumCUI(int currentAmount, int maxAmount)
    {
        premiumCUI.currentUI.text = currentAmount.ToString();
        premiumCUI.maxUI.text = "MAX: " + maxAmount.ToString();

        premiumCUI.slider.value = currentAmount;
        premiumCUI.slider.maxValue = maxAmount;

    }
    void UpdateAll()
    {
        UpdateWoodUI(ResorceManager.Instance.wood, ResorceManager.Instance.maxWood);
        UpdateStoneUI(ResorceManager.Instance.stone, ResorceManager.Instance.maxStone);
        UpdateStandardCUI(ResorceManager.Instance.standardCurrency, ResorceManager.Instance.maxSc);
        UpdatePremiumCUI(ResorceManager.Instance.premiumCurrency, ResorceManager.Instance.maxPc);
    }

    [System.Serializable]
    public class StandardUIReference
    {
        public Slider slider;
        public TextMeshProUGUI maxUI;
        public TextMeshProUGUI currentUI;
    }
}
