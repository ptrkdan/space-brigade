using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    const string PROJECTILE_PARENT_NAME = "Projectiles";

    [SerializeField] Projectile projectilePrefab;
    [SerializeField] GameObject weaponPos;

    GameObject projectileParent;

    private void Start()
    {
        SetProjectileParent();
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
