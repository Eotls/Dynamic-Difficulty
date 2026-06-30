using TMPro;
using UnityEngine;

public class AmmoText : MonoBehaviour
{
    TextMeshProUGUI text;

    [SerializeField]

    WeaponController weaponController;

    private void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        text.text = weaponController.weapon.currentAmmo + " / " + weaponController.weapon.reserveAmmo;
    }
}
