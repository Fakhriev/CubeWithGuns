using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponEquiper : MonoBehaviour
{
    [SerializeField] private Player_Shoot Player_Shoot;
    [SerializeField] private GameObject[] weapon = new GameObject[0];
    private int weaponIndex;

    private void Start()
    {
        weaponIndex = PlayerPrefs.GetInt("Weapon");
        EquipWeapon();
    }

    private void EquipWeapon()
    {
        GameObject newWeapon = Instantiate(weapon[weaponIndex], transform.position, Quaternion.identity);
        Weapon weaponComponent = newWeapon.GetComponent<Weapon>();

        GameObject bullet = weaponComponent.GetBullet();
        float shootReloadTime = weaponComponent.GetShootReloadTime();
        Transform shootPosition = weaponComponent.GetShootPosition();
        float range = weaponComponent.GetShootRange();
        AudioClip clip = weaponComponent.GetShootSound();

        Transform gunHolder = Player_Shoot.NewWeaponEquipped(bullet, shootReloadTime, shootPosition, range, clip);

        newWeapon.transform.rotation = gunHolder.rotation;
        newWeapon.transform.position = gunHolder.position;
        newWeapon.transform.SetParent(gunHolder);
    }
}
