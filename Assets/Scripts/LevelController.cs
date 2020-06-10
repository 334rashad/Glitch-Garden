using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    int numberOfAttackers = 0;
    bool levelTimerFinished = false;

    public void AttackerSpawned()
    {
        numberOfAttackers++;
    }
    public void AttackerKilled()
    {
        numberOfAttackers--;
        if(numberOfAttackers <= 0 & levelTimerFinished)
        {
            Debug.Log("End of Level");
        }
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
