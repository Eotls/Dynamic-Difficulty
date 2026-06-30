using UnityEditor;
using UnityEngine;
using System;

[CustomEditor(typeof(Weapon))]
public class WeaponEditor : Editor
{
    public override void OnInspectorGUI()
    {
        Weapon weapon = (Weapon)target;

        DrawDefaultInspector();

        GUILayout.Label("Current Ammo: " + weapon.currentAmmo + " / " + weapon.maxAmmo);
        GUILayout.Label("Current Ammo: " + weapon.reserveAmmo + " / " + weapon.maxReserveAmmo);
    }
}
