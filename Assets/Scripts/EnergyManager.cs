using UnityEngine;
using TMPro;
using System;

public class EnergyManager : MonoBehaviour
{
    [SerializeField] int startingEnergy = 100;

    int currentEnergy;
    TextMeshProUGUI energyDisplay;

    private void Awake()
    {
        currentEnergy = startingEnergy;
        energyDisplay = GetComponentInChildren<TextMeshProUGUI>();
        SetEnergyDisplayText();
    }
    public void AddEnergy(int amount)
    {
        currentEnergy += amount;
        SetEnergyDisplayText();
    }

    public bool SpendEnergy(int amount)
    {
        if (amount > currentEnergy) return false;

        currentEnergy -= amount;
        SetEnergyDisplayText();

        return true;
    }

    private void SetEnergyDisplayText()
    {
        energyDisplay.text = currentEnergy.ToString();
    }

}
