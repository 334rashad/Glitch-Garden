using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] GameObject levelComplete;
    [SerializeField] float waitToLoad = 3f;
    int numberOfAttackers = 0;
    bool levelTimerFinished = false;

    private void Start()
    {
        levelComplete.SetActive(false);
    }

    public void AttackerSpawned()
    {
        numberOfAttackers++;
    }
    public void AttackerKilled()
    {
        numberOfAttackers--;
        if(numberOfAttackers <= 0 & levelTimerFinished)
        {
            StartCoroutine(LevelFinished());
        }
    }

    IEnumerator LevelFinished()
    {
        levelComplete.SetActive(true);
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(waitToLoad);
        FindObjectOfType<LevelLoader>().LoadNextScene();
    }

    public void LevelTimerFinished()
    {
        levelTimerFinished = true;
        StopSpawners();
    }

    private void StopSpawners()
    {
        AttackerSpawner[] spawnerAray = FindObjectsOfType<AttackerSpawner>();
        foreach (AttackerSpawner spawner in spawnerAray)
        {
            spawner.StopSpawning();
        }
    } 
}
