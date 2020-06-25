using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponChanger : MonoBehaviour
{
    [SerializeField] private Player_Shoot Player_Shoot;
    [SerializeField] private GameObject[] weaponPrefabsArray = new GameObject[0];
    [SerializeField] private GameObject[] weaponStats = new GameObject[0];

    [SerializeField] private Button btn_WeaponRight;
    [SerializeField] private Button btn_WeaponLeft;

    public int weaponIndex;
    private GameObject oldWeapon;
    private GameObject oldWeaponStat;

    private void Start()
    {
        btn_WeaponRight.onClick.AddListener(ChangeWeaponRight);
        btn_WeaponLeft.onClick.AddListener(ChangeWeaponLeft);

        weaponIndex = -1;
        ChangeWeapon(1);
    }

    private void ChangeWeapon(int side)
    {
        if(oldWeapon != null)
        {
            Destroy(oldWeapon);
            oldWeaponStat.SetActive(false);
        }

        weaponIndex += side;

        if (weaponIndex == -1)
            weaponIndex = weaponPrefabsArray.Length - 1;

        if (weaponIndex == weaponPrefabsArray.Length)
            weaponIndex = 0;

        weaponStats[weaponIndex].SetActive(true);

        GameObject newWeapon = Instantiate(weaponPrefabsArray[weaponIndex], transform.position, Quaternion.identity);
        Weapon weaponComponent = newWeapon.GetComponent<Weapon>();

        GameObject bullet = weaponComponent.GetBullet();
        float shootReloadTime = weaponComponent.GetShootReloadTime();
        Transform shootPosition = weaponComponent.GetShootPosition();
        float range = weaponComponent.GetShootRange();

        Transform gunHolder = Player_Shoot.NewWeaponEquipped(bullet, shootReloadTime, shootPosition, range);

        newWeapon.transform.rotation = gunHolder.rotation;
        newWeapon.transform.position = gunHolder.position;
        newWeapon.transform.SetParent(gunHolder);

        oldWeapon = newWeapon;
        oldWeaponStat = weaponStats[weaponIndex];

        if (weaponIndex == weaponPrefabsArray.Length)
            weaponIndex = 0;
    }

    private void ChangeWeaponRight()
    {
        ChangeWeapon(1);
    }

    private void ChangeWeaponLeft()
    {
        ChangeWeapon(-1);
    }
}
