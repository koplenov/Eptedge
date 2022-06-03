using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Startup : MonoBehaviour
{
    void Start()
    {
        CartStats.Durability = 1;
        CartStats.Cargo = 1;
        PlayerPrefs.SetInt("JewishModifier", 1);
    }
}
