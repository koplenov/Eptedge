using System;
using UnityEngine;
using UnityEngine.UI;

public class Garage : MonoBehaviour
{
    [SerializeField] private GameObject[] levels;
    private int _currentLevel;
    private bool _isLevelCarOpen2 = false;
    public Text MoneyAmountText;
    public Text DurabilityCostText;
    public Text CargoCostText;
    public Text JewishText;

    public void Awake()
    {
        CartStats.MaxDurability = (_currentLevel + 1) * 2;
        CartStats.MaxCargo = (_currentLevel + 1) * 5;
        CartStats.MaxJewishModifier = (_currentLevel + 1) * 2;
        MoneyAmountText.text = CartStats.TotalMoneyAmount + " $";
        DurabilityCostText.text = CartStats.Durability + "/" + CartStats.MaxDurability;
        CargoCostText.text = CartStats.Cargo + "/" + CartStats.MaxCargo;
        JewishText.text = CartStats.JewishModifier + "/" + CartStats.MaxJewishModifier;
    }

    public void NextCar()
    {
        foreach (var level in levels) level.SetActive(false);
        if (CartStats.Durability == CartStats.MaxDurability && _currentLevel < levels.Length) 
        {
            _currentLevel++;
            levels[_currentLevel].SetActive(true);

            if (_isLevelCarOpen2 == false)
            {
                CartStats.Durability = _currentLevel + 1;
                CartStats.Cargo = _currentLevel + 1;
                CartStats.JewishModifier = _currentLevel + 1;
                _isLevelCarOpen2 = true;
                DurabilityCostText.text = CartStats.Durability + "/" + CartStats.MaxDurability;
                CargoCostText.text = CartStats.Cargo + "/" + CartStats.MaxCargo;
                JewishText.text = CartStats.JewishModifier + "/" + CartStats.MaxJewishModifier;
            }
        }
        else
        {
            levels[_currentLevel].SetActive(true);
        }
    }

    public void PreviousCar()
    {
        foreach (var level in levels) level.SetActive(false);
       
          if (_currentLevel > 0)
          {
            _currentLevel--;
            levels[_currentLevel].SetActive(true);
        }
        else
        {
            levels[_currentLevel].SetActive(true);
        }
    }

    public void DurabilityUp()
    {
        if (CartStats.Durability < CartStats.MaxDurability && CartStats.TotalMoneyAmount >= 50)
        {
            CartStats.Durability += 1;
            DurabilityCostText.text = CartStats.Durability + "/" + CartStats.MaxDurability;
            CartStats.TotalMoneyAmount -= 50;
            MoneyAmountText.text = CartStats.TotalMoneyAmount + " $";
        }
        else
        {
            DurabilityCostText.color = Color.red;
        }
    }

    public void CargoUp()
    {
        if (CartStats.Cargo < CartStats.MaxCargo && CartStats.TotalMoneyAmount >= 10)
        {
            CartStats.Cargo += 1;
            CargoCostText.text = CartStats.Cargo + "/" + CartStats.MaxCargo;
            CartStats.TotalMoneyAmount -= 10;
            MoneyAmountText.text = CartStats.TotalMoneyAmount + " $";
        }
        else
        {
            CargoCostText.color = Color.red;
        }
    }

    public void JewishModifierUp()
    {
        if (CartStats.JewishModifier < CartStats.MaxJewishModifier && CartStats.TotalMoneyAmount >= 150)
        {
            CartStats.JewishModifier += 1;
            JewishText.text = CartStats.JewishModifier + "/" + CartStats.MaxJewishModifier;
            CartStats.TotalMoneyAmount -= 150;
            MoneyAmountText.text = CartStats.TotalMoneyAmount + " $";
        }
        else
        {
            JewishText.color = Color.red;
        }
    }
}