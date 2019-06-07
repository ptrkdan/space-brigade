using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaneSpawner : MonoBehaviour
{
    [SerializeField] Vector2 spawnDelayRange = new Vector2(1, 5);
    [SerializeField] List<Attacker> attackerPrefabList;

    bool spawn = true;

    private IEnumerator Start()
    {
        while (spawn)
        {
            yield return new WaitForSeconds(Random.Range(spawnDelayRange.x, spawnDelayRange.y));
            SpawnAttacker();
        }
    }

    public void StopSpawning()
    {
        spawn = false;
    }

    private void SpawnAttacker()
    {
        Attacker attackerPrefab = attackerPrefabList[Random.Range(0, attackerPrefabList.Count)];
        Spawn(attackerPrefab);
    }

    private void Spawn(Attacker attackerPrefab)
    {
        Attacker newAttacker = Instantiate(attackerPrefab, transform.position, transform.rotation);
        newAttacker.transform.parent = transform;
    }
}
