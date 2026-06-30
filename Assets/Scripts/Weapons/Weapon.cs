using UnityEngine;
using System.Collections;
using System;

[Serializable]
[CreateAssetMenu]
public class Weapon : ScriptableObject
{
    GameObject visualsPrefab;

    // firing
    public float damage;
    public float headshotMultiplier;
    public float fireRate;

    // ammo
    public int currentAmmo { get; private set; }
    public int maxAmmo;
    private int ammoNeeded;

    public int reserveAmmo { get; private set; }
    public int maxReserveAmmo;

    // reloading
    public bool isFullAuto;

    public float reloadSpeed;
    public float fullReloadSpeed;


    public void Fire()
    {
        if (currentAmmo <= 0) return;
        currentAmmo--;
    }
    private void OnEnable()
    {
        currentAmmo = maxAmmo;
        reserveAmmo = maxReserveAmmo;
        
    }
     public bool AttemptReload()
    {
        if (currentAmmo == maxAmmo) return false;
        ammoNeeded = maxAmmo - currentAmmo;

        if (ammoNeeded > reserveAmmo)
        {
            currentAmmo += reserveAmmo;
            reserveAmmo = 0;
           
        }
        if (ammoNeeded <= reserveAmmo)
        {
            currentAmmo += ammoNeeded;
            reserveAmmo -= ammoNeeded;
           
        }
        return true;
    }
}
