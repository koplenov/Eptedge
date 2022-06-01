using System;
using UnityEngine;

public class Garage : MonoBehaviour
{
    [SerializeField] private GameObject[] levels;
    private int _currentLevel;

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
}