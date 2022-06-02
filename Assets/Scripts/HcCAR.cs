using System;
using UnityEngine;

public class HcCAR : MonoBehaviour
{
    [SerializeField] private Transform wheelsFront;
    [SerializeField] private Transform wheelsBack;
    [SerializeField] private GameObject[] levels;

    private void Start()
    {
        foreach (var level in levels) level.SetActive(false);
        levels[CartStats.Level].SetActive(true);
    }

    void FixedUpdate()
    {
        wheelsFront.Rotate(Vector3.back, 5f);
        wheelsBack.Rotate(Vector3.back, 5f);
    }
}
