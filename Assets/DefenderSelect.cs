using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DefenderSelect : MonoBehaviour
{
    [SerializeField] Defender defenderPrefab;

    private void Start()
    {
        SetCostLabel();
    }

    private void OnMouseDown()
    {
        ToggleDefenderButtonHighlight();
    }

    private void ToggleDefenderButtonHighlight()
    {
        DefenderSelect[] defenderSelects = FindObjectsOfType<DefenderSelect>();
        foreach(DefenderSelect defenderSelect in defenderSelects)
        {
            defenderSelect.GetComponent<Image>().color = Color.gray;
            defenderSelect.GetComponentInChildren<Image>().color = Color.gray;
        }

        GetComponent<Image>().color = Color.white;
        GetComponentInChildren<Image>().color = Color.white;

        FindObjectOfType<DefenderSpawner>().SetSelectedDefender(defenderPrefab);
    }

    private void SetCostLabel()
    {
        TextMeshProUGUI costLabel = GetComponentInChildren<TextMeshProUGUI>();
        costLabel.text = defenderPrefab.GetEnergyCost().ToString();
    }
}
