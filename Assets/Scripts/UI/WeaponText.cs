using UnityEngine;
using TMPro;
public class WeaponText : MonoBehaviour
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
        text.text = weaponController.weapon.name;
    }
}
