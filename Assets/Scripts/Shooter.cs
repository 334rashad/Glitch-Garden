using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectile, gun;

    private void Start()
    {
        SetLaneSpawner();
    }

    private void Update()
    {
        if (AttackerIsComing())
        {
            Debug.Log("Shoot! \n");
        } else
        {
            Debug.Log("Position clean");
        }
    }

    private void SetLaneSpawner()
    {
        throw new NotImplementedException();
    }

    private bool AttackerIsComing()
    {
        throw new NotImplementedException();
    }

    public void Fire()
    {
        Instantiate(projectile, gun.transform.position, transform.rotation);
    }
}
