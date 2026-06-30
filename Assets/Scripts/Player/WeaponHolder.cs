using UnityEngine;
using System;
using UnityEngine.InputSystem;
using System.Collections;
using Unity.VisualScripting;

public class WeaponHolder : MonoBehaviour
{
    public int currentWeaponIndex;
    public Weapon weapon;

    [SerializeField]
    Inventory inventory;

    [SerializeField]
    WeaponController controller;

    private void Start()
    {
        currentWeaponIndex = 0;
    }

    public void NextWeapon()
    {
        currentWeaponIndex += 1;
        SetWeapon(currentWeaponIndex);
        
    }

    public void PreviousWeapon()
    {
        currentWeaponIndex -= 1;
        SetWeapon(currentWeaponIndex);
        
    }

    void SetWeapon(int weaponIndex)
    {
        int index = Mathf.Clamp(weaponIndex, 0, inventory.weapons.Count);
        controller.EquipWeapon(inventory.weapons[index]);
        currentWeaponIndex = weaponIndex;  
    }

    public void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SetWeapon(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SetWeapon(1);
        }
    }




}
