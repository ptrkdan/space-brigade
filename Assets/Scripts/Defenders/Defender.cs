using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    [SerializeField] int energyCost = 50;

    public int GetEnergyCost() => energyCost;
}
