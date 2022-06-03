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
    private int JewishModifier;
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
        stats.Add(newcar);
        MoneyAmountText.text = CartStats.TotalMoneyAmount + " Руб.";
        DurabilityCostText.text = stats[_currentLevel].Durability + "/" + stats[_currentLevel].maxDurability;
        CargoCostText.text = stats[_currentLevel].Cargo + "/" + stats[_currentLevel].maxCargo;
        JewishText.text = PlayerPrefs.GetInt("JewishModifier") + "!";
    }

    public void NextCar()
    {
        if (_currentLevel+1 >= levels.Length)
        {
            Debug.Log("леха иди вфоыьшщвфы");
            return;
        }
        
        foreach (var level in levels) level.SetActive(false);
        if (stats[_currentLevel].Durability == stats[_currentLevel].maxDurability && _currentLevel < levels.Length)
        {
            _currentLevel++;

            if (_isLevelCarOpen2 == false)
            {
                var newcar = new CarStatDto(_currentLevel);
                newcar.Durability = 1;
                newcar.Cargo = 1;
                stats.Add(newcar);
                _isLevelCarOpen2 = true;
            }
            DurabilityCostText.text = stats[_currentLevel].Durability + "/" + stats[_currentLevel].maxDurability;
            CargoCostText.text = stats[_currentLevel].Cargo + "/" + stats[_currentLevel].maxCargo;
        }
        levels[_currentLevel].SetActive(true);
        DurabilityCostText.text = stats[_currentLevel].Durability + "/" + stats[_currentLevel].maxDurability;
        CargoCostText.text = stats[_currentLevel].Cargo + "/" + stats[_currentLevel].maxCargo;
    }

    public void PreviousCar()
    {
        foreach (var level in levels) level.SetActive(false);

        if (_currentLevel > 0) _currentLevel--;

            levels[_currentLevel].SetActive(true);
            DurabilityCostText.text = stats[_currentLevel].Durability + "/" + stats[_currentLevel].maxDurability;
            CargoCostText.text = stats[_currentLevel].Cargo + "/" + stats[_currentLevel].maxCargo;
            JewishText.text = PlayerPrefs.GetInt("JewishModifier") + "!";
       
    }

    public void DurabilityUp()
    {
        if (stats[_currentLevel].Durability < stats[_currentLevel].maxDurability && CartStats.TotalMoneyAmount >= 50)
        {
            stats[_currentLevel].Durability++;
            DurabilityCostText.text = stats[_currentLevel].Durability + "/" + stats[_currentLevel].maxDurability;
            CartStats.TotalMoneyAmount -= 50;
            MoneyAmountText.text = CartStats.TotalMoneyAmount + " Руб.";
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
            MoneyAmountText.text = CartStats.TotalMoneyAmount + " Руб.";
        }
        else
        {
            CargoCostText.color = Color.red;
        }
    }

    public void JewishModifierUp()
    {
        if (CartStats.TotalMoneyAmount >= 150)
        {
            PlayerPrefs.SetInt("JewishModifier",PlayerPrefs.GetInt("JewishModifier")+1);
            JewishText.text = PlayerPrefs.GetInt("JewishModifier") + "!";
            CartStats.TotalMoneyAmount -= 150;
            MoneyAmountText.text = CartStats.TotalMoneyAmount + " Руб.";
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
        SceneManager.LoadScene("SampleScene");
    }
}