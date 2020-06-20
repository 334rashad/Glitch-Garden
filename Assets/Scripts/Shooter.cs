using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectile, gun;
    AttackerSpawner myLaneSpawner;
    Animator animator;
    GameObject projectileParent;
    const string PROJECTILE_PARENT_NAME = "Projectiles";

    private void CreateProjectileParent()
    {
        projectileParent = GameObject.Find(PROJECTILE_PARENT_NAME);
        if (!projectileParent)
        {
            projectileParent = new GameObject(PROJECTILE_PARENT_NAME);
        }
    }

    private void Start()
    {
        SetLaneSpawner();
        animator = GetComponent<Animator>();
        CreateProjectileParent();
    }

    private void Update()
    {
        if (AttackerIsComing())
        {
            animator.SetBool("isAttacking", true);
        } else
        {
            animator.SetBool("isAttacking", false);
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
        GameObject newProjectile = Instantiate(projectile, 
            gun.transform.position, 
            transform.rotation) as GameObject;
        newProjectile.transform.parent = projectileParent.transform;

    }
}
