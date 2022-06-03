using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Garage : MonoBehaviour
{
    [SerializeField] private GameObject[] levels;
    [SerializeField] public Text moneyAmountText; 
    [SerializeField] public Text durabilityCostText;
    [SerializeField] public Text cargoCostText; 
    [SerializeField] public Text jewishText;
    private int currentLevel;
    private int jewishModifier;
    private bool isLevelCarOpen2; 

    public static List<CarStatDto> stats = new List<CarStatDto>();

    public void Awake()
    {
        CartStats.TotalMoneyAmount = 1000;

        var newcar = new CarStatDto(currentLevel);
        newcar.Durability = 1;
        newcar.Cargo = 1;
        stats.Add(newcar);
        moneyAmountText.text = CartStats.TotalMoneyAmount + " Руб.";
        durabilityCostText.text = stats[currentLevel].Durability + "/" + stats[currentLevel].maxDurability;
        cargoCostText.text = stats[currentLevel].Cargo + "/" + stats[currentLevel].maxCargo;
        jewishText.text = PlayerPrefs.GetInt("JewishModifier") + "!";
    }

    public void NextCar()
    {
        if (currentLevel + 1 >= levels.Length)
        {
            Debug.Log("леха иди вфоыьшщвфы");
            return;
        }

        foreach (var level in levels) level.SetActive(false);
        if (stats[currentLevel].Durability == stats[currentLevel].maxDurability && currentLevel < levels.Length)
        {
            currentLevel++;

            if (isLevelCarOpen2 == false)
            {
                var newcar = new CarStatDto(currentLevel);
                newcar.Durability = 1;
                newcar.Cargo = 1;
                stats.Add(newcar);
                isLevelCarOpen2 = true;
            }

            durabilityCostText.text = stats[currentLevel].Durability + "/" + stats[currentLevel].maxDurability;
            cargoCostText.text = stats[currentLevel].Cargo + "/" + stats[currentLevel].maxCargo;
        }

        levels[currentLevel].SetActive(true);
        durabilityCostText.text = stats[currentLevel].Durability + "/" + stats[currentLevel].maxDurability;
        cargoCostText.text = stats[currentLevel].Cargo + "/" + stats[currentLevel].maxCargo;
    }

    public void PreviousCar()
    {
        foreach (var level in levels) level.SetActive(false);

        if (currentLevel > 0) currentLevel--;

        levels[currentLevel].SetActive(true);
        durabilityCostText.text = stats[currentLevel].Durability + "/" + stats[currentLevel].maxDurability;
        cargoCostText.text = stats[currentLevel].Cargo + "/" + stats[currentLevel].maxCargo;
        jewishText.text = PlayerPrefs.GetInt("JewishModifier") + "!";
    }

    public void DurabilityUp()
    {
        if (stats[currentLevel].Durability < stats[currentLevel].maxDurability && CartStats.TotalMoneyAmount >= 50)
        {
            stats[currentLevel].Durability++;
            durabilityCostText.text = stats[currentLevel].Durability + "/" + stats[currentLevel].maxDurability;
            CartStats.TotalMoneyAmount -= 50;
            moneyAmountText.text = CartStats.TotalMoneyAmount + " Руб.";
        }
        else
        {
            durabilityCostText.color = Color.red;
        }
    }

    public void CargoUp()
    {
        if (stats[currentLevel].Cargo < stats[currentLevel].maxCargo && CartStats.TotalMoneyAmount >= 10)
        {
            stats[currentLevel].Cargo++;
            cargoCostText.text = stats[currentLevel].Cargo + "/" + stats[currentLevel].maxCargo;
            CartStats.TotalMoneyAmount -= 10;
            moneyAmountText.text = CartStats.TotalMoneyAmount + " Руб.";
        }
        else
        {
            cargoCostText.color = Color.red;
        }
    }

    public void JewishModifierUp()
    {
        if (CartStats.TotalMoneyAmount >= 150)
        {
            PlayerPrefs.SetInt("JewishModifier", PlayerPrefs.GetInt("JewishModifier") + 1);
            jewishText.text = PlayerPrefs.GetInt("JewishModifier") + "!";
            CartStats.TotalMoneyAmount -= 150;
            moneyAmountText.text = CartStats.TotalMoneyAmount + " Руб.";
        }
        else
        {
            jewishText.color = Color.red;
        }
    }

    public void LetsGo()
    {
        CartStats.Level = stats[currentLevel].Level;
        CartStats.Durability = stats[currentLevel].Durability;
        CartStats.Cargo = stats[currentLevel].Cargo;
        SceneManager.LoadScene("SampleScene");
    }
}