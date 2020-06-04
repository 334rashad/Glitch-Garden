using System;
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
            yield return new WaitForSeconds(UnityEngine.Random.Range(minSpawnDelay, maxSpawnDelay));
            SpawnAttacker();
        }
    }

    private void SpawnAttacker()
    {
        var attackerIndex = System.Random.Range(0, attackerTypeArray.Length);
    }

    private void Spawn(Attacker nextAttacker)
    {
        Attacker newAttacker = Instantiate(
                                attackerType,
                                transform.position,
                                transform.rotation) as Attacker;
        newAttacker.transform.parent = transform;
    }
}
