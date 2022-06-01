using System;
using UnityEngine;

public class Garage : MonoBehaviour
{
    [SerializeField] private GameObject[] levels;
    private int _currentLevel;

    public void Awake()
    {
        CartStats.MaxDurability = (_currentLevel+1) * 2;
        CartStats.MaxCargo = (_currentLevel+1) * 5;
        CartStats.MaxJewishModifier = (_currentLevel+1);
    }

    public void NextCar()
    {
        foreach (var level in levels) level.SetActive(false);
        try
        {
            _currentLevel++;
            levels[_currentLevel].SetActive(true);
        }
        catch (Exception)
        {
            _currentLevel = 0;
            levels[_currentLevel].SetActive(true);
        }
    }
    public void PreviousCar()
    {
        foreach (var level in levels) level.SetActive(false);
       
        try
        {
            _currentLevel--;
            levels[_currentLevel].SetActive(true);
        }
        catch (Exception)
        {
            _currentLevel = levels.Length-1;
            levels[_currentLevel].SetActive(true);
        }
    }

    public void DurabilityUp()
    {
        if (CartStats.Durability < CartStats.MaxDurability)
            CartStats.Durability += 1;
    }
    
    public void CargoUp()
    {
        if (CartStats.Cargo < CartStats.MaxCargo)
            CartStats.Cargo += 1;
    }
    
    public void JewishModifierUp()
    {
        if (CartStats.JewishModifier < CartStats.MaxJewishModifier)
            CartStats.JewishModifier += 1;
    }
}