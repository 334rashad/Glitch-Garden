﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{

    bool spawn = true;
    [SerializeField] float minSpawnDelay = 1f;
    [SerializeField] float maxSpawnDelay = 5f;
    [SerializeField] Attacker[] attackerTypeArray;



    // Start is called before the first frame update
    IEnumerator Start()
    {
        while (spawn)
        {
            yield return new WaitForSeconds(UnityEngine.Random.Range(minSpawnDelay, maxSpawnDelay - PlayerPrefController.GetDifficulty()));
            SpawnAttacker();
        }
    }

    public void StopSpawning()
    {
        spawn = false;
    }
 
    private void SpawnAttacker()
    {
        var attackerIndex = UnityEngine.Random.Range(0, attackerTypeArray.Length);
        Spawn(attackerTypeArray[attackerIndex]);
    }

    private void Spawn(Attacker nextAttacker)
    {
        Attacker newAttacker = Instantiate(
                                nextAttacker,
                                transform.position,
                                transform.rotation) as Attacker;
        newAttacker.transform.parent = transform;
    }
}
