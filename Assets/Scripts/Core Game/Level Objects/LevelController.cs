using System;
using System.Collections;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] Canvas levelFailCanvas;
    [SerializeField] Canvas levelCompleteCanvas;
    [SerializeField] float levelCompleteDelayInSeconds = 3f;

    int numAttackers = 0;
    bool isLevelTimerFinished = false;

    private void Start()
    {
        Time.timeScale = 1;
        levelCompleteCanvas?.gameObject.SetActive(false);
        levelFailCanvas?.gameObject.SetActive(false);
    }

    public void AttackerSpawned()
    {
        numAttackers++;
    }

    public void AttackerKilled()
    {
        numAttackers--;
        if (numAttackers <= 0 && isLevelTimerFinished)
        {
            StartCoroutine(HandleWinCondition());
        }
    }

    IEnumerator HandleWinCondition()
    {
        levelCompleteCanvas?.gameObject.SetActive(true);
        yield return new WaitForSeconds(levelCompleteDelayInSeconds);
        FindObjectOfType<LevelLoader>().GoToMainMenu();         // TODO Load next level
    }

    public void HandleLoseCondition()
    {
        levelFailCanvas?.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void LevelTimerFinished()
    {
        isLevelTimerFinished = true;
        StopSpawners();
    }

    private void StopSpawners()
    {
        LaneSpawner[] spawners = FindObjectsOfType<LaneSpawner>();
        foreach (LaneSpawner spawner in spawners)
        {
            spawner.StopSpawning();
        }
    }
}
