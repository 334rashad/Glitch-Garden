using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectile, gun;
    AttackerSpawner myLaneSpawner;

    private void Start()
    {
        SetLaneSpawner();
    }

    private void Update()
    {
        if (AttackerIsComing())
        {
            Debug.Log("Shoot!");
        } else
        {
            Debug.Log("Position clean");
        }
    }

    private void SetLaneSpawner()
    {
        AttackerSpawner[] attSpawners = FindObjectsOfType<AttackerSpawner>();

        foreach (AttackerSpawner spawner in attSpawners)
        {
            bool isOnSameLane = (Mathf.Abs(spawner.transform.position.y - 
                transform.position.y) <= Mathf.Epsilon);
            if (isOnSameLane) { 
                myLaneSpawner = spawner;
            }
        }

    }

    private bool AttackerIsComing()
    {
        return myLaneSpawner.transform.childCount > 0;
    }

    public void Fire()
    {
        Instantiate(projectile, gun.transform.position, transform.rotation);
    }
}
