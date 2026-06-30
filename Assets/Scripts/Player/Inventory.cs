using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Weapon> weapons = new();
    [SerializeField]
    WeaponHolder weaponHolder;

    public void AddWeapon(Weapon weapon)
    {

        if (!weapons.Contains(weapon))
        {
            weapons.Add(weapon);
            weapons.Remove(weapons[weaponHolder.currentWeaponIndex]);
        }
    }
}
