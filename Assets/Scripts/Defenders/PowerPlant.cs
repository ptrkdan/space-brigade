using UnityEngine;

public class PowerPlant : MonoBehaviour
{
    public void AddEnergy(int amount)
    {
        FindObjectOfType<EnergyManager>().AddEnergy(amount);
    }
}
