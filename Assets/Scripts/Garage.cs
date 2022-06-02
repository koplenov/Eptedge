using System;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    public static List<CarStatDto> stats = new List<CarStatDto>();

    public void Awake()
    {
        CartStats.TotalMoneyAmount = 1000;
        
        var newcar = new CarStatDto(_currentLevel);
        newcar.Durability = 1;
        newcar.Cargo = 1;
        newcar.JewishModifier = 1;
        
        stats.Add(newcar);
        
        MoneyAmountText.text = CartStats.TotalMoneyAmount + " $";
        DurabilityCostText.text = stats[_currentLevel].Durability + "/" + stats[_currentLevel].maxDurability;
        CargoCostText.text = stats[_currentLevel].Cargo + "/" + stats[_currentLevel].maxCargo;
        JewishText.text = stats[_currentLevel].JewishModifier + "/" + stats[_currentLevel].maxJewishModifier;
    }

    public void NextCar()
    {
        foreach (var level in levels) level.SetActive(false);
        if (stats[_currentLevel].Durability == stats[_currentLevel].maxDurability && _currentLevel < levels.Length)
        {
            _currentLevel++;

            if (_isLevelCarOpen2 == false)
            {
                var newcar = new CarStatDto(_currentLevel);
                newcar.Durability = 1;
                newcar.Cargo = 1;
                newcar.JewishModifier = 1;
                stats.Add(newcar);
                _isLevelCarOpen2 = true;
            }
            DurabilityCostText.text = stats[_currentLevel].Durability + "/" + stats[_currentLevel].maxDurability;
            CargoCostText.text = stats[_currentLevel].Cargo + "/" + stats[_currentLevel].maxCargo;
            JewishText.text = stats[_currentLevel].JewishModifier + "/" + stats[_currentLevel].maxJewishModifier;
        }
        levels[_currentLevel].SetActive(true);
        DurabilityCostText.text = stats[_currentLevel].Durability + "/" + stats[_currentLevel].maxDurability;
        CargoCostText.text = stats[_currentLevel].Cargo + "/" + stats[_currentLevel].maxCargo;
        JewishText.text = stats[_currentLevel].JewishModifier + "/" + stats[_currentLevel].maxJewishModifier;
    }

    public void PreviousCar()
    {
        foreach (var level in levels) level.SetActive(false);

        if (_currentLevel > 0)
        {
            _currentLevel--;
            levels[_currentLevel].SetActive(true);
            DurabilityCostText.text = stats[_currentLevel].Durability + "/" + stats[_currentLevel].maxDurability;
            CargoCostText.text = stats[_currentLevel].Cargo + "/" + stats[_currentLevel].maxCargo;
            JewishText.text = stats[_currentLevel].JewishModifier + "/" + stats[_currentLevel].maxJewishModifier;
        }
        else
        {
            levels[_currentLevel].SetActive(true);
            DurabilityCostText.text = stats[_currentLevel].Durability + "/" + stats[_currentLevel].maxDurability;
            CargoCostText.text = stats[_currentLevel].Cargo + "/" + stats[_currentLevel].maxCargo;
            JewishText.text = stats[_currentLevel].JewishModifier + "/" + stats[_currentLevel].maxJewishModifier;
        }
    }

    public void DurabilityUp()
    {
        if (stats[_currentLevel].Durability < stats[_currentLevel].maxDurability && CartStats.TotalMoneyAmount >= 50)
        {
            stats[_currentLevel].Durability++;
            DurabilityCostText.text = stats[_currentLevel].Durability + "/" + stats[_currentLevel].maxDurability;
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
        if (stats[_currentLevel].Cargo < stats[_currentLevel].maxCargo && CartStats.TotalMoneyAmount >= 10)
        {
            stats[_currentLevel].Cargo++;
            CargoCostText.text = stats[_currentLevel].Cargo + "/" + stats[_currentLevel].maxCargo;
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
        if (stats[_currentLevel].JewishModifier < stats[_currentLevel].maxJewishModifier &&
            CartStats.TotalMoneyAmount >= 150)
        {
            stats[_currentLevel].JewishModifier++;
            JewishText.text = stats[_currentLevel].JewishModifier + "/" + stats[_currentLevel].maxJewishModifier;
            CartStats.TotalMoneyAmount -= 150;
            MoneyAmountText.text = CartStats.TotalMoneyAmount + " $";
        }
        else
        {
            JewishText.color = Color.red;
        }
    }

    public void LetsGo()
    {
        CartStats.Level = stats[_currentLevel].Level;
        CartStats.Durability = stats[_currentLevel].Durability;
        CartStats.Cargo = stats[_currentLevel].Cargo;
        CartStats.JewishModifier = stats[_currentLevel].JewishModifier;
        SceneManager.LoadScene("SampleScene");
    }
}