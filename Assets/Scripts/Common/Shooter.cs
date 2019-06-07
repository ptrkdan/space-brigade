using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    const string PROJECTILE_PARENT_NAME = "Projectiles";

    [SerializeField] Projectile projectilePrefab;
    [SerializeField] GameObject weaponPos;

    Animator myAnimator;
    LaneSpawner myLaneSpawner;
    GameObject projectileParent;

    private void Start()
    {
        myAnimator = GetComponent<Animator>();
        SetLaneSpawner();
        SetProjectileParent();
    }

    private void Update()
    {
        if (IsAttackerInLane())
        {
            myAnimator.SetBool("isAttacking", true);
        }
        else
        {
            myAnimator.SetBool("isAttacking", false);
        }
    }

    private void SetLaneSpawner()
    {
        LaneSpawner[] laneSpawnerArray = FindObjectsOfType<LaneSpawner>();
        foreach (LaneSpawner spawner in laneSpawnerArray)
        {
            bool isCloseEnough = Math.Abs(spawner.transform.position.y - transform.position.y) <= Mathf.Epsilon;
            if (isCloseEnough)
            {
                myLaneSpawner = spawner;
                break;
            }
        }
    }

    private bool IsAttackerInLane()
    {
        return (myLaneSpawner.transform.childCount > 0) ? true : false;
    }

    private void SetProjectileParent()
    {
        projectileParent = GameObject.Find(PROJECTILE_PARENT_NAME);
        if (!projectileParent)
        {
            projectileParent = new GameObject(PROJECTILE_PARENT_NAME);
        }
    }

    public void Fire()
    {
        Debug.Log($"{gameObject.name} fires projectile");
        Projectile newProjectile = Instantiate(projectilePrefab, weaponPos.transform.position, weaponPos.transform.rotation);
        newProjectile.transform.parent = projectileParent.transform;
    }
}
