using System;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    const string DEFENDER_PARENT_NAME = "Defenders";

    GameObject defenderParent;
    [SerializeField] Defender selectedDefenderPrefab;

    private void Start()
    {
        CreateDefenderParent();
    }

    private void CreateDefenderParent()
    {
        defenderParent = GameObject.Find(DEFENDER_PARENT_NAME);
        if (!defenderParent)
        {
            defenderParent = new GameObject(DEFENDER_PARENT_NAME);
        }
    }

    private void OnMouseDown()
    {
        AttemptToPlaceDefender(GetSquareClicked());
    }

    public void SetSelectedDefender(Defender defenderPrefab)
    {
        selectedDefenderPrefab = defenderPrefab;
    }

    private Vector2 GetSquareClicked()
    {
        Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos);
        Vector2 gridPos = SnapToGrid(worldPos);

        return gridPos;
    }

    private Vector2 SnapToGrid(Vector2 worldPos)
    {
        int newX = Mathf.RoundToInt(worldPos.x);
        int newY = Mathf.RoundToInt(worldPos.y);

        return new Vector2(newX, newY);
    }

    private void AttemptToPlaceDefender(Vector2 gridPos)
    {
        if (!selectedDefenderPrefab) return;
        var energyManager = FindObjectOfType<EnergyManager>();
        int defenderCost = selectedDefenderPrefab.GetEnergyCost();

        if (energyManager.SpendEnergy(defenderCost))
        {
            SpawnDefender(gridPos);
        }
        else
        {
            // TODO Display "Not enough energy" message
        }

    }

    private void SpawnDefender(Vector2 gridPos)
    {
        Defender newDefender = Instantiate(selectedDefenderPrefab, gridPos, transform.rotation);
        newDefender.transform.parent = defenderParent.transform;
    }
}
