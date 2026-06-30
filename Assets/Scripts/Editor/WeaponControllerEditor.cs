using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.TerrainTools;
using UnityEngine;

[CustomEditor(typeof(WeaponController))]
public class WeaponControllerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        WeaponController controller = (WeaponController)target;

        DrawDefaultInspector();

        GUILayout.Label("Current Ammo: " + controller.weapon.currentAmmo + " / " + controller.weapon.maxAmmo);
        GUILayout.Label("Current Ammo: " + controller.weapon.reserveAmmo + " / " + controller.weapon.maxReserveAmmo);
    }
}
