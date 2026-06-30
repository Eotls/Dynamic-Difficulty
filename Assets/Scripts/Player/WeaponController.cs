using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Jobs;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public Weapon weapon;
    public Inventory inventory;
    public Camera cam;
    private int weaponSlot;
    public WeaponHolder weaponHolder;
    public bool isReloading = false;
    [HideInInspector]
    public bool isAiming;
    bool isFiring = false;
    private bool canShoot => !isReloading && weapon.currentAmmo > 0 && !isFiring;

    Coroutine rapidFire;
    Coroutine aiming;

    [SerializeField]
    Transform firePoint;

    [SerializeField]
    LayerMask hitboxLayer;

    //Ammo code
    public void Start()
    {
        weapon = inventory.weapons[0];
        weaponSlot = inventory.weapons.Count - 1;
    }
    
    //Shooting code
    public void Update()
    {
        if (Input.GetMouseButtonDown(0) && canShoot) StartFiring();

        if (Input.GetMouseButtonUp(0)) StopFiring();

        if (Input.GetMouseButtonDown(1) && !isReloading) StartAiming();

        if (Input.GetMouseButtonUp(1)) StopAiming();
        
        if (Input.GetKeyDown(KeyCode.R) && weapon.currentAmmo <= weapon.maxAmmo) AttemptReload();
    }

    public void StartAiming()
    {
        if (aiming != null) return;
        aiming = StartCoroutine(Aim());
    }
    IEnumerator Aim()
    {
        while (true)
        {
            Vector3 origin = new Vector3(transform.position.x, transform.position.y + 0.75f, transform.position.z);
            Vector3 direction = cam.transform.forward;
            Ray ray = new Ray(origin, direction);
            RaycastHit hit;
            Physics.Raycast(ray, out hit, 1000f, hitboxLayer);
            if (hit.collider == null)
            {
                yield return null;
                continue;
            }
            EnemyHitbox hitbox = hit.collider.GetComponent<EnemyHitbox>();
            hitbox.AimedAt();
            yield return null;
       
        }
    }
    public void StopAiming()
    {
        if (aiming == null) return;
        StopCoroutine(aiming);
        aiming = null;
    }
    public void StartFiring()
    {
        if (isFiring) return;
        if (rapidFire != null) return;
        rapidFire = StartCoroutine(RapidFiring());
        isFiring = true;
    }
    public void StopFiring()
    {
        if (!isFiring) return;
        if (rapidFire == null) return;
        StopCoroutine(rapidFire);
        isFiring = false;
        rapidFire = null;
    }

    IEnumerator RapidFiring()
    {
        Shoot();
        yield return new WaitForSeconds(1 / weapon.fireRate);

        while (weapon.isFullAuto)
        {
            Shoot();
            yield return new WaitForSeconds(1 / weapon.fireRate);
        }

        isFiring = false;
        rapidFire = null;
    }

    public void Shoot()
    {
        weapon.Fire();
        Vector3 origin = new Vector3(transform.position.x, transform.position.y + 0.75f, transform.position.z);
        Vector3 direction = cam.transform.forward;

        Ray ray = new Ray(origin, direction);
        RaycastHit hit;
        Physics.Raycast(ray, out hit, 1000f, hitboxLayer);

        if (hit.collider == null) return;

        EnemyHitbox hitbox = hit.collider.GetComponent<EnemyHitbox>();

        if (hitbox == null) return;

        hitbox.Hit(weapon.damage);
        

        if (weapon.currentAmmo <= 0)
        {
            AttemptReload();
        }
    }

    public void EquipWeapon(Weapon newWeapon)
    {
        weapon = newWeapon;
    }

    public void AttemptReload()
    {
        if (isReloading) return;
        if (weapon.currentAmmo == weapon.maxAmmo) return;

        StartCoroutine(Reload());
        isReloading = true;
    }

    IEnumerator Reload()
    { 
        yield return new WaitForSeconds(weapon.reloadSpeed);
        weapon.AttemptReload();
        isReloading = false;
    }
}
